using System;
using System.Collections.Generic;
using System.IO;
using ExtraStudentsProject;
using UnityEngine;

// Token: 0x0200000A RID: 10
[Serializable]
public class ExtraTopicJson : JsonData
{
	// Token: 0x1700001B RID: 27
	// (get) Token: 0x06000043 RID: 67 RVA: 0x00002497 File Offset: 0x00000697
	public static string FilePath
	{
		get
		{
			if (!GameGlobals.Eighties)
			{
				return Path.Combine(JsonData.FolderPath, "Extras/ExtraTopics.json");
			}
			return Path.Combine(JsonData.FolderPath, "Extras/ExtraEightiesTopics.json");
		}
	}

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x06000044 RID: 68 RVA: 0x000024BF File Offset: 0x000006BF
	public int[] Topics => _topics;

	// Token: 0x06000045 RID: 69 RVA: 0x00004798 File Offset: 0x00002998
	public static ExtraTopicJson[] LoadFromJson(string path)
	{
		SettingsManager = GameObject.Find("StudentManager").GetComponent<ExtraStudentsSettingsManager>();
		ExtraTopicJson[] array = new ExtraTopicJson[SettingsManager.ExtraStudentAmount];
		Dictionary<string, object>[] array2 = JsonData.Deserialize(path);
		foreach (Dictionary<string, object> d in array2)
		{
			int num = TFUtils.LoadInt(d, "ID");
			if (num == 0)
			{
				break;
			}
			array[num] = new ExtraTopicJson();
			ExtraTopicJson extraTopicJson = array[num];
			extraTopicJson._topics = new int[26];
			for (int j = 1; j <= 25; j++)
			{
				extraTopicJson._topics[j] = TFUtils.LoadInt(d, j.ToString());
			}
		}
		return array;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00002294 File Offset: 0x00000494
	public ExtraTopicJson()
	{
		UselessCall.Noop();
	}

	// Token: 0x04000062 RID: 98
	[SerializeField]
	private int[] _topics;

	// Token: 0x04000063 RID: 99
	public static ExtraStudentsSettingsManager SettingsManager;
}

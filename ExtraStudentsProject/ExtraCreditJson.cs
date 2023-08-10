using System;
using System.Collections.Generic;
using System.IO;
using ExtraStudentsProject;

// Token: 0x02000003 RID: 3
[Serializable]
public class ExtraCreditJson : JsonData
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000003 RID: 3 RVA: 0x00002273 File Offset: 0x00000473
	public static string FilePath => Path.Combine(JsonData.FolderPath, "Credits.json");

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000004 RID: 4 RVA: 0x00002284 File Offset: 0x00000484
	public string Name => name;

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000005 RID: 5 RVA: 0x0000228C File Offset: 0x0000048C
	public int Size => size;

	// Token: 0x06000006 RID: 6 RVA: 0x00002C4C File Offset: 0x00000E4C
	public static ExtraCreditJson[] LoadFromJson(string path)
	{
		List<ExtraCreditJson> list = new List<ExtraCreditJson>();
		Dictionary<string, object>[] array = JsonData.Deserialize(path);
		foreach (Dictionary<string, object> dictionary in array)
		{
			ExtraCreditJson extraCreditJson = new ExtraCreditJson();
			extraCreditJson.name = TFUtils.LoadString(dictionary, "Name");
			extraCreditJson.size = TFUtils.LoadInt(dictionary, "Size");
			list.Add(extraCreditJson);
		}
		return list.ToArray();
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002294 File Offset: 0x00000494
	public ExtraCreditJson()
	{
		UselessCall.Noop();
	}

	// Token: 0x04000002 RID: 2
	public string name;

	// Token: 0x04000003 RID: 3
	public int size;
}

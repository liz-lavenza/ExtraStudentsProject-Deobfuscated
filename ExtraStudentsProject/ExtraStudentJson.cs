using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ExtraStudentsProject;
using UnityEngine;

// Token: 0x02000009 RID: 9
[Serializable]
public class ExtraStudentJson : JsonData
{
	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000022 RID: 34 RVA: 0x00002373 File Offset: 0x00000573
	public static string FilePath
	{
		get
		{
			if (!GameGlobals.Eighties)
			{
				return Path.Combine(JsonData.FolderPath, "Extras/ExtraStudents.json");
			}
			return Path.Combine(JsonData.FolderPath, "Extras/ExtraEighties.json");
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000023 RID: 35 RVA: 0x0000239B File Offset: 0x0000059B
	// (set) Token: 0x06000024 RID: 36 RVA: 0x000023A3 File Offset: 0x000005A3
	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000025 RID: 37 RVA: 0x000023AC File Offset: 0x000005AC
	// (set) Token: 0x06000026 RID: 38 RVA: 0x000023B4 File Offset: 0x000005B4
	public string RealName
	{
		get
		{
			return _realname;
		}
		set
		{
			_realname = value;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000027 RID: 39 RVA: 0x000023BD File Offset: 0x000005BD
	public int Gender => _gender;

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000028 RID: 40 RVA: 0x000023C5 File Offset: 0x000005C5
	// (set) Token: 0x06000029 RID: 41 RVA: 0x000023CD File Offset: 0x000005CD
	public int Class
	{
		get
		{
			return _class;
		}
		set
		{
			_class = value;
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x0600002A RID: 42 RVA: 0x000023D6 File Offset: 0x000005D6
	// (set) Token: 0x0600002B RID: 43 RVA: 0x000023DE File Offset: 0x000005DE
	public int Seat
	{
		get
		{
			return _seat;
		}
		set
		{
			_seat = value;
		}
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x0600002C RID: 44 RVA: 0x000023E7 File Offset: 0x000005E7
	public ClubType Club => _club;

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x0600002D RID: 45 RVA: 0x000023EF File Offset: 0x000005EF
	// (set) Token: 0x0600002E RID: 46 RVA: 0x000023F7 File Offset: 0x000005F7
	public PersonaType Persona
	{
		get
		{
			return _persona;
		}
		set
		{
			_persona = value;
		}
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x0600002F RID: 47 RVA: 0x00002400 File Offset: 0x00000600
	public int Crush => _crush;

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000030 RID: 48 RVA: 0x00002408 File Offset: 0x00000608
	// (set) Token: 0x06000031 RID: 49 RVA: 0x00002410 File Offset: 0x00000610
	public float BreastSize
	{
		get
		{
			return _breastsize;
		}
		set
		{
			_breastsize = value;
		}
	}

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000032 RID: 50 RVA: 0x00002419 File Offset: 0x00000619
	// (set) Token: 0x06000033 RID: 51 RVA: 0x00002421 File Offset: 0x00000621
	public int Strength
	{
		get
		{
			return _strength;
		}
		set
		{
			_strength = value;
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x06000034 RID: 52 RVA: 0x0000242A File Offset: 0x0000062A
	// (set) Token: 0x06000035 RID: 53 RVA: 0x00002432 File Offset: 0x00000632
	public string Hairstyle
	{
		get
		{
			return _hairstyle;
		}
		set
		{
			_hairstyle = value;
		}
	}

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x06000036 RID: 54 RVA: 0x0000243B File Offset: 0x0000063B
	public string Color => _color;

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x06000037 RID: 55 RVA: 0x00002443 File Offset: 0x00000643
	public string Eyes => _eyes;

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x06000038 RID: 56 RVA: 0x0000244B File Offset: 0x0000064B
	public string EyeType => _eyetype;

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x06000039 RID: 57 RVA: 0x00002453 File Offset: 0x00000653
	public string Stockings => _stockings;

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x0600003A RID: 58 RVA: 0x0000245B File Offset: 0x0000065B
	// (set) Token: 0x0600003B RID: 59 RVA: 0x00002463 File Offset: 0x00000663
	public string Accessory
	{
		get
		{
			return _accessory;
		}
		set
		{
			_accessory = value;
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x0600003C RID: 60 RVA: 0x0000246C File Offset: 0x0000066C
	public string Info => _info;

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x0600003D RID: 61 RVA: 0x00002474 File Offset: 0x00000674
	public ScheduleBlock[] ScheduleBlocks => _scheduleblocks;

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x0600003E RID: 62 RVA: 0x0000247C File Offset: 0x0000067C
	public bool Success => _success;

	// Token: 0x0600003F RID: 63 RVA: 0x000044A0 File Offset: 0x000026A0
	public static ExtraStudentJson[] LoadFromJson(string path)
	{
		SettingsManager = GameObject.Find("StudentManager").GetComponent<ExtraStudentsSettingsManager>();
		ExtraStudentJson[] array = new ExtraStudentJson[SettingsManager.ExtraStudentAmount];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ExtraStudentJson();
		}
		Dictionary<string, object>[] array2 = JsonData.Deserialize(path);
		foreach (Dictionary<string, object> dictionary in array2)
		{
			int num = TFUtils.LoadInt(dictionary, "ID");
			if (num == 0)
			{
				break;
			}
			if (SettingsManager != null)
			{
				ExtraStudentJson extraStudentJson = array[num];
				extraStudentJson._name = TFUtils.LoadString(dictionary, "Name");
				extraStudentJson._realname = TFUtils.LoadString(dictionary, "RealName");
				extraStudentJson._gender = TFUtils.LoadInt(dictionary, "Gender");
				extraStudentJson._class = TFUtils.LoadInt(dictionary, "Class");
				extraStudentJson._seat = TFUtils.LoadInt(dictionary, "Seat");
				extraStudentJson._club = (ClubType)TFUtils.LoadInt(dictionary, "Club");
				extraStudentJson._persona = (PersonaType)TFUtils.LoadInt(dictionary, "Persona");
				extraStudentJson._crush = TFUtils.LoadInt(dictionary, "Crush");
				extraStudentJson._breastsize = TFUtils.LoadFloat(dictionary, "BreastSize");
				extraStudentJson._strength = TFUtils.LoadInt(dictionary, "Strength");
				extraStudentJson._hairstyle = TFUtils.LoadString(dictionary, "Hairstyle");
				extraStudentJson._color = TFUtils.LoadString(dictionary, "Color");
				extraStudentJson._eyes = TFUtils.LoadString(dictionary, "Eyes");
				extraStudentJson._eyetype = TFUtils.LoadString(dictionary, "EyeType");
				extraStudentJson._stockings = TFUtils.LoadString(dictionary, "Stockings");
				extraStudentJson._accessory = TFUtils.LoadString(dictionary, "Accessory");
				extraStudentJson._info = TFUtils.LoadString(dictionary, "Info");
				if (GameGlobals.LoveSick)
				{
					extraStudentJson._name = extraStudentJson._realname;
					extraStudentJson._realname = "";
				}
				if (OptionGlobals.HighPopulation && extraStudentJson._name == "Unknown")
				{
					extraStudentJson._name = "Random";
				}
				float[] array3 = split_floats(TFUtils.LoadString(dictionary, "ScheduleTime"));
				string[] array4 = split_strings(TFUtils.LoadString(dictionary, "ScheduleDestination"));
				string[] array5 = split_strings(TFUtils.LoadString(dictionary, "ScheduleAction"));
				extraStudentJson._scheduleblocks = new ScheduleBlock[array3.Length];
				for (int k = 0; k < extraStudentJson._scheduleblocks.Length; k++)
				{
					extraStudentJson._scheduleblocks[k] = new ScheduleBlock(array3[k], array4[k], array5[k]);
				}
				extraStudentJson._success = true;
			}
		}
		return array;
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00004744 File Offset: 0x00002944
	private static float[] split_floats(string string_0)
	{
		string[] array = string_0.Split('_');
		float[] array2 = new float[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			if (float.TryParse(array[i], NumberStyles.Float, NumberFormatInfo.InvariantInfo, out var result))
			{
				array2[i] = result;
			}
		}
		return array2;
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00002484 File Offset: 0x00000684
	private static string[] split_strings(string string_0)
	{
		return string_0.Split('_');
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00002294 File Offset: 0x00000494
	public ExtraStudentJson()
	{
		UselessCall.Noop();
	}

	// Token: 0x0400004E RID: 78
	[SerializeField]
	private string _name;

	// Token: 0x0400004F RID: 79
	[SerializeField]
	private string _realname;

	// Token: 0x04000050 RID: 80
	[SerializeField]
	private int _gender;

	// Token: 0x04000051 RID: 81
	[SerializeField]
	private int _class;

	// Token: 0x04000052 RID: 82
	[SerializeField]
	private int _seat;

	// Token: 0x04000053 RID: 83
	[SerializeField]
	private ClubType _club;

	// Token: 0x04000054 RID: 84
	[SerializeField]
	private PersonaType _persona;

	// Token: 0x04000055 RID: 85
	[SerializeField]
	private int _crush;

	// Token: 0x04000056 RID: 86
	[SerializeField]
	private float _breastsize;

	// Token: 0x04000057 RID: 87
	[SerializeField]
	private int _strength;

	// Token: 0x04000058 RID: 88
	[SerializeField]
	private string _hairstyle;

	// Token: 0x04000059 RID: 89
	[SerializeField]
	private string _color;

	// Token: 0x0400005A RID: 90
	[SerializeField]
	private string _eyes;

	// Token: 0x0400005B RID: 91
	[SerializeField]
	private string _eyetype;

	// Token: 0x0400005C RID: 92
	[SerializeField]
	private string _stockings;

	// Token: 0x0400005D RID: 93
	[SerializeField]
	private string _accessory;

	// Token: 0x0400005E RID: 94
	[SerializeField]
	private string _info;

	// Token: 0x0400005F RID: 95
	[SerializeField]
	private ScheduleBlock[] _scheduleblocks;

	// Token: 0x04000060 RID: 96
	[SerializeField]
	private bool _success;

	// Token: 0x04000061 RID: 97
	public static ExtraStudentsSettingsManager SettingsManager;
}

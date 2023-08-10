using System;
using System.IO;
using ExtraStudentsProject;
using ExtraStudentsProject.ExtraStudentsMainModule;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000006 RID: 6
public class ExtraStudentsSettingsManager : MonoBehaviour
{
	// Token: 0x06000014 RID: 20 RVA: 0x00003634 File Offset: 0x00001834
	private void Update()
	{
		if (injected)
		{
			return;
		}
		if (SceneManager.GetActiveScene().name != "ResolutionScene")
		{
			SlotsManager = GameObject.Find("MainHandler").GetComponent<ExtraStudentsNewSlotsScript>();
			StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		}
		else
		{
			ResolutionScreenInjector = GameObject.Find("MainHandler").GetComponent<ResolutionScreenInjectorScript>();
		}
		if (!File.Exists(Path.Combine(Application.streamingAssetsPath + SettingsFile)))
		{
			return;
		}
		AllCommands = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath + SettingsFile));
		if (File.Exists(Path.Combine(Application.streamingAssetsPath + ReputationsFile)))
		{
			AllReps = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath + ReputationsFile));
		}
		else
		{
			File.Create(Path.Combine(Application.streamingAssetsPath + ReputationsFile));
		}
		if (SceneManager.GetActiveScene().name != "ResolutionScene")
		{
			for (int i = 0; i < AllCommands.Length; i++)
			{
				Week2Update = AllCommands[i].Split(':');
				AmountCommand = AllCommands[i].Split(':');
				UpdateStudentAmount();
				if (Week2Update[0] == "Week2HangoutsUpdate")
				{
					switch (Week2Update[1])
					{
					case "1":
					case "true":
					case "True":
					case "T":
					case "t":
						SlotsManager.Week2Update = true;
						break;
					default:
						SlotsManager.Week2Update = false;
						break;
					}
				}
			}
			SetReputations();
		}
		else
		{
			for (int j = 0; j < AllCommands.Length; j++)
			{
				CustomRPC = AllCommands[j].Split(':');
				if (CustomRPC[0] == "DiscordCustomRichPresence")
				{
					switch (CustomRPC[1])
					{
					case "1":
					case "true":
					case "True":
					case "T":
					case "t":
						ResolutionScreenInjector.DiscordNeedsInjection = true;
						ResolutionScreenInjector.InjectExtraDiscordHandler();
						break;
					default:
						ResolutionScreenInjector.DiscordNeedsInjection = false;
						break;
					}
				}
			}
		}
		injected = true;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00003B18 File Offset: 0x00001D18
	private void UpdateStudentAmount()
	{
		if (AmountCommand[0] == "ExtraStudents" && AmountCommand[1] != string.Empty)
		{
			StudentAmount = int.Parse(AmountCommand[1]);
			if (StudentAmount > 0)
			{
				ExtraStudentAmount = StudentAmount + 101;
				SlotsManager.Students = ExtraStudentAmount;
			}
			else
			{
				ExtraStudentAmount = 0;
			}
		}
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00003B94 File Offset: 0x00001D94
	private void SetReputations()
	{
		Array.Resize(ref StudentManager.StudentReps, StudentManager.Students.Length);
		for (int i = 0; i < AllReps.Length; i++)
		{
			Reputations = AllReps[i].Split(':');
			if (Reputations[0] == null && !(Reputations[0] != string.Empty))
			{
				continue;
			}
			int.TryParse(Reputations[0], out var result);
			if (result > 100)
			{
				Debug.Log("''Reputation'' StudentID is: " + result + ".");
				if ((Reputations[1] != null || Reputations[1] != string.Empty) && (Reputations[2] != null || Reputations[2] != string.Empty) && (Reputations[3] != null || Reputations[3] != string.Empty))
				{
					Debug.Log("Reputation value is valid! Applying Student #" + result + " reputation. The rep. is: " + Reputations[1] + " " + Reputations[2] + " " + Reputations[3]);
					int.TryParse(Reputations[1], out var result2);
					int.TryParse(Reputations[2], out var result3);
					int.TryParse(Reputations[3], out var result4);
					StudentGlobals.SetReputationTriangle(result, new Vector3(result2, result3, result4));
				}
			}
			else
			{
				Debug.Log("StudentID is not valid.");
			}
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x0000233D File Offset: 0x0000053D
	public ExtraStudentsSettingsManager()
	{
		SettingsFile = "/ExtraStudents/ExtraStudentsSettings.txt";
		ReputationsFile = "/ExtraStudents/ExtraStudentsReputations.txt";
	}

	// Token: 0x0400002A RID: 42
	public ExtraStudentsNewSlotsScript SlotsManager;

	// Token: 0x0400002B RID: 43
	public StudentManagerScript StudentManager;

	// Token: 0x0400002C RID: 44
	private bool injected;

	// Token: 0x0400002D RID: 45
	private string SettingsFile;

	// Token: 0x0400002E RID: 46
	private string ReputationsFile;

	// Token: 0x0400002F RID: 47
	public string[] AllCommands;

	// Token: 0x04000030 RID: 48
	public string[] AllSpots;

	// Token: 0x04000031 RID: 49
	public string[] AllReps;

	// Token: 0x04000032 RID: 50
	public string[] AmountCommand;

	// Token: 0x04000033 RID: 51
	public string[] Week2Update;

	// Token: 0x04000034 RID: 52
	public string[] Reputations;

	// Token: 0x04000035 RID: 53
	public string[] CustomRPC;

	// Token: 0x04000036 RID: 54
	public int StudentAmount;

	// Token: 0x04000037 RID: 55
	public int ExtraStudentAmount;

	// Token: 0x04000038 RID: 56
	public string[] StudentsSpawnPos;

	// Token: 0x04000039 RID: 57
	public bool UpdateReputations;

	// Token: 0x0400003A RID: 58
	private ResolutionScreenInjectorScript ResolutionScreenInjector;
}

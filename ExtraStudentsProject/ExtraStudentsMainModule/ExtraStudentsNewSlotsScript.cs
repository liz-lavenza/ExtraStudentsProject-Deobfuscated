using System;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExtraStudentsProject.ExtraStudentsMainModule
{
	// Token: 0x0200002B RID: 43
	public class ExtraStudentsNewSlotsScript : MonoBehaviour
	{
		// Token: 0x06000105 RID: 261 RVA: 0x000288FC File Offset: 0x00026AFC
		private void Update()
		{
			if (NPG88cbFRJ)
			{
				return;
			}
			Hya8Krce8D = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			ExtraStudentManager = GameObject.Find("StudentManager").GetComponent<ExtraStudentManagerScript>();
			Array.Resize(ref Hya8Krce8D.Students, Students);
			if (SceneManager.GetActiveScene().name == "SchoolScene")
			{
				Array.Resize(ref Hya8Krce8D.SpawnPositions, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.LockerPositions, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.Lockers.List, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.StudentReps, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.OpinionsLearned.StudentOpinions, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.CommunalLocker.RivalPhone.StolenPhoneDropoff.PhoneHacked, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.Yandere.WeaponManager.Victims, Hya8Krce8D.Students.Length);
				Array.Resize(ref ExtraStudentManager.StudentFirstWeeks, Hya8Krce8D.Students.Length);
				WeaponScript[] weapons = Hya8Krce8D.Yandere.WeaponManager.Weapons;
				foreach (WeaponScript weaponScript in weapons)
				{
					if (weaponScript != null)
					{
						Array.Resize(ref weaponScript.Victims, Hya8Krce8D.Students.Length);
					}
				}
				Array.Resize(ref Hya8Krce8D.Hangouts.List, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.LunchSpots.List, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.Week1Hangouts.List, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.Week2Hangouts.List, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.Stairways.List, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.LunchSpots.List, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.SocialSeats, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.MournSpots, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.SulkSpots, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.StrippingPositions, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.MeetingSpots, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.FridaySpots, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.LunchWitnessPositions.List, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.WaitSpots, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.EightiesSpots.List, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.PerformSpots, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.PhotoShootSpots, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.RivalGuardSpots, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.TargetSize, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.RandomSpots, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.Patrols.List, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.TaskManager.TaskStatus, Hya8Krce8D.Students.Length);
				Array.Resize(ref Hya8Krce8D.Police.EndOfDay.StudentsToArrest, Hya8Krce8D.Students.Length);
				Array.Resize(ref LockerPosition, Hya8Krce8D.Students.Length);
				Array.Resize(ref SpawnPosition, Hya8Krce8D.Students.Length);
				Array.Resize(ref HangoutPosition, Hya8Krce8D.Students.Length);
				Array.Resize(ref Week1HangoutPosition, Hya8Krce8D.Students.Length);
				Array.Resize(ref Week2HangoutPosition, Hya8Krce8D.Students.Length);
				Array.Resize(ref StairwaysPosition, Hya8Krce8D.Students.Length);
				Array.Resize(ref LunchSpotPosition, Hya8Krce8D.Students.Length);
				Array.Resize(ref SocialSeatPosition, Hya8Krce8D.Students.Length);
				Array.Resize(ref MournPosition, Hya8Krce8D.Students.Length);
				Array.Resize(ref SulkPosition, Hya8Krce8D.Students.Length);
				Array.Resize(ref SunbathePosition, Hya8Krce8D.Students.Length);
				Array.Resize(ref MeetingDestination, Hya8Krce8D.Students.Length);
				Array.Resize(ref PaintDestination, Hya8Krce8D.Students.Length);
				Array.Resize(ref LunchtimeDestination, Hya8Krce8D.Students.Length);
				Array.Resize(ref WaitDestination, Hya8Krce8D.Students.Length);
				Array.Resize(ref EightiesDestination, Hya8Krce8D.Students.Length);
				Array.Resize(ref PerformDestination, Hya8Krce8D.Students.Length);
				Array.Resize(ref PhotoShootDestination, Hya8Krce8D.Students.Length);
				Array.Resize(ref GuardDestination, Hya8Krce8D.Students.Length);
				Array.Resize(ref RandomDestination, Hya8Krce8D.Students.Length);
				Array.Resize(ref Target, Hya8Krce8D.Students.Length);
				Array.Resize(ref Follower, Hya8Krce8D.Students.Length);
				Array.Resize(ref LovestruckID, Hya8Krce8D.Students.Length);
				if (Directory.Exists(Path.Combine(Application.streamingAssetsPath + ResourceDirectory)))
				{
					if (File.Exists(Path.Combine(Application.streamingAssetsPath + FullRoutineFile)))
					{
						AllSpots = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath + FullRoutineFile));
					}
					else
					{
						File.Create(Path.Combine(Application.streamingAssetsPath + ResourceDirectory + RoutineFile));
					}
				}
				else
				{
					Directory.CreateDirectory(Path.Combine(Application.streamingAssetsPath + ResourceDirectory));
					File.Create(Path.Combine(Application.streamingAssetsPath + ResourceDirectory + RoutineFile));
				}
				for (int j = 101; j < Hya8Krce8D.Students.Length; j++)
				{
					if (Hya8Krce8D.Students != null)
					{
						LockerPosition[j] = new GameObject("LockerPosition [" + j + "]");
						SpawnPosition[j] = new GameObject("SpawnPosition [" + j + "]");
						HangoutPosition[j] = new GameObject("HangoutPosition [" + j + "]");
						Week1HangoutPosition[j] = new GameObject("Week1HangoutPosition [" + j + "]");
						Week2HangoutPosition[j] = new GameObject("Week2HangoutPosition [" + j + "]");
						StairwaysPosition[j] = new GameObject("StairwaysPosition [" + j + "]");
						LunchSpotPosition[j] = new GameObject("LunchSpotPosition [" + j + "]");
						SocialSeatPosition[j] = new GameObject("SocialSeatPosition [" + j + "]");
						MournPosition[j] = new GameObject("MournPosition [" + j + "]");
						SulkPosition[j] = new GameObject("SulkPosition [" + j + "]");
						SunbathePosition[j] = new GameObject("SunbathePosition [" + j + "]");
						MeetingDestination[j] = new GameObject("MeetingPosition [" + j + "]");
						PaintDestination[j] = new GameObject("FridayPosition [" + j + "]");
						LunchtimeDestination[j] = new GameObject("LunchWitnessPosition [" + j + "]");
						WaitDestination[j] = new GameObject("WaitPosition [" + j + "]");
						EightiesDestination[j] = new GameObject("EightiesDestination [" + j + "]");
						PerformDestination[j] = new GameObject("PerformDestination [" + j + "]");
						PhotoShootDestination[j] = new GameObject("PhotoShootDestination [" + j + "]");
						GuardDestination[j] = new GameObject("GuardDestination [" + j + "]");
						RandomDestination[j] = new GameObject("RandomDestination [" + j + "]");
						Hya8Krce8D.LockerPositions[j] = LockerPosition[j].transform;
						NewSpots = new GameObject("NewSpots [Student #" + j + "]");
						LockerPosition[j].transform.parent = NewSpots.transform;
						SpawnPosition[j].transform.parent = NewSpots.transform;
						HangoutPosition[j].transform.parent = NewSpots.transform;
						Week1HangoutPosition[j].transform.parent = NewSpots.transform;
						Week2HangoutPosition[j].transform.parent = NewSpots.transform;
						StairwaysPosition[j].transform.parent = NewSpots.transform;
						LunchSpotPosition[j].transform.parent = NewSpots.transform;
						SocialSeatPosition[j].transform.parent = NewSpots.transform;
						MournPosition[j].transform.parent = NewSpots.transform;
						SulkPosition[j].transform.parent = NewSpots.transform;
						SunbathePosition[j].transform.parent = NewSpots.transform;
						MeetingDestination[j].transform.parent = NewSpots.transform;
						PaintDestination[j].transform.parent = NewSpots.transform;
						LunchtimeDestination[j].transform.parent = NewSpots.transform;
						WaitDestination[j].transform.parent = NewSpots.transform;
						EightiesDestination[j].transform.parent = NewSpots.transform;
						PerformDestination[j].transform.parent = NewSpots.transform;
						PhotoShootDestination[j].transform.parent = NewSpots.transform;
						GuardDestination[j].transform.parent = NewSpots.transform;
						RandomDestination[j].transform.parent = NewSpots.transform;
					}
				}
				Hya8Krce8D.Lockers.List[97] = Hya8Krce8D.Lockers.List[96];
				Hya8Krce8D.Lockers.List[98] = Hya8Krce8D.Lockers.List[96];
				Hya8Krce8D.Lockers.List[99] = Hya8Krce8D.Lockers.List[96];
				Hya8Krce8D.Lockers.List[100] = Hya8Krce8D.Lockers.List[96];
				Hya8Krce8D.Yandere.PauseScreen.TaskList.Limit = Hya8Krce8D.Students.Length - 1;
				SetLocationManager();
				OpinionsLearned = Hya8Krce8D.GetComponent<ExtraOpinionsLearnedScript>();
				Array.Resize(ref OpinionsLearned.StudentOpinions, Hya8Krce8D.Students.Length);
				for (int k = 1; k < Hya8Krce8D.Students.Length; k++)
				{
					Array.Resize(ref OpinionsLearned.StudentOpinions[k].Opinions, 26);
				}
			}
			NPG88cbFRJ = true;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00029780 File Offset: 0x00027980
		public void SetLocationManager()
		{
			StudentsPositions = new string[Hya8Krce8D.Students.Length];
			for (int i = 0; i < AllSpots.Length; i++)
			{
				StudentsPositions = AllSpots[i].Split(':');
				if (StudentsPositions.Length == 0 || (StudentsPositions[0] == null && !(StudentsPositions[0] != string.Empty)))
				{
					continue;
				}
				int.TryParse(StudentsPositions[0], out var result);
				if (result <= 100 || StudentsPositions.Length <= 1)
				{
					continue;
				}
				Debug.Log("Student #" + StudentsPositions[0] + " '" + StudentsPositions[1] + "' loaded.");
				float result2 = 0f;
				float result3 = 0f;
				float result4 = 0f;
				if (StudentsPositions[1] != "Follow" && StudentsPositions[1] != "Patrol" && StudentsPositions[1] != "SpawnWeek" && StudentsPositions[1] != "LovestruckTarget")
				{
					float.TryParse(StudentsPositions[3], NumberStyles.Float, CultureInfo.InvariantCulture, out result2);
					float.TryParse(StudentsPositions[4], NumberStyles.Float, CultureInfo.InvariantCulture, out result3);
					float.TryParse(StudentsPositions[5], NumberStyles.Float, CultureInfo.InvariantCulture, out result4);
				}
				if (StudentsPositions.Length <= 2)
				{
					continue;
				}
				switch (StudentsPositions[1])
				{
				case "Week2Hangout":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						Week2HangoutPosition[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.Week2Hangouts.List[result] = Week2HangoutPosition[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						Week2HangoutPosition[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.Week2Hangouts.List[result] = Week2HangoutPosition[result].transform;
					}
					if (Week2Update)
					{
						Hya8Krce8D.Students[result].ScheduleBlocks[2].destination = "Week2Hangout";
						ExtraStudentManager.yU9Z1mIPi0(result);
					}
					break;
				case "LunchSpot":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						LunchSpotPosition[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.LunchSpots.List[result] = LunchSpotPosition[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						LunchSpotPosition[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.LunchSpots.List[result] = LunchSpotPosition[result].transform;
					}
					break;
				case "Sunbathe":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						SunbathePosition[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.StrippingPositions[result] = SunbathePosition[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						SunbathePosition[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.StrippingPositions[result] = SunbathePosition[result].transform;
					}
					break;
				case "Wait":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						WaitDestination[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.WaitSpots[result] = WaitDestination[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						WaitDestination[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.WaitSpots[result] = WaitDestination[result].transform;
					}
					break;
				case "SpawnWeek":
					if (StudentsPositions.Length > 2 && (StudentsPositions[2] != null || StudentsPositions[2] != string.Empty))
					{
						int.TryParse(StudentsPositions[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out var result7);
						if (result7 > 0 && result7 < 11)
						{
							Debug.Log("The Student: " + result + " Selected Week is: " + result7);
							ExtraStudentManager.StudentFirstWeeks[result] = result7;
						}
					}
					break;
				case "Mourn":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						MournPosition[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.MournSpots[result] = MournPosition[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						MournPosition[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.MournSpots[result] = MournPosition[result].transform;
					}
					break;
				case "Random":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						RandomDestination[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.RandomSpots[result] = RandomDestination[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						RandomDestination[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.RandomSpots[result] = RandomDestination[result].transform;
					}
					break;
				case "Paint":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						PaintDestination[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.FridaySpots[result] = PaintDestination[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						PaintDestination[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.FridaySpots[result] = PaintDestination[result].transform;
					}
					break;
				case "Perform":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						PerformDestination[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.PerformSpots[result] = PerformDestination[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						PerformDestination[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.PerformSpots[result] = PerformDestination[result].transform;
					}
					break;
				case "SocialSeat":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						SocialSeatPosition[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.SocialSeats[result] = SocialSeatPosition[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						SocialSeatPosition[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.SocialSeats[result] = SocialSeatPosition[result].transform;
					}
					break;
				case "EightiesSpot":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						EightiesDestination[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.EightiesSpots.List[result] = EightiesDestination[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						EightiesDestination[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.EightiesSpots.List[result] = EightiesDestination[result].transform;
					}
					break;
				case "Hangout":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						HangoutPosition[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.Hangouts.List[result] = HangoutPosition[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						HangoutPosition[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.Hangouts.List[result] = HangoutPosition[result].transform;
					}
					break;
				case "LovestruckTarget":
				{
					int.TryParse(StudentsPositions[2], out var result6);
					if (result6 > 0)
					{
						LovestruckID[result] = result6;
					}
					break;
				}
				case "Follow":
				{
					int.TryParse(StudentsPositions[2], out var result5);
					Debug.Log("'Follow' Student Target ID: " + result5 + " StuID: " + result);
					if (result5 > 0 && result > 0)
					{
						Target[result] = result5;
						Follower[result] = result;
					}
					break;
				}
				case "Meeting":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						MeetingDestination[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.MeetingSpots[result] = MeetingDestination[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						MeetingDestination[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.MeetingSpots[result] = MeetingDestination[result].transform;
					}
					break;
				case "PhotoShoot":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						PhotoShootDestination[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.PhotoShootSpots[result] = PhotoShootDestination[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						PhotoShootDestination[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.PhotoShootSpots[result] = PhotoShootDestination[result].transform;
					}
					break;
				case "Patrol":
				{
					if (StudentsPositions.Length <= 2 || (StudentsPositions[2] == null && !(StudentsPositions[2] != string.Empty)))
					{
						break;
					}
					int.TryParse(StudentsPositions[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out var result8);
					if (result8 <= 0 || StudentsPositions.Length <= 3 || (StudentsPositions[3] == null && !(StudentsPositions[3] != string.Empty)) || StudentsPositions.Length <= 4 || (StudentsPositions[4] == null && !(StudentsPositions[4] != string.Empty)) || StudentsPositions.Length <= 5 || (StudentsPositions[5] == null && !(StudentsPositions[5] != string.Empty)) || StudentsPositions.Length <= 6 || (StudentsPositions[6] == null && !(StudentsPositions[6] != string.Empty)))
					{
						break;
					}
					float result9 = 0f;
					float result10 = 0f;
					float result11 = 0f;
					float.TryParse(StudentsPositions[4], NumberStyles.Float, CultureInfo.InvariantCulture, out result9);
					float.TryParse(StudentsPositions[5], NumberStyles.Float, CultureInfo.InvariantCulture, out result10);
					float.TryParse(StudentsPositions[6], NumberStyles.Float, CultureInfo.InvariantCulture, out result11);
					if (GameObject.Find("Patrols/Patrol" + result + "/PatrolPoint" + result8) == null)
					{
						if (result8 == 1)
						{
							new GameObject("Patrol" + result).transform.parent = GameObject.Find("Patrols").transform;
						}
						if (GameObject.Find("Patrols/Patrol" + result) != null)
						{
							GameObject gameObject = new GameObject("PatrolPoint" + result8);
							gameObject.transform.parent = GameObject.Find("Patrols/Patrol" + result).transform;
							if (StudentsPositions[3] == "Pos" || StudentsPositions[3] == "Position" || StudentsPositions[3] == "P" || StudentsPositions[3] == "pos" || StudentsPositions[3] == "position" || StudentsPositions[3] == "p")
							{
								gameObject.transform.localPosition = new Vector3(result9, result10, result11);
							}
							if (StudentsPositions[3] == "Rot" || StudentsPositions[3] == "Rotation" || StudentsPositions[3] == "R" || StudentsPositions[3] == "rot" || StudentsPositions[3] == "rotation" || StudentsPositions[3] == "r")
							{
								gameObject.transform.localEulerAngles = new Vector3(result9, result10, result11);
							}
							Hya8Krce8D.Patrols.List[result] = GameObject.Find("Patrols/Patrol" + result).transform;
						}
					}
					else
					{
						if (StudentsPositions[3] == "Pos" || StudentsPositions[3] == "Position" || StudentsPositions[3] == "P" || StudentsPositions[3] == "pos" || StudentsPositions[3] == "position" || StudentsPositions[3] == "p")
						{
							GameObject.Find("Patrols/Patrol" + result + "/PatrolPoint" + result8).transform.localPosition = new Vector3(result9, result10, result11);
						}
						if (StudentsPositions[3] == "Rot" || StudentsPositions[3] == "Rotation" || StudentsPositions[3] == "R" || StudentsPositions[3] == "rot" || StudentsPositions[3] == "rotation" || StudentsPositions[3] == "r")
						{
							GameObject.Find("Patrols/Patrol" + result + "/PatrolPoint" + result8).transform.localEulerAngles = new Vector3(result9, result10, result11);
						}
						Hya8Krce8D.Patrols.List[result] = GameObject.Find("Patrols/Patrol" + result).transform;
					}
					break;
				}
				case "LunchWitnessPosition":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						LunchtimeDestination[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.LunchWitnessPositions.List[result] = LunchtimeDestination[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						LunchtimeDestination[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.LunchWitnessPositions.List[result] = LunchtimeDestination[result].transform;
					}
					break;
				case "Spawn":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						SpawnPosition[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.SpawnPositions[result] = SpawnPosition[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						SpawnPosition[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.SpawnPositions[result] = SpawnPosition[result].transform;
					}
					break;
				case "Sulk":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						SulkPosition[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.SulkSpots[result] = SulkPosition[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						SulkPosition[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.SulkSpots[result] = SulkPosition[result].transform;
					}
					break;
				case "Stairway":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						StairwaysPosition[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.Stairways.List[result] = StairwaysPosition[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						StairwaysPosition[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.Stairways.List[result] = StairwaysPosition[result].transform;
					}
					break;
				case "Week1Hangout":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						Week1HangoutPosition[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.Week1Hangouts.List[result] = Week1HangoutPosition[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						Week1HangoutPosition[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.Week1Hangouts.List[result] = Week1HangoutPosition[result].transform;
					}
					break;
				case "Guard":
					if (StudentsPositions[2] == "Pos" || StudentsPositions[2] == "Position" || StudentsPositions[2] == "P" || StudentsPositions[2] == "pos" || StudentsPositions[2] == "position" || StudentsPositions[2] == "p")
					{
						GuardDestination[result].transform.position = new Vector3(result2, result3, result4);
						Hya8Krce8D.RivalGuardSpots[result] = GuardDestination[result].transform;
					}
					if (StudentsPositions[2] == "Rot" || StudentsPositions[2] == "Rotation" || StudentsPositions[2] == "R" || StudentsPositions[2] == "rot" || StudentsPositions[2] == "rotation" || StudentsPositions[2] == "r")
					{
						GuardDestination[result].transform.eulerAngles = new Vector3(result2, result3, result4);
						Hya8Krce8D.RivalGuardSpots[result] = GuardDestination[result].transform;
					}
					break;
				}
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000028AF File Offset: 0x00000AAF
		public ExtraStudentsNewSlotsScript()
		{
			UselessCall.Noop();
			FullRoutineFile = "/ExtraStudents/ExtraStudentsRoutine.txt";
			ResourceDirectory = "/ExtraStudents/";
			RoutineFile = "ExtraStudentsRoutine.txt";
		}

		// Token: 0x0400012E RID: 302
		private StudentManagerScript Hya8Krce8D;

		// Token: 0x0400012F RID: 303
		private ExtraStudentManagerScript ExtraStudentManager;

		// Token: 0x04000130 RID: 304
		public ExtraOpinionsLearnedScript OpinionsLearned;

		// Token: 0x04000131 RID: 305
		public GameObject[] LockerPosition;

		// Token: 0x04000132 RID: 306
		public GameObject[] SpawnPosition;

		// Token: 0x04000133 RID: 307
		public GameObject[] HangoutPosition;

		// Token: 0x04000134 RID: 308
		public GameObject[] Week1HangoutPosition;

		// Token: 0x04000135 RID: 309
		public GameObject[] Week2HangoutPosition;

		// Token: 0x04000136 RID: 310
		public GameObject[] StairwaysPosition;

		// Token: 0x04000137 RID: 311
		public GameObject[] LunchSpotPosition;

		// Token: 0x04000138 RID: 312
		public GameObject[] SocialSeatPosition;

		// Token: 0x04000139 RID: 313
		public GameObject[] MournPosition;

		// Token: 0x0400013A RID: 314
		public GameObject[] SulkPosition;

		// Token: 0x0400013B RID: 315
		public GameObject[] SunbathePosition;

		// Token: 0x0400013C RID: 316
		public GameObject[] MeetingDestination;

		// Token: 0x0400013D RID: 317
		public GameObject[] PaintDestination;

		// Token: 0x0400013E RID: 318
		public GameObject[] LunchtimeDestination;

		// Token: 0x0400013F RID: 319
		public GameObject[] WaitDestination;

		// Token: 0x04000140 RID: 320
		public GameObject[] EightiesDestination;

		// Token: 0x04000141 RID: 321
		public GameObject[] PerformDestination;

		// Token: 0x04000142 RID: 322
		public GameObject[] PhotoShootDestination;

		// Token: 0x04000143 RID: 323
		public GameObject[] GuardDestination;

		// Token: 0x04000144 RID: 324
		public GameObject[] RandomDestination;

		// Token: 0x04000145 RID: 325
		public GameObject NewSpots;

		// Token: 0x04000146 RID: 326
		private string FullRoutineFile;

		// Token: 0x04000147 RID: 327
		private string ResourceDirectory;

		// Token: 0x04000148 RID: 328
		private string RoutineFile;

		// Token: 0x04000149 RID: 329
		public string[] AllSpots;

		// Token: 0x0400014A RID: 330
		public string[] StudentsPositions;

		// Token: 0x0400014B RID: 331
		public int Students;

		// Token: 0x0400014C RID: 332
		public int ID;

		// Token: 0x0400014D RID: 333
		public bool Week2Update;

		// Token: 0x0400014E RID: 334
		private bool NPG88cbFRJ;

		// Token: 0x0400014F RID: 335
		public int[] Target;

		// Token: 0x04000150 RID: 336
		public int[] Follower;

		// Token: 0x04000151 RID: 337
		public int[] LovestruckID;
	}
}

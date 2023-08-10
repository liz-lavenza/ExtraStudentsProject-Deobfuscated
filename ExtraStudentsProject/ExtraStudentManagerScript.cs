using System;
using System.Collections;
using ExtraStudentsProject.ExtraStudentsMainModule;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExtraStudentsProject
{
	// Token: 0x02000018 RID: 24
	internal class ExtraStudentManagerScript : MonoBehaviour
	{
		// Token: 0x06000079 RID: 121 RVA: 0x0000FD0C File Offset: 0x0000DF0C
		private void Update()
		{
			if (!injected)
			{
				ASJvZ8DPwN = new bool[5];
				baseStudentManager = base.gameObject.GetComponent<StudentManagerScript>();
				ExtraStudentsSettingsManager = base.gameObject.GetComponent<ExtraStudentsSettingsManager>();
				ExtraJson = GameObject.Find("JSON").GetComponent<ExtraJsonScript>();
				LockerCreator = GameObject.Find("MainHandler").GetComponent<LockerCreatorScript>();
				zKdZFEmssX = baseStudentManager.MemorialScene.GetComponent<ExtraMemorialSceneScript>();
				ExtraOpinionsLearned = baseStudentManager.GetComponent<ExtraOpinionsLearnedScript>();
				ExtraStudentsNewSlots = GameObject.Find("MainHandler").GetComponent<ExtraStudentsNewSlotsScript>();
				ExtraStudentManager = GetComponent<ExtraStudentManagerScript>();
				StudentLimit = ExtraStudentsSettingsManager.ExtraStudentAmount;
				Array.Resize(ref baseStudentManager.SpawnPositions, baseStudentManager.Students.Length);
				if (!debug)
				{
					for (int i = 101; i < baseStudentManager.Students.Length; i++)
					{
						if (baseStudentManager.Students[i] != null)
						{
							baseStudentManager.TargetSize[i] = 2f + (float)i * 0.1f;
						}
					}
				}
				InitializeReputations();
				StartCoroutine(WtCZkerfot());
				OcTZ5IwlxY();
				injected = true;
			}
			if (SXovH1gxZM < 4)
			{
				SXovH1gxZM++;
				if (baseStudentManager.LoadedSave)
				{
					RagdollScript[] corpseList = baseStudentManager.Police.CorpseList;
					foreach (RagdollScript ragdollScript in corpseList)
					{
						if (ragdollScript != null && ragdollScript.gameObject != null)
						{
							GameObjectUtils.SetLayerRecursively(ragdollScript.gameObject, 11);
						}
					}
					TmGZhjWiID();
					Physics.SyncTransforms();
					baseStudentManager.Eighties = GameGlobals.Eighties;
					if (!baseStudentManager.Eighties && baseStudentManager.Students[baseStudentManager.RivalID] != null && baseStudentManager.Students[baseStudentManager.RivalID].Indoors)
					{
						baseStudentManager.UpdateExteriorStudents();
					}
					if (baseStudentManager.BookBag.Worn)
					{
						baseStudentManager.BookBag.Wear();
					}
					baseStudentManager.LoadedSave = false;
					baseStudentManager.Reputation.UpdatePendingRepLabel();
					if (!baseStudentManager.Eighties)
					{
						if (baseStudentManager.Students[10] != null)
						{
							baseStudentManager.Students[10].Cosmetic.SetFemaleUniform();
						}
						if (baseStudentManager.Students[86] != null)
						{
							baseStudentManager.Students[86].Cosmetic.SetFemaleUniform();
						}
						if (baseStudentManager.Students[87] != null)
						{
							baseStudentManager.Students[87].Cosmetic.SetFemaleUniform();
						}
						if (baseStudentManager.Students[88] != null)
						{
							baseStudentManager.Students[88].Cosmetic.SetFemaleUniform();
						}
						if (baseStudentManager.Students[89] != null)
						{
							baseStudentManager.Students[89].Cosmetic.SetFemaleUniform();
						}
					}
					else
					{
						if (baseStudentManager.Students[86] != null)
						{
							baseStudentManager.Students[86].Cosmetic.SetMaleUniform();
						}
						if (baseStudentManager.Students[87] != null)
						{
							baseStudentManager.Students[87].Cosmetic.SetMaleUniform();
						}
						if (baseStudentManager.Students[88] != null)
						{
							baseStudentManager.Students[88].Cosmetic.SetMaleUniform();
						}
						if (baseStudentManager.Students[89] != null)
						{
							baseStudentManager.Students[89].Cosmetic.SetMaleUniform();
						}
					}
					YBNZwIpjas();
				}
				if (SXovH1gxZM == 2 && GameGlobals.AlphabetMode)
				{
					for (int k = 1; k < baseStudentManager.Students.Length; k++)
					{
						StudentGlobals.SetStudentDead(k, value: false);
						StudentGlobals.SetStudentKidnapped(k, value: false);
						StudentGlobals.SetStudentArrested(k, value: false);
						StudentGlobals.SetStudentExpelled(k, value: false);
					}
				}
			}
			if (baseStudentManager.CanSelfReport)
			{
				mKRv8nGMF0 = true;
			}
			if (QgVvMatWBC)
			{
				return;
			}
			if (uSevQRYkLY != -1)
			{
				if (baseStudentManager.ErrorLabel != null)
				{
					baseStudentManager.ErrorLabel.text = string.Empty;
					baseStudentManager.ErrorLabel.enabled = false;
				}
				if (baseStudentManager.MissionMode)
				{
					StudentGlobals.FemaleUniform = 5;
					StudentGlobals.MaleUniform = 5;
					baseStudentManager.RedString.gameObject.SetActive(value: false);
				}
				baseStudentManager.SetAtmosphere();
				GameGlobals.Paranormal = false;
				if (StudentGlobals.StudentSlave > 100 && StudentGlobals.StudentSlave > 0 && !StudentGlobals.GetStudentDead(StudentGlobals.StudentSlave))
				{
					int studentSlave = StudentGlobals.StudentSlave;
					baseStudentManager.ForceSpawn = true;
					baseStudentManager.SpawnPositions[studentSlave] = baseStudentManager.SlaveSpot;
					baseStudentManager.SpawnID = studentSlave;
					StudentGlobals.SetStudentDead(studentSlave, value: false);
					SpawnStudent(baseStudentManager.SpawnID);
					baseStudentManager.Students[studentSlave].Slave = true;
					baseStudentManager.SpawnID = 0;
				}
				if (StudentGlobals.StudentSlave > 100 && StudentGlobals.FragileSlave > 0 && !StudentGlobals.GetStudentDead(StudentGlobals.FragileSlave))
				{
					int fragileSlave = StudentGlobals.FragileSlave;
					baseStudentManager.ForceSpawn = true;
					baseStudentManager.SpawnPositions[fragileSlave] = baseStudentManager.FragileSlaveSpot;
					baseStudentManager.SpawnID = fragileSlave;
					StudentGlobals.SetStudentDead(fragileSlave, value: false);
					SpawnStudent(baseStudentManager.SpawnID);
					baseStudentManager.Students[fragileSlave].FragileSlave = true;
					baseStudentManager.Students[fragileSlave].Slave = true;
					baseStudentManager.SpawnID = 0;
				}
				if (baseStudentManager.FragileWeapon != null)
				{
					baseStudentManager.FragileWeapon.gameObject.SetActive(value: false);
				}
				baseStudentManager.NPCsTotal = baseStudentManager.StudentsTotal + baseStudentManager.TeachersTotal;
				baseStudentManager.SpawnID = 1;
				if (StudentGlobals.MaleUniform == 0)
				{
					StudentGlobals.MaleUniform = 1;
				}
				baseStudentManager.ID = 1;
				while (baseStudentManager.ID < baseStudentManager.NPCsTotal + 1)
				{
					if (!StudentGlobals.GetStudentDead(baseStudentManager.ID))
					{
						StudentGlobals.SetStudentDying(baseStudentManager.ID, value: false);
					}
					baseStudentManager.ID++;
				}
				if (!baseStudentManager.TakingPortraits)
				{
					baseStudentManager.ID = 1;
					while (baseStudentManager.ID < 101)
					{
						baseStudentManager.TargetSize[baseStudentManager.ID] = 2f + (float)baseStudentManager.ID * 0.1f;
						baseStudentManager.ID++;
					}
					baseStudentManager.TargetSize[11] = 20f;
					baseStudentManager.ID = 1;
					while (baseStudentManager.ID < baseStudentManager.Lockers.List.Length)
					{
						baseStudentManager.LockerPositions[baseStudentManager.ID].transform.position = baseStudentManager.Lockers.List[baseStudentManager.ID].position + baseStudentManager.Lockers.List[baseStudentManager.ID].forward * 0.5f;
						baseStudentManager.LockerPositions[baseStudentManager.ID].LookAt(baseStudentManager.Lockers.List[baseStudentManager.ID].position);
						baseStudentManager.ID++;
					}
					baseStudentManager.ID = 1;
					while (baseStudentManager.ID < baseStudentManager.ShowerLockers.List.Length)
					{
						Transform transform = UnityEngine.Object.Instantiate(baseStudentManager.EmptyObject, baseStudentManager.ShowerLockers.List[baseStudentManager.ID].position + baseStudentManager.ShowerLockers.List[baseStudentManager.ID].forward * 0.5f, baseStudentManager.ShowerLockers.List[baseStudentManager.ID].rotation).transform;
						transform.parent = baseStudentManager.ShowerLockers.transform;
						transform.transform.eulerAngles = new Vector3(transform.transform.eulerAngles.x, transform.transform.eulerAngles.y + 180f, transform.transform.eulerAngles.z);
						baseStudentManager.StrippingPositions[baseStudentManager.ID] = transform;
						baseStudentManager.ID++;
					}
					baseStudentManager.ID = 1;
					while (baseStudentManager.ID < baseStudentManager.HidingSpots.List.Length)
					{
						if (baseStudentManager.HidingSpots.List[baseStudentManager.ID] == null)
						{
							GameObject gameObject = UnityEngine.Object.Instantiate(baseStudentManager.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
							while (!(gameObject.transform.position.x >= 2.5f) && gameObject.transform.position.x > -2.5f && gameObject.transform.position.z > -2.5f && !(gameObject.transform.position.z >= 2.5f))
							{
								gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
							}
							gameObject.transform.parent = baseStudentManager.HidingSpots.transform;
							baseStudentManager.HidingSpots.List[baseStudentManager.ID] = gameObject.transform;
						}
						baseStudentManager.ID++;
					}
				}
				if (GameGlobals.AlphabetMode)
				{
					Debug.Log("Entering Alphabet Killer Mode. Repositioning Yandere-chan and others.");
					baseStudentManager.Yandere.transform.position = baseStudentManager.Portal.transform.position + new Vector3(1f, 0f, 0f);
					baseStudentManager.Clock.StopTime = true;
					baseStudentManager.SkipTo730();
				}
				if (!baseStudentManager.TakingPortraits && !baseStudentManager.RecordingVideo && !baseStudentManager.SpawnNobody)
				{
					while (baseStudentManager.SpawnID < 98)
					{
						baseStudentManager.SpawnStudent(baseStudentManager.SpawnID);
						baseStudentManager.SpawnID++;
					}
					baseStudentManager.Graffiti[1].SetActive(value: false);
					baseStudentManager.Graffiti[2].SetActive(value: false);
					baseStudentManager.Graffiti[3].SetActive(value: false);
					baseStudentManager.Graffiti[4].SetActive(value: false);
					baseStudentManager.Graffiti[5].SetActive(value: false);
					baseStudentManager.RivalChan.SetActive(value: false);
				}
				baseStudentManager.Police.EndOfDay.VoidGoddess.UpdatePortraits();
				baseStudentManager.LoveManager.CoupleCheck();
				if (baseStudentManager.Eighties || baseStudentManager.Bullies > 0)
				{
					baseStudentManager.DetermineVictim();
				}
				baseStudentManager.UpdateStudents();
				baseStudentManager.QualityManager.UpdateOutlinesAndRimlight();
				if (baseStudentManager.QualityManager.DisableOutlinesLater)
				{
					OptionGlobals.DisableOutlines = true;
				}
				if (baseStudentManager.QualityManager.DisableRimLightLater)
				{
					OptionGlobals.RimLight = false;
				}
				baseStudentManager.QualityManager.UpdateOutlinesAndRimlight();
				for (int l = 26; l < 31; l++)
				{
					if (baseStudentManager.Students[l] != null)
					{
						baseStudentManager.OriginalClubPositions[l - 25] = baseStudentManager.Clubs.List[l].position;
						baseStudentManager.OriginalClubRotations[l - 25] = baseStudentManager.Clubs.List[l].rotation;
					}
				}
				if (!baseStudentManager.TakingPortraits)
				{
					baseStudentManager.TaskManager.UpdateTaskStatus();
				}
				baseStudentManager.Yandere.GloveAttacher.newRenderer.enabled = false;
				baseStudentManager.UpdateAprons();
				if (PlayerPrefs.GetInt("LoadingSave") == 1)
				{
					PlayerPrefs.SetInt("LoadingSave", 0);
					baseStudentManager.Load();
				}
				baseStudentManager.ClubManager.gameObject.SetActive(value: true);
				if (!baseStudentManager.YandereLate)
				{
					if (StudentGlobals.MemorialStudents > 0 && !baseStudentManager.ReturnedFromSave && DateGlobals.Week < 11)
					{
						baseStudentManager.Yandere.HUD.alpha = 0f;
						baseStudentManager.Yandere.RPGCamera.transform.position = new Vector3(38f, 4.125f, 68.825f);
						baseStudentManager.Yandere.RPGCamera.transform.eulerAngles = new Vector3(22.5f, 67.5f, 0f);
						baseStudentManager.Yandere.RPGCamera.transform.Translate(Vector3.forward, Space.Self);
						baseStudentManager.Yandere.RPGCamera.enabled = false;
						baseStudentManager.Yandere.HeartCamera.enabled = false;
						baseStudentManager.Yandere.CanMove = false;
						baseStudentManager.Clock.StopTime = true;
						baseStudentManager.StopMoving();
						baseStudentManager.MemorialScene.gameObject.SetActive(value: true);
						baseStudentManager.MemorialScene.enabled = true;
					}
				}
				else
				{
					Debug.Log("Because Yandere-chan is late for school, we're teleporting students where they would be at 8 AM.");
					baseStudentManager.Clock.PresentTime = 480f;
					baseStudentManager.Clock.HourTime = 8f;
					baseStudentManager.Clock.Hour = Mathf.Floor(baseStudentManager.Clock.PresentTime / 60f);
					baseStudentManager.Clock.Minute = Mathf.Floor((baseStudentManager.Clock.PresentTime / 60f - baseStudentManager.Clock.Hour) * 60f);
					baseStudentManager.Clock.UpdateClock();
					baseStudentManager.Clock.Update();
					baseStudentManager.SkipTo8();
				}
				for (int m = 1; m < 101; m++)
				{
					if (baseStudentManager.Students[m] != null)
					{
						if (!baseStudentManager.Students[m].Teacher)
						{
							baseStudentManager.Students[m].ShoeRemoval.Start();
						}
						baseStudentManager.Students[m].AddOutlineToHair();
					}
				}
				baseStudentManager.ClubManager.ActivateClubBenefit();
				if (GameGlobals.CensorPanties)
				{
					baseStudentManager.CensorStudents();
					baseStudentManager.Yandere.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().Censor();
				}
				if (!baseStudentManager.Eighties)
				{
					if (!baseStudentManager.MissionMode && !GameGlobals.AlphabetMode)
					{
						if (baseStudentManager.Week == 1)
						{
							baseStudentManager.Week1RoutineAdjustments();
						}
						if (baseStudentManager.Week == 2)
						{
							baseStudentManager.Week2RoutineAdjustments();
							baseStudentManager.BakeSale.SetActive(value: true);
						}
					}
				}
				else
				{
					baseStudentManager.IdolStage.SetActive(value: false);
					if (baseStudentManager.Students[baseStudentManager.RivalID] != null)
					{
						if (baseStudentManager.Week == 3)
						{
							baseStudentManager.EightiesWeek3RoutineAdjustments();
						}
						else if (baseStudentManager.Week == 4)
						{
							baseStudentManager.EightiesWeek4RoutineAdjustments();
						}
						else if (baseStudentManager.Week == 5)
						{
							baseStudentManager.EightiesWeek5RoutineAdjustments();
						}
						else if (baseStudentManager.Week == 6)
						{
							baseStudentManager.EightiesWeek6RoutineAdjustments();
							baseStudentManager.IdolStage.SetActive(value: true);
						}
						else if (baseStudentManager.Week == 7)
						{
							baseStudentManager.EightiesWeek3RoutineAdjustments();
						}
						else if (baseStudentManager.Week == 8)
						{
							baseStudentManager.EightiesWeek8RoutineAdjustments();
						}
						else if (baseStudentManager.Week == 9)
						{
							Debug.Log("Adjusting everyone's routine because of the gravure rival.");
							baseStudentManager.EightiesWeek9RoutineAdjustments();
							int num = 0;
							for (int n = 57; n < 61; n++)
							{
								if (baseStudentManager.Students[n] != null)
								{
									num++;
								}
							}
							if (SchoolGlobals.SchoolAtmosphere > 0.8f && num > 0)
							{
								baseStudentManager.PoolPhotoShootCameras.SetActive(value: true);
							}
							else if (baseStudentManager.Students[19] != null)
							{
								Debug.Log("Changing Gravure Idol's routine.");
								zvDvh3VgtC = baseStudentManager.Students[19].ScheduleBlocks[2];
								zvDvh3VgtC.destination = "Patrol";
								zvDvh3VgtC.action = "Patrol";
								zvDvh3VgtC = baseStudentManager.Students[19].ScheduleBlocks[7];
								zvDvh3VgtC.destination = "Patrol";
								zvDvh3VgtC.action = "Patrol";
								baseStudentManager.Students[19].GetDestinations();
							}
						}
						else if (baseStudentManager.Week == 10)
						{
							baseStudentManager.EightiesWeek10RoutineAdjustments();
						}
					}
					if (baseStudentManager.Students[baseStudentManager.RivalID] != null && baseStudentManager.Students[baseStudentManager.SuitorID] != null)
					{
						baseStudentManager.ChangeSuitorRoutine(baseStudentManager.SuitorID);
					}
					if (baseStudentManager.Week > 1)
					{
						RNjZ0dyqg5();
					}
				}
				if (baseStudentManager.SpawnNobody)
				{
					if (baseStudentManager.Week < 11)
					{
						baseStudentManager.TutorialActive = true;
						baseStudentManager.Tutorial.gameObject.SetActive(value: true);
						baseStudentManager.Tutorial.InstructionLabel.transform.parent.gameObject.SetActive(value: true);
					}
					if (SchoolGlobals.SchoolAtmosphere < 0.5f)
					{
						baseStudentManager.Clock.CameraEffects.UpdateBloom(1f);
						baseStudentManager.Clock.CameraEffects.UpdateBloomKnee(0.5f);
						baseStudentManager.Clock.CameraEffects.UpdateBloomRadius(4f);
					}
					else
					{
						baseStudentManager.Clock.CameraEffects.UpdateBloom(11f);
						baseStudentManager.Clock.CameraEffects.UpdateBloomKnee(1f);
						baseStudentManager.Clock.CameraEffects.UpdateBloomRadius(7f);
					}
					baseStudentManager.FPSDisplay.SetActive(value: false);
					baseStudentManager.FPSDisplayBG.SetActive(value: false);
				}
				if (!baseStudentManager.TutorialActive)
				{
					baseStudentManager.Tutorial.InstructionLabel.transform.parent.gameObject.SetActive(value: false);
				}
				baseStudentManager.UpdateAllBentos();
				if (!baseStudentManager.Eighties)
				{
					baseStudentManager.FanCover.enabled = true;
				}
				if (!baseStudentManager.MissionMode && !GameGlobals.AlphabetMode)
				{
					for (int num2 = 76; num2 < 90; num2++)
					{
						if (baseStudentManager.Students[num2] != null)
						{
							baseStudentManager.Students[num2].transform.position = baseStudentManager.SpawnPositions[num2].position;
						}
					}
				}
				Physics.SyncTransforms();
				if (baseStudentManager.MissionMode)
				{
					baseStudentManager.Yandere.ChangeSchoolwear();
				}
				baseStudentManager.UpdateAllSleuthClothing();
				if (baseStudentManager.LoadedSave)
				{
					RagdollScript[] corpseList = baseStudentManager.Police.CorpseList;
					foreach (RagdollScript ragdollScript2 in corpseList)
					{
						if (ragdollScript2 != null && ragdollScript2.gameObject != null)
						{
							GameObjectUtils.SetLayerRecursively(ragdollScript2.gameObject, 11);
						}
					}
					baseStudentManager.LoadAllStudentPositions();
					Physics.SyncTransforms();
					baseStudentManager.Eighties = GameGlobals.Eighties;
					if (!baseStudentManager.Eighties && baseStudentManager.Students[baseStudentManager.RivalID] != null && baseStudentManager.Students[baseStudentManager.RivalID].Indoors)
					{
						baseStudentManager.UpdateExteriorStudents();
					}
					if (baseStudentManager.BookBag.Worn)
					{
						baseStudentManager.BookBag.Wear();
					}
					baseStudentManager.LoadedSave = false;
					baseStudentManager.Reputation.UpdatePendingRepLabel();
					if (!baseStudentManager.Eighties)
					{
						if (baseStudentManager.Students[10] != null)
						{
							baseStudentManager.Students[10].Cosmetic.SetFemaleUniform();
						}
						if (baseStudentManager.Students[86] != null)
						{
							baseStudentManager.Students[86].Cosmetic.SetFemaleUniform();
						}
						if (baseStudentManager.Students[87] != null)
						{
							baseStudentManager.Students[87].Cosmetic.SetFemaleUniform();
						}
						if (baseStudentManager.Students[88] != null)
						{
							baseStudentManager.Students[88].Cosmetic.SetFemaleUniform();
						}
						if (baseStudentManager.Students[89] != null)
						{
							baseStudentManager.Students[89].Cosmetic.SetFemaleUniform();
						}
					}
					else
					{
						if (baseStudentManager.Students[86] != null)
						{
							baseStudentManager.Students[86].Cosmetic.SetMaleUniform();
						}
						if (baseStudentManager.Students[87] != null)
						{
							baseStudentManager.Students[87].Cosmetic.SetMaleUniform();
						}
						if (baseStudentManager.Students[88] != null)
						{
							baseStudentManager.Students[88].Cosmetic.SetMaleUniform();
						}
						if (baseStudentManager.Students[89] != null)
						{
							baseStudentManager.Students[89].Cosmetic.SetMaleUniform();
						}
					}
					StudentScript[] students = baseStudentManager.Students;
					foreach (StudentScript studentScript in students)
					{
						if (studentScript != null && studentScript.Meeting)
						{
							Debug.Log("A student was in the middle of meeting someone when this save file was made. Attempting to update their schedule accordingly.");
							baseStudentManager.NoteWindow.NoteLocker.StudentID = baseStudentManager.MeetStudentID;
							baseStudentManager.NoteWindow.NoteLocker.MeetTime = baseStudentManager.MeetTime;
							baseStudentManager.NoteWindow.NoteLocker.MeetID = baseStudentManager.MeetID;
							baseStudentManager.NoteWindow.NoteLocker.DetermineSchedule();
							studentScript.MeetTimer = 0f;
						}
					}
				}
				if (Screen.width < 1280 || Screen.height < 720)
				{
					Screen.SetResolution(1280, 720, fullscreen: false);
				}
			}
			else
			{
				string text = string.Empty;
				if (uSevQRYkLY > 1)
				{
					text = "The problem may be caused by Student " + uSevQRYkLY + ".";
				}
				if (baseStudentManager.ErrorLabel != null)
				{
					baseStudentManager.ErrorLabel.text = "The game cannot compile Students.JSON! There is a typo somewhere in the JSON file. The problem might be a missing quotation mark, a missing colon, a missing comma, or something else like that. Please find your typo and fix it, or revert to a backup of the JSON file. " + text;
					baseStudentManager.ErrorLabel.enabled = true;
				}
			}
			if (!baseStudentManager.TakingPortraits)
			{
				baseStudentManager.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
				baseStudentManager.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
				baseStudentManager.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
				baseStudentManager.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
				if (!baseStudentManager.ReturnedFromSave)
				{
					baseStudentManager.Yandere.Class.GetStats();
				}
				baseStudentManager.Yandere.CameraEffects.UpdateDOF(2f);
			}
			if (PlayerGlobals.PersonaID > 0)
			{
				baseStudentManager.Yandere.PersonaID = PlayerGlobals.PersonaID;
				baseStudentManager.Mirror.UpdatePersona();
			}
			baseStudentManager.LoadPantyshots();
			baseStudentManager.LoadPhotographs();
			if (baseStudentManager.RecordingVideo)
			{
				base.gameObject.SetActive(value: false);
				baseStudentManager.FPSDisplay.SetActive(value: false);
				baseStudentManager.FPSDisplayBG.SetActive(value: false);
				baseStudentManager.Clock.CameraEffects.UpdateBloom(1f);
				baseStudentManager.Clock.CameraEffects.UpdateBloomRadius(4f);
				baseStudentManager.Clock.CameraEffects.UpdateBloomKnee(0.75f);
				baseStudentManager.Yandere.enabled = false;
				baseStudentManager.Yandere.UICamera.gameObject.SetActive(value: false);
				baseStudentManager.Yandere.MainCamera.gameObject.SetActive(value: false);
			}
			if (StudentGlobals.UpdateRivalReputation)
			{
				baseStudentManager.StudentReps[baseStudentManager.RivalID] = baseStudentManager.StudentReps[baseStudentManager.RivalID] - 50f;
			}
			baseStudentManager.LoadTopicsLearned();
			if (baseStudentManager.Police != null)
			{
				baseStudentManager.Police.EndOfDay.VoidGoddess.Window.parent.gameObject.SetActive(value: false);
			}
			QgVvMatWBC = true;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000119E8 File Offset: 0x0000FBE8
		public void TmGZhjWiID()
		{
			Debug.Log("Now loading extra save data method.");
			Physics.SyncTransforms();
			for (int i = 101; i < baseStudentManager.Students.Length; i++)
			{
				if (!(baseStudentManager.Students[i] != null))
				{
					continue;
				}
				if (!baseStudentManager.Students[i].Alive)
				{
					Debug.Log(baseStudentManager.Students[i].Name + " is confirmed to be dead. Transforming them into a ragdoll now.");
					if (baseStudentManager.Students[i].Rival)
					{
						baseStudentManager.Students[i].MapMarker.gameObject.SetActive(value: false);
					}
					Vector3 localPosition = baseStudentManager.Students[i].Hips.localPosition;
					Quaternion localRotation = baseStudentManager.Students[i].Hips.localRotation;
					baseStudentManager.Students[i].Ragdoll.Yandere = baseStudentManager.Yandere;
					baseStudentManager.Students[i].BecomeRagdoll();
					GameObjectUtils.SetLayerRecursively(baseStudentManager.Students[i].gameObject, 0);
					baseStudentManager.Students[i].Ragdoll.UpdateNextFrame = true;
					baseStudentManager.Students[i].Ragdoll.NextPosition = localPosition;
					baseStudentManager.Students[i].Ragdoll.NextRotation = localRotation;
					baseStudentManager.Students[i].Ragdoll.CharacterAnimation = baseStudentManager.Students[i].CharacterAnimation;
					baseStudentManager.Students[i].MyRenderer.updateWhenOffscreen = true;
					baseStudentManager.Students[i].CharacterAnimation.enabled = false;
					baseStudentManager.Students[i].MyController.enabled = false;
					baseStudentManager.Students[i].Pathfinding.enabled = false;
					baseStudentManager.Students[i].HipCollider.enabled = true;
					if (!StudentGlobals.GetStudentDying(i))
					{
						Debug.Log("For some reason, " + baseStudentManager.Students[i].Name + " may not have been added to the Police CorpseList, so we're doing it manually.");
						baseStudentManager.Police.CorpseList[baseStudentManager.Police.Corpses] = baseStudentManager.Students[i].Ragdoll;
						baseStudentManager.Police.Corpses++;
						baseStudentManager.Police.Deaths++;
						if (baseStudentManager.Students[i].Removed)
						{
							baseStudentManager.Students[i].Ragdoll.Remove();
							baseStudentManager.Police.Corpses--;
						}
					}
					else
					{
						Debug.Log("It looks like " + baseStudentManager.Students[i].Name + " has already added themself to the Police CorpseList, so we won't be doing that manually.");
						if (baseStudentManager.Students[i].Removed)
						{
							Debug.Log(baseStudentManager.Students[i].Name + "'s ''Removed'' boolean was true, so we're removing them from the Police CorpseList.");
							baseStudentManager.Students[i].Ragdoll.Remove();
							baseStudentManager.Police.Corpses--;
						}
					}
					continue;
				}
				baseStudentManager.Students[i].ReturningFromSave = true;
				baseStudentManager.Students[i].PhaseFromSave = baseStudentManager.Students[i].Phase;
				if (baseStudentManager.Students[i].ChangingShoes)
				{
					baseStudentManager.Students[i].ShoeRemoval.enabled = true;
				}
				if (baseStudentManager.Students[i].ClubAttire)
				{
					int clubActivityPhase = baseStudentManager.Students[i].ClubActivityPhase;
					baseStudentManager.Students[i].ClubAttire = false;
					if (baseStudentManager.Students[i].ClubActivityPhase > 14)
					{
						if (baseStudentManager.Students[i].ClubActivityPhase == 18 || baseStudentManager.Students[i].ClubActivityPhase == 19)
						{
							baseStudentManager.Students[i].Destinations[baseStudentManager.Students[i].Phase] = baseStudentManager.Clubs.List[i].GetChild(baseStudentManager.Students[i].ClubActivityPhase - 2);
							baseStudentManager.Students[i].Destinations[baseStudentManager.Students[i].Phase + 1] = baseStudentManager.Clubs.List[i].GetChild(baseStudentManager.Students[i].ClubActivityPhase - 2);
							baseStudentManager.Students[i].CurrentDestination = baseStudentManager.Clubs.List[i].GetChild(baseStudentManager.Students[i].ClubActivityPhase - 2);
							baseStudentManager.Students[i].Pathfinding.target = baseStudentManager.Clubs.List[i].GetChild(baseStudentManager.Students[i].ClubActivityPhase - 2);
							baseStudentManager.Students[i].Character.transform.localPosition = new Vector3(0f, -0.25f, 0f);
							baseStudentManager.Students[i].CurrentAction = StudentActionType.ClubAction;
							baseStudentManager.Students[i].WalkAnim = "poolSwim_00";
							baseStudentManager.Students[i].ClubAnim = "poolSwim_00";
							baseStudentManager.Students[i].SetSplashes(Bool: true);
							baseStudentManager.Students[i].Phase++;
						}
						baseStudentManager.Clock.Period = 3;
					}
					baseStudentManager.Students[i].ChangeClubwear();
					if (baseStudentManager.Students[i].ClubActivityPhase > 14)
					{
						baseStudentManager.Students[i].ClubActivityPhase = clubActivityPhase;
					}
				}
				if (baseStudentManager.Students[i].Defeats > 0)
				{
					baseStudentManager.Students[i].IdleAnim = "idleInjured_00";
					baseStudentManager.Students[i].WalkAnim = "walkInjured_00";
					baseStudentManager.Students[i].OriginalIdleAnim = baseStudentManager.Students[i].IdleAnim;
					baseStudentManager.Students[i].OriginalWalkAnim = baseStudentManager.Students[i].WalkAnim;
					baseStudentManager.Students[i].LeanAnim = baseStudentManager.Students[i].IdleAnim;
					baseStudentManager.Students[i].CharacterAnimation.CrossFade(baseStudentManager.Students[i].IdleAnim);
					baseStudentManager.Students[i].Injured = true;
					baseStudentManager.Students[i].Strength = 0;
					ScheduleBlock obj = baseStudentManager.Students[i].ScheduleBlocks[2];
					obj.destination = "Sulk";
					obj.action = "Sulk";
					ScheduleBlock obj2 = baseStudentManager.Students[i].ScheduleBlocks[4];
					obj2.destination = "Sulk";
					obj2.action = "Sulk";
					ScheduleBlock obj3 = baseStudentManager.Students[i].ScheduleBlocks[6];
					obj3.destination = "Sulk";
					obj3.action = "Sulk";
					ScheduleBlock obj4 = baseStudentManager.Students[i].ScheduleBlocks[7];
					obj4.destination = "Sulk";
					obj4.action = "Sulk";
					baseStudentManager.Students[i].GetDestinations();
				}
				if (baseStudentManager.Students[i].Actions[baseStudentManager.Students[i].Phase] == StudentActionType.ClubAction && baseStudentManager.Students[i].Club == ClubType.Cooking && baseStudentManager.Students[i].ClubActivityPhase > 0)
				{
					baseStudentManager.Students[i].MyPlate.parent = baseStudentManager.Students[i].RightHand;
					baseStudentManager.Students[i].MyPlate.localPosition = new Vector3(0.02f, -0.02f, -0.15f);
					baseStudentManager.Students[i].MyPlate.localEulerAngles = new Vector3(-5f, -90f, 172.5f);
					baseStudentManager.Students[i].IdleAnim = baseStudentManager.Students[i].PlateIdleAnim;
					baseStudentManager.Students[i].WalkAnim = baseStudentManager.Students[i].PlateWalkAnim;
					baseStudentManager.Students[i].LeanAnim = baseStudentManager.Students[i].PlateIdleAnim;
					baseStudentManager.Students[i].GetFoodTarget();
					baseStudentManager.Students[i].ClubTimer = 0f;
				}
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00012394 File Offset: 0x00010594
		public void SpawnStudent(int int_0)
		{
			baseStudentManager.LockerPositions[int_0].transform.position = baseStudentManager.Lockers.List[int_0].position + baseStudentManager.Lockers.List[int_0].forward * 0.5f;
			baseStudentManager.LockerPositions[int_0].LookAt(baseStudentManager.Lockers.List[int_0].position);
			bool flag = false;
			if (baseStudentManager.Eighties)
			{
				if (int_0 > baseStudentManager.Week + baseStudentManager.WeekLimit && int_0 < 21)
				{
					flag = true;
				}
			}
			else
			{
				if (int_0 > 11 && int_0 < 21)
				{
					flag = true;
				}
				if (baseStudentManager.Week == 2 && int_0 == 12)
				{
					flag = false;
				}
			}
			if (ExtraJson.Students[int_0].Club != ClubType.Delinquent && StudentGlobals.GetStudentReputation(int_0) < -100)
			{
				flag = true;
			}
			if (!flag && baseStudentManager.Students[int_0] == null && !StudentGlobals.GetStudentDead(int_0) && !StudentGlobals.GetStudentKidnapped(int_0) && !StudentGlobals.GetStudentArrested(int_0) && !StudentGlobals.GetStudentExpelled(int_0))
			{
				int num;
				if (ExtraJson.Students[int_0].Name == "Random")
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(baseStudentManager.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
					while (!(gameObject.transform.position.x >= 2.5f) && gameObject.transform.position.x > -2.5f && gameObject.transform.position.z > -2.5f && !(gameObject.transform.position.z >= 2.5f))
					{
						gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
					}
					gameObject.transform.parent = baseStudentManager.HidingSpots.transform;
					baseStudentManager.HidingSpots.List[int_0] = gameObject.transform;
					GameObject gameObject2 = UnityEngine.Object.Instantiate(baseStudentManager.RandomPatrol, Vector3.zero, Quaternion.identity);
					gameObject2.transform.parent = baseStudentManager.Patrols.transform;
					baseStudentManager.Patrols.List[int_0] = gameObject2.transform;
					GameObject gameObject3 = UnityEngine.Object.Instantiate(baseStudentManager.RandomPatrol, Vector3.zero, Quaternion.identity);
					gameObject3.transform.parent = baseStudentManager.CleaningSpots.transform;
					baseStudentManager.CleaningSpots.List[int_0] = gameObject3.transform;
					num = ((!baseStudentManager.MissionMode || MissionModeGlobals.MissionTarget != int_0) ? UnityEngine.Random.Range(0, 2) : 0);
					FindUnoccupiedSeat();
				}
				else
				{
					num = ExtraJson.Students[int_0].Gender;
				}
				StudentModel = UnityEngine.Object.Instantiate((num == 0) ? baseStudentManager.StudentChan : baseStudentManager.StudentKun, baseStudentManager.SpawnPositions[int_0].position, Quaternion.identity);
				CosmeticScript component = StudentModel.GetComponent<CosmeticScript>();
				component.LoveManager = baseStudentManager.LoveManager;
				component.StudentManager = baseStudentManager;
				component.Randomize = baseStudentManager.Randomize;
				component.StudentID = int_0;
				component.JSON = baseStudentManager.JSON;
				if (ExtraJson.Students[int_0].Name == "Random")
				{
					StudentModel.GetComponent<StudentScript>().CleaningSpot = baseStudentManager.CleaningSpots.List[int_0];
					StudentModel.GetComponent<StudentScript>().CleaningRole = 3;
				}
				if (ExtraJson.Students[int_0].Club == ClubType.Bully)
				{
					baseStudentManager.Bullies++;
				}
				baseStudentManager.Students[int_0] = StudentModel.GetComponent<StudentScript>();
				StudentScript studentScript = baseStudentManager.Students[int_0];
				studentScript.ChaseSelectiveGrayscale.desaturation = 1f - SchoolGlobals.SchoolAtmosphere;
				studentScript.Cosmetic.TextureManager = baseStudentManager.TextureManager;
				studentScript.WitnessCamera = baseStudentManager.WitnessCamera;
				studentScript.StudentManager = baseStudentManager;
				studentScript.StudentID = int_0;
				studentScript.JSON = baseStudentManager.JSON;
				studentScript.BloodSpawnerIdentifier.ObjectID = "Student_" + int_0 + "_BloodSpawner";
				studentScript.HipsIdentifier.ObjectID = "Student_" + int_0 + "_Hips";
				studentScript.YanSave.ObjectID = "Student_" + int_0;
				studentScript.Yandere = baseStudentManager.Yandere;
				studentScript.MyTeacher = baseStudentManager.Teachers[ExtraJson.Students[studentScript.StudentID].Class];
				if (StudentGlobals.StudentSlave > 100)
				{
					studentScript.Seat = baseStudentManager.SlaveSpot;
				}
				D1CZm00jNl(int_0);
				CosmeticStartOverride(int_0);
				studentScript.ShoeRemoval.Start();
				if (studentScript.Miyuki != null)
				{
					studentScript.Miyuki.Enemy = baseStudentManager.MiyukiCat;
				}
				if (baseStudentManager.AoT)
				{
					studentScript.AoT = true;
				}
				if (baseStudentManager.DK)
				{
					studentScript.DK = true;
				}
				if (baseStudentManager.Spooky)
				{
					studentScript.Spooky = true;
				}
				if (baseStudentManager.Sans)
				{
					studentScript.BadTime = true;
				}
				if (!baseStudentManager.MissionMode)
				{
					if (int_0 == baseStudentManager.RivalID)
					{
						studentScript.Rival = true;
						baseStudentManager.RedString.transform.parent = studentScript.LeftPinky;
						baseStudentManager.RedString.transform.localPosition = new Vector3(0f, 0f, 0f);
					}
					if (int_0 == 1)
					{
						baseStudentManager.RedString.Target = studentScript.LeftPinky;
					}
				}
				else if (int_0 == MissionModeGlobals.MissionTarget)
				{
					studentScript.Rival = true;
				}
				if (num == 0)
				{
					baseStudentManager.GirlsSpawned++;
					studentScript.GirlID = baseStudentManager.GirlsSpawned;
				}
				IDwZfOOGui();
			}
			baseStudentManager.NPCsSpawned++;
			baseStudentManager.ForceSpawn = false;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00012A8C File Offset: 0x00010C8C
		private void IDwZfOOGui()
		{
			Array.Resize(ref baseStudentManager.SeatsTaken11, 30);
			Array.Resize(ref baseStudentManager.SeatsTaken12, 30);
			Array.Resize(ref baseStudentManager.SeatsTaken21, 30);
			Array.Resize(ref baseStudentManager.SeatsTaken22, 30);
			Array.Resize(ref baseStudentManager.SeatsTaken31, 30);
			Array.Resize(ref baseStudentManager.SeatsTaken32, 30);
			int @class = ExtraJson.Students[baseStudentManager.SpawnID].Class;
			int seat = ExtraJson.Students[baseStudentManager.SpawnID].Seat;
			switch (@class)
			{
			case 11:
				baseStudentManager.SeatsTaken11[seat] = true;
				break;
			case 12:
				baseStudentManager.SeatsTaken12[seat] = true;
				break;
			case 21:
				baseStudentManager.SeatsTaken21[seat] = true;
				break;
			case 22:
				baseStudentManager.SeatsTaken22[seat] = true;
				break;
			case 31:
				baseStudentManager.SeatsTaken31[seat] = true;
				break;
			case 32:
				baseStudentManager.SeatsTaken32[seat] = true;
				break;
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00012BB8 File Offset: 0x00010DB8
		private void FindUnoccupiedSeat()
		{
			baseStudentManager.SeatOccupied = false;
			if (baseStudentManager.Class == 1)
			{
				baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Class = 11;
				baseStudentManager.ID = 1;
				while (baseStudentManager.ID < baseStudentManager.SeatsTaken11.Length && !baseStudentManager.SeatOccupied)
				{
					if (!baseStudentManager.SeatsTaken11[baseStudentManager.ID])
					{
						baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Seat = baseStudentManager.ID;
						baseStudentManager.SeatsTaken11[baseStudentManager.ID] = true;
						baseStudentManager.SeatOccupied = true;
					}
					baseStudentManager.ID++;
					if (baseStudentManager.ID > 15)
					{
						baseStudentManager.Class++;
					}
				}
			}
			else if (baseStudentManager.Class == 2)
			{
				baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Class = 12;
				baseStudentManager.ID = 1;
				while (baseStudentManager.ID < baseStudentManager.SeatsTaken12.Length && !baseStudentManager.SeatOccupied)
				{
					if (!baseStudentManager.SeatsTaken12[baseStudentManager.ID])
					{
						baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Seat = baseStudentManager.ID;
						baseStudentManager.SeatsTaken12[baseStudentManager.ID] = true;
						baseStudentManager.SeatOccupied = true;
					}
					baseStudentManager.ID++;
					if (baseStudentManager.ID > 15)
					{
						baseStudentManager.Class++;
					}
				}
			}
			else if (baseStudentManager.Class == 3)
			{
				baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Class = 21;
				baseStudentManager.ID = 1;
				while (baseStudentManager.ID < baseStudentManager.SeatsTaken21.Length && !baseStudentManager.SeatOccupied)
				{
					if (!baseStudentManager.SeatsTaken21[baseStudentManager.ID])
					{
						baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Seat = baseStudentManager.ID;
						baseStudentManager.SeatsTaken21[baseStudentManager.ID] = true;
						baseStudentManager.SeatOccupied = true;
					}
					baseStudentManager.ID++;
					if (baseStudentManager.ID > 15)
					{
						baseStudentManager.Class++;
					}
				}
			}
			else if (baseStudentManager.Class == 4)
			{
				baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Class = 22;
				baseStudentManager.ID = 1;
				while (baseStudentManager.ID < baseStudentManager.SeatsTaken22.Length && !baseStudentManager.SeatOccupied)
				{
					if (!baseStudentManager.SeatsTaken22[baseStudentManager.ID])
					{
						baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Seat = baseStudentManager.ID;
						baseStudentManager.SeatsTaken22[baseStudentManager.ID] = true;
						baseStudentManager.SeatOccupied = true;
					}
					baseStudentManager.ID++;
					if (baseStudentManager.ID > 15)
					{
						baseStudentManager.Class++;
					}
				}
			}
			else if (baseStudentManager.Class == 5)
			{
				baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Class = 31;
				baseStudentManager.ID = 1;
				while (baseStudentManager.ID < baseStudentManager.SeatsTaken31.Length && !baseStudentManager.SeatOccupied)
				{
					if (!baseStudentManager.SeatsTaken31[baseStudentManager.ID])
					{
						baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Seat = baseStudentManager.ID;
						baseStudentManager.SeatsTaken31[baseStudentManager.ID] = true;
						baseStudentManager.SeatOccupied = true;
					}
					baseStudentManager.ID++;
					if (baseStudentManager.ID > 15)
					{
						baseStudentManager.Class++;
					}
				}
			}
			else if (baseStudentManager.Class == 6)
			{
				baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Class = 32;
				baseStudentManager.ID = 1;
				while (baseStudentManager.ID < baseStudentManager.SeatsTaken32.Length && !baseStudentManager.SeatOccupied)
				{
					if (!baseStudentManager.SeatsTaken32[baseStudentManager.ID])
					{
						baseStudentManager.JSON.Students[baseStudentManager.SpawnID].Seat = baseStudentManager.ID;
						baseStudentManager.SeatsTaken32[baseStudentManager.ID] = true;
						baseStudentManager.SeatOccupied = true;
					}
					baseStudentManager.ID++;
					if (baseStudentManager.ID > 15)
					{
						baseStudentManager.Class++;
					}
				}
			}
			if (!baseStudentManager.SeatOccupied)
			{
				FindUnoccupiedSeat();
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00013260 File Offset: 0x00011460
		public void D1CZm00jNl(int int_0)
		{
			StudentScript studentScript = baseStudentManager.Students[int_0];
			studentScript.CounterAnim = "f02_teacherCounterB_00";
			if (!studentScript.Started)
			{
				studentScript.CharacterAnimation = studentScript.Character.GetComponent<Animation>();
				studentScript.MyBento = studentScript.Bento.GetComponent<GenericBentoScript>();
				studentScript.Pathfinding.repathRate += (float)studentScript.StudentID * 0.01f;
				studentScript.OriginalIdleAnim = studentScript.IdleAnim;
				studentScript.OriginalLeanAnim = studentScript.LeanAnim;
				studentScript.Friend = PlayerGlobals.GetStudentFriend(studentScript.StudentID);
				if (!studentScript.StudentManager.LoveSick && SchoolAtmosphere.Type == SchoolAtmosphereType.Low && (studentScript.Club <= ClubType.Gaming || studentScript.Club == ClubType.Newspaper))
				{
					studentScript.IdleAnim = studentScript.ParanoidAnim;
				}
				if (ClubGlobals.Club == ClubType.Occult)
				{
					studentScript.Perception = 0.5f;
				}
				ParticleSystem.EmissionModule emission = studentScript.Hearts.emission;
				emission.enabled = false;
				studentScript.Prompt.OwnerType = PromptOwnerType.Person;
				studentScript.Paranoia = 2f - SchoolGlobals.SchoolAtmosphere;
				studentScript.VisionDistance = ((PlayerGlobals.PantiesEquipped == 4) ? 5f : 10f) * studentScript.Paranoia;
				if (studentScript.Yandere != null && studentScript.Yandere.DetectionPanel != null)
				{
					RjZZqkCA3s(int_0);
				}
				ExtraStudentJson extraStudentJson = ExtraJson.Students[studentScript.StudentID];
				studentScript.ScheduleBlocks = extraStudentJson.ScheduleBlocks;
				studentScript.Persona = extraStudentJson.Persona;
				studentScript.Class = extraStudentJson.Class;
				studentScript.Crush = extraStudentJson.Crush;
				studentScript.Club = extraStudentJson.Club;
				studentScript.BreastSize = extraStudentJson.BreastSize;
				studentScript.Strength = extraStudentJson.Strength;
				studentScript.Hairstyle = extraStudentJson.Hairstyle;
				studentScript.Accessory = extraStudentJson.Accessory;
				studentScript.Name = extraStudentJson.Name;
				studentScript.OriginalClub = studentScript.Club;
				if (StudentGlobals.GetStudentBroken(studentScript.StudentID))
				{
					studentScript.Cosmetic.RightEyeRenderer.gameObject.SetActive(value: false);
					studentScript.Cosmetic.LeftEyeRenderer.gameObject.SetActive(value: false);
					studentScript.Cosmetic.RightIrisLight.SetActive(value: false);
					studentScript.Cosmetic.LeftIrisLight.SetActive(value: false);
					studentScript.RightEmptyEye.SetActive(value: true);
					studentScript.LeftEmptyEye.SetActive(value: true);
					studentScript.Traumatized = true;
					studentScript.Shy = true;
					studentScript.Persona = PersonaType.Coward;
				}
				if (studentScript.Name == "Random")
				{
					studentScript.Persona = (PersonaType)UnityEngine.Random.Range(1, 8);
					if (studentScript.Persona == PersonaType.Lovestruck)
					{
						studentScript.Persona = PersonaType.PhoneAddict;
					}
					extraStudentJson.Persona = studentScript.Persona;
					if (studentScript.Persona == PersonaType.Heroic)
					{
						studentScript.Strength = UnityEngine.Random.Range(1, 5);
						extraStudentJson.Strength = studentScript.Strength;
					}
				}
				studentScript.Seat = studentScript.StudentManager.Seats[studentScript.Class].List[extraStudentJson.Seat];
				studentScript.gameObject.name = "Student_" + studentScript.StudentID + " (" + studentScript.Name + ")";
				studentScript.OriginalPersona = studentScript.Persona;
				if (studentScript.StudentID == 81 && StudentGlobals.GetStudentBroken(81))
				{
					studentScript.Persona = PersonaType.Coward;
				}
				if (studentScript.Persona != PersonaType.Loner && studentScript.Persona != PersonaType.Coward && studentScript.Persona != PersonaType.Fragile)
				{
					if (studentScript.Persona != PersonaType.TeachersPet && studentScript.Persona != PersonaType.Heroic && studentScript.Persona != PersonaType.Strict)
					{
						if (studentScript.Persona != PersonaType.Evil && studentScript.Persona != PersonaType.Spiteful && studentScript.Persona != PersonaType.Violent)
						{
							if (studentScript.Persona == PersonaType.SocialButterfly || studentScript.Persona == PersonaType.Lovestruck || studentScript.Persona == PersonaType.PhoneAddict || studentScript.Persona == PersonaType.Sleuth)
							{
								studentScript.CameraAnims = studentScript.SocialAnims;
							}
						}
						else
						{
							studentScript.CameraAnims = studentScript.EvilAnims;
						}
					}
					else
					{
						studentScript.CameraAnims = studentScript.HeroAnims;
					}
				}
				else
				{
					studentScript.CameraAnims = studentScript.CowardAnims;
				}
				if (ClubGlobals.GetClubClosed(studentScript.Club))
				{
					studentScript.Club = ClubType.None;
				}
				studentScript.Yandere = studentScript.StudentManager.Yandere;
				studentScript.DialogueWheel = studentScript.StudentManager.DialogueWheel;
				studentScript.ClubManager = studentScript.StudentManager.ClubManager;
				studentScript.Reputation = studentScript.StudentManager.Reputation;
				studentScript.Subtitle = studentScript.Yandere.Subtitle;
				studentScript.Police = studentScript.StudentManager.Police;
				studentScript.Clock = studentScript.StudentManager.Clock;
				studentScript.CameraEffects = studentScript.Yandere.MainCamera.GetComponent<CameraEffectsScript>();
				studentScript.RightEyeOrigin = studentScript.RightEye.localPosition;
				studentScript.LeftEyeOrigin = studentScript.LeftEye.localPosition;
				studentScript.Bento.GetComponent<GenericBentoScript>().StudentID = studentScript.StudentID;
				studentScript.DisableProps();
				studentScript.OriginalOriginalSprintAnim = studentScript.SprintAnim;
				studentScript.OriginalOriginalWalkAnim = studentScript.WalkAnim;
				studentScript.OriginalSprintAnim = studentScript.SprintAnim;
				studentScript.OriginalWalkAnim = studentScript.WalkAnim;
				if (studentScript.Persona == PersonaType.Evil)
				{
					studentScript.ScaredAnim = studentScript.EvilWitnessAnim;
				}
				if (studentScript.Persona == PersonaType.PhoneAddict)
				{
					studentScript.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
					studentScript.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
					studentScript.Countdown.Speed = 0.1f;
					studentScript.SprintAnim = studentScript.PhoneAnims[2];
					studentScript.PatrolAnim = studentScript.PhoneAnims[3];
				}
				if (studentScript.Club == ClubType.Bully)
				{
					studentScript.SkirtCollider.transform.localPosition = new Vector3(0f, 0.055f, 0f);
					if (!StudentGlobals.GetStudentBroken(studentScript.StudentID))
					{
						studentScript.IdleAnim = studentScript.PhoneAnims[0];
						studentScript.BullyID = studentScript.StudentID - 80;
					}
				}
				studentScript.SetSplashes(Bool: false);
				if (!studentScript.Male)
				{
					studentScript.DisableFemaleProps();
				}
				else
				{
					studentScript.DisableMaleProps();
				}
				if (studentScript.Rival)
				{
					studentScript.MapMarker.gameObject.SetActive(value: true);
				}
				B8SZ7hSEiv(studentScript.StudentID);
				BqBZcL1o7s(studentScript.StudentID);
				if (!studentScript.StudentManager.Eighties)
				{
					if (studentScript.StudentID == 1)
					{
						studentScript.MapMarker.gameObject.SetActive(value: true);
						if (DateGlobals.Week == 2)
						{
							ScheduleBlock obj = studentScript.ScheduleBlocks[2];
							obj.destination = "Patrol";
							obj.action = "Patrol";
							ScheduleBlock obj2 = studentScript.ScheduleBlocks[7];
							obj2.destination = "Patrol";
							obj2.action = "Patrol";
						}
					}
					else if (studentScript.StudentID == 2)
					{
						if (StudentGlobals.GetStudentDead(3) || StudentGlobals.GetStudentKidnapped(3) || studentScript.StudentManager.Students[3] == null || (studentScript.StudentManager.Students[3] != null && studentScript.StudentManager.Students[3].Slave))
						{
							ScheduleBlock obj3 = studentScript.ScheduleBlocks[2];
							obj3.destination = "Mourn";
							obj3.action = "Mourn";
							ScheduleBlock obj4 = studentScript.ScheduleBlocks[7];
							obj4.destination = "Mourn";
							obj4.action = "Mourn";
							studentScript.IdleAnim = studentScript.BulliedIdleAnim;
							studentScript.WalkAnim = studentScript.BulliedWalkAnim;
						}
						studentScript.PatrolAnim = studentScript.SearchPatrolAnim;
					}
					else if (studentScript.StudentID == 3)
					{
						if (StudentGlobals.GetStudentDead(2) || StudentGlobals.GetStudentKidnapped(2) || studentScript.StudentManager.Students[2] == null || (studentScript.StudentManager.Students[2] != null && studentScript.StudentManager.Students[2].Slave))
						{
							ScheduleBlock obj5 = studentScript.ScheduleBlocks[2];
							obj5.destination = "Mourn";
							obj5.action = "Mourn";
							ScheduleBlock obj6 = studentScript.ScheduleBlocks[7];
							obj6.destination = "Mourn";
							obj6.action = "Mourn";
							studentScript.IdleAnim = studentScript.BulliedIdleAnim;
							studentScript.WalkAnim = studentScript.BulliedWalkAnim;
						}
						studentScript.PatrolAnim = studentScript.SearchPatrolAnim;
					}
					else if (studentScript.StudentID == 4)
					{
						studentScript.IdleAnim = "f02_idleShort_00";
						studentScript.WalkAnim = "f02_newWalk_00";
					}
					else if (studentScript.StudentID == 5)
					{
						studentScript.LongSkirt = true;
						if (!studentScript.StudentManager.TakingPortraits)
						{
							studentScript.Shy = true;
						}
					}
					else if (studentScript.StudentID == 6)
					{
						studentScript.RelaxAnim = "crossarms_00";
						studentScript.CameraAnims = studentScript.HeroAnims;
						studentScript.Curious = true;
						studentScript.Crush = 11;
						if (studentScript.StudentManager.Students[11] == null)
						{
							studentScript.Curious = false;
						}
					}
					else if (studentScript.StudentID == 7)
					{
						studentScript.RunAnim = "runFeminine_00";
						studentScript.SprintAnim = "runFeminine_00";
						studentScript.RelaxAnim = "infirmaryRest_00";
						studentScript.OriginalSprintAnim = studentScript.SprintAnim;
						studentScript.Cosmetic.Start();
						if (!GameGlobals.AlphabetMode && !studentScript.StudentManager.MissionMode)
						{
							studentScript.gameObject.SetActive(value: false);
						}
					}
					else if (studentScript.StudentID == 8)
					{
						studentScript.IdleAnim = studentScript.BulliedIdleAnim;
						studentScript.WalkAnim = studentScript.BulliedWalkAnim;
					}
					else if (studentScript.StudentID == 9)
					{
						studentScript.IdleAnim = "idleScholarly_00";
						studentScript.WalkAnim = "walkScholarly_00";
						studentScript.CameraAnims = studentScript.HeroAnims;
					}
					else if (studentScript.StudentID == 10)
					{
						if (!GameGlobals.AlphabetMode && !studentScript.StudentManager.MissionMode)
						{
							studentScript.LovestruckTarget = 11;
						}
						else
						{
							studentScript.OriginalPersona = PersonaType.Heroic;
							studentScript.Persona = PersonaType.Heroic;
							studentScript.Strength = 5;
						}
						if (studentScript.StudentManager.Students[11] != null && DatingGlobals.SuitorProgress < 2 && (float)StudentGlobals.GetStudentReputation(10) > -33.33333f && StudentGlobals.StudentSlave != 11 && !GameGlobals.AlphabetMode && !studentScript.StudentManager.MissionMode)
						{
							studentScript.StudentManager.Patrols.List[studentScript.StudentID].parent = studentScript.StudentManager.Students[11].transform;
							studentScript.StudentManager.Patrols.List[studentScript.StudentID].localEulerAngles = new Vector3(0f, 0f, 0f);
							studentScript.StudentManager.Patrols.List[studentScript.StudentID].localPosition = new Vector3(0f, 0f, 0f);
							studentScript.VomitPhase = -1;
							studentScript.Indoors = true;
							studentScript.Spawned = true;
							studentScript.Calm = true;
							if (studentScript.ShoeRemoval.Locker == null)
							{
								studentScript.ShoeRemoval.Start();
							}
							studentScript.ShoeRemoval.PutOnShoes();
							studentScript.FollowTarget = studentScript.StudentManager.Students[11];
							studentScript.FollowTarget.Follower = studentScript;
							studentScript.IdleAnim = "f02_idleGirly_00";
							studentScript.WalkAnim = "f02_walkGirly_00";
							studentScript.PatrolAnim = "f02_stretch_00";
							studentScript.OriginalIdleAnim = studentScript.IdleAnim;
						}
						else
						{
							Debug.Log("Due to the circumstances, we're changing Raibaru's destinations.");
							if (!(studentScript.StudentManager.Students[11] == null) && StudentGlobals.StudentSlave != 11 && !GameGlobals.AlphabetMode && !studentScript.StudentManager.MissionMode)
							{
								if ((float)StudentGlobals.GetStudentReputation(10) <= -33.33333f)
								{
									ScheduleBlock obj7 = studentScript.ScheduleBlocks[2];
									obj7.destination = "Seat";
									obj7.action = "Sit";
									obj7.time = 8f;
									ScheduleBlock obj8 = studentScript.ScheduleBlocks[4];
									obj8.destination = "Seat";
									obj8.action = "Sit";
									studentScript.IdleAnim = studentScript.BulliedIdleAnim;
									studentScript.WalkAnim = studentScript.BulliedWalkAnim;
									studentScript.OriginalIdleAnim = studentScript.IdleAnim;
								}
								else if (DatingGlobals.SuitorProgress == 2)
								{
									ScheduleBlock obj9 = studentScript.ScheduleBlocks[2];
									obj9.destination = "Peek";
									obj9.action = "Peek";
									obj9.time = 8f;
									ScheduleBlock obj10 = studentScript.ScheduleBlocks[4];
									obj10.destination = "LunchSpot";
									obj10.action = "Eat";
								}
							}
							else
							{
								ejjZLYl0li(int_0);
							}
							IrUZGKRSBu(int_0);
							studentScript.TargetDistance = 0.5f;
						}
						studentScript.PhotoPatience = 0f;
						studentScript.OriginalWalkAnim = studentScript.WalkAnim;
						studentScript.CharacterAnimation["f02_nervousLeftRight_00"].speed = 0.5f;
					}
					else if (studentScript.StudentID == 11)
					{
						studentScript.SmartPhone.transform.localPosition = new Vector3(-0.0075f, -0.0025f, -0.0075f);
						studentScript.SmartPhone.transform.localEulerAngles = new Vector3(5f, -150f, 170f);
						studentScript.SmartPhone.GetComponent<Renderer>().material.mainTexture = studentScript.OsanaPhoneTexture;
						studentScript.IdleAnim = "f02_tsunIdle_00";
						studentScript.WalkAnim = "f02_tsunWalk_00";
						studentScript.TaskAnims[0] = "f02_Task33_Line0";
						studentScript.TaskAnims[1] = "f02_Task33_Line1";
						studentScript.TaskAnims[2] = "f02_Task33_Line2";
						studentScript.TaskAnims[3] = "f02_Task33_Line3";
						studentScript.TaskAnims[4] = "f02_Task33_Line4";
						studentScript.TaskAnims[5] = "f02_Task33_Line5";
						studentScript.LovestruckTarget = 1;
						studentScript.PhotoPatience = 0f;
						if (studentScript.StudentManager.Students[10] == null)
						{
							Debug.Log("Raibaru has been killed/arrested/vanished, so Osana's schedule has changed.");
							ScheduleBlock obj11 = studentScript.ScheduleBlocks[2];
							obj11.destination = "Mourn";
							obj11.action = "Mourn";
							ScheduleBlock obj12 = studentScript.ScheduleBlocks[7];
							obj12.destination = "Mourn";
							obj12.action = "Mourn";
							studentScript.IdleAnim = studentScript.BulliedIdleAnim;
							studentScript.WalkAnim = studentScript.BulliedWalkAnim;
						}
						else if (PlayerGlobals.RaibaruLoner || GameGlobals.AlphabetMode || studentScript.StudentManager.MissionMode)
						{
							Debug.Log("Raibaru has become a loner, so Osana's schedule has changed.");
							ScheduleBlock obj13 = studentScript.ScheduleBlocks[2];
							obj13.destination = "Patrol";
							obj13.action = "Patrol";
							ScheduleBlock obj14 = studentScript.ScheduleBlocks[7];
							obj14.destination = "Patrol";
							obj14.action = "Patrol";
							studentScript.PatrolAnim = "f02_pondering_00";
						}
						studentScript.OriginalWalkAnim = studentScript.WalkAnim;
					}
					else if (studentScript.StudentID == 12)
					{
						studentScript.IdleAnim = "f02_idleGirly_00";
						studentScript.WalkAnim = "f02_walkGirly_00";
						studentScript.Distracted = true;
						studentScript.CanTalk = false;
					}
					else if (studentScript.StudentID == 24 && studentScript.StudentID == 25)
					{
						studentScript.IdleAnim = "f02_idleGirly_00";
						studentScript.WalkAnim = "f02_walkGirly_00";
					}
					else if (studentScript.StudentID == 26)
					{
						studentScript.IdleAnim = "idleHaughty_00";
						studentScript.WalkAnim = "walkHaughty_00";
					}
					else if (studentScript.StudentID != 28 && studentScript.StudentID != 30)
					{
						if (studentScript.StudentID == 31)
						{
							studentScript.IdleAnim = studentScript.BulliedIdleAnim;
							studentScript.WalkAnim = studentScript.BulliedWalkAnim;
						}
						else if (studentScript.StudentID != 34 && studentScript.StudentID != 35)
						{
							if (studentScript.StudentID == 36)
							{
								if (TaskGlobals.GetTaskStatus(36) < 3)
								{
									studentScript.IdleAnim = "slouchIdle_00";
									studentScript.WalkAnim = "slouchWalk_00";
									studentScript.ClubAnim = "slouchGaming_00";
								}
								else
								{
									studentScript.IdleAnim = "properIdle_00";
									studentScript.WalkAnim = "properWalk_00";
									studentScript.ClubAnim = "properGaming_00";
								}
								if (studentScript.Paranoia > 1.66666f)
								{
									studentScript.IdleAnim = studentScript.ParanoidAnim;
									studentScript.WalkAnim = studentScript.ParanoidWalkAnim;
								}
								if (studentScript.StudentManager.MissionMode)
								{
									Debug.Log("Changing Gema's routine for Mission Mode.");
									ScheduleBlock obj15 = studentScript.ScheduleBlocks[4];
									obj15.destination = "LunchSpot";
									obj15.action = "Eat";
								}
							}
							else if (studentScript.StudentID == 39)
							{
								studentScript.SmartPhone.GetComponent<Renderer>().material.mainTexture = studentScript.MidoriPhoneTexture;
								studentScript.PatrolAnim = "f02_midoriTexting_00";
							}
							else if (studentScript.StudentID == 51)
							{
								studentScript.IdleAnim = "f02_idleConfident_01";
								studentScript.WalkAnim = "f02_walkConfident_01";
								if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
								{
									studentScript.IdleAnim = studentScript.BulliedIdleAnim;
									studentScript.WalkAnim = studentScript.BulliedWalkAnim;
									studentScript.CameraAnims = studentScript.CowardAnims;
									studentScript.Persona = PersonaType.Loner;
									if (!SchoolGlobals.RoofFence)
									{
										ScheduleBlock obj16 = studentScript.ScheduleBlocks[2];
										obj16.destination = "Sulk";
										obj16.action = "Sulk";
										ScheduleBlock obj17 = studentScript.ScheduleBlocks[4];
										obj17.destination = "Sulk";
										obj17.action = "Sulk";
										ScheduleBlock obj18 = studentScript.ScheduleBlocks[7];
										obj18.destination = "Sulk";
										obj18.action = "Sulk";
										ScheduleBlock obj19 = studentScript.ScheduleBlocks[8];
										obj19.destination = "Sulk";
										obj19.action = "Sulk";
									}
									else
									{
										ScheduleBlock obj20 = studentScript.ScheduleBlocks[2];
										obj20.destination = "Seat";
										obj20.action = "Sit";
										ScheduleBlock obj21 = studentScript.ScheduleBlocks[4];
										obj21.destination = "Seat";
										obj21.action = "Sit";
										ScheduleBlock obj22 = studentScript.ScheduleBlocks[7];
										obj22.destination = "Seat";
										obj22.action = "Sit";
										ScheduleBlock obj23 = studentScript.ScheduleBlocks[8];
										obj23.destination = "Seat";
										obj23.action = "Sit";
									}
								}
								if (studentScript.StudentManager.MissionMode)
								{
									Debug.Log("Changing Miyuji's routine for Mission Mode.");
									ScheduleBlock obj24 = studentScript.ScheduleBlocks[4];
									obj24.destination = "LunchSpot";
									obj24.action = "Eat";
								}
							}
							else if (studentScript.StudentID == 56)
							{
								studentScript.IdleAnim = "idleConfident_00";
								studentScript.WalkAnim = "walkConfident_00";
								studentScript.SleuthID = 1;
							}
							else if (studentScript.StudentID == 57)
							{
								studentScript.IdleAnim = "idleChill_01";
								studentScript.WalkAnim = "walkChill_01";
								studentScript.SleuthID = 20;
							}
							else if (studentScript.StudentID == 58)
							{
								studentScript.IdleAnim = "idleChill_00";
								studentScript.WalkAnim = "walkChill_00";
								studentScript.SleuthID = 40;
							}
							else if (studentScript.StudentID == 59)
							{
								studentScript.IdleAnim = "f02_idleGraceful_00";
								studentScript.WalkAnim = "f02_walkGraceful_00";
								studentScript.SleuthID = 60;
							}
							else if (studentScript.StudentID == 60)
							{
								studentScript.IdleAnim = "f02_idleScholarly_00";
								studentScript.WalkAnim = "f02_walkScholarly_00";
								studentScript.CameraAnims = studentScript.HeroAnims;
								studentScript.SleuthID = 80;
							}
							else if (studentScript.StudentID == 61)
							{
								studentScript.IdleAnim = "scienceIdle_00";
								studentScript.WalkAnim = "scienceWalk_00";
								studentScript.OriginalWalkAnim = "scienceWalk_00";
							}
							else if (studentScript.StudentID == 62)
							{
								studentScript.IdleAnim = "idleFrown_00";
								studentScript.WalkAnim = "walkFrown_00";
								if (studentScript.Paranoia > 1.66666f)
								{
									studentScript.IdleAnim = studentScript.ParanoidAnim;
									studentScript.WalkAnim = studentScript.ParanoidWalkAnim;
								}
							}
							else if (studentScript.StudentID != 64 && studentScript.StudentID != 65)
							{
								if (studentScript.StudentID == 66)
								{
									studentScript.IdleAnim = "pose_03";
									studentScript.OriginalWalkAnim = "walkConfident_00";
									studentScript.WalkAnim = "walkConfident_00";
									studentScript.ClubThreshold = 100f;
								}
								else if (studentScript.StudentID == 69)
								{
									studentScript.IdleAnim = "idleFrown_00";
									studentScript.WalkAnim = "walkFrown_00";
									if (studentScript.Paranoia > 1.66666f)
									{
										studentScript.IdleAnim = studentScript.ParanoidAnim;
										studentScript.WalkAnim = studentScript.ParanoidWalkAnim;
									}
								}
								else if (studentScript.StudentID == 71)
								{
									studentScript.IdleAnim = "f02_idleGirly_00";
									studentScript.WalkAnim = "f02_walkGirly_00";
								}
							}
							else
							{
								studentScript.IdleAnim = "f02_idleShort_00";
								studentScript.WalkAnim = "f02_newWalk_00";
								if (studentScript.Paranoia > 1.66666f)
								{
									studentScript.IdleAnim = studentScript.ParanoidAnim;
									studentScript.WalkAnim = studentScript.ParanoidWalkAnim;
								}
							}
						}
						else
						{
							studentScript.IdleAnim = "f02_idleShort_00";
							studentScript.WalkAnim = "f02_newWalk_00";
							if (studentScript.Paranoia > 1.66666f)
							{
								studentScript.IdleAnim = studentScript.ParanoidAnim;
								studentScript.WalkAnim = studentScript.ParanoidWalkAnim;
							}
						}
					}
					else if (studentScript.StudentID == 30)
					{
						studentScript.SmartPhone.GetComponent<Renderer>().material.mainTexture = studentScript.KokonaPhoneTexture;
					}
					if ((studentScript.StudentID == 6 || studentScript.StudentID == 11) && DatingGlobals.SuitorProgress == 2)
					{
						studentScript.Partner = ((studentScript.StudentID == 11) ? studentScript.StudentManager.Students[6] : studentScript.StudentManager.Students[11]);
						ScheduleBlock obj25 = studentScript.ScheduleBlocks[2];
						obj25.destination = "Cuddle";
						obj25.action = "Cuddle";
						ScheduleBlock obj26 = studentScript.ScheduleBlocks[4];
						obj26.destination = "Cuddle";
						obj26.action = "Cuddle";
						ScheduleBlock obj27 = studentScript.ScheduleBlocks[6];
						obj27.destination = "Locker";
						obj27.action = "Shoes";
						ScheduleBlock obj28 = studentScript.ScheduleBlocks[7];
						obj28.destination = "Exit";
						obj28.action = "Exit";
					}
					if (studentScript.StudentID > 100)
					{
						studentScript.StalkTarget = baseStudentManager.Yandere.transform;
						studentScript.SleuthTarget = baseStudentManager.Yandere.transform;
						studentScript.StalkerFleeing = true;
					}
				}
				else
				{
					studentScript.BookRenderer.material.mainTexture = studentScript.RedBookTexture;
					studentScript.Phoneless = true;
					if (!studentScript.Male)
					{
						studentScript.PatrolAnim = "f02_thinking_00";
					}
					if (studentScript.Rival)
					{
						if (studentScript.StudentID > 10 && studentScript.StudentID < 21)
						{
							ScheduleBlock obj29 = studentScript.ScheduleBlocks[2];
							obj29.destination = "Seat";
							obj29.action = "PlaceBag";
						}
						studentScript.BookBag.SetActive(value: true);
						studentScript.LovestruckTarget = 1;
					}
					if (studentScript.StudentID == 11)
					{
						studentScript.IdleAnim = "f02_idleGirly_00";
						studentScript.WalkAnim = "f02_walkGirly_00";
						if (!studentScript.Rival)
						{
							studentScript.Persona = PersonaType.LandlineUser;
						}
					}
					else if (studentScript.StudentID == 12)
					{
						studentScript.IdleAnim = "f02_idleConfident_01";
						studentScript.WalkAnim = "f02_walkConfident_01";
						studentScript.PyroUrge = true;
						if (!studentScript.Rival)
						{
							studentScript.Persona = PersonaType.LandlineUser;
						}
					}
					else if (studentScript.StudentID == 13)
					{
						studentScript.IdleAnim = "f02_idleShy_00";
						studentScript.WalkAnim = "f02_walkShy_00";
						if (!studentScript.Rival)
						{
							studentScript.Persona = PersonaType.Coward;
						}
					}
					else if (studentScript.StudentID == 14)
					{
						studentScript.IdleAnim = "f02_idleLively_00";
						studentScript.WalkAnim = "f02_walkLively_00";
						studentScript.ClubAnim = "f02_stretch_00";
						if (!studentScript.Rival)
						{
							studentScript.Persona = PersonaType.Heroic;
						}
					}
					else if (studentScript.StudentID == 15)
					{
						studentScript.IdleAnim = "f02_idleHaughty_00";
						studentScript.WalkAnim = "f02_walkHaughty_00";
						if (!studentScript.Rival)
						{
							studentScript.Persona = PersonaType.Loner;
						}
					}
					else if (studentScript.StudentID == 16)
					{
						studentScript.IdleAnim = "f02_idleGirly_00";
						studentScript.WalkAnim = "f02_walkGirly_00";
						studentScript.ClubAnim = "f02_vocalSingA_00";
						if (DateGlobals.Week != 6)
						{
							ScheduleBlock obj30 = studentScript.ScheduleBlocks[2];
							obj30.destination = "Lyrics";
							obj30.action = "Lyrics";
							ScheduleBlock obj31 = studentScript.ScheduleBlocks[7];
							obj31.destination = "Lyrics";
							obj31.action = "Lyrics";
						}
						if (!studentScript.Rival)
						{
							studentScript.Persona = PersonaType.LandlineUser;
						}
					}
					else if (studentScript.StudentID != 17 && studentScript.StudentID != 18)
					{
						if (studentScript.StudentID == 19)
						{
							studentScript.IdleAnim = "f02_idleElegant_00";
							studentScript.WalkAnim = "f02_walkElegant_00";
							studentScript.OriginalWalkAnim = "f02_walkElegant_00";
							studentScript.OriginalOriginalWalkAnim = "f02_walkElegant_00";
							studentScript.ClubAnim = studentScript.GravureAnims[0];
							if (!studentScript.Rival)
							{
								studentScript.Persona = PersonaType.LandlineUser;
							}
						}
						else if (studentScript.StudentID == 20)
						{
							studentScript.IdleAnim = "f02_idleConfident_00";
							studentScript.WalkAnim = "f02_walkConfident_00";
							if (!studentScript.Rival)
							{
								studentScript.Persona = PersonaType.Heroic;
							}
						}
						else if (studentScript.StudentID == 66)
						{
							studentScript.ClubThreshold = 100f;
						}
					}
					else
					{
						studentScript.IdleAnim = "f02_idleCouncilGrace_00";
						studentScript.WalkAnim = "f02_walkCouncilGrace_00";
						studentScript.CharacterAnimation["f02_smile_00"].layer = 1;
						studentScript.CharacterAnimation.Play("f02_smile_00");
						studentScript.CharacterAnimation["f02_smile_00"].weight = 1f;
						if (!studentScript.Rival)
						{
							studentScript.Persona = PersonaType.TeachersPet;
						}
					}
					if (studentScript.Male && studentScript.Club == ClubType.Delinquent)
					{
						studentScript.CharacterAnimation[studentScript.WalkAnim].speed += 0.01f * (float)(studentScript.StudentID - 76);
					}
					if (studentScript.StudentID == 20)
					{
						studentScript.GuardID = 1;
					}
					else
					{
						studentScript.GuardID = 20;
					}
				}
				studentScript.OriginalWalkAnim = studentScript.WalkAnim;
				if (StudentGlobals.GetStudentGrudge(studentScript.StudentID))
				{
					if (studentScript.Persona != PersonaType.Coward && studentScript.Persona != PersonaType.Evil && studentScript.Club != ClubType.Delinquent)
					{
						studentScript.CameraAnims = studentScript.EvilAnims;
						studentScript.Reputation.PendingRep -= 10f;
						studentScript.PendingRep -= 10f;
						studentScript.ID = 0;
						while (studentScript.ID < studentScript.Outlines.Length)
						{
							if (studentScript.Outlines[studentScript.ID] != null)
							{
								studentScript.Outlines[studentScript.ID].color = new Color(1f, 1f, 0f, 1f);
							}
							studentScript.ID++;
						}
					}
					studentScript.Grudge = true;
					studentScript.CameraAnims = studentScript.EvilAnims;
				}
				if (studentScript.Rival)
				{
					studentScript.ID = 0;
					while (studentScript.ID < studentScript.Outlines.Length)
					{
						if (studentScript.Outlines[studentScript.ID] != null)
						{
							studentScript.Outlines[studentScript.ID].color = new Color(10f, 0f, 0f, 1f);
						}
						studentScript.ID++;
					}
				}
				if (studentScript.Persona == PersonaType.Sleuth)
				{
					if (!(SchoolGlobals.SchoolAtmosphere <= 0.8f) && !studentScript.Grudge)
					{
						if (SchoolGlobals.SchoolAtmosphere <= 0.9f)
						{
							studentScript.WalkAnim = studentScript.ParanoidWalkAnim;
							studentScript.CameraAnims = studentScript.HeroAnims;
						}
					}
					else
					{
						studentScript.BecomeSleuth();
					}
				}
				if (!studentScript.Slave)
				{
					if (studentScript.StudentManager.Bullies > 1)
					{
						if (studentScript.StudentID != 81 && studentScript.StudentID != 83 && studentScript.StudentID != 85)
						{
							if (studentScript.StudentID == 82 || studentScript.StudentID == 84)
							{
								studentScript.Pathfinding.canSearch = false;
								studentScript.Pathfinding.canMove = false;
								studentScript.Paired = true;
								studentScript.CharacterAnimation["f02_walkTalk_01"].time += studentScript.StudentID - 81;
								studentScript.WalkAnim = "f02_walkTalk_01";
								studentScript.SpeechLines.Play();
							}
						}
						else if (studentScript.Persona != PersonaType.Coward)
						{
							studentScript.Pathfinding.canSearch = false;
							studentScript.Pathfinding.canMove = false;
							studentScript.Paired = true;
							studentScript.CharacterAnimation["f02_walkTalk_00"].time += studentScript.StudentID - 81;
							studentScript.WalkAnim = "f02_walkTalk_00";
							studentScript.SpeechLines.Play();
						}
					}
					if (studentScript.Club == ClubType.Delinquent)
					{
						if (studentScript.Friend)
						{
							studentScript.RespectEarned = true;
						}
						if (CounselorGlobals.WeaponsBanned == 0)
						{
							studentScript.MyWeapon = studentScript.Yandere.WeaponManager.DelinquentWeapons[studentScript.StudentID - 75];
							studentScript.MyWeapon.transform.parent = studentScript.WeaponBagParent;
							studentScript.MyWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							studentScript.MyWeapon.transform.localPosition = new Vector3(0f, 0f, 0f);
							studentScript.MyWeapon.FingerprintID = studentScript.StudentID;
							studentScript.MyWeapon.MyCollider.enabled = false;
							studentScript.WeaponBag.SetActive(value: true);
						}
						else
						{
							studentScript.OriginalPersona = PersonaType.Heroic;
							studentScript.Persona = PersonaType.Heroic;
						}
						string text = "";
						if (!studentScript.Male)
						{
							text = "f02_";
						}
						studentScript.ScaredAnim = "delinquentCombatIdle_00";
						studentScript.LeanAnim = "delinquentConcern_00";
						studentScript.ShoveAnim = text + "pushTough_00";
						studentScript.WalkAnim = text + "walkTough_00";
						studentScript.IdleAnim = text + "idleTough_00";
						studentScript.SpeechLines = studentScript.DelinquentSpeechLines;
						studentScript.Pathfinding.canSearch = false;
						studentScript.Pathfinding.canMove = false;
						studentScript.Paired = true;
						if (studentScript.Male)
						{
							studentScript.TaskAnims[0] = text + "delinquentTalk_04";
							studentScript.TaskAnims[1] = text + "delinquentTalk_01";
							studentScript.TaskAnims[2] = text + "delinquentTalk_02";
							studentScript.TaskAnims[3] = text + "delinquentTalk_03";
							studentScript.TaskAnims[4] = text + "delinquentTalk_00";
							studentScript.TaskAnims[5] = text + "delinquentTalk_03";
						}
					}
				}
				if (studentScript.Rival)
				{
					studentScript.RivalPrefix = "Rival ";
					if (DateGlobals.Weekday == DayOfWeek.Friday)
					{
						studentScript.ScheduleBlocks[7].time = 17f;
					}
				}
				if (!studentScript.Teacher && studentScript.Name != "Random")
				{
					studentScript.StudentManager.CleaningManager.GetRole(studentScript.StudentID);
					studentScript.CleaningSpot = studentScript.StudentManager.CleaningManager.Spot;
					studentScript.CleaningRole = studentScript.StudentManager.CleaningManager.Role;
				}
				if (studentScript.Club == ClubType.Cooking)
				{
					studentScript.SleuthID = (studentScript.StudentID - 21) * 20;
					studentScript.ClubAnim = studentScript.PrepareFoodAnim;
					if (studentScript.StudentID > 12)
					{
						studentScript.ClubMemberID = studentScript.StudentID - 20;
						studentScript.MyPlate = studentScript.StudentManager.Plates[studentScript.ClubMemberID];
						studentScript.OriginalPlatePosition = studentScript.MyPlate.position;
						studentScript.OriginalPlateRotation = studentScript.MyPlate.rotation;
					}
					if (!studentScript.StudentManager.EmptyDemon && !studentScript.StudentManager.TutorialActive)
					{
						studentScript.ApronAttacher.enabled = true;
					}
				}
				else if (studentScript.Club == ClubType.Drama)
				{
					if (studentScript.StudentID == 26)
					{
						studentScript.ClubAnim = "teaching_00";
					}
					else if (studentScript.StudentID != 27 && studentScript.StudentID != 28)
					{
						if (studentScript.StudentID == 29 || studentScript.StudentID == 30)
						{
							studentScript.ClubAnim = "f02_sit_00";
						}
					}
					else
					{
						studentScript.ClubAnim = "sit_00";
					}
					studentScript.OriginalClubAnim = studentScript.ClubAnim;
				}
				else if (studentScript.Club == ClubType.Occult)
				{
					studentScript.PatrolAnim = studentScript.ThinkAnim;
					studentScript.CharacterAnimation[studentScript.PatrolAnim].speed = 0.2f;
				}
				else if (studentScript.Club == ClubType.Gaming)
				{
					studentScript.MiyukiGameScreen.SetActive(value: true);
					studentScript.ClubMemberID = studentScript.StudentID - 35;
					if (studentScript.StudentID > 36)
					{
						studentScript.ClubAnim = studentScript.GameAnim;
					}
					studentScript.ActivityAnim = studentScript.GameAnim;
				}
				else if (studentScript.Club == ClubType.Art)
				{
					studentScript.ChangingBooth = studentScript.StudentManager.ChangingBooths[4];
					studentScript.ActivityAnim = studentScript.PaintAnim;
					studentScript.Attacher.ArtClub = true;
					studentScript.ClubAnim = studentScript.PaintAnim;
					studentScript.DressCode = true;
					if (DateGlobals.Weekday == DayOfWeek.Friday)
					{
						ScheduleBlock obj32 = studentScript.ScheduleBlocks[7];
						obj32.destination = "Paint";
						obj32.action = "Paint";
					}
					studentScript.ClubMemberID = studentScript.StudentID - 40;
					studentScript.Painting = studentScript.StudentManager.FridayPaintings[studentScript.ClubMemberID];
					yU9Z1mIPi0(int_0);
				}
				else if (studentScript.Club == ClubType.LightMusic)
				{
					studentScript.ClubMemberID = studentScript.StudentID - 50;
					studentScript.InstrumentBag[studentScript.ClubMemberID].SetActive(value: true);
					if (studentScript.StudentID == 51)
					{
						studentScript.ClubAnim = "f02_practiceGuitar_01";
					}
					else if (studentScript.StudentID != 52 && studentScript.StudentID != 53)
					{
						if (studentScript.StudentID == 54)
						{
							studentScript.ClubAnim = "f02_practiceDrums_00";
							studentScript.Instruments[4] = studentScript.StudentManager.DrumSet;
							if (studentScript.StudentManager.Eighties)
							{
								studentScript.InstrumentBag[studentScript.ClubMemberID].GetComponent<Renderer>().enabled = false;
								studentScript.Instruments[studentScript.ClubMemberID].GetComponent<Renderer>().enabled = false;
							}
						}
						else if (studentScript.StudentID == 55)
						{
							studentScript.ClubAnim = "f02_practiceKeytar_00";
						}
					}
					else
					{
						studentScript.ClubAnim = "f02_practiceGuitar_00";
					}
					if (studentScript.StudentManager.Eighties && studentScript.StudentManager.Students[16] != null && DateGlobals.Week == 6)
					{
						studentScript.Instruments[studentScript.ClubMemberID].GetComponent<AudioSource>().enabled = false;
						studentScript.Instruments[studentScript.ClubMemberID].GetComponent<AudioSource>().volume = 0f;
						if (studentScript.StudentID == 52)
						{
							studentScript.ClubAnim = "f02_guitarPlayA_00";
						}
						else if (studentScript.StudentID == 53)
						{
							studentScript.ClubAnim = "f02_guitarPlayB_00";
						}
						else if (studentScript.StudentID == 54)
						{
							studentScript.ClubAnim = "f02_drumsPlay_00";
						}
						else if (studentScript.StudentID == 55)
						{
							studentScript.ClubAnim = "f02_keysPlay_00";
						}
					}
				}
				else if (studentScript.Club == ClubType.MartialArts)
				{
					studentScript.ChangingBooth = studentScript.StudentManager.ChangingBooths[6];
					studentScript.DressCode = true;
					if (studentScript.StudentID == 46)
					{
						studentScript.IdleAnim = "pose_03";
						studentScript.ClubAnim = "pose_03";
						studentScript.ActivityAnim = studentScript.IdleAnim;
					}
					else if (studentScript.StudentID == 47)
					{
						studentScript.GetNewAnimation = true;
						studentScript.ClubAnim = "idle_20";
						studentScript.ActivityAnim = "kick_24";
					}
					else if (studentScript.StudentID == 48)
					{
						studentScript.ClubAnim = "sit_04";
						studentScript.ActivityAnim = "kick_24";
					}
					else if (studentScript.StudentID == 49)
					{
						studentScript.GetNewAnimation = true;
						studentScript.ClubAnim = "f02_idle_20";
						studentScript.ActivityAnim = "f02_kick_23";
					}
					else if (studentScript.StudentID == 50)
					{
						studentScript.ClubAnim = "f02_sit_05";
						studentScript.ActivityAnim = "f02_kick_23";
					}
					studentScript.ClubMemberID = studentScript.StudentID - 45;
				}
				else if (studentScript.Club == ClubType.Science)
				{
					if (!studentScript.StudentManager.Eighties)
					{
						studentScript.ChangingBooth = studentScript.StudentManager.ChangingBooths[8];
						studentScript.Attacher.ScienceClub = true;
						studentScript.DressCode = true;
						if (studentScript.StudentID == 61)
						{
							studentScript.ClubAnim = "scienceMad_00";
						}
						else if (studentScript.StudentID == 62)
						{
							studentScript.ClubAnim = "scienceTablet_00";
						}
						else if (studentScript.StudentID == 63)
						{
							studentScript.ClubAnim = "scienceChemistry_00";
						}
						else if (studentScript.StudentID == 64)
						{
							studentScript.ClubAnim = "f02_scienceLeg_00";
						}
						else if (studentScript.StudentID == 65)
						{
							studentScript.ClubAnim = "f02_scienceConsole_00";
						}
					}
					else if (studentScript.Male)
					{
						studentScript.ClubAnim = "scienceChemistry_00";
					}
					else
					{
						studentScript.ClubAnim = "f02_scienceChemistry_00";
					}
					studentScript.ClubMemberID = studentScript.StudentID - 60;
				}
				else if (studentScript.Club == ClubType.Sports)
				{
					if (studentScript.Male)
					{
						studentScript.ChangingBooth = studentScript.StudentManager.ChangingBooths[9];
						studentScript.ClubAnim = "stretch_00";
					}
					else
					{
						studentScript.ChangingBooth = studentScript.StudentManager.ChangingBooths[10];
						studentScript.ClubAnim = "f02_stretch_00";
					}
					studentScript.DressCode = true;
					studentScript.ClubMemberID = studentScript.StudentID - 65;
				}
				else if (studentScript.Club == ClubType.Gardening)
				{
					if (!studentScript.StudentManager.Eighties)
					{
						if (studentScript.StudentID == 71)
						{
							studentScript.PatrolAnim = "f02_thinking_00";
							studentScript.ClubAnim = "f02_thinking_00";
							studentScript.CharacterAnimation[studentScript.PatrolAnim].speed = 0.9f;
						}
						else
						{
							studentScript.ClubAnim = "f02_waterPlant_00";
							studentScript.WateringCan.SetActive(value: true);
						}
					}
					else
					{
						if (studentScript.Male)
						{
							studentScript.PatrolAnim = "thinking_00";
							studentScript.ClubAnim = "thinking_00";
						}
						else
						{
							studentScript.PatrolAnim = "f02_thinking_00";
							studentScript.ClubAnim = "f02_thinking_00";
						}
						studentScript.CharacterAnimation[studentScript.PatrolAnim].speed = 0.9f;
					}
				}
				else if (studentScript.Club == ClubType.Newspaper)
				{
					if (studentScript.StudentID == 36)
					{
						studentScript.ClubAnim = "thinking_00";
					}
					else if (studentScript.Male)
					{
						studentScript.PatrolAnim = "thinking_00";
						studentScript.ClubAnim = "onComputer_00";
					}
					else
					{
						studentScript.PatrolAnim = "f02_thinking_00";
						studentScript.ClubAnim = "f02_onComputer_00";
					}
					studentScript.OriginalClubAnim = studentScript.ClubAnim;
				}
				if (studentScript.OriginalClub != ClubType.Gaming)
				{
					studentScript.Miyuki.gameObject.SetActive(value: false);
				}
				if (studentScript.Cosmetic.Hairstyle == 20)
				{
					studentScript.IdleAnim = "f02_tsunIdle_00";
				}
				if (StudentGlobals.StudentSlave > 100)
				{
					studentScript.CleaningSpot = GameObject.Find("Patrols/RoofFlowerCleaningSpots").transform;
				}
				yU9Z1mIPi0(int_0);
				studentScript.OriginalActions = new StudentActionType[studentScript.Actions.Length];
				Array.Copy(studentScript.Actions, studentScript.OriginalActions, studentScript.Actions.Length);
				if (studentScript.AoT)
				{
					studentScript.AttackOnTitan();
				}
				if (studentScript.Slave)
				{
					studentScript.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
					studentScript.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
					studentScript.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
					studentScript.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
					studentScript.IdleAnim = studentScript.BrokenAnim;
					studentScript.WalkAnim = studentScript.BrokenWalkAnim;
					studentScript.RightEmptyEye.SetActive(value: true);
					studentScript.LeftEmptyEye.SetActive(value: true);
					studentScript.SmartPhone.SetActive(value: false);
					studentScript.Distracted = true;
					studentScript.Indoors = true;
					studentScript.Safe = false;
					studentScript.Shy = false;
					studentScript.ID = 0;
					while (studentScript.ID < studentScript.ScheduleBlocks.Length)
					{
						studentScript.ScheduleBlocks[studentScript.ID].time = 0f;
						studentScript.ID++;
					}
					if (studentScript.FragileSlave)
					{
						studentScript.HuntTarget = studentScript.StudentManager.Students[StudentGlobals.FragileTarget];
					}
					else
					{
						SchoolGlobals.KidnapVictim = 0;
					}
				}
				if (studentScript.Spooky)
				{
					studentScript.Spook();
				}
				studentScript.Prompt.HideButton[0] = true;
				studentScript.Prompt.HideButton[2] = true;
				studentScript.ID = 0;
				while (studentScript.ID < studentScript.Ragdoll.AllRigidbodies.Length)
				{
					studentScript.Ragdoll.AllRigidbodies[studentScript.ID].isKinematic = true;
					studentScript.Ragdoll.AllColliders[studentScript.ID].enabled = false;
					studentScript.ID++;
				}
				studentScript.Ragdoll.AllColliders[10].enabled = true;
				if (studentScript.StudentID == 1)
				{
					studentScript.Yandere.Senpai = studentScript.transform;
					studentScript.Yandere.LookAt.target = studentScript.Head;
					studentScript.ID = 0;
					while (studentScript.ID < studentScript.Outlines.Length)
					{
						if (studentScript.Outlines[studentScript.ID] != null)
						{
							studentScript.Outlines[studentScript.ID].enabled = true;
							studentScript.Outlines[studentScript.ID].color = new Color(1f, 0f, 1f);
						}
						studentScript.ID++;
					}
					studentScript.Prompt.ButtonActive[0] = false;
					studentScript.Prompt.ButtonActive[1] = false;
					studentScript.Prompt.ButtonActive[2] = false;
					studentScript.Prompt.ButtonActive[3] = false;
					if (studentScript.StudentManager.MissionMode || GameGlobals.SenpaiMourning)
					{
						studentScript.transform.position = Vector3.zero;
						studentScript.gameObject.SetActive(value: false);
					}
				}
				else if (!StudentGlobals.GetStudentPhotographed(studentScript.StudentID) && !studentScript.Rival)
				{
					studentScript.ID = 0;
					while (studentScript.ID < studentScript.Outlines.Length)
					{
						if (studentScript.Outlines[studentScript.ID] != null)
						{
							studentScript.Outlines[studentScript.ID].enabled = false;
							studentScript.Outlines[studentScript.ID].color = new Color(0f, 1f, 0f);
						}
						studentScript.ID++;
					}
				}
				studentScript.PickRandomAnim();
				GT9Zg8iVMh(int_0);
				Renderer component = studentScript.Armband.GetComponent<Renderer>();
				if (studentScript.Club != 0 && (studentScript.StudentID == 21 || studentScript.StudentID == 26 || studentScript.StudentID == 31 || studentScript.StudentID == 36 || studentScript.StudentID == 41 || studentScript.StudentID == 46 || studentScript.StudentID == 51 || studentScript.StudentID == 56 || studentScript.StudentID == 61 || studentScript.StudentID == 66 || studentScript.StudentID == 71))
				{
					studentScript.Armband.SetActive(value: true);
					studentScript.ClubLeader = true;
					if (studentScript.StudentManager.EmptyDemon)
					{
						studentScript.IdleAnim = studentScript.OriginalIdleAnim;
						studentScript.WalkAnim = studentScript.OriginalOriginalWalkAnim;
						studentScript.OriginalPersona = PersonaType.Evil;
						studentScript.Persona = PersonaType.Evil;
						studentScript.ScaredAnim = studentScript.EvilWitnessAnim;
					}
				}
				if (!studentScript.Teacher)
				{
					studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
					studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
				}
				else
				{
					studentScript.Indoors = true;
				}
				if (studentScript.StudentID == 1 || studentScript.StudentID == 4 || studentScript.StudentID == 5 || studentScript.StudentID == 11)
				{
					studentScript.BookRenderer.material.mainTexture = studentScript.RedBookTexture;
				}
				studentScript.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
				if ((studentScript.StudentManager.MissionMode && studentScript.StudentID == MissionModeGlobals.MissionTarget) || studentScript.Rival)
				{
					studentScript.ID = 0;
					while (studentScript.ID < studentScript.Outlines.Length)
					{
						if (studentScript.Outlines[studentScript.ID] != null)
						{
							studentScript.Outlines[studentScript.ID].enabled = true;
							studentScript.Outlines[studentScript.ID].color = new Color(1f, 0f, 0f);
						}
						studentScript.ID++;
					}
				}
				UnityEngine.Object.Destroy(studentScript.MyRigidbody);
				studentScript.Started = true;
				if (studentScript.Club == ClubType.Council)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, 0f));
					studentScript.Armband.SetActive(value: true);
					studentScript.Indoors = true;
					studentScript.Spawned = true;
					if (studentScript.ShoeRemoval.Locker == null)
					{
						studentScript.ShoeRemoval.Start();
					}
					studentScript.ShoeRemoval.PutOnShoes();
					if (studentScript.StudentID == 86)
					{
						studentScript.Suffix = "Strict";
					}
					else if (studentScript.StudentID == 87)
					{
						studentScript.Suffix = "Casual";
					}
					else if (studentScript.StudentID == 88)
					{
						studentScript.Suffix = "Grace";
					}
					else if (studentScript.StudentID == 89)
					{
						studentScript.Suffix = "Edgy";
					}
					if (!studentScript.StudentManager.Eighties)
					{
						studentScript.IdleAnim = "f02_idleCouncil" + studentScript.Suffix + "_00";
						studentScript.WalkAnim = "f02_walkCouncil" + studentScript.Suffix + "_00";
						studentScript.ShoveAnim = "f02_pushCouncil" + studentScript.Suffix + "_00";
						studentScript.PatrolAnim = "f02_scanCouncil" + studentScript.Suffix + "_00";
						studentScript.RelaxAnim = "f02_relaxCouncil" + studentScript.Suffix + "_00";
						studentScript.SprayAnim = "f02_sprayCouncil" + studentScript.Suffix + "_00";
						studentScript.BreakUpAnim = "f02_stopCouncil" + studentScript.Suffix + "_00";
						studentScript.PickUpAnim = "f02_teacherPickUp_00";
					}
					else
					{
						studentScript.BreakUpAnim = "delinquentTalk_03";
						studentScript.GuardAnim = studentScript.ReadyToFightAnim;
						studentScript.RelaxAnim = "sit_00";
						if (studentScript.StudentID == 89)
						{
							studentScript.RelaxAnim = "crossarms_00";
						}
					}
					studentScript.ScaredAnim = studentScript.ReadyToFightAnim;
					studentScript.ParanoidAnim = studentScript.GuardAnim;
					studentScript.CameraAnims[1] = studentScript.IdleAnim;
					studentScript.CameraAnims[2] = studentScript.IdleAnim;
					studentScript.CameraAnims[3] = studentScript.IdleAnim;
					studentScript.ClubMemberID = studentScript.StudentID - 85;
					studentScript.VisionDistance *= 2f;
				}
				if (!studentScript.StudentManager.NoClubMeeting && studentScript.Armband.activeInHierarchy && studentScript.Clock.Weekday == 5)
				{
					if (studentScript.StudentID < 86)
					{
						ScheduleBlock obj33 = studentScript.ScheduleBlocks[6];
						obj33.destination = "Meeting";
						obj33.action = "Meeting";
					}
					else
					{
						ScheduleBlock obj34 = studentScript.ScheduleBlocks[5];
						obj34.destination = "Meeting";
						obj34.action = "Meeting";
					}
					yU9Z1mIPi0(int_0);
				}
				if (studentScript.StudentID == 81 && StudentGlobals.GetStudentBroken(81))
				{
					studentScript.Destinations[2] = studentScript.StudentManager.BrokenSpot;
					studentScript.Destinations[4] = studentScript.StudentManager.BrokenSpot;
					studentScript.Actions[2] = StudentActionType.Shamed;
					studentScript.Actions[4] = StudentActionType.Shamed;
				}
			}
			studentScript.UpdateAnimLayers();
			if (!studentScript.Male)
			{
				if (studentScript.StudentID == 40)
				{
					studentScript.LongHair[0] = studentScript.LongHair[2];
				}
				if (studentScript.StudentID != 55 && studentScript.StudentID != 40)
				{
					studentScript.LongHair[0] = null;
					studentScript.LongHair[1] = null;
					studentScript.LongHair[2] = null;
				}
			}
			studentScript.OriginalScheduleBlocks = new ScheduleBlock[studentScript.ScheduleBlocks.Length];
			Array.Copy(studentScript.ScheduleBlocks, studentScript.OriginalScheduleBlocks, studentScript.ScheduleBlocks.Length);
			studentScript.CharacterAnimation.Sample();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00016248 File Offset: 0x00014448
		private void RjZZqkCA3s(int int_0)
		{
			StudentScript studentScript = baseStudentManager.Students[int_0];
			studentScript.DetectionMarker = UnityEngine.Object.Instantiate(studentScript.Marker, studentScript.Yandere.DetectionPanel.transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
			if (studentScript.StudentID == 1)
			{
				studentScript.DetectionMarker.GetComponent<DetectionMarkerScript>().Tex.color = new Color(1f, 0f, 0f, 0f);
			}
			studentScript.DetectionMarker.transform.parent = studentScript.Yandere.DetectionPanel.transform;
			studentScript.DetectionMarker.Target = studentScript.transform;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000162FC File Offset: 0x000144FC
		private void ejjZLYl0li(int int_0)
		{
			StudentScript obj = baseStudentManager.Students[int_0];
			ScheduleBlock obj2 = obj.ScheduleBlocks[1];
			obj2.destination = "Mourn";
			obj2.action = "Mourn";
			ScheduleBlock obj3 = obj.ScheduleBlocks[2];
			obj3.destination = "Mourn";
			obj3.action = "Mourn";
			ScheduleBlock obj4 = obj.ScheduleBlocks[4];
			obj4.destination = "Mourn";
			obj4.action = "Mourn";
			obj.Persona = PersonaType.Heroic;
			obj.IdleAnim = obj.BulliedIdleAnim;
			obj.WalkAnim = obj.BulliedWalkAnim;
			obj.OriginalIdleAnim = obj.IdleAnim;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00016398 File Offset: 0x00014598
		private void IrUZGKRSBu(int int_0)
		{
			StudentScript obj = baseStudentManager.Students[int_0];
			ScheduleBlock obj2 = obj.ScheduleBlocks[3];
			obj2.destination = "Seat";
			obj2.action = "Sit";
			ScheduleBlock obj3 = obj.ScheduleBlocks[5];
			obj3.destination = "Seat";
			obj3.action = "Sit";
			ScheduleBlock obj4 = obj.ScheduleBlocks[6];
			obj4.destination = "Locker";
			obj4.action = "Shoes";
			ScheduleBlock obj5 = obj.ScheduleBlocks[7];
			obj5.destination = "Exit";
			obj5.action = "Exit";
			ScheduleBlock obj6 = obj.ScheduleBlocks[8];
			obj6.destination = "Exit";
			obj6.action = "Exit";
			ScheduleBlock obj7 = obj.ScheduleBlocks[9];
			obj7.destination = "Exit";
			obj7.action = "Exit";
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00016460 File Offset: 0x00014660
		private void GT9Zg8iVMh(int int_0)
		{
			StudentScript studentScript = baseStudentManager.Students[int_0];
			if (!studentScript.Sleuthing)
			{
				studentScript.RandomSleuthAnim = studentScript.SleuthAnims[UnityEngine.Random.Range(0, 3)];
			}
			else
			{
				studentScript.RandomSleuthAnim = studentScript.SleuthAnims[UnityEngine.Random.Range(3, 6)];
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000164AC File Offset: 0x000146AC
		public void CosmeticStartOverride(int int_0)
		{
			CosmeticScript cosmetic = baseStudentManager.Students[int_0].Cosmetic;
			if (cosmetic.StudentManager != null)
			{
				cosmetic.Eighties = cosmetic.StudentManager.Eighties;
			}
			else
			{
				cosmetic.Eighties = GameGlobals.Eighties;
			}
			if (cosmetic.Eighties && cosmetic.Male)
			{
				cosmetic.MaleUniformTextures[1] = cosmetic.EightiesMaleCasualTexture;
				cosmetic.MaleCasualTextures[1] = cosmetic.EightiesMaleUniformTexture;
				cosmetic.MaleSocksTextures[1] = cosmetic.EightiesMaleSocksTexture;
				int num = 66;
				while (num < cosmetic.Trunks.Length)
				{
					if (cosmetic.Trunks[num] != null)
					{
						cosmetic.Trunks[num] = cosmetic.Trunks[0];
						num++;
					}
				}
			}
			if (cosmetic.Cutscene && EventGlobals.OsanaConversation)
			{
				cosmetic.StudentID = 11;
			}
			if (cosmetic.RightShoe != null)
			{
				cosmetic.RightShoe.SetActive(value: false);
				cosmetic.LeftShoe.SetActive(value: false);
			}
			cosmetic.ColorValue = new Color(1f, 1f, 1f, 1f);
			if (cosmetic.JSON == null)
			{
				cosmetic.JSON = cosmetic.Student.JSON;
			}
			string empty = string.Empty;
			if (!cosmetic.Initialized)
			{
				cosmetic.Accessory = int.Parse(ExtraJson.Students[cosmetic.StudentID].Accessory);
				cosmetic.Hairstyle = int.Parse(ExtraJson.Students[cosmetic.StudentID].Hairstyle);
				cosmetic.Stockings = ExtraJson.Students[cosmetic.StudentID].Stockings;
				cosmetic.BreastSize = ExtraJson.Students[cosmetic.StudentID].BreastSize;
				cosmetic.EyeType = ExtraJson.Students[cosmetic.StudentID].EyeType;
				cosmetic.HairColor = ExtraJson.Students[cosmetic.StudentID].Color;
				cosmetic.EyeColor = ExtraJson.Students[cosmetic.StudentID].Eyes;
				cosmetic.Club = ExtraJson.Students[cosmetic.StudentID].Club;
				cosmetic.Name = ExtraJson.Students[cosmetic.StudentID].Name;
				if (cosmetic.Yandere)
				{
					cosmetic.Accessory = 0;
					cosmetic.Hairstyle = 1;
					cosmetic.Stockings = "Black";
					cosmetic.BreastSize = 1f;
					cosmetic.HairColor = "White";
					cosmetic.EyeColor = "Black";
					cosmetic.Club = ClubType.None;
				}
				cosmetic.OriginalStockings = cosmetic.Stockings;
				cosmetic.Initialized = true;
			}
			if (cosmetic.Medibang)
			{
				cosmetic.Accessory = 0;
				cosmetic.Hairstyle = 56;
				cosmetic.Stockings = "";
				cosmetic.BreastSize = 1f;
				cosmetic.EyeType = "";
				cosmetic.HairColor = "";
				cosmetic.EyeColor = "";
				cosmetic.Club = ClubType.Occult;
				cosmetic.Name = "Edgy Example Girl";
			}
			if (cosmetic.Kidnapped)
			{
				cosmetic.Accessory = 0;
				cosmetic.EyewearID = 0;
			}
			if (!cosmetic.Eighties)
			{
				if (cosmetic.StudentID == 11)
				{
					if (DateGlobals.Week > 1 && !cosmetic.Kidnapped && !cosmetic.Student.Slave)
					{
						cosmetic.Hairstyle = 54;
					}
				}
				else if (cosmetic.StudentID == 36)
				{
					cosmetic.FacialHairstyle = 12;
					cosmetic.EyewearID = 8;
					if (cosmetic.StudentManager.TaskManager != null && cosmetic.StudentManager.TaskManager.TaskStatus[36] == 3)
					{
						Debug.Log("Gema is updating his appearance.");
						cosmetic.FacialHairstyle = 0;
						cosmetic.EyewearID = 9;
						cosmetic.Hairstyle = 49;
						cosmetic.Accessory = 0;
					}
				}
				else if (cosmetic.StudentID == 51 && ClubGlobals.GetClubClosed(ClubType.LightMusic))
				{
					cosmetic.Hairstyle = 51;
				}
			}
			if (cosmetic.StudentManager != null && cosmetic.StudentManager.EmptyDemon && (cosmetic.StudentID == 21 || cosmetic.StudentID == 26 || cosmetic.StudentID == 31 || cosmetic.StudentID == 36 || cosmetic.StudentID == 41 || cosmetic.StudentID == 46 || cosmetic.StudentID == 51 || cosmetic.StudentID == 56 || cosmetic.StudentID == 61 || cosmetic.StudentID == 66 || cosmetic.StudentID == 71))
			{
				if (!cosmetic.Male)
				{
					cosmetic.Hairstyle = 52;
				}
				else
				{
					cosmetic.Hairstyle = 53;
				}
				cosmetic.FacialHairstyle = 0;
				cosmetic.EyewearID = 0;
				cosmetic.Accessory = 0;
				cosmetic.Stockings = "";
				cosmetic.BreastSize = 1f;
				cosmetic.Empty = true;
			}
			if (cosmetic.Name == "Random")
			{
				cosmetic.Randomize = true;
				if (!cosmetic.Male)
				{
					empty = cosmetic.StudentManager.FirstNames[UnityEngine.Random.Range(0, cosmetic.StudentManager.FirstNames.Length)] + " " + cosmetic.StudentManager.LastNames[UnityEngine.Random.Range(0, cosmetic.StudentManager.LastNames.Length)];
					ExtraJson.Students[cosmetic.StudentID].Name = empty;
					cosmetic.Student.Name = empty;
				}
				else
				{
					empty = cosmetic.StudentManager.MaleNames[UnityEngine.Random.Range(0, cosmetic.StudentManager.MaleNames.Length)] + " " + cosmetic.StudentManager.LastNames[UnityEngine.Random.Range(0, cosmetic.StudentManager.LastNames.Length)];
					ExtraJson.Students[cosmetic.StudentID].Name = empty;
					cosmetic.Student.Name = empty;
				}
				if (MissionModeGlobals.MissionMode && MissionModeGlobals.MissionTarget == cosmetic.StudentID)
				{
					ExtraJson.Students[cosmetic.StudentID].Name = MissionModeGlobals.MissionTargetName;
					cosmetic.Student.Name = MissionModeGlobals.MissionTargetName;
					empty = MissionModeGlobals.MissionTargetName;
				}
			}
			if (cosmetic.Randomize)
			{
				cosmetic.Teacher = false;
				cosmetic.BreastSize = UnityEngine.Random.Range(0.5f, 2f);
				cosmetic.Accessory = 0;
				cosmetic.Club = ClubType.None;
				if (!cosmetic.Male)
				{
					cosmetic.Hairstyle = UnityEngine.Random.Range(1, cosmetic.FemaleHair.Length);
				}
				else
				{
					cosmetic.SkinColor = UnityEngine.Random.Range(0, cosmetic.SkinTextures.Length);
					cosmetic.Hairstyle = UnityEngine.Random.Range(1, cosmetic.MaleHair.Length);
				}
			}
			cosmetic.DisableAccessories();
			bool flag = false;
			if (cosmetic.StudentManager != null && cosmetic.StudentID == cosmetic.StudentManager.SuitorID)
			{
				flag = true;
			}
			if (flag && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorEyewear > 0)
			{
				cosmetic.Eyewear[StudentGlobals.CustomSuitorEyewear].SetActive(value: true);
			}
			if (!cosmetic.Male)
			{
				cosmetic.FemaleUniformID = StudentGlobals.FemaleUniform;
				cosmetic.ThickBrows.SetActive(value: false);
				if (!cosmetic.TakingPortrait)
				{
					cosmetic.Tongue.SetActive(value: false);
				}
				GameObject[] phoneCharms = cosmetic.PhoneCharms;
				foreach (GameObject gameObject in phoneCharms)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(value: false);
					}
				}
				if (QualitySettings.GetQualityLevel() > 1)
				{
					cosmetic.Student.BreastSize = 1f;
					cosmetic.BreastSize = 1f;
				}
				cosmetic.RightBreast.localScale = new Vector3(cosmetic.BreastSize, cosmetic.BreastSize, cosmetic.BreastSize);
				cosmetic.LeftBreast.localScale = new Vector3(cosmetic.BreastSize, cosmetic.BreastSize, cosmetic.BreastSize);
				cosmetic.RightWristband.SetActive(value: false);
				cosmetic.LeftWristband.SetActive(value: false);
				if (!cosmetic.Eighties)
				{
					if (cosmetic.StudentID == 51)
					{
						cosmetic.RightTemple.name = "RENAMED";
						cosmetic.LeftTemple.name = "RENAMED";
						cosmetic.RightTemple.localScale = new Vector3(0f, 1f, 1f);
						cosmetic.LeftTemple.localScale = new Vector3(0f, 1f, 1f);
						if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
						{
							cosmetic.SadBrows.SetActive(value: true);
						}
						else
						{
							cosmetic.ThickBrows.SetActive(value: true);
						}
					}
					else if (cosmetic.StudentID == 84 && StudentGlobals.GetStudentDead(81) && StudentGlobals.GetStudentDead(82) && StudentGlobals.GetStudentDead(83) && StudentGlobals.GetStudentDead(85))
					{
						cosmetic.Student.Club = ClubType.None;
						cosmetic.StudentManager.Bullies = 0;
						cosmetic.Club = ClubType.None;
						cosmetic.Hairstyle = 53;
					}
				}
				if (cosmetic.Club == ClubType.Bully)
				{
					if (!cosmetic.Kidnapped)
					{
						cosmetic.Student.SmartPhone.GetComponent<Renderer>().material.mainTexture = cosmetic.SmartphoneTextures[cosmetic.StudentID];
						cosmetic.Student.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
						cosmetic.Student.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
						cosmetic.Bookbag.GetComponent<MeshFilter>().mesh = cosmetic.ModernBookBagMesh;
					}
					cosmetic.RightWristband.GetComponent<Renderer>().material.mainTexture = cosmetic.WristwearTextures[cosmetic.StudentID];
					cosmetic.LeftWristband.GetComponent<Renderer>().material.mainTexture = cosmetic.WristwearTextures[cosmetic.StudentID];
					cosmetic.Bookbag.GetComponent<Renderer>().material.mainTexture = cosmetic.BookbagTextures[cosmetic.StudentID];
					cosmetic.HoodieRenderer.material.mainTexture = cosmetic.HoodieTextures[cosmetic.StudentID];
					if (cosmetic.PhoneCharms.Length != 0)
					{
						cosmetic.PhoneCharms[cosmetic.StudentID].SetActive(value: true);
					}
					if (cosmetic.FemaleUniformID < 2 || cosmetic.FemaleUniformID == 3)
					{
						cosmetic.RightWristband.SetActive(value: true);
						cosmetic.LeftWristband.SetActive(value: true);
					}
					cosmetic.Bookbag.SetActive(value: true);
					cosmetic.Hoodie.SetActive(value: true);
					for (int j = 0; j < 10; j++)
					{
						cosmetic.Fingernails[j].material.mainTexture = cosmetic.GanguroNailTextures[cosmetic.StudentID];
					}
					cosmetic.Student.GymTexture = cosmetic.TanGymTexture;
					cosmetic.Student.TowelTexture = cosmetic.TanTowelTexture;
				}
				else
				{
					for (int k = 0; k < 10; k++)
					{
						cosmetic.Fingernails[k].gameObject.SetActive(value: false);
					}
					if (cosmetic.Club == ClubType.Gardening && !cosmetic.TakingPortrait && !cosmetic.Kidnapped)
					{
						cosmetic.CanRenderer.material.mainTexture = cosmetic.CanTextures[cosmetic.StudentID];
					}
				}
				if (!cosmetic.Kidnapped && SceneManager.GetActiveScene().name == "PortraitScene")
				{
					if (!cosmetic.Eighties)
					{
						if (cosmetic.StudentID == 2)
						{
							cosmetic.CharacterAnimation.Play("succubus_a_idle_twins_01");
							cosmetic.transform.position = new Vector3(0.094f, 0f, 0f);
							cosmetic.LookCamera = true;
							cosmetic.CharacterAnimation["f02_smile_00"].layer = 1;
							cosmetic.CharacterAnimation.Play("f02_smile_00");
							cosmetic.CharacterAnimation["f02_smile_00"].weight = 1f;
						}
						else if (cosmetic.StudentID == 3)
						{
							cosmetic.CharacterAnimation.Play("succubus_b_idle_twins_02");
							cosmetic.transform.position = new Vector3(-0.322f, 0.04f, 0f);
							cosmetic.LookCamera = true;
							cosmetic.CharacterAnimation["f02_smile_00"].layer = 1;
							cosmetic.CharacterAnimation.Play("f02_smile_00");
							cosmetic.CharacterAnimation["f02_smile_00"].weight = 1f;
						}
						else if (cosmetic.StudentID == 4)
						{
							cosmetic.CharacterAnimation.Play("f02_idleShort_00");
							cosmetic.transform.position = new Vector3(0.015f, 0f, 0f);
							cosmetic.LookCamera = true;
						}
						else if (cosmetic.StudentID == 5)
						{
							cosmetic.CharacterAnimation[cosmetic.Student.ShyAnim].layer = 5;
							cosmetic.CharacterAnimation.Play(cosmetic.Student.ShyAnim);
							cosmetic.CharacterAnimation[cosmetic.Student.ShyAnim].weight = 0.5f;
						}
						else if (cosmetic.StudentID == 10)
						{
							cosmetic.CharacterAnimation.Play("f02_raibaruPortraitPose_00");
						}
						else if (cosmetic.StudentID == 11)
						{
							cosmetic.CharacterAnimation.Play("f02_rivalPortraitPose_01");
							cosmetic.transform.position = new Vector3(-0.045f, 0f, 0f);
						}
						else if (cosmetic.StudentID == 24)
						{
							cosmetic.CharacterAnimation.Play("f02_idleGirly_00");
							cosmetic.CharacterAnimation["f02_idleGirly_00"].time = 1f;
						}
						else if (cosmetic.StudentID == 25)
						{
							cosmetic.CharacterAnimation.Play("f02_idleGirly_00");
							cosmetic.CharacterAnimation["f02_idleGirly_00"].time = 0f;
						}
						else if (cosmetic.StudentID == 30)
						{
							cosmetic.CharacterAnimation.Play("f02_idleGirly_00");
							cosmetic.CharacterAnimation["f02_idleGirly_00"].time = 0f;
						}
						else if (cosmetic.StudentID == 34)
						{
							cosmetic.CharacterAnimation.Play("f02_idleShort_00");
							cosmetic.transform.position = new Vector3(0.015f, 0f, 0f);
							cosmetic.LookCamera = true;
						}
						else if (cosmetic.StudentID == 35)
						{
							cosmetic.CharacterAnimation.Play("f02_idleShort_00");
							cosmetic.transform.position = new Vector3(0.015f, 0f, 0f);
							cosmetic.LookCamera = true;
						}
						else if (cosmetic.StudentID == 38)
						{
							cosmetic.CharacterAnimation.Play("f02_idleGirly_00");
							cosmetic.CharacterAnimation["f02_idleGirly_00"].time = 0f;
						}
						else if (cosmetic.StudentID == 39)
						{
							cosmetic.CharacterAnimation.Play("f02_socialCameraPose_00");
							cosmetic.transform.position = new Vector3(cosmetic.transform.position.x, cosmetic.transform.position.y + 0.05f, cosmetic.transform.position.z);
						}
						else if (cosmetic.StudentID == 40)
						{
							cosmetic.CharacterAnimation.Play("f02_idleGirly_00");
							cosmetic.CharacterAnimation["f02_idleGirly_00"].time = 1f;
						}
						else if (cosmetic.StudentID == 51)
						{
							cosmetic.CharacterAnimation.Play("f02_musicPose_00");
							cosmetic.Tongue.SetActive(value: true);
						}
						else if (cosmetic.StudentID == 59)
						{
							cosmetic.CharacterAnimation.Play("f02_sleuthPortrait_00");
						}
						else if (cosmetic.StudentID == 60)
						{
							cosmetic.CharacterAnimation.Play("f02_sleuthPortrait_01");
						}
						else if (cosmetic.StudentID == 64)
						{
							cosmetic.CharacterAnimation.Play("f02_idleShort_00");
							cosmetic.transform.position = new Vector3(0.015f, 0f, 0f);
							cosmetic.LookCamera = true;
						}
						else if (cosmetic.StudentID == 65)
						{
							cosmetic.CharacterAnimation.Play("f02_idleShort_00");
							cosmetic.transform.position = new Vector3(0.015f, 0f, 0f);
							cosmetic.LookCamera = true;
						}
						else if (cosmetic.StudentID == 71)
						{
							cosmetic.CharacterAnimation.Play("f02_idleGirly_00");
							cosmetic.CharacterAnimation["f02_idleGirly_00"].time = 0f;
						}
						else if (cosmetic.StudentID == 72)
						{
							cosmetic.CharacterAnimation.Play("f02_idleGirly_00");
							cosmetic.CharacterAnimation["f02_idleGirly_00"].time = 0.66666f;
						}
						else if (cosmetic.StudentID == 73)
						{
							cosmetic.CharacterAnimation.Play("f02_idleGirly_00");
							cosmetic.CharacterAnimation["f02_idleGirly_00"].time = 1.33332f;
						}
						else if (cosmetic.StudentID == 74)
						{
							cosmetic.CharacterAnimation.Play("f02_idleGirly_00");
							cosmetic.CharacterAnimation["f02_idleGirly_00"].time = 1.99998f;
						}
						else if (cosmetic.StudentID == 75)
						{
							cosmetic.CharacterAnimation.Play("f02_idleGirly_00");
							cosmetic.CharacterAnimation["f02_idleGirly_00"].time = 2.66664f;
						}
						else if (cosmetic.StudentID == 81)
						{
							string text = "Casual";
							cosmetic.CharacterAnimation["f02_faceCouncil" + text + "_00"].layer = 1;
							cosmetic.CharacterAnimation.Play("f02_faceCouncil" + text + "_00");
							cosmetic.CharacterAnimation.Play("f02_socialCameraPose_00");
							cosmetic.transform.position = new Vector3(cosmetic.transform.position.x, cosmetic.transform.position.y + 0.05f, cosmetic.transform.position.z);
						}
						else if (cosmetic.StudentID != 82 && cosmetic.StudentID != 52)
						{
							if (cosmetic.StudentID != 83 && cosmetic.StudentID != 53)
							{
								if (cosmetic.StudentID != 84 && cosmetic.StudentID != 54)
								{
									if (cosmetic.StudentID != 85 && cosmetic.StudentID != 55)
									{
										if (cosmetic.StudentID == 90)
										{
											cosmetic.CharacterAnimation.Play("f02_nursePortraitPose_00");
										}
										else if (cosmetic.StudentID == 91)
										{
											cosmetic.CharacterAnimation.Play("f02_teacherPortraitPose_11");
											cosmetic.transform.position = new Vector3(0.0233333f, 0f, 0f);
										}
										else if (cosmetic.StudentID == 92)
										{
											cosmetic.CharacterAnimation.Play("f02_teacherPortraitPose_12");
											cosmetic.transform.position = new Vector3(-0.045f, 0f, 0f);
										}
										else if (cosmetic.StudentID == 93)
										{
											cosmetic.CharacterAnimation.Play("f02_teacherPortraitPose_21");
										}
										else if (cosmetic.StudentID == 94)
										{
											cosmetic.CharacterAnimation.Play("f02_teacherPortraitPose_22");
										}
										else if (cosmetic.StudentID == 95)
										{
											cosmetic.CharacterAnimation.Play("f02_teacherPortraitPose_31");
										}
										else if (cosmetic.StudentID == 96)
										{
											cosmetic.CharacterAnimation.Play("f02_teacherPortraitPose_32");
										}
										else if (cosmetic.StudentID == 97)
										{
											cosmetic.CharacterAnimation.Play("f02_coachPortraitPose_00");
											cosmetic.transform.position = new Vector3(-0.029f, 0f, 0f);
										}
										else if (cosmetic.Club != ClubType.Council)
										{
											cosmetic.CharacterAnimation.Play("f02_idleShort_01");
											cosmetic.transform.position = new Vector3(0.015f, 0f, 0f);
											cosmetic.LookCamera = true;
										}
									}
									else
									{
										cosmetic.CharacterAnimation.Play("f02_galPose_04");
									}
								}
								else
								{
									cosmetic.CharacterAnimation.Play("f02_galPose_03");
								}
							}
							else
							{
								cosmetic.CharacterAnimation.Play("f02_galPose_02");
							}
						}
						else
						{
							cosmetic.CharacterAnimation.Play("f02_galPose_01");
						}
					}
					else
					{
						cosmetic.transform.position = new Vector3(0.015f, 0f, 0f);
						if (cosmetic.StudentID > 10 && cosmetic.StudentID < 20)
						{
							cosmetic.transform.position = new Vector3(0f, 0f, 0f);
							cosmetic.CharacterAnimation.Play("f02_eightiesRivalPose_0" + (cosmetic.StudentID - 10));
						}
						else if (cosmetic.StudentID == 20)
						{
							cosmetic.transform.position = new Vector3(0f, 0f, 0f);
							cosmetic.CharacterAnimation.Play("f02_eightiesRivalPose_10");
						}
						if (cosmetic.StudentID > 2 && cosmetic.StudentID < 7)
						{
							cosmetic.CharacterAnimation["f02_smile_00"].layer = 1;
							cosmetic.CharacterAnimation.Play("f02_smile_00");
							cosmetic.CharacterAnimation["f02_smile_00"].weight = 1f;
						}
					}
				}
			}
			else
			{
				cosmetic.MaleUniformID = StudentGlobals.MaleUniform;
				GameObject[] galoAccessories = cosmetic.GaloAccessories;
				for (int l = 0; l < galoAccessories.Length; l++)
				{
					galoAccessories[l].SetActive(value: false);
				}
				bool flag2 = false;
				if (cosmetic.StudentManager != null && cosmetic.StudentID == cosmetic.StudentManager.SuitorID)
				{
					flag2 = true;
				}
				if (flag2 && StudentGlobals.CustomSuitor)
				{
					if (StudentGlobals.CustomSuitorHair > 0)
					{
						cosmetic.Hairstyle = StudentGlobals.CustomSuitorHair;
					}
					if (StudentGlobals.CustomSuitorAccessory > 0)
					{
						cosmetic.Accessory = StudentGlobals.CustomSuitorAccessory;
						if (cosmetic.Accessory == 1)
						{
							Transform obj = cosmetic.MaleAccessories[1].transform;
							obj.localScale = new Vector3(1.066666f, 1f, 1f);
							obj.localPosition = new Vector3(0f, -1.525f, 0.0066666f);
						}
					}
					if (StudentGlobals.CustomSuitorBlack)
					{
						cosmetic.HairColor = "SolidBlack";
					}
					if (StudentGlobals.CustomSuitorJewelry > 0)
					{
						galoAccessories = cosmetic.GaloAccessories;
						for (int m = 0; m < galoAccessories.Length; m++)
						{
							galoAccessories[m].SetActive(value: true);
						}
					}
				}
				if (!(cosmetic.StudentManager == null) && cosmetic.Eighties)
				{
					if (!cosmetic.Student.Posing)
					{
						if (cosmetic.Eighties)
						{
							if (cosmetic.StudentID == 86)
							{
								cosmetic.CharacterAnimation["toughFace_00"].layer = 1;
								cosmetic.CharacterAnimation.Play("toughFace_00");
								cosmetic.CharacterAnimation["toughFace_00"].weight = 1f;
							}
							if (cosmetic.Club == ClubType.Council)
							{
								cosmetic.CouncilBrows[cosmetic.StudentID - 85].SetActive(value: true);
							}
							if (cosmetic.StudentID == 76)
							{
								cosmetic.CharacterAnimation.Play("delinquentPoseB");
							}
							else if (cosmetic.StudentID == 77)
							{
								cosmetic.CharacterAnimation.Play("delinquentPoseA");
							}
							else if (cosmetic.StudentID == 78)
							{
								cosmetic.CharacterAnimation.Play("delinquentPoseC");
							}
							else if (cosmetic.StudentID == 79)
							{
								cosmetic.CharacterAnimation.Play("delinquentPoseD");
							}
							else if (cosmetic.StudentID == 80)
							{
								cosmetic.CharacterAnimation.Play("delinquentPoseE");
							}
						}
						if (cosmetic.Club == ClubType.Delinquent)
						{
							cosmetic.transform.position = new Vector3(0.005f, 0.03f, 0f);
						}
						else
						{
							cosmetic.transform.position = new Vector3(0.005f, 0f, 0f);
						}
					}
				}
				else
				{
					cosmetic.ThickBrows.SetActive(value: false);
					if (cosmetic.Club == ClubType.Occult)
					{
						cosmetic.CharacterAnimation["sadFace_00"].layer = 1;
						cosmetic.CharacterAnimation.Play("sadFace_00");
						cosmetic.CharacterAnimation["sadFace_00"].weight = 1f;
					}
					if (cosmetic.StudentID == 36 || cosmetic.StudentID == 66)
					{
						cosmetic.CharacterAnimation["toughFace_00"].layer = 1;
						cosmetic.CharacterAnimation.Play("toughFace_00");
						cosmetic.CharacterAnimation["toughFace_00"].weight = 1f;
						if (cosmetic.StudentID == 66)
						{
							cosmetic.ThickBrows.SetActive(value: true);
						}
					}
					if (SceneManager.GetActiveScene().name == "PortraitScene")
					{
						if (cosmetic.StudentID == 26)
						{
							cosmetic.CharacterAnimation.Play("idleHaughty_00");
						}
						else if (cosmetic.StudentID == 36)
						{
							cosmetic.CharacterAnimation.Play("slouchIdle_00");
						}
						else if (cosmetic.StudentID == 56)
						{
							cosmetic.CharacterAnimation.Play("idleConfident_00");
						}
						else if (cosmetic.StudentID == 57)
						{
							cosmetic.CharacterAnimation.Play("sleuthPortrait_00");
						}
						else if (cosmetic.StudentID == 58)
						{
							cosmetic.CharacterAnimation.Play("sleuthPortrait_01");
						}
						else if (cosmetic.StudentID == 61)
						{
							cosmetic.CharacterAnimation.Play("scienceMad_00");
							cosmetic.transform.position = new Vector3(0f, 0.1f, 0f);
						}
						else if (cosmetic.StudentID == 62)
						{
							cosmetic.CharacterAnimation.Play("idleFrown_00");
						}
						else if (cosmetic.StudentID == 69)
						{
							cosmetic.CharacterAnimation.Play("idleFrown_00");
						}
						else if (cosmetic.StudentID == 76)
						{
							cosmetic.CharacterAnimation.Play("delinquentPoseB");
						}
						else if (cosmetic.StudentID == 77)
						{
							cosmetic.CharacterAnimation.Play("delinquentPoseA");
						}
						else if (cosmetic.StudentID == 78)
						{
							cosmetic.CharacterAnimation.Play("delinquentPoseC");
						}
						else if (cosmetic.StudentID == 79)
						{
							cosmetic.CharacterAnimation.Play("delinquentPoseD");
						}
						else if (cosmetic.StudentID == 80)
						{
							cosmetic.CharacterAnimation.Play("delinquentPoseE");
						}
					}
				}
			}
			if (cosmetic.Club == ClubType.Teacher)
			{
				cosmetic.MyRenderer.sharedMesh = cosmetic.TeacherMesh;
				if (!SystemInfo.supportsComputeShaders)
				{
					cosmetic.MyRenderer.sharedMesh.ClearBlendShapes();
				}
				cosmetic.Teacher = true;
				if (cosmetic.Eighties)
				{
					cosmetic.Student.EightiesTeacherAttacher.SetActive(value: true);
					cosmetic.Student.MyRenderer.enabled = false;
				}
			}
			else if (cosmetic.Club == ClubType.GymTeacher)
			{
				if (!StudentGlobals.GetStudentReplaced(cosmetic.StudentID))
				{
					cosmetic.CharacterAnimation["f02_smile_00"].layer = 1;
					cosmetic.CharacterAnimation.Play("f02_smile_00");
					cosmetic.CharacterAnimation["f02_smile_00"].weight = 1f;
					cosmetic.RightEyeRenderer.gameObject.SetActive(value: false);
					cosmetic.LeftEyeRenderer.gameObject.SetActive(value: false);
				}
				cosmetic.MyRenderer.sharedMesh = cosmetic.CoachMesh;
				cosmetic.Teacher = true;
			}
			else if (cosmetic.Club == ClubType.Nurse)
			{
				if (!cosmetic.Eighties)
				{
					cosmetic.MyRenderer.sharedMesh = cosmetic.NurseMesh;
				}
				else
				{
					cosmetic.MyRenderer.sharedMesh = cosmetic.EightiesNurseMesh;
				}
				cosmetic.Teacher = true;
			}
			else if (cosmetic.Club == ClubType.Council)
			{
				cosmetic.Armband.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.285f, 0f));
				cosmetic.Armband.SetActive(value: true);
				string text2 = "";
				if (cosmetic.StudentID == 86)
				{
					text2 = "Strict";
				}
				if (cosmetic.StudentID == 87)
				{
					text2 = "Casual";
				}
				if (cosmetic.StudentID == 88)
				{
					text2 = "Grace";
				}
				if (cosmetic.StudentID == 89)
				{
					text2 = "Edgy";
				}
				if (!cosmetic.Eighties)
				{
					cosmetic.CharacterAnimation["f02_faceCouncil" + text2 + "_00"].layer = 1;
					cosmetic.CharacterAnimation.Play("f02_faceCouncil" + text2 + "_00");
					cosmetic.CharacterAnimation["f02_idleCouncil" + text2 + "_00"].time = 1f;
					cosmetic.CharacterAnimation.Play("f02_idleCouncil" + text2 + "_00");
				}
			}
			if (!ClubGlobals.GetClubClosed(cosmetic.Club) && (cosmetic.StudentID == 21 || cosmetic.StudentID == 26 || cosmetic.StudentID == 31 || cosmetic.StudentID == 36 || cosmetic.StudentID == 41 || cosmetic.StudentID == 46 || cosmetic.StudentID == 51 || cosmetic.StudentID == 56 || cosmetic.StudentID == 61 || cosmetic.StudentID == 66 || cosmetic.StudentID == 71))
			{
				cosmetic.Armband.SetActive(value: true);
				Renderer component = cosmetic.Armband.GetComponent<Renderer>();
				if (cosmetic.StudentID == 21)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.145f));
				}
				else if (cosmetic.StudentID == 26)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.145f));
				}
				else if (cosmetic.StudentID == 31)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, 0f));
				}
				else if (cosmetic.StudentID == 36)
				{
					if (!cosmetic.Eighties)
					{
						component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.29f));
					}
					else
					{
						component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.435f));
					}
				}
				else if (cosmetic.StudentID == 41)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.58f));
				}
				else if (cosmetic.StudentID == 46)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.435f));
				}
				else if (cosmetic.StudentID == 51)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.29f));
				}
				else if (cosmetic.StudentID == 56)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.29f));
				}
				else if (cosmetic.StudentID == 61)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
				}
				else if (cosmetic.StudentID == 66)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.145f));
				}
				else if (cosmetic.StudentID == 71)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.435f));
				}
			}
			if (cosmetic.StudentID == 1 && SenpaiGlobals.CustomSenpai)
			{
				if (SenpaiGlobals.SenpaiEyeWear > 0)
				{
					cosmetic.Eyewear[SenpaiGlobals.SenpaiEyeWear].SetActive(value: true);
				}
				cosmetic.FacialHairstyle = SenpaiGlobals.SenpaiFacialHair;
				cosmetic.HairColor = SenpaiGlobals.SenpaiHairColor;
				cosmetic.EyeColor = SenpaiGlobals.SenpaiEyeColor;
				cosmetic.Hairstyle = SenpaiGlobals.SenpaiHairStyle;
			}
			if (!cosmetic.Male)
			{
				if (!cosmetic.Teacher)
				{
					cosmetic.FemaleHair[cosmetic.Hairstyle].SetActive(value: true);
					cosmetic.HairRenderer = cosmetic.FemaleHairRenderers[cosmetic.Hairstyle];
					cosmetic.SetFemaleUniform();
				}
				else
				{
					cosmetic.TeacherHair[cosmetic.Hairstyle].SetActive(value: true);
					cosmetic.HairRenderer = cosmetic.TeacherHairRenderers[cosmetic.Hairstyle];
					if (cosmetic.Club == ClubType.Teacher)
					{
						cosmetic.MyRenderer.materials[1].mainTexture = cosmetic.TeacherBodyTexture;
						cosmetic.MyRenderer.materials[2].mainTexture = cosmetic.DefaultFaceTexture;
						cosmetic.MyRenderer.materials[0].mainTexture = cosmetic.TeacherBodyTexture;
					}
					else if (cosmetic.Club == ClubType.GymTeacher)
					{
						if (StudentGlobals.GetStudentReplaced(cosmetic.StudentID))
						{
							cosmetic.MyRenderer.materials[2].mainTexture = cosmetic.DefaultFaceTexture;
							cosmetic.MyRenderer.materials[0].mainTexture = cosmetic.CoachPaleBodyTexture;
							cosmetic.MyRenderer.materials[1].mainTexture = cosmetic.CoachPaleBodyTexture;
						}
						else
						{
							if (!cosmetic.Eighties)
							{
								cosmetic.MyRenderer.materials[2].mainTexture = cosmetic.CoachFaceTexture;
							}
							else
							{
								cosmetic.MyRenderer.materials[2].mainTexture = cosmetic.EightiesCoachFaceTexture;
							}
							cosmetic.MyRenderer.materials[0].mainTexture = cosmetic.CoachBodyTexture;
							cosmetic.MyRenderer.materials[1].mainTexture = cosmetic.CoachBodyTexture;
						}
					}
					else if (cosmetic.Club == ClubType.Nurse)
					{
						if (!cosmetic.Eighties)
						{
							cosmetic.MyRenderer.materials = cosmetic.NurseMaterials;
						}
						else
						{
							cosmetic.MyRenderer.materials = cosmetic.EightiesNurseMaterials;
						}
					}
				}
			}
			else
			{
				if (cosmetic.Hairstyle > 0)
				{
					cosmetic.MaleHair[cosmetic.Hairstyle].SetActive(value: true);
					cosmetic.HairRenderer = cosmetic.MaleHairRenderers[cosmetic.Hairstyle];
				}
				if (cosmetic.FacialHairstyle > 0)
				{
					cosmetic.FacialHair[cosmetic.FacialHairstyle].SetActive(value: true);
					cosmetic.FacialHairRenderer = cosmetic.FacialHairRenderers[cosmetic.FacialHairstyle];
				}
				if (cosmetic.EyewearID > 0)
				{
					cosmetic.Eyewear[cosmetic.EyewearID].SetActive(value: true);
				}
				cosmetic.SetMaleUniform();
			}
			if (!cosmetic.Male)
			{
				if (!cosmetic.Teacher)
				{
					if (cosmetic.FemaleAccessories[cosmetic.Accessory] != null)
					{
						cosmetic.FemaleAccessories[cosmetic.Accessory].SetActive(value: true);
					}
				}
				else if (cosmetic.TeacherAccessories[cosmetic.Accessory] != null)
				{
					cosmetic.TeacherAccessories[cosmetic.Accessory].SetActive(value: true);
				}
			}
			else if (cosmetic.MaleAccessories[cosmetic.Accessory] != null)
			{
				cosmetic.MaleAccessories[cosmetic.Accessory].SetActive(value: true);
			}
			if (cosmetic.StudentManager == null || (!cosmetic.Empty && !cosmetic.StudentManager.TutorialActive))
			{
				if (cosmetic.StudentManager == null || !cosmetic.Eighties)
				{
					if ((cosmetic.Club < ClubType.Gaming || cosmetic.Club == ClubType.Newspaper) && cosmetic.ClubAccessories[(int)cosmetic.Club] != null && !ClubGlobals.GetClubClosed(cosmetic.Club) && cosmetic.StudentID != 26)
					{
						cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: true);
					}
					if (!cosmetic.Eighties && cosmetic.StudentID == 36)
					{
						cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: true);
					}
					if (cosmetic.Club == ClubType.Cooking)
					{
						cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: false);
						cosmetic.ClubAccessories[(int)cosmetic.Club] = cosmetic.Kerchiefs[cosmetic.StudentID];
						if (!ClubGlobals.GetClubClosed(cosmetic.Club) && cosmetic.StudentID > 12)
						{
							cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: true);
						}
					}
					else if (cosmetic.Club == ClubType.Drama)
					{
						cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: false);
						cosmetic.ClubAccessories[(int)cosmetic.Club] = cosmetic.Roses[cosmetic.StudentID];
						if (!ClubGlobals.GetClubClosed(cosmetic.Club))
						{
							cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: true);
						}
					}
					else if (cosmetic.Club == ClubType.Art)
					{
						cosmetic.ClubAccessories[(int)cosmetic.Club].GetComponent<MeshFilter>().sharedMesh = cosmetic.Berets[cosmetic.StudentID];
						if (cosmetic.StudentID == 44)
						{
							cosmetic.ClubAccessories[(int)cosmetic.Club].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							cosmetic.ClubAccessories[(int)cosmetic.Club].transform.localScale = new Vector3(100f, 100f, 100f);
							cosmetic.ClubAccessories[(int)cosmetic.Club].transform.localPosition = new Vector3(0f, -1.445f, 0.02f);
						}
					}
					else if (cosmetic.Club == ClubType.Science)
					{
						cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: false);
						cosmetic.ClubAccessories[(int)cosmetic.Club] = cosmetic.Scanners[cosmetic.StudentID];
						if (!ClubGlobals.GetClubClosed(cosmetic.Club))
						{
							cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: true);
						}
					}
					else if (cosmetic.Club == ClubType.LightMusic)
					{
						cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: false);
						cosmetic.ClubAccessories[(int)cosmetic.Club] = cosmetic.MusicNotes[cosmetic.StudentID - 50];
						if (!ClubGlobals.GetClubClosed(cosmetic.Club))
						{
							cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: true);
						}
					}
					else if (cosmetic.Club == ClubType.Sports)
					{
						cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: false);
						cosmetic.ClubAccessories[(int)cosmetic.Club] = cosmetic.Goggles[cosmetic.StudentID];
						if (!ClubGlobals.GetClubClosed(cosmetic.Club))
						{
							cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: true);
						}
					}
					else if (cosmetic.Club == ClubType.Gardening)
					{
						cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: false);
						cosmetic.ClubAccessories[(int)cosmetic.Club] = cosmetic.Flowers[cosmetic.StudentID];
						if (!ClubGlobals.GetClubClosed(cosmetic.Club))
						{
							cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: true);
						}
					}
					else if (cosmetic.Club == ClubType.Gaming)
					{
						if (cosmetic.ClubAccessories[(int)cosmetic.Club] != null)
						{
							cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: false);
						}
						cosmetic.ClubAccessories[(int)cosmetic.Club] = cosmetic.RedCloth[cosmetic.StudentID];
						if (!ClubGlobals.GetClubClosed(cosmetic.Club) && cosmetic.ClubAccessories[(int)cosmetic.Club] != null)
						{
							cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: true);
						}
					}
				}
				if (!cosmetic.Eighties && cosmetic.StudentID == 36 && cosmetic.StudentManager != null && cosmetic.StudentManager.TaskManager != null && cosmetic.StudentManager.TaskManager.TaskStatus[36] == 3)
				{
					cosmetic.ClubAccessories[(int)cosmetic.Club].SetActive(value: false);
				}
			}
			if (cosmetic.StudentID == 11 && !cosmetic.TakingPortrait && !cosmetic.Cutscene && !cosmetic.Kidnapped && SceneManager.GetActiveScene().name == "SchoolScene")
			{
				cosmetic.CatGifts[1].SetActive(CollectibleGlobals.GetGiftGiven(1));
				cosmetic.CatGifts[2].SetActive(CollectibleGlobals.GetGiftGiven(2));
				cosmetic.CatGifts[3].SetActive(CollectibleGlobals.GetGiftGiven(3));
				cosmetic.CatGifts[4].SetActive(CollectibleGlobals.GetGiftGiven(4));
			}
			if (!cosmetic.Male)
			{
				cosmetic.StartCoroutine(cosmetic.PutOnStockings());
			}
			if (!cosmetic.Randomize)
			{
				if (cosmetic.EyeColor != string.Empty)
				{
					if (cosmetic.EyeColor == "White")
					{
						cosmetic.CorrectColor = new Color(1f, 1f, 1f);
					}
					else if (cosmetic.EyeColor == "Black")
					{
						cosmetic.CorrectColor = new Color(0.5f, 0.5f, 0.5f);
					}
					else if (cosmetic.EyeColor == "Red")
					{
						cosmetic.CorrectColor = new Color(1f, 0f, 0f);
					}
					else if (cosmetic.EyeColor == "Yellow")
					{
						cosmetic.CorrectColor = new Color(1f, 1f, 0f);
					}
					else if (cosmetic.EyeColor == "Green")
					{
						cosmetic.CorrectColor = new Color(0f, 1f, 0f);
					}
					else if (cosmetic.EyeColor == "Cyan")
					{
						cosmetic.CorrectColor = new Color(0f, 1f, 1f);
					}
					else if (cosmetic.EyeColor == "Blue")
					{
						cosmetic.CorrectColor = new Color(0f, 0f, 1f);
					}
					else if (cosmetic.EyeColor == "Purple")
					{
						cosmetic.CorrectColor = new Color(1f, 0f, 1f);
					}
					else if (cosmetic.EyeColor == "Orange")
					{
						cosmetic.CorrectColor = new Color(1f, 0.5f, 0f);
					}
					else if (cosmetic.EyeColor == "Brown")
					{
						cosmetic.CorrectColor = new Color(0.5f, 0.25f, 0f);
					}
					else
					{
						cosmetic.CorrectColor = new Color(0f, 0f, 0f);
					}
					if (cosmetic.StudentID > 90 && cosmetic.StudentID < 97)
					{
						cosmetic.CorrectColor.r = cosmetic.CorrectColor.r * 0.5f;
						cosmetic.CorrectColor.g = cosmetic.CorrectColor.g * 0.5f;
						cosmetic.CorrectColor.b = cosmetic.CorrectColor.b * 0.5f;
					}
					if (cosmetic.CorrectColor != new Color(0f, 0f, 0f))
					{
						cosmetic.RightEyeRenderer.material.color = cosmetic.CorrectColor;
						cosmetic.LeftEyeRenderer.material.color = cosmetic.CorrectColor;
					}
				}
			}
			else
			{
				float r = UnityEngine.Random.Range(0f, 1f);
				float g = UnityEngine.Random.Range(0f, 1f);
				float b = UnityEngine.Random.Range(0f, 1f);
				cosmetic.RightEyeRenderer.material.color = new Color(r, g, b);
				cosmetic.LeftEyeRenderer.material.color = new Color(r, g, b);
			}
			if (!cosmetic.Randomize)
			{
				if (cosmetic.HairColor == "White")
				{
					cosmetic.ColorValue = new Color(1f, 1f, 1f);
				}
				else if (cosmetic.HairColor == "Black")
				{
					cosmetic.ColorValue = new Color(0.5f, 0.5f, 0.5f);
				}
				else if (cosmetic.HairColor == "SolidBlack")
				{
					cosmetic.ColorValue = new Color(0.0001f, 0.0001f, 0.0001f);
				}
				else if (cosmetic.HairColor == "Red")
				{
					cosmetic.ColorValue = new Color(1f, 0f, 0f);
				}
				else if (cosmetic.HairColor == "Yellow")
				{
					cosmetic.ColorValue = new Color(1f, 1f, 0f);
				}
				else if (cosmetic.HairColor == "Green")
				{
					cosmetic.ColorValue = new Color(0f, 1f, 0f);
				}
				else if (cosmetic.HairColor == "Cyan")
				{
					cosmetic.ColorValue = new Color(0f, 1f, 1f);
				}
				else if (cosmetic.HairColor == "Blue")
				{
					cosmetic.ColorValue = new Color(0f, 0f, 1f);
				}
				else if (cosmetic.HairColor == "Purple")
				{
					cosmetic.ColorValue = new Color(1f, 0f, 1f);
				}
				else if (cosmetic.HairColor == "Orange")
				{
					cosmetic.ColorValue = new Color(1f, 0.5f, 0f);
				}
				else if (cosmetic.HairColor == "Brown")
				{
					cosmetic.ColorValue = new Color(0.5f, 0.25f, 0f);
				}
				else
				{
					cosmetic.ColorValue = new Color(0f, 0f, 0f);
					cosmetic.RightIrisLight.SetActive(value: false);
					cosmetic.LeftIrisLight.SetActive(value: false);
				}
				if (cosmetic.StudentID > 90 && cosmetic.StudentID < 97)
				{
					cosmetic.ColorValue.r = cosmetic.ColorValue.r * 0.5f;
					cosmetic.ColorValue.g = cosmetic.ColorValue.g * 0.5f;
					cosmetic.ColorValue.b = cosmetic.ColorValue.b * 0.5f;
				}
				if (cosmetic.ColorValue == new Color(0f, 0f, 0f))
				{
					if (cosmetic.HairRenderer != null)
					{
						cosmetic.RightEyeRenderer.material.mainTexture = cosmetic.HairRenderer.material.mainTexture;
						cosmetic.LeftEyeRenderer.material.mainTexture = cosmetic.HairRenderer.material.mainTexture;
						if (!cosmetic.DoNotChangeFace)
						{
							cosmetic.FaceTexture = cosmetic.HairRenderer.material.mainTexture;
						}
					}
					if (cosmetic.Empty)
					{
						cosmetic.FaceTexture = cosmetic.GrayFace;
					}
					cosmetic.CustomHair = true;
				}
				if (!cosmetic.CustomHair)
				{
					if (cosmetic.Hairstyle > 0)
					{
						if (GameGlobals.LoveSick)
						{
							cosmetic.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
							if (cosmetic.HairRenderer.materials.Length > 1)
							{
								cosmetic.HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
							}
						}
						else
						{
							cosmetic.HairRenderer.material.color = cosmetic.ColorValue;
						}
					}
				}
				else if (GameGlobals.LoveSick)
				{
					cosmetic.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
					if (cosmetic.HairRenderer.materials.Length > 1)
					{
						cosmetic.HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
					}
				}
				if (!cosmetic.Male)
				{
					if (cosmetic.StudentID == 25)
					{
						cosmetic.FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(0f, 1f, 1f);
					}
					else if (cosmetic.StudentID == 30)
					{
						cosmetic.FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f);
					}
				}
			}
			else
			{
				cosmetic.HairRenderer.material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
			}
			if (!cosmetic.Teacher)
			{
				if (cosmetic.CustomHair)
				{
					if (!cosmetic.Male)
					{
						cosmetic.MyRenderer.materials[2].mainTexture = cosmetic.FaceTexture;
					}
					else if (cosmetic.Club == ClubType.Council)
					{
						cosmetic.MyRenderer.materials[0].mainTexture = cosmetic.FaceTexture;
					}
					else if (cosmetic.MaleUniformID == 1)
					{
						cosmetic.MyRenderer.materials[2].mainTexture = cosmetic.FaceTexture;
					}
					else if (cosmetic.MaleUniformID < 4)
					{
						cosmetic.MyRenderer.materials[1].mainTexture = cosmetic.FaceTexture;
					}
					else
					{
						cosmetic.MyRenderer.materials[0].mainTexture = cosmetic.FaceTexture;
					}
				}
			}
			else if (cosmetic.Teacher && StudentGlobals.GetStudentReplaced(cosmetic.StudentID))
			{
				Color studentColor = StudentGlobals.GetStudentColor(cosmetic.StudentID);
				Color studentEyeColor = StudentGlobals.GetStudentEyeColor(cosmetic.StudentID);
				cosmetic.HairRenderer.material.color = studentColor;
				cosmetic.RightEyeRenderer.material.color = studentEyeColor;
				cosmetic.LeftEyeRenderer.material.color = studentEyeColor;
			}
			if (cosmetic.Male)
			{
				if (cosmetic.Accessory == 2)
				{
					cosmetic.RightIrisLight.SetActive(value: false);
					cosmetic.LeftIrisLight.SetActive(value: false);
				}
				if (SceneManager.GetActiveScene().name == "PortraitScene")
				{
					cosmetic.Character.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
				}
				if (cosmetic.FacialHairRenderer != null)
				{
					cosmetic.FacialHairRenderer.material.color = cosmetic.ColorValue;
					if (cosmetic.FacialHairRenderer.materials.Length > 1)
					{
						cosmetic.FacialHairRenderer.materials[1].color = cosmetic.ColorValue;
					}
				}
			}
			if (!cosmetic.Eighties)
			{
				if (cosmetic.StudentID != 10)
				{
					if (cosmetic.StudentID != 25 && cosmetic.StudentID != 30)
					{
						if (cosmetic.StudentID == 2)
						{
							if (GameGlobals.RingStolen)
							{
								cosmetic.FemaleAccessories[3].SetActive(value: false);
							}
						}
						else if (cosmetic.StudentID == 40)
						{
							if (cosmetic.transform.position != Vector3.zero)
							{
								cosmetic.RightEyeRenderer.material.mainTexture = cosmetic.WaifuEyeTexture;
								cosmetic.LeftEyeRenderer.material.mainTexture = cosmetic.WaifuEyeTexture;
								cosmetic.RightIrisLight.GetComponent<Renderer>().material.mainTexture = cosmetic.WaifuIrisTexture;
								cosmetic.LeftIrisLight.GetComponent<Renderer>().material.mainTexture = cosmetic.WaifuIrisTexture;
								cosmetic.RightIrisLight.SetActive(value: true);
								cosmetic.LeftIrisLight.SetActive(value: true);
								cosmetic.RightEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
								cosmetic.LeftEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
							}
						}
						else if (cosmetic.StudentID == 41)
						{
							cosmetic.CharacterAnimation["moodyEyes_00"].layer = 1;
							cosmetic.CharacterAnimation.Play("moodyEyes_00");
							cosmetic.CharacterAnimation["moodyEyes_00"].weight = 1f;
							cosmetic.CharacterAnimation.Play("moodyEyes_00");
						}
						else if (cosmetic.StudentID == 51)
						{
							if (!ClubGlobals.GetClubClosed(ClubType.LightMusic))
							{
								cosmetic.PunkAccessories[1].SetActive(value: true);
								cosmetic.PunkAccessories[2].SetActive(value: true);
								cosmetic.PunkAccessories[3].SetActive(value: true);
							}
						}
						else if (cosmetic.StudentID == 59)
						{
							cosmetic.ClubAccessories[7].transform.localPosition = new Vector3(0f, -1.04f, 0.5f);
							cosmetic.ClubAccessories[7].transform.localEulerAngles = new Vector3(-22.5f, 0f, 0f);
						}
						else if (cosmetic.StudentID == 60)
						{
							cosmetic.FemaleAccessories[13].SetActive(value: true);
						}
					}
					else
					{
						cosmetic.FemaleAccessories[6].SetActive(value: true);
						if ((float)StudentGlobals.GetStudentReputation(cosmetic.StudentID) < -33.33333f)
						{
							cosmetic.FemaleAccessories[6].SetActive(value: false);
						}
					}
				}
			}
			else if (cosmetic.StudentID == 86)
			{
				cosmetic.CharacterAnimation["moodyEyes_00"].layer = 1;
				cosmetic.CharacterAnimation.Play("moodyEyes_00");
				cosmetic.CharacterAnimation["moodyEyes_00"].weight = 1f;
				cosmetic.CharacterAnimation.Play("moodyEyes_00");
			}
			if (cosmetic.Student != null && cosmetic.Student.AoT)
			{
				cosmetic.Student.AttackOnTitan();
			}
			if (cosmetic.HomeScene)
			{
				cosmetic.Student.CharacterAnimation["idle_00"].time = 9f;
				cosmetic.Student.CharacterAnimation["idle_00"].speed = 0f;
				cosmetic.Hairstyle = 65;
			}
			if (!cosmetic.Eighties)
			{
				kkFZn2mLjt(int_0);
			}
			HaXZj2LJrN(int_0);
			if (!cosmetic.Male && cosmetic.StudentID != 90)
			{
				cosmetic.EyeTypeCheck();
			}
			if (cosmetic.Kidnapped)
			{
				cosmetic.WearIndoorShoes();
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00019ABC File Offset: 0x00017CBC
		private void kkFZn2mLjt(int int_0)
		{
			CosmeticScript cosmetic = baseStudentManager.Students[int_0].Cosmetic;
			if (cosmetic.StudentID == 37)
			{
				if (TaskGlobals.GetTaskStatus(37) < 3)
				{
					if (!cosmetic.TakingPortrait)
					{
						cosmetic.MaleAccessories[1].SetActive(value: false);
					}
					else
					{
						cosmetic.MaleAccessories[1].SetActive(value: true);
					}
				}
			}
			else if (cosmetic.StudentID == 11 && cosmetic.PhoneCharms.Length != 0)
			{
				if (TaskGlobals.GetTaskStatus(11) < 3)
				{
					cosmetic.PhoneCharms[11].SetActive(value: false);
				}
				else
				{
					cosmetic.PhoneCharms[11].SetActive(value: true);
				}
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00019B54 File Offset: 0x00017D54
		private void HaXZj2LJrN(int int_0)
		{
			CosmeticScript cosmetic = baseStudentManager.Students[int_0].Cosmetic;
			if (!cosmetic.TurnedOn && !cosmetic.TakingPortrait && cosmetic.Male)
			{
				if (cosmetic.Hairstyle != 46 && cosmetic.Hairstyle != 48 && cosmetic.Hairstyle != 49)
				{
					if ((cosmetic.Accessory <= 1 || cosmetic.Accessory >= 10) && cosmetic.Accessory != 13 && cosmetic.Accessory != 17)
					{
						if (cosmetic.Student.Persona == PersonaType.TeachersPet)
						{
							cosmetic.LoveManager.Targets[cosmetic.LoveManager.TotalTargets] = cosmetic.Student.Head;
							cosmetic.LoveManager.TotalTargets++;
						}
						else if (cosmetic.EyewearID > 0)
						{
							cosmetic.LoveManager.Targets[cosmetic.LoveManager.TotalTargets] = cosmetic.Student.Head;
							cosmetic.LoveManager.TotalTargets++;
						}
						else if (cosmetic.SkinColor == 8)
						{
							cosmetic.LoveManager.Targets[cosmetic.LoveManager.TotalTargets] = cosmetic.Student.Head;
							cosmetic.LoveManager.TotalTargets++;
						}
					}
					else
					{
						cosmetic.LoveManager.Targets[cosmetic.LoveManager.TotalTargets] = cosmetic.Student.Head;
						cosmetic.LoveManager.TotalTargets++;
					}
				}
				else
				{
					cosmetic.LoveManager.Targets[cosmetic.LoveManager.TotalTargets] = cosmetic.Student.Head;
					cosmetic.LoveManager.TotalTargets++;
				}
			}
			cosmetic.TurnedOn = true;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00019D34 File Offset: 0x00017F34
		public void yU9Z1mIPi0(int int_0)
		{
			StudentScript studentScript = baseStudentManager.Students[int_0];
			if (!studentScript.Teacher)
			{
				studentScript.MyLocker = studentScript.StudentManager.LockerPositions[studentScript.StudentID];
			}
			if (studentScript.Slave)
			{
				ScheduleBlock[] scheduleBlocks = studentScript.ScheduleBlocks;
				foreach (ScheduleBlock obj in scheduleBlocks)
				{
					obj.destination = "Slave";
					obj.action = "Slave";
				}
			}
			studentScript.ID = 1;
			while (studentScript.ID < ExtraJson.Students[studentScript.StudentID].ScheduleBlocks.Length)
			{
				ScheduleBlock scheduleBlock = studentScript.ScheduleBlocks[studentScript.ID];
				if (scheduleBlock.destination == "Locker")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.MyLocker;
				}
				else if (scheduleBlock.destination == "Seat")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.Seat;
				}
				else if (scheduleBlock.destination == "SocialSeat")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.SocialSeats[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "Podium")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Podiums.List[studentScript.Class];
				}
				else if (scheduleBlock.destination == "Exit")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Hangouts.List[0];
				}
				else if (scheduleBlock.destination == "Hangout")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Hangouts.List[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "Week1Hangout")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Week1Hangouts.List[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "Week2Hangout")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Week2Hangouts.List[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "Stairway")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Stairways.List[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "LunchSpot")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.LunchSpots.List[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "Slave")
				{
					if (!studentScript.FragileSlave)
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.SlaveSpot;
					}
					else
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.FragileSlaveSpot;
					}
				}
				else if (scheduleBlock.destination == "Patrol")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Patrols.List[studentScript.StudentID].GetChild(0);
					if ((studentScript.OriginalClub == ClubType.Gardening || studentScript.OriginalClub == ClubType.Occult) && studentScript.Club == ClubType.None)
					{
						Debug.Log("StudentScript student's club disbanded, so their destination has been set to ''Hangout''.");
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Hangouts.List[studentScript.StudentID];
					}
				}
				else if (scheduleBlock.destination == "Search Patrol")
				{
					studentScript.StudentManager.SearchPatrols.List[studentScript.Class].GetChild(0).position = studentScript.Seat.position + studentScript.Seat.forward;
					studentScript.StudentManager.SearchPatrols.List[studentScript.Class].GetChild(0).LookAt(studentScript.Seat);
					studentScript.StudentManager.StolenPhoneSpot.transform.position = studentScript.Seat.position + studentScript.Seat.forward * 0.4f;
					studentScript.StudentManager.StolenPhoneSpot.transform.position += Vector3.up;
					studentScript.StudentManager.StolenPhoneSpot.gameObject.SetActive(value: true);
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.SearchPatrols.List[studentScript.Class].GetChild(0);
				}
				else if (scheduleBlock.destination == "Graffiti")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.GraffitiSpots[studentScript.BullyID];
				}
				else if (scheduleBlock.destination == "Bully")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.BullySpots[studentScript.BullyID];
				}
				else if (scheduleBlock.destination == "Mourn")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.MournSpots[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "Clean")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.CleaningSpot.GetChild(0);
				}
				else if (scheduleBlock.destination == "ShameSpot")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.ShameSpot;
				}
				else if (scheduleBlock.destination == "Follow")
				{
					if (studentScript.FollowTarget != null)
					{
						studentScript.Destinations[studentScript.ID] = studentScript.FollowTarget.FollowTargetDestination;
					}
				}
				else if (scheduleBlock.destination == "Cuddle")
				{
					if (!studentScript.Male)
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.FemaleCoupleSpot;
					}
					else
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.MaleCoupleSpot;
					}
				}
				else if (scheduleBlock.destination == "Peek")
				{
					if (!studentScript.Male)
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.FemaleStalkSpot;
					}
					else
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.MaleStalkSpot;
					}
				}
				else if (scheduleBlock.destination == "Club")
				{
					if (studentScript.Club > ClubType.None)
					{
						if (studentScript.Club == ClubType.Sports)
						{
							studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Clubs.List[studentScript.StudentID].GetChild(0);
						}
						else
						{
							studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Clubs.List[studentScript.StudentID];
						}
					}
					else
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Hangouts.List[studentScript.StudentID];
					}
				}
				else if (scheduleBlock.destination == "Sulk")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.SulkSpots[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "Sleuth")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.SleuthTarget;
				}
				else if (scheduleBlock.destination == "Stalk")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StalkTarget;
					baseStudentManager.Students[studentScript.ID].StalkerFleeing = true;
					baseStudentManager.Students[studentScript.ID].SleuthTarget = baseStudentManager.Yandere.transform;
					baseStudentManager.Students[studentScript.ID].StalkTarget = baseStudentManager.Yandere.transform;
				}
				else if (scheduleBlock.destination == "Sunbathe")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.StrippingPositions[studentScript.GirlID];
				}
				else if (scheduleBlock.destination == "Shock")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.ShockedSpots[studentScript.StudentID - 80];
				}
				else if (scheduleBlock.destination == "Miyuki")
				{
					studentScript.ClubMemberID = studentScript.StudentID - 35;
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.MiyukiSpots[studentScript.ClubMemberID].transform;
				}
				else if (scheduleBlock.destination == "Practice")
				{
					if (studentScript.Club > ClubType.None)
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.PracticeSpots[studentScript.ClubMemberID];
					}
					else
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Hangouts.List[studentScript.StudentID];
					}
				}
				else if (scheduleBlock.destination == "Lyrics")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.LyricsSpot;
				}
				else if (scheduleBlock.destination == "Meeting")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.MeetingSpots[studentScript.StudentID].transform;
				}
				else if (scheduleBlock.destination == "InfirmaryBed")
				{
					if (studentScript.Male)
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.MaleRestSpots[studentScript.StudentManager.SedatedStudents];
						studentScript.StudentManager.SedatedStudents++;
					}
					else
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.FemaleRestSpots[studentScript.StudentManager.SedatedStudents];
						studentScript.StudentManager.SedatedStudents++;
					}
				}
				else if (scheduleBlock.destination == "InfirmarySeat")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.InfirmarySeat;
				}
				else if (scheduleBlock.destination == "Paint")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.FridaySpots[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "LockerRoom")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.MaleLockerRoomChangingSpot;
				}
				else if (scheduleBlock.destination == "LunchWitnessPosition")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.LunchWitnessPositions.List[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "Wait")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.WaitSpots[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "SleepSpot")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.SleepSpot;
				}
				else if (scheduleBlock.destination == "LightFire")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.PyroSpot;
				}
				else if (scheduleBlock.destination == "EightiesSpot")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.EightiesSpots.List[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "Perform")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.PerformSpots[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "PhotoShoot")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.PhotoShootSpots[studentScript.StudentID];
				}
				else if (scheduleBlock.destination == "Guard")
				{
					if (studentScript.StudentID == 20)
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.Students[1].transform;
					}
					else
					{
						studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.RivalGuardSpots[studentScript.StudentID].transform;
					}
				}
				else if (scheduleBlock.destination == "Random")
				{
					studentScript.Destinations[studentScript.ID] = studentScript.StudentManager.RandomSpots[studentScript.StudentID];
				}
				if (scheduleBlock.action == "Stand")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.AtLocker;
				}
				else if (scheduleBlock.action == "Socialize")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Socializing;
				}
				else if (scheduleBlock.action == "Game")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Gaming;
				}
				else if (scheduleBlock.action == "Slave")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Slave;
				}
				else if (scheduleBlock.action == "Relax")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Relax;
				}
				else if (scheduleBlock.action == "Sit")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.SitAndTakeNotes;
				}
				else if (scheduleBlock.action == "Peek")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Peek;
				}
				else if (scheduleBlock.action == "SocialSit")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.SitAndSocialize;
					if (studentScript.Persona == PersonaType.Sleuth && studentScript.Club == ClubType.None)
					{
						studentScript.Actions[studentScript.ID] = StudentActionType.Socializing;
					}
				}
				else if (scheduleBlock.action == "Eat")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.SitAndEatBento;
				}
				else if (scheduleBlock.action == "Shoes")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.ChangeShoes;
				}
				else if (scheduleBlock.action == "Grade")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.GradePapers;
				}
				else if (scheduleBlock.action == "Patrol")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Patrol;
					if (studentScript.OriginalClub == ClubType.Occult && studentScript.Club == ClubType.None)
					{
						Debug.Log("StudentScript student's club disbanded, so their action has been set to ''Socialize''.");
						studentScript.Actions[studentScript.ID] = StudentActionType.Socializing;
					}
				}
				else if (scheduleBlock.action == "Search Patrol")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.SearchPatrol;
				}
				else if (scheduleBlock.action == "Gossip")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Gossip;
				}
				else if (scheduleBlock.action == "Graffiti")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Graffiti;
				}
				else if (scheduleBlock.action == "Bully")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Bully;
				}
				else if (scheduleBlock.action == "Read")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Read;
				}
				else if (scheduleBlock.action == "Text")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Texting;
				}
				else if (scheduleBlock.action == "Mourn")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Mourn;
				}
				else if (scheduleBlock.action == "Cuddle")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Cuddle;
				}
				else if (scheduleBlock.action == "Teach")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Teaching;
				}
				else if (scheduleBlock.action == "Wait")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Wait;
				}
				else if (scheduleBlock.action == "Clean")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Clean;
				}
				else if (scheduleBlock.action == "Shamed")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Shamed;
				}
				else if (scheduleBlock.action == "Follow")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Follow;
				}
				else if (scheduleBlock.action == "Sulk")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Sulk;
				}
				else if (scheduleBlock.action == "Sleuth")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Sleuth;
				}
				else if (scheduleBlock.action == "Stalk")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Stalk;
				}
				else if (scheduleBlock.action == "Sketch")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Sketch;
				}
				else if (scheduleBlock.action == "Sunbathe")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Sunbathe;
				}
				else if (scheduleBlock.action == "Shock")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Shock;
				}
				else if (scheduleBlock.action == "Miyuki")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Miyuki;
				}
				else if (scheduleBlock.action == "Meeting")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Meeting;
				}
				else if (scheduleBlock.action == "Lyrics")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Lyrics;
				}
				else if (scheduleBlock.action == "Practice")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Practice;
				}
				else if (scheduleBlock.action == "Sew")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Sew;
				}
				else if (scheduleBlock.action == "Paint")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Paint;
				}
				else if (scheduleBlock.action == "UpdateAppearance")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.UpdateAppearance;
				}
				else if (scheduleBlock.action == "LightCig")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.LightCig;
				}
				else if (scheduleBlock.action == "PlaceBag")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.PlaceBag;
				}
				else if (scheduleBlock.action == "Sleep")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Sleep;
				}
				else if (scheduleBlock.action == "LightFire")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.LightFire;
				}
				else if (scheduleBlock.action == "Jog")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Jog;
				}
				else if (scheduleBlock.action == "PrepareFood")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.PrepareFood;
				}
				else if (scheduleBlock.action == "Perform")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Perform;
				}
				else if (scheduleBlock.action == "PhotoShoot")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.PhotoShoot;
				}
				else if (scheduleBlock.action == "GravurePose")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.GravurePose;
				}
				else if (scheduleBlock.action == "Guard")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.Guard;
				}
				else if (scheduleBlock.action == "Random")
				{
					studentScript.Actions[studentScript.ID] = StudentActionType.HelpTeacher;
				}
				else if (scheduleBlock.action == "Club")
				{
					if (studentScript.Club > ClubType.None)
					{
						studentScript.Actions[studentScript.ID] = StudentActionType.ClubAction;
					}
					else if (studentScript.OriginalClub == ClubType.Art)
					{
						studentScript.Actions[studentScript.ID] = StudentActionType.Sketch;
					}
					else
					{
						studentScript.Actions[studentScript.ID] = StudentActionType.Socializing;
					}
				}
				studentScript.ID++;
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0001B234 File Offset: 0x00019434
		public void PkfZp95Yps()
		{
			for (int i = 101; i < baseStudentManager.Students.Length; i++)
			{
				if (baseStudentManager.Students[i] != null)
				{
					AwoZaEUto9();
				}
				else
				{
					baseStudentManager.SkipTo8();
				}
			}
			for (int j = 1; j < baseStudentManager.Students.Length; j++)
			{
				StudentScript studentScript = baseStudentManager.Students[j];
				if (studentScript != null && studentScript.StudentID < 90)
				{
					studentScript.ShoeRemoval.RightCurrentShoe.gameObject.SetActive(value: true);
					studentScript.ShoeRemoval.LeftCurrentShoe.gameObject.SetActive(value: true);
					Debug.Log("I'm enabling all shoes again.!");
				}
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0001B2F4 File Offset: 0x000194F4
		public void AwoZaEUto9()
		{
			while (baseStudentManager.NPCsSpawned < baseStudentManager.NPCsTotal)
			{
				baseStudentManager.SpawnStudent(baseStudentManager.SpawnID);
				baseStudentManager.SpawnID++;
			}
			int num = 0;
			int num2 = 0;
			baseStudentManager.ID = 1;
			while (baseStudentManager.ID < baseStudentManager.Students.Length)
			{
				StudentScript studentScript = baseStudentManager.Students[baseStudentManager.ID];
				if (studentScript != null && studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil)
				{
					if (!studentScript.Started)
					{
						studentScript.Start();
					}
					bool flag = false;
					if (zKdZFEmssX.enabled && studentScript.Teacher)
					{
						flag = true;
						studentScript.Teacher = false;
					}
					if (!studentScript.Teacher)
					{
						if (!studentScript.Indoors)
						{
							if (studentScript.ShoeRemoval.Locker == null)
							{
								studentScript.ShoeRemoval.Start();
							}
							studentScript.ShoeRemoval.PutOnShoes();
						}
						studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
						studentScript.transform.rotation = studentScript.Seat.rotation;
						if (studentScript.StudentID == 10 && baseStudentManager.Students[11] != null)
						{
							studentScript.transform.position = baseStudentManager.Students[11].transform.position;
						}
						Physics.SyncTransforms();
						studentScript.Pathfinding.canSearch = true;
						studentScript.Pathfinding.canMove = true;
						studentScript.Pathfinding.speed = 1f;
						studentScript.ClubActivityPhase = 0;
						studentScript.Distracted = false;
						studentScript.Spawned = true;
						studentScript.Routine = true;
						studentScript.Safe = false;
						studentScript.SprintAnim = studentScript.OriginalSprintAnim;
						if (studentScript.ClubAttire)
						{
							studentScript.ChangeSchoolwear();
							studentScript.ClubAttire = true;
						}
						if (studentScript.StudentID < 101)
						{
							studentScript.TeleportToDestination();
							studentScript.TeleportToDestination();
						}
						else
						{
							se6ZTZM05J(studentScript.StudentID);
							se6ZTZM05J(studentScript.StudentID);
						}
					}
					else if (studentScript.StudentID < 101)
					{
						studentScript.TeleportToDestination();
						studentScript.TeleportToDestination();
					}
					else
					{
						se6ZTZM05J(studentScript.StudentID);
						se6ZTZM05J(studentScript.StudentID);
					}
					if (zKdZFEmssX.enabled)
					{
						if (flag)
						{
							studentScript.Teacher = true;
						}
						if (studentScript.Persona == PersonaType.PhoneAddict)
						{
							studentScript.SmartPhone.SetActive(value: true);
						}
						if (studentScript.Actions[studentScript.Phase] == StudentActionType.Graffiti && !baseStudentManager.Bully)
						{
							ScheduleBlock obj = studentScript.ScheduleBlocks[2];
							obj.destination = "Patrol";
							obj.action = "Patrol";
							if (studentScript.StudentID < 101)
							{
								studentScript.GetDestinations();
							}
							else
							{
								yU9Z1mIPi0(studentScript.StudentID);
							}
						}
						studentScript.SpeechLines.Stop();
						studentScript.transform.position = new Vector3(20f + (float)num * 1.1f, 0f, 82 - num2 * 5);
						num2++;
						if (num2 > 4)
						{
							num++;
							num2 = 0;
						}
					}
				}
				baseStudentManager.ID++;
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0001B65C File Offset: 0x0001985C
		public void se6ZTZM05J(int int_0)
		{
			StudentScript studentScript = baseStudentManager.Students[int_0];
			yU9Z1mIPi0(int_0);
			if (studentScript.Phase < studentScript.ScheduleBlocks.Length && studentScript.Clock.HourTime >= studentScript.ScheduleBlocks[studentScript.Phase].time)
			{
				studentScript.Phase++;
				if (studentScript.Actions[studentScript.Phase] == StudentActionType.Patrol)
				{
					studentScript.CurrentDestination = studentScript.StudentManager.Patrols.List[studentScript.StudentID].GetChild(studentScript.PatrolID);
					studentScript.Pathfinding.target = studentScript.CurrentDestination;
				}
				else
				{
					studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
					studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
				}
				base.transform.position = studentScript.CurrentDestination.position;
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0001B750 File Offset: 0x00019950
		public void c5hZUFbXgl(int int_0)
		{
			StudentScript studentScript = baseStudentManager.Students[int_0];
			studentScript.GetDestinations();
			if (studentScript.Phase < studentScript.ScheduleBlocks.Length && studentScript.Clock.HourTime >= studentScript.ScheduleBlocks[studentScript.Phase].time)
			{
				studentScript.Phase++;
				if (studentScript.Actions[studentScript.Phase] == StudentActionType.Patrol)
				{
					studentScript.CurrentDestination = studentScript.StudentManager.Patrols.List[studentScript.StudentID].GetChild(studentScript.PatrolID);
					studentScript.Pathfinding.target = studentScript.CurrentDestination;
				}
				else
				{
					studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
					studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
				}
				base.transform.position = studentScript.CurrentDestination.position;
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000025D5 File Offset: 0x000007D5
		public void ojJZe5g7yv()
		{
			RandomizeRoutines();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0001B844 File Offset: 0x00019A44
		public void RandomizeRoutines()
		{
			baseStudentManager.ID = 100;
			while (baseStudentManager.ID < StudentLimit)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(baseStudentManager.EmptyObject, baseStudentManager.transform.position, Quaternion.identity);
				baseStudentManager.RandomSpots[baseStudentManager.ID] = gameObject.transform;
				gameObject.transform.position = baseStudentManager.PossibleRandomSpots[UnityEngine.Random.Range(1, 11)].position;
				baseStudentManager.ID++;
			}
			baseStudentManager.ID = 100;
			while (baseStudentManager.ID < StudentLimit)
			{
				StudentScript studentScript = baseStudentManager.Students[baseStudentManager.ID];
				if (studentScript != null)
				{
					studentScript.Indoors = true;
					studentScript.Spawned = true;
					studentScript.Calm = true;
					if (studentScript.ShoeRemoval.Locker == null && !studentScript.Teacher)
					{
						studentScript.ShoeRemoval.Start();
						studentScript.ShoeRemoval.PutOnShoes();
					}
					ScheduleBlock obj = studentScript.ScheduleBlocks[0];
					obj.destination = "Random";
					obj.action = "Random";
					ScheduleBlock obj2 = studentScript.ScheduleBlocks[1];
					obj2.destination = "Random";
					obj2.action = "Random";
					ScheduleBlock obj3 = studentScript.ScheduleBlocks[2];
					obj3.destination = "Random";
					obj3.action = "Random";
					ScheduleBlock obj4 = studentScript.ScheduleBlocks[3];
					obj4.destination = "Random";
					obj4.action = "Random";
					ScheduleBlock obj5 = studentScript.ScheduleBlocks[4];
					obj5.destination = "Random";
					obj5.action = "Random";
					ScheduleBlock obj6 = studentScript.ScheduleBlocks[5];
					obj6.destination = "Random";
					obj6.action = "Random";
					if (studentScript.StudentID < 101)
					{
						studentScript.GetDestinations();
					}
					else
					{
						yU9Z1mIPi0(studentScript.StudentID);
					}
					studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
					studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
					studentScript.CurrentAction = StudentActionType.HelpTeacher;
					baseStudentManager.Students[baseStudentManager.ID].transform.position = baseStudentManager.PossibleRandomSpots[UnityEngine.Random.Range(1, 11)].position;
					Physics.SyncTransforms();
				}
				baseStudentManager.ID++;
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0001BAD4 File Offset: 0x00019CD4
		public void InitializeReputations()
		{
			baseStudentManager.ReputationSetter.InitializeReputations();
			for (int i = 101; i < baseStudentManager.Students.Length; i++)
			{
				if (baseStudentManager.Students[i] != null)
				{
					Vector3 reputationTriangle = StudentGlobals.GetReputationTriangle(i);
					reputationTriangle.x *= 0.33333f;
					reputationTriangle.y *= 0.33333f;
					reputationTriangle.z *= 0.33333f;
					StudentGlobals.SetStudentReputation(i, Mathf.RoundToInt(reputationTriangle.x + reputationTriangle.y + reputationTriangle.z));
					baseStudentManager.StudentReps[i] = StudentGlobals.GetStudentReputation(i);
				}
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0001BB90 File Offset: 0x00019D90
		public void dTLZIdx6vH(float float_0)
		{
			StudentScript[] students = baseStudentManager.Students;
			foreach (StudentScript studentScript in students)
			{
				if (!(studentScript != null) || studentScript.StudentID <= 1)
				{
					continue;
				}
				if (studentScript.MyRenderer != null)
				{
					studentScript.MyRenderer.materials[0].color = new Color(1f - float_0, 1f - float_0, 1f - float_0, 1f);
					studentScript.MyRenderer.materials[1].color = new Color(1f - float_0, 1f - float_0, 1f - float_0, 1f);
					if (studentScript.MyRenderer.materials.Length > 2)
					{
						studentScript.MyRenderer.materials[2].color = new Color(1f - float_0, 1f - float_0, 1f - float_0, 1f);
					}
				}
				if (studentScript.Cosmetic.Hairstyle == 1)
				{
					if (baseStudentManager.Yandere.Sanity > 33.27f)
					{
						if (studentScript.StudentID > 100)
						{
							CosmeticStartOverride(studentScript.StudentID);
							CosmeticStartOverride(studentScript.StudentID);
						}
					}
					else
					{
						SetHairColor(studentScript, float_0, 0f, 0f, 0f, bool_0: true);
						SetEyeColor(studentScript, float_0, 0f, 0f, 0f, bool_0: true);
					}
				}
				else
				{
					SetHairColor(studentScript, float_0, 0f, 0f, 0f, bool_0: true);
					SetEyeColor(studentScript, float_0, 0f, 0f, 0f, bool_0: true);
				}
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0001BD38 File Offset: 0x00019F38
		private void SetHairColor(StudentScript studentScript_0, float float_0, float float_1, float float_2, float float_3, bool bool_0)
		{
			if (studentScript_0.Cosmetic.HairRenderer != null)
			{
				if (bool_0)
				{
					studentScript_0.Cosmetic.HairRenderer.material.color = new Color(1f - float_0, 1f - float_0, 1f - float_0, 1f);
				}
				else
				{
					studentScript_0.Cosmetic.HairRenderer.material.color = new Color(float_1, float_2, float_3, 1f);
				}
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0001BDB8 File Offset: 0x00019FB8
		private void SetEyeColor(StudentScript studentScript_0, float float_0, float float_1, float float_2, float float_3, bool bool_0)
		{
			if (bool_0)
			{
				studentScript_0.Cosmetic.LeftEyeRenderer.material.color = new Color(1f - float_0, 1f - float_0, 1f - float_0, 1f);
				studentScript_0.Cosmetic.RightEyeRenderer.material.color = new Color(1f - float_0, 1f - float_0, 1f - float_0, 1f);
			}
			else
			{
				studentScript_0.Cosmetic.LeftEyeRenderer.material.color = new Color(float_1, float_2, float_3, 1f);
				studentScript_0.Cosmetic.RightEyeRenderer.material.color = new Color(float_1, float_2, float_3, 1f);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0001BE7C File Offset: 0x0001A07C
		private void GarbageMode()
		{
			for (j0mv4DAaux = 1; j0mv4DAaux < baseStudentManager.Students.Length; j0mv4DAaux++)
			{
				if (baseStudentManager.Students[j0mv4DAaux] != null && baseStudentManager.Students[j0mv4DAaux].gameObject.activeInHierarchy)
				{
					baseStudentManager.Students[j0mv4DAaux].Cosmetic.HairRenderer.gameObject.SetActive(value: false);
					baseStudentManager.Students[j0mv4DAaux].MyRenderer.enabled = false;
					baseStudentManager.Students[j0mv4DAaux].GarbageBag.SetActive(value: true);
				}
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0001BF54 File Offset: 0x0001A154
		private void xxtZiXxK0Y()
		{
			for (j0mv4DAaux = 1; j0mv4DAaux < baseStudentManager.Students.Length; j0mv4DAaux++)
			{
				if (baseStudentManager.Students[j0mv4DAaux] != null && baseStudentManager.Students[j0mv4DAaux].gameObject.activeInHierarchy)
				{
					baseStudentManager.DisableStudent(j0mv4DAaux);
				}
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000025DD File Offset: 0x000007DD
		private void htEZXeIsC6()
		{
			for (j0mv4DAaux = 1; j0mv4DAaux < StudentLimit; j0mv4DAaux++)
			{
				StudentGlobals.SetStudentPhotographed(j0mv4DAaux, value: true);
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002610 File Offset: 0x00000810
		private IEnumerator WtCZkerfot()
		{
			for (;;)
			{
				if (!ASJvZ8DPwN[0] && baseStudentManager.AoT && baseStudentManager.Yandere.Egg)
				{
					ojJZe5g7yv();
					ASJvZ8DPwN[0] = true;
				}
				if (!ASJvZ8DPwN[1] && baseStudentManager.Yandere.GarbageBag.activeInHierarchy)
				{
					GarbageMode();
					ASJvZ8DPwN[1] = true;
				}
				if (!ASJvZ8DPwN[2] && baseStudentManager.Clock.Horror && baseStudentManager.Yandere.Egg)
				{
					xxtZiXxK0Y();
					ASJvZ8DPwN[2] = true;
				}
				if (!ASJvZ8DPwN[3] && baseStudentManager.Yandere.LifeNotebook.activeInHierarchy && baseStudentManager.Yandere.Egg)
				{
					htEZXeIsC6();
					ASJvZ8DPwN[3] = true;
				}
				if (mKRv8nGMF0)
				{
					baseStudentManager.CanSelfReport = false;
					for (int i = 90; i < baseStudentManager.Students.Length; i++)
					{
						M2sZAUUgDW(baseStudentManager.Students[i]);
						dF0ZuJPp8M(i);
					}
				}
				yield return new WaitForSeconds(0.25f);
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0001BFD8 File Offset: 0x0001A1D8
		public void wn5ZsJhPfO()
		{
			for (int i = 2; i < baseStudentManager.Students.Length; i++)
			{
				StudentScript studentScript = baseStudentManager.Students[i];
				if (studentScript != null && (studentScript.gameObject.activeInHierarchy || studentScript.Hurry) && !studentScript.Safe && !studentScript.Slave && studentScript.Teacher)
				{
					M2sZAUUgDW(studentScript);
				}
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0001C048 File Offset: 0x0001A248
		public void zovZPdnYM7(int int_0)
		{
			if (int_0 > 1)
			{
				StudentScript studentScript = baseStudentManager.Students[int_0];
				if (studentScript != null && !studentScript.Safe && !studentScript.FightingSlave && studentScript.Teacher)
				{
					M2sZAUUgDW(studentScript);
				}
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0001C090 File Offset: 0x0001A290
		public void M2sZAUUgDW(StudentScript studentScript_0)
		{
			if (baseStudentManager.Yandere.Bloodiness == 0f && (double)baseStudentManager.Yandere.Sanity > 66.66666 && !baseStudentManager.Yandere.StudentManager.WitnessCamera.Show && baseStudentManager.Yandere.StudentManager.ChaseCamera == null && !baseStudentManager.MurderTakingPlace)
			{
				if (baseStudentManager.Police.Corpses <= 0 && baseStudentManager.Police.LimbParent.childCount <= 0 && baseStudentManager.Police.BloodParent.childCount <= 0 && baseStudentManager.Police.BloodyClothing <= 0 && baseStudentManager.Police.BloodyWeapons <= 0)
				{
					vtfvC59yST = false;
				}
				else
				{
					vtfvC59yST = true;
				}
			}
			else
			{
				vtfvC59yST = false;
			}
			if (studentScript_0 != null && studentScript_0.Teacher)
			{
				if (vtfvC59yST)
				{
					studentScript_0.Prompt.HideButton[0] = false;
					studentScript_0.Prompt.Label[0].text = "     Report Blood/Corpse";
				}
				else
				{
					studentScript_0.Prompt.HideButton[0] = true;
				}
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0001C1F4 File Offset: 0x0001A3F4
		public void dF0ZuJPp8M(int int_0)
		{
			Debug.Log("New UpdateTalkInput running.");
			StudentScript studentScript = baseStudentManager.Students[int_0];
			if (!(studentScript != null) || !(studentScript.Prompt.Circle[0].fillAmount <= 0.3f) || !(studentScript.Prompt.Circle[0].fillAmount <= 0.3f))
			{
				return;
			}
			bool flag = false;
			if (studentScript.Yandere.PickUp != null && studentScript.Yandere.PickUp.Salty && !studentScript.Indoors)
			{
				flag = true;
			}
			bool flag2 = false;
			if (studentScript.Teacher && vtfvC59yST)
			{
				flag2 = true;
			}
			if (studentScript.StudentManager.Pose)
			{
				studentScript.MyController.enabled = false;
				studentScript.Pathfinding.canSearch = false;
				studentScript.Pathfinding.canMove = false;
				studentScript.Stop = true;
				jwAZyvk9FW(studentScript);
				return;
			}
			if (studentScript.BadTime)
			{
				studentScript.Yandere.EmptyHands();
				studentScript.BecomeRagdoll();
				studentScript.Yandere.RagdollPK.connectedBody = studentScript.Ragdoll.AllRigidbodies[5];
				studentScript.Yandere.RagdollPK.connectedAnchor = studentScript.Ragdoll.LimbAnchor[4];
				studentScript.DialogueWheel.PromptBar.ClearButtons();
				studentScript.DialogueWheel.PromptBar.Label[1].text = "Back";
				studentScript.DialogueWheel.PromptBar.UpdateButtons();
				studentScript.DialogueWheel.PromptBar.Show = true;
				studentScript.Yandere.Ragdoll = studentScript.Ragdoll.gameObject;
				studentScript.Yandere.SansEyes[0].SetActive(value: true);
				studentScript.Yandere.SansEyes[1].SetActive(value: true);
				studentScript.Yandere.GlowEffect.Play();
				studentScript.Yandere.CanMove = false;
				studentScript.Yandere.PK = true;
				studentScript.DeathType = DeathType.EasterEgg;
				return;
			}
			if (studentScript.StudentManager.Six)
			{
				UnityEngine.Object.Instantiate(studentScript.AlarmDisc, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity).GetComponent<AlarmDiscScript>().Originator = studentScript;
				AudioSource.PlayClipAtPoint(studentScript.Yandere.SixTakedown, base.transform.position);
				AudioSource.PlayClipAtPoint(studentScript.Yandere.Snarls[UnityEngine.Random.Range(0, studentScript.Yandere.Snarls.Length)], base.transform.position);
				studentScript.Yandere.CharacterAnimation.CrossFade("f02_sixEat_00");
				studentScript.Yandere.TargetStudent = studentScript;
				studentScript.Yandere.FollowHips = true;
				studentScript.Yandere.Attacking = true;
				studentScript.Yandere.CanMove = false;
				studentScript.Yandere.Eating = true;
				studentScript.CharacterAnimation.CrossFade(studentScript.EatVictimAnim);
				studentScript.CharacterAnimation[studentScript.WetAnim].weight = 0f;
				studentScript.Pathfinding.enabled = false;
				studentScript.Routine = false;
				studentScript.Dying = true;
				studentScript.Eaten = true;
				GameObject gameObject = UnityEngine.Object.Instantiate(studentScript.EmptyGameObject, base.transform.position, Quaternion.identity);
				studentScript.Yandere.SixTarget = gameObject.transform;
				studentScript.Yandere.SixTarget.LookAt(studentScript.Yandere.transform.position);
				studentScript.Yandere.SixTarget.Translate(studentScript.Yandere.SixTarget.forward);
				return;
			}
			if (studentScript.Yandere.SpiderGrow)
			{
				if (!studentScript.Eaten && !studentScript.Cosmetic.Empty)
				{
					AudioSource.PlayClipAtPoint(studentScript.Yandere.SixTakedown, base.transform.position);
					AudioSource.PlayClipAtPoint(studentScript.Yandere.Snarls[UnityEngine.Random.Range(0, studentScript.Yandere.Snarls.Length)], base.transform.position);
					GameObject obj = UnityEngine.Object.Instantiate(studentScript.Yandere.EmptyHusk, base.transform.position + base.transform.forward * 0.5f, Quaternion.identity);
					obj.GetComponent<EmptyHuskScript>().TargetStudent = studentScript;
					obj.transform.LookAt(base.transform.position);
					studentScript.CharacterAnimation.CrossFade(studentScript.EatVictimAnim);
					studentScript.CharacterAnimation[studentScript.WetAnim].weight = 0f;
					studentScript.Pathfinding.enabled = false;
					studentScript.Distracted = false;
					studentScript.Routine = false;
					studentScript.Dying = true;
					studentScript.Eaten = true;
					if (studentScript.Investigating)
					{
						studentScript.StopInvestigating();
					}
					if (studentScript.Following)
					{
						studentScript.FollowCountdown.gameObject.SetActive(value: false);
						studentScript.Yandere.Follower = null;
						studentScript.Yandere.Followers--;
						studentScript.Following = false;
					}
					UnityEngine.Object.Instantiate(studentScript.EmptyGameObject, base.transform.position, Quaternion.identity);
				}
				return;
			}
			if (studentScript.StudentManager.Gaze)
			{
				studentScript.Yandere.CharacterAnimation.CrossFade("f02_gazerPoint_00");
				studentScript.Yandere.GazerEyes.Attacking = true;
				studentScript.Yandere.TargetStudent = studentScript;
				studentScript.Yandere.GazeAttacking = true;
				studentScript.Yandere.CanMove = false;
				studentScript.Routine = false;
				return;
			}
			if (studentScript.Slave)
			{
				studentScript.Prompt.Circle[0].fillAmount = 1f;
				studentScript.Yandere.TargetStudent = studentScript;
				studentScript.Yandere.PauseScreen.StudentInfoMenu.Targeting = true;
				studentScript.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(value: true);
				studentScript.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
				studentScript.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
				studentScript.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
				StartCoroutine(studentScript.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
				studentScript.Yandere.PauseScreen.MainMenu.SetActive(value: false);
				studentScript.Yandere.PauseScreen.Panel.enabled = true;
				studentScript.Yandere.PauseScreen.Sideways = true;
				studentScript.Yandere.PauseScreen.Show = true;
				Time.timeScale = 0.0001f;
				studentScript.Yandere.PromptBar.ClearButtons();
				studentScript.Yandere.PromptBar.Label[1].text = "Cancel";
				studentScript.Yandere.PromptBar.UpdateButtons();
				studentScript.Yandere.PromptBar.Show = true;
				return;
			}
			if (studentScript.FightingSlave)
			{
				studentScript.Yandere.CharacterAnimation.CrossFade("f02_subtleStab_00");
				studentScript.Yandere.SubtleStabbing = true;
				studentScript.Yandere.TargetStudent = studentScript;
				studentScript.Yandere.CanMove = false;
				return;
			}
			if (studentScript.Following)
			{
				studentScript.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
				studentScript.Prompt.Label[0].text = "     Talk";
				studentScript.Prompt.Circle[0].fillAmount = 1f;
				ParticleSystem.EmissionModule emission = studentScript.Hearts.emission;
				emission.enabled = false;
				studentScript.FollowCountdown.gameObject.SetActive(value: false);
				studentScript.Yandere.Follower = null;
				studentScript.Yandere.Followers--;
				studentScript.Following = false;
				studentScript.Routine = true;
				studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
				studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
				studentScript.Pathfinding.canSearch = true;
				studentScript.Pathfinding.canMove = true;
				studentScript.Pathfinding.speed = studentScript.WalkSpeed;
				return;
			}
			if ((studentScript.Clock.Period == 2 && !flag2) || (studentScript.Clock.Period == 4 && !flag2) || (studentScript.StudentID < 90 && studentScript.CurrentDestination == studentScript.Seat))
			{
				Debug.Log("This character won't talk because Class is in session, or because their destination is ''seat''.");
				if (studentScript.Club != ClubType.Delinquent)
				{
					studentScript.Subtitle.UpdateLabel(SubtitleType.ClassApology, 0, 3f);
				}
				else
				{
					studentScript.Subtitle.UpdateLabel(SubtitleType.DelinquentAnnoy, UnityEngine.Random.Range(0, studentScript.Subtitle.DelinquentAnnoyClips.Length), 3f);
				}
				studentScript.Prompt.Circle[0].fillAmount = 1f;
				return;
			}
			if (!(studentScript.InEvent || !studentScript.CanTalk || studentScript.GoAway || studentScript.Fleeing || (studentScript.Meeting && !studentScript.Drownable) || studentScript.Wet || studentScript.TurnOffRadio || studentScript.InvestigatingBloodPool || (studentScript.MyPlate != null && studentScript.MyPlate.parent == studentScript.RightHand) || flag) && !studentScript.ReturningMisplacedWeapon && studentScript.Actions[studentScript.Phase] != StudentActionType.Bully && studentScript.Actions[studentScript.Phase] != StudentActionType.Graffiti && (!studentScript.CanTakeSnack || !(studentScript.IgnoreFoodTimer > 0f)) && (studentScript.StudentManager.Eighties || studentScript.StudentID != 12) && (!studentScript.Rival || studentScript.Indoors) && (!(studentScript.FollowTarget != null) || !studentScript.FollowTarget.InEvent))
			{
				if (studentScript.Clock.Period == 3 && studentScript.BusyAtLunch)
				{
					studentScript.Subtitle.UpdateLabel(SubtitleType.SadApology, 1, 3f);
					studentScript.Prompt.Circle[0].fillAmount = 1f;
				}
				else if (studentScript.Warned)
				{
					Debug.Log("This character refuses to speak to Yandere-chan because of a grudge.");
					studentScript.Subtitle.UpdateLabel(SubtitleType.GrudgeRefusal, 0, 3f);
					studentScript.Prompt.Circle[0].fillAmount = 1f;
					if (!studentScript.Male)
					{
						studentScript.CharacterAnimation["f02_smile_00"].weight = 0f;
					}
				}
				else if (studentScript.Ignoring)
				{
					studentScript.Subtitle.UpdateLabel(SubtitleType.PhotoAnnoyance, 0, 3f);
					studentScript.Prompt.Circle[0].fillAmount = 1f;
				}
				else if (studentScript.Yandere.PickUp != null && studentScript.Yandere.PickUp.PuzzleCube)
				{
					if (studentScript.Investigating)
					{
						studentScript.StopInvestigating();
					}
					studentScript.EmptyHands();
					studentScript.Prompt.Circle[0].fillAmount = 1f;
					studentScript.PuzzleCube = studentScript.Yandere.PickUp;
					studentScript.Yandere.EmptyHands();
					studentScript.PuzzleCube.enabled = false;
					studentScript.PuzzleCube.Prompt.Hide();
					studentScript.PuzzleCube.Prompt.enabled = false;
					studentScript.PuzzleCube.MyRigidbody.useGravity = false;
					studentScript.PuzzleCube.MyRigidbody.isKinematic = true;
					studentScript.PuzzleCube.gameObject.transform.parent = studentScript.RightHand;
					studentScript.PuzzleCube.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
					studentScript.PuzzleCube.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					if (studentScript.Male)
					{
						studentScript.PuzzleCube.gameObject.transform.localPosition = new Vector3(0f, -0.0466666f, 0f);
						studentScript.PuzzleCube.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
					}
					else
					{
						studentScript.PuzzleCube.gameObject.transform.localPosition = new Vector3(0f, -0.0266666f, 0f);
						studentScript.PuzzleCube.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
					}
					studentScript.Pathfinding.canSearch = false;
					studentScript.Pathfinding.canMove = false;
					studentScript.SolvingPuzzle = true;
					studentScript.Distracted = true;
					studentScript.Routine = false;
				}
				else if (studentScript.Actions[studentScript.Phase] == StudentActionType.LightFire)
				{
					studentScript.Yandere.NotificationManager.CustomText = "She doesn't seem to notice you...";
					studentScript.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					studentScript.Prompt.Circle[0].fillAmount = 1f;
				}
				else
				{
					bool flag3 = false;
					if (studentScript.Yandere.Bloodiness + (float)studentScript.Yandere.GloveBlood > 0f && !studentScript.Yandere.Paint)
					{
						flag3 = true;
					}
					if (!studentScript.Witness && flag3)
					{
						studentScript.Prompt.Circle[0].fillAmount = 1f;
						studentScript.YandereVisible = true;
						studentScript.Alarm = 200f;
					}
					else if (!studentScript.Grudge && studentScript.Teacher && vtfvC59yST)
					{
						Debug.Log("The player has just reported blood/murder to the faculty.");
						baseStudentManager.Reputation.UpdateRep();
						baseStudentManager.Police.SelfReported = true;
						baseStudentManager.Reputation.Portal.EndDay();
					}
				}
				return;
			}
			if (!studentScript.StudentManager.Eighties && studentScript.StudentID == 10 && TaskGlobals.GetTaskStatus(46) == 1)
			{
				Debug.Log("The game thinks that the current period is: " + studentScript.Clock.Period);
				if (studentScript.Clock.Period == 3 || studentScript.Clock.Period == 5)
				{
					studentScript.Yandere.NotificationManager.CustomText = "Martial Arts Club is not training now";
					studentScript.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			studentScript.Subtitle.UpdateLabel(SubtitleType.EventApology, 1, 3f);
			studentScript.Prompt.Circle[0].fillAmount = 1f;
			studentScript.StudentManager.UpdateMe(studentScript.StudentID);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0001D09C File Offset: 0x0001B29C
		public void jwAZyvk9FW(StudentScript studentScript_0)
		{
			baseStudentManager.PoseMode.ChoosingAction = true;
			baseStudentManager.PoseMode.Panel.enabled = true;
			baseStudentManager.PoseMode.Student = studentScript_0;
			baseStudentManager.PoseMode.UpdateLabels();
			baseStudentManager.PoseMode.Show = true;
			studentScript_0.DialogueWheel.PromptBar.ClearButtons();
			studentScript_0.DialogueWheel.PromptBar.Label[0].text = "Confirm";
			studentScript_0.DialogueWheel.PromptBar.Label[1].text = "Back";
			studentScript_0.DialogueWheel.PromptBar.Label[4].text = "Change";
			studentScript_0.DialogueWheel.PromptBar.Label[5].text = "Increase/Decrease";
			studentScript_0.DialogueWheel.PromptBar.UpdateButtons();
			studentScript_0.DialogueWheel.PromptBar.Show = true;
			studentScript_0.Yandere.Character.GetComponent<Animation>().CrossFade(studentScript_0.Yandere.IdleAnim);
			studentScript_0.Yandere.CanMove = false;
			studentScript_0.Posing = true;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000025C4 File Offset: 0x000007C4
		public void JwEZWJIcj5()
		{
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0001D1D8 File Offset: 0x0001B3D8
		public void gmxZdlqosX()
		{
			for (int i = 101; i < baseStudentManager.Students.Length; i++)
			{
				if (baseStudentManager.Students[i] != null)
				{
					baseStudentManager.Students[i].SavePositionX = baseStudentManager.Students[i].transform.position.x;
					baseStudentManager.Students[i].SavePositionY = baseStudentManager.Students[i].transform.position.y;
					baseStudentManager.Students[i].SavePositionZ = baseStudentManager.Students[i].transform.position.z;
				}
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0001D2A8 File Offset: 0x0001B4A8
		public void YBNZwIpjas()
		{
			for (int i = 101; i < baseStudentManager.Students.Length; i++)
			{
				if (!(baseStudentManager.Students[i] != null))
				{
					continue;
				}
				baseStudentManager.Students[i].Interaction = StudentInteractionType.Idle;
				baseStudentManager.Students[i].WaitTimer = 1f;
				if (baseStudentManager.Students[i].enabled)
				{
					baseStudentManager.Students[i].CurrentDestination = baseStudentManager.Students[i].Destinations[baseStudentManager.Students[i].Phase];
					baseStudentManager.Students[i].Pathfinding.target = baseStudentManager.Students[i].Destinations[baseStudentManager.Students[i].Phase];
					if (baseStudentManager.Students[i].Actions[baseStudentManager.Students[i].Phase] == StudentActionType.Clean)
					{
						baseStudentManager.Students[i].EquipCleaningItems();
					}
					else if (baseStudentManager.Students[i].Actions[baseStudentManager.Students[i].Phase] != StudentActionType.Patrol && (baseStudentManager.Students[i].Actions[baseStudentManager.Students[i].Phase] != StudentActionType.ClubAction || baseStudentManager.Students[i].Club != ClubType.Gardening))
					{
						if (baseStudentManager.Students[i].Actions[baseStudentManager.Students[i].Phase] == StudentActionType.Sleuth)
						{
							baseStudentManager.Students[i].CurrentDestination = baseStudentManager.Students[i].SleuthTarget;
							baseStudentManager.Students[i].Pathfinding.target = baseStudentManager.Students[i].SleuthTarget;
						}
						else if (baseStudentManager.Students[i].Actions[baseStudentManager.Students[i].Phase] == StudentActionType.Sunbathe && baseStudentManager.Students[i].SunbathePhase > 1)
						{
							baseStudentManager.Students[i].CurrentDestination = baseStudentManager.SunbatheSpots[baseStudentManager.Students[i].StudentID];
							baseStudentManager.Students[i].Pathfinding.target = baseStudentManager.SunbatheSpots[baseStudentManager.Students[i].StudentID];
						}
						else if (baseStudentManager.Students[i].Actions[baseStudentManager.Students[i].Phase] == StudentActionType.Stalk)
						{
							baseStudentManager.Students[i].StalkTarget = baseStudentManager.Yandere.transform;
							baseStudentManager.Students[i].SleuthTarget = baseStudentManager.Yandere.transform;
							baseStudentManager.Students[i].CurrentDestination = baseStudentManager.Students[i].StalkTarget;
							baseStudentManager.Students[i].Pathfinding.target = baseStudentManager.Students[i].StalkTarget;
							baseStudentManager.Students[i].StalkerFleeing = true;
						}
					}
					else
					{
						baseStudentManager.Students[i].CurrentDestination = baseStudentManager.Students[i].StudentManager.Patrols.List[baseStudentManager.Students[i].StudentID].GetChild(baseStudentManager.Students[i].PatrolID);
						baseStudentManager.Students[i].Pathfinding.target = baseStudentManager.Students[i].CurrentDestination;
					}
				}
				if (baseStudentManager.Students[i].LostTeacherTrust)
				{
					baseStudentManager.Students[i].WalkAnim = baseStudentManager.Students[i].BulliedWalkAnim;
					baseStudentManager.Students[i].SmartPhone.SetActive(value: false);
				}
				if (baseStudentManager.Students[i].EatingSnack)
				{
					baseStudentManager.Students[i].Scrubber.SetActive(value: false);
					baseStudentManager.Students[i].Eraser.SetActive(value: false);
				}
				if (baseStudentManager.Students[i].SentToLocker)
				{
					baseStudentManager.Students[i].CurrentDestination = baseStudentManager.Students[i].MyLocker;
					baseStudentManager.Students[i].Pathfinding.target = baseStudentManager.Students[i].MyLocker;
				}
				baseStudentManager.Students[i].DiscCheck = false;
				baseStudentManager.Students[i].Waiting = true;
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000261F File Offset: 0x0000081F
		public void OKiZVeY7HW(int int_0, int int_1, bool bool_0)
		{
			ExtraOpinionsLearned.StudentOpinions[int_1].Opinions[int_0] = bool_0;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000263A File Offset: 0x0000083A
		public bool Q4mZrfQRNr(int int_0, int int_1)
		{
			return ExtraOpinionsLearned.StudentOpinions[int_1].Opinions[int_0];
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0001D7E4 File Offset: 0x0001B9E4
		public void OcTZ5IwlxY()
		{
			Debug.Log("Attempting to load all of the ''topics learned''.");
			for (int i = 1; i < baseStudentManager.Students.Length; i++)
			{
				for (int j = 1; j < 26; j++)
				{
					OKiZVeY7HW(j, i, ConversationGlobals.GetTopicLearnedByStudent(j, i));
				}
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0001D830 File Offset: 0x0001BA30
		public void B8SZ7hSEiv(int int_0)
		{
			if (ExtraStudentsNewSlots.Target[int_0] > 0 && ExtraStudentsNewSlots.Follower[int_0] > 0)
			{
				baseStudentManager.Students[int_0].FollowTarget = baseStudentManager.Students[ExtraStudentsNewSlots.Target[int_0]];
				baseStudentManager.Students[int_0].FollowTarget.Follower = baseStudentManager.Students[int_0];
				if (!baseStudentManager.Students[ExtraStudentsNewSlots.Target[int_0]].Male)
				{
					baseStudentManager.Students[int_0].FollowTarget.FollowTargetDestination.gameObject.SetActive(value: true);
				}
				else
				{
					baseStudentManager.Students[int_0].FollowTarget.FollowTargetDestination = baseStudentManager.Students[int_0].FollowTarget.LabcoatAttacher.transform;
				}
				ExtraStudentManager.yU9Z1mIPi0(int_0);
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002654 File Offset: 0x00000854
		public void BqBZcL1o7s(int int_0)
		{
			if (ExtraStudentsNewSlots.LovestruckID[int_0] > 0)
			{
				baseStudentManager.Students[int_0].LovestruckTarget = ExtraStudentsNewSlots.LovestruckID[int_0];
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0001D938 File Offset: 0x0001BB38
		private void RNjZ0dyqg5()
		{
			for (int i = 1; i < baseStudentManager.Week; i++)
			{
				if (GameGlobals.GetRivalEliminations(i) == 6)
				{
					Debug.Log("Rival #" + i + " was Matchmade! Adjusting her routine now.");
					StudentScript studentScript = baseStudentManager.Students[10 + i];
					StudentScript studentScript2 = baseStudentManager.Students[baseStudentManager.SuitorIDs[i]];
					if (studentScript != null && studentScript2 != null)
					{
						studentScript.PartnerID = baseStudentManager.SuitorIDs[i];
						studentScript.Partner = baseStudentManager.Students[studentScript.PartnerID];
						studentScript.CoupleID = i;
						dkHZ9DLErR(studentScript);
						studentScript2.PartnerID = 10 + i;
						studentScript2.Partner = baseStudentManager.Students[10 + i];
						studentScript2.CoupleID = i;
						dkHZ9DLErR(studentScript2);
					}
				}
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0001DA2C File Offset: 0x0001BC2C
		private void dkHZ9DLErR(StudentScript studentScript_0)
		{
			ScheduleBlock obj = studentScript_0.ScheduleBlocks[2];
			obj.destination = "Cuddle";
			obj.action = "Cuddle";
			ScheduleBlock obj2 = studentScript_0.ScheduleBlocks[4];
			obj2.destination = "Cuddle";
			obj2.action = "Cuddle";
			ScheduleBlock obj3 = studentScript_0.ScheduleBlocks[6];
			obj3.destination = "Locker";
			obj3.action = "Shoes";
			ScheduleBlock obj4 = studentScript_0.ScheduleBlocks[7];
			obj4.destination = "Exit";
			obj4.action = "Exit";
			studentScript_0.GetDestinations();
			studentScript_0.Pathfinding.target = studentScript_0.Destinations[studentScript_0.Phase];
			studentScript_0.CurrentDestination = studentScript_0.Destinations[studentScript_0.Phase];
		}

		// Token: 0x04000094 RID: 148
		public StudentManagerScript baseStudentManager;

		// Token: 0x04000095 RID: 149
		public ExtraMemorialSceneScript zKdZFEmssX;

		// Token: 0x04000096 RID: 150
		public LockerCreatorScript LockerCreator;

		// Token: 0x04000097 RID: 151
		public ExtraStudentsSettingsManager ExtraStudentsSettingsManager;

		// Token: 0x04000098 RID: 152
		public ExtraOpinionsLearnedScript ExtraOpinionsLearned;

		// Token: 0x04000099 RID: 153
		public ExtraStudentsNewSlotsScript ExtraStudentsNewSlots;

		// Token: 0x0400009A RID: 154
		public ExtraStudentManagerScript ExtraStudentManager;

		// Token: 0x0400009B RID: 155
		public ExtraJsonScript ExtraJson;

		// Token: 0x0400009C RID: 156
		public GameObject StudentModel;

		// Token: 0x0400009D RID: 157
		public bool[] ASJvZ8DPwN;

		// Token: 0x0400009E RID: 158
		public bool debug;

		// Token: 0x0400009F RID: 159
		public bool injected;

		// Token: 0x040000A0 RID: 160
		public bool mKRv8nGMF0;

		// Token: 0x040000A1 RID: 161
		public bool vtfvC59yST;

		// Token: 0x040000A2 RID: 162
		public bool QgVvMatWBC;

		// Token: 0x040000A3 RID: 163
		public int StudentLimit;

		// Token: 0x040000A4 RID: 164
		private int j0mv4DAaux;

		// Token: 0x040000A5 RID: 165
		public int SXovH1gxZM;

		// Token: 0x040000A6 RID: 166
		public int[] StudentFirstWeeks;

		// Token: 0x040000A7 RID: 167
		public int uSevQRYkLY;

		// Token: 0x040000A8 RID: 168
		private ScheduleBlock zvDvh3VgtC;
	}
}

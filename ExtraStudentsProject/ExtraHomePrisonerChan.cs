using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExtraStudentsProject
{
	// Token: 0x02000024 RID: 36
	internal class ExtraHomePrisonerChan : MonoBehaviour
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x00023944 File Offset: 0x00021B44
		private void Start()
		{
			HomePrisonerChan = base.gameObject.GetComponent<HomePrisonerChanScript>();
			ExtraJson = GameObject.Find("JSON").GetComponent<ExtraJsonScript>();
			if (HomePrisonerChan.StudentID > 0)
			{
				if (StudentGlobals.GetStudentSanity(HomePrisonerChan.StudentID) == 100)
				{
					HomePrisonerChan.AnkleRopes.SetActive(value: false);
				}
				HomePrisonerChan.PermanentAngleR = HomePrisonerChan.TwintailR.eulerAngles;
				HomePrisonerChan.PermanentAngleL = HomePrisonerChan.TwintailL.eulerAngles;
				StudentGlobals.GetStudentArrested(HomePrisonerChan.StudentID);
				StudentGlobals.GetStudentDead(HomePrisonerChan.StudentID);
				if (!StudentGlobals.GetStudentArrested(HomePrisonerChan.StudentID) && !StudentGlobals.GetStudentDead(HomePrisonerChan.StudentID))
				{
					HomePrisonerChan.Cosmetic.StudentID = HomePrisonerChan.StudentID;
					HomePrisonerChan.Cosmetic.enabled = true;
					OverrideCosmeticStart(HomePrisonerChan.StudentID);
					if (HomePrisonerChan.StudentID < 101)
					{
						HomePrisonerChan.BreastSize = HomePrisonerChan.JSON.Students[HomePrisonerChan.StudentID].BreastSize;
					}
					else
					{
						HomePrisonerChan.BreastSize = ExtraJson.Students[HomePrisonerChan.StudentID].BreastSize;
					}
					HomePrisonerChan.RightEyeRotOrigin = HomePrisonerChan.RightEye.localEulerAngles;
					HomePrisonerChan.LeftEyeRotOrigin = HomePrisonerChan.LeftEye.localEulerAngles;
					HomePrisonerChan.RightEyeOrigin = HomePrisonerChan.RightEye.localPosition;
					HomePrisonerChan.LeftEyeOrigin = HomePrisonerChan.LeftEye.localPosition;
					HomePrisonerChan.UpdateSanity();
					HomePrisonerChan.TwintailR.transform.localEulerAngles = new Vector3(0f, 180f, -90f);
					HomePrisonerChan.TwintailL.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
					HomePrisonerChan.Blindfold.SetActive(value: false);
					HomePrisonerChan.Tripod.SetActive(value: false);
					if (HomePrisonerChan.StudentID == 81 && !StudentGlobals.GetStudentBroken(81) && SchemeGlobals.HelpingKokona)
					{
						HomePrisonerChan.Blindfold.SetActive(value: true);
						HomePrisonerChan.Tripod.SetActive(value: true);
					}
				}
				else
				{
					HomePrisonerChan.gameObject.SetActive(value: false);
				}
				if (HomePrisonerChan.IdleAnim == "")
				{
					HomePrisonerChan.IdleAnim = "f02_kidnapIdle_01";
				}
				HomePrisonerChan.Character.GetComponent<Animation>().CrossFade(HomePrisonerChan.IdleAnim);
			}
			else
			{
				HomePrisonerChan.gameObject.SetActive(value: false);
			}
			if (HomePrisonerChan.Cosmetic.Student.Ragdoll != null)
			{
				for (int i = 0; i < HomePrisonerChan.Cosmetic.Student.Ragdoll.AllRigidbodies.Length; i++)
				{
					HomePrisonerChan.Cosmetic.Student.Ragdoll.AllRigidbodies[i].isKinematic = true;
					HomePrisonerChan.Cosmetic.Student.Ragdoll.AllColliders[i].enabled = false;
				}
				HomePrisonerChan.Cosmetic.Student.DisableFemaleProps();
				HomePrisonerChan.Cosmetic.Student.SetSplashes(Bool: false);
				HomePrisonerChan.Cosmetic.Student.DisableProps();
				HomePrisonerChan.Blindfold.SetActive(value: true);
			}
			if (GameGlobals.Eighties)
			{
				if (HomePrisonerChan.Eighties)
				{
					HomePrisonerChan.Blindfold.SetActive(value: true);
				}
				else
				{
					HomePrisonerChan.gameObject.SetActive(value: false);
				}
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00023D7C File Offset: 0x00021F7C
		public void OverrideCosmeticStart(int int_0)
		{
			CosmeticScript component = base.gameObject.GetComponent<CosmeticScript>();
			if (component.Kidnapped && component.FemaleHair[20] == null)
			{
				component.FemaleHair[20] = component.BackupOsanaHair;
				component.FemaleHairRenderers[20] = component.BackupOsanaHairRenderer;
			}
			if (component.StudentManager != null)
			{
				component.Eighties = component.StudentManager.Eighties;
			}
			else
			{
				component.Eighties = GameGlobals.Eighties;
			}
			if (component.Eighties && component.Male)
			{
				component.MaleUniformTextures[1] = component.EightiesMaleCasualTexture;
				component.MaleCasualTextures[1] = component.EightiesMaleUniformTexture;
				component.MaleSocksTextures[1] = component.EightiesMaleSocksTexture;
				int num = 66;
				while (num < component.Trunks.Length)
				{
					if (component.Trunks[num] != null)
					{
						component.Trunks[num] = component.Trunks[0];
						num++;
					}
				}
			}
			if (component.Cutscene && EventGlobals.OsanaConversation)
			{
				component.StudentID = 11;
			}
			if (component.RightShoe != null)
			{
				component.RightShoe.SetActive(value: false);
				component.LeftShoe.SetActive(value: false);
			}
			component.ColorValue = new Color(1f, 1f, 1f, 1f);
			string empty = string.Empty;
			if (!component.Initialized)
			{
				component.Accessory = int.Parse(ExtraJson.Students[component.StudentID].Accessory);
				component.Hairstyle = int.Parse(ExtraJson.Students[component.StudentID].Hairstyle);
				component.Stockings = ExtraJson.Students[component.StudentID].Stockings;
				component.BreastSize = ExtraJson.Students[component.StudentID].BreastSize;
				component.EyeType = ExtraJson.Students[component.StudentID].EyeType;
				component.HairColor = ExtraJson.Students[component.StudentID].Color;
				component.EyeColor = ExtraJson.Students[component.StudentID].Eyes;
				component.Club = ExtraJson.Students[component.StudentID].Club;
				component.Name = ExtraJson.Students[component.StudentID].Name;
				if (component.Yandere)
				{
					component.Accessory = 0;
					component.Hairstyle = 1;
					component.Stockings = "Black";
					component.BreastSize = 1f;
					component.HairColor = "White";
					component.EyeColor = "Black";
					component.Club = ClubType.None;
				}
				component.OriginalStockings = component.Stockings;
				component.Initialized = true;
			}
			if (component.Medibang)
			{
				component.Accessory = 0;
				component.Hairstyle = 56;
				component.Stockings = "";
				component.BreastSize = 1f;
				component.EyeType = "";
				component.HairColor = "";
				component.EyeColor = "";
				component.Club = ClubType.Occult;
				component.Name = "Edgy Example Girl";
			}
			if (component.Kidnapped)
			{
				component.Accessory = 0;
				component.EyewearID = 0;
			}
			if (!component.Eighties)
			{
				if (component.StudentID == 11)
				{
					if (DateGlobals.Week > 1 && !component.Kidnapped && !component.Student.Slave)
					{
						component.Hairstyle = 54;
					}
				}
				else if (component.StudentID == 36)
				{
					component.FacialHairstyle = 12;
					component.EyewearID = 8;
					if (component.StudentManager.TaskManager != null && component.StudentManager.TaskManager.TaskStatus[36] == 3)
					{
						Debug.Log("Gema is updating his appearance.");
						component.FacialHairstyle = 0;
						component.EyewearID = 9;
						component.Hairstyle = 49;
						component.Accessory = 0;
					}
				}
				else if (component.StudentID == 51 && ClubGlobals.GetClubClosed(ClubType.LightMusic))
				{
					component.Hairstyle = 51;
				}
			}
			if (component.StudentManager != null && component.StudentManager.EmptyDemon && (component.StudentID == 21 || component.StudentID == 26 || component.StudentID == 31 || component.StudentID == 36 || component.StudentID == 41 || component.StudentID == 46 || component.StudentID == 51 || component.StudentID == 56 || component.StudentID == 61 || component.StudentID == 66 || component.StudentID == 71))
			{
				if (!component.Male)
				{
					component.Hairstyle = 52;
				}
				else
				{
					component.Hairstyle = 53;
				}
				component.FacialHairstyle = 0;
				component.EyewearID = 0;
				component.Accessory = 0;
				component.Stockings = "";
				component.BreastSize = 1f;
				component.Empty = true;
			}
			if (component.Name == "Random")
			{
				component.Randomize = true;
				if (!component.Male)
				{
					empty = component.StudentManager.FirstNames[Random.Range(0, component.StudentManager.FirstNames.Length)] + " " + component.StudentManager.LastNames[Random.Range(0, component.StudentManager.LastNames.Length)];
					ExtraJson.Students[component.StudentID].Name = empty;
					component.Student.Name = empty;
				}
				else
				{
					empty = component.StudentManager.MaleNames[Random.Range(0, component.StudentManager.MaleNames.Length)] + " " + component.StudentManager.LastNames[Random.Range(0, component.StudentManager.LastNames.Length)];
					ExtraJson.Students[component.StudentID].Name = empty;
					component.Student.Name = empty;
				}
				if (MissionModeGlobals.MissionMode && MissionModeGlobals.MissionTarget == component.StudentID)
				{
					ExtraJson.Students[component.StudentID].Name = MissionModeGlobals.MissionTargetName;
					component.Student.Name = MissionModeGlobals.MissionTargetName;
					empty = MissionModeGlobals.MissionTargetName;
				}
			}
			if (component.Randomize)
			{
				component.Teacher = false;
				component.BreastSize = Random.Range(0.5f, 2f);
				component.Accessory = 0;
				component.Club = ClubType.None;
				if (!component.Male)
				{
					component.Hairstyle = Random.Range(1, component.FemaleHair.Length);
				}
				else
				{
					component.SkinColor = Random.Range(0, component.SkinTextures.Length);
					component.Hairstyle = Random.Range(1, component.MaleHair.Length);
				}
			}
			component.DisableAccessories();
			bool flag = false;
			if (component.StudentManager != null && component.StudentID == component.StudentManager.SuitorID)
			{
				flag = true;
			}
			if (flag && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorEyewear > 0)
			{
				component.Eyewear[StudentGlobals.CustomSuitorEyewear].SetActive(value: true);
			}
			if (!component.Male)
			{
				component.FemaleUniformID = StudentGlobals.FemaleUniform;
				component.ThickBrows.SetActive(value: false);
				if (!component.TakingPortrait)
				{
					component.Tongue.SetActive(value: false);
				}
				GameObject[] phoneCharms = component.PhoneCharms;
				foreach (GameObject gameObject in phoneCharms)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(value: false);
					}
				}
				if (QualitySettings.GetQualityLevel() > 1)
				{
					component.Student.BreastSize = 1f;
					component.BreastSize = 1f;
				}
				component.RightBreast.localScale = new Vector3(component.BreastSize, component.BreastSize, component.BreastSize);
				component.LeftBreast.localScale = new Vector3(component.BreastSize, component.BreastSize, component.BreastSize);
				component.RightWristband.SetActive(value: false);
				component.LeftWristband.SetActive(value: false);
				if (!component.Eighties)
				{
					if (component.StudentID == 51)
					{
						if (!component.Kidnapped && !component.Student.Slave)
						{
							component.RightTemple.name = "RENAMED";
							component.LeftTemple.name = "RENAMED";
						}
						component.RightTemple.localScale = new Vector3(0f, 1f, 1f);
						component.LeftTemple.localScale = new Vector3(0f, 1f, 1f);
						if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
						{
							component.SadBrows.SetActive(value: true);
						}
						else
						{
							component.ThickBrows.SetActive(value: true);
						}
					}
					else if (component.StudentID == 84 && StudentGlobals.GetStudentDead(81) && StudentGlobals.GetStudentDead(82) && StudentGlobals.GetStudentDead(83) && StudentGlobals.GetStudentDead(85))
					{
						component.Student.Club = ClubType.None;
						component.StudentManager.Bullies = 0;
						component.Club = ClubType.None;
						component.Hairstyle = 53;
					}
				}
				if (component.Club == ClubType.Bully)
				{
					if (!component.Kidnapped)
					{
						component.Student.SmartPhone.GetComponent<Renderer>().material.mainTexture = component.SmartphoneTextures[component.StudentID];
						component.Student.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
						component.Student.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
						component.Bookbag.GetComponent<MeshFilter>().mesh = component.ModernBookBagMesh;
					}
					component.RightWristband.GetComponent<Renderer>().material.mainTexture = component.WristwearTextures[component.StudentID];
					component.LeftWristband.GetComponent<Renderer>().material.mainTexture = component.WristwearTextures[component.StudentID];
					component.Bookbag.GetComponent<Renderer>().material.mainTexture = component.BookbagTextures[component.StudentID];
					component.HoodieRenderer.material.mainTexture = component.HoodieTextures[component.StudentID];
					if (component.PhoneCharms.Length != 0)
					{
						component.PhoneCharms[component.StudentID].SetActive(value: true);
					}
					if (component.FemaleUniformID < 2 || component.FemaleUniformID == 3)
					{
						component.RightWristband.SetActive(value: true);
						component.LeftWristband.SetActive(value: true);
					}
					component.Bookbag.SetActive(value: true);
					component.Hoodie.SetActive(value: true);
					for (int j = 0; j < 10; j++)
					{
						component.Fingernails[j].material.mainTexture = component.GanguroNailTextures[component.StudentID];
					}
					component.Student.GymTexture = component.TanGymTexture;
					component.Student.TowelTexture = component.TanTowelTexture;
				}
				else
				{
					component.DisableFingernails();
					if (component.Club == ClubType.Gardening && !component.TakingPortrait && !component.Kidnapped)
					{
						component.CanRenderer.material.mainTexture = component.CanTextures[component.StudentID];
					}
				}
				if (!component.Kidnapped && SceneManager.GetActiveScene().name == "PortraitScene")
				{
					if (!component.Eighties)
					{
						if (component.StudentID == 2)
						{
							component.CharacterAnimation.Play("succubus_a_idle_twins_01");
							base.transform.position = new Vector3(0.094f, 0f, 0f);
							component.LookCamera = true;
							component.CharacterAnimation["f02_smile_00"].layer = 1;
							component.CharacterAnimation.Play("f02_smile_00");
							component.CharacterAnimation["f02_smile_00"].weight = 1f;
						}
						else if (component.StudentID == 3)
						{
							component.CharacterAnimation.Play("succubus_b_idle_twins_02");
							base.transform.position = new Vector3(-0.322f, 0.04f, 0f);
							component.LookCamera = true;
							component.CharacterAnimation["f02_smile_00"].layer = 1;
							component.CharacterAnimation.Play("f02_smile_00");
							component.CharacterAnimation["f02_smile_00"].weight = 1f;
						}
						else if (component.StudentID == 4)
						{
							component.CharacterAnimation.Play("f02_idleShort_00");
							base.transform.position = new Vector3(0.015f, 0f, 0f);
							component.LookCamera = true;
						}
						else if (component.StudentID == 5)
						{
							component.CharacterAnimation[component.Student.ShyAnim].layer = 5;
							component.CharacterAnimation.Play(component.Student.ShyAnim);
							component.CharacterAnimation[component.Student.ShyAnim].weight = 0.5f;
						}
						else if (component.StudentID == 10)
						{
							component.CharacterAnimation.Play("f02_raibaruPortraitPose_00");
						}
						else if (component.StudentID == 11)
						{
							component.CharacterAnimation.Play("f02_rivalPortraitPose_01");
							base.transform.position = new Vector3(-0.045f, 0f, 0f);
						}
						else if (component.StudentID == 24)
						{
							component.CharacterAnimation.Play("f02_idleGirly_00");
							component.CharacterAnimation["f02_idleGirly_00"].time = 1f;
						}
						else if (component.StudentID == 25)
						{
							component.CharacterAnimation.Play("f02_idleGirly_00");
							component.CharacterAnimation["f02_idleGirly_00"].time = 0f;
						}
						else if (component.StudentID == 30)
						{
							component.CharacterAnimation.Play("f02_idleGirly_00");
							component.CharacterAnimation["f02_idleGirly_00"].time = 0f;
						}
						else if (component.StudentID == 34)
						{
							component.CharacterAnimation.Play("f02_idleShort_00");
							base.transform.position = new Vector3(0.015f, 0f, 0f);
							component.LookCamera = true;
						}
						else if (component.StudentID == 35)
						{
							component.CharacterAnimation.Play("f02_idleShort_00");
							base.transform.position = new Vector3(0.015f, 0f, 0f);
							component.LookCamera = true;
						}
						else if (component.StudentID == 38)
						{
							component.CharacterAnimation.Play("f02_idleGirly_00");
							component.CharacterAnimation["f02_idleGirly_00"].time = 0f;
						}
						else if (component.StudentID == 39)
						{
							component.CharacterAnimation.Play("f02_socialCameraPose_00");
							base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.05f, base.transform.position.z);
						}
						else if (component.StudentID == 40)
						{
							component.CharacterAnimation.Play("f02_idleGirly_00");
							component.CharacterAnimation["f02_idleGirly_00"].time = 1f;
						}
						else if (component.StudentID == 51)
						{
							component.CharacterAnimation.Play("f02_musicPose_00");
							component.Tongue.SetActive(value: true);
						}
						else if (component.StudentID == 59)
						{
							component.CharacterAnimation.Play("f02_sleuthPortrait_00");
						}
						else if (component.StudentID == 60)
						{
							component.CharacterAnimation.Play("f02_sleuthPortrait_01");
						}
						else if (component.StudentID == 64)
						{
							component.CharacterAnimation.Play("f02_idleShort_00");
							base.transform.position = new Vector3(0.015f, 0f, 0f);
							component.LookCamera = true;
						}
						else if (component.StudentID == 65)
						{
							component.CharacterAnimation.Play("f02_idleShort_00");
							base.transform.position = new Vector3(0.015f, 0f, 0f);
							component.LookCamera = true;
						}
						else if (component.StudentID == 71)
						{
							component.CharacterAnimation.Play("f02_idleGirly_00");
							component.CharacterAnimation["f02_idleGirly_00"].time = 0f;
						}
						else if (component.StudentID == 72)
						{
							component.CharacterAnimation.Play("f02_idleGirly_00");
							component.CharacterAnimation["f02_idleGirly_00"].time = 0.66666f;
						}
						else if (component.StudentID == 73)
						{
							component.CharacterAnimation.Play("f02_idleGirly_00");
							component.CharacterAnimation["f02_idleGirly_00"].time = 1.33332f;
						}
						else if (component.StudentID == 74)
						{
							component.CharacterAnimation.Play("f02_idleGirly_00");
							component.CharacterAnimation["f02_idleGirly_00"].time = 1.99998f;
						}
						else if (component.StudentID == 75)
						{
							component.CharacterAnimation.Play("f02_idleGirly_00");
							component.CharacterAnimation["f02_idleGirly_00"].time = 2.66664f;
						}
						else if (component.StudentID == 81)
						{
							string text = "Casual";
							component.CharacterAnimation["f02_faceCouncil" + text + "_00"].layer = 1;
							component.CharacterAnimation.Play("f02_faceCouncil" + text + "_00");
							component.CharacterAnimation.Play("f02_socialCameraPose_00");
							base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.05f, base.transform.position.z);
						}
						else if (component.StudentID != 82 && component.StudentID != 52)
						{
							if (component.StudentID != 83 && component.StudentID != 53)
							{
								if (component.StudentID != 84 && component.StudentID != 54)
								{
									if (component.StudentID != 85 && component.StudentID != 55)
									{
										if (component.StudentID == 90)
										{
											component.CharacterAnimation.Play("f02_nursePortraitPose_00");
										}
										else if (component.StudentID == 91)
										{
											component.CharacterAnimation.Play("f02_teacherPortraitPose_11");
											base.transform.position = new Vector3(0.0233333f, 0f, 0f);
										}
										else if (component.StudentID == 92)
										{
											component.CharacterAnimation.Play("f02_teacherPortraitPose_12");
											base.transform.position = new Vector3(-0.045f, 0f, 0f);
										}
										else if (component.StudentID == 93)
										{
											component.CharacterAnimation.Play("f02_teacherPortraitPose_21");
										}
										else if (component.StudentID == 94)
										{
											component.CharacterAnimation.Play("f02_teacherPortraitPose_22");
										}
										else if (component.StudentID == 95)
										{
											component.CharacterAnimation.Play("f02_teacherPortraitPose_31");
										}
										else if (component.StudentID == 96)
										{
											component.CharacterAnimation.Play("f02_teacherPortraitPose_32");
										}
										else if (component.StudentID == 97)
										{
											component.CharacterAnimation.Play("f02_coachPortraitPose_02");
											base.transform.position = new Vector3(-0.029f, 0f, 0f);
										}
										else if (component.Club != ClubType.Council)
										{
											component.CharacterAnimation.Play("f02_idleShort_01");
											base.transform.position = new Vector3(0.015f, 0f, 0f);
											component.LookCamera = true;
										}
									}
									else
									{
										component.CharacterAnimation.Play("f02_galPose_04");
									}
								}
								else
								{
									component.CharacterAnimation.Play("f02_galPose_03");
								}
							}
							else
							{
								component.CharacterAnimation.Play("f02_galPose_02");
							}
						}
						else
						{
							component.CharacterAnimation.Play("f02_galPose_01");
						}
					}
					else
					{
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						if (component.StudentID > 10 && component.StudentID < 20)
						{
							base.transform.position = new Vector3(0f, 0f, 0f);
							component.CharacterAnimation.Play("f02_eightiesRivalPose_0" + (component.StudentID - 10));
						}
						else if (component.StudentID == 20)
						{
							base.transform.position = new Vector3(0f, 0f, 0f);
							component.CharacterAnimation.Play("f02_eightiesRivalPose_10");
						}
						else if (component.StudentID == 36)
						{
							component.CharacterAnimation["f02_smile_00"].layer = 1;
							component.CharacterAnimation.Play("f02_smile_00");
							component.CharacterAnimation["f02_smile_00"].weight = 1f;
						}
						if (component.StudentID > 2 && component.StudentID < 7)
						{
							component.CharacterAnimation["f02_smile_00"].layer = 1;
							component.CharacterAnimation.Play("f02_smile_00");
							component.CharacterAnimation["f02_smile_00"].weight = 1f;
						}
					}
				}
			}
			else
			{
				component.MaleUniformID = StudentGlobals.MaleUniform;
				GameObject[] galoAccessories = component.GaloAccessories;
				for (int k = 0; k < galoAccessories.Length; k++)
				{
					galoAccessories[k].SetActive(value: false);
				}
				bool flag2 = false;
				if (component.StudentManager != null && component.StudentID == component.StudentManager.SuitorID)
				{
					flag2 = true;
				}
				if (flag2 && StudentGlobals.CustomSuitor)
				{
					if (StudentGlobals.CustomSuitorHair > 0)
					{
						component.Hairstyle = StudentGlobals.CustomSuitorHair;
					}
					if (StudentGlobals.CustomSuitorAccessory > 0)
					{
						component.Accessory = StudentGlobals.CustomSuitorAccessory;
						if (component.Accessory == 1)
						{
							Transform obj = component.MaleAccessories[1].transform;
							obj.localScale = new Vector3(1.066666f, 1f, 1f);
							obj.localPosition = new Vector3(0f, -1.525f, 0.0066666f);
						}
					}
					if (StudentGlobals.CustomSuitorBlack)
					{
						component.HairColor = "SolidBlack";
					}
					if (StudentGlobals.CustomSuitorJewelry > 0)
					{
						galoAccessories = component.GaloAccessories;
						for (int l = 0; l < galoAccessories.Length; l++)
						{
							galoAccessories[l].SetActive(value: true);
						}
					}
				}
				if (!(component.StudentManager == null) && component.Eighties)
				{
					if (!component.Student.Posing)
					{
						if (component.Eighties)
						{
							if (component.StudentID == 86)
							{
								component.CharacterAnimation["toughFace_00"].layer = 1;
								component.CharacterAnimation.Play("toughFace_00");
								component.CharacterAnimation["toughFace_00"].weight = 1f;
							}
							if (component.Club == ClubType.Council)
							{
								component.CouncilBrows[component.StudentID - 85].SetActive(value: true);
							}
							if (component.StudentID == 76)
							{
								component.CharacterAnimation.Play("delinquentPoseB");
							}
							else if (component.StudentID == 77)
							{
								component.CharacterAnimation.Play("delinquentPoseA");
							}
							else if (component.StudentID == 78)
							{
								component.CharacterAnimation.Play("delinquentPoseC");
							}
							else if (component.StudentID == 79)
							{
								component.CharacterAnimation.Play("delinquentPoseD");
							}
							else if (component.StudentID == 80)
							{
								component.CharacterAnimation.Play("delinquentPoseE");
							}
						}
						if (component.Club == ClubType.Delinquent)
						{
							base.transform.position = new Vector3(0.005f, 0.03f, 0f);
						}
						else
						{
							base.transform.position = new Vector3(0.005f, 0f, 0f);
						}
					}
				}
				else
				{
					component.ThickBrows.SetActive(value: false);
					if (component.Club == ClubType.Occult)
					{
						component.CharacterAnimation["sadFace_00"].layer = 1;
						component.CharacterAnimation.Play("sadFace_00");
						component.CharacterAnimation["sadFace_00"].weight = 1f;
					}
					if (component.StudentID == 36 || component.StudentID == 66)
					{
						component.CharacterAnimation["toughFace_00"].layer = 1;
						component.CharacterAnimation.Play("toughFace_00");
						component.CharacterAnimation["toughFace_00"].weight = 1f;
						if (component.StudentID == 66)
						{
							component.ThickBrows.SetActive(value: true);
						}
					}
					if (SceneManager.GetActiveScene().name == "PortraitScene")
					{
						if (component.StudentID == 26)
						{
							component.CharacterAnimation.Play("idleHaughty_00");
						}
						else if (component.StudentID == 36)
						{
							component.CharacterAnimation.Play("slouchIdle_00");
						}
						else if (component.StudentID == 56)
						{
							component.CharacterAnimation.Play("idleConfident_00");
						}
						else if (component.StudentID == 57)
						{
							component.CharacterAnimation.Play("sleuthPortrait_00");
						}
						else if (component.StudentID == 58)
						{
							component.CharacterAnimation.Play("sleuthPortrait_01");
						}
						else if (component.StudentID == 61)
						{
							component.CharacterAnimation.Play("scienceMad_00");
							base.transform.position = new Vector3(0f, 0.1f, 0f);
						}
						else if (component.StudentID == 62)
						{
							component.CharacterAnimation.Play("idleFrown_00");
						}
						else if (component.StudentID == 69)
						{
							component.CharacterAnimation.Play("idleFrown_00");
						}
						else if (component.StudentID == 76)
						{
							component.CharacterAnimation.Play("delinquentPoseB");
						}
						else if (component.StudentID == 77)
						{
							component.CharacterAnimation.Play("delinquentPoseA");
						}
						else if (component.StudentID == 78)
						{
							component.CharacterAnimation.Play("delinquentPoseC");
						}
						else if (component.StudentID == 79)
						{
							component.CharacterAnimation.Play("delinquentPoseD");
						}
						else if (component.StudentID == 80)
						{
							component.CharacterAnimation.Play("delinquentPoseE");
						}
					}
				}
			}
			if (component.Club == ClubType.Teacher)
			{
				component.MyRenderer.sharedMesh = component.TeacherMesh;
				if (!SystemInfo.supportsComputeShaders)
				{
					component.MyRenderer.sharedMesh.ClearBlendShapes();
				}
				component.Teacher = true;
				if (component.Eighties)
				{
					component.Student.EightiesTeacherAttacher.SetActive(value: true);
					component.Student.MyRenderer.enabled = false;
				}
			}
			else if (component.Club == ClubType.GymTeacher)
			{
				if (!StudentGlobals.GetStudentReplaced(component.StudentID))
				{
					component.RightEyeRenderer.gameObject.SetActive(value: false);
					component.LeftEyeRenderer.gameObject.SetActive(value: false);
				}
				component.MyRenderer.sharedMesh = component.CoachMesh;
				component.Teacher = true;
			}
			else if (component.Club == ClubType.Nurse)
			{
				if (!component.Eighties)
				{
					component.MyRenderer.sharedMesh = component.NurseMesh;
				}
				else
				{
					component.MyRenderer.sharedMesh = component.EightiesNurseMesh;
				}
				component.Teacher = true;
			}
			else if (component.Club == ClubType.Council)
			{
				component.Armband.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.285f, 0f));
				component.Armband.SetActive(value: true);
				string text2 = "";
				if (component.StudentID == 86)
				{
					text2 = "Strict";
				}
				if (component.StudentID == 87)
				{
					text2 = "Casual";
				}
				if (component.StudentID == 88)
				{
					text2 = "Grace";
				}
				if (component.StudentID == 89)
				{
					text2 = "Edgy";
				}
				if (!component.Eighties)
				{
					component.CharacterAnimation["f02_faceCouncil" + text2 + "_00"].layer = 1;
					component.CharacterAnimation.Play("f02_faceCouncil" + text2 + "_00");
					component.CharacterAnimation["f02_idleCouncil" + text2 + "_00"].time = 1f;
					component.CharacterAnimation.Play("f02_idleCouncil" + text2 + "_00");
				}
			}
			if (!ClubGlobals.GetClubClosed(component.Club) && (component.StudentID == 21 || component.StudentID == 26 || component.StudentID == 31 || component.StudentID == 36 || component.StudentID == 41 || component.StudentID == 46 || component.StudentID == 51 || component.StudentID == 56 || component.StudentID == 61 || component.StudentID == 66 || component.StudentID == 71))
			{
				if (!component.Kidnapped)
				{
					component.Armband.SetActive(value: true);
				}
				Renderer component2 = component.Armband.GetComponent<Renderer>();
				if (component.StudentID == 21)
				{
					component2.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.145f));
				}
				else if (component.StudentID == 26)
				{
					component2.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.145f));
				}
				else if (component.StudentID == 31)
				{
					component2.material.SetTextureOffset("_MainTex", new Vector2(0.57f, 0f));
				}
				else if (component.StudentID == 36)
				{
					if (!component.Eighties)
					{
						component2.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.29f));
					}
					else
					{
						component2.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.435f));
					}
				}
				else if (component.StudentID == 41)
				{
					component2.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.58f));
				}
				else if (component.StudentID == 46)
				{
					component2.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.435f));
				}
				else if (component.StudentID == 51)
				{
					component2.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.29f));
				}
				else if (component.StudentID == 56)
				{
					component2.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.29f));
				}
				else if (component.StudentID == 61)
				{
					component2.material.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
				}
				else if (component.StudentID == 66)
				{
					component2.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.145f));
				}
				else if (component.StudentID == 71)
				{
					component2.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.435f));
				}
			}
			if (component.StudentID == 1 && SenpaiGlobals.CustomSenpai)
			{
				if (SenpaiGlobals.SenpaiEyeWear > 0)
				{
					component.Eyewear[SenpaiGlobals.SenpaiEyeWear].SetActive(value: true);
				}
				component.FacialHairstyle = SenpaiGlobals.SenpaiFacialHair;
				component.HairColor = SenpaiGlobals.SenpaiHairColor;
				component.EyeColor = SenpaiGlobals.SenpaiEyeColor;
				component.Hairstyle = SenpaiGlobals.SenpaiHairStyle;
			}
			if (!component.Male)
			{
				if (!component.Teacher)
				{
					component.FemaleHair[component.Hairstyle].SetActive(value: true);
					component.HairRenderer = component.FemaleHairRenderers[component.Hairstyle];
					component.SetFemaleUniform();
				}
				else
				{
					component.TeacherHair[component.Hairstyle].SetActive(value: true);
					component.HairRenderer = component.TeacherHairRenderers[component.Hairstyle];
					if (component.Club == ClubType.Teacher)
					{
						component.MyRenderer.materials[0].mainTexture = component.DefaultFaceTexture;
						component.MyRenderer.materials[1].mainTexture = component.TeacherBodyTexture;
						component.MyRenderer.materials[2].mainTexture = component.TeacherBodyTexture;
					}
					else if (component.Club == ClubType.GymTeacher)
					{
						if (StudentGlobals.GetStudentReplaced(component.StudentID))
						{
							component.MyRenderer.materials[2].mainTexture = component.DefaultFaceTexture;
							component.MyRenderer.materials[0].mainTexture = component.CoachPaleBodyTexture;
							component.MyRenderer.materials[1].mainTexture = component.CoachPaleBodyTexture;
						}
						else
						{
							if (!component.Eighties)
							{
								component.MyRenderer.materials[2].mainTexture = component.CoachFaceTexture;
							}
							else
							{
								component.MyRenderer.materials[2].mainTexture = component.EightiesCoachFaceTexture;
							}
							component.MyRenderer.materials[0].mainTexture = component.CoachBodyTexture;
							component.MyRenderer.materials[1].mainTexture = component.CoachBodyTexture;
						}
					}
					else if (component.Club == ClubType.Nurse)
					{
						if (!component.Eighties)
						{
							component.MyRenderer.materials = component.NurseMaterials;
						}
						else
						{
							component.MyRenderer.materials = component.EightiesNurseMaterials;
						}
					}
				}
			}
			else
			{
				if (component.Hairstyle > 0)
				{
					component.MaleHair[component.Hairstyle].SetActive(value: true);
					component.HairRenderer = component.MaleHairRenderers[component.Hairstyle];
				}
				if (component.FacialHairstyle > 0)
				{
					component.FacialHair[component.FacialHairstyle].SetActive(value: true);
					component.FacialHairRenderer = component.FacialHairRenderers[component.FacialHairstyle];
				}
				if (component.EyewearID > 0)
				{
					component.Eyewear[component.EyewearID].SetActive(value: true);
				}
				component.SetMaleUniform();
			}
			if (!component.Male)
			{
				if (!component.Teacher)
				{
					if (component.FemaleAccessories[component.Accessory] != null)
					{
						component.FemaleAccessories[component.Accessory].SetActive(value: true);
					}
				}
				else if (component.TeacherAccessories[component.Accessory] != null && (!component.TakingPortrait || component.Eighties || (component.TakingPortrait && component.StudentID < 97)))
				{
					component.TeacherAccessories[component.Accessory].SetActive(value: true);
				}
			}
			else if (component.MaleAccessories[component.Accessory] != null)
			{
				component.MaleAccessories[component.Accessory].SetActive(value: true);
			}
			if ((component.StudentManager == null || (!component.Empty && !component.StudentManager.TutorialActive)) && !component.Kidnapped)
			{
				if (component.StudentManager == null || !component.Eighties)
				{
					if ((component.Club < ClubType.Gaming || component.Club == ClubType.Newspaper) && component.ClubAccessories[(int)component.Club] != null && !ClubGlobals.GetClubClosed(component.Club) && component.StudentID != 26)
					{
						component.ClubAccessories[(int)component.Club].SetActive(value: true);
					}
					if (!component.Eighties && component.StudentID == 36)
					{
						component.ClubAccessories[(int)component.Club].SetActive(value: true);
					}
					if (component.Club == ClubType.Cooking)
					{
						component.ClubAccessories[(int)component.Club].SetActive(value: false);
						component.ClubAccessories[(int)component.Club] = component.Kerchiefs[component.StudentID];
						if (!ClubGlobals.GetClubClosed(component.Club) && component.StudentID > 12)
						{
							component.ClubAccessories[(int)component.Club].SetActive(value: true);
						}
					}
					else if (component.Club == ClubType.Drama)
					{
						component.ClubAccessories[(int)component.Club].SetActive(value: false);
						component.ClubAccessories[(int)component.Club] = component.Roses[component.StudentID];
						if (!ClubGlobals.GetClubClosed(component.Club))
						{
							component.ClubAccessories[(int)component.Club].SetActive(value: true);
						}
					}
					else if (component.Club == ClubType.Art)
					{
						component.ClubAccessories[(int)component.Club].GetComponent<MeshFilter>().sharedMesh = component.Berets[component.StudentID];
						if (component.StudentID == 44)
						{
							component.ClubAccessories[(int)component.Club].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							component.ClubAccessories[(int)component.Club].transform.localScale = new Vector3(100f, 100f, 100f);
							component.ClubAccessories[(int)component.Club].transform.localPosition = new Vector3(0f, -1.445f, 0.02f);
						}
					}
					else if (component.Club == ClubType.Science)
					{
						if (component.ClubAccessories[(int)component.Club] != null)
						{
							component.ClubAccessories[(int)component.Club].SetActive(value: false);
						}
						component.ClubAccessories[(int)component.Club] = component.Scanners[component.StudentID];
						if (!ClubGlobals.GetClubClosed(component.Club))
						{
							component.ClubAccessories[(int)component.Club].SetActive(value: true);
						}
					}
					else if (component.Club == ClubType.LightMusic)
					{
						component.ClubAccessories[(int)component.Club].SetActive(value: false);
						component.ClubAccessories[(int)component.Club] = component.MusicNotes[component.StudentID - 50];
						if (!ClubGlobals.GetClubClosed(component.Club))
						{
							component.ClubAccessories[(int)component.Club].SetActive(value: true);
						}
					}
					else if (component.Club == ClubType.Sports)
					{
						component.ClubAccessories[(int)component.Club].SetActive(value: false);
						component.ClubAccessories[(int)component.Club] = component.Goggles[component.StudentID];
						if (!ClubGlobals.GetClubClosed(component.Club))
						{
							component.ClubAccessories[(int)component.Club].SetActive(value: true);
						}
					}
					else if (component.Club == ClubType.Gardening)
					{
						component.ClubAccessories[(int)component.Club].SetActive(value: false);
						component.ClubAccessories[(int)component.Club] = component.Flowers[component.StudentID];
						if (!ClubGlobals.GetClubClosed(component.Club))
						{
							component.ClubAccessories[(int)component.Club].SetActive(value: true);
						}
					}
					else if (component.Club == ClubType.Gaming)
					{
						if (component.ClubAccessories[(int)component.Club] != null)
						{
							component.ClubAccessories[(int)component.Club].SetActive(value: false);
						}
						component.ClubAccessories[(int)component.Club] = component.RedCloth[component.StudentID];
						if (!ClubGlobals.GetClubClosed(component.Club) && component.ClubAccessories[(int)component.Club] != null)
						{
							component.ClubAccessories[(int)component.Club].SetActive(value: true);
						}
					}
				}
				if (!component.Eighties && component.StudentID == 36 && component.StudentManager != null && component.StudentManager.TaskManager != null && component.StudentManager.TaskManager.TaskStatus[36] == 3)
				{
					component.ClubAccessories[(int)component.Club].SetActive(value: false);
				}
			}
			if (component.StudentID == 11 && !component.TakingPortrait && !component.Cutscene && !component.Kidnapped && SceneManager.GetActiveScene().name == "SchoolScene")
			{
				component.CatGifts[1].SetActive(CollectibleGlobals.GetGiftGiven(1));
				component.CatGifts[2].SetActive(CollectibleGlobals.GetGiftGiven(2));
				component.CatGifts[3].SetActive(CollectibleGlobals.GetGiftGiven(3));
				component.CatGifts[4].SetActive(CollectibleGlobals.GetGiftGiven(4));
			}
			if (!component.Male)
			{
				StartCoroutine(component.PutOnStockings());
			}
			if (!component.Randomize)
			{
				if (component.EyeColor != string.Empty)
				{
					if (component.EyeColor == "White")
					{
						component.CorrectColor = new Color(1f, 1f, 1f);
					}
					else if (component.EyeColor == "Black")
					{
						component.CorrectColor = new Color(0.5f, 0.5f, 0.5f);
					}
					else if (component.EyeColor == "Red")
					{
						component.CorrectColor = new Color(1f, 0f, 0f);
					}
					else if (component.EyeColor == "Yellow")
					{
						component.CorrectColor = new Color(1f, 1f, 0f);
					}
					else if (component.EyeColor == "Green")
					{
						component.CorrectColor = new Color(0f, 1f, 0f);
					}
					else if (component.EyeColor == "Cyan")
					{
						component.CorrectColor = new Color(0f, 1f, 1f);
					}
					else if (component.EyeColor == "Blue")
					{
						component.CorrectColor = new Color(0f, 0f, 1f);
					}
					else if (component.EyeColor == "Purple")
					{
						component.CorrectColor = new Color(1f, 0f, 1f);
					}
					else if (component.EyeColor == "Orange")
					{
						component.CorrectColor = new Color(1f, 0.5f, 0f);
					}
					else if (component.EyeColor == "Brown")
					{
						component.CorrectColor = new Color(0.5f, 0.25f, 0f);
					}
					else
					{
						component.CorrectColor = new Color(0f, 0f, 0f);
					}
					if (component.StudentID > 90 && component.StudentID < 97)
					{
						component.CorrectColor.r = component.CorrectColor.r * 0.5f;
						component.CorrectColor.g = component.CorrectColor.g * 0.5f;
						component.CorrectColor.b = component.CorrectColor.b * 0.5f;
					}
					if (component.CorrectColor != new Color(0f, 0f, 0f))
					{
						component.RightEyeRenderer.material.color = component.CorrectColor;
						component.LeftEyeRenderer.material.color = component.CorrectColor;
					}
				}
			}
			else
			{
				float r = Random.Range(0f, 1f);
				float g = Random.Range(0f, 1f);
				float b = Random.Range(0f, 1f);
				component.RightEyeRenderer.material.color = new Color(r, g, b);
				component.LeftEyeRenderer.material.color = new Color(r, g, b);
			}
			if (!component.Randomize)
			{
				if (component.HairColor == "White")
				{
					component.ColorValue = new Color(1f, 1f, 1f);
				}
				else if (component.HairColor == "Black")
				{
					component.ColorValue = new Color(0.5f, 0.5f, 0.5f);
				}
				else if (component.HairColor == "SolidBlack")
				{
					component.ColorValue = new Color(0.0001f, 0.0001f, 0.0001f);
				}
				else if (component.HairColor == "Red")
				{
					component.ColorValue = new Color(1f, 0f, 0f);
				}
				else if (component.HairColor == "Yellow")
				{
					component.ColorValue = new Color(1f, 1f, 0f);
				}
				else if (component.HairColor == "Green")
				{
					component.ColorValue = new Color(0f, 1f, 0f);
				}
				else if (component.HairColor == "Cyan")
				{
					component.ColorValue = new Color(0f, 1f, 1f);
				}
				else if (component.HairColor == "Blue")
				{
					component.ColorValue = new Color(0f, 0f, 1f);
				}
				else if (component.HairColor == "Purple")
				{
					component.ColorValue = new Color(1f, 0f, 1f);
				}
				else if (component.HairColor == "Orange")
				{
					component.ColorValue = new Color(1f, 0.5f, 0f);
				}
				else if (component.HairColor == "Brown")
				{
					component.ColorValue = new Color(0.5f, 0.25f, 0f);
				}
				else
				{
					component.ColorValue = new Color(0f, 0f, 0f);
					component.RightIrisLight.SetActive(value: false);
					component.LeftIrisLight.SetActive(value: false);
				}
				if (component.StudentID > 90 && component.StudentID < 97)
				{
					component.ColorValue.r = component.ColorValue.r * 0.5f;
					component.ColorValue.g = component.ColorValue.g * 0.5f;
					component.ColorValue.b = component.ColorValue.b * 0.5f;
				}
				if (component.ColorValue == new Color(0f, 0f, 0f))
				{
					if (component.HairRenderer != null)
					{
						component.RightEyeRenderer.material.mainTexture = component.HairRenderer.material.mainTexture;
						component.LeftEyeRenderer.material.mainTexture = component.HairRenderer.material.mainTexture;
						if (!component.DoNotChangeFace)
						{
							component.FaceTexture = component.HairRenderer.material.mainTexture;
						}
					}
					if (component.Empty)
					{
						component.FaceTexture = component.GrayFace;
					}
					component.CustomHair = true;
				}
				if (!component.CustomHair)
				{
					if (component.Hairstyle > 0)
					{
						if (GameGlobals.LoveSick)
						{
							component.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
							if (component.HairRenderer.materials.Length > 1)
							{
								component.HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
							}
						}
						else
						{
							component.HairRenderer.material.color = component.ColorValue;
						}
					}
				}
				else if (GameGlobals.LoveSick)
				{
					component.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
					if (component.HairRenderer.materials.Length > 1)
					{
						component.HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
					}
				}
				if (!component.Male)
				{
					if (component.StudentID == 25)
					{
						component.FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(0f, 1f, 1f);
					}
					else if (component.StudentID == 30)
					{
						component.FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f);
					}
				}
			}
			else
			{
				component.HairRenderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
			}
			if (!component.Teacher)
			{
				if (component.CustomHair)
				{
					if (!component.Male)
					{
						component.MyRenderer.materials[2].mainTexture = component.FaceTexture;
					}
					else if (component.Club == ClubType.Council)
					{
						component.MyRenderer.materials[0].mainTexture = component.FaceTexture;
					}
					else if (component.MaleUniformID == 1)
					{
						component.MyRenderer.materials[2].mainTexture = component.FaceTexture;
					}
					else if (component.MaleUniformID < 4)
					{
						component.MyRenderer.materials[1].mainTexture = component.FaceTexture;
					}
					else
					{
						component.MyRenderer.materials[0].mainTexture = component.FaceTexture;
					}
				}
			}
			else if (component.Teacher && StudentGlobals.GetStudentReplaced(component.StudentID))
			{
				Color studentColor = StudentGlobals.GetStudentColor(component.StudentID);
				Color studentEyeColor = StudentGlobals.GetStudentEyeColor(component.StudentID);
				component.HairRenderer.material.color = studentColor;
				component.RightEyeRenderer.material.color = studentEyeColor;
				component.LeftEyeRenderer.material.color = studentEyeColor;
			}
			if (component.Male)
			{
				if (component.Accessory == 2)
				{
					component.RightIrisLight.SetActive(value: false);
					component.LeftIrisLight.SetActive(value: false);
				}
				if (SceneManager.GetActiveScene().name == "PortraitScene")
				{
					component.Character.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
				}
				if (component.FacialHairRenderer != null)
				{
					component.FacialHairRenderer.material.color = component.ColorValue;
					if (component.FacialHairRenderer.materials.Length > 1)
					{
						component.FacialHairRenderer.materials[1].color = component.ColorValue;
					}
				}
			}
			if (!component.Eighties)
			{
				if (component.StudentID != 10)
				{
					if (component.StudentID != 25 && component.StudentID != 30)
					{
						if (component.StudentID == 2)
						{
							if (GameGlobals.RingStolen)
							{
								component.FemaleAccessories[3].SetActive(value: false);
							}
						}
						else if (component.StudentID == 40)
						{
							if (base.transform.position != Vector3.zero)
							{
								component.RightEyeRenderer.material.mainTexture = component.WaifuEyeTexture;
								component.LeftEyeRenderer.material.mainTexture = component.WaifuEyeTexture;
								component.RightIrisLight.GetComponent<Renderer>().material.mainTexture = component.WaifuIrisTexture;
								component.LeftIrisLight.GetComponent<Renderer>().material.mainTexture = component.WaifuIrisTexture;
								component.RightIrisLight.SetActive(value: true);
								component.LeftIrisLight.SetActive(value: true);
								component.RightEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
								component.LeftEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
							}
						}
						else if (component.StudentID == 41)
						{
							component.CharacterAnimation["moodyEyes_00"].layer = 1;
							component.CharacterAnimation.Play("moodyEyes_00");
							component.CharacterAnimation["moodyEyes_00"].weight = 1f;
							component.CharacterAnimation.Play("moodyEyes_00");
						}
						else if (component.StudentID == 51)
						{
							if (!ClubGlobals.GetClubClosed(ClubType.LightMusic))
							{
								component.PunkAccessories[1].SetActive(value: true);
								component.PunkAccessories[2].SetActive(value: true);
								component.PunkAccessories[3].SetActive(value: true);
							}
						}
						else if (component.StudentID == 59)
						{
							component.ClubAccessories[7].transform.localPosition = new Vector3(0f, -1.04f, 0.5f);
							component.ClubAccessories[7].transform.localEulerAngles = new Vector3(-22.5f, 0f, 0f);
						}
						else if (component.StudentID == 60)
						{
							component.FemaleAccessories[13].SetActive(value: true);
						}
					}
					else
					{
						component.FemaleAccessories[6].SetActive(value: true);
						if ((float)StudentGlobals.GetStudentReputation(component.StudentID) < -33.33333f)
						{
							component.FemaleAccessories[6].SetActive(value: false);
						}
					}
				}
			}
			else
			{
				if (component.StudentID == 86)
				{
					component.CharacterAnimation["moodyEyes_00"].layer = 1;
					component.CharacterAnimation.Play("moodyEyes_00");
					component.CharacterAnimation["moodyEyes_00"].weight = 1f;
					component.CharacterAnimation.Play("moodyEyes_00");
				}
				if (component.StudentID == 30)
				{
					component.EnableRings();
				}
			}
			if (component.Student != null && component.Student.AoT)
			{
				component.Student.AttackOnTitan();
			}
			if (component.HomeScene)
			{
				component.Student.CharacterAnimation["idle_00"].time = 9f;
				component.Student.CharacterAnimation["idle_00"].speed = 0f;
				component.Hairstyle = 65;
			}
			if (!component.Eighties)
			{
				CosmeticTaskCheck(int_0);
			}
			OverrideTurnOnCheck(int_0);
			if (!component.Male && component.StudentID != 90)
			{
				component.EyeTypeCheck();
			}
			if (component.Kidnapped || (component.Student.Slave && !component.Student.FragileSlave))
			{
				component.WearBurlapSack();
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00027418 File Offset: 0x00025618
		private void CosmeticTaskCheck(int int_0)
		{
			CosmeticScript component = base.gameObject.GetComponent<CosmeticScript>();
			if (component.StudentID == 37)
			{
				if (TaskGlobals.GetTaskStatus(37) < 3)
				{
					if (!component.TakingPortrait)
					{
						component.MaleAccessories[1].SetActive(value: false);
					}
					else
					{
						component.MaleAccessories[1].SetActive(value: true);
					}
				}
			}
			else if (component.StudentID == 11 && component.PhoneCharms.Length != 0)
			{
				if (TaskGlobals.GetTaskStatus(11) < 3)
				{
					component.PhoneCharms[11].SetActive(value: false);
				}
				else
				{
					component.PhoneCharms[11].SetActive(value: true);
				}
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000274A8 File Offset: 0x000256A8
		private void OverrideTurnOnCheck(int int_0)
		{
			CosmeticScript component = base.gameObject.GetComponent<CosmeticScript>();
			if (!component.TurnedOn && !component.TakingPortrait && component.Male)
			{
				if (component.Hairstyle != 46 && component.Hairstyle != 48 && component.Hairstyle != 49)
				{
					if ((component.Accessory <= 1 || component.Accessory >= 10) && component.Accessory != 13 && component.Accessory != 17)
					{
						if (component.Student.Persona == PersonaType.TeachersPet)
						{
							component.LoveManager.Targets[component.LoveManager.TotalTargets] = component.Student.Head;
							component.LoveManager.TotalTargets++;
						}
						else if (component.EyewearID > 0)
						{
							component.LoveManager.Targets[component.LoveManager.TotalTargets] = component.Student.Head;
							component.LoveManager.TotalTargets++;
						}
						else if (component.SkinColor == 8)
						{
							component.LoveManager.Targets[component.LoveManager.TotalTargets] = component.Student.Head;
							component.LoveManager.TotalTargets++;
						}
					}
					else
					{
						component.LoveManager.Targets[component.LoveManager.TotalTargets] = component.Student.Head;
						component.LoveManager.TotalTargets++;
					}
				}
				else
				{
					component.LoveManager.Targets[component.LoveManager.TotalTargets] = component.Student.Head;
					component.LoveManager.TotalTargets++;
				}
			}
			component.TurnedOn = true;
		}

		// Token: 0x0400010E RID: 270
		public HomePrisonerChanScript HomePrisonerChan;

		// Token: 0x0400010F RID: 271
		public ExtraJsonScript ExtraJson;
	}
}

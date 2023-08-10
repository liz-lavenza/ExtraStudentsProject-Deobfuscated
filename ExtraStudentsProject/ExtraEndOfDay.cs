using System;
using System.Collections.Generic;
using System.Text;
using ExtraStudentsProject.ExtraStudentsOpenLibrary;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExtraStudentsProject
{
	// Token: 0x02000011 RID: 17
	internal class ExtraEndOfDay : MonoBehaviour
	{
		// Token: 0x06000054 RID: 84 RVA: 0x00004C98 File Offset: 0x00002E98
		private void Start()
		{
			StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			Police = StudentManager.Police.GetComponent<ExtraPoliceScript>();
			EndOfDay = base.gameObject.GetComponent<EndOfDayScript>();
			EndOfDay.enabled = false;
			ExtraJSON = StudentManager.JSON.GetComponent<ExtraJsonScript>();
			ExtraVoidGoddess = EndOfDay.VoidGoddess.GetComponent<ExtraVoidGoddess>();
			Debug.Log("The End-of-Day ''Extra'' GameObject has just fired its Start() function.");
			EndOfDay.VoidGoddess.Start();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004D34 File Offset: 0x00002F34
		private void Update()
		{
			EndOfDay.Yandere.UpdateSlouch();
			if (Input.GetKeyDown("space"))
			{
				EndOfDay.EndOfDayDarkness.color = new Color(0f, 0f, 0f, 1f);
				EndOfDay.Darken = true;
			}
			if (EndOfDay.EndOfDayDarkness.color.a == 0f && Input.GetButtonDown("A"))
			{
				EndOfDay.Darken = true;
			}
			if (EndOfDay.Darken)
			{
				EndOfDay.EndOfDayDarkness.color = new Color(EndOfDay.EndOfDayDarkness.color.r, EndOfDay.EndOfDayDarkness.color.g, EndOfDay.EndOfDayDarkness.color.b, Mathf.MoveTowards(EndOfDay.EndOfDayDarkness.color.a, 1f, Time.deltaTime * 2f));
				if (EndOfDay.EndOfDayDarkness.color.a == 1f)
				{
					if (EndOfDay.Senpai == null && EndOfDay.StudentManager.Students[1] != null)
					{
						EndOfDay.Senpai = EndOfDay.StudentManager.Students[1];
						EndOfDay.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						EndOfDay.Senpai.CharacterAnimation.enabled = true;
					}
					if (EndOfDay.Senpai != null)
					{
						EndOfDay.Senpai.gameObject.SetActive(value: false);
					}
					if (EndOfDay.Rival == null && EndOfDay.StudentManager.Students[EndOfDay.StudentManager.RivalID] != null)
					{
						EndOfDay.Rival = EndOfDay.StudentManager.Students[EndOfDay.StudentManager.RivalID];
						EndOfDay.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						EndOfDay.Rival.CharacterAnimation.enabled = true;
					}
					if (EndOfDay.Rival != null)
					{
						EndOfDay.Rival.gameObject.SetActive(value: false);
					}
					EndOfDay.Yandere.transform.parent = null;
					EndOfDay.Yandere.transform.position = new Vector3(0f, 0f, -75f);
					EndOfDay.EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
					EndOfDay.EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0f);
					if (EndOfDay.KidnappedVictim != null)
					{
						EndOfDay.KidnappedVictim.gameObject.SetActive(value: false);
					}
					if (EndOfDay.StudentManager.Students[EndOfDay.StudentManager.SuitorID] != null)
					{
						EndOfDay.StudentManager.Students[EndOfDay.StudentManager.SuitorID].gameObject.SetActive(value: false);
					}
					EndOfDay.CardboardBox.parent = null;
					EndOfDay.Yandere.LifeNotePen.SetActive(value: false);
					EndOfDay.SearchingCop.SetActive(value: false);
					EndOfDay.MurderScene.SetActive(value: false);
					EndOfDay.Cops.SetActive(value: false);
					EndOfDay.TabletCop.SetActive(value: false);
					EndOfDay.ShruggingCops.SetActive(value: false);
					EndOfDay.SecuritySystemScene.SetActive(value: false);
					EndOfDay.OpenTranqCase.SetActive(value: false);
					EndOfDay.ClosedTranqCase.SetActive(value: false);
					EndOfDay.GaudyRing.SetActive(value: false);
					EndOfDay.AnswerSheet.SetActive(value: false);
					EndOfDay.Fence.SetActive(value: false);
					EndOfDay.SCP.SetActive(value: false);
					EndOfDay.Headmaster.SetActive(value: false);
					EndOfDay.ArrestingCops.SetActive(value: false);
					EndOfDay.Mask.SetActive(value: false);
					EndOfDay.EyeWitnessScene.SetActive(value: false);
					EndOfDay.ScaredCops.SetActive(value: false);
					EndOfDay.EightiesGaudyRing.SetActive(value: false);
					if (EndOfDay.WitnessList[1] != null)
					{
						EndOfDay.WitnessList[1].gameObject.SetActive(value: false);
					}
					if (EndOfDay.WitnessList[2] != null)
					{
						EndOfDay.WitnessList[2].gameObject.SetActive(value: false);
					}
					if (EndOfDay.WitnessList[3] != null)
					{
						EndOfDay.WitnessList[3].gameObject.SetActive(value: false);
					}
					if (EndOfDay.WitnessList[4] != null)
					{
						EndOfDay.WitnessList[4].gameObject.SetActive(value: false);
					}
					if (EndOfDay.WitnessList[5] != null)
					{
						EndOfDay.WitnessList[5].gameObject.SetActive(value: false);
					}
					if (EndOfDay.Patsy != null)
					{
						EndOfDay.Patsy.gameObject.SetActive(value: false);
					}
					if (!EndOfDay.GameOver)
					{
						EndOfDay.Darken = false;
						UpdateScene();
					}
					else
					{
						EndOfDay.Heartbroken.transform.parent.transform.parent = null;
						EndOfDay.Heartbroken.transform.parent.gameObject.SetActive(value: true);
						EndOfDay.Heartbroken.Cursor.HeartbrokenCamera.depth = 6f;
						if (EndOfDay.Police.Deaths + PlayerGlobals.Kills > 50)
						{
							EndOfDay.Heartbroken.Noticed = true;
						}
						else
						{
							EndOfDay.Heartbroken.Noticed = false;
							EndOfDay.Heartbroken.Arrested = true;
						}
						EndOfDay.MainCamera.SetActive(value: false);
						base.gameObject.SetActive(value: false);
						Time.timeScale = 1f;
					}
					if (EndOfDay.RivalName == "")
					{
						if (EndOfDay.StudentManager.Eighties)
						{
							EndOfDay.Protagonist = "Ryoba";
							EndOfDay.RivalName = EndOfDay.EightiesRivalNames[DateGlobals.Week];
						}
						else
						{
							EndOfDay.RivalName = EndOfDay.RivalNames[DateGlobals.Week];
						}
					}
					if (EndOfDay.Yandere.VtuberID > 0)
					{
						EndOfDay.Protagonist = EndOfDay.VtuberNames[EndOfDay.Yandere.VtuberID];
					}
				}
			}
			else
			{
				EndOfDay.EndOfDayDarkness.color = new Color(EndOfDay.EndOfDayDarkness.color.r, EndOfDay.EndOfDayDarkness.color.g, EndOfDay.EndOfDayDarkness.color.b, Mathf.MoveTowards(EndOfDay.EndOfDayDarkness.color.a, 0f, Time.deltaTime * 2f));
			}
			AudioSource component = GetComponent<AudioSource>();
			component.volume = Mathf.MoveTowards(component.volume, 1f, Time.deltaTime * 2f);
			if (EndOfDay.WitnessList[2] != null)
			{
				EndOfDay.WitnessList[2].CharacterAnimation.Play(EndOfDay.WitnessList[2].IdleAnim);
			}
			if (EndOfDay.WitnessList[3] != null)
			{
				EndOfDay.WitnessList[3].CharacterAnimation.Play(EndOfDay.WitnessList[3].IdleAnim);
			}
			if (EndOfDay.WitnessList[4] != null)
			{
				EndOfDay.WitnessList[4].CharacterAnimation.Play(EndOfDay.WitnessList[4].IdleAnim);
			}
			if (EndOfDay.WitnessList[5] != null)
			{
				EndOfDay.WitnessList[5].CharacterAnimation.Play(EndOfDay.WitnessList[5].IdleAnim);
			}
			if (EndOfDay.Phase == 17)
			{
				EndOfDay.EODCamera.position = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].position;
				EndOfDay.EODCamera.eulerAngles = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].eulerAngles;
				EndOfDay.EODCamera.Translate(Vector3.forward * 0f, Space.Self);
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000571C File Offset: 0x0000391C
		public void UpdateScene()
		{
			EndOfDay.Label.color = new Color(0f, 0f, 0f, 1f);
			if (!EndOfDay.PoliceArrived)
			{
				return;
			}
			for (int i = 0; i < EndOfDay.Yandere.Weapon.Length; i++)
			{
				if (EndOfDay.Yandere.Weapon[i] != null && EndOfDay.Yandere.Weapon[i].Bloody)
				{
					EndOfDay.Yandere.Weapon[i].Drop();
				}
			}
			if (!EndOfDay.WeaponsChecked)
			{
				EndOfDay.WeaponManager.CheckWeapons();
				EndOfDay.WeaponsChecked = true;
			}
			EndOfDay.ID = 0;
			while (EndOfDay.ID < EndOfDay.WeaponManager.Weapons.Length)
			{
				if (EndOfDay.WeaponManager.Weapons[EndOfDay.ID] != null)
				{
					EndOfDay.WeaponManager.Weapons[EndOfDay.ID].gameObject.SetActive(value: false);
				}
				EndOfDay.ID++;
			}
			if (Input.GetKeyDown(KeyCode.Backspace))
			{
				Finish();
			}
			if (EndOfDay.Phase == 1)
			{
				Time.timeScale = 1f;
				GameGlobals.PoliceYesterday = true;
				EndOfDay.CopAnimation[1]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
				EndOfDay.CopAnimation[2]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
				EndOfDay.CopAnimation[3]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
				EndOfDay.Counselor.LectureID = 0;
				EndOfDay.Cops.SetActive(value: true);
				bool flag = false;
				if (EndOfDay.Yandere.Egg && !flag)
				{
					EndOfDay.Label.text = "The police arrive at school.";
					EndOfDay.Phase = 999;
					return;
				}
				if (EndOfDay.Police.PoisonScene)
				{
					EndOfDay.Label.text = "The police and the paramedics arrive at school.";
					EndOfDay.Phase = 103;
					return;
				}
				if (EndOfDay.Police.DrownVictims == 1)
				{
					EndOfDay.Label.text = "The police arrive at school.";
					EndOfDay.Phase = 104;
					return;
				}
				if (EndOfDay.Police.ElectroScene)
				{
					EndOfDay.Label.text = "The police arrive at school.";
					EndOfDay.Phase = 105;
					return;
				}
				if (EndOfDay.Police.MurderSuicideScene)
				{
					EndOfDay.Label.text = "The police arrive at school, and discover what appears to be the scene of a murder-suicide.";
					EndOfDay.Phase++;
					return;
				}
				EndOfDay.Label.text = "The police arrive at school.";
				if (EndOfDay.Police.SuicideScene)
				{
					EndOfDay.Phase = 102;
				}
				else
				{
					EndOfDay.Phase++;
				}
			}
			else if (EndOfDay.Phase == 2)
			{
				if (EndOfDay.Police.Corpses != 0)
				{
					Debug.Log("Corpses were present at school.");
					EndOfDay.MurderScene.SetActive(value: true);
					List<string> list = new List<string>();
					RagdollScript[] corpseList = EndOfDay.Police.CorpseList;
					foreach (RagdollScript ragdollScript in corpseList)
					{
						if (!(ragdollScript != null) || ragdollScript.Disposed)
						{
							continue;
						}
						if (ragdollScript.Student.StudentID == EndOfDay.StudentManager.RivalID)
						{
							Debug.Log("The rival died, and now the game is determining exactly how she died.");
							EndOfDay.RivalEliminationMethod = RivalEliminationType.Murdered;
							if (ragdollScript.Student.Electrified || ragdollScript.Student.Electrocuted || ragdollScript.Student.DeathType == DeathType.Burning || ragdollScript.Student.DeathType == DeathType.Weight || ragdollScript.Student.DeathType == DeathType.Drowning || ragdollScript.Student.DeathType == DeathType.Poison || ragdollScript.Student.DeathType == DeathType.Explosion)
							{
								EndOfDay.RivalEliminationMethod = RivalEliminationType.Accident;
							}
							if (ragdollScript.Student.DeathType == DeathType.Burning)
							{
								GameGlobals.SpecificEliminationID = 5;
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Burn", 1);
								}
							}
							else if (ragdollScript.Student.DeathType == DeathType.Electrocution)
							{
								Debug.Log("The game should now be informing the Content Checklist that the player has performed an electrocution.");
								GameGlobals.SpecificEliminationID = 8;
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Electrocute", 1);
								}
							}
							else if (ragdollScript.Student.DeathType == DeathType.Weight)
							{
								GameGlobals.SpecificEliminationID = 6;
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Crush", 1);
								}
							}
							else if (ragdollScript.Student.DeathType == DeathType.Drowning)
							{
								Debug.Log("The rival drowned.");
								if (EndOfDay.PoolEvent)
								{
									Debug.Log("The player eliminated the rival during a pool event.");
									GameGlobals.SpecificEliminationID = 16;
									if (!GameGlobals.Debug)
									{
										PlayerPrefs.SetInt("Pool", 1);
									}
								}
								else
								{
									Debug.Log("The player did not eliminate the rival during a pool event.");
									GameGlobals.SpecificEliminationID = 7;
									if (!GameGlobals.Debug)
									{
										PlayerPrefs.SetInt("Drown", 1);
									}
								}
							}
							else if (ragdollScript.Decapitated)
							{
								GameGlobals.SpecificEliminationID = 10;
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Fan", 1);
								}
							}
							else if (ragdollScript.Student.DeathType == DeathType.Poison)
							{
								GameGlobals.SpecificEliminationID = 15;
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Poison", 1);
								}
							}
							else if (ragdollScript.Student.DeathType == DeathType.Falling)
							{
								GameGlobals.SpecificEliminationID = 17;
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Push", 1);
								}
							}
							else if (ragdollScript.Student.Hunted)
							{
								GameGlobals.SpecificEliminationID = 14;
								if (!GameGlobals.Debug)
								{
									if (ragdollScript.Student.MurderedByFragile)
									{
										PlayerPrefs.SetInt("DrivenToMurder", 1);
									}
									else
									{
										PlayerPrefs.SetInt("MurderSuicide", 1);
									}
								}
								Debug.Log("The game knows that the rival died as part of a murder-suicide.");
							}
							else if (ragdollScript.Student.DeathType == DeathType.Weapon)
							{
								Debug.Log("The game believes that the rival died from a ''Weapon''.");
								GameGlobals.SpecificEliminationID = 1;
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Attack", 1);
								}
							}
							else if (ragdollScript.Student.DeathType == DeathType.Explosion)
							{
								Debug.Log("The game knows that the rival died from an explosion.");
								GameGlobals.SpecificEliminationID = 20;
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Attack", 1);
								}
							}
							else
							{
								Debug.Log("We know that the rival died, but we didn't get any noteworthy information about her death...");
							}
						}
						else if (ragdollScript.Student.StudentID > 10 && ragdollScript.Student.StudentID < DateGlobals.Week + 10)
						{
							Debug.Log("A previous rival's corpse has been discovered.");
							EndOfDay.SetFormerRivalDeath(ragdollScript.Student.StudentID - 10, ragdollScript.Student);
						}
						EndOfDay.VictimArray[EndOfDay.Corpses] = ragdollScript.Student.StudentID;
						list.Add(ragdollScript.Student.Name);
						EndOfDay.Corpses++;
					}
					list.Sort();
					string text = "The police discover the corpse" + ((list.Count == 1) ? string.Empty : "s") + " of ";
					if (list.Count == 1)
					{
						EndOfDay.Label.text = text + list[0] + ".";
					}
					else if (list.Count == 2)
					{
						EndOfDay.Label.text = text + list[0] + " and " + list[1] + ".";
					}
					else if (list.Count < 6)
					{
						EndOfDay.Label.text = "The police discover multiple corpses on school grounds.";
						StringBuilder stringBuilder = new StringBuilder();
						for (int k = 0; k < list.Count - 1; k++)
						{
							stringBuilder.Append(list[k] + ", ");
						}
						stringBuilder.Append("and " + list[list.Count - 1] + ".");
						EndOfDay.Label.text = text + stringBuilder.ToString();
					}
					else
					{
						EndOfDay.Label.text = "The police discover more than five corpses on school grounds.";
					}
					EndOfDay.Phase++;
					return;
				}
				Debug.Log("Zero corpses were present at school.");
				if (!EndOfDay.Police.PoisonScene && !EndOfDay.Police.SuicideScene)
				{
					if (EndOfDay.Police.LimbParent.childCount <= 0 && EndOfDay.Police.GarbageParent.childCount <= 0)
					{
						EndOfDay.SearchingCop.SetActive(value: true);
						if (EndOfDay.Police.BloodParent.childCount - EndOfDay.ClothingWithRedPaint > 0)
						{
							EndOfDay.Label.text = "The police find mysterious blood stains, but are unable to locate any corpses on school grounds.";
						}
						else if (EndOfDay.ClothingWithRedPaint == 0)
						{
							EndOfDay.Label.text = "The police are unable to locate any corpses on school grounds.";
						}
						else
						{
							EndOfDay.Label.text = "The police find clothing that is stained with red paint, but are unable to locate any actual blood stains, and cannot locate any corpses, either.";
						}
					}
					else
					{
						if (EndOfDay.Police.LimbParent.childCount + EndOfDay.Police.GarbageParent.childCount == 1)
						{
							EndOfDay.Label.text = "The police find a severed body part at school.";
						}
						else
						{
							EndOfDay.Label.text = "The police find multiple severed body parts at school.";
						}
						EndOfDay.MurderScene.SetActive(value: true);
					}
					EndOfDay.Phase++;
				}
				else
				{
					EndOfDay.SearchingCop.SetActive(value: true);
					EndOfDay.Label.text = "The police are unable to locate any other corpses on school grounds.";
					EndOfDay.Phase++;
				}
			}
			else if (EndOfDay.Phase == 3)
			{
				if (EndOfDay.WeaponManager.MurderWeapons != 0)
				{
					EndOfDay.MurderWeapon = null;
					EndOfDay.ID = 0;
					while (EndOfDay.ID < EndOfDay.WeaponManager.Weapons.Length)
					{
						if (EndOfDay.MurderWeapon == null)
						{
							WeaponScript weaponScript = EndOfDay.WeaponManager.Weapons[EndOfDay.ID];
							if (weaponScript != null && weaponScript.Blood.enabled)
							{
								if (!weaponScript.AlreadyExamined)
								{
									EndOfDay.WeaponManager.MurderWeapons--;
									weaponScript.gameObject.SetActive(value: true);
									weaponScript.AlreadyExamined = true;
									EndOfDay.MurderWeapon = weaponScript;
									EndOfDay.WeaponID = EndOfDay.ID;
								}
								else
								{
									weaponScript.gameObject.SetActive(value: false);
								}
							}
						}
						EndOfDay.ID++;
					}
					List<string> list2 = new List<string>();
					EndOfDay.CurrentMurderWeaponKilledRival = false;
					EndOfDay.ID = 0;
					while (EndOfDay.ID < EndOfDay.MurderWeapon.Victims.Length)
					{
						if (EndOfDay.MurderWeapon.Victims[EndOfDay.ID])
						{
							if (EndOfDay.ID < 101)
							{
								list2.Add(EndOfDay.JSON.Students[EndOfDay.ID].Name);
							}
							else
							{
								list2.Add(ExtraJSON.Students[EndOfDay.ID].Name);
							}
							if (EndOfDay.MurderWeapon.Victims[EndOfDay.StudentManager.RivalID])
							{
								EndOfDay.CurrentMurderWeaponKilledRival = true;
							}
						}
						EndOfDay.ID++;
					}
					list2.Sort();
					EndOfDay.Victims = list2.Count;
					string text2 = EndOfDay.MurderWeapon.Name;
					string text3 = ((text2[text2.Length - 1] != 's') ? ("a " + text2.ToLower() + " that is") : (text2.ToLower() + " that are"));
					string text4 = "The police discover " + text3 + " stained with the blood of ";
					if (list2.Count == 1)
					{
						EndOfDay.Label.text = text4 + list2[0] + ".";
					}
					else if (list2.Count == 2)
					{
						EndOfDay.Label.text = text4 + list2[0] + " and " + list2[1] + ".";
					}
					else
					{
						StringBuilder stringBuilder2 = new StringBuilder();
						for (int l = 0; l < list2.Count - 1; l++)
						{
							stringBuilder2.Append(list2[l] + ", ");
						}
						stringBuilder2.Append("and " + list2[list2.Count - 1] + ".");
						EndOfDay.Label.text = text4 + stringBuilder2.ToString();
					}
					EndOfDay.Weapons++;
					EndOfDay.Phase++;
					EndOfDay.MurderWeapon.transform.parent = base.transform;
					EndOfDay.MurderWeapon.transform.localPosition = new Vector3(0.6f, 1.4f, -1.5f);
					EndOfDay.MurderWeapon.transform.localEulerAngles = new Vector3(-45f, 90f, -90f);
					EndOfDay.MurderWeapon.MyRigidbody.useGravity = false;
					EndOfDay.MurderWeapon.Rotate = true;
				}
				else
				{
					EndOfDay.ShruggingCops.SetActive(value: true);
					if (EndOfDay.Weapons == 0)
					{
						EndOfDay.Label.text = "The police are unable to locate any murder weapons.";
						EndOfDay.Phase += 2;
					}
					else
					{
						EndOfDay.Phase += 2;
						UpdateScene();
					}
				}
			}
			else if (EndOfDay.Phase == 4)
			{
				if (EndOfDay.MurderWeapon.FingerprintID == 0)
				{
					EndOfDay.ShruggingCops.SetActive(value: true);
					EndOfDay.Label.text = "The police find no fingerprints on the weapon.";
					EndOfDay.Phase = 3;
					return;
				}
				if (EndOfDay.MurderWeapon.FingerprintID == 100)
				{
					TeleportYandere();
					EndOfDay.Yandere.CharacterAnimation.Play("f02_disappointed_00");
					if (EndOfDay.Yandere.StudentManager.Eighties)
					{
						EndOfDay.Yandere.LoseGentleEyes();
					}
					EndOfDay.Label.text = "The police find " + EndOfDay.Protagonist + "'s fingerprints on the weapon.";
					EndOfDay.Phase = 100;
					return;
				}
				int fingerprintID = EndOfDay.WeaponManager.Weapons[EndOfDay.WeaponID].FingerprintID;
				EndOfDay.TabletCop.SetActive(value: true);
				EndOfDay.CopAnimation[4]["scienceTablet_00"].speed = 0f;
				if (fingerprintID < 101)
				{
					EndOfDay.TabletPortrait.material.mainTexture = EndOfDay.VoidGoddess.Portraits[fingerprintID].mainTexture;
					EndOfDay.Label.text = "The police find the fingerprints of " + EndOfDay.JSON.Students[fingerprintID].Name + " on the weapon.";
				}
				else
				{
					EndOfDay.TabletPortrait.material.mainTexture = ExtraVoidGoddess.VoidGoddess.Portraits[fingerprintID].mainTexture;
					EndOfDay.Label.text = "The police find the fingerprints of " + ExtraJSON.Students[fingerprintID].Name + " on the weapon.";
				}
				EndOfDay.Phase = 101;
			}
			else if (EndOfDay.Phase == 5)
			{
				if (EndOfDay.Police.PhotoEvidence > 0)
				{
					TeleportYandere();
					EndOfDay.Yandere.CharacterAnimation.Play("f02_disappointed_00");
					if (EndOfDay.Yandere.StudentManager.Eighties)
					{
						EndOfDay.Yandere.LoseGentleEyes();
					}
					EndOfDay.ShruggingCops.SetActive(value: false);
					EndOfDay.Label.text = "The police find a smartphone with photographic evidence of " + EndOfDay.Protagonist + " committing a crime.";
					EndOfDay.Phase = 100;
				}
				else
				{
					EndOfDay.Phase++;
					UpdateScene();
				}
			}
			else if (EndOfDay.Phase == 6)
			{
				if (!SchoolGlobals.HighSecurity)
				{
					EndOfDay.Phase++;
					UpdateScene();
					return;
				}
				EndOfDay.SecuritySystemScene.SetActive(value: true);
				if (!EndOfDay.SecuritySystem.Evidence)
				{
					EndOfDay.Label.text = "The police investigate the security camera recordings, but cannot find anything incriminating in the footage.";
					EndOfDay.Phase++;
				}
				else if (!EndOfDay.SecuritySystem.Masked)
				{
					EndOfDay.Label.text = "The police investigate the security camera recordings, and find incriminating footage of " + EndOfDay.Protagonist + ".";
					EndOfDay.Phase = 100;
				}
				else
				{
					EndOfDay.Label.text = "The police investigate the security camera recordings, and find footage of a suspicious masked person.";
					EndOfDay.Police.MaskReported = true;
					EndOfDay.Phase++;
				}
			}
			else if (EndOfDay.Phase == 7)
			{
				for (int m = 1; m < EndOfDay.StudentManager.Students.Length; m++)
				{
					if (EndOfDay.StudentManager.Students[m] != null && EndOfDay.StudentManager.Students[m].WitnessedMurder && EndOfDay.StudentManager.Students[m].Alive && EndOfDay.StudentManager.Students[m].Persona != PersonaType.Coward && EndOfDay.StudentManager.Students[m].Persona != PersonaType.Spiteful && EndOfDay.StudentManager.Students[m].Persona != PersonaType.Evil && EndOfDay.StudentManager.Students[m].Club != ClubType.Delinquent && !EndOfDay.StudentManager.Students[m].SawMask)
					{
						EndOfDay.EyeWitnesses++;
						EndOfDay.WitnessList[EndOfDay.EyeWitnesses] = EndOfDay.StudentManager.Students[m];
					}
				}
				if (EndOfDay.EyeWitnesses <= 0)
				{
					EndOfDay.Phase++;
					UpdateScene();
					return;
				}
				DisableThings(EndOfDay.WitnessList[1]);
				DisableThings(EndOfDay.WitnessList[2]);
				DisableThings(EndOfDay.WitnessList[3]);
				DisableThings(EndOfDay.WitnessList[4]);
				DisableThings(EndOfDay.WitnessList[5]);
				EndOfDay.WitnessList[1].transform.localPosition = Vector3.zero;
				if (EndOfDay.WitnessList[2] != null)
				{
					EndOfDay.WitnessList[2].transform.localPosition = new Vector3(-1f, 0f, -0.5f);
				}
				if (EndOfDay.WitnessList[3] != null)
				{
					EndOfDay.WitnessList[3].transform.localPosition = new Vector3(1f, 0f, -0.5f);
				}
				if (EndOfDay.WitnessList[4] != null)
				{
					EndOfDay.WitnessList[4].transform.localPosition = new Vector3(-2f, 0f, -1f);
				}
				if (EndOfDay.WitnessList[5] != null)
				{
					EndOfDay.WitnessList[5].transform.localPosition = new Vector3(1.5f, 0f, -1f);
				}
				if (EndOfDay.WitnessList[1].Male)
				{
					EndOfDay.WitnessList[1].CharacterAnimation.Play("carefreeTalk_02");
				}
				else
				{
					EndOfDay.WitnessList[1].CharacterAnimation.Play("f02_carefreeTalk_02");
				}
				EndOfDay.EyeWitnessScene.SetActive(value: true);
				if (EndOfDay.EyeWitnesses == 1)
				{
					EndOfDay.Label.text = "One student accuses " + EndOfDay.Protagonist + " of murder, but nobody else can corroborate that students' claims, so the police are unable to develop reasonable justification to arrest " + EndOfDay.Protagonist + ".";
					EndOfDay.Phase++;
				}
				else if (EndOfDay.EyeWitnesses < 5)
				{
					EndOfDay.Label.text = "Several students accuse " + EndOfDay.Protagonist + " of murder, but there are not enough witnesses to provide the police with reasonable justification to arrest her.";
					EndOfDay.Phase++;
				}
				else
				{
					EndOfDay.Label.text = "Numerous students accuse " + EndOfDay.Protagonist + " of murder, providing the police with enough justification to arrest her.";
					EndOfDay.Phase = 100;
				}
			}
			else if (EndOfDay.Phase == 8)
			{
				EndOfDay.ShruggingCops.SetActive(value: false);
				if (EndOfDay.Yandere.Sanity > 33.33333f)
				{
					if ((EndOfDay.Yandere.Bloodiness > 0f && !EndOfDay.Yandere.RedPaint) || (EndOfDay.Yandere.Gloved && EndOfDay.Yandere.Gloves.Blood.enabled))
					{
						if (EndOfDay.Arrests == 0)
						{
							TeleportYandere();
							EndOfDay.Yandere.CharacterAnimation.Play("f02_disappointed_00");
							if (EndOfDay.Yandere.StudentManager.Eighties)
							{
								EndOfDay.Yandere.LoseGentleEyes();
							}
							EndOfDay.Label.text = "The police notice that " + EndOfDay.Protagonist + "'s clothing is bloody. They confirm that the blood is not hers. " + EndOfDay.Protagonist + " is unable to convince the police that she did not commit murder.";
							EndOfDay.Phase = 100;
						}
						else
						{
							TeleportYandere();
							EndOfDay.Yandere.CharacterAnimation["YandereConfessionRejected"].time = 4f;
							EndOfDay.Yandere.CharacterAnimation.Play("YandereConfessionRejected");
							EndOfDay.Label.text = "The police notice that " + EndOfDay.Protagonist + "'s clothing is bloody. They confirm that the blood is not hers. " + EndOfDay.Protagonist + " is able to convince the police that she was splashed with blood while witnessing a murder.";
							if (!EndOfDay.TranqCase.Occupied)
							{
								EndOfDay.Phase += 2;
							}
							else
							{
								EndOfDay.Phase++;
							}
						}
					}
					else if (EndOfDay.Police.BloodyClothing - EndOfDay.ClothingWithRedPaint > 0)
					{
						TeleportYandere();
						EndOfDay.Yandere.CharacterAnimation.Play("f02_disappointed_00");
						if (EndOfDay.Yandere.StudentManager.Eighties)
						{
							EndOfDay.Yandere.LoseGentleEyes();
						}
						EndOfDay.Label.text = "The police find bloody clothing that has traces of " + EndOfDay.Protagonist + "'s DNA. " + EndOfDay.Protagonist + " is unable to convince the police that she did not commit murder.";
						EndOfDay.Phase = 100;
					}
					else
					{
						TeleportYandere();
						EndOfDay.Yandere.CharacterAnimation["YandereConfessionRejected"].time = 4f;
						EndOfDay.Yandere.CharacterAnimation.Play("YandereConfessionRejected");
						EndOfDay.Label.text = "The police question all students in the school, including " + EndOfDay.Protagonist + ". The police are unable to link " + EndOfDay.Protagonist + " to any crimes.";
						if (!EndOfDay.TranqCase.Occupied)
						{
							EndOfDay.Phase += 2;
						}
						else if (EndOfDay.TranqCase.VictimID == EndOfDay.ArrestID)
						{
							EndOfDay.Phase += 2;
						}
						else
						{
							EndOfDay.Phase++;
						}
						if (EndOfDay.Yandere.StudentManager.Eighties)
						{
							EndOfDay.Yandere.LoseGentleEyes();
						}
					}
				}
				else
				{
					TeleportYandere();
					EndOfDay.Yandere.CharacterAnimation.Play("f02_disappointed_00");
					if (EndOfDay.Yandere.StudentManager.Eighties)
					{
						EndOfDay.Yandere.LoseGentleEyes();
					}
					if (EndOfDay.Yandere.Bloodiness == 0f)
					{
						EndOfDay.Label.text = "The police question " + EndOfDay.Protagonist + ", who exhibits extremely unusual behavior. The police decide to investigate " + EndOfDay.Protagonist + " further, and eventually learn of her crimes.";
						EndOfDay.Phase = 100;
					}
					else
					{
						EndOfDay.Label.text = "The police notice that " + EndOfDay.Protagonist + " is covered in blood and exhibiting extremely unusual behavior. The police decide to investigate " + EndOfDay.Protagonist + " further, and eventually learn of her crimes.";
						EndOfDay.Phase = 100;
					}
				}
			}
			else if (EndOfDay.Phase == 9)
			{
				EndOfDay.KidnappedVictim = EndOfDay.StudentManager.Students[EndOfDay.TranqCase.VictimID];
				EndOfDay.KidnappedVictim.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				EndOfDay.KidnappedVictim.CharacterAnimation.enabled = true;
				EndOfDay.KidnappedVictim.gameObject.SetActive(value: true);
				EndOfDay.KidnappedVictim.Ragdoll.Zs.SetActive(value: false);
				EndOfDay.KidnappedVictim.transform.parent = base.transform;
				EndOfDay.KidnappedVictim.transform.localPosition = new Vector3(0f, 0.145f, 0f);
				EndOfDay.KidnappedVictim.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
				EndOfDay.KidnappedVictim.CharacterAnimation.Play("f02_sit_06");
				EndOfDay.KidnappedVictim.WhiteQuestionMark.SetActive(value: true);
				EndOfDay.OpenTranqCase.SetActive(value: true);
				if (EndOfDay.TranqCase.VictimID < 101)
				{
					EndOfDay.Label.text = "The police discover " + EndOfDay.JSON.Students[EndOfDay.TranqCase.VictimID].Name + " inside of a musical instrument case. However, she is unable to recall how she got inside of the case. The police are unable to determine what happened.";
				}
				else
				{
					EndOfDay.Label.text = "The police discover " + ExtraJSON.Students[EndOfDay.TranqCase.VictimID].Name + " inside of a musical instrument case. However, she is unable to recall how she got inside of the case. The police are unable to determine what happened.";
				}
				StudentGlobals.SetStudentKidnapped(EndOfDay.TranqCase.VictimID, value: false);
				StudentGlobals.SetStudentMissing(EndOfDay.TranqCase.VictimID, value: false);
				EndOfDay.TranqCase.VictimClubType = ClubType.None;
				EndOfDay.TranqCase.VictimID = 0;
				EndOfDay.TranqCase.Occupied = false;
				EndOfDay.Phase++;
			}
			else if (EndOfDay.Phase == 10)
			{
				if (EndOfDay.Police.MaskReported)
				{
					EndOfDay.Mask.SetActive(value: true);
					GameGlobals.MasksBanned = true;
					if (EndOfDay.SecuritySystem.Masked)
					{
						EndOfDay.Label.text = "In security camera footage, the killer was wearing a mask. As a result, the police are unable to gather meaningful information about the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward.";
					}
					else
					{
						EndOfDay.Label.text = "Witnesses state that the killer was wearing a mask. As a result, the police are unable to gather meaningful information about the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward.";
					}
					EndOfDay.Police.MaskReported = false;
					EndOfDay.Phase++;
				}
				else
				{
					EndOfDay.Phase++;
					UpdateScene();
				}
			}
			else if (EndOfDay.Phase == 11)
			{
				EndOfDay.Cops.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				EndOfDay.Cops.SetActive(value: true);
				if (EndOfDay.Arrests == 0)
				{
					if (EndOfDay.DeadPerps == 0)
					{
						EndOfDay.Label.text = "The police do not have enough evidence to perform an arrest. The police investigation ends, and students are free to leave.";
					}
					else if (EndOfDay.Police.MurderSuicideScene)
					{
						EndOfDay.Label.text = "The police conclude that a murder-suicide took place, but are unable to take any further action. The police investigation ends, and students are free to leave.";
					}
					else
					{
						EndOfDay.Label.text = "The police believe that they know the identity of the killer, but they cannot locate the suspect at school. The police leave to search for the person that they believe is the killer. The police investigation ends, and students are free to leave.";
					}
				}
				else if (EndOfDay.Arrests == 1)
				{
					EndOfDay.Label.text = "The police believe that they have arrested the perpetrator of the crime. The police investigation ends, and students are free to leave.";
				}
				else
				{
					EndOfDay.Label.text = "The police believe that they have arrested the perpetrators of the crimes. The police investigation ends, and students are free to leave.";
				}
				if (!EndOfDay.StudentManager.RivalEliminated && EndOfDay.RivalEliminationMethod == RivalEliminationType.None)
				{
					if (DateGlobals.Weekday == DayOfWeek.Friday)
					{
						EndOfDay.Phase = 24;
					}
					else
					{
						EndOfDay.Phase += 2;
					}
				}
				else
				{
					EndOfDay.Phase++;
				}
			}
			else if (EndOfDay.Phase == 12)
			{
				EndOfDay.Senpai.enabled = false;
				EndOfDay.Senpai.transform.parent = base.transform;
				EndOfDay.Senpai.gameObject.SetActive(value: true);
				EndOfDay.Senpai.transform.localPosition = new Vector3(0f, 0f, 0f);
				EndOfDay.Senpai.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				EndOfDay.Senpai.EmptyHands();
				Physics.SyncTransforms();
				string text5 = "";
				if (EndOfDay.Yandere.Egg && EndOfDay.RivalEliminationMethod == RivalEliminationType.None)
				{
					EndOfDay.RivalEliminationMethod = RivalEliminationType.Murdered;
				}
				if (EndOfDay.RivalEliminationMethod == RivalEliminationType.None)
				{
					EndOfDay.Label.text = "Your Senpai feels a growing sense of concern that the school may not be safe.";
				}
				else if (EndOfDay.RivalEliminationMethod != RivalEliminationType.Murdered && EndOfDay.RivalEliminationMethod != RivalEliminationType.MurderedWitnessed && EndOfDay.RivalEliminationMethod != RivalEliminationType.Accident && EndOfDay.RivalEliminationMethod != RivalEliminationType.SuicideFake)
				{
					EndOfDay.Senpai.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
					if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Arrested)
					{
						EndOfDay.Senpai.CharacterAnimation["refuse_02"].speed = 0.5f;
						EndOfDay.Senpai.CharacterAnimation.Play("refuse_02");
						EndOfDay.Label.text = "Senpai is disgusted to learn that " + EndOfDay.RivalName + " would actually commit murder. He is deeply disappointed in her.";
					}
					else if (EndOfDay.RivalEliminationMethod != RivalEliminationType.Befriended && EndOfDay.RivalEliminationMethod != RivalEliminationType.Matchmade)
					{
						if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Expelled)
						{
							EndOfDay.Senpai.CharacterAnimation.Play("surprisedPose_00");
							EndOfDay.Label.text = "Senpai is shocked to learn that " + EndOfDay.RivalName + " has been expelled. He is deeply disappointed in her.";
						}
						else if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Ruined)
						{
							EndOfDay.Senpai.CharacterAnimation["refuse_02"].speed = 0.5f;
							EndOfDay.Senpai.CharacterAnimation.Play("refuse_02");
							EndOfDay.Label.text = "Senpai is disturbed by the rumors circulating about " + EndOfDay.RivalName + ". He is deeply disappointed in her.";
						}
						else if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Rejected)
						{
							EndOfDay.Senpai.CharacterAnimation.Play(EndOfDay.Senpai.BulliedIdleAnim);
							EndOfDay.Label.text = "Senpai feels guilty for turning down " + EndOfDay.RivalName + "'s feelings, but also he knows that he cannot take back what has been said.";
						}
						else if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Vanished)
						{
							EndOfDay.Senpai.CharacterAnimation.Play(EndOfDay.Senpai.BulliedIdleAnim);
							EndOfDay.Label.text = "Senpai is concerned about the sudden disappearance of " + EndOfDay.RivalName + ". His mental stability has been slightly affected.";
						}
					}
					else
					{
						EndOfDay.Senpai.CharacterAnimation.Play(EndOfDay.Senpai.BulliedIdleAnim);
						EndOfDay.Label.text = "Senpai notices that " + EndOfDay.RivalName + " is distancing herself from him. He feels a little sad about it, but he accepts it.";
					}
				}
				else if (!EndOfDay.StudentManager.Eighties)
				{
					EndOfDay.Senpai.CharacterAnimation.Play("kneelCry_00");
					if (DateGlobals.Weekday != DayOfWeek.Friday)
					{
						text5 = "\nSenpai will stay home from school for one day to mourn her death.";
						GameGlobals.SenpaiMourning = true;
					}
					EndOfDay.Label.text = "Senpai is absolutely devastated by the death of his childhood friend. His mental stability has been greatly affected." + text5;
				}
				else
				{
					EndOfDay.Senpai.CharacterAnimation.Play(EndOfDay.Senpai.BulliedIdleAnim);
					EndOfDay.Label.text = "Senpai is deeply saddened by the death of his friend.";
				}
				EndOfDay.Phase++;
			}
			else if (EndOfDay.Phase == 13)
			{
				EndOfDay.Senpai.enabled = false;
				EndOfDay.Senpai.transform.parent = base.transform;
				EndOfDay.Senpai.gameObject.SetActive(value: true);
				EndOfDay.Senpai.transform.localPosition = new Vector3(0f, 0f, 0f);
				EndOfDay.Senpai.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
				EndOfDay.Senpai.EmptyHands();
				if (EndOfDay.StudentManager.RivalEliminated)
				{
					EndOfDay.Senpai.CharacterAnimation.Play(EndOfDay.Senpai.BulliedWalkAnim);
				}
				else
				{
					EndOfDay.Senpai.CharacterAnimation.Play(EndOfDay.Senpai.WalkAnim);
				}
				EndOfDay.Yandere.LookAt.enabled = true;
				EndOfDay.Yandere.MyController.enabled = false;
				EndOfDay.Yandere.transform.parent = base.transform;
				EndOfDay.Yandere.transform.localPosition = new Vector3(2.5f, 0f, 2.5f);
				EndOfDay.Yandere.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
				EndOfDay.Yandere.CharacterAnimation.Play(EndOfDay.Yandere.WalkAnim);
				EndOfDay.Label.text = EndOfDay.Protagonist + " stalks Senpai until he has returned home, and then returns to her own home.";
				if (GameGlobals.SenpaiMourning)
				{
					EndOfDay.Senpai.gameObject.SetActive(value: false);
					EndOfDay.Yandere.LookAt.enabled = false;
					EndOfDay.Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
					EndOfDay.Yandere.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
					EndOfDay.Label.text = EndOfDay.Protagonist + " returns home, thinking of Senpai every step of the way.";
				}
				Physics.SyncTransforms();
				EndOfDay.Phase++;
			}
			else if (EndOfDay.Phase == 14)
			{
				Debug.Log("We're currently in the End-of-Day sequence, checking to see if the Counselor has to lecture anyone.");
				if (!StudentGlobals.GetStudentDying(EndOfDay.StudentManager.RivalID) && !StudentGlobals.GetStudentDead(EndOfDay.StudentManager.RivalID) && !StudentGlobals.GetStudentArrested(EndOfDay.StudentManager.RivalID))
				{
					Debug.Log("The current rival is not dying, dead, or arrested.");
					if (EndOfDay.Counselor.LectureID > 0)
					{
						EndOfDay.Yandere.gameObject.SetActive(value: false);
						for (int n = 1; n < StudentManager.Students.Length; n++)
						{
							EndOfDay.StudentManager.DisableStudent(n);
						}
						EndOfDay.EODCamera.position = new Vector3(-18.5f, 1f, 6.5f);
						EndOfDay.EODCamera.eulerAngles = new Vector3(0f, -45f, 0f);
						EndOfDay.EODCamera.Translate(EndOfDay.EODCamera.transform.forward * 0.3f);
						EndOfDay.Counselor.Lecturing = true;
						base.enabled = false;
						Debug.Log("The counselor is going to lecture somebody! Exiting End-of-Day sequence.");
					}
					else
					{
						EndOfDay.Phase++;
						UpdateScene();
					}
				}
				else
				{
					EndOfDay.Phase++;
					UpdateScene();
				}
			}
			else if (EndOfDay.Phase == 15)
			{
				EndOfDay.EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
				EndOfDay.EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0f);
				EndOfDay.TextWindow.SetActive(value: true);
				if (EndOfDay.Counselor.MustReturnStolenRing)
				{
					if (!EndOfDay.StudentManager.Eighties)
					{
						EndOfDay.GaudyRing.SetActive(value: true);
					}
					else
					{
						EndOfDay.EightiesGaudyRing.SetActive(value: true);
					}
					if (!EndOfDay.StudentManager.Eighties)
					{
						EndOfDay.Label.text = "The guidance counselor returns Sakyu's stolen ring to her. Sakyu decides to stop bringing the ring to school.";
						GameGlobals.RingStolen = true;
					}
					else
					{
						EndOfDay.Label.text = "The guidance counselor returns Himeko's stolen ring to her. Having her ring stolen does not affect Himeko's decision to wear expensive jewelry at school every day.";
					}
					EndOfDay.Counselor.MustReturnStolenRing = false;
				}
				else if (SchemeGlobals.GetSchemeStage(2) == 3)
				{
					EndOfDay.GaudyRing.SetActive(value: true);
					if (!StudentGlobals.GetStudentDying(EndOfDay.StudentManager.RivalID) && !StudentGlobals.GetStudentDead(EndOfDay.StudentManager.RivalID) && !StudentGlobals.GetStudentArrested(EndOfDay.StudentManager.RivalID))
					{
						EndOfDay.Label.text = EndOfDay.RivalName + " discovers a ring inside of her book bag. She returns the ring to its owner.";
					}
					else
					{
						EndOfDay.Label.text = "Sakyu Basu will never recover her stolen ring.";
					}
					SchemeGlobals.SetSchemeStage(2, 100);
					GameGlobals.RingStolen = true;
				}
				else
				{
					EndOfDay.Phase++;
					UpdateScene();
				}
			}
			else if (EndOfDay.Phase == 16)
			{
				if (EndOfDay.Police.Deaths + PlayerGlobals.Kills > 50)
				{
					EndOfDay.EODCamera.position = new Vector3(-6f, 0.15f, -49f);
					EndOfDay.EODCamera.eulerAngles = new Vector3(-22.5f, 22.5f, 0f);
					EndOfDay.Label.text = "More than half of the school's population is dead. For the safety of the remaining students, the headmaster of Akademi makes the decision to shut down the school. Senpai enrolls in a school far away. " + EndOfDay.Protagonist + " will not be able to follow him, and another girl will steal his heart. " + EndOfDay.Protagonist + " has permanently lost her chance to be with Senpai.";
					EndOfDay.Heartbroken.NoSnap = true;
					EndOfDay.GameOver = true;
				}
				else
				{
					EndOfDay.Phase++;
					UpdateScene();
				}
			}
			else if (EndOfDay.Phase == 17)
			{
				EndOfDay.ClubLimit = EndOfDay.ClubArray.Length;
				if (!GameGlobals.Eighties)
				{
					EndOfDay.ClubLimit--;
				}
				EndOfDay.ClubClosed = false;
				EndOfDay.ClubKicked = false;
				EndOfDay.DistanceToMoveForward = 1.2f;
				if (EndOfDay.ClubID < EndOfDay.ClubLimit)
				{
					if (EndOfDay.StudentManager.Eighties && EndOfDay.ClubID == 11)
					{
						EndOfDay.ClubID++;
					}
					if (!ClubGlobals.GetClubClosed(EndOfDay.ClubArray[EndOfDay.ClubID]))
					{
						EndOfDay.ClubManager.CheckClub(EndOfDay.ClubArray[EndOfDay.ClubID]);
						if (EndOfDay.ClubManager.ClubMembers < 5)
						{
							EndOfDay.EODCamera.position = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].position;
							EndOfDay.EODCamera.eulerAngles = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].eulerAngles;
							EndOfDay.EODCamera.Translate(Vector3.forward * EndOfDay.DistanceToMoveForward, Space.Self);
							ClubGlobals.SetClubClosed(EndOfDay.ClubArray[EndOfDay.ClubID], value: true);
							if (EndOfDay.ClubID != 11)
							{
								EndOfDay.Label.text = "The " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + " no longer has enough members to remain operational. The school forces the club to disband.";
							}
							else if (EndOfDay.ClubManager.ClubMembers > 0)
							{
								EndOfDay.Label.text = "The Gaming Club makes the decision to disband.";
							}
							else
							{
								EndOfDay.Label.text = "The Gaming Club no longer exists.";
							}
							EndOfDay.ClubClosed = true;
							if (EndOfDay.Yandere.Club == EndOfDay.ClubArray[EndOfDay.ClubID])
							{
								EndOfDay.Yandere.Club = ClubType.None;
							}
						}
						if (EndOfDay.ClubManager.LeaderMissing)
						{
							EndOfDay.EODCamera.position = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].position;
							EndOfDay.EODCamera.eulerAngles = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].eulerAngles;
							EndOfDay.EODCamera.Translate(Vector3.forward * EndOfDay.DistanceToMoveForward, Space.Self);
							ClubGlobals.SetClubClosed(EndOfDay.ClubArray[EndOfDay.ClubID], value: true);
							EndOfDay.Label.text = "The leader of the " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + " has gone missing. The " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + " cannot operate without its leader. The club disbands.";
							EndOfDay.ClubClosed = true;
							if (EndOfDay.Yandere.Club == EndOfDay.ClubArray[EndOfDay.ClubID])
							{
								EndOfDay.Yandere.Club = ClubType.None;
							}
						}
						else if (EndOfDay.ClubManager.LeaderDead)
						{
							EndOfDay.EODCamera.position = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].position;
							EndOfDay.EODCamera.eulerAngles = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].eulerAngles;
							EndOfDay.EODCamera.Translate(Vector3.forward * EndOfDay.DistanceToMoveForward, Space.Self);
							ClubGlobals.SetClubClosed(EndOfDay.ClubArray[EndOfDay.ClubID], value: true);
							EndOfDay.Label.text = "The leader of the " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + " is gone. The " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + " cannot operate without its leader. The club disbands.";
							EndOfDay.ClubClosed = true;
							if (EndOfDay.Yandere.Club == EndOfDay.ClubArray[EndOfDay.ClubID])
							{
								EndOfDay.Yandere.Club = ClubType.None;
							}
						}
						else if (EndOfDay.ClubManager.LeaderAshamed)
						{
							EndOfDay.EODCamera.position = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].position;
							EndOfDay.EODCamera.eulerAngles = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].eulerAngles;
							EndOfDay.EODCamera.Translate(Vector3.forward * EndOfDay.DistanceToMoveForward, Space.Self);
							ClubGlobals.SetClubClosed(EndOfDay.ClubArray[EndOfDay.ClubID], value: true);
							EndOfDay.Label.text = "The leader of the " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + " has unexpectedly disbanded the club without explanation.";
							EndOfDay.ClubClosed = true;
							EndOfDay.ClubManager.LeaderAshamed = false;
							if (EndOfDay.Yandere.Club == EndOfDay.ClubArray[EndOfDay.ClubID])
							{
								EndOfDay.Yandere.Club = ClubType.None;
							}
						}
					}
					if (!ClubGlobals.GetClubClosed(EndOfDay.ClubArray[EndOfDay.ClubID]) && !ClubGlobals.GetClubKicked(EndOfDay.ClubArray[EndOfDay.ClubID]) && EndOfDay.Yandere.Club == EndOfDay.ClubArray[EndOfDay.ClubID])
					{
						EndOfDay.ClubManager.CheckGrudge(EndOfDay.ClubArray[EndOfDay.ClubID]);
						if (EndOfDay.ClubManager.LeaderGrudge)
						{
							EndOfDay.EODCamera.position = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].position;
							EndOfDay.EODCamera.eulerAngles = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].eulerAngles;
							EndOfDay.EODCamera.Translate(Vector3.forward * EndOfDay.DistanceToMoveForward, Space.Self);
							EndOfDay.Label.text = EndOfDay.Protagonist + " receives a message from the president of the " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + ". " + EndOfDay.Protagonist + " is no longer a member of the " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + ", and is not welcome in the " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + " room.";
							ClubGlobals.SetClubKicked(EndOfDay.ClubArray[EndOfDay.ClubID], value: true);
							EndOfDay.Yandere.Club = ClubType.None;
							EndOfDay.ClubKicked = true;
						}
						else if (EndOfDay.ClubManager.ClubGrudge)
						{
							EndOfDay.EODCamera.position = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].position;
							EndOfDay.EODCamera.eulerAngles = EndOfDay.ClubManager.ClubVantages[EndOfDay.ClubID].eulerAngles;
							EndOfDay.EODCamera.Translate(Vector3.forward * EndOfDay.DistanceToMoveForward, Space.Self);
							EndOfDay.Label.text = EndOfDay.Protagonist + " receives a message from the president of the " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + ". There is someone in the " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + " who hates and fears " + EndOfDay.Protagonist + ". " + EndOfDay.Protagonist + " is no longer a member of the " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + ", and is not welcome in the " + EndOfDay.ClubNames[EndOfDay.ClubID].ToString() + " room.";
							ClubGlobals.SetClubKicked(EndOfDay.ClubArray[EndOfDay.ClubID], value: true);
							EndOfDay.Yandere.Club = ClubType.None;
							EndOfDay.ClubKicked = true;
						}
					}
					if (!EndOfDay.ClubClosed && !EndOfDay.ClubKicked)
					{
						EndOfDay.ClubID++;
						UpdateScene();
					}
					EndOfDay.ClubManager.LeaderAshamed = false;
				}
				else
				{
					EndOfDay.Phase++;
					UpdateScene();
				}
			}
			else if (EndOfDay.Phase == 18)
			{
				if (EndOfDay.TranqCase.Occupied)
				{
					EndOfDay.ClosedTranqCase.SetActive(value: true);
					EndOfDay.Label.color = new Color(EndOfDay.Label.color.r, EndOfDay.Label.color.g, EndOfDay.Label.color.b, 1f);
					if (EndOfDay.StudentManager.Eighties)
					{
						EndOfDay.Protagonist = "Ryoba";
					}
					EndOfDay.Label.text = EndOfDay.Protagonist + " waits until midnight, sneaks into school, and returns to the musical instrument case that contains her unconscious victim. She pushes the case back to her house and ties the victim to a chair in her basement.";
					if (EndOfDay.TranqCase.VictimID == EndOfDay.StudentManager.RivalID)
					{
						EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
						GameGlobals.SpecificEliminationID = 12;
						if (!GameGlobals.Debug)
						{
							PlayerPrefs.SetInt("Kidnap", 1);
						}
					}
					EndOfDay.Phase++;
				}
				else
				{
					EndOfDay.Phase++;
					UpdateScene();
				}
			}
			else if (EndOfDay.Phase == 19)
			{
				if (EndOfDay.ErectFence)
				{
					EndOfDay.Fence.SetActive(value: true);
					EndOfDay.Label.text = "To prevent any other students from falling off of the school rooftop, the school erects a fence around the roof.";
					SchoolGlobals.RoofFence = true;
					EndOfDay.ErectFence = false;
				}
				else
				{
					EndOfDay.Phase++;
					UpdateScene();
				}
			}
			else if (EndOfDay.Phase == 20)
			{
				if (!SchoolGlobals.HighSecurity && EndOfDay.Police.CouncilDeath)
				{
					if (!EndOfDay.StudentManager.Eighties)
					{
						EndOfDay.SCP.SetActive(value: true);
						EndOfDay.Label.text = "The student council president has ordered the implementation of heightened security precautions. Security cameras and metal detectors are now present at school.";
					}
					else
					{
						EndOfDay.Headmaster.SetActive(value: true);
						EndOfDay.Label.text = "The headmaster has ordered the implementation of heightened security precautions. Security cameras and metal detectors are now present at school.";
					}
					EndOfDay.Police.CouncilDeath = false;
				}
				else
				{
					EndOfDay.Phase++;
					UpdateScene();
				}
			}
			else if (EndOfDay.Phase == 21)
			{
				Debug.Log("The End-of-Day sequence is now checking the rival's reputation.");
				EndOfDay.Rival = EndOfDay.StudentManager.Students[EndOfDay.StudentManager.RivalID];
				if (EndOfDay.ArticleID == 2)
				{
					EndOfDay.StudentManager.StudentReps[EndOfDay.StudentManager.RivalID] -= 20f * (1f + (float)EndOfDay.Class.LanguageGrade * 0.2f);
					StudentGlobals.SetStudentReputation(EndOfDay.StudentManager.RivalID, Mathf.RoundToInt(EndOfDay.StudentManager.StudentReps[EndOfDay.StudentManager.RivalID]));
				}
				if (EndOfDay.Rival != null && EndOfDay.Rival.Alive && EndOfDay.StudentManager.StudentReps[EndOfDay.StudentManager.RivalID] <= -100f)
				{
					Debug.Log("The rival is not null, the rival is alive, and the rival's reputation is below -100.");
					EndOfDay.Rival.gameObject.SetActive(value: true);
					EndOfDay.Rival.transform.parent = base.transform;
					EndOfDay.Rival.transform.localPosition = new Vector3(0f, 0f, 0f);
					EndOfDay.Rival.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					EndOfDay.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					EndOfDay.Rival.CharacterAnimation.Play(EndOfDay.Rival.BulliedWalkAnim);
					EndOfDay.Rival.CharacterAnimation.enabled = true;
					if (EndOfDay.StudentManager.Eighties)
					{
						EndOfDay.RivalName = EndOfDay.EightiesRivalNames[DateGlobals.Week];
					}
					else
					{
						EndOfDay.RivalName = EndOfDay.RivalNames[DateGlobals.Week];
					}
					EndOfDay.Label.text = EndOfDay.RivalName + " cannot endure the bullying and harassment that she is being subjected to due to her damaged reputation. She chooses to withdraw from Akademi and never return.";
					EndOfDay.RivalEliminationMethod = RivalEliminationType.Ruined;
					EndOfDay.StudentManager.RivalEliminated = true;
					GameGlobals.SpecificEliminationID = 4;
					if (EndOfDay.StudentManager.StudentReps[EndOfDay.StudentManager.RivalID] <= -150f)
					{
						EndOfDay.Label.text = EndOfDay.RivalName + " is absolutely devastated by the unbearable bullying and harassment that she is being subjected to. She silently returns to her home, planning something drastic...";
						EndOfDay.Rival.CharacterAnimation.Play(EndOfDay.Rival.BulliedIdleAnim);
						EndOfDay.RivalEliminationMethod = RivalEliminationType.SuicideBully;
						EndOfDay.GoToSuicideScene = true;
						EndOfDay.StudentManager.Students[EndOfDay.StudentManager.RivalID].Hearts.Stop();
						GameGlobals.SpecificEliminationID = 19;
						if (!GameGlobals.Debug)
						{
							PlayerPrefs.SetInt("Suicide", 1);
						}
					}
					else
					{
						Debug.Log("Informing the Content Checklist.");
						if (!GameGlobals.Debug)
						{
							PlayerPrefs.SetInt("Bully", 1);
						}
					}
					EndOfDay.Phase++;
				}
				else
				{
					EndOfDay.Phase++;
					UpdateScene();
				}
			}
			else if (EndOfDay.Phase == 22)
			{
				Debug.Log("The End-of-Day sequence is now checking whether or not we need to boot the player out of a club.");
				if (EndOfDay.Yandere.Club != 0 && DateGlobals.Weekday == DayOfWeek.Friday && EndOfDay.ClubManager.ActivitiesAttended == 0)
				{
					TeleportYandere();
					EndOfDay.Yandere.CharacterAnimation.Play("f02_disappointed_00");
					if (EndOfDay.Yandere.StudentManager.Eighties)
					{
						EndOfDay.Yandere.LoseGentleEyes();
					}
					if (EndOfDay.StudentManager.Eighties)
					{
						EndOfDay.Protagonist = "Ryoba";
					}
					EndOfDay.Label.text = EndOfDay.Protagonist + " did not participate in any activities with her club this week. She been kicked out of the club.";
					ClubGlobals.SetClubKicked(EndOfDay.Yandere.Club, value: true);
					ClubGlobals.Club = ClubType.None;
					EndOfDay.Yandere.Club = ClubType.None;
				}
				else
				{
					EndOfDay.Phase++;
					UpdateScene();
				}
			}
			else if (EndOfDay.Phase == 23)
			{
				Finish();
			}
			else if (EndOfDay.Phase == 24)
			{
				if (!EndOfDay.LoveManager.ConfessToSuitor && EndOfDay.StudentManager.Students[EndOfDay.StudentManager.SuitorID].Alive)
				{
					EndOfDay.Senpai.enabled = false;
					EndOfDay.Senpai.Pathfinding.enabled = false;
					EndOfDay.Senpai.transform.parent = base.transform;
					EndOfDay.Senpai.gameObject.SetActive(value: true);
					EndOfDay.Senpai.transform.localPosition = new Vector3(0f, 0f, 0f);
					EndOfDay.Senpai.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					EndOfDay.Senpai.EmptyHands();
					EndOfDay.Senpai.MyController.enabled = false;
					EndOfDay.Senpai.CharacterAnimation.enabled = true;
					EndOfDay.Senpai.CharacterAnimation.CrossFade(EndOfDay.Senpai.IdleAnim);
					EndOfDay.Rival.enabled = false;
					EndOfDay.Rival.Pathfinding.enabled = false;
					EndOfDay.Rival.transform.parent = base.transform;
					EndOfDay.Rival.gameObject.SetActive(value: true);
					EndOfDay.Rival.transform.localPosition = new Vector3(0f, 0f, 1f);
					EndOfDay.Rival.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
					EndOfDay.Rival.EmptyHands();
					EndOfDay.Rival.MyController.enabled = false;
					EndOfDay.Rival.CharacterAnimation.enabled = true;
					EndOfDay.Rival.CharacterAnimation.CrossFade(EndOfDay.Rival.IdleAnim);
					EndOfDay.Rival.CharacterAnimation["f02_shy_00"].weight = 1f;
					EndOfDay.Rival.CharacterAnimation.Play("f02_shy_00");
					EndOfDay.Label.text = "After the police investigation ends, " + EndOfDay.RivalName + " asks Senpai to speak with her under the cherry tree behind the school.";
					EndOfDay.Phase++;
				}
				else
				{
					StudentScript obj = EndOfDay.StudentManager.Students[EndOfDay.StudentManager.SuitorID];
					obj.enabled = false;
					obj.Pathfinding.enabled = false;
					obj.transform.parent = base.transform;
					obj.gameObject.SetActive(value: true);
					obj.transform.localPosition = new Vector3(-0.4f, 0f, 0f);
					obj.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
					obj.EmptyHands();
					obj.MyController.enabled = false;
					obj.CharacterAnimation.enabled = true;
					obj.CharacterAnimation.Play("holdHandsLoop_00");
					ParticleSystem.EmissionModule emission = obj.Hearts.emission;
					emission.enabled = true;
					obj.Hearts.Play();
					EndOfDay.Rival.enabled = false;
					EndOfDay.Rival.Pathfinding.enabled = false;
					EndOfDay.Rival.transform.parent = base.transform;
					EndOfDay.Rival.gameObject.SetActive(value: true);
					EndOfDay.Rival.transform.localPosition = new Vector3(0.4f, 0f, 0f);
					EndOfDay.Rival.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
					EndOfDay.Rival.EmptyHands();
					EndOfDay.Rival.MyController.enabled = false;
					EndOfDay.Rival.CharacterAnimation.enabled = true;
					EndOfDay.Rival.CharacterAnimation.CrossFade(EndOfDay.Rival.IdleAnim);
					EndOfDay.Rival.CharacterAnimation["f02_shy_00"].weight = 1f;
					EndOfDay.Rival.CharacterAnimation.Play("f02_holdHandsLoop_00");
					ParticleSystem.EmissionModule emission2 = EndOfDay.Rival.Hearts.emission;
					emission2.enabled = true;
					EndOfDay.Rival.Hearts.Play();
					EndOfDay.RivalEliminationMethod = RivalEliminationType.Matchmade;
					EndOfDay.Label.text = "After the police investigation ends, " + EndOfDay.RivalName + " confesses to a boy that she has fallen in love with. She will no longer attempt to pursue a relationship with " + EndOfDay.Protagonist + "'s Senpai.";
					EndOfDay.Phase = 12;
				}
			}
			else if (EndOfDay.Phase == 25)
			{
				for (int num = 1; num < StudentManager.Students.Length; num++)
				{
					EndOfDay.StudentManager.DisableStudent(num);
				}
				EndOfDay.LoveManager.Suitor = EndOfDay.Senpai;
				EndOfDay.LoveManager.Rival = EndOfDay.Rival;
				EndOfDay.LoveManager.Rival.CharacterAnimation["f02_shy_00"].weight = 0f;
				EndOfDay.LoveManager.Suitor.gameObject.SetActive(value: true);
				EndOfDay.LoveManager.Rival.gameObject.SetActive(value: true);
				EndOfDay.Yandere.gameObject.SetActive(value: true);
				EndOfDay.LoveManager.Suitor.transform.parent = null;
				EndOfDay.LoveManager.Rival.transform.parent = null;
				EndOfDay.Yandere.gameObject.transform.parent = null;
				EndOfDay.LoveManager.BeginConfession();
				EndOfDay.Clock.NightLighting();
				EndOfDay.Clock.enabled = false;
				base.gameObject.SetActive(value: false);
			}
			else if (EndOfDay.Phase == 100)
			{
				EndOfDay.Yandere.MyController.enabled = false;
				EndOfDay.Yandere.transform.parent = base.transform;
				EndOfDay.Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
				EndOfDay.Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				EndOfDay.Yandere.CharacterAnimation.Play("f02_handcuffs_00");
				EndOfDay.Yandere.Handcuffs.SetActive(value: true);
				EndOfDay.ArrestingCops.SetActive(value: true);
				Physics.SyncTransforms();
				EndOfDay.Label.text = EndOfDay.Protagonist + " is arrested by the police. She will never have Senpai.";
				EndOfDay.GameOver = true;
				EndOfDay.Heartbroken.Arrested = true;
				EndOfDay.Heartbroken.NoSnap = true;
			}
			else if (EndOfDay.Phase == 101)
			{
				int fingerprintID2 = EndOfDay.WeaponManager.Weapons[EndOfDay.WeaponID].FingerprintID;
				StudentScript studentScript = EndOfDay.StudentManager.Students[fingerprintID2];
				if (studentScript.Alive)
				{
					EndOfDay.Patsy = EndOfDay.StudentManager.Students[fingerprintID2];
					EndOfDay.Patsy.gameObject.SetActive(value: true);
					EndOfDay.Patsy.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					EndOfDay.Patsy.CharacterAnimation.enabled = true;
					if (EndOfDay.Patsy.WeaponBag != null)
					{
						EndOfDay.Patsy.WeaponBag.SetActive(value: false);
					}
					EndOfDay.Patsy.EmptyHands();
					EndOfDay.Patsy.SpeechLines.Stop();
					EndOfDay.Patsy.Handcuffs.SetActive(value: true);
					EndOfDay.Patsy.gameObject.SetActive(value: true);
					EndOfDay.Patsy.Ragdoll.Zs.SetActive(value: false);
					EndOfDay.Patsy.SmartPhone.SetActive(value: false);
					EndOfDay.Patsy.MyController.enabled = false;
					EndOfDay.Patsy.transform.parent = base.transform;
					EndOfDay.Patsy.transform.localPosition = new Vector3(0f, 0f, 0f);
					EndOfDay.Patsy.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					EndOfDay.Patsy.ShoeRemoval.enabled = false;
					if (EndOfDay.StudentManager.Students[fingerprintID2].Male)
					{
						EndOfDay.StudentManager.Students[fingerprintID2].CharacterAnimation.Play("handcuffs_00");
					}
					else
					{
						EndOfDay.StudentManager.Students[fingerprintID2].CharacterAnimation.Play("f02_handcuffs_00");
					}
					EndOfDay.ArrestingCops.SetActive(value: true);
					if (!studentScript.Tranquil)
					{
						if (fingerprintID2 < 101)
						{
							EndOfDay.Label.text = EndOfDay.JSON.Students[fingerprintID2].Name + " is arrested by the police.";
						}
						else
						{
							EndOfDay.Label.text = ExtraJSON.Students[fingerprintID2].Name + " is arrested by the police.";
						}
						EndOfDay.StudentsToArrest[fingerprintID2] = true;
						EndOfDay.Arrests++;
					}
					else
					{
						if (fingerprintID2 < 101)
						{
							EndOfDay.Label.text = EndOfDay.JSON.Students[fingerprintID2].Name + " is found asleep inside of a musical instrument case. The police assume that she hid herself inside of the box after committing murder, and arrest her.";
						}
						else
						{
							EndOfDay.Label.text = ExtraJSON.Students[fingerprintID2].Name + " is found asleep inside of a musical instrument case. The police assume that she hid herself inside of the box after committing murder, and arrest her.";
						}
						EndOfDay.StudentsToArrest[fingerprintID2] = true;
						EndOfDay.ArrestID = fingerprintID2;
						EndOfDay.TranqCase.Occupied = false;
						EndOfDay.Arrests++;
					}
					if (EndOfDay.Patsy.StudentID == EndOfDay.StudentManager.RivalID)
					{
						EndOfDay.StudentManager.RivalEliminated = true;
						EndOfDay.RivalArrested = true;
					}
				}
				else
				{
					EndOfDay.ShruggingCops.SetActive(value: true);
					if (studentScript.Ragdoll.Disposed)
					{
						if (fingerprintID2 < 101)
						{
							EndOfDay.Label.text = EndOfDay.JSON.Students[fingerprintID2].Name + " is missing. The police cannot perform an arrest.";
						}
						else
						{
							EndOfDay.Label.text = ExtraJSON.Students[fingerprintID2].Name + " is missing. The police cannot perform an arrest.";
						}
						EndOfDay.DeadPerps++;
					}
					else
					{
						bool flag2 = false;
						EndOfDay.ID = 0;
						while (EndOfDay.ID < EndOfDay.VictimArray.Length)
						{
							if (EndOfDay.VictimArray[EndOfDay.ID] == fingerprintID2 && !studentScript.MurderSuicide)
							{
								flag2 = true;
							}
							EndOfDay.ID++;
						}
						if (!flag2)
						{
							if (fingerprintID2 < 101)
							{
								EndOfDay.Label.text = EndOfDay.JSON.Students[fingerprintID2].Name + " is dead. The police cannot perform an arrest.";
							}
							else
							{
								EndOfDay.Label.text = ExtraJSON.Students[fingerprintID2].Name + " is dead. The police cannot perform an arrest.";
							}
							EndOfDay.DeadPerps++;
						}
						else if (fingerprintID2 < 101)
						{
							EndOfDay.Label.text = EndOfDay.JSON.Students[fingerprintID2].Name + "'s fingerprints are on the same weapon that killed them. The police cannot solve this mystery.";
						}
						else
						{
							EndOfDay.Label.text = ExtraJSON.Students[fingerprintID2].Name + "'s fingerprints are on the same weapon that killed them. The police cannot solve this mystery.";
						}
					}
				}
				if (EndOfDay.CurrentMurderWeaponKilledRival)
				{
					Debug.Log("The police believe that they know who killed the rival. ''Details'' for this rival should be set to ''14'' - ''Ryoba's involvement not suspected.''");
					EndOfDay.InvolvementNotSuspected = true;
				}
				EndOfDay.Phase = 3;
			}
			else if (EndOfDay.Phase == 102)
			{
				if (!EndOfDay.StudentManager.Students[EndOfDay.Police.SuicideID].Ragdoll.Disposed)
				{
					EndOfDay.MurderScene.SetActive(value: true);
					if (EndOfDay.Police.SuicideNote)
					{
						EndOfDay.Label.text = "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police find a suicide note, and conclude that the deceased student probably took their own life. However, they still search the school for clues and evidence.";
					}
					else
					{
						EndOfDay.Label.text = "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police treat the incident as a murder case, and search the school for any other victims.";
					}
					if (EndOfDay.Police.SuicideID == EndOfDay.StudentManager.RivalID)
					{
						EndOfDay.RivalEliminationMethod = RivalEliminationType.SuicideFake;
					}
					EndOfDay.ErectFence = true;
				}
				else
				{
					EndOfDay.ShruggingCops.SetActive(value: true);
					EndOfDay.Label.text = "The police attempt to determine whether or not a student fell to their death from the school rooftop. The police are unable to reach a conclusion.";
				}
				EndOfDay.ID = 0;
				while (EndOfDay.ID < EndOfDay.Police.CorpseList.Length)
				{
					RagdollScript ragdollScript2 = EndOfDay.Police.CorpseList[EndOfDay.ID];
					if (ragdollScript2 != null && ragdollScript2.Suicide)
					{
						EndOfDay.Police.SuicideVictims++;
						if (EndOfDay.Police.Corpses > 0)
						{
							EndOfDay.Police.Corpses--;
						}
					}
					EndOfDay.ID++;
				}
				EndOfDay.Phase = 2;
			}
			else if (EndOfDay.Phase == 103)
			{
				EndOfDay.MurderScene.SetActive(value: true);
				EndOfDay.Label.text = "The paramedics attempt to resuscitate the poisoned student, but they are unable to revive her. The police treat the incident as a murder case, and search the school for any other victims.";
				EndOfDay.ID = 0;
				while (EndOfDay.ID < EndOfDay.Police.CorpseList.Length)
				{
					RagdollScript ragdollScript3 = EndOfDay.Police.CorpseList[EndOfDay.ID];
					if (ragdollScript3 != null && ragdollScript3.Poisoned && EndOfDay.Police.Corpses > 0)
					{
						EndOfDay.Police.Corpses--;
					}
					EndOfDay.ID++;
				}
				if (EndOfDay.Corpse.StudentID == EndOfDay.StudentManager.RivalID)
				{
					GameGlobals.SpecificEliminationID = 15;
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Poison", 1);
					}
				}
				EndOfDay.Phase = 2;
			}
			else if (EndOfDay.Phase == 104)
			{
				EndOfDay.MurderScene.SetActive(value: true);
				EndOfDay.Label.text = "The police determine that " + EndOfDay.Police.DrownedStudentName + " died from drowning. The police treat the death as a possible murder, and search the school for any other victims.";
				EndOfDay.ID = 0;
				while (EndOfDay.ID < EndOfDay.Police.CorpseList.Length)
				{
					RagdollScript ragdollScript4 = EndOfDay.Police.CorpseList[EndOfDay.ID];
					if (ragdollScript4 != null)
					{
						if (ragdollScript4.Student.StudentID == EndOfDay.StudentManager.RivalID)
						{
							Debug.Log("The player drowned the rival.");
							if (EndOfDay.RivalEliminationMethod == RivalEliminationType.None)
							{
								EndOfDay.RivalEliminationMethod = RivalEliminationType.Murdered;
							}
							GameGlobals.SpecificEliminationID = 7;
							if (!GameGlobals.Debug)
							{
								PlayerPrefs.SetInt("Drown", 1);
							}
						}
						if (ragdollScript4.Drowned && EndOfDay.Police.Corpses > 0)
						{
							EndOfDay.Police.Corpses--;
						}
					}
					EndOfDay.ID++;
				}
				EndOfDay.Phase = 2;
			}
			else if (EndOfDay.Phase == 105)
			{
				EndOfDay.MurderScene.SetActive(value: true);
				EndOfDay.Label.text = "The police determine that " + EndOfDay.Police.ElectrocutedStudentName + " died from being electrocuted. The police treat the death as a possible murder, and search the school for any other victims.";
				EndOfDay.ID = 0;
				while (EndOfDay.ID < EndOfDay.Police.CorpseList.Length)
				{
					RagdollScript ragdollScript5 = EndOfDay.Police.CorpseList[EndOfDay.ID];
					if (ragdollScript5 != null && ragdollScript5.Electrocuted)
					{
						if (ragdollScript5.Student.StudentID == EndOfDay.StudentManager.RivalID)
						{
							Debug.Log("The game should now be informing the Content Checklist that the player has performed an electrocution.");
							if (!GameGlobals.Debug)
							{
								PlayerPrefs.SetInt("Electrocute", 1);
							}
						}
						if (EndOfDay.Police.Corpses > 0)
						{
							EndOfDay.Police.Corpses--;
						}
					}
					EndOfDay.ID++;
				}
				EndOfDay.Phase = 2;
			}
			else if (EndOfDay.Phase == 999)
			{
				EndOfDay.ScaredCops.SetActive(value: true);
				EndOfDay.Yandere.MyController.enabled = false;
				EndOfDay.Yandere.transform.parent = base.transform;
				EndOfDay.Yandere.transform.localPosition = new Vector3(0f, 0f, -1f);
				EndOfDay.Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				Physics.SyncTransforms();
				EndOfDay.Label.text = "The police witness actual evidence of the supernatural, are absolutely horrified, and run for their lives.";
				if (EndOfDay.StudentManager.RivalEliminated)
				{
					EndOfDay.Phase = 12;
				}
				else
				{
					EndOfDay.Phase = 13;
				}
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000AC1C File Offset: 0x00008E1C
		private void TeleportYandere()
		{
			EndOfDay.Yandere.MyController.enabled = false;
			EndOfDay.Yandere.transform.parent = base.transform;
			EndOfDay.Yandere.transform.localPosition = new Vector3(0.75f, 0.33333f, -1.9f);
			EndOfDay.Yandere.transform.localEulerAngles = new Vector3(-22.5f, 157.5f, 0f);
			Physics.SyncTransforms();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000ACB4 File Offset: 0x00008EB4
		private void Finish()
		{
			Debug.Log("We have reached the end of the End-of-Day sequence.");
			if (EndOfDay.RivalArrested)
			{
				EndOfDay.RivalEliminationMethod = RivalEliminationType.Arrested;
			}
			if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Murdered)
			{
				Debug.Log("The rival was attacked with a weapon.");
				GameGlobals.RivalEliminationID = 1;
				GameGlobals.NonlethalElimination = false;
				if (EndOfDay.StudentManager.Students[1].SenpaiWitnessingRivalDie)
				{
					GameGlobals.RivalEliminationID = 2;
				}
				if (EndOfDay.InvolvementNotSuspected)
				{
					Debug.Log("The police found someone's fingerprints on the murder weapon, so Ryoba is not a suspect.");
					GameGlobals.RivalEliminationID = 14;
				}
			}
			else if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Arrested)
			{
				Debug.Log("The rival was arrested.");
				GameGlobals.RivalEliminationID = 3;
				GameGlobals.NonlethalElimination = true;
				GameGlobals.SpecificEliminationID = 11;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Frame", 1);
				}
				StudentGlobals.SetStudentArrested(EndOfDay.StudentManager.RivalID, value: true);
			}
			else if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Expelled)
			{
				Debug.Log("The rival was expelled.");
				StudentGlobals.SetStudentExpelled(EndOfDay.StudentManager.RivalID, value: true);
				GameGlobals.RivalEliminationID = 5;
				GameGlobals.NonlethalElimination = true;
				GameGlobals.SpecificEliminationID = 9;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Expel", 1);
				}
			}
			else if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Matchmade)
			{
				Debug.Log("The rival was matchmade.");
				GameGlobals.RivalEliminationID = 6;
				GameGlobals.NonlethalElimination = true;
				GameGlobals.SpecificEliminationID = 13;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Matchmake", 1);
				}
			}
			else if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Rejected)
			{
				Debug.Log("The rival was rejected by Senpai.");
				GameGlobals.RivalEliminationID = 7;
				GameGlobals.NonlethalElimination = true;
				GameGlobals.SpecificEliminationID = 18;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Reject", 1);
				}
			}
			else if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Ruined)
			{
				Debug.Log("The rival's reputation has been ruined.");
				GameGlobals.RivalEliminationID = 8;
				GameGlobals.NonlethalElimination = true;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Bully", 1);
				}
			}
			else if (EndOfDay.RivalEliminationMethod == RivalEliminationType.SuicideBully)
			{
				Debug.Log("The rival was bullied into suicide.");
				GameGlobals.RivalEliminationID = 9;
				GameGlobals.NonlethalElimination = false;
			}
			else if (EndOfDay.RivalEliminationMethod == RivalEliminationType.SuicideFake)
			{
				Debug.Log("The rival was pushed off the school rooftop, and the player made her death look like an accident.");
				GameGlobals.RivalEliminationID = 10;
				GameGlobals.NonlethalElimination = false;
				GameGlobals.SpecificEliminationID = 17;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Push", 1);
				}
			}
			else if (EndOfDay.RivalEliminationMethod != RivalEliminationType.Vanished && !EndOfDay.RivalDismemberedAndIncinerated && !EndOfDay.RivalBuried)
			{
				if (EndOfDay.RivalEliminationMethod == RivalEliminationType.Accident)
				{
					Debug.Log("The rival was killed in a ''mysterious accident''.");
					GameGlobals.RivalEliminationID = 12;
					GameGlobals.NonlethalElimination = false;
				}
			}
			else
			{
				Debug.Log("The rival ''mysteriously disappeared''.");
				GameGlobals.RivalEliminationID = 11;
				GameGlobals.NonlethalElimination = false;
				CheckForNatureOfDeath();
				if (EndOfDay.TranqCase.VictimID == EndOfDay.StudentManager.RivalID)
				{
					GameGlobals.NonlethalElimination = true;
				}
			}
			if (GameGlobals.RivalEliminationID == 0 && EndOfDay.StudentManager.Students[EndOfDay.StudentManager.RivalID] != null && !EndOfDay.StudentManager.Students[EndOfDay.StudentManager.RivalID].Alive)
			{
				Debug.Log("RivalEliminationID was 0, but the rival is dead. Bug?");
				if (EndOfDay.StudentManager.Students[EndOfDay.StudentManager.RivalID].Ragdoll.Hidden || !EndOfDay.PoliceArrived)
				{
					Debug.Log("The rival ''mysteriously disappeared''.");
					GameGlobals.RivalEliminationID = 11;
					GameGlobals.NonlethalElimination = false;
				}
				CheckForNatureOfDeath();
			}
			PlayerGlobals.Reputation = EndOfDay.Reputation.Reputation;
			ClubGlobals.Club = EndOfDay.Yandere.Club;
			StudentGlobals.MemorialStudents = 0;
			HomeGlobals.Night = true;
			Police.KillStudents();
			SetPhonesHacked();
			ArrestStudents();
			if (EndOfDay.Police.Suspended)
			{
				DateGlobals.PassDays = EndOfDay.Police.SuspensionLength;
			}
			else
			{
				DateGlobals.PassDays = 1;
			}
			if (EndOfDay.StudentManager.Students[StudentGlobals.StudentSlave] != null && EndOfDay.StudentManager.Students[StudentGlobals.StudentSlave].Ragdoll.enabled)
			{
				StudentGlobals.StudentSlave = 0;
				StudentGlobals.Prisoners--;
				if (StudentGlobals.PrisonerChosen == 1)
				{
					StudentGlobals.Prisoner1 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 2)
				{
					StudentGlobals.Prisoner2 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 3)
				{
					StudentGlobals.Prisoner3 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 4)
				{
					StudentGlobals.Prisoner4 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 5)
				{
					StudentGlobals.Prisoner5 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 6)
				{
					StudentGlobals.Prisoner6 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 7)
				{
					StudentGlobals.Prisoner7 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 8)
				{
					StudentGlobals.Prisoner8 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 9)
				{
					StudentGlobals.Prisoner9 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 10)
				{
					StudentGlobals.Prisoner10 = 0;
				}
			}
			for (int i = 1; i < 11; i++)
			{
				if (EndOfDay.StudentManager.RivalKilledSelf[i])
				{
					GameGlobals.SetRivalEliminations(i, 10);
					GameGlobals.SetSpecificEliminations(i, 19);
				}
			}
			bool flag = DateGlobals.Weekday != DayOfWeek.Friday && EndOfDay.StudentManager.SabotageProgress > EndOfDay.StudentManager.InitialSabotageProgress;
			if (!EndOfDay.TranqCase.Occupied)
			{
				if (EndOfDay.GoToSuicideScene)
				{
					SceneManager.LoadScene("SuicideScene");
				}
				else if (flag)
				{
					SceneManager.LoadScene("RivalRejectionProgressScene");
				}
				else if (!EndOfDay.StudentManager.Eighties && DateGlobals.Week > 1)
				{
					SceneManager.LoadScene("WeekLimitScene");
				}
				else
				{
					SceneManager.LoadScene("HomeScene");
				}
			}
			else
			{
				StudentGlobals.Prisoners++;
				if (StudentGlobals.Prisoners == 1)
				{
					StudentGlobals.Prisoner1 = EndOfDay.TranqCase.VictimID;
				}
				else if (StudentGlobals.Prisoners == 2)
				{
					StudentGlobals.Prisoner2 = EndOfDay.TranqCase.VictimID;
				}
				else if (StudentGlobals.Prisoners == 3)
				{
					StudentGlobals.Prisoner3 = EndOfDay.TranqCase.VictimID;
				}
				else if (StudentGlobals.Prisoners == 4)
				{
					StudentGlobals.Prisoner4 = EndOfDay.TranqCase.VictimID;
				}
				else if (StudentGlobals.Prisoners == 5)
				{
					StudentGlobals.Prisoner5 = EndOfDay.TranqCase.VictimID;
				}
				else if (StudentGlobals.Prisoners == 6)
				{
					StudentGlobals.Prisoner6 = EndOfDay.TranqCase.VictimID;
				}
				else if (StudentGlobals.Prisoners == 7)
				{
					StudentGlobals.Prisoner7 = EndOfDay.TranqCase.VictimID;
				}
				else if (StudentGlobals.Prisoners == 8)
				{
					StudentGlobals.Prisoner8 = EndOfDay.TranqCase.VictimID;
				}
				else if (StudentGlobals.Prisoners == 9)
				{
					StudentGlobals.Prisoner9 = EndOfDay.TranqCase.VictimID;
				}
				else if (StudentGlobals.Prisoners == 10)
				{
					StudentGlobals.Prisoner10 = EndOfDay.TranqCase.VictimID;
				}
				StudentGlobals.SetStudentKidnapped(EndOfDay.TranqCase.VictimID, value: true);
				StudentGlobals.SetStudentSanity(EndOfDay.TranqCase.VictimID, 100);
				if (flag)
				{
					GameGlobals.JustKidnapped = true;
					SceneManager.LoadScene("RivalRejectionProgressScene");
				}
				else
				{
					SceneManager.LoadScene("CalendarScene");
				}
			}
			if (EndOfDay.Dumpster.StudentToGoMissing > 0)
			{
				EndOfDay.Dumpster.SetVictimMissing();
			}
			EndOfDay.ID = 0;
			while (EndOfDay.ID < EndOfDay.GardenHoles.Length)
			{
				EndOfDay.GardenHoles[EndOfDay.ID].EndOfDayCheck();
				EndOfDay.ID++;
			}
			EndOfDay.ID = 1;
			while (EndOfDay.ID < EndOfDay.Yandere.Inventory.ShrineCollectibles.Length)
			{
				if (EndOfDay.Yandere.Inventory.ShrineCollectibles[EndOfDay.ID])
				{
					PlayerGlobals.SetShrineCollectible(EndOfDay.ID, value: true);
				}
				EndOfDay.ID++;
			}
			EndOfDay.Incinerator.SetVictimsMissing();
			EndOfDay.WoodChipper.SetVictimsMissing();
			if (EndOfDay.FragileTarget > 0)
			{
				StudentGlobals.FragileTarget = EndOfDay.FragileTarget;
				StudentGlobals.FragileSlave = 5;
			}
			if (EndOfDay.StudentManager.ReactedToGameLeader)
			{
				SchoolGlobals.ReactedToGameLeader = true;
			}
			if (TaskGlobals.GetTaskStatus(46) == 1)
			{
				TaskGlobals.SetTaskStatus(46, 0);
			}
			if (EndOfDay.StudentManager.Students[46] != null && EndOfDay.StudentManager.Students[46].TaskPhase == 5)
			{
				TaskGlobals.SetTaskStatus(46, 3);
				PlayerGlobals.SetStudentFriend(46, value: true);
				EndOfDay.NewFriends++;
			}
			if (EndOfDay.NewFriends > 0)
			{
				PlayerGlobals.Friends += EndOfDay.NewFriends;
			}
			if (EndOfDay.Yandere.Alerts > 0)
			{
				PlayerGlobals.Alerts += EndOfDay.Yandere.Alerts;
			}
			SchoolGlobals.SchoolAtmosphere += (float)EndOfDay.Arrests * 0.1f;
			if (EndOfDay.Counselor.ExpelledDelinquents)
			{
				SchoolGlobals.SchoolAtmosphere += 0.25f;
			}
			if (EndOfDay.Yandere.Inventory.FakeID)
			{
				PlayerGlobals.FakeID = true;
			}
			if (EndOfDay.RaibaruLoner)
			{
				PlayerGlobals.RaibaruLoner = true;
			}
			if (EndOfDay.StopMourning)
			{
				GameGlobals.SenpaiMourning = false;
			}
			if (EndOfDay.StudentManager.EmbarassingSecret)
			{
				SchemeGlobals.SetServicePurchased(4, value: true);
				SchemeGlobals.EmbarassingSecret = true;
			}
			EventGlobals.LearnedAboutPhotographer = EndOfDay.LearnedAboutPhotographer;
			EventGlobals.OsanaEvent1 = EndOfDay.LearnedOsanaInfo1;
			EventGlobals.OsanaEvent2 = EndOfDay.LearnedOsanaInfo2;
			CollectibleGlobals.MatchmakingGifts = EndOfDay.MatchmakingGifts;
			CollectibleGlobals.SenpaiGifts = EndOfDay.SenpaiGifts;
			PlayerGlobals.PantyShots = EndOfDay.Yandere.Inventory.PantyShots;
			PlayerGlobals.Money = EndOfDay.Yandere.Inventory.Money;
			ClassGlobals.Biology = EndOfDay.Class.Biology;
			ClassGlobals.Chemistry = EndOfDay.Class.Chemistry;
			ClassGlobals.Language = EndOfDay.Class.Language;
			ClassGlobals.Physical = EndOfDay.Class.Physical;
			ClassGlobals.Psychology = EndOfDay.Class.Psychology;
			ClassGlobals.BiologyGrade = EndOfDay.Class.BiologyGrade;
			ClassGlobals.ChemistryGrade = EndOfDay.Class.ChemistryGrade;
			ClassGlobals.LanguageGrade = EndOfDay.Class.LanguageGrade;
			ClassGlobals.PhysicalGrade = EndOfDay.Class.PhysicalGrade;
			ClassGlobals.PsychologyGrade = EndOfDay.Class.PsychologyGrade;
			PlayerGlobals.Headset = EndOfDay.Yandere.Inventory.Headset;
			PlayerGlobals.DirectionalMic = EndOfDay.Yandere.Inventory.DirectionalMic;
			EndOfDay.WeaponManager.TrackDumpedWeapons();
			EndOfDay.Yandere.PauseScreen.FavorMenu.ServicesMenu.SaveServicesPurchased();
			EndOfDay.StudentManager.LoveManager.SaveSuitorInstructions();
			EndOfDay.StudentManager.TaskManager.SaveTaskStatuses();
			EndOfDay.StudentManager.SaveCollectibles();
			EndOfDay.StudentManager.SavePantyshots();
			EndOfDay.StudentManager.SaveReps();
			if (EndOfDay.StudentManager.DatingMinigame.DataNeedsSaving)
			{
				EndOfDay.StudentManager.DatingMinigame.SaveTopicsAndCompliments();
			}
			if (EndOfDay.StudentManager.DatingMinigame.GiftStatusNeedsSaving)
			{
				EndOfDay.StudentManager.DatingMinigame.SaveGiftStatus();
			}
			if (EndOfDay.StudentManager.DialogueWheel.AdviceWindow.DataNeedsSaving)
			{
				EndOfDay.StudentManager.DialogueWheel.AdviceWindow.SaveTopicsAndCompliments();
			}
			if (EndOfDay.StudentManager.DialogueWheel.AdviceWindow.GiftDataNeedsSaving)
			{
				EndOfDay.StudentManager.DialogueWheel.AdviceWindow.SaveGiftStatus();
			}
			if (SchemeGlobals.GetSchemeStage(6) == 8)
			{
				SchemeGlobals.SetSchemeStage(6, 9);
				EndOfDay.Yandere.PauseScreen.Schemes.UpdateInstructions();
			}
			EndOfDay.Yandere.CameraEffects.UpdateBloom(1f);
			EndOfDay.Yandere.CameraEffects.UpdateBloomKnee(0.5f);
			EndOfDay.Yandere.CameraEffects.UpdateBloomRadius(4f);
			DatingGlobals.RivalSabotaged = EndOfDay.StudentManager.SabotageProgress;
			PlayerGlobals.PersonaID = EndOfDay.Yandere.PersonaID;
			PlayerGlobals.CorpsesDiscovered += EndOfDay.Police.Corpses;
			ClassGlobals.BonusStudyPoints = EndOfDay.Class.StudyPoints + EndOfDay.Class.BonusPoints;
			Debug.Log("Adding " + EndOfDay.Class.BonusPoints + " Bonus Study Points.");
			HomeGlobals.LateForSchool = false;
			PlayerGlobals.ShrineItems += EndOfDay.ShrineItemsCollected;
			EndOfDay.Counselor.SaveExcusesUsed();
			EndOfDay.Counselor.ExpelStudents();
			EndOfDay.Counselor.SaveCounselorData();
			StudentGlobals.ExpelProgress = EndOfDay.Counselor.RivalExpelProgress;
			CounselorGlobals.ReportedAlcohol = EndOfDay.Counselor.ReportedAlcohol;
			CounselorGlobals.ReportedCigarettes = EndOfDay.Counselor.ReportedCigarettes;
			CounselorGlobals.ReportedCondoms = EndOfDay.Counselor.ReportedCondoms;
			CounselorGlobals.ReportedTheft = EndOfDay.Counselor.ReportedTheft;
			CounselorGlobals.ReportedCheating = EndOfDay.Counselor.ReportedCheating;
			for (int j = 1; j < EndOfDay.WeaponManager.BroughtWeapons.Length; j++)
			{
				if (EndOfDay.WeaponManager.BroughtWeapons[j] == null)
				{
					PlayerGlobals.SetCannotBringItem(j, value: true);
				}
			}
			if (EndOfDay.Yandere.Inventory.ArrivedWithRatPoison && EndOfDay.Yandere.Inventory.EmeticPoisons == 0)
			{
				PlayerGlobals.SetCannotBringItem(4, value: true);
			}
			if (EndOfDay.Yandere.Inventory.ArrivedWithSake && !EndOfDay.Yandere.Inventory.Sake)
			{
				PlayerGlobals.SetCannotBringItem(5, value: true);
			}
			if (EndOfDay.Yandere.Inventory.ArrivedWithCigs && !EndOfDay.Yandere.Inventory.Cigs)
			{
				PlayerGlobals.SetCannotBringItem(6, value: true);
			}
			if (EndOfDay.Yandere.Inventory.ArrivedWithCondoms && !EndOfDay.Yandere.Inventory.Condoms)
			{
				PlayerGlobals.SetCannotBringItem(7, value: true);
			}
			if (EndOfDay.Yandere.Inventory.ArrivedWithSedative && EndOfDay.Yandere.Inventory.SedativePoisons == 0)
			{
				PlayerGlobals.SetCannotBringItem(9, value: true);
				PlayerGlobals.BoughtSedative = false;
			}
			if (EndOfDay.Yandere.Inventory.ArrivedWithPoison && EndOfDay.Yandere.Inventory.LethalPoisons == 0)
			{
				Debug.Log("The player arrived with lethal poison. The player doesn't have lethal poison anymore.");
				PlayerGlobals.SetCannotBringItem(11, value: true);
				PlayerGlobals.BoughtPoison = false;
			}
			if (EndOfDay.Yandere.Inventory.LethalPoisons > 0)
			{
				Debug.Log("The player is bringing some poison home from school.");
				PlayerGlobals.BoughtPoison = true;
			}
			if (EndOfDay.Yandere.Inventory.SedativePoisons > 0)
			{
				PlayerGlobals.BoughtSedative = true;
			}
			if (EndOfDay.Yandere.Inventory.LockPick)
			{
				PlayerGlobals.BoughtLockpick = true;
			}
			if (EndOfDay.Counselor.ReportedNarcotics)
			{
				PlayerGlobals.BoughtNarcotics = false;
			}
			if (EndOfDay.ExplosiveDeviceUsed)
			{
				PlayerGlobals.BoughtExplosive = false;
			}
			if (EndOfDay.Yandere.Inventory.Cigs)
			{
				PlayerGlobals.SetCannotBringItem(6, value: false);
			}
			if (EndOfDay.Yandere.Inventory.Sake)
			{
				PlayerGlobals.SetCannotBringItem(5, value: false);
			}
			if (EndOfDay.Yandere.Inventory.EmeticPoisons > 0)
			{
				PlayerGlobals.SetCannotBringItem(4, value: false);
			}
			if (EndOfDay.Yandere.Inventory.SedativePoisons > 0)
			{
				PlayerGlobals.BoughtSedative = true;
				PlayerGlobals.SetCannotBringItem(9, value: false);
			}
			if (EndOfDay.ArticleID == 1)
			{
				PlayerGlobals.Reputation += 20f * (1f + (float)ClassGlobals.LanguageGrade * 0.2f);
			}
			else if (EndOfDay.ArticleID == 3)
			{
				SchoolGlobals.SchoolAtmosphere += 20f * (1f + (float)ClassGlobals.LanguageGrade * 0.2f);
			}
			if (GameGlobals.PoliceYesterday)
			{
				PlayerGlobals.PoliceVisits++;
			}
			PlayerGlobals.BloodWitnessed += EndOfDay.BloodWitnessed;
			PlayerGlobals.WeaponWitnessed += EndOfDay.WeaponWitnessed;
			EndOfDay.ClubManager.UpdateQuitClubs();
			StudentGlobals.UpdateRivalReputation = false;
			Debug.Log("Making the game aware of the fact that ClubManager.ActivitiesAttended was " + EndOfDay.ClubManager.ActivitiesAttended + " at the end of this day.");
			ClubGlobals.ActivitiesAttended = EndOfDay.ClubManager.ActivitiesAttended;
			ArrestStudents();
			EndOfDay.SaveTopicsLearned();
			EndOfDay.RemovableItemManager.RemoveItems();
			EndOfDay.Yandere.CameraEffects.UpdateVignette(0f);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000BFB0 File Offset: 0x0000A1B0
		private void DisableThings(StudentScript studentScript_0)
		{
			if (studentScript_0 != null)
			{
				studentScript_0.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				studentScript_0.CharacterAnimation.enabled = true;
				studentScript_0.CharacterAnimation.Play(studentScript_0.IdleAnim);
				studentScript_0.EmptyHands();
				studentScript_0.SpeechLines.Stop();
				studentScript_0.Ragdoll.Zs.SetActive(value: false);
				studentScript_0.SmartPhone.SetActive(value: false);
				studentScript_0.MyController.enabled = false;
				studentScript_0.ShoeRemoval.enabled = false;
				studentScript_0.enabled = false;
				studentScript_0.gameObject.SetActive(value: true);
				studentScript_0.transform.parent = base.transform;
				studentScript_0.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000C07C File Offset: 0x0000A27C
		private void CheckForNatureOfDeath()
		{
			if (!(EndOfDay.StudentManager.Students[EndOfDay.StudentManager.RivalID] != null))
			{
				return;
			}
			RagdollScript ragdoll = EndOfDay.StudentManager.Students[EndOfDay.StudentManager.RivalID].Ragdoll;
			if (ragdoll.Student.DeathType == DeathType.Burning)
			{
				GameGlobals.SpecificEliminationID = 5;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Burn", 1);
				}
				Debug.Log("The game knows that she was burned, though.");
			}
			else if (ragdoll.Student.DeathType == DeathType.Electrocution)
			{
				GameGlobals.SpecificEliminationID = 8;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Electrocute", 1);
				}
				Debug.Log("The game knows that she was electrocuted, though.");
				Debug.Log("The game should now be informing the Content Checklist that the player has performed an electrocution.");
			}
			else if (ragdoll.Student.DeathType == DeathType.Weight)
			{
				GameGlobals.SpecificEliminationID = 6;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Crush", 1);
				}
				Debug.Log("The game knows that she was crushed, though.");
			}
			else if (ragdoll.Student.DeathType == DeathType.Drowning)
			{
				if (EndOfDay.PoolEvent)
				{
					Debug.Log("The player eliminated the rival during a pool event.");
					GameGlobals.SpecificEliminationID = 16;
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Pool", 1);
					}
				}
				else
				{
					Debug.Log("The game knows that she drowned, though.");
					GameGlobals.SpecificEliminationID = 7;
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Drown", 1);
					}
				}
			}
			else if (ragdoll.Decapitated)
			{
				GameGlobals.SpecificEliminationID = 10;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Fan", 1);
				}
				Debug.Log("The game knows that she was decapitated, though.");
			}
			else if (ragdoll.Student.DeathType == DeathType.Poison)
			{
				GameGlobals.SpecificEliminationID = 15;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Poison", 1);
				}
				Debug.Log("The game knows that she was poisoned, though.");
			}
			else if (ragdoll.Student.DeathType == DeathType.Falling)
			{
				GameGlobals.SpecificEliminationID = 17;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Push", 1);
				}
				Debug.Log("The game knows that she was pushed, though.");
			}
			else if (ragdoll.Student.Hunted)
			{
				GameGlobals.SpecificEliminationID = 14;
				if (!GameGlobals.Debug)
				{
					if (ragdoll.Student.MurderedByFragile)
					{
						PlayerPrefs.SetInt("DrivenToMurder", 1);
					}
					else
					{
						PlayerPrefs.SetInt("MurderSuicide", 1);
					}
				}
				Debug.Log("The game knows that the rival died as part of a murder-suicide, though.");
			}
			else if (ragdoll.Student.DeathType == DeathType.Weapon)
			{
				GameGlobals.SpecificEliminationID = 1;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Attack", 1);
				}
				Debug.Log("The game knows that she was attacked, though.");
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000C2F0 File Offset: 0x0000A4F0
		public void SetFormerRivalDeath(int int_0, StudentScript studentScript_0)
		{
			Debug.Log("The elimination information for Rival #" + int_0 + " is now being updated.");
			if (studentScript_0.DeathType == DeathType.Burning)
			{
				GameGlobals.SetSpecificEliminations(int_0, 5);
			}
			else if (studentScript_0.DeathType == DeathType.Electrocution)
			{
				GameGlobals.SetSpecificEliminations(int_0, 8);
			}
			else if (studentScript_0.DeathType == DeathType.Weight)
			{
				GameGlobals.SetSpecificEliminations(int_0, 6);
			}
			else if (studentScript_0.DeathType == DeathType.Drowning)
			{
				if (EndOfDay.PoolEvent)
				{
					GameGlobals.SetSpecificEliminations(int_0, 16);
				}
				else
				{
					GameGlobals.SetSpecificEliminations(int_0, 7);
				}
			}
			else if (studentScript_0.Ragdoll.Decapitated)
			{
				GameGlobals.SetSpecificEliminations(int_0, 10);
			}
			else if (studentScript_0.DeathType == DeathType.Poison)
			{
				GameGlobals.SetSpecificEliminations(int_0, 15);
			}
			else if (studentScript_0.DeathType == DeathType.Falling)
			{
				GameGlobals.SetSpecificEliminations(int_0, 17);
			}
			else if (studentScript_0.Hunted)
			{
				GameGlobals.SetSpecificEliminations(int_0, 14);
			}
			else if (studentScript_0.DeathType == DeathType.Weapon)
			{
				GameGlobals.SetSpecificEliminations(int_0, 1);
			}
			GameGlobals.SetRivalEliminations(int_0, 14);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000C3E8 File Offset: 0x0000A5E8
		public void ArrestStudents()
		{
			Debug.Log("Calling the ArrestStudents() function.");
			for (int i = 1; i < StudentManager.Students.Length; i++)
			{
				if (EndOfDay.StudentsToArrest[i])
				{
					StudentGlobals.SetStudentArrested(i, value: true);
					Debug.Log("Arresting Student ID: " + i);
				}
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000C444 File Offset: 0x0000A644
		public void SetPhonesHacked()
		{
			for (int i = 1; i < StudentManager.Students.Length; i++)
			{
				if (StudentManager.CommunalLocker.RivalPhone.StolenPhoneDropoff.PhoneHacked[i])
				{
					StudentGlobals.SetStudentPhoneStolen(i, value: true);
				}
			}
		}

		// Token: 0x04000071 RID: 113
		private StudentManagerScript StudentManager;

		// Token: 0x04000072 RID: 114
		private EndOfDayScript EndOfDay;

		// Token: 0x04000073 RID: 115
		private ExtraVoidGoddess ExtraVoidGoddess;

		// Token: 0x04000074 RID: 116
		private ExtraPoliceScript Police;

		// Token: 0x04000075 RID: 117
		private ExtraJsonScript ExtraJSON;
	}
}

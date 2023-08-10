using System;
using System.Collections;
using ExtraStudentsProject.ExtraStudentsOpenLibrary;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExtraStudentsProject
{
	// Token: 0x02000016 RID: 22
	internal class ExtraStudentInfoMenuScript : MonoBehaviour
	{
		// Token: 0x0600006D RID: 109 RVA: 0x0000D828 File Offset: 0x0000BA28
		private void Start()
		{
			StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			if (SceneManager.GetActiveScene().name == "SchoolScene")
			{
				StudentInfoMenu = StudentManager.Yandere.PauseScreen.StudentInfoMenu;
			}
			else
			{
				StudentInfoMenu = GameObject.Find("PauseScreen").GetComponent<PauseScreenScript>().StudentInfoMenu;
			}
			ExtraJSON = StudentInfoMenu.JSON.GetComponent<ExtraJsonScript>();
			ExtraStudentInfo = StudentInfoMenu.StudentInfo.GetComponent<ExtraStudentInfoScript>();
			Array.Resize(ref StudentInfoMenu.StudentPortraits, StudentManager.Students.Length);
			Array.Resize(ref StudentInfoMenu.PortraitLoaded, StudentManager.Students.Length);
			Array.Resize(ref StudentInfoMenu.DeathShadows, StudentManager.Students.Length);
			Array.Resize(ref StudentInfoMenu.Friends, StudentManager.Students.Length);
			Array.Resize(ref StudentInfoMenu.Panties, StudentManager.Students.Length);
			Array.Resize(ref StudentManager.PantyShotTaken, StudentManager.Students.Length);
			Array.Resize(ref PortraitScripts, StudentManager.Students.Length);
			Array.Resize(ref UselessArray, StudentManager.Students.Length);
			Array.Resize(ref NoStudent, StudentManager.Students.Length);
			StudentGlobals.GetStudentPhotographed(11);
			StudentInfoMenu.BusyBlocker.position = new Vector3(0f, 0f, 0f);
			Row = 20;
			for (int i = 101; i < StudentManager.Students.Length; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(StudentInfoMenu.StudentPortrait, base.transform.position, Quaternion.identity);
				gameObject.transform.parent = StudentInfoMenu.PortraitGrid;
				gameObject.transform.localPosition = new Vector3(-300f + (float)StudentInfoMenu.Column * 150f, 80f - (float)Row * 160f, 0f);
				gameObject.transform.localEulerAngles = Vector3.zero;
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				PortraitScripts[i] = gameObject.GetComponent<StudentPortraitScript>();
				StudentInfoMenu.Column++;
				if (StudentInfoMenu.Column > 4)
				{
					StudentInfoMenu.Column = 0;
					Row++;
				}
				if (StudentManager.Students[i] == null)
				{
					NoStudent[i] = true;
				}
				if (GameGlobals.Eighties && !NoStudent[i])
				{
					StudentGlobals.SetStudentPhotographed(i, value: true);
				}
			}
			StudentInfoMenu.Column = 0;
			StudentInfoMenu.Row = 0;
			PortraitsUpdated = false;
			StudentInfoMenu.Scrollbar.parent.gameObject.SetActive(value: false);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000DB70 File Offset: 0x0000BD70
		private void Update()
		{
			if (StudentInfoMenu.StudentPortraits.Length > 101 + ModdedStudents)
			{
				ModdedStudents += 5;
				ModdedStudentRows++;
				StudentInfoMenu.Rows = 20 + ModdedStudentRows;
			}
			if (!PortraitsUpdated)
			{
				StartCoroutine(UpdatePortraitsAsync());
				PortraitsUpdated = false;
			}
			if (StudentInfoMenu.StudentID >= PortraitScripts.Length)
			{
				NeedsReset = true;
			}
			else
			{
				NeedsReset = false;
			}
			if (Input.GetButtonDown("A"))
			{
				if (StudentInfoMenu.PromptBar.Label[0].text != string.Empty)
				{
					if (!StudentGlobals.GetStudentPhotographed(StudentInfoMenu.StudentID) && (StudentInfoMenu.StudentID <= 97 || StudentInfoMenu.StudentID >= 101))
					{
						StudentGlobals.SetStudentPhotographed(StudentInfoMenu.StudentID, value: true);
						if (StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID] != null)
						{
							for (int i = 0; i < StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID].Outlines.Length; i++)
							{
								if (StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID].Outlines[i] != null)
								{
									StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID].Outlines[i].enabled = true;
								}
							}
						}
						StudentInfoMenu.PauseScreen.ServiceMenu.gameObject.SetActive(value: true);
						StudentInfoMenu.PauseScreen.ServiceMenu.UpdateList();
						StudentInfoMenu.PauseScreen.ServiceMenu.UpdateDesc();
						StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
						StudentInfoMenu.GettingInfo = false;
						StudentInfoMenu.gameObject.SetActive(value: false);
					}
					else if (StudentInfoMenu.UsingLifeNote)
					{
						StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
						StudentInfoMenu.PauseScreen.Sideways = false;
						StudentInfoMenu.PauseScreen.Show = false;
						StudentInfoMenu.gameObject.SetActive(value: false);
						StudentInfoMenu.NoteWindow.TargetStudent = StudentInfoMenu.StudentID;
						StudentInfoMenu.NoteWindow.gameObject.SetActive(value: true);
						StudentInfoMenu.NoteWindow.SlotLabels[1].text = StudentManager.Students[StudentInfoMenu.StudentID].Name;
						StudentInfoMenu.NoteWindow.SlotsFilled[1] = true;
						StudentInfoMenu.UsingLifeNote = false;
						StudentInfoMenu.PromptBar.Label[0].text = "Confirm";
						StudentInfoMenu.PromptBar.UpdateButtons();
						StudentInfoMenu.NoteWindow.CheckForCompletion();
					}
					else
					{
						StudentInfoMenu.StudentInfo.gameObject.SetActive(value: true);
						if (StudentInfoMenu.StudentID < 101)
						{
							StudentInfoMenu.StudentInfo.UpdateInfo(StudentInfoMenu.StudentID);
						}
						else
						{
							ExtraStudentInfo.Start();
							ExtraStudentInfo.UpdateInfo(StudentInfoMenu.StudentID);
						}
						StudentInfoMenu.StudentInfo.Topics.SetActive(value: false);
						StudentInfoMenu.gameObject.SetActive(value: false);
						StudentInfoMenu.PromptBar.ClearButtons();
						if (StudentInfoMenu.Gossiping)
						{
							StudentInfoMenu.PromptBar.Label[0].text = "Gossip";
						}
						if (StudentInfoMenu.Distracting)
						{
							StudentInfoMenu.PromptBar.Label[0].text = "Distract";
						}
						if (StudentInfoMenu.CyberBullying || StudentInfoMenu.CyberStalking)
						{
							StudentInfoMenu.PromptBar.Label[0].text = "Accept";
						}
						if (StudentInfoMenu.FindingLocker)
						{
							StudentInfoMenu.PromptBar.Label[0].text = "Find Locker";
						}
						if (StudentInfoMenu.MatchMaking)
						{
							StudentInfoMenu.PromptBar.Label[0].text = "Match";
						}
						if (StudentInfoMenu.Targeting || StudentInfoMenu.UsingLifeNote)
						{
							StudentInfoMenu.PromptBar.Label[0].text = "Kill";
						}
						if (StudentInfoMenu.SendingHome)
						{
							StudentInfoMenu.PromptBar.Label[0].text = "Send Home";
						}
						if (StudentInfoMenu.FiringCouncilMember)
						{
							StudentInfoMenu.PromptBar.Label[0].text = "Fire";
						}
						if (StudentInfoMenu.GettingOpinions)
						{
							StudentInfoMenu.PromptBar.Label[0].text = "Get Opinions";
						}
						if (StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID] != null)
						{
							if (StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID].gameObject.activeInHierarchy)
							{
								if (StudentInfoMenu.StudentManager.Tag.Target == StudentManager.Students[StudentInfoMenu.StudentID].Head)
								{
									StudentInfoMenu.PromptBar.Label[2].text = "Untag";
								}
								else
								{
									StudentInfoMenu.PromptBar.Label[2].text = "Tag";
								}
							}
							else
							{
								StudentInfoMenu.PromptBar.Label[2].text = "";
							}
						}
						else
						{
							StudentInfoMenu.PromptBar.Label[2].text = "";
						}
						StudentInfoMenu.PromptBar.Label[1].text = "Back";
						StudentInfoMenu.PromptBar.Label[3].text = "Interests";
						StudentInfoMenu.PromptBar.Label[6].text = "Reputation";
						StudentInfoMenu.PromptBar.UpdateButtons();
					}
					if (StudentInfoMenu.PauseScreen.Eighties)
					{
						StudentInfoMenu.PauseScreen.BlackenAllText();
					}
				}
			}
			else if (Input.GetButtonDown("B"))
			{
				PortraitsUpdated = false;
				StudentInfoMenu.BusyBlocker.position = new Vector3(0f, 0f, 0f);
				if (!StudentInfoMenu.Gossiping && !StudentInfoMenu.Distracting && !StudentInfoMenu.MatchMaking && !StudentInfoMenu.Targeting)
				{
					if (!StudentInfoMenu.CyberBullying && !StudentInfoMenu.CyberStalking && !StudentInfoMenu.FindingLocker)
					{
						if (!StudentInfoMenu.SendingHome && !StudentInfoMenu.GettingInfo && !StudentInfoMenu.GettingOpinions && !StudentInfoMenu.FiringCouncilMember)
						{
							if (StudentInfoMenu.UsingLifeNote)
							{
								StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
								StudentInfoMenu.PauseScreen.Sideways = false;
								StudentInfoMenu.PauseScreen.Show = false;
								StudentInfoMenu.gameObject.SetActive(value: false);
								StudentInfoMenu.NoteWindow.gameObject.SetActive(value: true);
								StudentInfoMenu.UsingLifeNote = false;
							}
							else
							{
								StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
								StudentInfoMenu.PauseScreen.Sideways = false;
								StudentInfoMenu.PauseScreen.PressedB = true;
								StudentInfoMenu.gameObject.SetActive(value: false);
								StudentInfoMenu.PromptBar.ClearButtons();
								StudentInfoMenu.PromptBar.Label[0].text = "Accept";
								StudentInfoMenu.PromptBar.Label[1].text = "Exit";
								StudentInfoMenu.PromptBar.Label[4].text = "Choose";
								StudentInfoMenu.PromptBar.UpdateButtons();
								StudentInfoMenu.PromptBar.Show = true;
							}
						}
						else
						{
							StudentInfoMenu.PauseScreen.ServiceMenu.gameObject.SetActive(value: true);
							StudentInfoMenu.PauseScreen.ServiceMenu.UpdateList();
							StudentInfoMenu.PauseScreen.ServiceMenu.UpdateDesc();
							StudentInfoMenu.gameObject.SetActive(value: false);
							StudentInfoMenu.FiringCouncilMember = false;
							StudentInfoMenu.GettingOpinions = false;
							StudentInfoMenu.SendingHome = false;
							StudentInfoMenu.GettingInfo = false;
						}
					}
					else
					{
						StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
						StudentInfoMenu.PauseScreen.Sideways = false;
						StudentInfoMenu.PauseScreen.Show = false;
						StudentInfoMenu.gameObject.SetActive(value: false);
						Time.timeScale = 1f;
						if (StudentInfoMenu.FindingLocker)
						{
							StudentInfoMenu.PauseScreen.Yandere.RPGCamera.enabled = true;
						}
						StudentInfoMenu.FindingLocker = false;
						StudentInfoMenu.PromptBar.ClearButtons();
						StudentInfoMenu.PromptBar.Show = false;
					}
				}
				else
				{
					if (StudentInfoMenu.Targeting)
					{
						StudentInfoMenu.PauseScreen.Yandere.RPGCamera.enabled = true;
					}
					StudentInfoMenu.PauseScreen.Yandere.Interaction = YandereInteractionType.Bye;
					StudentInfoMenu.PauseScreen.Yandere.TalkTimer = 2f;
					StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
					StudentInfoMenu.PauseScreen.Sideways = false;
					StudentInfoMenu.PauseScreen.Show = false;
					StudentInfoMenu.gameObject.SetActive(value: false);
					Time.timeScale = 1f;
					StudentInfoMenu.Distracting = false;
					StudentInfoMenu.MatchMaking = false;
					StudentInfoMenu.Gossiping = false;
					StudentInfoMenu.Targeting = false;
					StudentInfoMenu.PromptBar.ClearButtons();
					StudentInfoMenu.PromptBar.Show = false;
				}
			}
			if (StudentInfoMenu.InputManager.TappedUp || StudentInfoMenu.InputManager.TappedDown || StudentInfoMenu.InputManager.TappedRight || StudentInfoMenu.InputManager.TappedLeft)
			{
				if (NeedsReset)
				{
					StudentInfoMenu.Column = 0;
					UpdateHighlight();
				}
				else
				{
					UpdateHighlight();
				}
			}
			if (StudentInfoMenu.GrabPortraitsNextFrame)
			{
				StudentInfoMenu.Frame++;
				if (StudentInfoMenu.Frame > 1)
				{
					StartCoroutine(UpdatePortraitsAsync());
					StudentInfoMenu.GrabPortraitsNextFrame = false;
					StudentInfoMenu.Frame = 0;
				}
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000025A1 File Offset: 0x000007A1
		public IEnumerator UpdatePortraitsAsync()
		{
			string EightiesPrefix = "";
			if (StudentInfoMenu.PauseScreen.Eighties)
			{
				EightiesPrefix = "1989";
			}
			for (int ID = 101; ID < StudentManager.Students.Length; ID++)
			{
				if (!UselessArray[ID])
				{
					if (ID > 100)
					{
						if (!StudentInfoMenu.PauseScreen.Eighties && (StudentInfoMenu.PauseScreen.Eighties || ID >= 12) && (StudentInfoMenu.PauseScreen.Eighties || ID <= 20))
						{
							PortraitScripts[ID].Portrait.mainTexture = StudentInfoMenu.RivalPortraits[ID];
						}
						else if (StudentGlobals.GetStudentPhotographed(ID))
						{
							string url = "file:///" + Application.streamingAssetsPath + "/Portraits" + EightiesPrefix + "/Student_" + ID + ".png";
							WWW www = new WWW(url);
							yield return www;
							if (www.error == null)
							{
								if (!StudentGlobals.GetStudentReplaced(ID))
								{
									PortraitScripts[ID].Portrait.mainTexture = www.texture;
								}
								else
								{
									PortraitScripts[ID].Portrait.mainTexture = StudentInfoMenu.BlankPortrait;
								}
							}
							else
							{
								Debug.Log("Student #" + ID + " gets an '' Unknown'' portrait because an error occured.");
								PortraitScripts[ID].Portrait.mainTexture = StudentInfoMenu.UnknownPortrait;
							}
							UselessArray[ID] = true;
						}
						else
						{
							PortraitScripts[ID].Portrait.mainTexture = StudentInfoMenu.UnknownPortrait;
						}
					}
					else
					{
						switch (ID)
						{
						default:
							PortraitScripts[ID].Portrait.mainTexture = StudentInfoMenu.RivalPortraits[ID];
							break;
						case 98:
							PortraitScripts[ID].Portrait.mainTexture = StudentInfoMenu.Counselor;
							break;
						case 99:
							PortraitScripts[ID].Portrait.mainTexture = StudentInfoMenu.Headmaster;
							break;
						case 100:
							PortraitScripts[ID].Portrait.mainTexture = StudentInfoMenu.InfoChan;
							break;
						}
					}
				}
				if (StudentManager.PantyShotTaken[ID] || PlayerGlobals.GetStudentPantyShot(ID))
				{
					PortraitScripts[ID].Panties.SetActive(value: true);
				}
				if (StudentManager.Students[ID] != null)
				{
					PortraitScripts[ID].Friend.SetActive(StudentManager.Students[ID].Friend);
				}
				if (StudentGlobals.GetStudentDying(ID) || StudentGlobals.GetStudentDead(ID) || (StudentManager.Students[ID] != null && !StudentManager.Students[ID].Alive))
				{
					PortraitScripts[ID].DeathShadow.SetActive(value: true);
				}
				if (MissionModeGlobals.MissionMode && ID == 1)
				{
					PortraitScripts[ID].DeathShadow.SetActive(value: true);
				}
				if (SceneManager.GetActiveScene().name == "SchoolScene" && StudentManager.Students[ID] != null && StudentManager.Students[ID].Tranquil)
				{
					PortraitScripts[ID].DeathShadow.SetActive(value: true);
				}
				if (StudentGlobals.GetStudentArrested(ID))
				{
					PortraitScripts[ID].PrisonBars.SetActive(value: true);
					PortraitScripts[ID].DeathShadow.SetActive(value: true);
				}
				if (StudentManager.Eighties && ID > 11 && ID < 21 && DateGlobals.Week < ID - 10)
				{
					PortraitScripts[ID].Portrait.mainTexture = StudentInfoMenu.UnknownPortrait;
				}
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000E7A0 File Offset: 0x0000C9A0
		private void UpdateHighlight()
		{
			StudentInfoMenu.Highlight.localPosition = new Vector3(-300f + (float)StudentInfoMenu.Column * 150f, 80f - (float)StudentInfoMenu.Row * 160f, StudentInfoMenu.Highlight.localPosition.z);
			StudentInfoMenu.BusyBlocker.position = new Vector3(0f, 0f, 0f);
			StudentInfoMenu.StudentID = 1 + (StudentInfoMenu.Column + StudentInfoMenu.Row * StudentInfoMenu.Columns);
			if ((StudentInfoMenu.StudentID > 97 && StudentInfoMenu.StudentID < 101) || StudentGlobals.GetStudentPhotographed(StudentInfoMenu.StudentID))
			{
				if (SceneManager.GetActiveScene().name == "SchoolScene")
				{
					if (!NoStudent[StudentInfoMenu.StudentID])
					{
						StudentInfoMenu.PromptBar.Label[0].text = "View Info";
						StudentInfoMenu.PromptBar.UpdateButtons();
					}
					else
					{
						StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
						StudentInfoMenu.PromptBar.UpdateButtons();
					}
				}
				else
				{
					StudentInfoMenu.PromptBar.Label[0].text = "View Info";
					StudentInfoMenu.PromptBar.UpdateButtons();
				}
			}
			else
			{
				StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
				StudentInfoMenu.PromptBar.UpdateButtons();
			}
			if (StudentInfoMenu.UsingLifeNote)
			{
				if (StudentInfoMenu.StudentID < 101)
				{
					if (StudentInfoMenu.StudentID != 1 && (StudentInfoMenu.StudentID <= 11 || StudentInfoMenu.StudentID >= 21) && (StudentInfoMenu.StudentID <= 97 || StudentInfoMenu.StudentID >= 101) && !StudentInfoMenu.StudentPortraits[StudentInfoMenu.StudentID].DeathShadow.activeInHierarchy && (!(StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID] != null) || StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID].enabled))
					{
						StudentInfoMenu.PromptBar.Label[0].text = "Kill";
					}
					else
					{
						StudentInfoMenu.PromptBar.Label[0].text = "";
					}
				}
				else if (StudentInfoMenu.StudentID != 1 && (StudentInfoMenu.StudentID <= 11 || StudentInfoMenu.StudentID >= 21) && (StudentInfoMenu.StudentID <= 97 || StudentInfoMenu.StudentID >= 101) && !PortraitScripts[StudentInfoMenu.StudentID].DeathShadow.activeInHierarchy && (!(StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID] != null) || StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID].enabled))
				{
					StudentInfoMenu.PromptBar.Label[0].text = "Kill";
				}
				else
				{
					StudentInfoMenu.PromptBar.Label[0].text = "";
				}
				if (NoStudent[StudentInfoMenu.StudentID])
				{
					StudentInfoMenu.PromptBar.Label[0].text = "";
				}
				StudentInfoMenu.PromptBar.UpdateButtons();
			}
			if (StudentInfoMenu.Gossiping)
			{
				if (StudentInfoMenu.StudentID < 101)
				{
					if (StudentInfoMenu.StudentID == 1 || StudentInfoMenu.StudentID == StudentInfoMenu.PauseScreen.Yandere.TargetStudent.StudentID || StudentInfoMenu.JSON.Students[StudentInfoMenu.StudentID].Club == ClubType.Sports || StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID] == null || StudentGlobals.GetStudentDead(StudentInfoMenu.StudentID) || (StudentInfoMenu.StudentID == StudentInfoMenu.StudentManager.RivalID && StudentInfoMenu.StudentManager.Police.EndOfDay.RivalEliminationMethod == RivalEliminationType.Expelled) || (StudentInfoMenu.StudentID > 89 && StudentInfoMenu.StudentID < 101))
					{
						StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
					}
				}
				else if (StudentInfoMenu.StudentID == 1 || StudentInfoMenu.StudentID == StudentInfoMenu.PauseScreen.Yandere.TargetStudent.StudentID || ExtraJSON.Students[StudentInfoMenu.StudentID].Club == ClubType.Sports || StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID] == null || StudentGlobals.GetStudentDead(StudentInfoMenu.StudentID) || (StudentInfoMenu.StudentID == StudentInfoMenu.StudentManager.RivalID && StudentInfoMenu.StudentManager.Police.EndOfDay.RivalEliminationMethod == RivalEliminationType.Expelled) || (StudentInfoMenu.StudentID > 89 && StudentInfoMenu.StudentID < 101))
				{
					StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
				}
				StudentInfoMenu.PromptBar.UpdateButtons();
			}
			if (StudentInfoMenu.CyberBullying)
			{
				if (StudentInfoMenu.StudentID < 101)
				{
					if (StudentInfoMenu.JSON.Students[StudentInfoMenu.StudentID].Gender == 1 || StudentGlobals.GetStudentDead(StudentInfoMenu.StudentID) || (StudentInfoMenu.StudentID > 97 && StudentInfoMenu.StudentID < 101))
					{
						StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
					}
				}
				else if (ExtraJSON.Students[StudentInfoMenu.StudentID].Gender == 1 || StudentGlobals.GetStudentDead(StudentInfoMenu.StudentID) || (StudentInfoMenu.StudentID > 97 && StudentInfoMenu.StudentID < 101))
				{
					StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
				}
				StudentInfoMenu.PromptBar.UpdateButtons();
			}
			if (StudentInfoMenu.CyberStalking && (StudentGlobals.GetStudentDead(StudentInfoMenu.StudentID) || StudentGlobals.GetStudentArrested(StudentInfoMenu.StudentID) || (StudentInfoMenu.StudentID > 97 && StudentInfoMenu.StudentID < 101)))
			{
				StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
				StudentInfoMenu.PromptBar.UpdateButtons();
			}
			if (StudentInfoMenu.FindingLocker && (StudentInfoMenu.StudentID == 1 || (StudentInfoMenu.StudentID > 89 && StudentInfoMenu.StudentID < 101) || (StudentManager.Students[StudentInfoMenu.StudentID] != null && StudentManager.Students[StudentInfoMenu.StudentID].Club == ClubType.Council) || StudentGlobals.GetStudentDead(StudentInfoMenu.StudentID)))
			{
				StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
				StudentInfoMenu.PromptBar.UpdateButtons();
			}
			if (StudentInfoMenu.Distracting)
			{
				StudentInfoMenu.Dead = false;
				if (StudentManager.Students[StudentInfoMenu.StudentID] == null)
				{
					StudentInfoMenu.Dead = true;
				}
				if (StudentInfoMenu.Dead)
				{
					StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
					StudentInfoMenu.PromptBar.UpdateButtons();
				}
				else if (StudentInfoMenu.StudentID == 1 || !StudentManager.Students[StudentInfoMenu.StudentID].Alive || StudentInfoMenu.StudentID == StudentInfoMenu.PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentKidnapped(StudentInfoMenu.StudentID) || StudentManager.Students[StudentInfoMenu.StudentID].Tranquil || StudentManager.Students[StudentInfoMenu.StudentID].Teacher || StudentManager.Students[StudentInfoMenu.StudentID].Slave || StudentGlobals.GetStudentDead(StudentInfoMenu.StudentID) || StudentManager.Students[StudentInfoMenu.StudentID].MyBento.Tampered || (StudentInfoMenu.StudentID > 97 && StudentInfoMenu.StudentID < 101))
				{
					if (StudentInfoMenu.StudentID > 1 && StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID] != null && StudentManager.Students[StudentInfoMenu.StudentID].InEvent)
					{
						StudentInfoMenu.BusyBlocker.position = StudentInfoMenu.Highlight.position;
					}
					StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
					StudentInfoMenu.PromptBar.UpdateButtons();
				}
			}
			if (StudentInfoMenu.MatchMaking && (StudentInfoMenu.StudentID == StudentInfoMenu.PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentDead(StudentInfoMenu.StudentID) || (StudentInfoMenu.StudentID > 97 && StudentInfoMenu.StudentID < 101)))
			{
				StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
				StudentInfoMenu.PromptBar.UpdateButtons();
			}
			if (StudentInfoMenu.Targeting && (StudentManager.Students[StudentInfoMenu.StudentID] == null || StudentInfoMenu.StudentID == 1 || (StudentInfoMenu.StudentID > 97 && StudentInfoMenu.StudentID < 101) || StudentGlobals.GetStudentDead(StudentInfoMenu.StudentID) || !StudentInfoMenu.StudentManager.Students[StudentInfoMenu.StudentID].gameObject.activeInHierarchy || StudentManager.Students[StudentInfoMenu.StudentID].InEvent || StudentManager.Students[StudentInfoMenu.StudentID].Tranquil))
			{
				if (StudentInfoMenu.StudentID > 1 && StudentManager.Students[StudentInfoMenu.StudentID] != null && StudentManager.Students[StudentInfoMenu.StudentID].InEvent)
				{
					StudentInfoMenu.BusyBlocker.position = StudentInfoMenu.Highlight.position;
				}
				StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
				StudentInfoMenu.PromptBar.UpdateButtons();
			}
			if (StudentInfoMenu.SendingHome)
			{
				Debug.Log("Highlighting student number " + StudentInfoMenu.StudentID);
				if (StudentManager.Students[StudentInfoMenu.StudentID] != null)
				{
					StudentScript studentScript = StudentManager.Students[StudentInfoMenu.StudentID];
					if (StudentInfoMenu.StudentID == 1 || StudentGlobals.GetStudentDead(StudentInfoMenu.StudentID) || (StudentInfoMenu.StudentID < 98 && studentScript.SentHome) || (StudentInfoMenu.StudentID > 97 && StudentInfoMenu.StudentID < 101) || StudentGlobals.StudentSlave == StudentInfoMenu.StudentID || (studentScript.Club == ClubType.MartialArts && studentScript.ClubAttire) || (studentScript.Club == ClubType.Sports && studentScript.ClubAttire) || StudentManager.Students[StudentInfoMenu.StudentID].CameraReacting || !StudentGlobals.GetStudentPhotographed(StudentInfoMenu.StudentID) || studentScript.Wet || studentScript.Slave || studentScript.Phoneless)
					{
						StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
						StudentInfoMenu.PromptBar.UpdateButtons();
					}
				}
			}
			if (StudentInfoMenu.GettingInfo)
			{
				if (!StudentGlobals.GetStudentPhotographed(StudentInfoMenu.StudentID) && (StudentInfoMenu.StudentID <= 97 || StudentInfoMenu.StudentID >= 101))
				{
					StudentInfoMenu.PromptBar.Label[0].text = "Get Info";
				}
				else
				{
					StudentInfoMenu.PromptBar.Label[0].text = string.Empty;
				}
				StudentInfoMenu.PromptBar.UpdateButtons();
			}
			UpdateStudentLabels();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000F6A8 File Offset: 0x0000D8A8
		private void UpdateStudentLabels()
		{
			if (StudentInfoMenu.StudentID < 101)
			{
				if ((StudentInfoMenu.StudentID <= 97 || StudentInfoMenu.StudentID >= 101) && !StudentGlobals.GetStudentPhotographed(StudentInfoMenu.StudentID) && !StudentInfoMenu.GettingInfo)
				{
					StudentInfoMenu.NameLabel.text = "Unknown";
				}
				else
				{
					StudentInfoMenu.NameLabel.text = StudentInfoMenu.JSON.Students[StudentInfoMenu.StudentID].Name;
				}
			}
			else if ((StudentInfoMenu.StudentID <= 97 || StudentInfoMenu.StudentID >= 101) && !StudentGlobals.GetStudentPhotographed(StudentInfoMenu.StudentID) && !StudentInfoMenu.GettingInfo)
			{
				StudentInfoMenu.NameLabel.text = "Unknown";
			}
			else
			{
				StudentInfoMenu.NameLabel.text = ExtraJSON.Students[StudentInfoMenu.StudentID].Name;
			}
		}

		// Token: 0x04000082 RID: 130
		private StudentInfoMenuScript StudentInfoMenu;

		// Token: 0x04000083 RID: 131
		private StudentManagerScript StudentManager;

		// Token: 0x04000084 RID: 132
		public StudentPortraitScript[] PortraitScripts;

		// Token: 0x04000085 RID: 133
		private ExtraStudentInfoScript ExtraStudentInfo;

		// Token: 0x04000086 RID: 134
		private ExtraJsonScript ExtraJSON;

		// Token: 0x04000087 RID: 135
		public bool[] UselessArray;

		// Token: 0x04000088 RID: 136
		public bool[] NoStudent;

		// Token: 0x04000089 RID: 137
		private bool PortraitsUpdated;

		// Token: 0x0400008A RID: 138
		private bool NeedsReset;

		// Token: 0x0400008B RID: 139
		private int Row;

		// Token: 0x0400008C RID: 140
		private int ModdedStudents;

		// Token: 0x0400008D RID: 141
		private int ModdedStudentRows;
	}
}

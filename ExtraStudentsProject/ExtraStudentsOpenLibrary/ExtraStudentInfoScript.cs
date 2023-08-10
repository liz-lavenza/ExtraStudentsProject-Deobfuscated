using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExtraStudentsProject.ExtraStudentsOpenLibrary
{
	// Token: 0x0200001C RID: 28
	public class ExtraStudentInfoScript : MonoBehaviour
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x0001EE28 File Offset: 0x0001D028
		public void Start()
		{
			StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			PauseScreen = GameObject.Find("PauseScreen").GetComponent<PauseScreenScript>();
			StudentInfo = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>();
			if (SceneManager.GetActiveScene().name == "SchoolScene")
			{
				NewTopicInterface = GameObject.Find("DialogueWheel").GetComponent<ExtraDialogueWheelScript>().NewInterface;
				TextMessage = GameObject.Find("UI Camera/Panel/PauseScreen/TextMessage");
				NewJSON = StudentManager.JSON.GetComponent<ExtraJsonScript>();
			}
			else
			{
				NewJSON = GameObject.Find("JSON").GetComponent<ExtraJsonScript>();
			}
			Yandere = StudentManager.Yandere;
			DialogueWheel = StudentInfo.DialogueWheel;
			CurrentStudent = StudentInfo.CurrentStudent;
			PromptBar = StudentInfo.PromptBar;
			StudentInfoMenu = PauseScreen.StudentInfoMenu;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0001EF3C File Offset: 0x0001D13C
		public void UpdateInfo(int ID)
		{
			StudentInfo.gameObject.SetActive(value: true);
			Updated = false;
			StudentInfo.CurrentStudent = ID;
			if (!StudentInfo.UpdatedOnce)
			{
				StudentInfo.Eighties = GameGlobals.Eighties;
			}
			StudentInfo.UpdatedOnce = true;
			ExtraStudentJson extraStudentJson = NewJSON.Students[ID];
			if (extraStudentJson.RealName == "")
			{
				StudentInfo.NameLabel.transform.localPosition = new Vector3(-228f, 195f, 0f);
				StudentInfo.RealNameLabel.text = "";
			}
			else
			{
				StudentInfo.NameLabel.transform.localPosition = new Vector3(-228f, 210f, 0f);
				StudentInfo.RealNameLabel.text = "Real Name: " + extraStudentJson.RealName;
			}
			StudentInfo.NameLabel.text = extraStudentJson.Name;
			string text = extraStudentJson.Class.ToString() ?? "";
			text = text.Insert(1, "-");
			StudentInfo.ClassLabel.text = "Class " + text;
			switch (ID)
			{
			case 90:
			case 97:
			case 98:
			case 99:
			case 100:
				StudentInfo.ClassLabel.text = "";
				break;
			}
			float num = ((!(StudentInfo.StudentManager != null)) ? ((float)StudentGlobals.GetStudentReputation(ID)) : StudentInfo.StudentManager.StudentReps[ID]);
			if (num < 0f)
			{
				StudentInfo.ReputationLabel.text = num.ToString() ?? "";
			}
			else if (num > 0f)
			{
				StudentInfo.ReputationLabel.text = "+" + num;
			}
			else
			{
				StudentInfo.ReputationLabel.text = "0";
			}
			StudentInfo.ReputationBar.localPosition = new Vector3(num * 0.96f, StudentInfo.ReputationBar.localPosition.y, StudentInfo.ReputationBar.localPosition.z);
			if (StudentInfo.ReputationBar.localPosition.x > 96f)
			{
				StudentInfo.ReputationBar.localPosition = new Vector3(96f, StudentInfo.ReputationBar.localPosition.y, StudentInfo.ReputationBar.localPosition.z);
			}
			if (StudentInfo.ReputationBar.localPosition.x < -96f)
			{
				StudentInfo.ReputationBar.localPosition = new Vector3(-96f, StudentInfo.ReputationBar.localPosition.y, StudentInfo.ReputationBar.localPosition.z);
			}
			if (StudentManager != null && StudentManager.Students[StudentInfo.CurrentStudent] != null)
			{
				StudentInfo.PersonaLabel.text = Persona.PersonaNames[StudentManager.Students[StudentInfo.CurrentStudent].Persona];
			}
			else
			{
				StudentInfo.PersonaLabel.text = Persona.PersonaNames[extraStudentJson.Persona];
			}
			if (extraStudentJson.Persona == PersonaType.Strict && extraStudentJson.Club == ClubType.GymTeacher && !StudentGlobals.GetStudentReplaced(ID))
			{
				StudentInfo.PersonaLabel.text = "Friendly but Strict";
			}
			MatchmadeCheck();
			int num2 = 0;
			if (StudentInfo.StudentManager != null)
			{
				num2 = StudentManager.SuitorID;
			}
			if (StudentInfo.Matchmade)
			{
				StudentInfo.LeftCrushLabel.text = "Relationship";
				if (StudentManager.Students[extraStudentJson.Crush].StudentID < 101)
				{
					StudentInfo.CrushLabel.text = StudentInfo.JSON.Students[extraStudentJson.Crush].Name;
					StudentInfo.CrushLabel.text = StudentInfo.PartnerName;
				}
				else
				{
					StudentInfo.CrushLabel.text = NewJSON.Students[extraStudentJson.Crush].Name;
					StudentInfo.CrushLabel.text = StudentInfo.PartnerName;
				}
			}
			else
			{
				StudentInfo.LeftCrushLabel.text = "Crush";
				if (StudentInfo.CurrentStudent > 10 && StudentInfo.CurrentStudent < 21)
				{
					if (StudentInfo.StudentManager != null && StudentInfo.CurrentStudent == StudentInfo.StudentManager.RivalID)
					{
						if (StudentManager.Students[extraStudentJson.Crush].StudentID < 101)
						{
							StudentInfo.CrushLabel.text = StudentInfo.JSON.Students[extraStudentJson.Crush].Name;
						}
						else
						{
							StudentInfo.CrushLabel.text = NewJSON.Students[extraStudentJson.Crush].Name;
						}
					}
					else
					{
						StudentInfo.CrushLabel.text = "None Anymore";
					}
				}
				if (StudentInfo.CurrentStudent == num2)
				{
					if (StudentManager != null && StudentManager.LoveManager.SuitorProgress == 0)
					{
						StudentInfo.CrushLabel.text = "Unknown";
					}
					else if (StudentManager.Students[extraStudentJson.Crush].StudentID < 101)
					{
						StudentInfo.CrushLabel.text = StudentInfo.JSON.Students[extraStudentJson.Crush].Name;
					}
					else
					{
						StudentInfo.CrushLabel.text = NewJSON.Students[extraStudentJson.Crush].Name;
					}
				}
				else if (extraStudentJson.Crush == 0)
				{
					StudentInfo.CrushLabel.text = "Unknown";
				}
				else if (extraStudentJson.Crush == 99)
				{
					StudentInfo.CrushLabel.text = "?????";
				}
				else
				{
					if (StudentManager.Students[extraStudentJson.Crush].StudentID < 101)
					{
						StudentInfo.CrushLabel.text = StudentInfo.JSON.Students[extraStudentJson.Crush].Name;
					}
					else
					{
						StudentInfo.CrushLabel.text = NewJSON.Students[extraStudentJson.Crush].Name;
					}
					for (int i = 2; i < 11; i++)
					{
						if (StudentInfo.StudentManager != null && StudentInfo.CurrentStudent == StudentInfo.StudentManager.SuitorIDs[i] && StudentInfo.StudentManager.Week < i)
						{
							StudentInfo.CrushLabel.text = "Unknown";
						}
					}
				}
			}
			if (extraStudentJson.Club < ClubType.Teacher)
			{
				StudentInfo.OccupationLabel.text = "Club";
			}
			else
			{
				StudentInfo.OccupationLabel.text = "Occupation";
			}
			if (extraStudentJson.Club < ClubType.Teacher)
			{
				StudentInfo.ClubLabel.text = Club.ClubNames[extraStudentJson.Club];
			}
			else
			{
				StudentInfo.ClubLabel.text = Club.TeacherClubNames[extraStudentJson.Class];
			}
			if (ClubGlobals.GetClubClosed(extraStudentJson.Club))
			{
				StudentInfo.ClubLabel.text = "No Club";
			}
			StudentInfo.StrengthLabel.text = PatvTfGLO4[extraStudentJson.Strength];
			AudioSource component = GetComponent<AudioSource>();
			component.enabled = false;
			StudentInfo.Static.SetActive(value: false);
			component.volume = 0f;
			component.Stop();
			string text2 = "";
			if (StudentInfo.Eighties)
			{
				text2 = "1989";
			}
			if (ID < StudentManager.Students.Length)
			{
				if (!StudentInfo.Eighties && (StudentInfo.Eighties || ID >= 12) && (StudentInfo.Eighties || ID <= 20))
				{
					StudentInfo.Portrait.mainTexture = StudentInfoMenu.RivalPortraits[ID];
				}
				else
				{
					WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + text2 + "/Student_" + ID + ".png");
					if (!StudentGlobals.GetStudentReplaced(ID))
					{
						StudentInfo.Portrait.mainTexture = wWW.texture;
					}
					else
					{
						StudentInfo.Portrait.mainTexture = StudentInfo.BlankPortrait;
					}
					if (StudentInfo.Eighties && StudentInfo.CurrentStudent > 10 && StudentInfo.CurrentStudent < 21 && DateGlobals.Week < StudentInfo.CurrentStudent - 10)
					{
						StudentInfo.Portrait.mainTexture = StudentInfoMenu.EightiesUnknown;
					}
				}
			}
			else
			{
				switch (ID)
				{
				case 98:
					StudentInfo.Portrait.mainTexture = StudentInfoMenu.Counselor;
					break;
				case 99:
					StudentInfo.Portrait.mainTexture = StudentInfoMenu.Headmaster;
					break;
				case 100:
					StudentInfo.Portrait.mainTexture = StudentInfoMenu.InfoChan;
					if (!StudentInfo.Eighties)
					{
						StudentInfo.Static.SetActive(value: true);
						if (!StudentInfo.StudentInfoMenu.Gossiping && !StudentInfo.StudentInfoMenu.Distracting && !StudentInfo.StudentInfoMenu.CyberBullying && !StudentInfo.StudentInfoMenu.CyberStalking)
						{
							component.enabled = true;
							component.volume = 1f;
							component.Play();
						}
					}
					break;
				}
			}
			TJSvprCWcA(ID);
			H0yvaqV4NT();
			CensorUnknownRivalInfo();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0001FA50 File Offset: 0x0001DC50
		private void TJSvprCWcA(int int_0)
		{
			if (!StudentInfo.Eighties)
			{
				switch (int_0)
				{
				case 11:
					if (StudentInfo.Yandere != null)
					{
						StudentInfo.Strings[1] = (StudentInfo.Yandere.Police.EndOfDay.LearnedOsanaInfo1 ? "May be a victim of blackmail." : "?????");
						StudentInfo.Strings[2] = (StudentInfo.Yandere.Police.EndOfDay.LearnedOsanaInfo2 ? "Has a stalker." : "?????");
					}
					else
					{
						StudentInfo.Strings[1] = "?????";
						StudentInfo.Strings[2] = "?????";
					}
					StudentInfo.InfoLabel.text = StudentInfo.Strings[1] + "\n\n" + StudentInfo.Strings[2];
					break;
				case 51:
					if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
					{
						StudentInfo.InfoLabel.text = "Disbanded the Light Music Club, dyed her hair back to its original color, removed her piercings, and stopped socializing with others.";
					}
					else
					{
						StudentInfo.InfoLabel.text = NewJSON.Students[int_0].Info;
					}
					break;
				default:
					if (StudentGlobals.GetStudentReplaced(int_0))
					{
						StudentInfo.InfoLabel.text = "No additional information is available at this time.";
					}
					else if (NewJSON.Students[int_0].Info == string.Empty)
					{
						StudentInfo.InfoLabel.text = "No additional information is available at this time.";
					}
					else
					{
						StudentInfo.InfoLabel.text = NewJSON.Students[int_0].Info;
					}
					break;
				}
			}
			else if (StudentGlobals.GetStudentReplaced(int_0))
			{
				StudentInfo.InfoLabel.text = "No additional information is available at this time.";
			}
			else if (NewJSON.Students[int_0].Info == string.Empty)
			{
				StudentInfo.InfoLabel.text = "No additional information is available at this time.";
			}
			else
			{
				StudentInfo.InfoLabel.text = NewJSON.Students[int_0].Info;
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0001FC7C File Offset: 0x0001DE7C
		private void H0yvaqV4NT()
		{
			Vector3 zero = Vector3.zero;
			zero = ((StudentInfo.CurrentStudent != 100) ? StudentGlobals.GetReputationTriangle(StudentInfo.CurrentStudent) : ((!StudentInfo.Eighties) ? new Vector3(Random.Range(-100, 101), Random.Range(-100, 101), Random.Range(-100, 101)) : new Vector3(0f, 50f, 100f)));
			StudentInfo.ReputationChart.fields[0].Value = zero.x;
			StudentInfo.ReputationChart.fields[1].Value = zero.y;
			StudentInfo.ReputationChart.fields[2].Value = zero.z;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0001FD60 File Offset: 0x0001DF60
		private void Update()
		{
			if (Input.GetButtonDown("A") && StudentInfoMenu.Gossiping)
			{
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				StudentInfo.DialogueWheel.Victim = StudentInfo.CurrentStudent;
				StudentInfo.StudentInfoMenu.Gossiping = false;
				StudentInfo.gameObject.SetActive(value: false);
				Time.timeScale = 0.0001f;
				StudentInfo.DialogueWheel.TopicInterface.Socializing = false;
				StudentInfo.DialogueWheel.TopicInterface.StudentID = StudentInfo.Yandere.TargetStudent.StudentID;
				StudentInfo.DialogueWheel.TopicInterface.Student = StudentInfo.Yandere.TargetStudent;
				StudentInfo.DialogueWheel.TopicInterface.TargetStudentID = StudentInfo.CurrentStudent;
				StudentInfo.DialogueWheel.TopicInterface.TargetStudent = StudentInfo.StudentManager.Students[StudentInfo.CurrentStudent];
				NewTopicInterface.Start();
				NewTopicInterface.UpdateOpinions();
				NewTopicInterface.UpdateTopicHighlight();
				StudentInfo.DialogueWheel.TopicInterface.gameObject.SetActive(value: true);
				StudentInfo.PromptBar.ClearButtons();
				StudentInfo.PromptBar.Label[0].text = "Speak";
				StudentInfo.PromptBar.Label[1].text = "Back";
				StudentInfo.PromptBar.Label[2].text = "Positive/Negative";
				StudentInfo.PromptBar.UpdateButtons();
				StudentInfo.PromptBar.Show = true;
			}
			if (TextMessage != null && TextMessage.activeInHierarchy)
			{
				StudentInfo.gameObject.SetActive(value: false);
			}
			if (Input.GetButtonDown("LB"))
			{
				H0yvaqV4NT();
			}
			H0yvaqV4NT();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0001FFB8 File Offset: 0x0001E1B8
		public void MatchmadeCheck()
		{
			StudentInfo.Matchmade = false;
			if (StudentInfo.Eighties)
			{
				if ((StudentInfo.CurrentStudent > 10 && StudentInfo.CurrentStudent < 21 && GameGlobals.GetRivalEliminations(StudentInfo.CurrentStudent - 10) == 6) || (StudentInfo.CurrentStudent == 22 && GameGlobals.GetRivalEliminations(1) == 6) || (StudentInfo.CurrentStudent == 27 && GameGlobals.GetRivalEliminations(2) == 6) || (StudentInfo.CurrentStudent == 32 && GameGlobals.GetRivalEliminations(3) == 6) || (StudentInfo.CurrentStudent == 37 && GameGlobals.GetRivalEliminations(4) == 6) || (StudentInfo.CurrentStudent == 42 && GameGlobals.GetRivalEliminations(5) == 6) || (StudentInfo.CurrentStudent == 47 && GameGlobals.GetRivalEliminations(6) == 6) || (StudentInfo.CurrentStudent == 57 && GameGlobals.GetRivalEliminations(7) == 6) || (StudentInfo.CurrentStudent == 62 && GameGlobals.GetRivalEliminations(8) == 6) || (StudentInfo.CurrentStudent == 67 && GameGlobals.GetRivalEliminations(9) == 6) || (StudentInfo.CurrentStudent == 72 && GameGlobals.GetRivalEliminations(10) == 6))
				{
					StudentInfo.Matchmade = true;
					if (StudentInfo.CurrentStudent == 11)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[22].Name;
					}
					else if (StudentInfo.CurrentStudent == 12)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[27].Name;
					}
					else if (StudentInfo.CurrentStudent == 13)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[28].Name;
					}
					else if (StudentInfo.CurrentStudent == 14)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[32].Name;
					}
					else if (StudentInfo.CurrentStudent == 15)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[42].Name;
					}
					else if (StudentInfo.CurrentStudent == 16)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[47].Name;
					}
					else if (StudentInfo.CurrentStudent == 17)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[57].Name;
					}
					else if (StudentInfo.CurrentStudent == 18)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[62].Name;
					}
					else if (StudentInfo.CurrentStudent == 19)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[67].Name;
					}
					else if (StudentInfo.CurrentStudent == 20)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[72].Name;
					}
					else if (StudentInfo.CurrentStudent == 22)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[11].Name;
					}
					else if (StudentInfo.CurrentStudent == 27)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[12].Name;
					}
					else if (StudentInfo.CurrentStudent == 32)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[13].Name;
					}
					else if (StudentInfo.CurrentStudent == 37)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[14].Name;
					}
					else if (StudentInfo.CurrentStudent == 42)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[15].Name;
					}
					else if (StudentInfo.CurrentStudent == 47)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[16].Name;
					}
					else if (StudentInfo.CurrentStudent == 57)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[17].Name;
					}
					else if (StudentInfo.CurrentStudent == 62)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[18].Name;
					}
					else if (StudentInfo.CurrentStudent == 67)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[19].Name;
					}
					else if (StudentInfo.CurrentStudent == 72)
					{
						StudentInfo.PartnerName = StudentInfo.JSON.Students[20].Name;
					}
				}
			}
			else if ((StudentInfo.CurrentStudent > 10 && StudentInfo.CurrentStudent < 21 && GameGlobals.GetRivalEliminations(StudentInfo.CurrentStudent - 10) == 6) || (StudentInfo.CurrentStudent == 6 && GameGlobals.GetRivalEliminations(1) == 6))
			{
				StudentInfo.Matchmade = true;
				if (StudentInfo.CurrentStudent == 11)
				{
					StudentInfo.PartnerName = StudentInfo.JSON.Students[6].Name;
				}
				else if (StudentInfo.CurrentStudent == 6)
				{
					StudentInfo.PartnerName = StudentInfo.JSON.Students[11].Name;
				}
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000205E4 File Offset: 0x0001E7E4
		public void CensorUnknownRivalInfo()
		{
			if (StudentInfo.CurrentStudent > 10 && StudentInfo.CurrentStudent < 21 && DateGlobals.Week < StudentInfo.CurrentStudent - 10)
			{
				StudentInfo.NameLabel.text = "?????";
				StudentInfo.PersonaLabel.text = "?????";
				StudentInfo.CrushLabel.text = "?????";
				StudentInfo.ClubLabel.text = "?????";
				StudentInfo.StrengthLabel.text = "?????";
				StudentInfo.InfoLabel.text = "?????";
				StudentInfo.ReputationLabel.text = "";
				StudentInfo.ReputationBar.localPosition = new Vector3(0f, -10f, 0f);
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000206E4 File Offset: 0x0001E8E4
		private void UpdateTopics()
		{
			Debug.Log("UpdateTopics");
			int num = 0;
			int num2 = 0;
			for (int i = 1; i < StudentInfo.TopicIcons.Length; i++)
			{
				StudentInfo.TopicIcons[i].spriteName = (ConversationGlobals.GetTopicDiscovered(i) ? i : 0).ToString();
			}
			for (int j = 1; j <= 25; j++)
			{
				UISprite uISprite = StudentInfo.TopicOpinionIcons[j];
				if (!ConversationGlobals.GetTopicLearnedByStudent(j, CurrentStudent))
				{
					uISprite.spriteName = "Unknown";
					continue;
				}
				int[] topics = StudentInfo.JSON.Topics[CurrentStudent].Topics;
				uISprite.spriteName = StudentInfo.OpinionSpriteNames[topics[j]];
				if (topics[j] == 1)
				{
					num2++;
				}
				if (topics[j] == 2)
				{
					num++;
				}
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000207D0 File Offset: 0x0001E9D0
		// Note: this type is marked as 'beforefieldinit'.
		static ExtraStudentInfoScript()
		{
			UselessCall.Noop();
			PatvTfGLO4 = new IntAndStringDictionary
			{
				{ 0, "Incapable" },
				{ 1, "Very Weak" },
				{ 2, "Weak" },
				{ 3, "Strong" },
				{ 4, "Very Strong" },
				{ 5, "Peak Physical Strength" },
				{ 6, "Extensive Training" },
				{ 7, "Carries Pepper Spray" },
				{ 8, "Armed" },
				{ 9, "Invincible" },
				{ 99, "?????" }
			};
		}

		// Token: 0x040000B1 RID: 177
		public ExtraTopicInterfaceScript NewTopicInterface;

		// Token: 0x040000B2 RID: 178
		public ExtraJsonScript NewJSON;

		// Token: 0x040000B3 RID: 179
		public StudentInfoMenuScript StudentInfoMenu;

		// Token: 0x040000B4 RID: 180
		public PauseScreenScript PauseScreen;

		// Token: 0x040000B5 RID: 181
		public StudentInfoScript StudentInfo;

		// Token: 0x040000B6 RID: 182
		public StudentManagerScript StudentManager;

		// Token: 0x040000B7 RID: 183
		public DialogueWheelScript DialogueWheel;

		// Token: 0x040000B8 RID: 184
		public PromptBarScript PromptBar;

		// Token: 0x040000B9 RID: 185
		public YandereScript Yandere;

		// Token: 0x040000BA RID: 186
		public GameObject TextMessage;

		// Token: 0x040000BB RID: 187
		public bool GossipingWithExtra;

		// Token: 0x040000BC RID: 188
		public bool Updated;

		// Token: 0x040000BD RID: 189
		public int CurrentStudent;

		// Token: 0x040000BE RID: 190
		private static readonly IntAndStringDictionary PatvTfGLO4;
	}
}

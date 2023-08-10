using System;
using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x0200001E RID: 30
	internal class ExtraVoidGoddess : MonoBehaviour
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x00020F74 File Offset: 0x0001F174
		private void Start()
		{
			StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			VoidGoddess = StudentManager.Police.EndOfDay.VoidGoddess;
			VoidGoddess.enabled = false;
			for (int i = 1; i < VoidGoddess.Portraits.Length; i++)
			{
				VoidGoddess.Portraits[i].gameObject.SetActive(value: false);
			}
			Array.Resize(ref VoidGoddess.Portraits, 201);
			if (injected)
			{
				return;
			}
			string text = "";
			if (GameGlobals.Eighties)
			{
				text = "1989";
			}
			for (StudentCount = 1; StudentCount < 201; StudentCount++)
			{
				VoidGoddess.NewPortrait = UnityEngine.Object.Instantiate(VoidGoddess.Portrait, VoidGoddess.transform.position, Quaternion.identity);
				VoidGoddess.NewPortrait.transform.parent = VoidGoddess.Window;
				VoidGoddess.NewPortrait.transform.localScale = new Vector3(1f, 1f, 1f);
				VoidGoddess.NewPortrait.transform.localPosition = new Vector3(-450 + VoidGoddess.Column * 100, 450 - VoidGoddess.Row * 100, 0f);
				VoidGoddess.Portraits[StudentCount] = VoidGoddess.NewPortrait.GetComponent<UITexture>();
				if (!StudentManager.Eighties && StudentCount > 11 && StudentCount < 21)
				{
					VoidGoddess.NewPortrait.GetComponent<UITexture>().mainTexture = VoidGoddess.Prompt.Yandere.PauseScreen.StudentInfoMenu.RivalPortraits[StudentCount];
				}
				else if (StudentCount >= 98 && StudentCount <= 100)
				{
					if (StudentCount == 98)
					{
						VoidGoddess.NewPortrait.GetComponent<UITexture>().mainTexture = VoidGoddess.Counselor;
					}
					else if (StudentCount == 99)
					{
						VoidGoddess.NewPortrait.GetComponent<UITexture>().mainTexture = VoidGoddess.Headmaster;
					}
					else if (StudentCount == 100)
					{
						VoidGoddess.NewPortrait.GetComponent<UITexture>().mainTexture = VoidGoddess.Infochan;
					}
				}
				else
				{
					WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + text + "/Student_" + StudentCount + ".png");
					if (StudentCount > StudentManager.Students.Length - 1)
					{
						VoidGoddess.NewPortrait.GetComponent<UITexture>().mainTexture = VoidGoddess.StudentManager.Yandere.PauseScreen.StudentInfoMenu.BlankPortrait;
						VoidGoddess.Portraits[StudentCount].color = new Color(1f, 1f, 1f, 0.5f);
					}
					else
					{
						VoidGoddess.NewPortrait.GetComponent<UITexture>().mainTexture = wWW.texture;
					}
				}
				VoidGoddess.Column++;
				if (VoidGoddess.Column == 10)
				{
					VoidGoddess.Column = 0;
					VoidGoddess.Row++;
				}
				if (VoidGoddess.Row == 10)
				{
					VoidGoddess.Row = 0;
				}
			}
			UpdatePortraits();
			injected = true;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00021388 File Offset: 0x0001F588
		public void Update()
		{
			if (VoidGoddess.Prompt.Circle[0].fillAmount == 0f)
			{
				VoidGoddess.Prompt.Circle[0].fillAmount = 1f;
				if (!VoidGoddess.Goddess.activeInHierarchy)
				{
					VoidGoddess.Prompt.Yandere.Police.Invalid = true;
					VoidGoddess.Prompt.Label[0].text = "     Pass Judgement";
					VoidGoddess.Prompt.Label[1].text = "     Dismiss";
					VoidGoddess.Prompt.Label[2].text = "     Follow";
					VoidGoddess.Prompt.HideButton[1] = false;
					VoidGoddess.Prompt.HideButton[2] = false;
					VoidGoddess.Prompt.OffsetX[0] = 0f;
					VoidGoddess.Goddess.SetActive(value: true);
				}
				else
				{
					VoidGoddess.Window.parent.gameObject.SetActive(value: true);
					VoidGoddess.Prompt.Yandere.CanMove = false;
					VoidGoddess.PassingJudgement = true;
					RearrangeWindow();
					UpdatePortraits();
				}
			}
			if (VoidGoddess.Prompt.Circle[1].fillAmount == 0f)
			{
				VoidGoddess.Prompt.Circle[1].fillAmount = 1f;
				VoidGoddess.Prompt.Label[0].text = "     Summon An Ancient Evil";
				VoidGoddess.Prompt.Label[1].text = "";
				VoidGoddess.Prompt.Label[2].text = "";
				VoidGoddess.Prompt.HideButton[1] = true;
				VoidGoddess.Prompt.HideButton[2] = true;
				VoidGoddess.Prompt.OffsetX[0] = 0f;
				base.transform.position = new Vector3(-9.5f, 1f, -75f);
				VoidGoddess.Goddess.SetActive(value: false);
				VoidGoddess.Follow = false;
			}
			if (VoidGoddess.Prompt.Circle[2].fillAmount == 0f)
			{
				VoidGoddess.Prompt.Circle[2].fillAmount = 1f;
				VoidGoddess.Follow = !VoidGoddess.Follow;
			}
			if (VoidGoddess.Follow && Vector3.Distance(VoidGoddess.Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0f), base.transform.position) > 1f)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, VoidGoddess.Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0f), Time.deltaTime);
			}
			if (currentPage > 1)
			{
				currentPage = 0;
				InjectText();
			}
			if (currentPage < 0)
			{
				currentPage = 1;
				InjectText();
			}
			if (!VoidGoddess.PassingJudgement)
			{
				return;
			}
			if (VoidGoddess.InputManager.TappedUp)
			{
				VoidGoddess.Row--;
				UpdateHighlight();
			}
			else if (VoidGoddess.InputManager.TappedDown)
			{
				VoidGoddess.Row++;
				UpdateHighlight();
			}
			if (VoidGoddess.InputManager.TappedLeft)
			{
				VoidGoddess.Column--;
				UpdateHighlight();
			}
			else if (VoidGoddess.InputManager.TappedRight)
			{
				VoidGoddess.Column++;
				UpdateHighlight();
			}
			if (Input.GetKeyDown(KeyCode.L))
			{
				currentPage++;
				VoidGoddess.Row = 0;
				VoidGoddess.Column = 0;
				UpdateHighlight();
			}
			if (Input.GetKeyDown(KeyCode.K))
			{
				currentPage--;
				VoidGoddess.Row = 0;
				VoidGoddess.Column = 0;
				UpdateHighlight();
			}
			ShowStudentPage(currentPage);
			if (Input.GetButtonDown("A") && !NoStudentSelected)
			{
				VoidGoddess.StudentManager.DisableStudent(VoidGoddess.Selected);
				UpdatePortraits();
			}
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				if (!VoidGoddess.Disabled)
				{
					VoidGoddess.StudentManager.DisableEveryone();
					VoidGoddess.Disabled = true;
				}
				else
				{
					for (StudentCount = 1; StudentCount < 102; StudentCount++)
					{
						VoidGoddess.StudentManager.DisableStudent(StudentCount);
					}
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				for (StudentCount = 1; StudentCount < 11; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				for (StudentCount = 11; StudentCount < 21; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				for (StudentCount = 21; StudentCount < 26; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				for (StudentCount = 26; StudentCount < 31; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				for (StudentCount = 31; StudentCount < 36; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				for (StudentCount = 36; StudentCount < 41; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				for (StudentCount = 41; StudentCount < 46; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				for (StudentCount = 46; StudentCount < 51; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha0))
			{
				for (StudentCount = 51; StudentCount < 56; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown("-"))
			{
				for (StudentCount = 56; StudentCount < 61; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown("="))
			{
				for (StudentCount = 61; StudentCount < 66; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown("r"))
			{
				for (StudentCount = 66; StudentCount < 71; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown("t"))
			{
				for (StudentCount = 71; StudentCount < 76; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown("y"))
			{
				for (StudentCount = 76; StudentCount < 81; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown("u"))
			{
				for (StudentCount = 81; StudentCount < 86; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown("i"))
			{
				for (StudentCount = 86; StudentCount < 90; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown("o"))
			{
				for (StudentCount = 90; StudentCount < 98; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown("p"))
			{
				for (StudentCount = 1; StudentCount < 101; StudentCount++)
				{
					if (StudentCount != 21 && StudentCount != 26 && StudentCount != 31 && StudentCount != 36 && StudentCount != 41 && StudentCount != 46 && StudentCount != 51 && StudentCount != 56 && StudentCount != 61 && StudentCount != 66 && StudentCount != 71)
					{
						VoidGoddess.StudentManager.DisableStudent(StudentCount);
					}
				}
				UpdatePortraits();
			}
			else if (Input.GetKeyDown("space"))
			{
				for (StudentCount = 2; StudentCount < 101; StudentCount++)
				{
					if (StudentCount != 1 && StudentCount != 2 && StudentCount != 3 && StudentCount != 6 && StudentCount != 10 && StudentCount != 11 && StudentCount != 26 && StudentCount != 36 && StudentCount != 39 && StudentCount != 41 && StudentCount != 42 && StudentCount != 43 && StudentCount != 44 && StudentCount != 45 && StudentCount != 46 && StudentCount != 47 && StudentCount != 48 && StudentCount != 49 && StudentCount != 50 && StudentCount != 71 && StudentCount != 81 && StudentCount != 82 && StudentCount != 83 && StudentCount != 84 && StudentCount != 85)
					{
						VoidGoddess.StudentManager.DisableStudent(StudentCount);
					}
				}
				if (VoidGoddess.StudentManager.Students[7].gameObject.activeInHierarchy)
				{
					VoidGoddess.StudentManager.DisableStudent(7);
				}
				UpdatePortraits();
			}
			if (Input.GetButtonDown("B"))
			{
				VoidGoddess.Window.parent.gameObject.SetActive(value: false);
				VoidGoddess.Prompt.Yandere.CanMove = true;
				VoidGoddess.Prompt.Yandere.Shoved = false;
				VoidGoddess.PassingJudgement = false;
			}
			if (Input.GetKeyDown(KeyCode.Z) && !NoStudentSelected)
			{
				VoidGoddess.StudentManager.Students[VoidGoddess.Selected].transform.position = VoidGoddess.Prompt.Yandere.transform.position + VoidGoddess.Prompt.Yandere.transform.forward;
				Physics.SyncTransforms();
			}
			if (Input.GetKeyDown(KeyCode.X) && !NoStudentSelected)
			{
				VoidGoddess.StudentManager.Students[VoidGoddess.Selected].BecomeRagdoll();
				VoidGoddess.StudentManager.Students[VoidGoddess.Selected].Ragdoll.NeckSnapped = true;
			}
			if (Input.GetKeyDown(KeyCode.G))
			{
				for (StudentCount = 101; StudentCount < StudentManager.Students.Length; StudentCount++)
				{
					VoidGoddess.StudentManager.DisableStudent(StudentCount);
				}
				UpdatePortraits();
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00022210 File Offset: 0x00020410
		private void UpdateHighlight()
		{
			if (VoidGoddess.Row < 0)
			{
				VoidGoddess.Row = 9;
			}
			else if (VoidGoddess.Row > 9)
			{
				VoidGoddess.Row = 0;
			}
			if (VoidGoddess.Column < 0)
			{
				VoidGoddess.Column = 9;
			}
			else if (VoidGoddess.Column > 9)
			{
				VoidGoddess.Column = 0;
			}
			VoidGoddess.Highlight.localPosition = new Vector3(-450 + 100 * VoidGoddess.Column, 450 - 100 * VoidGoddess.Row, VoidGoddess.Highlight.localPosition.z);
			InjectText();
			switch (currentPage)
			{
			case 1:
				VoidGoddess.Selected = 1 + VoidGoddess.Row * 10 + VoidGoddess.Column + 100;
				break;
			case 0:
				VoidGoddess.Selected = 1 + VoidGoddess.Row * 10 + VoidGoddess.Column;
				break;
			}
			if (VoidGoddess.Selected > StudentManager.Students.Length - 1)
			{
				NoStudentSelected = true;
			}
			else
			{
				NoStudentSelected = false;
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00022378 File Offset: 0x00020578
		public void UpdatePortraits()
		{
			for (StudentCount = 1; StudentCount < StudentManager.Students.Length; StudentCount++)
			{
				if (VoidGoddess.Portraits[StudentCount] != null)
				{
					if (VoidGoddess.StudentManager.Students[StudentCount] != null)
					{
						if (VoidGoddess.StudentManager.Students[StudentCount].gameObject.activeInHierarchy)
						{
							VoidGoddess.Portraits[StudentCount].color = new Color(1f, 1f, 1f, 1f);
						}
						else
						{
							VoidGoddess.Portraits[StudentCount].color = new Color(1f, 1f, 1f, 0.5f);
						}
					}
					else
					{
						VoidGoddess.Portraits[StudentCount].color = new Color(1f, 1f, 1f, 0.5f);
					}
				}
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000224B0 File Offset: 0x000206B0
		private void InjectText()
		{
			DisplayPage = currentPage + 1;
			cKTvwpWWtc = "Current Page: " + DisplayPage + "/2";
			ifBvWiApod = "WASD or Arrow Keys:\nSelect\n\nE Key:\nToggle\n\nZ Key:\nTeleport Student\nTo Your Location\n\nX Key:\nGive Counselor Amnesia\n\n- EXTRA STUDENTS PROJECT -\n\nKL Keys:\nChange Students Page\n\n" + cKTvwpWWtc;
			r96vde7DmF = "1 : Toggle All\n2 : Toggle Clubless\n3 : Toggle Rivals\n4 : Toggle Cooking\n5 : Toggle Drama\n6 : Toggle Occult\n7 : Toggle Gaming\n8 : Toggle Art\n9 : Toggle Martial Arts\n0 : Toggle Music\n- : Toggle Photography\n- : Toggle Science\nR : Toggle Sports\nT : Toggle Gardening\nY : Toggle Delinquents\nU : Toggle Bullies\nI : Toggle Student Council\nO : Toggle Faculty\nP : Toggle Non-Leaders\nQ : Exit\nG : Toggle Extra Students";
			HhkvuY6qF2.text = ifBvWiApod;
			J5NvyXmJVT.text = r96vde7DmF;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00022530 File Offset: 0x00020730
		private void RearrangeWindow()
		{
			HhkvuY6qF2 = VoidGoddess.Window.transform.Find("ControlsText").GetComponent<UILabel>();
			J5NvyXmJVT = VoidGoddess.Window.transform.Find("ToggleText").GetComponent<UILabel>();
			J5NvyXmJVT.transform.localPosition = new Vector3(J5NvyXmJVT.transform.localPosition.x, 0.5f, J5NvyXmJVT.transform.localPosition.z);
			J5NvyXmJVT.depth = 5;
			dnyvP9I5Xb = VoidGoddess.Window.transform.Find("RightBG").GetComponent<UISprite>();
			dnyvP9I5Xb.depth = 2;
			dnyvP9I5Xb.height = 1000;
			w0IvAq87ge = VoidGoddess.Window.transform.Find("LeftBG").GetComponent<UISprite>();
			w0IvAq87ge.transform.localPosition = new Vector3(w0IvAq87ge.transform.localPosition.x, 10f, w0IvAq87ge.transform.localPosition.z);
			w0IvAq87ge.depth = 4;
			w0IvAq87ge.height = 1110;
			InjectText();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000026CD File Offset: 0x000008CD
		private void ShowStudentPage(int int_0)
		{
			switch (int_0)
			{
			case 1:
				ShowModdedStudents();
				break;
			case 0:
				ShowVanillaStudents();
				break;
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000226A4 File Offset: 0x000208A4
		private void ShowVanillaStudents()
		{
			for (int i = 1; i < VoidGoddess.Portraits.Length; i++)
			{
				VoidGoddess.Portraits[i].gameObject.SetActive(value: true);
			}
			for (int j = 101; j < VoidGoddess.Portraits.Length; j++)
			{
				VoidGoddess.Portraits[j].gameObject.SetActive(value: false);
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00022714 File Offset: 0x00020914
		private void ShowModdedStudents()
		{
			for (int i = 1; i < VoidGoddess.Portraits.Length; i++)
			{
				VoidGoddess.Portraits[i].gameObject.SetActive(value: false);
			}
			for (int j = 101; j < VoidGoddess.Portraits.Length; j++)
			{
				VoidGoddess.Portraits[j].gameObject.SetActive(value: true);
			}
		}

		// Token: 0x040000C7 RID: 199
		public StudentManagerScript StudentManager;

		// Token: 0x040000C8 RID: 200
		public VoidGoddessScript VoidGoddess;

		// Token: 0x040000C9 RID: 201
		private UISprite dnyvP9I5Xb;

		// Token: 0x040000CA RID: 202
		private UISprite w0IvAq87ge;

		// Token: 0x040000CB RID: 203
		private UILabel HhkvuY6qF2;

		// Token: 0x040000CC RID: 204
		private UILabel J5NvyXmJVT;

		// Token: 0x040000CD RID: 205
		private string ifBvWiApod;

		// Token: 0x040000CE RID: 206
		private string r96vde7DmF;

		// Token: 0x040000CF RID: 207
		private string cKTvwpWWtc;

		// Token: 0x040000D0 RID: 208
		private bool injected;

		// Token: 0x040000D1 RID: 209
		private bool NoStudentSelected;

		// Token: 0x040000D2 RID: 210
		private int StudentCount;

		// Token: 0x040000D3 RID: 211
		private int currentPage;

		// Token: 0x040000D4 RID: 212
		private int DisplayPage;
	}
}

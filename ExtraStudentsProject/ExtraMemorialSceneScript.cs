using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x02000013 RID: 19
	internal class ExtraMemorialSceneScript : MonoBehaviour
	{
		// Token: 0x06000062 RID: 98 RVA: 0x0000C6BC File Offset: 0x0000A8BC
		private void Start()
		{
			StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			ExtraStudentManager = StudentManager.GetComponent<ExtraStudentManagerScript>();
			ExtraJson = GameObject.Find("JSON").GetComponent<ExtraJsonScript>();
			baseMemorialScene = StudentManager.MemorialScene;
			baseMemorialScene.enabled = false;
			baseMemorialScene.BloomIntensity = 1f;
			baseMemorialScene.BloomRadius = 4f;
			baseMemorialScene.Speed = 0f;
			baseMemorialScene.StudentManager.Yandere.HeartCamera.enabled = false;
			baseMemorialScene.StudentManager.Yandere.RPGCamera.enabled = false;
			baseMemorialScene.StudentManager.Yandere.CanMove = false;
			baseMemorialScene.StudentManager.Yandere.HUD.alpha = 0f;
			if (PlayerPrefs.GetInt("LoadingSave") == 1)
			{
				int profile = GameGlobals.Profile;
				int @int = PlayerPrefs.GetInt("SaveSlot");
				StudentGlobals.MemorialStudents = PlayerPrefs.GetInt("Profile_" + profile + "_Slot_" + @int + "_MemorialStudents");
			}
			baseMemorialScene.MemorialStudents = StudentGlobals.MemorialStudents;
			if (baseMemorialScene.MemorialStudents % 2 == 0)
			{
				baseMemorialScene.CanvasGroup.transform.localPosition = new Vector3(-0.5f, 0f, -2f);
			}
			int int_ = 0;
			int i;
			for (i = 1; i < 10; i++)
			{
				baseMemorialScene.Canvases[i].SetActive(value: false);
			}
			string text = "";
			if (GameGlobals.Eighties)
			{
				baseMemorialScene.StudentManager.IdolStage.SetActive(value: false);
				text = "1989";
				TurnYoung();
			}
			i = 0;
			while (baseMemorialScene.MemorialStudents > 0)
			{
				i++;
				baseMemorialScene.Canvases[i].SetActive(value: true);
				if (baseMemorialScene.MemorialStudents == 1)
				{
					int_ = StudentGlobals.MemorialStudent1;
				}
				else if (baseMemorialScene.MemorialStudents == 2)
				{
					int_ = StudentGlobals.MemorialStudent2;
				}
				else if (baseMemorialScene.MemorialStudents == 3)
				{
					int_ = StudentGlobals.MemorialStudent3;
				}
				else if (baseMemorialScene.MemorialStudents == 4)
				{
					int_ = StudentGlobals.MemorialStudent4;
				}
				else if (baseMemorialScene.MemorialStudents == 5)
				{
					int_ = StudentGlobals.MemorialStudent5;
				}
				else if (baseMemorialScene.MemorialStudents == 6)
				{
					int_ = StudentGlobals.MemorialStudent6;
				}
				else if (baseMemorialScene.MemorialStudents == 7)
				{
					int_ = StudentGlobals.MemorialStudent7;
				}
				else if (baseMemorialScene.MemorialStudents == 8)
				{
					int_ = StudentGlobals.MemorialStudent8;
				}
				else if (baseMemorialScene.MemorialStudents == 9)
				{
					int_ = StudentGlobals.MemorialStudent9;
				}
				WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + text + "/Student_" + int_ + ".png");
				baseMemorialScene.Portraits[i].mainTexture = wWW.texture;
				GameObject gameObject_ = Object.Instantiate(baseMemorialScene.FlowerVase, baseMemorialScene.transform.position, Quaternion.identity);
				MemorializeStudent(int_, gameObject_);
				baseMemorialScene.MemorialStudents--;
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000CA58 File Offset: 0x0000AC58
		private void Update()
		{
			baseMemorialScene.StudentManager.Yandere.CanMove = false;
			baseMemorialScene.StudentManager.Yandere.HeartCamera.enabled = false;
			baseMemorialScene.StudentManager.Yandere.RPGCamera.enabled = false;
			baseMemorialScene.Speed += Time.deltaTime;
			if (baseMemorialScene.Speed > 1f)
			{
				if (!baseMemorialScene.Eulogized)
				{
					if (!StudentManager.Eighties)
					{
						StudentManager.Yandere.Subtitle.UpdateLabel(SubtitleType.Eulogy, 0, 8f);
					}
					else
					{
						StudentManager.Yandere.Subtitle.UpdateLabel(SubtitleType.Eulogy, 1, 8f);
					}
					StudentManager.Yandere.PromptBar.Label[0].text = "Continue";
					StudentManager.Yandere.PromptBar.UpdateButtons();
					StudentManager.Yandere.PromptBar.Show = true;
					baseMemorialScene.Eulogized = true;
				}
				StudentManager.MainCamera.position = Vector3.Lerp(StudentManager.MainCamera.position, new Vector3(38f, 4.125f, 68.825f), (baseMemorialScene.Speed - 1f) * Time.deltaTime * 0.15f);
				if (Input.GetButtonDown("A"))
				{
					baseMemorialScene.StudentManager.Yandere.PromptBar.Show = false;
					baseMemorialScene.FadeOut = true;
				}
			}
			if (!baseMemorialScene.FadeOut)
			{
				return;
			}
			baseMemorialScene.BloomIntensity = Mathf.MoveTowards(baseMemorialScene.BloomIntensity, 500f, Time.deltaTime * 500f);
			baseMemorialScene.BloomRadius = Mathf.MoveTowards(baseMemorialScene.BloomRadius, 7f, Time.deltaTime * 7f);
			baseMemorialScene.CameraEffects.UpdateBloom(baseMemorialScene.BloomIntensity);
			baseMemorialScene.CameraEffects.UpdateBloomRadius(baseMemorialScene.BloomRadius);
			if (baseMemorialScene.BloomIntensity == 500f)
			{
				if (baseMemorialScene.StudentManager.Eighties && DateGlobals.Week == 6)
				{
					baseMemorialScene.StudentManager.IdolStage.SetActive(value: true);
					base.gameObject.SetActive(value: false);
				}
				baseMemorialScene.StudentManager.Yandere.Casual = !baseMemorialScene.StudentManager.Yandere.Casual;
				baseMemorialScene.StudentManager.Yandere.ChangeSchoolwear();
				baseMemorialScene.StudentManager.Yandere.transform.position = new Vector3(12f, 0f, 72f);
				baseMemorialScene.StudentManager.Yandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
				baseMemorialScene.StudentManager.Yandere.HeartCamera.enabled = true;
				baseMemorialScene.StudentManager.Yandere.RPGCamera.enabled = true;
				baseMemorialScene.StudentManager.Yandere.CanMove = true;
				baseMemorialScene.StudentManager.Yandere.HUD.alpha = 1f;
				baseMemorialScene.StudentManager.Clock.BloomIntensity = baseMemorialScene.BloomIntensity;
				baseMemorialScene.StudentManager.Clock.BloomRadius = baseMemorialScene.BloomRadius;
				baseMemorialScene.StudentManager.Clock.UpdateBloom = true;
				baseMemorialScene.StudentManager.Clock.ReduceKnee = false;
				baseMemorialScene.StudentManager.Clock.Lerp = true;
				baseMemorialScene.StudentManager.Clock.StopTime = false;
				baseMemorialScene.StudentManager.Clock.PresentTime = 450f;
				baseMemorialScene.StudentManager.Clock.HourTime = 7.5f;
				baseMemorialScene.StudentManager.Unstop();
				ExtraStudentManager.AwoZaEUto9();
				baseMemorialScene.Headmaster.SetActive(value: false);
				baseMemorialScene.Counselor.SetActive(value: false);
				baseMemorialScene.StudentManager.UpdateAllSleuthClothing();
				baseMemorialScene.StudentManager.Clock.GivePlayerBroughtWeapon();
				base.enabled = false;
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000CF44 File Offset: 0x0000B144
		private void MemorializeStudent(int int_0, GameObject gameObject_0)
		{
			if (int_0 < 101)
			{
				StudentJson studentJson = baseMemorialScene.StudentManager.JSON.Students[int_0];
				Transform transform = baseMemorialScene.StudentManager.Seats[studentJson.Class].List[studentJson.Seat];
				if (transform.position.x > 0f)
				{
					gameObject_0.transform.position = transform.position + new Vector3(0.33333f, 0.7711f, 0f);
					return;
				}
				gameObject_0.transform.position = transform.position + new Vector3(-0.33333f, 0.7711f, 0f);
				gameObject_0.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			}
			else
			{
				ExtraStudentJson extraStudentJson = ExtraJson.Students[int_0];
				Transform transform2 = baseMemorialScene.StudentManager.Seats[extraStudentJson.Class].List[extraStudentJson.Seat];
				if (transform2.position.x > 0f)
				{
					gameObject_0.transform.position = transform2.position + new Vector3(0.33333f, 0.7711f, 0f);
					return;
				}
				gameObject_0.transform.position = transform2.position + new Vector3(-0.33333f, 0.7711f, 0f);
				gameObject_0.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000D0D4 File Offset: 0x0000B2D4
		private void TurnYoung()
		{
			baseMemorialScene.YoungHeadmaster.SetActive(value: true);
			baseMemorialScene.CounselorEighties.SetActive(value: true);
			for (int i = 1; i < 6; i++)
			{
				baseMemorialScene.HeadmasterMesh[i].SetActive(value: false);
			}
			for (int j = 1; j < 7; j++)
			{
				baseMemorialScene.CounselorMesh[j].SetActive(value: false);
			}
			baseMemorialScene.CounselorMesh[7].SetActive(value: true);
		}

		// Token: 0x04000077 RID: 119
		private ExtraStudentManagerScript ExtraStudentManager;

		// Token: 0x04000078 RID: 120
		private ExtraJsonScript ExtraJson;

		// Token: 0x04000079 RID: 121
		private StudentManagerScript StudentManager;

		// Token: 0x0400007A RID: 122
		private MemorialSceneScript baseMemorialScene;
	}
}

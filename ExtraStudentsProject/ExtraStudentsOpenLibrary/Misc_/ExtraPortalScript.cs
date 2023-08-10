using UnityEngine;

namespace ExtraStudentsProject.ExtraStudentsOpenLibrary.Misc_
{
	// Token: 0x02000023 RID: 35
	public class ExtraPortalScript : MonoBehaviour
	{
		// Token: 0x060000DE RID: 222 RVA: 0x00002774 File Offset: 0x00000974
		private void Start()
		{
			basePortalScript = GameObject.Find("Portal").GetComponent<PortalScript>();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0002315C File Offset: 0x0002135C
		private void Update()
		{
			if (basePortalScript.Transition)
			{
				basePortalScript.Transition = false;
				Transition = true;
			}
			if (!Transition)
			{
				return;
			}
			if (basePortalScript.FadeOut)
			{
				basePortalScript.Yandere.transform.position = Vector3.Lerp(basePortalScript.Yandere.transform.position, new Vector3(-11.62f, 4f, -25.36f), Time.deltaTime * 10f);
				if (basePortalScript.LoveManager.HoldingHands)
				{
					basePortalScript.LoveManager.Rival.transform.position = new Vector3(0f, 0f, -50f);
				}
				basePortalScript.ClassDarkness.alpha = Mathf.MoveTowards(basePortalScript.ClassDarkness.alpha, 1f, Time.deltaTime);
				if (!(basePortalScript.ClassDarkness.alpha >= 0.95f))
				{
					return;
				}
				if (basePortalScript.Yandere.Resting)
				{
					basePortalScript.StudentManager.Mirror.UpdatePersona();
					basePortalScript.Yandere.OriginalIdleAnim = basePortalScript.Yandere.IdleAnim;
					basePortalScript.Yandere.OriginalWalkAnim = basePortalScript.Yandere.WalkAnim;
					basePortalScript.Yandere.CharacterAnimation.CrossFade(basePortalScript.Yandere.IdleAnim);
					basePortalScript.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
					basePortalScript.Yandere.Resting = false;
					basePortalScript.Yandere.Health = 10;
					basePortalScript.FadeOut = false;
					basePortalScript.Proceed = true;
					basePortalScript.ClassDarkness.alpha = 1f;
					basePortalScript.Yandere.CameraEffects.UpdateDOF(basePortalScript.OriginalDOF);
					return;
				}
				if (basePortalScript.Yandere.Armed)
				{
					basePortalScript.Yandere.Unequip();
				}
				basePortalScript.HeartbeatCamera.SetActive(value: false);
				basePortalScript.FadeOut = false;
				basePortalScript.Proceed = false;
				basePortalScript.Yandere.RPGCamera.enabled = false;
				basePortalScript.Yandere.MainCamera.transform.position = new Vector3(-12.25f, 5f, -25.85f);
				basePortalScript.Yandere.MainCamera.transform.eulerAngles = new Vector3(0f, 45f, 0f);
				UnityEngine.PostProcessing.DepthOfFieldModel.Settings settings = basePortalScript.Yandere.CameraEffects.Profile.depthOfField.settings;
				basePortalScript.OriginalDOF = settings.focusDistance;
				basePortalScript.Yandere.CameraEffects.UpdateDOF(0.6f);
				basePortalScript.Clock.gameObject.SetActive(value: false);
				basePortalScript.StudentManager.Reputation.gameObject.SetActive(value: false);
				basePortalScript.Yandere.SanityLabel.transform.parent.gameObject.SetActive(value: false);
				basePortalScript.PromptBar.ClearButtons();
				basePortalScript.PromptBar.Label[4].text = "Choose";
				basePortalScript.PromptBar.Label[5].text = "Allocate";
				basePortalScript.PromptBar.UpdateButtons();
				basePortalScript.PromptBar.Show = true;
				basePortalScript.Class.StudyPoints += ((PlayerGlobals.PantiesEquipped == 7) ? 10 : 5);
				basePortalScript.Class.StudyPoints += basePortalScript.Class.BonusPoints;
				basePortalScript.Class.BonusPoints = 0;
				basePortalScript.Class.StudyPoints -= basePortalScript.Late;
				basePortalScript.Class.UpdateLabel();
				basePortalScript.Class.gameObject.SetActive(value: true);
				basePortalScript.Class.Show = true;
				if (basePortalScript.Police.Show)
				{
					basePortalScript.Police.Timer = 1E-06f;
				}
			}
			else if (basePortalScript.Proceed)
			{
				if (basePortalScript.ReturningFromLecture)
				{
					basePortalScript.ClassDarkness.alpha = 1f;
					basePortalScript.ReturningFromLecture = false;
					basePortalScript.Yandere.CameraEffects.UpdateDOF(basePortalScript.OriginalDOF);
				}
				if (basePortalScript.ClassDarkness.color.a > 0.95f)
				{
					basePortalScript.HeartbeatCamera.SetActive(value: true);
					basePortalScript.Clock.enabled = true;
					basePortalScript.Yandere.FixCamera();
					basePortalScript.Yandere.RPGCamera.enabled = false;
				}
				basePortalScript.ClassDarkness.alpha = Mathf.MoveTowards(basePortalScript.ClassDarkness.alpha, 0f, Time.deltaTime);
				if (basePortalScript.ClassDarkness.color.a != 0f)
				{
					return;
				}
				basePortalScript.ClassDarkness.enabled = false;
				basePortalScript.Clock.StopTime = false;
				basePortalScript.Transition = false;
				Transition = false;
				basePortalScript.Proceed = false;
				basePortalScript.Yandere.RPGCamera.enabled = true;
				basePortalScript.Yandere.InClass = false;
				basePortalScript.Yandere.CanMove = true;
				basePortalScript.Yandere.LifeNotePen.SetActive(value: false);
				basePortalScript.Yandere.LifeNotePen.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
				basePortalScript.Paper.SetActive(value: false);
				basePortalScript.Clock.gameObject.SetActive(value: true);
				basePortalScript.StudentManager.Reputation.gameObject.SetActive(value: true);
				basePortalScript.Yandere.SanityLabel.transform.parent.gameObject.SetActive(value: true);
				basePortalScript.StudentManager.ResumeMovement();
				if (basePortalScript.Clock.HourTime > 15f)
				{
					basePortalScript.StudentManager.TakeOutTheTrash();
				}
				if (!MissionModeGlobals.MissionMode)
				{
					if (basePortalScript.Headmaster.activeInHierarchy)
					{
						basePortalScript.Headmaster.SetActive(value: false);
					}
					else
					{
						basePortalScript.Headmaster.SetActive(value: true);
					}
				}
			}
			else
			{
				basePortalScript.Yandere.CharacterAnimation.CrossFade("f02_takingNotes_00");
				basePortalScript.ClassDarkness.alpha = Mathf.MoveTowards(basePortalScript.ClassDarkness.alpha, 0f, Time.deltaTime);
			}
		}

		// Token: 0x0400010C RID: 268
		[SerializeField]
		private PortalScript basePortalScript;

		// Token: 0x0400010D RID: 269
		private bool Transition;
	}
}

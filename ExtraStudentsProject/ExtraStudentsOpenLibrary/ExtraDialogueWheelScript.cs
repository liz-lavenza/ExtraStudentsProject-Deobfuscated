using UnityEngine;

namespace ExtraStudentsProject.ExtraStudentsOpenLibrary
{
	// Token: 0x02000010 RID: 16
	public class ExtraDialogueWheelScript : MonoBehaviour
	{
		// Token: 0x06000051 RID: 81 RVA: 0x00004A04 File Offset: 0x00002C04
		private void Start()
		{
			DialogueWheel = GetComponent<DialogueWheelScript>();
			DialogueWheel.TopicInterface.gameObject.AddComponent<ExtraTopicInterfaceScript>();
			NewInterface = DialogueWheel.TopicInterface.gameObject.GetComponent<ExtraTopicInterfaceScript>();
			Yandere = DialogueWheel.Yandere;
			Yandere.PauseScreen.StudentInfo.gameObject.AddComponent<ExtraStudentInfoScript>();
			NewStudentInfo = Yandere.PauseScreen.StudentInfo.GetComponent<ExtraStudentInfoScript>();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004A98 File Offset: 0x00002C98
		private void Update()
		{
			if (DialogueWheel.Show && Input.GetButtonDown("A") && !DialogueWheel.ClubLeader && DialogueWheel.Selected != 0 && DialogueWheel.Shadow[DialogueWheel.Selected].color.a == 0f && DialogueWheel.Selected == 2)
			{
				Time.timeScale = 0.0001f;
				DialogueWheel.TopicInterface.gameObject.SetActive(value: true);
				DialogueWheel.PromptBar.ClearButtons();
				DialogueWheel.PromptBar.Label[0].text = "Speak";
				DialogueWheel.PromptBar.Label[1].text = "Back";
				DialogueWheel.PromptBar.Label[2].text = "Positive/Negative";
				DialogueWheel.PromptBar.UpdateButtons();
				DialogueWheel.PromptBar.Show = true;
				DialogueWheel.Impatience.fillAmount = 0f;
				DialogueWheel.Show = false;
				DialogueWheel.TopicInterface.StudentID = DialogueWheel.Yandere.TargetStudent.StudentID;
				DialogueWheel.TopicInterface.Student = DialogueWheel.Yandere.TargetStudent;
				base.transform.localScale = Vector3.zero;
				if (DialogueWheel.Yandere.TargetStudent.StudentID < 101)
				{
					DialogueWheel.TopicInterface.UpdateOpinions();
					DialogueWheel.TopicInterface.UpdateTopicHighlight();
				}
				else
				{
					NewInterface.UpdateOpinions();
					NewInterface.UpdateTopicHighlight();
					Debug.Log("Checking for new extras students!");
				}
			}
		}

		// Token: 0x0400006D RID: 109
		public YandereScript Yandere;

		// Token: 0x0400006E RID: 110
		public DialogueWheelScript DialogueWheel;

		// Token: 0x0400006F RID: 111
		public ExtraTopicInterfaceScript NewInterface;

		// Token: 0x04000070 RID: 112
		public ExtraStudentInfoScript NewStudentInfo;
	}
}

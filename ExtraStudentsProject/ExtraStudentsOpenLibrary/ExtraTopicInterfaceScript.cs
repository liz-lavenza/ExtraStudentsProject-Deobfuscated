using UnityEngine;

namespace ExtraStudentsProject.ExtraStudentsOpenLibrary
{
	// Token: 0x0200001D RID: 29
	public class ExtraTopicInterfaceScript : MonoBehaviour
	{
		// Token: 0x060000BE RID: 190 RVA: 0x00020874 File Offset: 0x0001EA74
		public void Start()
		{
			StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			InputManager = GameObject.Find("MainCamera").GetComponent<InputManagerScript>();
			Yandere = StudentManager.Yandere;
			TopicInterface = GetComponent<TopicInterfaceScript>();
			NewJSON = GameObject.Find("JSON").GetComponent<ExtraJsonScript>();
			JSON = GameObject.Find("JSON").GetComponent<JsonScript>();
			Fc5vUbEMCY = StudentManager.GetComponent<ExtraStudentManagerScript>();
			UpdateOpinions();
			DetermineOpinion();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00020910 File Offset: 0x0001EB10
		private void Update()
		{
			if (TopicInterface.InputManager.TappedUp || TopicInterface.InputManager.TappedDown || TopicInterface.InputManager.TappedLeft || TopicInterface.InputManager.TappedRight)
			{
				UpdateTopicHighlight();
			}
			if (Input.GetButtonDown("X"))
			{
				UpdateTopicHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				if (TopicInterface.Socializing)
				{
					TopicInterface.Yandere.Interaction = YandereInteractionType.Compliment;
					TopicInterface.Yandere.TalkTimer = 5f;
				}
				else
				{
					TopicInterface.Yandere.Interaction = YandereInteractionType.Gossip;
					TopicInterface.Yandere.TalkTimer = 5f;
				}
				TopicInterface.Yandere.PromptBar.Show = false;
				TopicInterface.gameObject.SetActive(value: false);
				if (TopicInterface.Student.StudentID < 101)
				{
					TopicInterface.Student.Talk.enabled = true;
				}
				else
				{
					TopicInterface.Student.Talk.enabled = false;
				}
				Time.timeScale = 1f;
			}
			UpdateTopicHighlight();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00020A60 File Offset: 0x0001EC60
		public void UpdateTopicHighlight()
		{
			DetermineOpinion();
			if (TopicInterface.Socializing)
			{
				TopicInterface.LoveHate = (TopicInterface.Positive ? "love" : "hate");
				TopicInterface.Statement = "Hi, " + TopicInterface.Student.Name + "! Gosh, I just really " + TopicInterface.LoveHate + " " + TopicInterface.TopicNames[TopicInterface.TopicSelected] + ". Can you relate to that at all?";
				if ((TopicInterface.Positive && TopicInterface.Opinion == 2) || (!TopicInterface.Positive && TopicInterface.Opinion == 1))
				{
					TopicInterface.Success = true;
				}
			}
			else
			{
				TopicInterface.LoveHate = (TopicInterface.Positive ? "loves" : "hates");
				if (TopicInterface.TargetStudentID < 101)
				{
					TopicInterface.Statement = "Hey, " + TopicInterface.Student.Name + "! Did you know that " + JSON.Students[TopicInterface.TargetStudentID].Name + " really " + TopicInterface.LoveHate + " " + TopicInterface.TopicNames[TopicInterface.TopicSelected] + "?";
				}
				else
				{
					TopicInterface.Statement = "Hey, " + TopicInterface.Student.Name + "! Did you know that " + NewJSON.Students[TopicInterface.TargetStudentID].Name + " really " + TopicInterface.LoveHate + " " + TopicInterface.TopicNames[TopicInterface.TopicSelected] + "?";
				}
				if ((TopicInterface.Positive && TopicInterface.Opinion == 1) || (!TopicInterface.Positive && TopicInterface.Opinion == 2))
				{
					TopicInterface.Success = true;
				}
			}
			TopicInterface.Label.text = TopicInterface.Statement;
			TopicInterface.EmbarassingSecret.SetActive(value: false);
			if (!TopicInterface.Socializing && TopicInterface.TargetStudentID == TopicInterface.StudentManager.RivalID && TopicInterface.StudentManager.EmbarassingSecret)
			{
				TopicInterface.EmbarassingSecret.SetActive(value: true);
			}
			if (TopicInterface.Positive)
			{
				TopicInterface.NegativeRemark.SetActive(value: false);
				TopicInterface.PositiveRemark.SetActive(value: true);
			}
			else
			{
				TopicInterface.PositiveRemark.SetActive(value: false);
				TopicInterface.NegativeRemark.SetActive(value: true);
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00020DE0 File Offset: 0x0001EFE0
		public void UpdateOpinions()
		{
			for (int i = 1; i <= 25; i++)
			{
				UISprite uISprite = TopicInterface.OpinionIcons[i];
				if (TopicInterface.StudentID < 101)
				{
					if (!StudentManager.GetTopicLearnedByStudent(i, TopicInterface.StudentID))
					{
						uISprite.spriteName = "Unknown";
						continue;
					}
					int[] topics = TopicInterface.JSON.Topics[TopicInterface.StudentID].Topics;
					uISprite.spriteName = TopicInterface.OpinionSpriteNames[topics[i]];
				}
				else if (!Fc5vUbEMCY.Q4mZrfQRNr(i, TopicInterface.StudentID))
				{
					uISprite.spriteName = "Unknown";
				}
				else
				{
					int[] topics2 = NewJSON.Topics[TopicInterface.StudentID].Topics;
					uISprite.spriteName = TopicInterface.OpinionSpriteNames[topics2[i]];
				}
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00020ED8 File Offset: 0x0001F0D8
		public void DetermineOpinion()
		{
			if (TopicInterface.StudentID < 101)
			{
				int[] topics = TopicInterface.JSON.Topics[TopicInterface.StudentID].Topics;
				TopicInterface.Opinion = topics[TopicInterface.TopicSelected];
			}
			else
			{
				int[] topics2 = NewJSON.Topics[TopicInterface.StudentID].Topics;
				TopicInterface.Opinion = topics2[TopicInterface.TopicSelected];
			}
			TopicInterface.Success = false;
		}

		// Token: 0x040000BF RID: 191
		public StudentManagerScript StudentManager;

		// Token: 0x040000C0 RID: 192
		private ExtraStudentManagerScript Fc5vUbEMCY;

		// Token: 0x040000C1 RID: 193
		public ExtraOpinionsLearnedScript OpinionsLearned;

		// Token: 0x040000C2 RID: 194
		public TopicInterfaceScript TopicInterface;

		// Token: 0x040000C3 RID: 195
		public InputManagerScript InputManager;

		// Token: 0x040000C4 RID: 196
		public YandereScript Yandere;

		// Token: 0x040000C5 RID: 197
		public ExtraJsonScript NewJSON;

		// Token: 0x040000C6 RID: 198
		public JsonScript JSON;
	}
}

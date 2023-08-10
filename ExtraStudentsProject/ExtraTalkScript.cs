using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x0200001A RID: 26
	internal class ExtraTalkScript : MonoBehaviour
	{
		// Token: 0x060000AB RID: 171 RVA: 0x000026A1 File Offset: 0x000008A1
		private void Start()
		{
			baseStudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			extraStudentManager = GameObject.Find("StudentManager").GetComponent<ExtraStudentManagerScript>();
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0001DC5C File Offset: 0x0001BE5C
		private void Update()
		{
			for (int i = 101; i < baseStudentManager.Students.Length; i++)
			{
				TalkTo(baseStudentManager.Students[i]);
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0001DC98 File Offset: 0x0001BE98
		private void TalkTo(StudentScript victim)
		{
			if (!(victim != null) || !victim.Talking)
			{
				return;
			}
			if (victim.Interaction == StudentInteractionType.ReceivingCompliment)
			{
				if (victim.TalkTimer == 3f)
				{
					if (!ConversationGlobals.GetTopicDiscovered(20))
					{
						victim.Yandere.NotificationManager.TopicName = "Socializing";
						victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
						ConversationGlobals.SetTopicDiscovered(20, value: true);
					}
					if (victim.StudentID < 101)
					{
						if (!victim.StudentManager.GetTopicLearnedByStudent(20, victim.StudentID))
						{
							victim.Yandere.NotificationManager.TopicName = "Socializing";
							victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
							victim.StudentManager.SetTopicLearnedByStudent(20, victim.StudentID, boolean: true);
						}
					}
					else if (!extraStudentManager.Q4mZrfQRNr(20, victim.StudentID))
					{
						victim.Yandere.NotificationManager.TopicName = "Socializing";
						victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
						extraStudentManager.OKiZVeY7HW(20, victim.StudentID, bool_0: true);
					}
					if (victim.Club != ClubType.Delinquent)
					{
						victim.CharacterAnimation.CrossFade(victim.LookDownAnim);
						GetRepBonusFor(victim);
						int topicSelected = victim.StudentManager.DialogueWheel.TopicInterface.TopicSelected;
						if (victim.StudentID < 101)
						{
							if (!victim.StudentManager.GetTopicLearnedByStudent(topicSelected, victim.StudentID))
							{
								victim.Yandere.NotificationManager.TopicName = victim.StudentManager.InterestManager.TopicNames[topicSelected];
								victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
								victim.StudentManager.SetTopicLearnedByStudent(topicSelected, victim.StudentID, boolean: true);
							}
						}
						else if (!extraStudentManager.Q4mZrfQRNr(topicSelected, victim.StudentID))
						{
							victim.Yandere.NotificationManager.TopicName = victim.StudentManager.InterestManager.TopicNames[topicSelected];
							victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
							extraStudentManager.OKiZVeY7HW(topicSelected, victim.StudentID, bool_0: true);
						}
						if (victim.DialogueWheel.TopicInterface.Success)
						{
							victim.Subtitle.PersonaSubtitle.UpdateLabel(PersonaType.Nemesis, victim.Reputation.Reputation, 5f);
							victim.Reputation.PendingRep += 1f + (float)victim.RepBonus;
							victim.PendingRep += 1f + (float)victim.RepBonus;
						}
						else
						{
							victim.Subtitle.PersonaSubtitle.UpdateLabel(PersonaType.None, victim.Reputation.Reputation, 5f);
							victim.Reputation.PendingRep -= 1f;
							victim.PendingRep -= 1f;
						}
					}
					else
					{
						victim.Subtitle.UpdateLabel(SubtitleType.Dismissive, 1, 3f);
					}
					victim.Complimented = true;
				}
				else if (Input.GetButtonDown("A"))
				{
					victim.TalkTimer = 0f;
				}
				victim.TalkTimer -= Time.deltaTime;
				if (victim.TalkTimer <= 0f)
				{
					victim.DialogueWheel.End();
					victim.Talk.enabled = true;
				}
			}
			if (victim.Interaction == StudentInteractionType.Gossiping)
			{
				if (victim.TalkTimer == 3f)
				{
					if (victim.Club != ClubType.Delinquent)
					{
						victim.Gossiped = true;
						if (victim.DialogueWheel.TopicInterface.Success)
						{
							victim.CharacterAnimation.CrossFade(victim.GossipAnim);
							victim.Subtitle.CustomText = "Ugh, I can't get along with people like that...";
							victim.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
							victim.GossipBonus = 0;
							if (PlayerGlobals.PantiesEquipped == 9)
							{
								victim.GossipBonus++;
							}
							if (victim.Yandere.Class.SocialBonus > 0)
							{
								victim.GossipBonus++;
							}
							if (victim.Friend)
							{
								victim.GossipBonus++;
							}
							if (victim.StudentManager.EmbarassingSecret && victim.DialogueWheel.Victim == victim.StudentManager.RivalID)
							{
								victim.GossipBonus++;
							}
							if ((victim.Male && victim.Yandere.Class.Seduction + victim.Yandere.Class.SeductionBonus > 0) || victim.Yandere.Class.Seduction == 5)
							{
								victim.GossipBonus++;
							}
							if (victim.Reputation.Reputation > 33.33333f)
							{
								victim.GossipBonus++;
							}
							if (victim.Club == ClubType.Bully)
							{
								victim.GossipBonus++;
							}
							victim.GossipBonus += victim.Yandere.Class.PsychologyGrade + victim.Yandere.Class.PsychologyBonus;
							victim.StudentManager.StudentReps[victim.DialogueWheel.Victim] -= 1 + victim.GossipBonus;
							if (victim.Club != ClubType.Bully)
							{
								victim.Reputation.PendingRep -= 2f;
								victim.PendingRep -= 2f;
							}
							victim.Gossiped = true;
							victim.Yandere.NotificationManager.TopicName = "Gossip";
							if (victim.StudentManager.Students[victim.DialogueWheel.Victim] != null)
							{
								victim.Yandere.NotificationManager.CustomText = victim.StudentManager.Students[victim.DialogueWheel.Victim].Name + "'s rep is now " + victim.StudentManager.StudentReps[victim.DialogueWheel.Victim];
								victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
							}
						}
						else
						{
							victim.Subtitle.PersonaSubtitle.UpdateLabel(PersonaType.None, victim.Reputation.Reputation, 5f);
							victim.Reputation.PendingRep -= 1f;
							victim.PendingRep -= 1f;
						}
						int topicSelected2 = victim.StudentManager.DialogueWheel.TopicInterface.TopicSelected;
						if (victim.StudentID < 101)
						{
							if (!victim.StudentManager.GetTopicLearnedByStudent(topicSelected2, victim.StudentID))
							{
								victim.Yandere.NotificationManager.TopicName = victim.StudentManager.InterestManager.TopicNames[topicSelected2];
								victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
								victim.StudentManager.SetTopicLearnedByStudent(topicSelected2, victim.StudentID, boolean: true);
							}
							if (!victim.StudentManager.GetTopicLearnedByStudent(19, victim.StudentID))
							{
								victim.Yandere.NotificationManager.TopicName = "Gossip";
								victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
								victim.StudentManager.SetTopicLearnedByStudent(19, victim.StudentID, boolean: true);
							}
						}
						else
						{
							if (!extraStudentManager.Q4mZrfQRNr(topicSelected2, victim.StudentID))
							{
								victim.Yandere.NotificationManager.TopicName = victim.StudentManager.InterestManager.TopicNames[topicSelected2];
								victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
								extraStudentManager.OKiZVeY7HW(topicSelected2, victim.StudentID, bool_0: true);
							}
							if (!extraStudentManager.Q4mZrfQRNr(19, victim.StudentID))
							{
								victim.Yandere.NotificationManager.TopicName = "Gossip";
								victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
								extraStudentManager.OKiZVeY7HW(19, victim.StudentID, bool_0: true);
							}
						}
					}
					else
					{
						victim.Subtitle.UpdateLabel(SubtitleType.Dismissive, 2, 3f);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						victim.TalkTimer = 0f;
					}
					if (victim.CharacterAnimation[victim.GossipAnim].time >= victim.CharacterAnimation[victim.GossipAnim].length)
					{
						victim.CharacterAnimation.CrossFade(victim.IdleAnim);
					}
					if (victim.TalkTimer <= 0f)
					{
						victim.Yandere.TargetStudent = victim;
						victim.DialogueWheel.End();
						victim.Talk.enabled = true;
					}
				}
				victim.TalkTimer -= Time.deltaTime;
			}
			if (victim.Interaction != StudentInteractionType.GivingTask || !(victim.TalkTimer <= 0f))
			{
				return;
			}
			if (victim.TaskPhase == 5)
			{
				if (victim.StudentID < 101)
				{
					if (!victim.StudentManager.GetTopicLearnedByStudent(21, victim.StudentID))
					{
						victim.Yandere.NotificationManager.TopicName = "Solitude";
						victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
						victim.StudentManager.SetTopicLearnedByStudent(21, victim.StudentID, boolean: true);
					}
				}
				else if (!extraStudentManager.Q4mZrfQRNr(21, victim.StudentID))
				{
					victim.Yandere.NotificationManager.TopicName = "Solitude";
					victim.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
					extraStudentManager.OKiZVeY7HW(21, victim.StudentID, bool_0: true);
				}
				victim.DialogueWheel.TaskWindow.TaskComplete = true;
				victim.StudentManager.TaskManager.TaskStatus[victim.StudentID] = 3;
				victim.Police.EndOfDay.NewFriends++;
				victim.Interaction = StudentInteractionType.Idle;
				victim.Friend = true;
				if (victim.Club != ClubType.Delinquent)
				{
					GetRepBonusFor(victim);
					victim.Reputation.PendingRep += 1f + (float)victim.RepBonus;
					victim.PendingRep += 1f + (float)victim.RepBonus;
				}
				else
				{
					victim.StudentManager.DelinquentVoices.SetActive(value: false);
				}
				if (SchemeGlobals.GetSchemeStage(6) == 3)
				{
					SchemeGlobals.SetSchemeStage(6, 4);
					victim.Yandere.PauseScreen.Schemes.UpdateInstructions();
				}
			}
			else if (victim.TaskPhase != 4 && victim.TaskPhase != 0)
			{
				if (victim.TaskPhase == 3)
				{
					victim.DialogueWheel.TaskWindow.UpdateWindow(victim.StudentID);
					victim.Subtitle.Label.text = "";
					victim.Interaction = StudentInteractionType.Idle;
					return;
				}
				if (victim.TaskPhase == 999)
				{
					victim.TaskPhase = 0;
					victim.Interaction = StudentInteractionType.Idle;
					victim.DialogueWheel.End();
					return;
				}
				victim.TaskPhase++;
				victim.Subtitle.UpdateLabel(victim.TaskLineResponseType, victim.TaskPhase, victim.Subtitle.GetClipLength(victim.StudentID, victim.TaskPhase));
				victim.Subtitle.Timer = 0f;
				victim.CharacterAnimation.CrossFade(victim.TaskAnims[victim.TaskPhase]);
				victim.CurrentAnim = victim.TaskAnims[victim.TaskPhase];
				victim.TalkTimer = victim.Subtitle.GetClipLength(victim.StudentID, victim.TaskPhase);
			}
			else
			{
				victim.StudentManager.TaskManager.UpdateTaskStatus();
				victim.DialogueWheel.End();
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0001E7F4 File Offset: 0x0001C9F4
		public void GetRepBonusFor(StudentScript victim)
		{
			victim.RepBonus = 0;
			if (PlayerGlobals.PantiesEquipped == 3)
			{
				victim.RepBonus++;
			}
			if ((victim.Male && victim.Yandere.Class.Seduction + victim.Yandere.Class.SeductionBonus > 0) || victim.Yandere.Class.Seduction == 5)
			{
				victim.RepBonus++;
			}
			if (victim.Yandere.Class.SocialBonus > 0)
			{
				victim.RepBonus++;
			}
			victim.ChameleonCheck();
			if (victim.Chameleon)
			{
				victim.RepBonus++;
			}
			victim.RepBonus += victim.Yandere.Class.PsychologyGrade + victim.Yandere.Class.PsychologyBonus;
		}

		// Token: 0x040000AC RID: 172
		private StudentManagerScript baseStudentManager;

		// Token: 0x040000AD RID: 173
		private ExtraStudentManagerScript extraStudentManager;
	}
}

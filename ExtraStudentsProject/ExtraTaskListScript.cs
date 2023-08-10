using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x0200001B RID: 27
	internal class ExtraTaskListScript : MonoBehaviour
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x0001E8D8 File Offset: 0x0001CAD8
		private void Start()
		{
			taskListScript = base.gameObject.GetComponent<TaskListScript>();
			extraJsonScript = GameObject.Find("JSON").GetComponent<ExtraJsonScript>();
			if (MissionModeGlobals.MissionMode)
			{
				taskListScript.TaskDesc.color = new Color(1f, 1f, 1f, 1f);
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0001E93C File Offset: 0x0001CB3C
		private void Update()
		{
			if (taskListScript.gameObject.activeInHierarchy && !injected)
			{
				taskListScript.enabled = false;
				injected = true;
				UpdateTaskList();
				StartCoroutine(taskListScript.UpdateTaskInfo());
			}
			if (!taskListScript.InputManager.DPadUp && !taskListScript.InputManager.StickUp && !Input.GetKey("w") && !Input.GetKey("up"))
			{
				taskListScript.HeldUp = 0f;
			}
			else
			{
				Debug.Log("yes, it's up...");
				taskListScript.HeldUp += Time.unscaledDeltaTime;
			}
			if (!taskListScript.InputManager.DPadDown && !taskListScript.InputManager.StickDown && !Input.GetKey("s") && !Input.GetKey("down"))
			{
				taskListScript.HeldDown = 0f;
			}
			else
			{
				taskListScript.HeldDown += Time.unscaledDeltaTime;
			}
			if (taskListScript.InputManager.TappedUp || taskListScript.HeldUp > 0.5f)
			{
				if (taskListScript.HeldUp > 0.5f)
				{
					taskListScript.HeldUp = 0.45f;
				}
				if (taskListScript.ID == 1)
				{
					taskListScript.ListPosition--;
					if (taskListScript.ListPosition < 0)
					{
						taskListScript.ListPosition = taskListScript.Limit - 16;
						taskListScript.ID = 16;
					}
				}
				else
				{
					taskListScript.ID--;
				}
				UpdateTaskList();
				StartCoroutine(taskListScript.UpdateTaskInfo());
			}
			if (taskListScript.InputManager.TappedDown || taskListScript.HeldDown > 0.5f)
			{
				if (taskListScript.HeldDown > 0.5f)
				{
					taskListScript.HeldDown = 0.45f;
				}
				if (taskListScript.ID == 16)
				{
					taskListScript.ListPosition++;
					if (taskListScript.ID + taskListScript.ListPosition > taskListScript.Limit)
					{
						taskListScript.ListPosition = 0;
						taskListScript.ID = 1;
					}
				}
				else
				{
					taskListScript.ID++;
				}
				UpdateTaskList();
				StartCoroutine(taskListScript.UpdateTaskInfo());
			}
			if (taskListScript.Tutorials)
			{
				if (!taskListScript.TutorialWindow.Hide && !taskListScript.TutorialWindow.Show)
				{
					if (Input.GetButtonDown("A"))
					{
						OptionGlobals.TutorialsOff = false;
						taskListScript.TutorialWindow.ForceID = taskListScript.ListPosition + taskListScript.ID;
						taskListScript.TutorialWindow.ShowTutorial();
						taskListScript.TutorialWindow.enabled = true;
						taskListScript.TutorialWindow.SummonWindow();
					}
					else if (Input.GetButtonDown("B"))
					{
						taskListScript.Exit();
					}
				}
			}
			else if (Input.GetButtonDown("B"))
			{
				taskListScript.Exit();
				injected = false;
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0001ECDC File Offset: 0x0001CEDC
		public void UpdateTaskList()
		{
			for (int i = 1; i < taskListScript.TaskNameLabels.Length; i++)
			{
				if (taskListScript.TaskWindow.TaskManager.TaskStatus[i + taskListScript.ListPosition] == 0)
				{
					taskListScript.TaskNameLabels[i].text = "Undiscovered Task #" + (i + taskListScript.ListPosition);
				}
				else if (i + taskListScript.ListPosition < 101)
				{
					taskListScript.TaskNameLabels[i].text = taskListScript.JSON.Students[i + taskListScript.ListPosition].Name + "'s Task";
				}
				else
				{
					taskListScript.TaskNameLabels[i].text = extraJsonScript.Students[i + taskListScript.ListPosition].Name + "'s Task";
				}
				taskListScript.Checkmarks[i].enabled = taskListScript.TaskWindow.TaskManager.TaskStatus[i + taskListScript.ListPosition] == 3;
			}
		}

		// Token: 0x040000AE RID: 174
		private ExtraJsonScript extraJsonScript;

		// Token: 0x040000AF RID: 175
		private TaskListScript taskListScript;

		// Token: 0x040000B0 RID: 176
		private bool injected;
	}
}

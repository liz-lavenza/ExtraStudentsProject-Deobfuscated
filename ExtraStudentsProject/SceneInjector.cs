using ExtraStudentsProject.ExtraStudentsMainModule;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExtraStudentsProject
{
	// Token: 0x0200000F RID: 15
	internal class SceneInjector : MonoBehaviour
	{
		// Token: 0x0600004D RID: 77 RVA: 0x0000251E File Offset: 0x0000071E
		private void Start()
		{
			SceneManager.activeSceneChanged += OnSceneChanged;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000048C4 File Offset: 0x00002AC4
		private void Update()
		{
			current_scene_name = SceneManager.GetActiveScene().name;
			if (!injected)
			{
				GameObject gameObject = new GameObject("MainHandler");
				switch (current_scene_name)
				{
				case "SchoolScene":
					gameObject.AddComponent<SchoolScriptInjector>();
					break;
				case "HomeScene":
					gameObject.AddComponent<ExtraStudentsHomeScript>();
					break;
				case "CreditsScene":
					gameObject.AddComponent<ExtraStudentsCreditsScript>();
					break;
				case "NewTitleScene":
					gameObject.AddComponent<TitleScreenInjector>();
					break;
				case "WelcomeScene":
					gameObject.AddComponent<WelcomeSceneInjector>();
					break;
				case "ResolutionScene":
					gameObject.AddComponent<ResolutionScreenInjectorScript>();
					break;
				}
				injected = true;
			}
			if (debug)
			{
				if (Input.GetKeyDown(KeyCode.Insert))
				{
					SceneManager.LoadScene("SchoolScene");
				}
				if (Input.GetKeyDown(KeyCode.End))
				{
					SceneManager.LoadScene("SchoolScene");
					Globals.DeleteAll();
					SchoolGlobals.DeleteAll();
				}
				if (Input.GetKeyDown(KeyCode.PageDown))
				{
					SceneManager.LoadScene("SchoolScene");
					StudentGlobals.SetStudentArrested(101, value: true);
					Debug.Log("Student 101 is arrested? " + StudentGlobals.GetStudentArrested(101));
				}
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002531 File Offset: 0x00000731
		private void OnSceneChanged(Scene scene_0, Scene scene_1)
		{
			injected = false;
		}

		// Token: 0x0400006A RID: 106
		private string current_scene_name;

		// Token: 0x0400006B RID: 107
		private bool injected;

		// Token: 0x0400006C RID: 108
		private bool debug;
	}
}

using ExtraStudentsProject.ExtraStudentsOpenLibrary;
using UnityEngine;

namespace ExtraStudentsProject.ExtraStudentsMainModule
{
	// Token: 0x0200002A RID: 42
	public class ExtraStudentsHomeScript : MonoBehaviour
	{
		// Token: 0x06000103 RID: 259 RVA: 0x00028870 File Offset: 0x00026A70
		private void Start()
		{
			PauseScreen = GameObject.Find("PauseScreen").GetComponent<PauseScreenScript>();
			PauseScreen.StudentInfoMenu.gameObject.AddComponent<ExtraStudentInfoMenuScript>();
			PauseScreen.StudentInfoMenu.StudentInfo.gameObject.AddComponent<ExtraStudentInfoScript>();
			GameObject.Find("StudentManager").AddComponent<ExtraStudentsSettingsManager>();
			GameObject.Find("JSON").AddComponent<ExtraJsonScript>();
			base.gameObject.AddComponent<ExtraStudentsNewSlotsScript>();
			base.gameObject.AddComponent<PrisonersInjector>();
		}

		// Token: 0x0400012D RID: 301
		private PauseScreenScript PauseScreen;
	}
}

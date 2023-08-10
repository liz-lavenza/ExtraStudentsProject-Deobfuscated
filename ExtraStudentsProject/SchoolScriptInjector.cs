using ExtraStudentsProject.ExtraStudentsMainModule;
using ExtraStudentsProject.ExtraStudentsOpenLibrary;
using ExtraStudentsProject.ExtraStudentsOpenLibrary.Misc_;
using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x0200002C RID: 44
	internal class SchoolScriptInjector : MonoBehaviour
	{
		// Token: 0x06000108 RID: 264 RVA: 0x0002BD10 File Offset: 0x00029F10
		private void Start()
		{
			GameObject.Find("StudentManager").AddComponent<ExtraStudentsFileManager>();
			GameObject.Find("StudentManager").AddComponent<ExtraStudentsSettingsManager>();
			GameObject.Find("JSON").AddComponent<ExtraJsonScript>();
			GameObject.Find("StudentManager").GetComponent<StudentManagerScript>().MemorialScene.gameObject.AddComponent<ExtraMemorialSceneScript>();
			GameObject.Find("StudentManager").AddComponent<ExtraStudentManagerScript>();
			GameObject.Find("DialogueWheel").AddComponent<ExtraDialogueWheelScript>();
			GameObject.Find("Shutter").AddComponent<ExtraShutterScript>();
			GameObject.Find("YandereChan").AddComponent<UselessThing>();
			GameObject.Find("YandereChan").GetComponent<YandereScript>().Police.gameObject.AddComponent<ExtraPoliceScript>();
			GameObject.Find("YandereChan").GetComponent<YandereScript>().Police.EndOfDay.gameObject.AddComponent<ExtraEndOfDay>();
			GameObject.Find("StudentManager").AddComponent<ExtraOpinionsLearnedScript>();
			GameObject.Find("PauseScreen").GetComponent<PauseScreenScript>().StudentInfoMenu.gameObject.AddComponent<ExtraStudentInfoMenuScript>();
			base.gameObject.AddComponent<ExtraStudentsNewSlotsScript>();
			base.gameObject.AddComponent<ClassroomExpander>();
			base.gameObject.AddComponent<LockerCreatorScript>();
			base.gameObject.AddComponent<StudentSpawner>();
			GameObject.Find("YandereChan").GetComponent<YandereScript>().Police.EndOfDay.VoidGoddess.gameObject.AddComponent<ExtraVoidGoddess>();
			GameObject.Find("Incinerator").AddComponent<ExtraIncineratorScript>();
			GameObject.Find("StudentManager").GetComponent<StudentManagerScript>().Yandere.PauseScreen.TaskList.gameObject.AddComponent<ExtraTaskListScript>();
			GameObject.Find("StudentManager").AddComponent<RecreateStudentInfoScript>();
			GameObject.Find("StudentManager").AddComponent<ExtraTalkScript>();
			GameObject.Find("DebugMenu").AddComponent<ExtraDebugMenuScript>();
			GameObject.Find("Portal").AddComponent<ExtraPortalScript>();
		}
	}
}

using ExtraStudentsProject.ExtraStudentsOpenLibrary;
using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x02000015 RID: 21
	internal class ExtraShutterScript : MonoBehaviour
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00002578 File Offset: 0x00000778
		private void Start()
		{
			baseShutterScript = base.gameObject.GetComponent<ShutterScript>();
			extraStudentInfo = baseShutterScript.StudentInfo.GetComponent<ExtraStudentInfoScript>();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000D640 File Offset: 0x0000B840
		private void Update()
		{
			if (baseShutterScript.DisplayError || !baseShutterScript.PhotoIcons.activeInHierarchy || baseShutterScript.Snapping || baseShutterScript.TextMessages.gameObject.activeInHierarchy)
			{
				return;
			}
			Time.timeScale = 0.0001f;
			if (baseShutterScript.Yandere.RivalPhone || !Input.GetButtonDown("X"))
			{
				return;
			}
			bool flag = false;
			if (baseShutterScript.StudentManager.Eighties && baseShutterScript.InfoX.activeInHierarchy)
			{
				flag = true;
			}
			if (!flag && !baseShutterScript.InfoX.activeInHierarchy)
			{
				baseShutterScript.PauseScreen.Sideways = true;
				if (!StudentGlobals.GetStudentPhotographed(baseShutterScript.Student.StudentID))
				{
					baseShutterScript.Yandere.Inventory.PantyShots++;
				}
				StudentGlobals.SetStudentPhotographed(baseShutterScript.Student.StudentID, value: true);
				baseShutterScript.ID = 0;
				if (baseShutterScript.Student.StudentID < 101)
				{
					baseShutterScript.StudentInfo.UpdateInfo(baseShutterScript.Student.StudentID);
				}
				else
				{
					extraStudentInfo.Start();
					extraStudentInfo.UpdateInfo(baseShutterScript.Student.StudentID);
					extraStudentInfo.StudentInfo.gameObject.SetActive(value: true);
				}
				baseShutterScript.StudentInfo.gameObject.SetActive(value: true);
				baseShutterScript.PhotoIcons.transform.localPosition = new Vector3(0f, 1000f, 0f);
			}
		}

		// Token: 0x04000080 RID: 128
		private ExtraStudentInfoScript extraStudentInfo;

		// Token: 0x04000081 RID: 129
		private ShutterScript baseShutterScript;
	}
}

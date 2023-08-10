using UnityEngine;

namespace ExtraStudentsProject.ExtraStudentsOpenLibrary
{
	// Token: 0x02000022 RID: 34
	public class ExtraSaveLoadMenuScript : MonoBehaviour
	{
		// Token: 0x060000DB RID: 219 RVA: 0x00002728 File Offset: 0x00000928
		private void Start()
		{
			Qk06ofRNGh = GameObject.Find("StudentManager").GetComponent<ExtraStudentManagerScript>();
			LNG6QsawvM = base.gameObject.GetComponent<SaveLoadMenuScript>();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00002750 File Offset: 0x00000950
		private void Update()
		{
			if (LNG6QsawvM.GrabScreenshot)
			{
				Debug.Log("Saving ExtraInfos.");
				Qk06ofRNGh.JwEZWJIcj5();
			}
		}

		// Token: 0x0400010A RID: 266
		[SerializeField]
		private ExtraStudentManagerScript Qk06ofRNGh;

		// Token: 0x0400010B RID: 267
		[SerializeField]
		private SaveLoadMenuScript LNG6QsawvM;
	}
}

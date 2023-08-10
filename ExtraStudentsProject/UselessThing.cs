using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x0200001F RID: 31
	internal class UselessThing : MonoBehaviour
	{
		// Token: 0x060000CE RID: 206 RVA: 0x000026E4 File Offset: 0x000008E4
		private void Start()
		{
			KEFvDluGg7 = base.gameObject.GetComponent<YandereScript>();
			MQdvFymLID = GameObject.Find("StudentManager").GetComponent<ExtraStudentManagerScript>();
		}

		// Token: 0x040000D5 RID: 213
		private ExtraStudentManagerScript MQdvFymLID;

		// Token: 0x040000D6 RID: 214
		private YandereScript KEFvDluGg7;
	}
}

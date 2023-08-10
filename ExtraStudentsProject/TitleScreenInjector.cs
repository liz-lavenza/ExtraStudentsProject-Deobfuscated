using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x0200002E RID: 46
	internal class TitleScreenInjector : MonoBehaviour
	{
		// Token: 0x06000113 RID: 275 RVA: 0x0002CBF8 File Offset: 0x0002ADF8
		private void Start()
		{
			RevisionLabel = GameObject.Find("DEMO/REVISION").GetComponent<UILabel>();
			RevisionLabel.transform.localPosition = new Vector3(RevisionLabel.transform.localPosition.x, -290f, RevisionLabel.transform.localPosition.z);
			ModifiedRevisionString = RevisionLabel.text + "\nEXTRA STUDENTS PROJECT!";
			RevisionLabel.text = ModifiedRevisionString;
		}

		// Token: 0x04000165 RID: 357
		private UILabel RevisionLabel;

		// Token: 0x04000166 RID: 358
		private string ModifiedRevisionString;
	}
}

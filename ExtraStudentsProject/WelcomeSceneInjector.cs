using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x02000031 RID: 49
	internal class WelcomeSceneInjector : MonoBehaviour
	{
		// Token: 0x06000122 RID: 290 RVA: 0x00002980 File Offset: 0x00000B80
		private void Start()
		{
			NewWelcomeText = "Welcome to Yandere Simulator + Extra Students Project!";
			WelcomeLabel = GameObject.Find("WelcomeToYandereSimulator").GetComponent<UILabel>();
			WelcomeLabel.text = NewWelcomeText;
		}

		// Token: 0x04000172 RID: 370
		private UILabel WelcomeLabel;

		// Token: 0x04000173 RID: 371
		private string NewWelcomeText;
	}
}

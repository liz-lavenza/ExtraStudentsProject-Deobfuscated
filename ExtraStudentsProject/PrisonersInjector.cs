using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x02000025 RID: 37
	internal class PrisonersInjector : MonoBehaviour
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x00027680 File Offset: 0x00025880
		private void Awake()
		{
			Prisoners = new HomePrisonerChanScript[2];
			Prisoners[0] = GameObject.Find("HomeCamera/Panel/PrisonerWindow/").GetComponent<HomePrisonerScript>().EightiesPrisoner;
			Prisoners[1] = GameObject.Find("HomeCamera/Panel/PrisonerWindow/").GetComponent<HomePrisonerScript>().Prisoner;
			initialised = true;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000276D8 File Offset: 0x000258D8
		private void Update()
		{
			if (!injected && initialised)
			{
				for (int i = 0; i < 2; i++)
				{
					Prisoners[i].gameObject.AddComponent<ExtraHomePrisonerChan>();
					injected = true;
				}
			}
		}

		// Token: 0x04000110 RID: 272
		private HomePrisonerChanScript[] Prisoners;

		// Token: 0x04000111 RID: 273
		private bool initialised;

		// Token: 0x04000112 RID: 274
		private bool injected;
	}
}

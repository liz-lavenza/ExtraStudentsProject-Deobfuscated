using System;
using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x02000012 RID: 18
	internal class ExtraIncineratorScript : MonoBehaviour
	{
		// Token: 0x0600005F RID: 95 RVA: 0x0000C490 File Offset: 0x0000A690
		private void Start()
		{
			Incinerator = base.gameObject.GetComponent<IncineratorScript>();
			Array.Resize(ref Incinerator.EvidenceList, Incinerator.Yandere.StudentManager.Students.Length);
			Array.Resize(ref Incinerator.CorpseList, Incinerator.Yandere.StudentManager.Students.Length);
			Array.Resize(ref Incinerator.VictimList, Incinerator.Yandere.StudentManager.Students.Length);
			Array.Resize(ref Incinerator.ConfirmedDead, Incinerator.Yandere.StudentManager.Students.Length);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000C54C File Offset: 0x0000A74C
		private void Update()
		{
			if (Incinerator.Prompt.Circle[0].fillAmount != 0f)
			{
				return;
			}
			Incinerator.ID = 0;
			while (Incinerator.ID < Incinerator.Yandere.StudentManager.Students.Length)
			{
				if (Incinerator.Yandere.StudentManager.Students[Incinerator.CorpseList[Incinerator.ID]] != null)
				{
					Incinerator.Yandere.StudentManager.Students[Incinerator.CorpseList[Incinerator.ID]].Ragdoll.Disposed = true;
					Incinerator.ConfirmedDead[Incinerator.ID] = Incinerator.CorpseList[Incinerator.ID];
					if (Incinerator.Yandere.StudentManager.Students[Incinerator.CorpseList[Incinerator.ID]].Ragdoll.Drowned)
					{
						Incinerator.Yandere.Police.DrownVictims--;
					}
				}
				Incinerator.ID++;
			}
		}

		// Token: 0x04000076 RID: 118
		private IncineratorScript Incinerator;
	}
}

using System;
using ExtraStudentsProject;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class ExtraOpinionsLearnedScript : MonoBehaviour
{
	// Token: 0x06000047 RID: 71 RVA: 0x00002266 File Offset: 0x00000466
	public ExtraOpinionsLearnedScript()
	{
		UselessCall.Noop();
	}

	// Token: 0x04000064 RID: 100
	[SerializeField]
	public Students[] StudentOpinions;

	// Token: 0x0200000C RID: 12
	[Serializable]
	public struct Students
	{
		// Token: 0x04000065 RID: 101
		public bool[] Opinions;
	}
}

using ExtraStudentsProject;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class ExtraStudentsCreditsScript : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002248 File Offset: 0x00000448
	private void Start()
	{
		Jh6h5GUqZ = GameObject.Find("Main Camera");
		Jh6h5GUqZ.AddComponent<ExtraCreditsScript>();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002266 File Offset: 0x00000466
	public ExtraStudentsCreditsScript()
	{
		UselessCall.Noop();
	}

	// Token: 0x04000001 RID: 1
	private GameObject Jh6h5GUqZ;
}

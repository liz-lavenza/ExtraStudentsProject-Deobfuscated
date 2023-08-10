using ExtraStudentsProject;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000008 RID: 8
public class ExtraJsonScript : MonoBehaviour
{
	// Token: 0x17000004 RID: 4
	// (get) Token: 0x0600001C RID: 28 RVA: 0x0000235B File Offset: 0x0000055B
	public ExtraStudentJson[] Students => students;

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x0600001D RID: 29 RVA: 0x00002363 File Offset: 0x00000563
	public ExtraCreditJson[] Credits => credits;

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x0600001E RID: 30 RVA: 0x0000236B File Offset: 0x0000056B
	public ExtraTopicJson[] Topics => topics;

	// Token: 0x0600001F RID: 31 RVA: 0x00004410 File Offset: 0x00002610
	private void Awake()
	{
		if (SceneManager.GetActiveScene().name == "CreditsScene")
		{
			credits = ExtraCreditJson.LoadFromJson(ExtraCreditJson.FilePath);
		}
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00004448 File Offset: 0x00002648
	private void Update()
	{
		if (!Updated)
		{
			if (SceneManager.GetActiveScene().name != "CreditsScene")
			{
				students = ExtraStudentJson.LoadFromJson(ExtraStudentJson.FilePath);
				topics = ExtraTopicJson.LoadFromJson(ExtraTopicJson.FilePath);
			}
			Updated = true;
		}
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00002266 File Offset: 0x00000466
	public ExtraJsonScript()
	{
		UselessCall.Noop();
	}

	// Token: 0x0400004A RID: 74
	[SerializeField]
	public ExtraStudentJson[] students;

	// Token: 0x0400004B RID: 75
	[SerializeField]
	public ExtraCreditJson[] credits;

	// Token: 0x0400004C RID: 76
	[SerializeField]
	public ExtraTopicJson[] topics;

	// Token: 0x0400004D RID: 77
	public bool Updated;
}

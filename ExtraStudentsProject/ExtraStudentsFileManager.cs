using System.IO;
using ExtraStudentsProject;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class ExtraStudentsFileManager : MonoBehaviour
{
	// Token: 0x06000011 RID: 17 RVA: 0x000033B8 File Offset: 0x000015B8
	private void Start()
	{
		ybkIBitBG = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		Error = new bool[3];
		ErrorUpdate = new bool[3];
		if (!Directory.Exists(Path.Combine(Application.streamingAssetsPath + eTeShhJXe)))
		{
			ErrorUpdate[0] = true;
			Debug.Log("Directory 'ExtraStudents' not found!");
			Debug.Log("Debugging directory:");
			Debug.Log(Path.Combine(Application.streamingAssetsPath + eTeShhJXe));
			Directory.CreateDirectory(Path.Combine(Application.streamingAssetsPath + eTeShhJXe));
		}
		if (!Directory.Exists(Path.Combine(Application.streamingAssetsPath + fUpEpjDrP)))
		{
			ErrorUpdate[1] = true;
			Debug.Log("Directory 'ExtraStudents/Resources/' not found!");
			Debug.Log("Debugging directory:");
			Debug.Log(Path.Combine(Application.streamingAssetsPath + fUpEpjDrP));
			Directory.CreateDirectory(Path.Combine(Application.streamingAssetsPath + fUpEpjDrP));
		}
		if (!File.Exists(Path.Combine(Application.streamingAssetsPath + fUpEpjDrP + lDhYU7pEu)))
		{
			ErrorUpdate[2] = true;
			Debug.Log("Debugging file path:");
			Debug.Log(Path.Combine(Application.streamingAssetsPath + fUpEpjDrP + lDhYU7pEu));
		}
	}

	// Token: 0x06000012 RID: 18 RVA: 0x0000356C File Offset: 0x0000176C
	private void Update()
	{
		if (Error[0])
		{
			if (ErrorUpdate[0])
			{
				ybkIBitBG.NotificationManager.CustomText = "Directory 'StreamingAssets/ExtraStudents/' not found. Creating directory!";
				ybkIBitBG.NotificationManager.DisplayNotification(NotificationType.Custom);
				ErrorUpdate[0] = false;
			}
			if (ErrorUpdate[1])
			{
				ybkIBitBG.NotificationManager.CustomText = "Directory 'StreamingAssets/ExtraStudents/Resources/' not found. Creating directory!";
				ybkIBitBG.NotificationManager.DisplayNotification(NotificationType.Custom);
				ErrorUpdate[1] = false;
			}
			if (ErrorUpdate[2])
			{
				ybkIBitBG.NotificationManager.CustomText = "ExtraStudentsAssets.N3xuSAPI Not found! Disabling Extra Students Project.";
				ybkIBitBG.NotificationManager.DisplayNotification(NotificationType.Custom);
				ErrorUpdate[2] = false;
			}
		}
	}

	// Token: 0x06000013 RID: 19 RVA: 0x0000230F File Offset: 0x0000050F
	public ExtraStudentsFileManager()
	{
		UselessCall.Noop();
		eTeShhJXe = "/ExtraStudents";
		fUpEpjDrP = "/ExtraStudents/Resources/";
		lDhYU7pEu = "ExtraStudentsAssets.N3xuSAPI";
	}

	// Token: 0x04000024 RID: 36
	private YandereScript ybkIBitBG;

	// Token: 0x04000025 RID: 37
	public bool[] ErrorUpdate;

	// Token: 0x04000026 RID: 38
	public bool[] Error;

	// Token: 0x04000027 RID: 39
	private string eTeShhJXe;

	// Token: 0x04000028 RID: 40
	private string fUpEpjDrP;

	// Token: 0x04000029 RID: 41
	private string lDhYU7pEu;
}

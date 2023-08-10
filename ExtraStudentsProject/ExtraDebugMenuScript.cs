using ExtraStudentsProject;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class ExtraDebugMenuScript : MonoBehaviour
{
	// Token: 0x06000018 RID: 24 RVA: 0x00003D58 File Offset: 0x00001F58
	private void Start()
	{
		DebugMenu = base.gameObject.GetComponent<DebugMenuScript>();
		DelinquentManager = DebugMenu.DelinquentManager;
		Bento = DebugMenu.Bento;
		EasterEggWindow = DebugMenu.EasterEggWindow;
		SacrificialArm = DebugMenu.SacrificialArm;
		DebugPoisons = DebugMenu.DebugPoisons;
		CircularSaw = DebugMenu.CircularSaw;
		GreenRoom = DebugMenu.GreenScreen;
		RoofKnife = DebugMenu.Knife;
		TeleportSpot = DebugMenu.TeleportSpot;
		ElectrocutionKit = DebugMenu.ElectrocutionKit;
		Mop = DebugMenu.Mop;
		MissionModeWindow = DebugMenu.MissionModeWindow;
		Window = DebugMenu.Window;
		PantyCensorTexture = DebugMenu.PantyCensorTexture;
		Object.Destroy(DebugMenu.GetComponent<DebugMenuScript>());
		GameObject.Find("DebugMenu").AddComponent<DebugMenuScript>();
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00003E84 File Offset: 0x00002084
	private void Update()
	{
		if (DebugMenu == null)
		{
			Omeu01OP1();
		}
		if (!DebugMenu.Yandere.NoDebug)
		{
			DebugMenu.MissionMode = false;
			DebugMenu.NoDebug = false;
		}
		if (DebugMenu.MissionMode || DebugMenu.NoDebug || !DebugMenu.Window.activeInHierarchy)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			for (int i = 101; i < DebugMenu.StudentManager.Students.Length; i++)
			{
				StudentGlobals.SetStudentPhotographed(i, value: true);
				if (DebugMenu.StudentManager.Students[i] != null)
				{
					DebugMenu.StudentManager.Students[i].Friend = true;
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.Z))
		{
			DebugMenu.Yandere.Police.Invalid = true;
			Debug.Log("Killing all students now.");
			for (int j = 2; j < DebugMenu.StudentManager.Students.Length; j++)
			{
				StudentScript studentScript = DebugMenu.StudentManager.Students[j];
				if (studentScript != null)
				{
					studentScript.SpawnAlarmDisc();
					studentScript.BecomeRagdoll();
					studentScript.DeathType = DeathType.EasterEgg;
				}
			}
			DebugMenu.Window.SetActive(value: false);
		}
		else if (Input.GetKeyDown("7"))
		{
			DebugMenu.Yandere.transform.position = DebugMenu.TeleportSpot[2].position + new Vector3(0.55f, 0f, 0f);
			if (DebugMenu.Yandere.Followers > 0)
			{
				DebugMenu.Yandere.Follower.transform.position = DebugMenu.Yandere.transform.position;
			}
			Physics.SyncTransforms();
			DebugMenu.Window.SetActive(value: false);
		}
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00004094 File Offset: 0x00002294
	private void Omeu01OP1()
	{
		DebugMenu = GameObject.Find("DebugMenu").GetComponent<DebugMenuScript>();
		DebugMenu.FakeStudentSpawner = GameObject.Find("FakeStudentSpawner").GetComponent<FakeStudentSpawnerScript>();
		DebugMenu.DelinquentManager = DelinquentManager;
		DebugMenu.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		DebugMenu.CameraEffects = GameObject.Find("MainCamera").GetComponent<CameraEffectsScript>();
		DebugMenu.WeaponManager = GameObject.Find("WeaponManager").GetComponent<WeaponManagerScript>();
		DebugMenu.Reputation = GameObject.Find("HUD/Reputation").GetComponent<ReputationScript>();
		DebugMenu.Counselor = GameObject.Find("Counselor").GetComponent<CounselorScript>();
		DebugMenu.DebugConsole = GameObject.Find("MainCamera").GetComponent<DebugConsole>();
		DebugMenu.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		DebugMenu.Bento = Bento;
		DebugMenu.Clock = GameObject.Find("HUD/Clock").GetComponent<ClockScript>();
		DebugMenu.Turtle = GameObject.Find("LightMusicClub/Aquarium/AquariumMesh").GetComponent<PrayScript>();
		DebugMenu.Zoom = GameObject.Find("YandereChan/CameraPivot/").GetComponent<ZoomScript>();
		DebugMenu.Astar = GameObject.Find("A*").GetComponent<AstarPath>();
		DebugMenu.OsanaEvent1 = GameObject.Find("EliminationEvents/OsanaEvents/Friday/OsanaFridayBeforeClassEvent1/").GetComponent<OsanaFridayBeforeClassEvent1Script>();
		DebugMenu.OsanaEvent2 = GameObject.Find("EliminationEvents/OsanaEvents/Friday/OsanaFridayBeforeClassEvent2/").GetComponent<OsanaFridayBeforeClassEvent2Script>();
		DebugMenu.OsanaEvent3 = GameObject.Find("EliminationEvents/OsanaEvents/Friday/OsanaFridayLunchEvent/").GetComponent<OsanaFridayLunchEventScript>();
		DebugMenu.EasterEggWindow = EasterEggWindow;
		DebugMenu.SacrificialArm = SacrificialArm;
		DebugMenu.DebugPoisons = DebugPoisons;
		DebugMenu.CircularSaw = CircularSaw;
		DebugMenu.GreenScreen = GreenRoom;
		DebugMenu.Knife = RoofKnife;
		DebugMenu.TeleportSpot = TeleportSpot;
		DebugMenu.RooftopSpot = GameObject.Find("MeetSpots").transform;
		DebugMenu.MidoriSpot = GameObject.Find("MidoriDebugSpot").transform;
		DebugMenu.Lockers = GameObject.Find("StudentManager/Lockers").transform;
		DebugMenu.MissionModeWindow = MissionModeWindow;
		DebugMenu.Window = Window;
		DebugMenu.ElectrocutionKit = ElectrocutionKit;
		DebugMenu.PantyCensorTexture = PantyCensorTexture;
		DebugMenu.Mop = Mop;
		DebugMenu.KidnappedVictim = 2;
		DebugMenu.RooftopStudent = 11;
		DebugMenu.transform.localPosition = new Vector3(DebugMenu.transform.localPosition.x, 0f, DebugMenu.transform.localPosition.z);
		DebugMenu.MissionModeWindow.SetActive(value: false);
		DebugMenu.Window.SetActive(value: false);
		DebugMenu.MissionMode = true;
		DebugMenu.NoDebug = true;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002266 File Offset: 0x00000466
	public ExtraDebugMenuScript()
	{
		UselessCall.Noop();
	}

	// Token: 0x0400003B RID: 59
	public DebugMenuScript DebugMenu;

	// Token: 0x0400003C RID: 60
	public DelinquentManagerScript DelinquentManager;

	// Token: 0x0400003D RID: 61
	public BentoScript Bento;

	// Token: 0x0400003E RID: 62
	public GameObject EasterEggWindow;

	// Token: 0x0400003F RID: 63
	public GameObject SacrificialArm;

	// Token: 0x04000040 RID: 64
	public GameObject DebugPoisons;

	// Token: 0x04000041 RID: 65
	public GameObject CircularSaw;

	// Token: 0x04000042 RID: 66
	public GameObject GreenRoom;

	// Token: 0x04000043 RID: 67
	public GameObject RoofKnife;

	// Token: 0x04000044 RID: 68
	public GameObject Mop;

	// Token: 0x04000045 RID: 69
	public GameObject MissionModeWindow;

	// Token: 0x04000046 RID: 70
	public GameObject Window;

	// Token: 0x04000047 RID: 71
	public GameObject[] ElectrocutionKit;

	// Token: 0x04000048 RID: 72
	public Texture PantyCensorTexture;

	// Token: 0x04000049 RID: 73
	public Transform[] TeleportSpot;
}

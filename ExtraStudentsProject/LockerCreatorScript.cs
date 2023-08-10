using System.IO;
using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x0200002D RID: 45
	internal class LockerCreatorScript : MonoBehaviour
	{
		// Token: 0x0600010A RID: 266 RVA: 0x0002BEF0 File Offset: 0x0002A0F0
		private void Start()
		{
			StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			ExtraFileManager = StudentManager.GetComponent<ExtraStudentsFileManager>();
			if (File.Exists(Path.Combine(Application.streamingAssetsPath + ResourceDirectory + studentMeshPath)))
			{
				studentMesh = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath + ResourceDirectory, studentMeshPath));
			}
			if (studentMesh != null)
			{
				Debug.Log(">> Success loading extra bundle assets. <<");
				ReplaceLockerObjects();
				WeaponBag = GameObject.Find("WeaponBag");
				Gift = GameObject.Find("Gift");
				Portal = StudentManager.Portal.GetComponent<PortalScript>();
				WeaponBag.transform.position = new Vector3(WeaponBag.transform.position.x, WeaponBag.transform.position.y, -32.74f);
				newColumns = new GameObject[3];
				columnAsset = studentMesh.LoadAsset<GameObject>("Column_One_Sided");
				newColumns[0] = Object.Instantiate(columnAsset, new Vector3(-3f, 0f, -22f), Quaternion.identity);
				newColumns[1] = Object.Instantiate(columnAsset, new Vector3(0f, 0f, -22f), Quaternion.identity);
				newColumns[2] = Object.Instantiate(columnAsset, new Vector3(3f, 0f, -22f), Quaternion.identity);
				MoveClassProps();
				studentMesh.Unload(unloadAllLoadedObjects: false);
			}
			else
			{
				Debug.Log(">> There was an error loading extra bundle assets. <<");
				ExtraFileManager.Error[0] = true;
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0002C0E0 File Offset: 0x0002A2E0
		private void Update()
		{
			if (!injected)
			{
				AstarPath.active.Scan();
				injected = true;
				for (int i = 1; i < StudentManager.Students.Length; i++)
				{
					InitLockers(0, i);
				}
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0002C128 File Offset: 0x0002A328
		private void ReplaceLockerObjects()
		{
			FindStudentMeshFilter = GameObject.Find("School/Lockers/FindStudentPrompt").GetComponent<MeshFilter>();
			SchoolEntrance = GameObject.Find("School/FirstFloor/Entrance");
			SchoolLockers = GameObject.Find("School/Lockers/");
			EntranceComponents = SchoolEntrance.GetComponentsInChildren(typeof(Component));
			LockersComponents = SchoolLockers.GetComponentsInChildren(typeof(Component));
			FindStudentMesh = studentMesh.LoadAsset<Mesh>("FindStudentMesh");
			FindStudentMeshFilter.mesh = FindStudentMesh;
			FindStudentMeshFilter.transform.localPosition = new Vector3(-3f, 1.3715f, 6.46f);
			Component[] entranceComponents = EntranceComponents;
			foreach (Component component in entranceComponents)
			{
				if (component.name == "Column_One_Sided")
				{
					component.gameObject.SetActive(value: false);
				}
			}
			entranceComponents = LockersComponents;
			foreach (Component component2 in entranceComponents)
			{
				if (component2.name == "LockerRow")
				{
					component2.gameObject.SetActive(value: false);
				}
			}
			entranceComponents = LockersComponents;
			foreach (Component component3 in entranceComponents)
			{
				if (component3.name == "Collider")
				{
					component3.gameObject.SetActive(value: false);
				}
			}
			MakeLockers();
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0002C29C File Offset: 0x0002A49C
		private void MakeLockers()
		{
			LockerRows = new GameObject[9];
			LockerColliders = new GameObject[5];
			for (int i = 0; i < 9; i++)
			{
				LockerRows[i] = Object.Instantiate(studentMesh.LoadAsset<GameObject>("NewLockerRow (" + i + ")"), new Vector3(0f, 0f, 0f), Quaternion.identity);
				LockerRows[i].transform.parent = SchoolLockers.transform;
			}
			LockerRows[0].transform.localPosition = new Vector3(-5.88f, 0f, 0.02f);
			LockerRows[1].transform.localPosition = new Vector3(-3f, 0f, 0.74f);
			LockerRows[2].transform.localPosition = new Vector3(-3f, 0f, 0.54f);
			LockerRows[3].transform.localPosition = new Vector3(0f, 0f, 0.74f);
			LockerRows[4].transform.localPosition = new Vector3(0f, 0f, 0.54f);
			LockerRows[5].transform.localPosition = new Vector3(3f, 0f, 0.74f);
			LockerRows[6].transform.localPosition = new Vector3(3f, 0f, 0.54f);
			LockerRows[7].transform.localPosition = new Vector3(5.88f, 0f, 0.74f);
			LockerRows[8].transform.localPosition = new Vector3(-5.88f, 4f, 0f);
			LockerRows[1].transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			LockerRows[3].transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			LockerRows[5].transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			LockerRows[7].transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			AddLockerColliders();
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0002C528 File Offset: 0x0002A728
		public void InitLockers(int int_0, int int_1)
		{
			if (int_1 < 86)
			{
				if (LockerRows[int_0].transform.Find("NewLocker (" + int_1 + ")") != null)
				{
					StudentManager.Lockers.List[int_1] = LockerRows[int_0].transform.Find("NewLocker (" + int_1 + ")");
				}
				else
				{
					int_0++;
					InitLockers(int_0, int_1);
				}
			}
			else if (int_1 > 100)
			{
				if (LockerRows[int_0].transform.Find("NewLocker (" + int_1 + ")") != null)
				{
					StudentManager.Lockers.List[int_1] = LockerRows[int_0].transform.Find("NewLocker (" + int_1 + ")");
				}
				else
				{
					int_0++;
					InitLockers(int_0, int_1);
				}
			}
			StudentManager.LockerPositions[int_1].transform.position = StudentManager.Lockers.List[int_1].position + StudentManager.Lockers.List[int_1].forward * 0.5f;
			StudentManager.LockerPositions[int_1].LookAt(StudentManager.Lockers.List[int_1].position);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0002C6B4 File Offset: 0x0002A8B4
		private void AddLockerColliders()
		{
			for (int i = 0; i < 5; i++)
			{
				LockerColliders[i] = new GameObject("Collider");
				LockerColliders[i].transform.parent = SchoolLockers.transform;
				LockerColliders[i].AddComponent<BoxCollider>();
			}
			LockerColliders[0].transform.localPosition = new Vector3(-5.745f, 0.75f, 0.1333333f);
			LockerColliders[0].GetComponent<BoxCollider>().center = new Vector3(0f, 0f, 0.25f);
			LockerColliders[0].GetComponent<BoxCollider>().size = new Vector3(0.27f, 1.5f, 10.8f);
			LockerColliders[1].transform.localPosition = new Vector3(-2f, 0.75f, 0.1333333f);
			LockerColliders[1].GetComponent<BoxCollider>().center = new Vector3(-1f, 0f, 0.65f);
			LockerColliders[1].GetComponent<BoxCollider>().size = new Vector3(0.54f, 1.5f, 10.6f);
			LockerColliders[2].transform.localPosition = new Vector3(1f, 0.75f, 0.1333333f);
			LockerColliders[2].GetComponent<BoxCollider>().center = new Vector3(-1f, 0f, 0.65f);
			LockerColliders[2].GetComponent<BoxCollider>().size = new Vector3(0.54f, 1.5f, 10.6f);
			LockerColliders[3].transform.localPosition = new Vector3(4f, 0.75f, 0.1333333f);
			LockerColliders[3].GetComponent<BoxCollider>().center = new Vector3(-1f, 0f, 0.65f);
			LockerColliders[3].GetComponent<BoxCollider>().size = new Vector3(0.54f, 1.5f, 10.6f);
			LockerColliders[4].transform.localPosition = new Vector3(5.745f, 0.75f, 0.1333333f);
			LockerColliders[4].GetComponent<BoxCollider>().center = new Vector3(0f, 0f, 0.5f);
			LockerColliders[4].GetComponent<BoxCollider>().size = new Vector3(0.27f, 1.5f, 10.14f);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0002C944 File Offset: 0x0002AB44
		public void MoveClassProps()
		{
			GameObject[] array = new GameObject[6];
			Transform[] componentsInChildren = GameObject.Find("School/Classprops/").GetComponentsInChildren<Transform>();
			int num = 0;
			Transform[] array2 = componentsInChildren;
			foreach (Transform transform in array2)
			{
				if (transform.name == "ClassProps" && num < array.Length)
				{
					array[num] = transform.gameObject;
					num++;
				}
				if (transform.name == "Desk")
				{
					transform.gameObject.SetActive(value: false);
				}
			}
			for (int j = 0; j < array.Length; j++)
			{
				ModifyClassSeats(array[j].transform, j);
			}
			Mesh mesh = studentMesh.LoadAsset<Mesh>("BentoWrap");
			Mesh mesh2 = studentMesh.LoadAsset<Mesh>("Q_Gift_Box_Bottom");
			Mesh mesh3 = studentMesh.LoadAsset<Mesh>("Q_Gift_Box_Top");
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			Portal.OsanaEvent.Bentos[1].transform.Find("BentoWrap").GetComponent<MeshFilter>().mesh = mesh;
			Portal.OsanaEvent.Bentos[2].transform.Find("BentoWrap").GetComponent<MeshFilter>().mesh = mesh;
			Gift.transform.Find("GiftBottom").GetComponent<MeshFilter>().mesh = mesh2;
			Gift.transform.Find("GiftBottom/GiftTop").GetComponent<MeshFilter>().mesh = mesh3;
			Gift.transform.Find("Note").GetComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;
			GameObject.Find("School/SecondFloor/Classrooms/").transform.GetChild(0).Find("Colliders").GetChild(6)
				.GetComponent<BoxCollider>()
				.size = new Vector3(6.25f, 3f, 0.3f);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0002CB40 File Offset: 0x0002AD40
		public void ModifyClassSeats(Transform transform_0, int int_0)
		{
			GameObject gameObject = studentMesh.LoadAsset<GameObject>("ClassSeats");
			if (gameObject != null)
			{
				Debug.Log("ClassID is: " + int_0);
				GameObject gameObject2 = Object.Instantiate(gameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject2.transform.parent = transform_0;
				gameObject2.transform.localPosition = new Vector3(0f, 0f, 0f);
				if (int_0 == 1 || int_0 == 3 || int_0 == 5)
				{
					gameObject2.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				}
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000028DD File Offset: 0x00000ADD
		public LockerCreatorScript()
		{
			UselessCall.Noop();
			ResourceDirectory = "/ExtraStudents/Resources/";
			studentMeshPath = "ExtraStudentsAssets.N3xuSAPI";
		}

		// Token: 0x04000152 RID: 338
		private StudentManagerScript StudentManager;

		// Token: 0x04000153 RID: 339
		private ExtraStudentsFileManager ExtraFileManager;

		// Token: 0x04000154 RID: 340
		private PortalScript Portal;

		// Token: 0x04000155 RID: 341
		private AssetBundle studentMesh;

		// Token: 0x04000156 RID: 342
		private MeshFilter FindStudentMeshFilter;

		// Token: 0x04000157 RID: 343
		private GameObject SchoolEntrance;

		// Token: 0x04000158 RID: 344
		private GameObject SchoolLockers;

		// Token: 0x04000159 RID: 345
		private GameObject columnAsset;

		// Token: 0x0400015A RID: 346
		private GameObject WeaponBag;

		// Token: 0x0400015B RID: 347
		private GameObject Gift;

		// Token: 0x0400015C RID: 348
		private GameObject[] LockerRows;

		// Token: 0x0400015D RID: 349
		private GameObject[] LockerColliders;

		// Token: 0x0400015E RID: 350
		private GameObject[] newColumns;

		// Token: 0x0400015F RID: 351
		private Component[] EntranceComponents;

		// Token: 0x04000160 RID: 352
		private Component[] LockersComponents;

		// Token: 0x04000161 RID: 353
		private Mesh FindStudentMesh;

		// Token: 0x04000162 RID: 354
		private bool injected;

		// Token: 0x04000163 RID: 355
		private string ResourceDirectory;

		// Token: 0x04000164 RID: 356
		private string studentMeshPath;
	}
}

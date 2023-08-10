using System;
using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x02000026 RID: 38
	internal class ClassroomExpander : MonoBehaviour
	{
		// Token: 0x060000E9 RID: 233 RVA: 0x0002771C File Offset: 0x0002591C
		private void Awake()
		{
			StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			DisabledManagers = GameObject.Find("DisabledManagers");
			StolenPhoneSpot = GameObject.Find("StolenPhoneSpot");
			OsanaBag = DisabledManagers.transform.Find("RivalBag (Osana)").gameObject;
			Seats = StudentManager.Seats;
			Portal = GameObject.Find("Portal").GetComponent<PortalScript>();
			Gift = GameObject.Find("Gift");
			ModifyClasses();
			Portal.transform.position = new Vector3(-11.87f, 5f, -25.4f);
			StolenPhoneSpot.transform.position = new Vector3(-13.25f, 5f, -24.05f);
			OsanaBag.transform.localPosition = new Vector3(-13.25f, 4.342f, -23.69f);
			Portal.OsanaEvent.Destination.transform.localPosition = new Vector3(-13.75f, 4f, -24f);
			Portal.OsanaEvent.Bentos[1].transform.position = new Vector3(-13.45f, 4.771692f, -24.151f);
			Portal.OsanaEvent.Bentos[2].transform.position = new Vector3(-13.45f, 4.771692f, -23.951f);
			Gift.transform.position = new Vector3(12.025f, 9.021f, -25.35f);
			GameObject.Find("EightiesPatrols").GetComponent<ListScript>().List[1].GetChild(0).transform.position = new Vector3(12f, 8f, -24.75f);
			GameObject.Find("EightiesEvents").transform.GetChild(0).transform.position = new Vector3(12f, 8.772625f, -25.025f);
			Portal.StudentManager.FridayTestNotes.transform.position = new Vector3(12f, 8.776f, -25.0854f);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000278B File Offset: 0x0000098B
		private void ModifyClasses()
		{
			ModifyClass(11, 1);
			ModifyClass(12, 2);
			ModifyClass(21, 3);
			ModifyClass(22, 4);
			ModifyClass(31, 5);
			ModifyClass(32, 6);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00027974 File Offset: 0x00025B74
		private void ModifyClass(int int_0, int int_1)
		{
			ExpandClass(int_0, int_1);
			AddSeat(int_0, 1, -3.25f, 0f, 2.15f);
			AddSeat(int_0, 2, -1.95f, 0f, 2.15f);
			AddSeat(int_0, 3, -0.65f, 0f, 2.15f);
			AddSeat(int_0, 4, 0.65f, 0f, 2.15f);
			AddSeat(int_0, 5, 1.95f, 0f, 2.15f);
			AddSeat(int_0, 6, 3.25f, 0f, 2.15f);
			AddSeat(int_0, 7, -3.25f, 0f, 0.9f);
			AddSeat(int_0, 8, -1.95f, 0f, 0.9f);
			AddSeat(int_0, 9, -0.65f, 0f, 0.9f);
			AddSeat(int_0, 10, 0.65f, 0f, 0.9f);
			AddSeat(int_0, 11, 1.95f, 0f, 0.9f);
			AddSeat(int_0, 12, 3.25f, 0f, 0.9f);
			AddSeat(int_0, 13, -3.25f, 0f, -0.35f);
			AddSeat(int_0, 14, -1.95f, 0f, -0.35f);
			AddSeat(int_0, 15, -0.65f, 0f, -0.35f);
			AddSeat(int_0, 16, 0.65f, 0f, -0.35f);
			AddSeat(int_0, 17, 1.95f, 0f, -0.35f);
			AddSeat(int_0, 18, 3.25f, 0f, -0.35f);
			AddSeat(int_0, 19, -3.25f, 0f, -1.6f);
			AddSeat(int_0, 20, -1.95f, 0f, -1.6f);
			AddSeat(int_0, 21, -0.65f, 0f, -1.6f);
			AddSeat(int_0, 22, 0.65f, 0f, -1.6f);
			AddSeat(int_0, 23, 1.95f, 0f, -1.6f);
			AddSeat(int_0, 24, 3.25f, 0f, -1.6f);
			AddSeat(int_0, 25, -3.25f, 0f, -2.85f);
			AddSeat(int_0, 26, -1.95f, 0f, -2.85f);
			AddSeat(int_0, 27, -0.65f, 0f, -2.85f);
			AddSeat(int_0, 28, 0.65f, 0f, -2.85f);
			AddSeat(int_0, 29, 1.95f, 0f, -2.85f);
			AddSeat(int_0, 30, 3.25f, 0f, -2.85f);
			AddDesk(int_1, 0, -3.25f, 0f, 2.15f);
			AddDesk(int_1, 1, -1.95f, 0f, 2.15f);
			AddDesk(int_1, 2, -0.65f, 0f, 2.15f);
			AddDesk(int_1, 3, 0.65f, 0f, 2.15f);
			AddDesk(int_1, 4, 1.95f, 0f, 2.15f);
			AddDesk(int_1, 5, 3.25f, 0f, 2.15f);
			AddDesk(int_1, 6, -3.25f, 0f, 0.9f);
			AddDesk(int_1, 7, -1.95f, 0f, 0.9f);
			AddDesk(int_1, 8, -0.65f, 0f, 0.9f);
			AddDesk(int_1, 9, 0.65f, 0f, 0.9f);
			AddDesk(int_1, 10, 1.95f, 0f, 0.9f);
			AddDesk(int_1, 11, 3.25f, 0f, 0.9f);
			AddDesk(int_1, 12, -3.25f, 0f, -0.35f);
			AddDesk(int_1, 13, -1.95f, 0f, -0.35f);
			AddDesk(int_1, 14, -0.65f, 0f, -0.35f);
			AddDesk(int_1, 15, 0.65f, 0f, -0.35f);
			AddDesk(int_1, 16, 1.95f, 0f, -0.35f);
			AddDesk(int_1, 17, 3.25f, 0f, -0.35f);
			AddDesk(int_1, 18, -3.25f, 0f, -1.6f);
			AddDesk(int_1, 19, -1.95f, 0f, -1.6f);
			AddDesk(int_1, 20, -0.65f, 0f, -1.6f);
			AddDesk(int_1, 21, 0.65f, 0f, -1.6f);
			AddDesk(int_1, 22, 1.95f, 0f, -1.6f);
			AddDesk(int_1, 23, 3.25f, 0f, -1.6f);
			AddDesk(int_1, 24, -3.25f, 0f, -2.85f);
			AddDesk(int_1, 25, -1.95f, 0f, -2.85f);
			AddDesk(int_1, 26, -0.65f, 0f, -2.85f);
			AddDesk(int_1, 27, 0.65f, 0f, -2.85f);
			AddDesk(int_1, 28, 1.95f, 0f, -2.85f);
			AddDesk(int_1, 29, 3.25f, 0f, -2.85f);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000027C3 File Offset: 0x000009C3
		private void AddSeat(int int_0, int int_1, float float_0, float float_1, float float_2)
		{
			Seats[int_0].List[int_1].transform.localPosition = new Vector3(float_0, float_1, float_2);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000027E8 File Offset: 0x000009E8
		private void AddDesk(int int_0, int int_1, float float_0, float float_1, float float_2)
		{
			StudentManager.CleaningManager.Desks[int_0].GetChild(int_1).transform.localPosition = new Vector3(float_0, float_1, float_2);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00027F18 File Offset: 0x00026118
		private void ExpandClass(int int_0, int int_1)
		{
			Array.Resize(ref Seats[int_0].List, 31);
			Array.Resize(ref StudentManager.CleaningManager.Desks[int_1].GetComponent<ListScript>().List, 31);
			for (int i = 16; i < 31; i++)
			{
				Seats[int_0].List[i] = new GameObject(i.ToString()).transform;
				Seats[int_0].List[i].transform.parent = Seats[int_0].transform;
				StudentManager.CleaningManager.Desks[int_1].GetComponent<ListScript>().List[i] = new GameObject(i.ToString()).transform;
				StudentManager.CleaningManager.Desks[int_1].GetComponent<ListScript>().List[i].transform.parent = StudentManager.CleaningManager.Desks[int_1].transform;
				CreateDesks(int_0, int_1, i, 0f, 0f, 0f);
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0002803C File Offset: 0x0002623C
		private void CreateDesks(int int_0, int int_1, int int_2, float float_0, float float_1, float float_2)
		{
			Seats[int_0].List[int_2].transform.localEulerAngles = new Vector3(float_0, float_1, float_2);
			Seats[int_0].List[int_2].transform.localScale = new Vector3(1f, 1f, 1f);
			StudentManager.CleaningManager.Desks[int_1].GetComponent<ListScript>().List[int_2].transform.localEulerAngles = new Vector3(float_0, float_1, float_2);
			StudentManager.CleaningManager.Desks[int_1].GetComponent<ListScript>().List[int_2].transform.localScale = new Vector3(1f, 1f, 1f);
		}

		// Token: 0x04000113 RID: 275
		public StudentManagerScript StudentManager;

		// Token: 0x04000114 RID: 276
		public ListScript[] Seats;

		// Token: 0x04000115 RID: 277
		public PortalScript Portal;

		// Token: 0x04000116 RID: 278
		public GameObject DisabledManagers;

		// Token: 0x04000117 RID: 279
		public GameObject StolenPhoneSpot;

		// Token: 0x04000118 RID: 280
		public GameObject OsanaBag;

		// Token: 0x04000119 RID: 281
		public GameObject Gift;
	}
}

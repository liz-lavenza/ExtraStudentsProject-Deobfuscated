using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x0200000D RID: 13
	internal class StudentSpawner : MonoBehaviour
	{
		// Token: 0x06000048 RID: 72 RVA: 0x000024C7 File Offset: 0x000006C7
		private void Start()
		{
			StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			ExtraStudentManager = StudentManager.GetComponent<ExtraStudentManagerScript>();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000483C File Offset: 0x00002A3C
		private void Update()
		{
			if (injected)
			{
				return;
			}
			for (int i = 101; i < StudentManager.Students.Length; i++)
			{
				if (StudentManager.SpawnPositions[i] != null)
				{
					if (ExtraStudentManager.StudentFirstWeeks[i] == 0)
					{
						ExtraStudentManager.SpawnStudent(i);
					}
					else if (DateGlobals.Week >= ExtraStudentManager.StudentFirstWeeks[i])
					{
						ExtraStudentManager.SpawnStudent(i);
					}
				}
			}
			injected = true;
		}

		// Token: 0x04000066 RID: 102
		private StudentManagerScript StudentManager;

		// Token: 0x04000067 RID: 103
		public ExtraStudentManagerScript ExtraStudentManager;

		// Token: 0x04000068 RID: 104
		private bool injected;
	}
}

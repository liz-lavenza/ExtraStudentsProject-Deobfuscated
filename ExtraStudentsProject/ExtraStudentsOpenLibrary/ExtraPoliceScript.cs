using UnityEngine;

namespace ExtraStudentsProject.ExtraStudentsOpenLibrary
{
	// Token: 0x02000014 RID: 20
	public class ExtraPoliceScript : MonoBehaviour
	{
		// Token: 0x06000067 RID: 103 RVA: 0x0000253A File Offset: 0x0000073A
		private void Start()
		{
			NNcNdySHXC = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			aXZNwQsR6H = base.gameObject.GetComponent<PoliceScript>();
			xw5NVUMm8w = NNcNdySHXC.JSON.GetComponent<ExtraJsonScript>();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000D154 File Offset: 0x0000B354
		public void KillStudents()
		{
			Debug.Log("KillStudents() is being called.");
			for (int i = 1; i < NNcNdySHXC.Students.Length; i++)
			{
				if (StudentGlobals.GetStudentDead(i) || !(NNcNdySHXC.StudentReps[i] < -150f))
				{
					continue;
				}
				aXZNwQsR6H.Deaths++;
				StudentGlobals.SetStudentDead(i, value: true);
				Debug.Log("Student #" + i + " committed suicide due to low reputation. They will have a memorial at school tomorrow.");
				if (StudentGlobals.MemorialStudents < 9)
				{
					StudentGlobals.MemorialStudents++;
					if (StudentGlobals.MemorialStudents == 1)
					{
						StudentGlobals.MemorialStudent1 = i;
					}
					else if (StudentGlobals.MemorialStudents == 2)
					{
						StudentGlobals.MemorialStudent2 = i;
					}
					else if (StudentGlobals.MemorialStudents == 3)
					{
						StudentGlobals.MemorialStudent3 = i;
					}
					else if (StudentGlobals.MemorialStudents == 4)
					{
						StudentGlobals.MemorialStudent4 = i;
					}
					else if (StudentGlobals.MemorialStudents == 5)
					{
						StudentGlobals.MemorialStudent5 = i;
					}
					else if (StudentGlobals.MemorialStudents == 6)
					{
						StudentGlobals.MemorialStudent6 = i;
					}
					else if (StudentGlobals.MemorialStudents == 7)
					{
						StudentGlobals.MemorialStudent7 = i;
					}
					else if (StudentGlobals.MemorialStudents == 8)
					{
						StudentGlobals.MemorialStudent8 = i;
					}
					else if (StudentGlobals.MemorialStudents == 9)
					{
						StudentGlobals.MemorialStudent9 = i;
					}
				}
			}
			if (aXZNwQsR6H.Deaths > 0)
			{
				PlayerGlobals.Kills += aXZNwQsR6H.Deaths;
				Debug.Log("There were deaths at school today. As a result, PlayerGlobals.Kills is being incremented.");
				for (int j = 2; j < NNcNdySHXC.Students.Length; j++)
				{
					if (!StudentGlobals.GetStudentDying(j) && (!(NNcNdySHXC.Students[j] != null) || NNcNdySHXC.Students[j].Alive))
					{
						continue;
					}
					Debug.Log("Subtracting 10% school atmosphere because someone died.");
					SchoolGlobals.SchoolAtmosphere -= 0.1f;
					if (j > 100)
					{
						if (xw5NVUMm8w.Students[j].Club == ClubType.Council)
						{
							SchoolGlobals.SchoolAtmosphere -= 1f;
							SchoolGlobals.HighSecurity = true;
						}
					}
					else if (j < 98 && aXZNwQsR6H.JSON.Students[j].Club == ClubType.Council)
					{
						SchoolGlobals.SchoolAtmosphere -= 1f;
						SchoolGlobals.HighSecurity = true;
					}
					StudentGlobals.SetStudentDead(j, value: true);
					if (j > 10 && j < DateGlobals.Week + 10 && NNcNdySHXC.Students[j] != null && NNcNdySHXC.Students[j].Ragdoll.Disposed)
					{
						Debug.Log("The player killed a previous rival and disposed of her corpse.");
						aXZNwQsR6H.EndOfDay.SetFormerRivalDeath(j - 10, NNcNdySHXC.Students[j]);
						GameGlobals.SetRivalEliminations(j - 10, 11);
					}
					StudentGlobals.SetStudentGrudge(j, value: false);
				}
				SchoolGlobals.SchoolAtmosphere -= (float)aXZNwQsR6H.Corpses * 0.1f;
				if (aXZNwQsR6H.DrownVictims + aXZNwQsR6H.Corpses > 0)
				{
					RagdollScript[] corpseList = aXZNwQsR6H.CorpseList;
					foreach (RagdollScript ragdollScript in corpseList)
					{
						if (ragdollScript != null && !ragdollScript.Disposed && StudentGlobals.MemorialStudents < 9)
						{
							StudentGlobals.MemorialStudents++;
							if (StudentGlobals.MemorialStudents == 1)
							{
								StudentGlobals.MemorialStudent1 = ragdollScript.Student.StudentID;
							}
							else if (StudentGlobals.MemorialStudents == 2)
							{
								StudentGlobals.MemorialStudent2 = ragdollScript.Student.StudentID;
							}
							else if (StudentGlobals.MemorialStudents == 3)
							{
								StudentGlobals.MemorialStudent3 = ragdollScript.Student.StudentID;
							}
							else if (StudentGlobals.MemorialStudents == 4)
							{
								StudentGlobals.MemorialStudent4 = ragdollScript.Student.StudentID;
							}
							else if (StudentGlobals.MemorialStudents == 5)
							{
								StudentGlobals.MemorialStudent5 = ragdollScript.Student.StudentID;
							}
							else if (StudentGlobals.MemorialStudents == 6)
							{
								StudentGlobals.MemorialStudent6 = ragdollScript.Student.StudentID;
							}
							else if (StudentGlobals.MemorialStudents == 7)
							{
								StudentGlobals.MemorialStudent7 = ragdollScript.Student.StudentID;
							}
							else if (StudentGlobals.MemorialStudents == 8)
							{
								StudentGlobals.MemorialStudent8 = ragdollScript.Student.StudentID;
							}
							else if (StudentGlobals.MemorialStudents == 9)
							{
								StudentGlobals.MemorialStudent9 = ragdollScript.Student.StudentID;
							}
						}
					}
				}
			}
			SchoolGlobals.SchoolAtmosphere = Mathf.Clamp01(SchoolGlobals.SchoolAtmosphere);
			for (int l = 1; l < NNcNdySHXC.StudentsTotal; l++)
			{
				StudentScript studentScript = NNcNdySHXC.Students[l];
				if (studentScript != null && studentScript.Grudge && studentScript.Persona != PersonaType.Evil)
				{
					StudentGlobals.SetStudentGrudge(l, value: true);
					if (studentScript.OriginalPersona == PersonaType.Sleuth && !StudentGlobals.GetStudentDying(l))
					{
						StudentGlobals.SetStudentGrudge(56, value: true);
						StudentGlobals.SetStudentGrudge(57, value: true);
						StudentGlobals.SetStudentGrudge(58, value: true);
						StudentGlobals.SetStudentGrudge(59, value: true);
						StudentGlobals.SetStudentGrudge(60, value: true);
					}
				}
			}
		}

		// Token: 0x0400007D RID: 125
		private StudentManagerScript NNcNdySHXC;

		// Token: 0x0400007E RID: 126
		private PoliceScript aXZNwQsR6H;

		// Token: 0x0400007F RID: 127
		private ExtraJsonScript xw5NVUMm8w;
	}
}

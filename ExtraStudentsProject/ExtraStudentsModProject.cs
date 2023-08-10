using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x0200000E RID: 14
	public class ExtraStudentsModProject : MonoBehaviour
	{
		// Token: 0x0600004B RID: 75 RVA: 0x000024EF File Offset: 0x000006EF
		public static void HookProjectWithGame()
		{
			if (!I5FN4JKJZR)
			{
				GameObject obj = new GameObject("ExtraStudentsHandler");
				obj.AddComponent<SceneInjector>();
				Object.DontDestroyOnLoad(obj);
				I5FN4JKJZR = true;
				Debug.Log("Hooking is finished. Welcome to 'Extra Students Project'!");
			}
		}

		// Token: 0x04000069 RID: 105
		private static bool I5FN4JKJZR;
	}
}

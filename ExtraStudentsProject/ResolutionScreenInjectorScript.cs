using System.Collections;
using ExtraStudentsProject.ExtraStudentsMainModule;
using UnityEngine;

namespace ExtraStudentsProject
{
	// Token: 0x0200002F RID: 47
	internal class ResolutionScreenInjectorScript : MonoBehaviour
	{
		// Token: 0x06000115 RID: 277 RVA: 0x0002CC8C File Offset: 0x0002AE8C
		private void Start()
		{
			WelcomeString = "Welcome to the Extra Students Project! This mod is developed by N3xuS.\n\n";
			WarningString = "\n\nDO NOT report bugs to YandereDev using this modification.";
			BugReportString = "\n\nFound any bugs? Report them on the server: https://discord.gg/wCQ2FZAcmQ (Press Enter)";
			Discord = GameObject.Find("Discord");
			Prv8dSn6aB = new GameObject[2];
			v458wuXq1P = new GameObject[3];
			Prv8dSn6aB[0] = GameObject.Find("Main Camera/Panel/Bug Warning Label");
			Prv8dSn6aB[1] = GameObject.Find("Main Camera/Panel/Bug Warning BG");
			v458wuXq1P[0] = new GameObject();
			v458wuXq1P[1] = new GameObject();
			v458wuXq1P[0] = Object.Instantiate(Prv8dSn6aB[0]);
			v458wuXq1P[1] = Object.Instantiate(Prv8dSn6aB[1]);
			v458wuXq1P[2] = Object.Instantiate(Prv8dSn6aB[0]);
			for (int i = 0; i < 3; i++)
			{
				v458wuXq1P[i].transform.localPosition = new Vector3(0f, -0.35f, 1f);
			}
			v458wuXq1P[0].GetComponent<UILabel>().text = WelcomeString;
			v458wuXq1P[1].GetComponent<UISprite>().height = 200;
			v458wuXq1P[2].GetComponent<UILabel>().text = BugReportString;
			StartCoroutine(HhH8uCflE4());
			AddExtraSettingsManager();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00002900 File Offset: 0x00000B00
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
			{
				Application.OpenURL("https://discord.gg/wCQ2FZAcmQ");
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0002CDEC File Offset: 0x0002AFEC
		private void VXm8AV9dOg()
		{
			FFo8cNuAMM = !FFo8cNuAMM;
			if (FFo8cNuAMM)
			{
				v458wuXq1P[2].GetComponent<UILabel>().color = Color.red;
			}
			else
			{
				v458wuXq1P[2].GetComponent<UILabel>().color = Color.white;
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00002921 File Offset: 0x00000B21
		private IEnumerator HhH8uCflE4()
		{
			for (;;)
			{
				yield return new WaitForSeconds(0.5f);
				VXm8AV9dOg();
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00002930 File Offset: 0x00000B30
		private void AddExtraSettingsManager()
		{
			base.gameObject.AddComponent<ExtraStudentsSettingsManager>();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000293E File Offset: 0x00000B3E
		public void InjectExtraDiscordHandler()
		{
			if (DiscordNeedsInjection)
			{
				Object.Destroy(Discord.GetComponent<DiscordRPC>());
				Discord.AddComponent<ExtraStudentsDiscordManager>();
			}
		}

		// Token: 0x04000167 RID: 359
		private GameObject[] Prv8dSn6aB;

		// Token: 0x04000168 RID: 360
		private GameObject[] v458wuXq1P;

		// Token: 0x04000169 RID: 361
		public GameObject Discord;

		// Token: 0x0400016A RID: 362
		private string WelcomeString;

		// Token: 0x0400016B RID: 363
		private string WarningString;

		// Token: 0x0400016C RID: 364
		private string BugReportString;

		// Token: 0x0400016D RID: 365
		private bool FFo8cNuAMM;

		// Token: 0x0400016E RID: 366
		public bool DiscordNeedsInjection;
	}
}

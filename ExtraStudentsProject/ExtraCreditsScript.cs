using System.IO;
using System.Runtime.CompilerServices;
using ExtraStudentsProject;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000004 RID: 4
public class ExtraCreditsScript : MonoBehaviour
{
	private bool ShouldStopCredits => ID == JSON.Credits.Length;

	// Token: 0x06000009 RID: 9 RVA: 0x000022B8 File Offset: 0x000004B8
	private GameObject Sv73uUfN9(int int_0)
	{
		return Object.Instantiate((int_0 == 1) ? Swpjp1dOd : Bc812gqOh, SpawnPoint.position, Quaternion.identity);
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002CB4 File Offset: 0x00000EB4
	private void Start()
	{
		Di2fRRexo();
		Dark = baseCredits.Dark;
		if (GameGlobals.TransitionToPostCredits || GameGlobals.DarkEnding)
		{
			GameGlobals.DarkEnding = false;
			Jukebox.clip = DarkCreditsMusic;
			Darkness.color = new Color(0f, 0f, 0f, 0f);
			Blossoms.startColor = new Color(0.5f, 0f, 0f, 1f);
			SkipLabel.color = new Color(0.5f, 0f, 0f, 1f);
			Dark = true;
		}
		if (GameGlobals.Eighties)
		{
			Camera.main.backgroundColor = new Color(0.05f, 0.05f, 0.05f, 1f);
			Jukebox.clip = EightiesCreditsMusic;
			Eighties = true;
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002DB8 File Offset: 0x00000FB8
	private void Di2fRRexo()
	{
		baseCredits = GameObject.Find("Main Camera").GetComponent<CreditsScript>();
		JSON = GameObject.Find("JSON").GetComponent<JsonScript>();
		Panel = baseCredits.transform.Find("Panel/");
		SpawnPoint = baseCredits.transform.Find("Panel/SpawnPoint");
		SkipLabel = baseCredits.transform.Find("Panel/SkipLabel").GetComponent<UILabel>();
		Darkness = baseCredits.transform.Find("Panel/Darkness").GetComponent<UISprite>();
		DefaultValues();
		EightiesCreditsMusic = baseCredits.EightiesCreditsMusic;
		DarkCreditsMusic = baseCredits.DarkCreditsMusic;
		Jukebox = baseCredits.Jukebox;
		Blossoms = baseCredits.Blossoms;
		baseCredits.enabled = false;
		JSON.enabled = false;
		JSON.gameObject.AddComponent<ExtraJsonScript>();
		if (File.Exists(Path.Combine(Application.streamingAssetsPath + ResourcesDirectory + ResourceFile)))
		{
			uPteoYPAv = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath + ResourcesDirectory, ResourceFile));
		}
		else
		{
			OriginalCredits = true;
		}
		if (uPteoYPAv != null)
		{
			Debug.Log(">> Success loading extra bundle assets. <<");
		}
		else
		{
			Debug.Log(">> There was an error loading extra bundle assets. <<");
			OriginalCredits = true;
		}
		if (OriginalCredits)
		{
			baseCredits.enabled = true;
			JSON.enabled = true;
			base.enabled = false;
			DefaultValues();
		}
		else
		{
			Swpjp1dOd = uPteoYPAv.LoadAsset<GameObject>("CreditsLabelSmall");
			Bc812gqOh = uPteoYPAv.LoadAsset<GameObject>("CreditsLabelBig");
			uPteoYPAv.Unload(unloadAllLoadedObjects: false);
		}
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002FC4 File Offset: 0x000011C4
	public void DefaultValues()
	{
		ID = 0;
		SpeedUpFactor = 0.5f;
		MusicTimer = 0f;
		TimerLimit = 0f;
		FadeTimer = 0f;
		Timer = 0f;
		Speed = 1f;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x0000301C File Offset: 0x0000121C
	private void Update()
	{
		if (!UpdateCreditsFirstTime)
		{
			CQMbpTg7c();
		}
		MusicTimer += Time.deltaTime;
		if (!Begin)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				Begin = true;
				Jukebox.Play();
				Timer = 0f;
				SpawnCredit();
			}
		}
		else
		{
			if (!ShouldStopCredits)
			{
				Timer += Time.deltaTime * Speed;
				if (Timer >= TimerLimit)
				{
					SpawnCredit();
					Timer -= TimerLimit;
				}
			}
			if (Input.GetButtonDown("X") || MusicTimer >= Jukebox.clip.length)
			{
				FadeOut = true;
			}
		}
		if (FadeOut)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			Jukebox.volume -= Time.deltaTime;
			if (Darkness.color.a == 1f)
			{
				if (GameGlobals.TransitionToPostCredits)
				{
					SceneManager.LoadScene("PostCreditsScene");
				}
				else if (GameGlobals.TrueEnding)
				{
					SceneManager.LoadScene("TrueEndingScene");
				}
				else
				{
					SceneManager.LoadScene("NewTitleScene");
				}
			}
		}
		bool keyDown = Input.GetKeyDown(KeyCode.Minus);
		bool keyDown2 = Input.GetKeyDown(KeyCode.Equals);
		if (keyDown)
		{
			Time.timeScale -= 1f;
		}
		else if (keyDown2)
		{
			Time.timeScale += 1f;
		}
		if (keyDown || keyDown2)
		{
			Jukebox.pitch = Time.timeScale;
		}
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00003220 File Offset: 0x00001420
	public void SpawnCredit()
	{
		ExtraCreditJson extraCreditJson = JSON.GetComponent<ExtraJsonScript>().Credits[ID];
		GameObject gameObject = Sv73uUfN9(extraCreditJson.Size);
		TimerLimit = (float)extraCreditJson.Size * SpeedUpFactor;
		gameObject.transform.parent = Panel;
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.GetComponent<UILabel>().text = extraCreditJson.Name;
		if (Eighties)
		{
			gameObject.GetComponent<UILabel>().color = new Color(0.8235294f, 0.6431373f, 1f, 1f);
		}
		else if (Dark)
		{
			gameObject.GetComponent<UILabel>().color = new Color(0.5f, 0f, 0f, 1f);
		}
		ID++;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00003310 File Offset: 0x00001510
	private void CQMbpTg7c()
	{
		kCQgmurFe = JSON.GetComponent<ExtraJsonScript>();
		for (int i = 0; i < kCQgmurFe.credits.Length; i++)
		{
			if (kCQgmurFe.credits[i].name == "Lead Programmer")
			{
				kCQgmurFe.credits[i].name = "Extra Students Project";
			}
			if (kCQgmurFe.credits[i].name == "YandereDev")
			{
				kCQgmurFe.credits[i].name = "N3xuS";
			}
		}
		UpdateCreditsFirstTime = true;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000022E1 File Offset: 0x000004E1
	public ExtraCreditsScript()
	{
		UselessCall.Noop();
		Speed = 1f;
		ResourcesDirectory = "/ExtraStudents/Resources/";
		ResourceFile = "ExtraStudentsAssets.N3xuSAPI";
	}

	// Token: 0x04000004 RID: 4
	[SerializeField]
	private CreditsScript baseCredits;

	// Token: 0x04000005 RID: 5
	[SerializeField]
	private JsonScript JSON;

	// Token: 0x04000006 RID: 6
	[SerializeField]
	private ExtraJsonScript kCQgmurFe;

	// Token: 0x04000007 RID: 7
	[SerializeField]
	private Transform SpawnPoint;

	// Token: 0x04000008 RID: 8
	[SerializeField]
	private Transform Panel;

	// Token: 0x04000009 RID: 9
	[SerializeField]
	private GameObject Swpjp1dOd;

	// Token: 0x0400000A RID: 10
	[SerializeField]
	private GameObject Bc812gqOh;

	// Token: 0x0400000C RID: 12
	[SerializeField]
	private UILabel SkipLabel;

	// Token: 0x0400000D RID: 13
	[SerializeField]
	private UISprite Darkness;

	// Token: 0x0400000E RID: 14
	[SerializeField]
	private int ID;

	// Token: 0x0400000F RID: 15
	public float SpeedUpFactor;

	// Token: 0x04000010 RID: 16
	public float MusicTimer;

	// Token: 0x04000011 RID: 17
	public float TimerLimit;

	// Token: 0x04000012 RID: 18
	public float FadeTimer;

	// Token: 0x04000013 RID: 19
	public float Speed;

	// Token: 0x04000014 RID: 20
	public float Timer;

	// Token: 0x04000015 RID: 21
	public bool Eighties;

	// Token: 0x04000016 RID: 22
	public bool FadeOut;

	// Token: 0x04000017 RID: 23
	public bool Begin;

	// Token: 0x04000018 RID: 24
	public bool Dark;

	// Token: 0x04000019 RID: 25
	public bool OriginalCredits;

	// Token: 0x0400001A RID: 26
	public bool UpdateCreditsFirstTime;

	// Token: 0x0400001B RID: 27
	public bool[] LabelValid;

	// Token: 0x0400001C RID: 28
	public AudioClip EightiesCreditsMusic;

	// Token: 0x0400001D RID: 29
	public AudioClip DarkCreditsMusic;

	// Token: 0x0400001E RID: 30
	public AudioSource Jukebox;

	// Token: 0x0400001F RID: 31
	public ParticleSystem Blossoms;

	// Token: 0x04000020 RID: 32
	[SerializeField]
	private AssetBundle uPteoYPAv;

	// Token: 0x04000021 RID: 33
	private string ResourcesDirectory;

	// Token: 0x04000022 RID: 34
	private string ResourceFile;

	// Token: 0x04000023 RID: 35
	public int CreditsSize;
}

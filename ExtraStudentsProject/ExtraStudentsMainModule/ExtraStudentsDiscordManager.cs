using System.Collections;
using System.Collections.Generic;
using Discord;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExtraStudentsProject.ExtraStudentsMainModule
{
	// Token: 0x02000027 RID: 39
	public class ExtraStudentsDiscordManager : MonoBehaviour
	{
		// Token: 0x060000F1 RID: 241 RVA: 0x0002810C File Offset: 0x0002630C
		private void Start()
		{
			Object.DontDestroyOnLoad(base.gameObject);
			if (_applicationID != string.Empty)
			{
				_discord = new global::Discord.Discord(long.Parse(_applicationID), 1UL);
				UpdateActivity();
			}
			else
			{
				Debug.Log("An error has occurred. You probably didn't set the Application ID.");
			}
			StartCoroutine(RichPresenceUpdate());
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00002816 File Offset: 0x00000A16
		private void Update()
		{
			if (_discord != null)
			{
				_discord.RunCallbacks();
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00028174 File Offset: 0x00026374
		private void UpdateRichPresenceInfo()
		{
			if (SceneManager.GetActiveScene().name == "SchoolScene" && _clockScript == null)
			{
				_clockScript = Object.FindObjectOfType<ClockScript>();
			}
			UpdateActivity();
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000281BC File Offset: 0x000263BC
		private void UpdateActivity()
		{
			_currentScene = SceneManager.GetActiveScene().name;
			_activity = _discord.GetActivityManager();
			Activity activity = default(Activity);
			activity.Assets.LargeImage = _boxArtImage;
			activity.Assets.LargeText = _boxArtText;
			activity.Details = _details;
			activity.State = GetSceneDescription();
			Activity activity2 = activity;
			_activity.UpdateActivity(activity2, delegate(Result RichPresenceResult)
			{
				if (RichPresenceResult != 0)
				{
					Debug.Log("Error! Connection Error (" + RichPresenceResult.ToString() + ")");
				}
			});
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00028260 File Offset: 0x00026460
		private string GetSceneDescription()
		{
			UpdateSceneDescription();
			string currentScene = _currentScene;
			if (currentScene != null && currentScene == "SchoolScene")
			{
				string text = (MissionModeGlobals.MissionMode ? ", Mission Mode" : string.Empty);
				return string.Format("{0}, {1}, {2}, {3}{4}", _sceneDescription["SchoolScene"], _clockScript.TimeLabel.text, _gamePeriod[_clockScript.Period], _gameWeekday[_clockScript.Weekday], text);
			}
			if (_sceneDescription.ContainsKey(_currentScene))
			{
				return _sceneDescription[_currentScene];
			}
			return "No description available yet.";
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0002833C File Offset: 0x0002653C
		private void UpdateSceneDescription()
		{
			if (!_createdDictionary)
			{
				_sceneDescription.Add("ResolutionScene", "Setting the resolution!");
				_sceneDescription.Add("WelcomeScene", "Launching the game!");
				_sceneDescription.Add("SponsorScene", "Checking out the sponsors!");
				_sceneDescription.Add("NewTitleScene", "At the title screen!");
				_sceneDescription.Add("SenpaiScene", "Customizing Senpai!");
				_sceneDescription.Add("IntroScene", "Watching the Intro!");
				_sceneDescription.Add("NewIntroScene", "Watching the Intro!");
				_sceneDescription.Add("PhoneScene", "Texting with Info-Chan!");
				_sceneDescription.Add("CalendarScene", "Checking out the Calendar!");
				_sceneDescription.Add("HomeScene", "Chilling at home!");
				_sceneDescription.Add("LoadingScene", "Now Loading!");
				_sceneDescription.Add("SchoolScene", "At School");
				_sceneDescription.Add("YanvaniaTitleScene", "Beginning Yanvania: Senpai of the Night!");
				_sceneDescription.Add("YanvaniaScene", "Playing Yanvania: Senpai of the Night!");
				_sceneDescription.Add("LivingRoomScene", "Preparing to befriend or betray  Osana!");
				_sceneDescription.Add("MissionModeScene", "Accepting a mission!");
				_sceneDescription.Add("VeryFunScene", "??????????");
				_sceneDescription.Add("CreditsScene", "Viewing the credits!");
				_sceneDescription.Add("MiyukiTitleScene", "Beginning Magical Girl Pretty Miyuki!");
				_sceneDescription.Add("MiyukiGameplayScene", "Playing Magical Girl Pretty Miyuki!");
				_sceneDescription.Add("MiyukiThanksScene", "Finishing Magical Girl Pretty Miyuki!");
				_sceneDescription.Add("RhythmMinigameScene", "Jamming out with the Light Music Club!");
				_sceneDescription.Add("LifeNoteScene", "Watching an episode of Life Note!");
				_sceneDescription.Add("YancordScene", "Chatting over Yancord!");
				_sceneDescription.Add("MaidMenuScene", "Getting ready to be cute at a maid cafe!");
				_sceneDescription.Add("MaidGameScene", "Being a cute maid! MOE MOE KYUN!");
				_sceneDescription.Add("StreetScene", "Chilling in town!");
				_sceneDescription.Add("BusStopScene", "Watching Senpai meet Amai!");
				_sceneDescription.Add("PostCreditsScene", "Eavesdropping on the headmaster!");
				_sceneDescription.Add("DiscordScene", "Awaiting Verification");
				_sceneDescription.Add("OsanaJokeScene", "Killing Osana at long last!");
				_sceneDescription.Add("ThanksForPlayingScene", "Just beat the Osana demo!");
				_sceneDescription.Add("StalkerHouseScene", "Sneaking through a stalker's house!");
				_sceneDescription.Add("GenocideScene", "Successfully committed genocide!");
				_sceneDescription.Add("RivalRejectionProgressScene", "Making Senpai reject a confession!");
				_sceneDescription.Add("EightiesCutsceneScene", "Listening to Ryoba talk!");
				_sceneDescription.Add("CourtroomScene", "Awaiting the judge's verdict!");
				_sceneDescription.Add("TrueEndingScene", "Witnessing the true ending!");
				_sceneDescription.Add("AsylumScene", "Sneaking through a spooky asylum!");
				_sceneDescription.Add("AbductionScene", "Watching an abduction take place!");
				_sceneDescription.Add("WeekSelectScene", "Deciding what week to skip to!");
				_gameWeekday.Add(0, " Monday");
				_gameWeekday.Add(1, "Monday");
				_gameWeekday.Add(2, "Tuesday");
				_gameWeekday.Add(3, "Wednesday");
				_gameWeekday.Add(4, "Thursday");
				_gameWeekday.Add(5, "Friday");
				_gamePeriod.Add(0, " Before Class");
				_gamePeriod.Add(1, "Before Class");
				_gamePeriod.Add(2, "Class Time");
				_gamePeriod.Add(3, "Lunch Time");
				_gamePeriod.Add(4, "Class Time");
				_gamePeriod.Add(5, "Cleaning Time");
				_gamePeriod.Add(6, "After School");
				_createdDictionary = true;
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000282B File Offset: 0x00000A2B
		private IEnumerator RichPresenceUpdate()
		{
			while (_updateRichPresence)
			{
				yield return new WaitForSeconds(_updateRate);
				UpdateRichPresenceInfo();
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000283A File Offset: 0x00000A3A
		private void OnDisable()
		{
			if (_discord != null)
			{
				_discord.Dispose();
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00028798 File Offset: 0x00026998
		public ExtraStudentsDiscordManager()
		{
			UselessCall.Noop();
			_applicationID = "943256951662465074";
			_boxArtImage = "extrastudentsproject";
			_boxArtText = "New Students!";
			_details = "with Extra Students Project!";
			_updateRate = 5f;
			_updateRichPresence = true;
			_sceneDescription = new Dictionary<string, string>();
			_gamePeriod = new Dictionary<int, string>();
			_gameWeekday = new Dictionary<int, string>();
		}

		// Token: 0x0400011A RID: 282
		private global::Discord.Discord _discord;

		// Token: 0x0400011B RID: 283
		private ActivityManager _activity;

		// Token: 0x0400011C RID: 284
		private ClockScript _clockScript;

		// Token: 0x0400011D RID: 285
		[SerializeField]
		private string _applicationID;

		// Token: 0x0400011E RID: 286
		[SerializeField]
		private string _boxArtImage;

		// Token: 0x0400011F RID: 287
		[SerializeField]
		private string _boxArtText;

		// Token: 0x04000120 RID: 288
		[SerializeField]
		private string _details;

		// Token: 0x04000121 RID: 289
		private string _currentScene;

		// Token: 0x04000122 RID: 290
		[SerializeField]
		private float _updateRate;

		// Token: 0x04000123 RID: 291
		[SerializeField]
		private bool _createdDictionary;

		// Token: 0x04000124 RID: 292
		[SerializeField]
		private bool _updateRichPresence;

		// Token: 0x04000125 RID: 293
		[SerializeField]
		private Dictionary<string, string> _sceneDescription;

		// Token: 0x04000126 RID: 294
		[SerializeField]
		private Dictionary<int, string> _gamePeriod;

		// Token: 0x04000127 RID: 295
		[SerializeField]
		private Dictionary<int, string> _gameWeekday;
	}
}

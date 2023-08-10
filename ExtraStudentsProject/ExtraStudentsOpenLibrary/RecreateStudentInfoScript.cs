using UnityEngine;

namespace ExtraStudentsProject.ExtraStudentsOpenLibrary
{
	// Token: 0x02000021 RID: 33
	public class RecreateStudentInfoScript : MonoBehaviour
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x00022848 File Offset: 0x00020A48
		private void Start()
		{
			PauseScreen = GameObject.Find("PauseScreen").GetComponent<PauseScreenScript>();
			StudentInfoMenu = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().StudentInfoMenu;
			StudentManager = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().StudentManager;
			DialogueWheel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().DialogueWheel;
			NoteLocker = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().NoteLocker;
			ReputationChart = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().ReputationChart;
			PromptBar = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().PromptBar;
			Shutter = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().Shutter;
			Yandere = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().Yandere;
			JSON = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().JSON;
			Counselor = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().GuidanceCounselor;
			DefaultPortrait = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().DefaultPortrait;
			BlankPortrait = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().BlankPortrait;
			Headmaster = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().Headmaster;
			InfoChan = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().InfoChan;
			ReputationBar = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().ReputationBar;
			Static = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().Static;
			Topics = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().Topics;
			OccupationLabel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().OccupationLabel;
			ReputationLabel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().ReputationLabel;
			RealNameLabel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().RealNameLabel;
			StrengthLabel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().StrengthLabel;
			PersonaLabel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().PersonaLabel;
			ClassLabel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().ClassLabel;
			CrushLabel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().CrushLabel;
			ClubLabel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().ClubLabel;
			InfoLabel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().InfoLabel;
			NameLabel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().NameLabel;
			Portrait = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().Portrait;
			OpinionSpriteNames = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().OpinionSpriteNames;
			Strings = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().Strings;
			TopicIcons = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().TopicIcons;
			TopicOpinionIcons = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().TopicOpinionIcons;
			LeftCrushLabel = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>().LeftCrushLabel;
			TopicInterface = DialogueWheel.TopicInterface.gameObject;
			NegativeRemark = DialogueWheel.TopicInterface.NegativeRemark;
			PositiveRemark = DialogueWheel.TopicInterface.PositiveRemark;
			EmbarassingSecret = DialogueWheel.TopicInterface.EmbarassingSecret;
			TopicHighlight = DialogueWheel.TopicInterface.TopicHighlight;
			OpinionIcons = DialogueWheel.TopicInterface.OpinionIcons;
			EmbarassingLabel = DialogueWheel.TopicInterface.EmbarassingLabel;
			Label = DialogueWheel.TopicInterface.Label;
			TopicOpinionSpriteNames = DialogueWheel.TopicInterface.OpinionSpriteNames;
			TopicNames = DialogueWheel.TopicInterface.TopicNames;
			Object.Destroy(PauseScreen.StudentInfo.GetComponent<StudentInfoScript>());
			Object.Destroy(DialogueWheel.TopicInterface);
			PauseScreen.StudentInfo.AddComponent<StudentInfoScript>();
			TopicInterface.AddComponent<TopicInterfaceScript>();
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00022D04 File Offset: 0x00020F04
		private void Update()
		{
			if (Phase >= 3)
			{
				return;
			}
			if (Phase >= 1)
			{
				if (StudentInfo == null)
				{
					StudentInfo = PauseScreen.StudentInfo.GetComponent<StudentInfoScript>();
				}
				else
				{
					CopyStudentInfo();
				}
				if (baseTopicInterface == null)
				{
					baseTopicInterface = TopicInterface.GetComponent<TopicInterfaceScript>();
				}
				else
				{
					ResetTopicInterface();
				}
			}
			Phase++;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00022D84 File Offset: 0x00020F84
		private void CopyStudentInfo()
		{
			StudentInfo.StudentInfoMenu = StudentInfoMenu;
			StudentInfo.StudentManager = StudentManager;
			StudentInfo.DialogueWheel = DialogueWheel;
			StudentInfo.NoteLocker = NoteLocker;
			StudentInfo.ReputationChart = ReputationChart;
			StudentInfo.PromptBar = PromptBar;
			StudentInfo.Shutter = Shutter;
			StudentInfo.Yandere = Yandere;
			StudentInfo.JSON = JSON;
			StudentInfo.GuidanceCounselor = Counselor;
			StudentInfo.DefaultPortrait = DefaultPortrait;
			StudentInfo.BlankPortrait = BlankPortrait;
			StudentInfo.Headmaster = Headmaster;
			StudentInfo.InfoChan = InfoChan;
			StudentInfo.ReputationBar = ReputationBar;
			StudentInfo.Static = Static;
			StudentInfo.Topics = Topics;
			StudentInfo.OccupationLabel = OccupationLabel;
			StudentInfo.ReputationLabel = ReputationLabel;
			StudentInfo.RealNameLabel = RealNameLabel;
			StudentInfo.StrengthLabel = StrengthLabel;
			StudentInfo.PersonaLabel = PersonaLabel;
			StudentInfo.ClassLabel = ClassLabel;
			StudentInfo.CrushLabel = CrushLabel;
			StudentInfo.ClubLabel = ClubLabel;
			StudentInfo.InfoLabel = InfoLabel;
			StudentInfo.NameLabel = NameLabel;
			StudentInfo.Portrait = Portrait;
			StudentInfo.OpinionSpriteNames = OpinionSpriteNames;
			StudentInfo.Strings = Strings;
			StudentInfo.TopicIcons = TopicIcons;
			StudentInfo.TopicOpinionIcons = TopicOpinionIcons;
			StudentInfo.LeftCrushLabel = LeftCrushLabel;
			Shutter.StudentInfo = StudentInfo;
			Shutter.StudentInfo.StudentInfoMenu.StudentInfo = StudentInfo;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00022FF0 File Offset: 0x000211F0
		private void ResetTopicInterface()
		{
			baseTopicInterface.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
			baseTopicInterface.InputManager = GameObject.Find("MainCamera").GetComponent<InputManagerScript>();
			baseTopicInterface.Yandere = StudentManager.Yandere;
			baseTopicInterface.JSON = JSON;
			baseTopicInterface.NegativeRemark = NegativeRemark;
			baseTopicInterface.PositiveRemark = PositiveRemark;
			baseTopicInterface.EmbarassingSecret = EmbarassingSecret;
			baseTopicInterface.TopicHighlight = TopicHighlight;
			baseTopicInterface.OpinionIcons = OpinionIcons;
			baseTopicInterface.EmbarassingLabel = EmbarassingLabel;
			baseTopicInterface.Label = Label;
			baseTopicInterface.TopicSelected = 1;
			baseTopicInterface.Opinion = 0;
			baseTopicInterface.Column = 1;
			baseTopicInterface.Row = 1;
			baseTopicInterface.Socializing = true;
			baseTopicInterface.Positive = true;
			baseTopicInterface.OpinionSpriteNames = TopicOpinionSpriteNames;
			baseTopicInterface.TopicNames = TopicNames;
			baseTopicInterface.LoveHate = "love";
			DialogueWheel.TopicInterface = baseTopicInterface;
		}

		// Token: 0x040000DA RID: 218
		public PauseScreenScript PauseScreen;

		// Token: 0x040000DB RID: 219
		public StudentInfoScript StudentInfo;

		// Token: 0x040000DC RID: 220
		public StudentInfoMenuScript StudentInfoMenu;

		// Token: 0x040000DD RID: 221
		public StudentManagerScript StudentManager;

		// Token: 0x040000DE RID: 222
		public DialogueWheelScript DialogueWheel;

		// Token: 0x040000DF RID: 223
		public NoteLockerScript NoteLocker;

		// Token: 0x040000E0 RID: 224
		public RadarChart ReputationChart;

		// Token: 0x040000E1 RID: 225
		public PromptBarScript PromptBar;

		// Token: 0x040000E2 RID: 226
		public ShutterScript Shutter;

		// Token: 0x040000E3 RID: 227
		public YandereScript Yandere;

		// Token: 0x040000E4 RID: 228
		public JsonScript JSON;

		// Token: 0x040000E5 RID: 229
		public Texture Counselor;

		// Token: 0x040000E6 RID: 230
		public Texture DefaultPortrait;

		// Token: 0x040000E7 RID: 231
		public Texture BlankPortrait;

		// Token: 0x040000E8 RID: 232
		public Texture Headmaster;

		// Token: 0x040000E9 RID: 233
		public Texture InfoChan;

		// Token: 0x040000EA RID: 234
		public Transform ReputationBar;

		// Token: 0x040000EB RID: 235
		public GameObject Static;

		// Token: 0x040000EC RID: 236
		public GameObject Topics;

		// Token: 0x040000ED RID: 237
		public UILabel OccupationLabel;

		// Token: 0x040000EE RID: 238
		public UILabel ReputationLabel;

		// Token: 0x040000EF RID: 239
		public UILabel RealNameLabel;

		// Token: 0x040000F0 RID: 240
		public UILabel StrengthLabel;

		// Token: 0x040000F1 RID: 241
		public UILabel PersonaLabel;

		// Token: 0x040000F2 RID: 242
		public UILabel ClassLabel;

		// Token: 0x040000F3 RID: 243
		public UILabel CrushLabel;

		// Token: 0x040000F4 RID: 244
		public UILabel ClubLabel;

		// Token: 0x040000F5 RID: 245
		public UILabel InfoLabel;

		// Token: 0x040000F6 RID: 246
		public UILabel NameLabel;

		// Token: 0x040000F7 RID: 247
		public UITexture Portrait;

		// Token: 0x040000F8 RID: 248
		public string[] OpinionSpriteNames;

		// Token: 0x040000F9 RID: 249
		public string[] Strings;

		// Token: 0x040000FA RID: 250
		public UISprite[] TopicIcons;

		// Token: 0x040000FB RID: 251
		public UISprite[] TopicOpinionIcons;

		// Token: 0x040000FC RID: 252
		public UILabel LeftCrushLabel;

		// Token: 0x040000FD RID: 253
		[SerializeField]
		private int Phase;

		// Token: 0x040000FF RID: 255
		[SerializeField]
		private GameObject TopicInterface;

		// Token: 0x04000100 RID: 256
		[SerializeField]
		private TopicInterfaceScript baseTopicInterface;

		// Token: 0x04000101 RID: 257
		[SerializeField]
		private GameObject NegativeRemark;

		// Token: 0x04000102 RID: 258
		[SerializeField]
		private GameObject PositiveRemark;

		// Token: 0x04000103 RID: 259
		[SerializeField]
		private GameObject EmbarassingSecret;

		// Token: 0x04000104 RID: 260
		[SerializeField]
		private Transform TopicHighlight;

		// Token: 0x04000105 RID: 261
		[SerializeField]
		private UISprite[] OpinionIcons;

		// Token: 0x04000106 RID: 262
		[SerializeField]
		private UILabel EmbarassingLabel;

		// Token: 0x04000107 RID: 263
		[SerializeField]
		private UILabel Label;

		// Token: 0x04000108 RID: 264
		[SerializeField]
		private string[] TopicOpinionSpriteNames;

		// Token: 0x04000109 RID: 265
		[SerializeField]
		private string[] TopicNames;
	}
}

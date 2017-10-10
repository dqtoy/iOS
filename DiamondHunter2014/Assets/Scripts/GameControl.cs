using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Initialize();
	}
	
	public GameStyle Style
	{
		get {return Misc.Style;}
	}
	
	public GameMode Mode 
	{ 
		get {return Misc.Mode;}
		set {Misc.Mode = value;}
	}
		

	public static int? StartingLevel;
	
	void Initialize()
	{
		Entities = new List<GameObject>();
		TouchedEntities = new List<DiamondControl>();
		Bursts = new List<GameObject>();
		LoadEntities();
		Level = StartingLevel ?? 1;
		StartingGameTime = Style == GameStyle.Full ? 45 : 45;
		Misc.PauseTime = 0;
		extraIncrease = 0;
		Score = 0;
		loadTestData = false;
		Misc.GamePaused = false;
		Misc.Reset();
		DiamondControl.InitSpeed();
		InitLevelScores();
		if (!Misc.ModeSet)
			Mode = GameMode.Arcade;
		
		if (Mode ==GameMode.Arcade)
		{
			DiamondControl.Speed = 1.5f;
			DiamondControl.DeltaSpeedIncrease = 0.1f;
			DiamondControl.ShiftMultiplerSpeed = 15;
		}
		OptionsButton = GameObject.Find("Options").guiTexture;
		MuteButton = GameObject.Find("Mute").guiTexture;
		TitleButton = GameObject.Find("Title").guiTexture;
		RestartButton = GameObject.Find("Restart").guiTexture;
		NextButton = GameObject.Find("Next").guiTexture;
		MuteButton.enabled = TitleButton.enabled = RestartButton.enabled = NextButton.enabled = false;
		
		if (Misc.Mode == GameMode.Puzzle)
			CreatePuzzleDiamonds(Level);
		//AdBinding.createAdBanner (true);
	}
	
	
	public static int Score, Addition;
	public static int Level;
	public static float GameTime { get 
		{
			if (Misc.Instance.TutorialMode) return extraIncrease;
			return StartingGameTime - Misc.TimeInLevel + extraIncrease;
		}
	}
	static float extraIncrease;
	int StartingScore = 10;
	static float StartingGameTime = 3, timeIncrease = 0.1f;
	System.Random Rand = new System.Random();
	List<GameObject> Entities;
	public static List<DiamondControl> TouchedEntities;
	List<GameObject> Bursts;
	void LoadEntities()
	{
		int max = Mode == GameMode.Puzzle || Misc.Instance.TutorialMode ? 9 : 4;
		for (int i=0; i<=max; ++i)
		{
			Entities.Add((GameObject)Resources.Load(i.ToString()));
		}
		Bursts.Add((GameObject)Resources.Load("burst"));
		Bursts.Add((GameObject)Resources.Load("burst2"));
	}
	
	void Update()
	{
		processTouch();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Misc.Mode == GameMode.Arcade && !Misc.Instance.TutorialMode)
			CreateDiamonds();
		ProcessAfterShiftingMatches();
		ProcessEvents();
		ProcessCameraShake();
		ProcessDebug();
	}
	
	void ProcessDebug()
	{
		var sb = new System.Text.StringBuilder();
		for (int i=0; i<DiamondList.Count; ++i)
		{
			for (int j=0; j<DiamondList[i].Count; ++j)
				sb.Append(DiamondList[i][j] != null ? DiamondList[i][j].name.Replace("(Clone)", "") : "x");
			sb.Append("\n");
		}
		sb.Append("\n       \n        \n        \n        ");
		//TextManager.DebugText(sb.ToString());
	}
	
	public float CameraShakeTime = 0.5f;
	float CameraShakeStartTime;
	bool _cameraShake;
	Vector3 cameraShakePosition;
	bool CameraShake 
	{
		get {return _cameraShake;}
		set 
		{
			var prev = _cameraShake;
			_cameraShake = value;
			if (value && !prev)
			{
				CameraShakeStartTime = Misc.TimeInLevel;
				cameraShakePosition = Camera.main.transform.position;
			}
		}
	}
	

	void ProcessCameraShake()
	{
		if (CameraShake)
		{
			if (Time.timeSinceLevelLoad - CameraShakeStartTime < CameraShakeTime)
				Camera.main.transform.position +=  UnityEngine.Random.insideUnitSphere * 0.05f;
			else
			{
				CameraShake = false;
				Camera.main.transform.position = cameraShakePosition;
			}
		}
	}
	
	bool GameOver = false;
	bool PuzzleDone = false, FailedPuzzle;
	int tutorialId = 0;
	bool tutorialDiamondsCreated;
	public static string TutorialText;
	
	void ProcessTutorial()
	{
		NextButton.enabled = true;
		int checkId = 0;
		if (tutorialId == 0)
		{
			TutorialText = "Welcome to Bespangled!";
		}
		else if (tutorialId == 1)
		{
			TutorialText = "The object of the game is to clear\nas many diamonds onscreen as possible";
		}
		else if (tutorialId == 2)
		{
			TutorialText = "Find similar diamonds and touch \nat least 3 of them to create a match.\nMatching them will make them disappear. ";
		}
		else if (tutorialId == 3)
		{
			TutorialText = "Let's give it a try!\nMatch all the following diamonds";
		}
		else if (tutorialId == 4)
		{
			if (!tutorialDiamondsCreated)
			{
				CreatePuzzleDiamonds(1);
				tutorialDiamondsCreated = true;
			}
		}
		else if (tutorialId == 5)
		{
			ClearExistingPuzzle();
			TutorialText = "The more you match, \nthe higher score you will receive.\nAnd the time will increase\ngiving you more play time!";
		}
		else if (tutorialId == 6)
		{
			TutorialText = "Upon matching diamonds,\nall diamonds above the matched ones\nwill shift downward.";
		}
		else if (tutorialId == 7)
		{
			TutorialText = "If the shifted diamonds \nmake 4 or more matches\nthey will also disappear, \nproviding huge scores!";
		}
		else if (tutorialId == 8)
		{
			TutorialText = "Let's give it a try!\nMatch all the following diamonds \non the bottom to shift \nthe upper diamonds down.";
		}
		else if (tutorialId == 9)
		{
			if (!tutorialDiamondsCreated)
			{
				CreatePuzzleDiamonds(2);
				tutorialDiamondsCreated = true;
			}
		}
		else if (tutorialId == 10)
		{
			TutorialText = "Matching diamonds on the right side\nwill make diamonds on the left\nshift down.";
		}
		else if (tutorialId == 11)
		{
			TutorialText = "And matching diamonds on the left side\nwill make diamonds on the right\nshift down.";
		}
		else if (tutorialId == 12)
		{
			TutorialText = "Keep this in mind so matching\ncan be strategically done\nto yield lots of points.";
		}
		else if (tutorialId == 13)
		{
			TutorialText = "Let's see the shifting process\nwith more diamonds.";
		}
		else if (tutorialId == 14)
		{
			TutorialText = "Matching the bottom diamonds.";
			if (!tutorialDiamondsCreated)
			{
				CreatePuzzleDiamonds(3);
				tutorialDiamondsCreated = true;
			}
		}
		else if (tutorialId == 15)
		{
			TutorialText = "Those are the rules.\nNow enjoy!";
		}
		else
		{
			//ClearExistingPuzzle();
			TutorialText = null;
			Misc.Instance.TutorialMode = false;
			extraIncrease = 10000;
			doNotLoadDiamonds = true;
			AutoFade.LoadLevel("Game");
		}
	}
	
	bool gameOverSet;
	void ProcessEvents()
	{
		if (Misc.Instance.TutorialMode)
		{
			ProcessTutorial();
		}
		else if (Mode == GameMode.Arcade)
		{
			if (GameTime < 0 && !gameOverSet)
			{
				MusicPlayer.PlaySound(SoundType.GameOver);
				Misc.GamePaused = true;
				PuzzleGameOverObject = (GameObject)Instantiate(Resources.Load("type_gameOver"));
				GameOver = true;
				this.TitleButton.enabled = true;// RestartButton.enabled = true;
				this.OptionsButton.enabled = false;
				gameOverSet = true;
			}
			if (Score > LevelScores[Level-1])	
			{
				LevellingUp();
			}
		}
		else 
		{
			var sql = from dc in PuzzleDiamonds
				group dc by dc.name into n
					select new {Name = name, Count = n.Count()};
			
			if (!PuzzleDone && ((sql.Any(i=>i.Count < 3)  || Misc.PuzzleMoveCount >= Misc.MaximumMoveCount )
			         && lastShiftActivity > 0
			         && lastShiftActivity + 1 < Misc.TimeInLevel
			         && DiamondList.Any(l=>l.Any(d=>d != null 
			                                     ))))
			{
				foreach (var o in TouchedEntities)
					o.Touched();
				TouchedEntities.Clear();
				//PuzzleGameOverObject = (GameObject)Instantiate(Resources.Load("type_gameOver"));
				PuzzleDone = true;
				RestartButton.enabled = true;
				FailedPuzzle = true;
			}
			else if (!PuzzleDone && !DiamondList.Any(l=>l.Any(d=>d != null))) 	// no more diamonds
			{
				if (chainCount < 3)
					ProcessMessages(Rand.Next(3, 9));
				PuzzleDone = true;
				NextButton.enabled = true;
				RestartButton.enabled = true;
				FailedPuzzle = false;				
				Misc.Instance.HighScore = Score;
				
			}
		}

	}
	
	GameObject PuzzleGameOverObject;
	
	bool levelUp= false;
	void LevellingUp()
	{
		++Level;
		LoadHappyMessage(EntityType.LevelUp);
		MusicPlayer.PlaySound(SoundType.LevelUp);
		levelUp = true;
		if (Level > Misc.Instance.HighLevel)
			Misc.Instance.HighLevel = Level;
		if (Level == 4)
			Entities.Add((GameObject)Resources.Load("5"));
		else if (Level == 5)
			Entities.Add((GameObject)Resources.Load("6"));
		else if (Level == 6)
			Entities.Add((GameObject)Resources.Load("7"));
		else if (Level == 7)
			Entities.Add((GameObject)Resources.Load("8"));
	}
	
	List<int> LevelScores;
	void InitLevelScores()
	{
		LevelScores = new List<int>();
		for (int i=1; i<200; ++i)
			LevelScores.Add(i*10000);
	}
	
	void OnGUI2()
	{
		if (GUI.Button( new Rect(Screen.width - 100, 10, 100, 50), "Clear"))
		{
			ClearTouched();
		}
	}
	
	bool touch, handTouch;
	void processTouch ()
	{
		//if (GameOver && (Input.touches.Count() > 0 || Input.GetMouseButtonDown(0))) AutoFade.LoadLevel("Title");
		if (shiftMatchingInProcess) return;
		var touchPosition = Vector3.zero;
		if (Input.touches.Count() >= 1)
		{
	    	touchPosition = Input.touches[0].position;
			touch = true;
			handTouch = true;
		}
		else if (handTouch)
		{
			touch = false;
			handTouch = false;
		}
		if (Input.GetMouseButtonDown(0))
		{
			touchPosition = Input.mousePosition;
			touch = true;
		}
		else if (Input.GetMouseButtonUp(0))
			touch = false;
		else if (touch)
			touchPosition = Input.mousePosition;
		if (!Misc.GamePaused)
		{
			if (touch && touchPosition != Vector3.zero)
			{
				if (Mode == GameMode.Puzzle && PuzzleDone )
				{
					;//MusicPlayer.PlaySound(SoundType.WrongMove);
				}
				else {
					var go = GetPointFromXY(touchPosition);
					if (go  != null && go.GetComponent<DiamondControl>() != null)
					{
						var dc = go.GetComponent<DiamondControl>();
						bool addNew = false;
						if (TouchedEntities.Count == 0) addNew = true;
						else if (!TouchedEntities.Contains(dc))
						{
							int i=0;
							for (i=0; i<TouchedEntities.Count; ++i)
							{
								if (TouchedEntities[i] != dc 
								    && dc.name == TouchedEntities[i].name 
								    && (1==2
								        //|| Mode == GameMode.Puzzle 
								        || Vector3.Distance(TouchedEntities[i].transform.position, dc.transform.position) < 2)
								    )
								    
									break;
							}
							addNew = i < TouchedEntities.Count;
						}
						if (addNew)
						{
							dc.Touched();
							TouchedEntities.Add(dc);
						}
					}
				}
			}
			if (!touch && TouchedEntities.Count > 0)
			{
				bool good = TouchedEntities.Count >= 3;// && AreTouchesAdjacent();
				if (!good)
					MusicPlayer.PlaySound(SoundType.WrongMove);
				else 
				{
					chainCount = 0;
					++Misc.PuzzleMoveCount;
				}
				ProcessMatches(good);
				
			}
		}
		ProcessButtons(touchPosition);
	}
	
	float buttonsTime=0;
	void ProcessButtons(Vector3 pos)
	{
		if (pos == Vector3.zero || Time.timeSinceLevelLoad < buttonsTime) return;
		bool restart = (Misc.GamePaused || PuzzleDone) && !GameOver && RestartButton.enabled && RestartButton.HitTest(pos);
		if (!GameOver && !FailedPuzzle && OptionsButton.HitTest(pos))
		{
			MusicPlayer.PlaySound(SoundType.Touches);
			if (!Misc.GamePaused)
			{
				Misc.GamePaused = MuteButton.enabled = TitleButton.enabled = true;// 
				if (Mode == GameMode.Puzzle)
					RestartButton.enabled = true;
			}
			else 
			{
				Misc.GamePaused = MuteButton.enabled = TitleButton.enabled = false;// RestartButton.enabled = false;
				if (Mode == GameMode.Puzzle)
					RestartButton.enabled = false;
			}
			buttonsTime = Time.timeSinceLevelLoad + 0.3f;
		}
		else if (Misc.GamePaused)
		{
			if (!GameOver && MuteButton.HitTest(pos))		
			{
				Misc.Instance.MusicMute = !Misc.Instance.MusicMute;
				MusicPlayer.PlaySound(SoundType.Touches);
				MusicPlayer.Instance.TogglePlay();
			}
			if (TitleButton.HitTest(pos))			
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				doNotLoadDiamonds = true;
				AutoFade.LoadLevel("Title");
			}
			if (false && Mode != GameMode.Puzzle && restart)			
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				//AutoFade.LoadLevel("Game");
				if (PuzzleGameOverObject != null )
					Destroy(PuzzleGameOverObject);
				Initialize();
				buttonsTime = Time.timeSinceLevelLoad + 0.3f;
				return;
			}
		}
		if (PuzzleDone || restart)
		{
			if (Misc.GamePaused) 
			{
				Misc.GamePaused = false;
				Misc.GamePaused = MuteButton.enabled = TitleButton.enabled = RestartButton.enabled = false;
			}
			if (NextButton.HitTest(pos) || restart)
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				PuzzleDone = false;
				if (!FailedPuzzle && !restart)
				{
					++Level;
				}
				Score = 0;
				Destroy(PuzzleGameOverObject);
				PuzzleGameOverObject = null;
				CreatePuzzleDiamonds(Level);
				FailedPuzzle = false;
				lastShiftActivity =0;
				NextButton.enabled = RestartButton.enabled =false;
				buttonsTime = Time.timeSinceLevelLoad + 0.3f;
			}
		}
		if (Misc.Instance.TutorialMode && NextButton.HitTest(pos))
		{
			tutorialId++;
			buttonsTime = Time.timeSinceLevelLoad + 0.3f;
			tutorialDiamondsCreated = false;
		}
	}

	
	GUITexture OptionsButton, MuteButton, TitleButton, RestartButton, NextButton;
	
	bool shiftMatchingInProcess;
	float shiftMatchingCountDown;
	int chainCount, prevChainCount;
	float lastShiftActivity;
	void ProcessAfterShiftingMatches()
	{
		if (!shiftMatchingInProcess && DiamondList.Any(l=>l.Any(o=>o != null && o.ProcessShifting)))
		{
			TouchedEntities.Clear();
			for (int i=0; i<DiamondList.Count; ++i)
				for (int j=0; j<DiamondList[i].Count; ++j)
					ProcessShiftMatches(i, j);
			foreach(var o in TouchedEntities)
				o.Touched();
			for (int i=0; i<DiamondList.Count; ++i)
			{
				for (int j=0; j<DiamondList[i].Count; ++j)
				{
					if (DiamondList[i][j] != null)
						DiamondList[i][j].ProcessShifting = DiamondList[i][j].ShiftMatched = false;
				}
			}
			if (TouchedEntities.Count > 0){
				shiftMatchingInProcess = true;
				shiftMatchingCountDown = Misc.TimeInLevel + ShiftMatchDelay;
			}

		}
		if (shiftMatchingInProcess && shiftMatchingCountDown < Misc.TimeInLevel)
		{
			ProcessMatches(true);					
			shiftMatchingInProcess = false;
			ProcessMessages(chainCount);
		}
	}
	
	float ShiftMatchDelay 
	{
		get {return Mode == GameMode.Arcade ? 0.5f : 0.75f;}
	}
	
	void ProcessMessages(int id)
	{
		if (id == 3) LoadHappyMessage(EntityType.Great);
		if (id == 4) LoadHappyMessage(EntityType.Hot);
		if (id == 5) LoadHappyMessage(EntityType.Incredible);
		if (id == 6) LoadHappyMessage(EntityType.Omg);
		if (id == 7) LoadHappyMessage(EntityType.Speechless);
		if (id == 8) LoadHappyMessage(EntityType.Stunning);
		if (id > 9) LoadHappyMessage(EntityType.Unbelievable);
		if (Mode == GameMode.Arcade)
			if (id >= 5) CameraShake = true;
	}
	
	void LoadHappyMessage(EntityType type)
	{
		var obj = (GameObject)Instantiate(PrefabCollection.Instance.Get(type));
		obj.AddComponent<MessageControl>();
	}
	
	void ProcessShiftMatches(int i, int j)
	{
		if (DiamondList[i][j] == null || !DiamondList[i][j].ProcessShifting) return;
		var chain = new List<DiamondControl>() ;
		ShiftMatchesCount(DiamondList[i][j].name, chain, i, j);
		if (chain.Count > 3) {
			TouchedEntities.AddRange(chain);
		}
		else 
		{
			foreach (var ch in chain)
				ch.ShiftMatched = false;
		}
	}
	
	void ShiftMatchesCount(string name, List<DiamondControl> chain, int i, int j)
	{
		if (!ValidIndices(i, j)
		    || DiamondList[i][j] == null || DiamondList[i][j].ShiftMatched ||  DiamondList[i][j].name != name) return;
		chain.Add(DiamondList[i][j]);
		DiamondList[i][j].ShiftMatched = true;
		if (i>0)	// go up one row
		{
			ShiftMatchesCount(name, chain, i-1, j+ (DiamondList[i].Type == RowType.Alternate ? 1 : -1));
			ShiftMatchesCount(name, chain, i-1, j);
		}
		if (i < DiamondList.Count - 1)
		{
			ShiftMatchesCount(name, chain, i+1, j+(DiamondList[i].Type == RowType.Alternate ? 1 : -1));
			ShiftMatchesCount(name, chain, i+1, j);
		}
		if (j>0)
			ShiftMatchesCount(name, chain, i, j-1);
		if (j<DiamondList[i].Count - 1)
			ShiftMatchesCount(name, chain, i, j+1);
		
	}
	
	void ProcessMatches(bool doIt)
	{
		if (doIt)
		{
			CleanUpDiamonds();
			ProcessShifting();
			int startScore = StartingScore;
			float time = timeIncrease;
			for (int s=3; s<TouchedEntities.Count; ++s)
			{
				startScore += s*StartingScore;
				time += s*timeIncrease;
			}
			Vector3 firstPosition = Vector3.zero;
			string id = "";
			foreach(var o in TouchedEntities.Where(o=>o != null).OrderBy(o=>o.TouchedTime))
			{
				if (firstPosition == Vector3.zero)
				{
					firstPosition = Camera.main.WorldToScreenPoint( o.transform.position);
					id = o.ID;
				}
				LoadBurst(o.transform.position);
				Destroy(o.gameObject, 0.1f);
				if (Mode == GameMode.Puzzle)
					PuzzleDiamonds.Remove(o);
			}
			TextManager.SetInfoText(id, startScore.ToString(), firstPosition);
			Score += startScore;
			if (Style == GameStyle.Full)
				extraIncrease += time;
			if (Score >= Misc.Instance.HighScore)
				Misc.Instance.HighScore = Score;
			if (TouchedEntities.Count > 7)
				MusicPlayer.PlaySound(SoundType.PowerUp2);
			else
				MusicPlayer.PlaySound(SoundType.PowerUp);
			++chainCount;
			lastShiftActivity = Misc.TimeInLevel;
		}
		foreach(var o in TouchedEntities)
			o.Touched();
		TouchedEntities.Clear();
	}
	
	void ProcessShifting()
	{
		Bias bias = CalculateBias();
		foreach(var list in DiamondList)
			foreach(var o in list)
				if (o != null) o.IsShifted = false;
		for(int i=DiamondList.Count - 1; i>0; --i)
		{
			var list = DiamondList[i];
			for (int j=0; j<list.Count; ++j)
			{
				if (list[j] != null && list[j].IsTouched && !list[j].IsShifted)
				{
					ShiftDiamond(list[j], i, j, bias);
				}
			}
		}
		NullDiamonds();
	}
	
	void NullDiamonds()
	{
		for(int i=DiamondList.Count - 1; i>0; --i)
		{
			var list = DiamondList[i];
			for (int j=0; j<list.Count; ++j)
			{
				for (int ii=i-1; ii>=0; --ii)
				{
					bool found = false;
					for (int jj=0; jj<DiamondList[ii].Count; ++jj)
					{
						if (DiamondList[ii][jj] == list[j])
						{
							DiamondList[ii][jj] = null;
							found = true;
							break;
						}
					}
					if (found) break;
				}
			}
		}
	}
	
	Bias CalculateBias()
	{
		//return Bias.Right;
		int left=0, right=0, halfWay = (int)numOfDiamonds / 2;
		for(int i=0; i<DiamondList.Count; ++i)
		{
			var list = DiamondList[i];
			for (int j=0; j<list.Count; ++j)
			{
				if (list[j] != null && list[j].IsTouched)
				{
					if (j<halfWay) ++right;
					else ++left;
				}
			}
		}
		return left <= right ? Bias.Left : Bias.Right;
	}
	
	void ShiftDiamond(DiamondControl o, int i, int j, Bias bias)
	{
		if (!ValidIndices(i,j) || o == null) return;
		int origI = i, origJ = j, startI = i, startJ = j;
		if (i==3 && j==0) 
			i+= 0;
		int prevI=0, prevJ=0;
		ShiftIJ(ref i, ref j, bias);
		DiamondControl obj = null;
		while (ValidIndices(i,j))
		{
			obj = DiamondList[i][j];
			DiamondControl dc = obj;
			if (obj != null && dc != null && !dc.IsTouched && !dc.IsShifted)
			{
				dc.Shift(o.transform.position);
				DiamondList[origI][origJ] = obj;
				if (origI >= 0 && origJ >= 0) 
				{
					ShiftIJ(ref origI, ref origJ, bias);
					o = DiamondList[origI][origJ];
					if (o == null) 
					{
						break;
					}
					
				}
			}
			if (dc != null && !dc.IsTouched && !dc.IsShifted)
				prevI = i; prevJ = j;
			ShiftIJ(ref i, ref j, bias);
		}
		
		//ShiftInverseIJ(ref prevI, ref prevJ, bias);
		//NullDiamond(startI, startJ, bias);
	}
	
	bool ValidIndices(int i, int j)
	{
		return i>=0 && j>=0 && i<DiamondList.Count && j<DiamondList[i].Count;
	}
	
	void NullDiamond(int i, int j, Bias bias)
	{
		if (!ValidIndices(i,j)) return;
		var obj = DiamondList[i][j];
		do {
			ShiftIJ(ref i, ref j, bias);
		} while (ValidIndices(i,j) && DiamondList[i][j] != obj);
		if (ValidIndices(i,j) && DiamondList[i][j] == obj)
		{
			NullDiamond(i,j,bias);
			DiamondList[i][j] = null;
		}
	}
	
	void NullDiamond2(int startI, int startJ, Bias bias)
	{
		if (!ValidIndices(startI, startJ)) return;
		int i=startI, j = startJ;
		var startObj = DiamondList[i][j];
		do {
			ShiftReverseIJ(ref i, ref j, bias);
		} while (ValidIndices(i,j) && DiamondList[i][j] != startObj);
		if (ValidIndices(i,j) && DiamondList[i][j] == startObj)
		{
			var obj = startObj;
			do {
				ShiftIJ(ref i, ref j, bias);
				if (ValidIndices(i,j))
				{
					obj = DiamondList[i][j];
					DiamondList[i][j] = null;
				}
			} while (ValidIndices(i,j));
		}
	}
	
	void ShiftIJ(ref int i, ref int j, Bias bias)
	{
		if (bias == Bias.Right)
		{
			if (DiamondList[i].Type != RowType.Alternate) --j;
		}
		else if (DiamondList[i].Type == RowType.Alternate) ++j;
		--i;
	}
	
	void ShiftInverseIJ(ref int i, ref int j, Bias bias)
	{
		if (bias == Bias.Right)
		{
			if (DiamondList[i].Type != RowType.Alternate) ++j;
		}
		else if (DiamondList[i].Type != RowType.Alternate) --j;
		++i;
	}
	
	void ShiftReverseIJ(ref int i, ref int j, Bias bias)
	{
		if (bias == Bias.Right)
		{
			if (DiamondList[i].Type == RowType.Alternate) ++j;
		}
		else if (DiamondList[i].Type != RowType.Alternate) --j;
		++i;
	}
	
	void ClearTouched()
	{
		foreach(var o in TouchedEntities)
			o.Touched();
		TouchedEntities.Clear();
	}
	
	
	void LoadBurst(Vector3 position)
	{
		var go = (GameObject)Instantiate(Bursts[0], position, Quaternion.identity);
		//var go2 = (GameObject)Instantiate(Bursts[1], position, Quaternion.identity);
		go.AddComponent<DiamondControl>();
		//go2.AddComponent<DiamondControl>();
		Destroy(go, 3);
		//Destroy(go2, 3);
	}
	
	public static GameObject GetPointFromXY(Vector3 point)
	{
		var ray = Camera.main.ScreenPointToRay(point);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			return hit.collider.gameObject;
		}
		return null;
	}
	
	int diamondIteration = 0;
	int numOfDiamonds = 7;
	float startX = 6f, deltaX = 1.5f, speedMultiplier = 1.5f;
	float startZ = -9, startY = 20, extraDelta;
	List<DiamondCollection> _DiamondList;
	List<DiamondCollection> DiamondList {get {return (_DiamondList ?? (_DiamondList = new List<DiamondCollection>()));}}
	void CreateDiamonds()
	{
		if (!Misc.GamePaused && Misc.TimeInLevel > diamondIteration * (speedMultiplier/DiamondControl.Speed))
		{
			var list = new DiamondCollection();
			list.Type = DiamondList.Count == 0 || DiamondList[DiamondList.Count - 1].Type == RowType.Alternate ? RowType.Regular : RowType.Alternate;
			if (list.Type != RowType.Alternate) extraDelta = 0;
			else extraDelta = deltaX/2;
			DiamondList.Add(list);
			int index;
			for (int i=0; i<numOfDiamonds; ++i)
			{
				index = loadTestData ? LoadTest(i) : Rand.Next(0, Entities.Count);
				//var o = (GameObject)Instantiate(Entities[index], new Vector3(startX + i*deltaX + extraDelta, startY, startZ), Quaternion.identity);
				//o.tag = DiamondTag;
				//o.transform.localScale *= 0.75f;
				//o.AddComponent<DiamondControl>();
				list.Add(CreateDiamond(i, index));
			}
			++diamondIteration;
			
			CleanUpDiamonds();
		}
		if (levelUp)
		{
			levelUp = false;			
			var s1 = DiamondControl.Speed;
			float d1 = diamondIteration * (speedMultiplier/DiamondControl.Speed);
			//Misc.PauseTime += (float)(Misc.TimeInLevel - diamondIteration * (speedMultiplier/DiamondControl.Speed));
			DiamondControl.IncreaseSpeed(); 
			var s2 = DiamondControl.Speed;
			diamondIteration = (int)(diamondIteration *(s2 / s1)) ;
			float timeDiff = d1 - diamondIteration * (speedMultiplier/DiamondControl.Speed);
			Misc.PauseTime += timeDiff;
		}
	}
	
	TutorialCollection _tutorialCollection;
	TutorialCollection tutorialCollection
	{
		get 
		{
			if (_tutorialCollection == null)
			{
				_tutorialCollection = new TutorialCollection();
			}
			return _tutorialCollection;
		}
	}
	PuzzleCollection _puzzleCollection;
	PuzzleCollection puzzleCollection
	{
		get 
		{
			if (_puzzleCollection == null)
			{
				_puzzleCollection = new PuzzleCollection();
				Puzzles.AddMore(_puzzleCollection);
			}
			return _puzzleCollection;
		}
	}
	Puzzle CurrentPuzzle;
	bool doNotLoadDiamonds;
	void CreatePuzzleDiamonds(int puzzleId)
	{
		if (doNotLoadDiamonds 
		    || (Misc.Instance.TutorialMode && tutorialCollection.Count == 0)
		    || (!Misc.Instance.TutorialMode && puzzleCollection.Count == 0)) return;
		if (!Misc.Instance.TutorialMode && !puzzleCollection.Any(p=>p.Id == puzzleId)) 
			puzzleId = puzzleCollection[puzzleCollection.Count - 1].Id;
		else if (Misc.Instance.TutorialMode && !tutorialCollection.Any(p=>p.Id == puzzleId)) 
			puzzleId = tutorialCollection[tutorialCollection.Count - 1].Id;
		var puzzle = Misc.Instance.TutorialMode ? tutorialCollection.Where(p=>p.Id == puzzleId).First() : puzzleCollection.Where(p=>p.Id == puzzleId).First() ;
		CurrentPuzzle = puzzle;
		ClearExistingPuzzle();
		int iteration = 0;
		Misc.PuzzleMoveCount = 0;
		Misc.MaximumMoveCount = puzzle.MaximumNumberOfMoves;
		foreach (var row in puzzle)
		{
			var list = new DiamondCollection();
			list.Type = iteration % 2 == 0 ? RowType.Regular : RowType.Alternate;
			if (iteration % 2 == 0) extraDelta = 0;
			else extraDelta = deltaX/2;

			DiamondList.Add(list);
			for (int i=0; i<row.Count; ++i)
			{
				if (row[i] < 0) continue;
				var dc = CreateDiamond(i, row[i]);
				dc.EndPuzzleDelta = iteration * 1.5f;
				list.Add(dc);
				PuzzleDiamonds.Add(dc);
			}
			++iteration;
		}
	}
	
	void ClearExistingPuzzle()
	{
		ClearExistingDiamonds();
		PuzzleDiamonds.Clear();
	}
	
	List<DiamondControl> _PuzzleDiamonds;
	List<DiamondControl> PuzzleDiamonds {get {return (_PuzzleDiamonds ?? (_PuzzleDiamonds = new List<DiamondControl>()));}}
	
	void ClearExistingDiamonds()
	{
		for (int i=0; i<DiamondList.Count; ++i)
			for (int j=0; j<DiamondList[i].Count; ++j)
				if (DiamondList[i][j] != null)
					Destroy(DiamondList[i][j].gameObject);
		DiamondList.Clear();
	}
	
	DiamondControl CreateDiamond(int index, int entityIndex)
	{
		var o = (GameObject)Instantiate(Entities[entityIndex], new Vector3(startX + index*deltaX + extraDelta, startY, startZ), Quaternion.identity);
		o.tag = DiamondTag;
		o.AddComponent<DiamondControl>();
		o.transform.localScale *= 0.8f;
		return o.GetComponent<DiamondControl>();
	}
	
	bool loadTestData;
	List<List<int>> testData;
	int LoadTest(int index)
	{
		if (!loadTestData) return Rand.Next(0, Entities.Count);
		if (testData == null) 
		{
			testData = new List<List<int>>();
			testData.Add(new List<int> {0,0,0,0,0,0,0});
			testData.Add(new List<int> {0,1,0,0,0,0,0});
			testData.Add(new List<int> {1,1,0,0,0,0,0});
			testData.Add(new List<int> {1,2,2,2,0,0,0});
		}
		if (diamondIteration >= testData.Count)
		{
			loadTestData = false;
			return Rand.Next(0, Entities.Count);
		}
		return testData[diamondIteration][index];
	}
	
	void CleanUpDiamonds()
	{
		//if (shiftMatchingInProcess || DiamondList.Count == 0 ) return;
		if (DiamondList[0].Any(o=>o != null && o.transform.position.z >= DiamondControl.EndZPosition))
			DiamondList.RemoveAt(0);
		if (!DiamondList[0].Any(o=>o != null))
			DiamondList.RemoveAt(0);
	}
	
	string DiamondTag = "Diamond";
}

public class DiamondCollection: List<DiamondControl>
{
	public RowType Type {get;set;}
}

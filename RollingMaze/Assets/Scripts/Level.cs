using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEditor;
using MNProductions.Maze.Enums;

public class Level : MonoBehaviour {
	
	System.Random Rand;
	bool LoadCountDown;
	float bestTime;
	GUIStyle Style; 
	int CoinCount;
	Dictionary<PowerupTypes, int> PowerupCount;
	
	float startPauseTime;
	float PauseTime = 0;
	bool _GamePaused;
	bool GamePaused 
	{
		get {return _GamePaused;}
		set {
			_GamePaused = value;
			if (GameObject.Find("Ball") != null)
				GameObject.Find("Ball").GetComponent<BallController>().GamePaused = value;
			if (value)
				startPauseTime = Time.timeSinceLevelLoad;
			else
			{
				PauseTime += (Time.timeSinceLevelLoad - startPauseTime);
			}
		}
	}
	
	GameObject _BallObject;
	GameObject BallObject {get {return _BallObject ?? (_BallObject = GameObject.Find("Ball"));}}
	BallController BallObjectController {get {return GameObject.Find("Ball").GetComponent<BallController>();}}
	
	float TimeInLevel { get {return Time.timeSinceLevelLoad - PauseTime;}}
	// Use this for initialization
	void Start () {
		ItemCollection = new List<GameObject>();
		NonCoinItemCollection = new List<GameObject>();
		LoadItems("itemDropPoint");
		//LoadBall();
		HideWalls();
		PauseTime = 0;
		GamePaused = true;
		startPauseTime = Time.timeSinceLevelLoad;
		LoadCountDown = true;
		Style = new GUIStyle();
		Style.fontSize = 20;
		Style.normal.textColor = Color.yellow;
		bestTime = SaveData.GetBestTime(LevelName);
		CoinCount = SaveData.GetCoinCount();
		LoadPowerups();
		TextManager.LoadGui();
	}
	
	public static int LevelCount 
	{
		get{
			if (StartButtons.IsFreeVersion) return 5;
			return 10;
		}
	}
	#region Loading
	void LoadPowerups()
	{
		PowerupCount = new Dictionary<PowerupTypes, int>();
		foreach(PowerupTypes type in System.Enum.GetValues(typeof(PowerupTypes)))
		{
			PowerupCount[type] = SaveData.GetItemCollectedCount(type.ToString());
		}
	}
	
	void Awake()
	{
		Rand = new System.Random((int)(Time.time * 1000));
	}
	
	List<GameObject> ItemCollection;
	List<GameObject> NonCoinItemCollection;
	
	void HideWalls()
	{
		foreach(var wall in GameObject.FindGameObjectsWithTag("Player"))
		{
			wall.renderer.enabled =false;
		}
	}
	
	List<UnityEngine.Object> ItemPrefabs;
	void LoadPrefabs()
	{
		ItemPrefabs = new List<Object>();
		for (int i=0; i<10; ++i)
		{
			var item = Resources.Load(i.ToString());
			ItemPrefabs.Add(item);
		}
		for (int i=97; i<=122; ++i)
			ItemPrefabs.Add(Resources.Load(((char)i).ToString()));
		ItemPrefabs.Add(Resources.Load("CoinSource"));
	}
	
	void LoadItems(string name)
	{
		LoadPrefabs();
		
		foreach(var objLocation in GameObject.FindGameObjectsWithTag("GameController"))
		{
			if (objLocation == null) continue;
			Object item;
			if (objLocation.name == "Coin")
			{
				item = ItemPrefabs.First(i=>i.name == "CoinSource");
			}
			else 
			{
				do {
					item = ItemPrefabs[Rand.Next(0, ItemPrefabs.Count)];
				}
				while (item.name.StartsWith("Coin"));
			}
			try {
			var obj = (GameObject)Instantiate(item, objLocation.transform.position, Quaternion.identity);
			obj.AddComponent("itemBehavior");
			ItemCollection.Add(obj);
			if (objLocation.name != "Coin")
				NonCoinItemCollection.Add(obj);
			}
			catch {}
		}
	}
	
	GameObject FinishMessage;
	bool BestTimeAchieved;
	
	void LoadFinishMessage()
	{
		var pos = Camera.main.transform.position;
		FinishMessage = (GameObject)Instantiate(Resources.Load(string.Format("Message{0}", Rand.Next(1, MessageCount)))
		                                        , new Vector3(pos.x, 8, pos.z), Quaternion.identity);
		BestTimeAchieved = TimeInLevel < (bestTime <= 0 ? 9999 : bestTime);
		if (BestTimeAchieved)
		{
			bestTime = TimeInLevel;
			SaveData.SaveLevelTime(LevelName, TimeInLevel);
		}
		GamePaused = true;
	}
	
	#endregion
	
	public int MessageCount = 3;
	float countDownSpeed = 10;
	int countDownDelta= 5;
	float startY = 20;
	List<GameObject> countDownList;
	void AddCountDown(List<GameObject> list, string name, Vector3 position)
	{
		list.Add((GameObject)Instantiate(Resources.Load(name), position, Quaternion.identity));			
		int index = countDownList.Count - 1;
		list[index].transform.position += new Vector3(0, startY + index*countDownDelta, 0);
		list[index].transform.RotateAround(Vector3.up, 90);
	}
	
	bool ProcessCountDown(ref List<GameObject> list, out bool goAhead, float speed, params string[] names)
	{
		goAhead = false;
		if (list == null || list.Count == 0)
		{
			if (list == null)
				list = new List<GameObject>();
			var ball = GameObject.Find("Ball");
			for (int i=0; i<names.Length; ++i)
				AddCountDown(list, names[i], ball.transform.position);
			GamePaused = true;
		}
		foreach (var obj in list)
		{
			obj.transform.position -= new Vector3(0, Time.deltaTime * speed, 0);
			obj.transform.Rotate(Vector3.up, Time.deltaTime * 30);
		}
		if (list[list.Count - 2].transform.position.y < 2)
		{
			goAhead = true;
		}
		if (list[list.Count - 1].transform.position.y < 0)
		{
			foreach (var obj in list)
			{
				Destroy(obj);
			}
			list.Clear();
			list = null;
			return false;
		}
		return true;
	}
		
	// Update is called once per frame
	void FixedUpdate () {
		if (LoadCountDown)
		{
			bool goAhead = false;
			LoadCountDown = ProcessCountDown(ref countDownList, out goAhead, countDownSpeed, "Three", "Two", "One", "Go");
			if (goAhead)
			{
				if (GamePaused)
					GamePaused = false;
			}
		}
		if (CurrentActions.Contains(PowerupTypes.pow))
		{
			bool goAhead = false;
			var ret = ProcessCountDown(ref countDownList, out goAhead, countDownSpeed, "calculating", "graph", "integral", "Go");
			if (goAhead)
			{
				if (GamePaused)
					GamePaused = false;
			}
			if (!ret)
			{
				CurrentActions.Remove(PowerupTypes.pow);			
				var ball = GameObject.Find("Ball");//.GetComponent<BallController>().PowActionToPosition = 
				var sql = from i in ItemCollection
					where !i.name.StartsWith("Coin")
					orderby Vector3.Distance(i.transform.position, ball.transform.position)
						select i.transform.position;
				if (sql.Count() > 0)
					ball.GetComponent<BallController>().PowActionToPosition = sql.First();
				
			}
		}
		var toRemove = new List<GameObject>();
		foreach (var item in ItemCollection)
		{
			var b = item.GetComponent<itemBehavior>();
			if (b.ItemTouched)
			{
				if (Time.timeSinceLevelLoad - b.CountDown > b.CountDownTo)
				{
					toRemove.Add(item);
					if (b.Type == ItemType.Coin)
					{
						//MusicPlayer.PlaySound("coinSound");
						SaveData.AddCoinCollected();
						++CoinCount;
					}
					else
						SaveData.AddItemCollected(b.name);
				}
			}
		}
		foreach (var item in toRemove)
		{
			ItemCollection.Remove(item);
			NonCoinItemCollection.Remove(item);
			Destroy(item);
		}
		// if there is only one item left and it was touched
		if ((!FinishMessageLoaded && NonCoinItemCollection.Count == 1 && NonCoinItemCollection[0].GetComponent<itemBehavior>().ItemTouched ))
			LoadFinishMessage();
		if (NonCoinItemCollection.Count == 0){
			// no more items, advance to next scene
			int newLevel = CurrentLevel + 1;
			if (newLevel > LevelCount)
			{
				//newLevel = 1;
				AutoFade.LoadLevel("Finished");
				return;
			}
			else				
				AutoFade.LoadLevel(string.Format("Level{0}", newLevel));
		}
		else if (!GamePaused && !FinishMessageLoaded) 
			currentLevelTime = TimeInLevel;
		ProcessFinishMessage();
	}
	
	string LevelName{get {return Application.loadedLevelName;}}
	int CurrentLevel 
	{ 
		get 
		{
			if (LevelName != null)
				return int.Parse(LevelName.Replace("Level", ""));
			return Application.loadedLevel;
		}
	}
	
	void OnApplicationPause()
	{
		SetGamePause();
	}
	
	void OnGUI()
	{
		GUI.skin.button = null;
		ProcessStatusHUD();
		if (!GamePaused)
		{
			ProcessPowerups();
		}
		if (BestTimeAchieved)
			//ProcessGeneralHUD(new Rect(300, 200, 200, 100), "New best time!");
			TextManager.SetHudText("alert", "New best time!");
		ProcessMenuButtons();
		var coinRect = new Rect(Misc.ScreenWidth - Misc.ButtonWidth, 30, Misc.ButtonWidth-5, Misc.ButtonWidth-5);
		GUI.DrawTexture(coinRect, TextureCollection.Instance.GetTexture("coinTexture"));
		TextManager.SetHudText("coin", CoinCount.ToString());
		//GUI.Label(rect, CoinCount.ToString());
	}
	
	void SetGamePause()
	{
		MusicPlayer.PlaySound("menuSound");
			configSelected = GamePaused = true;
			var light = GameObject.Find("Directional light").GetComponent<Light>();
			CurrentLightColor = light.color;
			light.color = Color.grey;
	}
	
	bool configSelected = false;
	float currentLightIntensity;
	UnityEngine.Color CurrentLightColor;
	void ProcessMenuButtons()
	{
		if (!configSelected && !GamePaused && GUI.Button(new Rect(10, 40, Misc.ButtonWidth, Misc.ButtonHeight), Textures.GetTexture("icon_gear")))
		{
			SetGamePause();
		}
		if (configSelected)
		{
			if (GUI.Button(new Rect(10, 40, Misc.ButtonWidth, Misc.ButtonHeight), Textures.GetTexture("icon_back")))
			{
				MusicPlayer.PlaySound("menuSound");
				configSelected = GamePaused = false;
				GameObject.Find("Directional light").GetComponent<Light>().color = CurrentLightColor;
			}
			if (GUI.Button(new Rect(10 + Misc.ButtonWidth, 40, Misc.ButtonWidth, Misc.ButtonHeight), Textures.GetTexture("icon_home")))
			{
				MusicPlayer.PlaySound("menuSound");
				AutoFade.LoadLevel("Title");
			}
			if (GUI.Button(new Rect(10 + 2*Misc.ButtonWidth, 40, Misc.ButtonWidth, Misc.ButtonHeight), Textures.GetTexture("icon_restart")))
			{
				MusicPlayer.PlaySound("menuSound");
				AutoFade.LoadLevel(LevelName);		
			}
			if (false && GUI.Button(new Rect(10 + 3*Misc.ButtonWidth, 40, 150, Misc.ButtonHeight), string.Format("Turn Music {0}", SaveData.IsMusicOn ? "Off" : "On")))
			{
				SaveData.ToggleMusicOnOff();
				if (SaveData.IsMusicOn)
					MusicPlayer.Instance.Play();
				else
					MusicPlayer.Instance.Stop();
			}
		}
	}
	
	float currentLevelTime = 0;
	void ProcessStatusHUD()
	{
		float time = GamePaused ? TimeInLevel - (Time.timeSinceLevelLoad - startPauseTime) : TimeInLevel;
		if (time < 0.1f) time = 0;
		//GUI.Label(new Rect(10, 10, 600, 100), string.Format("Time: {0:0.00} Best Time: {1:0.00} "
		//                                                    , time
		//                                                    , bestTime
		//                                                    )
		//          );
		TextManager.SetHudText("hud", string.Format("Best Time: {1:0.00} Time: {0:0.00} "
		                                                    , time
		                                                    , bestTime
		                                                    ));
	}
	
	List<PowerupTypes> _CurrentActions;
	List<PowerupTypes> CurrentActions
	{
		get {return (_CurrentActions ?? (_CurrentActions = new List<PowerupTypes>()));}
	}
	void ProcessPowerups()
	{
		if (PowerupCount == null ) return;
		foreach(var item in PowerupCount.Where(i=>i.Value > 0).Select(i=>i.Key).ToList())
		{
			string name = item.ToString();
			var rect = new Rect(Misc.ScreenWidth - Misc.ButtonWidth, Misc.ScreenHeight/2+30, Misc.ButtonWidth, Misc.ButtonHeight);
			if (GUI.Button(rect , Textures.GetTexture(PowerupIcons.GetIcon(name))) && !CurrentActions.Contains(item))
			{
				CurrentActions.Add(item);
				PowerupCount[item]--;
				SaveData.AddItemCollected(name, -1);
			}
			//GUI.Label(rect, PowerupCount[item].ToString());
			TextManager.SetHudText("pow", string.Format("{0}    ", PowerupCount[item]));
		}
	}
	
	TextureCollection _textures;
	TextureCollection Textures {get {return (_textures ?? (_textures = new TextureCollection()));}}
	void ProcessGeneralHUD(Rect pos, string message)
	{
		GUI.Label(pos, message, Style);
	}
	
	bool FinishMessageLoaded 
	{
		get {return FinishMessage != null;}
	}
	float rotateSpeed = 30;
	void ProcessFinishMessage()
	{
		if (FinishMessage == null) return;
		FinishMessage.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
		FinishMessage.transform.position += Vector3.up * Time.deltaTime;
		if (FinishMessage.transform.position.y >= 20)
			Destroy(FinishMessage);

	}
	
	
}

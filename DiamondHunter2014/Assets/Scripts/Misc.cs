using System;
using UnityEngine;

public class Misc : MonoBehaviour
{
	
    private static Misc instance = null;
    public static Misc Instance { get { return (instance ?? (instance = new Misc())); } }
	public Misc ()
	{
		ScreenWidth = Screen.width;
		ScreenHeight = Screen.height;
		ButtonWidth = (int)(ScreenWidth / 6.4);
		ButtonHeight = (int)(ScreenHeight / 6.4);
		ScreenHeightHalf = ScreenHeight / 2;
		ScreenWidthHalf = ScreenWidth / 2;
	}
	
	public static GameStyle Style
	{
		get {return GameStyle.Full;}
	}
	
	public int ScreenWidth, ScreenHeight, ScreenWidthHalf, ScreenHeightHalf;
	public int ButtonWidth, ButtonHeight;
	public static int NumberOfKills = 0;
	
	static float startPauseTime;
	public static float PauseTime = 0;
	static GameMode _Mode;
	public static bool ModeSet {get;set;}
	public static GameMode Mode 
	{
		get {return _Mode;}
		set
		{
			if (value == GameMode.Arcade)
			{
				DiamondControl.Speed = 1.5f;
				DiamondControl.ShiftMultiplerSpeed = 15;
			}
			else 
			{
				//DiamondControl.Speed = 8f;
				//DiamondControl.ShiftMultiplerSpeed = 3;
			}
			_Mode = value;
			ModeSet = true;
		}
	}
	public static int PuzzleMoveCount, MaximumMoveCount;
	static bool _GamePaused;
	public static bool GamePaused 
	{
		get {return _GamePaused;}
		set {
			_GamePaused = value;
			if (value)
				startPauseTime = Time.timeSinceLevelLoad;
			else
			{
				PauseTime += (Time.timeSinceLevelLoad - startPauseTime);
			}
		}
	}
	public static float TimeInLevel { get {return Time.timeSinceLevelLoad - PauseTime;}}
	public static void Reset()
	{
		PauseTime = 0;
		_GamePaused = false;
		startPauseTime = 0;
	}
	
	public int HighScore
	{
		get 
		{
			string key = "Score" + ( Mode == GameMode.Arcade ? "" : GameControl.Level.ToString());
			return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetInt(key) : 0;
		}		
		set 
		{ 
			string key = "Score" + ( Mode == GameMode.Arcade ? "" : GameControl.Level.ToString());
			PlayerPrefs.SetInt(key, value); 
		}
	}
	int? _NumberOfLevelsCompleted;
	public int NumberOfLevelsCompleted
	{
		get
		{
			if (_NumberOfLevelsCompleted == null)
			{
				int i=1;
				for (; i<100; ++i)
				{
					if (!PlayerPrefs.HasKey("Score" + i.ToString())) break;
				}
				_NumberOfLevelsCompleted = i;
			}
			return _NumberOfLevelsCompleted ?? 1;
		}
	}
	public int HighLevel
	{
		get {return PlayerPrefs.HasKey("Level") ? PlayerPrefs.GetInt("Level") : 0;}
		set { PlayerPrefs.SetInt("Level", value);}
	}
	public string CurrentMusic
	{
		get {return PlayerPrefs.HasKey("Music") ? PlayerPrefs.GetString("Music") : "SoundTitle";}
		set { PlayerPrefs.SetString("Music", value);}
	}
	public bool MusicMute
	{
		get {return PlayerPrefs.HasKey("MusicMute") ? PlayerPrefs.GetInt("MusicMute") == 1 : false;}
		set { PlayerPrefs.SetInt("MusicMute", value ? 1 : 0);}
	}
	public bool TutorialMode
	{
		get { return false; }// PlayerPrefs.HasKey("TutorialMode") ? PlayerPrefs.GetInt("TutorialMode") == 1 : true;}
		set { PlayerPrefs.SetInt("TutorialMode", value ? 1 : 0);}
	}
}

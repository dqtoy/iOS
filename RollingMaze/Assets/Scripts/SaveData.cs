
using UnityEngine;    // For Debug.Log, etc.


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SaveData {

	public int Coins;
	
	public static void AddItemCollected(string name)
	{
		PlayerPrefs.SetInt(name, PlayerPrefs.HasKey(name) ? PlayerPrefs.GetInt(name) + 1 : 1);
	}
	
	public static void AddItemCollected(string name, int count)
	{
		PlayerPrefs.SetInt(name, PlayerPrefs.HasKey(name) ? PlayerPrefs.GetInt(name) + count : count);
	}
	
	public static int GetItemCollectedCount(string name)
	{
		return PlayerPrefs.HasKey(name) ? PlayerPrefs.GetInt(name) : 0;
	}
	
	static string CoinKey = "Coins";
	public static void AddCoinCollected()
	{
		AddCoinsCollected(1);
	}
	
	public static void AddCoinsCollected(int count)
	{
		PlayerPrefs.SetInt(CoinKey, PlayerPrefs.HasKey(CoinKey) ? PlayerPrefs.GetInt(CoinKey) + count : count);
	}
	
	public static void SubtractCoinsCollected(int amount)
	{
		PlayerPrefs.SetInt(CoinKey, PlayerPrefs.HasKey(CoinKey) ? PlayerPrefs.GetInt(CoinKey) - amount : 0);
	}
	
	public static void SaveLevelTime(string key, float time)
	{
		var value = string.Format("{0:0.00}", time);
		//PlayerPrefs.SetString(key, PlayerPrefs.HasKey(key) ? PlayerPrefs.GetString(key) + "," + value : value);
		PlayerPrefs.SetString(key, value);
	}
	
	public static int GetCoinCount()
	{
		return PlayerPrefs.HasKey(CoinKey) ? PlayerPrefs.GetInt(CoinKey) : 0;
	}
	
	public static float GetBestTime(string name)
	{
		try {
			if (!PlayerPrefs.HasKey(name)) return 0;
			return float.Parse(PlayerPrefs.GetString(name));
		}
		catch (Exception exc)
		{
			Debug.Log(exc.ToString());
			return -999;
		}
			
	}
	
	static string HelpKey = "Help";
	public static bool ShowHelp
	{
		get {return !PlayerPrefs.HasKey(HelpKey);}
		set {PlayerPrefs.SetInt(HelpKey, 1);}
	}
	
	
	static string CurrentMusicKey = "CurrentMusic";
	public static string CurrentMusic
	{
		get{
			return PlayerPrefs.HasKey(CurrentMusicKey) ? PlayerPrefs.GetString(CurrentMusicKey) : "BGMusic1";
		}
	}
	
	public static void SetCurrentMusic(string music)
	{
		PlayerPrefs.SetString(CurrentMusicKey, music);
	}
	
	static string MusicOnOffKey = "MusicOnOff";
	public static void SetMusicOnOff(int onOff)
	{
		PlayerPrefs.SetInt(MusicOnOffKey, onOff);
	}
	
	public static bool IsMusicOn
	{
		get
		{
			return PlayerPrefs.HasKey(MusicOnOffKey) ? PlayerPrefs.GetInt(MusicOnOffKey) == 1 : true;
		}
	}
	
	public static void ToggleMusicOnOff()
	{
		PlayerPrefs.SetInt(MusicOnOffKey, IsMusicOn ? 0 : 1);
	}
	
	public static void Reset()
	{
		PlayerPrefs.DeleteAll();
	}
  // The default constructor. Included for when we call it during Save() and Load()
  	public SaveData () 
	{
	}

}

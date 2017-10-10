using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class MusicPlayer : MonoBehaviour {
  private static MusicPlayer instance = null;
  public static MusicPlayer Instance { get 
		{
			if (instance == null)
			{
				if (Misc.Instance.CurrentMusic != null)
				{
					var bg = (GameObject)Resources.Load(Misc.Instance.CurrentMusic);
					bg.AddComponent<MusicPlayer>();
					instance = bg.GetComponent<MusicPlayer>();
				}
			}
			return instance;
		}
		set {instance = value;}
	}

	void Start()
	{
		if (Instance == null) 
		    Instance = this;
	    DontDestroyOnLoad(gameObject);
	}
	
  public void Play() {
		if (audio.isPlaying ) return;
        	audio.Play();
  }
	
	public void LoadNewTrack()
	{

		//var bg = (GameObject)Resources.Load(SaveData.CurrentMusic);// GameObject.Find(SaveData.CurrentMusic);
		//instance = bg.GetComponent<MusicPlayer>();
		instance.Play();
	}
	
	public void PlayNewSong(string title)
	{
		print(title);
		Misc.Instance.CurrentMusic = title;
		Instance.Stop();
		if (title != null)
		{
			var bg = (GameObject)Resources.Load(title);
			bg.AddComponent<MusicPlayer>();
			Instance = bg.GetComponent<MusicPlayer>();
			Instance.Play();
		}
	}
	
	public void TogglePlay()
	{
		if (audio.isPlaying) audio.Stop();
		else audio.Play();
	}

  public void Stop() {
    audio.Stop();
  }
	
	public static void PlaySound(string name){
		var sound =  (GameObject)Resources.Load(name);
		if (sound != null)
			sound.audio.Play();
	}
	
	public static void PlaySound(SoundType type)
	{
		PlaySound(Sounds.Instance.GetSound(type));
	}
	
	public static void PlayTitle()
	{
		var sound =  (GameObject)Resources.Load(Sounds.Instance.GetSound(SoundType.Title));
		if (sound != null && !sound.audio.isPlaying)
		{
			sound.audio.loop = true;
			sound.audio.Play();
		}
	}
}


public class Sounds : Dictionary<SoundType, string>
{
	static Sounds instance;
	public static Sounds Instance {get {return (instance ?? (instance = new Sounds()));}}
	
	public Sounds()
	{
		Add(SoundType.Touches, "SoundTouch");
		Add(SoundType.PowerUp, "SoundPowerUp");
		Add(SoundType.WrongMove, "SoundWrongMove");
		Add(SoundType.Title, "SoundTitle");
		Add(SoundType.GameOver, "SoundGameOver");
		Add(SoundType.LevelUp, "SoundLevelUp");
		Add(SoundType.PowerUp2, "SoundPowerUp2");
		Add(SoundType.Transition, "SoundTransition");
		
	}
	
	public string GetSound(SoundType type)
	{
		return ContainsKey(type) ? this[type] : this[SoundType.Default];
	}
}
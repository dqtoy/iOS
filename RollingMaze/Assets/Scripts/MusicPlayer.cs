using System;
using UnityEngine;


public class MusicPlayer : MonoBehaviour {
  private static MusicPlayer instance = null;
  public static MusicPlayer Instance { get 
		{
			if (instance == null)
			{
				var bg = (GameObject)Resources.Load(SaveData.CurrentMusic);// GameObject.Find(SaveData.CurrentMusic);
				instance = bg.GetComponent<MusicPlayer>();
			}
			return instance;
		}
	}

	void Start()
	{
		if (instance != null) return;
	    instance = this;
	    DontDestroyOnLoad(this.gameObject);
	}
	
  public void Play() {
		if (audio.isPlaying || !SaveData.IsMusicOn) return;
        audio.Play();
  }
	
	public void LoadNewTrack()
	{

		var bg = (GameObject)Resources.Load(SaveData.CurrentMusic);// GameObject.Find(SaveData.CurrentMusic);
		instance = bg.GetComponent<MusicPlayer>();
		instance.Play();
	}

  public void Stop() {
    audio.Stop();
  }
	
	public static void PlaySound(string name){
		var sound =  (GameObject)Resources.Load(name);
		if (sound != null)
			sound.audio.Play();
	}
}
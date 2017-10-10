using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyBird
{

	public class MusicPlayer : MonoBehaviour {
		public static MusicPlayer instance;
		public static MusicPlayer Instance { get 
			{
				if (instance == null)
				{
					var bg = (GameObject)Resources.Load(Main.CurrentSong);// GameObject.Find(SaveData.CurrentMusic);
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

			if (audio.isPlaying) return;
			audio.enabled = true;
			audio.Play();
	  }
		
		public void LoadNewTrack()
		{
			var bg = (GameObject)Resources.Load(Main.CurrentSong);
			instance = bg.GetComponent<MusicPlayer>();
			bg.GetComponent<AudioSource> ().enabled = true;
			instance.enabled = true;
			instance.Play();
		}

	  public void Stop() {
			audio.Stop();
	  }

		static Dictionary<string, UnityEngine.GameObject> _SoundObjects;
		static Dictionary<string, UnityEngine.GameObject> SoundObjects{
			get{
				return _SoundObjects ?? (_SoundObjects = new Dictionary<string, UnityEngine.GameObject>());
			}
		}

		public static void PlaySound(SoundType type)
		{
			var sound = GameObject.FindGameObjectWithTag(Sounds.Instance.GetSound(type)).GetComponent<MusicPlayer>();
			sound.Stop ();
			sound.Play();
		}
		public static void PlaySound(string type, bool loop)
		{
			if (instance != null)
				instance.Stop ();
			instance = GameObject.FindGameObjectWithTag(type).GetComponent<MusicPlayer>();
			instance.GetComponent<AudioSource> ().loop = loop;
			instance.Play();
		}
	}


	public class Sounds : Dictionary<SoundType, string>
	{
		static Sounds instance;
		public static Sounds Instance {get {return (instance ?? (instance = new Sounds()));}}
		
		public Sounds()
		{
			Add(SoundType.Explosion, "ExplosionSound");
			Add(SoundType.Flap, "FlapSound");
			Add(SoundType.Coin, "CoinSound");
			Add(SoundType.Thud, "SoundThud");
			Add(SoundType.Song1, "Song1");
			Add(SoundType.Song2, "Song2");
		}
		
		public string GetSound(SoundType type)
		{
			return ContainsKey(type) ? this[type] : this[SoundType.Default];
		}
	}
}
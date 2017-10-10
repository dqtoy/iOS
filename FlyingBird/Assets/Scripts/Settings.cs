using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MyBird;

public class Settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		BackTexture  = GameObject.Find ("Back").GetComponent<GUITexture> ();
		HandednessTexture  = GameObject.Find ("Handedness").GetComponent<GUITexture> ();
		NoMusicTexture  = GameObject.Find ("NoMusic").GetComponent<GUITexture> ();
		Song1Texture  = GameObject.Find ("Song1").GetComponent<GUITexture> ();
		Song2Texture  = GameObject.Find ("Song2").GetComponent<GUITexture> ();
		ReviewTexture  = GameObject.Find ("Review").GetComponent<GUITexture> ();
		HelpTexture  = GameObject.Find ("Help").GetComponent<GUITexture> ();
		SettingTexture  = GameObject.Find ("Settings_type").GetComponent<GUITexture> ();
		LoadScoreTextures ();
		SetScore (Main.HighScore);


		Main.SetGuiTextureInset (HelpTexture);
		Main.SetGuiTextureInset (BackTexture);
		Main.SetGuiTextureInset (SettingTexture);
		Main.SetGuiTextureInset (NoMusicTexture);
		Main.SetGuiTextureInset (Song1Texture );
		Main.SetGuiTextureInset (Song2Texture);
		Main.SetGuiTextureInset (ReviewTexture);
		Main.SetGuiTextureInset (HandednessTexture);
	}
	
	GUITexture BackTexture, HandednessTexture, NoMusicTexture, Song1Texture, Song2Texture, ReviewTexture, HelpTexture, SettingTexture;
	// Update is called once per frame
	void Update () {
		if (MyBird.Main.IsTextureTouchedReleased(BackTexture, true))
			AutoFade.LoadLevel("Title");
		if (MyBird.Main.IsTextureTouchedReleased (HelpTexture, true)) {
			Main.PreviousScene = "Settings";
			AutoFade.LoadLevel ("Help");
		}
		if (MyBird.Main.IsTextureTouchedReleased (HandednessTexture, true))
			MyBird.Main.ToggleHandedness ();
		if (MyBird.Main.IsTextureTouchedReleased (NoMusicTexture, true))
		{
			MyBird.Main.CurrentSong = "NoSong";
			MusicPlayer.Instance.Stop ();
		}
		if (MyBird.Main.IsTextureTouchedReleased (Song1Texture, true)) 
		{
			MyBird.Main.CurrentSong = "Song1";
			//MusicPlayer.Instance.LoadNewTrack();
			MusicPlayer.PlaySound(Main.CurrentSong, true);
		}
		if (MyBird.Main.IsTextureTouchedReleased (Song2Texture, true))
		{
			MyBird.Main.CurrentSong = "Song2";
			//MusicPlayer.Instance.LoadNewTrack();
			MusicPlayer.PlaySound(Main.CurrentSong, true);
		}
		if (MyBird.Main.IsTextureTouchedReleased (ReviewTexture, true)) 
		{
			Application.OpenURL("https://userpub.itunes.apple.com/WebObjects/MZUserPublishing.woa/wa/addUserReview?id=337064413&type=Purple+Software");
		}
	}

	ObjectCollection scoreCollection;
	
	void SetScore(int score)
	{
		// disable all scores first
		scoreCollection.Where (go => go.guiTexture.enabled).ToList ().ForEach (go => go.guiTexture.enabled = false);
		string scr = score.ToString ();
		if (scr.Length == 2) {
			scoreCollection.Find (go => go.name == "Score1" + scr [1].ToString ()).guiTexture.enabled = true;
		}
		scoreCollection.Find (go => go.name == "Score0" + scr [0].ToString ()).guiTexture.enabled = true;
		
	}

	void LoadScoreTextures()
	{
		scoreCollection = new ObjectCollection ();
		for (int i=0; i<10; ++i) {
			Texture texture =  Resources.Load<Texture>(i.ToString());
			GameObject text0 = new GameObject ("Score0" + i.ToString());
			text0.AddComponent<GUITexture>();
			text0.guiTexture.texture = texture;
			text0.transform.position = new Vector3(0.1f, 0.9f, 0);
			text0.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
			text0.guiTexture.enabled = false;
			scoreCollection.Add(text0);
		}
		for (int i=0; i<10; ++i) {
			Texture texture =  Resources.Load<Texture>(i.ToString());
			GameObject text0 = new GameObject ("Score1" + i.ToString());
			text0.AddComponent<GUITexture>();
			text0.guiTexture.texture = texture;
			text0.transform.position = new Vector3(0.2f, 0.9f, 0);
			text0.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
			text0.guiTexture.enabled = false;
			scoreCollection.Add(text0);
		}
		scoreCollection.Find (go => go.name == "Score00").guiTexture.enabled = true;
	}

}

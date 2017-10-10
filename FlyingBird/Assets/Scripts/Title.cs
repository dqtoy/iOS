using UnityEngine;
using System.Collections;
using MyBird;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {


		StartButton = new Rect (Screen.width/2-50, Screen.height/2, 100, 30);
		TitleRect = new Rect (Screen.width/2-125, Screen.height/3, 250, 40);
		StartButtonTexture = (GUITexture)GameObject.Find ("StartGame").GetComponent<GUITexture> ();
		SettingTexture  = (GUITexture)GameObject.Find ("Setting").GetComponent<GUITexture> ();
		TitleTexture  = (GUITexture)GameObject.Find ("Title").GetComponent<GUITexture> ();
		if (Main.CurrentSong != "" && MusicPlayer.instance != null && !MusicPlayer.instance.GetComponent<AudioSource>().isPlaying)
			MusicPlayer.PlaySound (Main.CurrentSong, true);
		
		AdBinding.destroyAdBanner();
		Main.SetGuiTextureInset (StartButtonTexture);
		Main.SetGuiTextureInset (SettingTexture);
		Main.SetGuiTextureInset (TitleTexture);
	}

	Rect StartButton, TitleRect;
	GUITexture StartButtonTexture, SettingTexture, TitleTexture;

	// Update is called once per frame
	void Update () {
		if (MyBird.Main.IsTextureTouchedReleased (StartButtonTexture, true)) {
			if (!Main.IsFirstTimePlayed)
				AutoFade.LoadLevel ("Level");
			else
			{
				Main.SetFirstTimePlayed();
				Main.PreviousScene = "Level";
				AutoFade.LoadLevel("Help");
			}
		}
		if (MyBird.Main.IsTextureTouchedReleased(SettingTexture, true))
			AutoFade.LoadLevel("Settings");
	}
}

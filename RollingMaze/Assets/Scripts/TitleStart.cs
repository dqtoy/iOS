using UnityEngine;
using System.Collections;

public class TitleStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MusicPlayer.Instance.Play();
	}
	
	void Awake()
	{
	}
	
	
	void OnGUI()
	{
		if (GUI.Button(new Rect(280, 260, Misc.ButtonWidth-10, Misc.ButtonHeight-10), TextureCollection.Instance.GetTexture("button_level")))
		{
			MusicPlayer.PlaySound("menuSound");
			AutoFade.LoadLevel("LevelSelect");
		}
		if (GUI.Button(new Rect(280, 200, Misc.ButtonWidth-10, Misc.ButtonHeight-10), TextureCollection.Instance.GetTexture("button_start")))
		{
			MusicPlayer.PlaySound("menuSound");
			AutoFade.LoadLevel("Level1");
		}
		if (GUI.Button(new Rect(280, 320, Misc.ButtonWidth-10, Misc.ButtonHeight-10), TextureCollection.Instance.GetTexture("button_shop")))
		{
			MusicPlayer.PlaySound("menuSound");
			AutoFade.LoadLevel("Shop");
		}
		if (GUI.Button(new Rect(280, 380, Misc.ButtonWidth-10, Misc.ButtonHeight-10), TextureCollection.Instance.GetTexture("button_option")))
		{
			MusicPlayer.PlaySound("menuSound");
			AutoFade.LoadLevel("Options");
		}
	}
}

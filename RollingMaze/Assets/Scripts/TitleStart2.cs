using UnityEngine;
using System.Collections;

public class TitleStart2 : MonoBehaviour {
	
	public GUIStyle style;


	// Use this for initialization
	void Start () {
		MusicPlayer.Instance.Play();
		buttonX = Misc.ScreenWidth/2;
		buttonY = Misc.ScreenHeight/3;
		buttonHeight = Misc.ButtonHeight;
		buttonWidth = Misc.ButtonWidth;
	}
	
	
	void Awake()
	{
	}
	
	void Update()
	{
	}
	
	public static void LoadBursts(Vector3 position)
	{
		LoadBursts(position, position);
	}
	
	public static void LoadBursts(Vector3 position1, Vector3 position2)
	{
			Instantiate(Resources.Load("burst"), position1, Quaternion.identity);
			Instantiate(Resources.Load("burst2"), position2, Quaternion.identity);
	}
	
	int buttonX, buttonY, buttonHeight, buttonWidth;
	void OnGUIx()
	{
		GUI.skin.button = null;//style;
		if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), TextureCollection.Instance.GetTexture("button_start")))
		{
			MusicPlayer.PlaySound("menuSound");
			LoadBursts(transform.position, transform.position);
			if (SaveData.ShowHelp)
				AutoFade.LoadLevel("Help1");
			else
				AutoFade.LoadLevel("Level1");
		}
		if (GUI.Button(new Rect(buttonX, buttonY + 45, buttonWidth, buttonHeight), TextureCollection.Instance.GetTexture("button_level")))
		{
			MusicPlayer.PlaySound("menuSound");
			LoadBursts(transform.position, transform.position);
			AutoFade.LoadLevel("LevelSelect");
		}
		if (GUI.Button(new Rect(buttonX, buttonY + 100, buttonWidth, buttonHeight), TextureCollection.Instance.GetTexture("button_shop")))
		{
			MusicPlayer.PlaySound("menuSound");
			LoadBursts(transform.position, transform.position);
			AutoFade.LoadLevel("Shop");
		}
		if (GUI.Button(new Rect(buttonX, buttonY + 140, buttonWidth, buttonHeight), TextureCollection.Instance.GetTexture("button_option")))
		{
			MusicPlayer.PlaySound("menuSound");
			LoadBursts(transform.position, transform.position);
			AutoFade.LoadLevel("Options");
		}
	}
}


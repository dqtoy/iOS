using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Gui : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MainGameButtons = true;
		ButtonPositions = new List<Rect>();
		for (int i=0; i<=6; ++i)
		{
			ButtonPositions.Add(new Rect(10 + i*Misc.Instance.ButtonWidth, Misc.Instance.ScreenHeight - Misc.Instance.ButtonHeight
				                        , Misc.Instance.ButtonWidth
				                        , Misc.Instance.ButtonHeight));
		}
		StatusPosition = new Rect(10, 10, 300, 50);
		LevelButtonPositions = new List<Rect>();
		for (int i=0; i<=3; ++i)
		{
			for (int j=0; j<6; ++j)
				LevelButtonPositions.Add(new Rect(10 + j*Misc.Instance.ButtonWidth, Misc.Instance.ButtonHeight*i+Misc.Instance.ButtonHeight
				                        , Misc.Instance.ButtonWidth
				                        , Misc.Instance.ButtonHeight));
		}

		LoadGui();
	}

	UIText text;
	List<Rect> ButtonPositions;
	List<Rect> LevelButtonPositions;
	Rect StatusPosition;
	
	// Update is called once per frame
	void Update () {
	}
	
	void LoadGui()
	{
		//Instantiate(PrefabCollection.Instance.Get(EntityType.UI), Vector3.zero, Quaternion.identity);
		//Instantiate(PrefabCollection.Instance.Get(EntityType.Gui), Vector3.zero, Quaternion.identity);
	}
	
	public static bool IsLevelSelect 
	{
		get {return Application.loadedLevelName == "LevelSelect";}
	}
	
	void LoadButton(string name, int index)
	{
		if (GUI.Button(LevelButtonPositions[index], name))
		{
			//LevelScript.Instance.RestartLevelScript();
			AutoFade.LoadLevel(name);
		}
	}
	
	public bool MainGameButtons = true;
	bool onMenu;
	void OnGUI2()
	{
		if (IsLevelSelect)
		{
			int levelSelectIndex = 0;
			LoadButton("Foyer", levelSelectIndex++);
			LoadButton("DiningSmall", levelSelectIndex++);
			LoadButton("DiningHall", levelSelectIndex++);
			LoadButton("TrainingRoom", levelSelectIndex++);
			LoadButton("Chopper", levelSelectIndex++);
			LoadButton("Stairs", levelSelectIndex++);
		}
		if (true || MainGameButtons)
		{
			int buttonIndex = 0;
			if (!onMenu && GUI.Button(ButtonPositions[buttonIndex++], "Menu"))
			{
				onMenu = true;
				Misc.GamePaused = true;
			}
			else if (onMenu)
			{
				if (GUI.Button(ButtonPositions[buttonIndex++], "Back"))
				{
					onMenu = false;
					Misc.GamePaused = false;
				}
			}
			else
			{
				if (false && GUI.Button(ButtonPositions[buttonIndex++], "Fire"))
				{
					//ProjectileControl.PowerProjectile = true;
				}
			}
			if (onMenu)
			{
				if (GUI.Button(ButtonPositions[buttonIndex++], "Restart"))
				{
					AutoFade.LoadLevel(Application.loadedLevelName);
					Misc.NumberOfKills = 0;
					Misc.GamePaused = false;
				}
				if (GUI.Button(ButtonPositions[buttonIndex++], "Title"))
				{
					AutoFade.LoadLevel("Title");
					Misc.NumberOfKills = 0;
					Misc.GamePaused = false;
				}
				if (GUI.Button(ButtonPositions[buttonIndex++], "Select Room"))
				{
					AutoFade.LoadLevel("LevelSelect");
					Misc.NumberOfKills = 0;
					Misc.GamePaused = false;
				}
			}
		}
	}
}

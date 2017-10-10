using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelSelector : MonoBehaviour {
	
	GUIStyle Style;
	// Use this for initialization
	void Start () {
		Style = new GUIStyle();
		Style.fontSize = 20;
		Style.normal.textColor = Color.white;
	}
	
	public string LevelId;
	
	void OnGUI()
	{
		GUI.skin.button = null;
		if (GUI.Button(new Rect(10,5,Misc.ButtonWidth,Misc.ButtonHeight), TextureCollection.Instance.GetTexture("icon_home")))
		{
			MusicPlayer.PlaySound("menuSound");
			AutoFade.LoadLevel("Title");
		}
		DisplayLevels();
		/*
		DisplayLevel("Level1", null, new Rect(startX, startY, width, height));
		DisplayLevel("Level2", "Level1", new Rect(startX + width + delta, startY, width, height));
		DisplayLevel("Level3", "Level2", new Rect(startX + 2 *(width + delta), startY, width, height));
		DisplayLevel("Level4", "Level3", new Rect(startX + 3 *(width + delta), startY, width, height));
		DisplayLevel("Level5", "Level4", new Rect(startX, startY + height + delta, width, height));
		DisplayLevel("Level6", "Level5", new Rect(startX + width + delta, startY + height + delta, width, height));
		DisplayLevel("Level7", "Level6", new Rect(startX + 2* (width + delta), startY + height + delta, width, height));
		DisplayLevel("Level8", "Level7", new Rect(startX + 3* (width + delta), startY + height + delta, width, height));
		// start new row
		DisplayLevel("Level9", "Level8", new Rect(startX , startY + 2*(height + delta), width, height));
		DisplayLevel("Level10", "Level9", new Rect(startX + (width + delta), startY + 2*(height + delta), width, height));
		*/
	}
	
	void DisplayLevels()
	{
		float width = Misc.ButtonWidth*1.5f, height = Misc.ButtonHeight*1.5f
			, delta = 10, startX = 10, startY = Misc.ButtonHeight+10;
		int levelCount=1;
		for (int i=0; i<4; ++i)
		{
			for (int j=0; j<4; ++j)
			{
				DisplayLevel(string.Format("Level{0}", levelCount), levelCount == 1 ? null : string.Format("Level{0}", levelCount-1)
				             , new Rect(startX + j*(width + delta), startY +i*(height + delta), width, height));
				levelCount++;
				if (levelCount > Level.LevelCount) return;
			}
		}
	}
	
	void DisplayLevel(string name, string levelCheck, Rect rect)
	{
		if (levelCheck == null || SaveData.GetBestTime(levelCheck) > 0)
		{
			if (GUI.Button(rect, TextureCollection.Instance.GetTexture(name)))
			{
				MusicPlayer.PlaySound("menuSound");
				AutoFade.LoadLevel(name);
			}
			float bestTime = SaveData.GetBestTime(name);
			GUI.Label(new Rect(rect.x, rect.y+rect.height-20, rect.width, rect.height), bestTime.ToString());
		}
		else {
			GUI.Button(rect, TextureCollection.Instance.GetTexture("icon_lock"));
		}
		GUI.Label(rect, name, Style);
	}
}

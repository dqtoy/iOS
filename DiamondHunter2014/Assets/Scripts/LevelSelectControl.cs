using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelSelectControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		BackButton = GameObject.Find("Back").guiTexture;
		NextButton = GameObject.Find("Next").guiTexture;
		PrevButton = GameObject.Find("Previous").guiTexture;
		
		TextManager.MoveInfoDisplays = false;
		Entities = new List<GameObject>();
		for (int i=0; i<=9; ++i)
		{
			Entities.Add((GameObject)Resources.Load(i.ToString()));
		}
		Bursts = (GameObject)Resources.Load("burst");
		CurrentPage = 0;
		Levels = new List<GameObject>();
		LoadLevelSelects();
		
	}
	
	List<GameObject> Entities;
	List<GameObject> Levels;
	float rows=3, cols=4;
	void LoadLevelSelects()
	{
		foreach(var l in Levels)
		{
			LoadBurst(l.transform.position);
			Destroy(l);
		}
		Levels.Clear();
		var level = Resources.Load("Level");
		float x=8, y=26, z=6, dX=1.8f, dZ=3;
		int entityId = 0;
		for (int i=0; i<3; ++i)
		{
			for (int j=0; j<4; ++j)
			{
				Vector3 pos = new Vector3(x+j*dX, y, z-i*dZ);
				Levels.Add((GameObject)Instantiate(Entities[Rand.Instance.Next(0, Entities.Count-1)], pos, Quaternion.identity));
				if (entityId % 10 == 0) entityId = 0;
				float lev = j+i*cols+CurrentPage*rows*cols;
				Levels[Levels.Count-1].name = string.Format("{0}", lev+1);
				Levels[Levels.Count-1].transform.localScale *= (lev < Misc.Instance.NumberOfLevelsCompleted) ? 0.8f : 0.2f;
				//if (lev + 1 == Misc.Instance.NumberOfLevelsCompleted) return;
			}
		}
		loadText = false;
	}
	int CurrentPage;
	
	void LoadBurst(Vector3 position)
	{
		var go = (GameObject)Instantiate(Bursts, position, Quaternion.identity);
		Destroy(go, 3);
	}
	
	int maxLevels = 50;
	GameObject Bursts;
	GUITexture BackButton, NextButton, PrevButton;
	
	float buttonClick;
	
	// Update is called once per frame
	void Update () {
		if (buttonClick > Time.timeSinceLevelLoad) return;
		
		Vector3 pos = Vector3.zero;
		
		if (Input.touches.Count() > 0)
			pos = Input.touches[0].position;
		else if (Input.GetMouseButtonDown(0))
			pos = Input.mousePosition;
		if (pos != Vector3.zero)
		{
			if (BackButton.HitTest(pos))
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				buttonClick = Time.timeSinceLevelLoad + 0.3f;
				AutoFade.LoadLevel("Title");
			}
			if (NextButton.enabled && NextButton.HitTest(pos) && ((CurrentPage+1)*rows*cols <= maxLevels))
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				buttonClick = Time.timeSinceLevelLoad + 0.3f;
				CurrentPage++;
				LoadLevelSelects();
				loadText = false;
			}
			if (PrevButton.enabled && PrevButton.HitTest(pos) && CurrentPage - 1 >= 0)
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				buttonClick = Time.timeSinceLevelLoad + 0.3f;
				CurrentPage--;
				LoadLevelSelects();
				loadText = false;
			}
		}
		PrevButton.enabled = CurrentPage > 0;
		NextButton.enabled = ((CurrentPage+1)*rows*cols <= maxLevels);
		
		var go = GameControl.GetPointFromXY(pos);
		if (go != null)
		{
			try 
			{
				int lev = int.Parse(go.name);
				if (lev <= Misc.Instance.NumberOfLevelsCompleted)
				{
					GameControl.StartingLevel = lev;
					MusicPlayer.PlaySound(SoundType.Touches);
					Misc.Mode = GameMode.Puzzle;
					buttonClick = Time.timeSinceLevelLoad + 0.3f;
					TextManager.MoveInfoDisplays = true;
					AutoFade.LoadLevel("Game");
				}
				else 
					MusicPlayer.PlaySound(SoundType.WrongMove);
			}
			catch {}
		}
		if (!loadText)
		{
			TextManager.ClearInfoDisplays();
			foreach(var o in Levels)
			{
				string id = o.name;
				TextManager.SetInfoText(id, id + "   ", Camera.main.WorldToScreenPoint( o.transform.position), false);
			}
			loadText = true;
		}
	}
	
	bool loadText;
}

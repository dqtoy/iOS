using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class TextManager : MonoBehaviour
{
	private UITextInstance text2;
	private UITextInstance text3;
	private UITextInstance text4;
	
	private UITextInstance textWrap1;
	private UITextInstance textWrap2;
	
	public bool setLowAsciiForcingMode = true;
	public string highAsciiString = char.ConvertFromUtf32( 8220 ) + "Grand Central Station" + char.ConvertFromUtf32( 8221 );
	
	void Update()
	{
		if (Misc.GamePaused) return;
		if (Application.loadedLevelName != "LevelSelect")
		{
			if (Misc.Mode == GameMode.Arcade)
			{
				instance.text = string.Format("High Score: {3}\nScore: {0}        \nLevel: {2}/{4}      \nTime: {1}      "
			                              , GameControl.Score
			                              , GameControl.GameTime.ToString("0.00")
			                              , GameControl.Level
			                              , Misc.Instance.HighScore > GameControl.Score ? Misc.Instance.HighScore : GameControl.Score
			                              , Misc.Instance.HighLevel > GameControl.Level ? Misc.Instance.HighLevel : GameControl.Level
			                              );
			}
			else 
			{
				instance.text = string.Format("High Score: {3}\nScore: {0}        \nLevel: {2}      \nMoves: {5}/{6}      "
			                              , GameControl.Score
			                              , GameControl.GameTime.ToString("0.00")
			                              , GameControl.Level
			                              , Misc.Instance.HighScore > GameControl.Score ? Misc.Instance.HighScore : GameControl.Score
			                              , Misc.Instance.HighLevel > GameControl.Level ? Misc.Instance.HighLevel : GameControl.Level
				                          , Misc.PuzzleMoveCount
				                          , Misc.MaximumMoveCount
			                              );
			}
			if (Misc.Instance.TutorialMode && !string.IsNullOrEmpty(GameControl.TutorialText))
			{
				tutorial.text = GameControl.TutorialText ;
			}
			if (!string.IsNullOrEmpty(tutorial.text))
				tutorial.text += "\n                              \n                              \n                              \n                              ";;
		}
		
		foreach(var info in GameInfoDisplays)
		{
			if (MoveInfoDisplays && Misc.TimeInLevel - info.TimeStarted > 1)
			{
				info.Id = null;
				//info.UiText.text = "";
				info.Text = null;
				info.UiText.text = "    ";
			}
			else if (info.Text != null)
			{
				info.UiText.text = info.Text;
				if (MoveInfoDisplays)
					info.UiText.yPos -= 1;
			}
		}

	}
	
	UIText text;
	UITextInstance instance, tutorial, levelSelect;
	static UITextInstance debugText;
	public static void DebugText(string text)
	{
		if (debugText != null && text != null)
			debugText.text = text;
	}
	
	public static void ClearInfoDisplays()
	{
		foreach(var o in GameInfoDisplays)
			o.Id = null;
	}
	
	static List<GameInfo> GameInfoDisplays;
	public static bool MoveInfoDisplays = true;
	
	public static void SetInfoText(string id, string text, Vector3 position, bool moveInfoDisplays)
	{
		MoveInfoDisplays = moveInfoDisplays;
		SetInfoText(id, text, position);
	}
	public static void SetInfoText(string id, string text, Vector3 position)
	{
		return;//
		if (!GameInfoDisplays.Any(i=>i.Id == id))
		{
			if (!GameInfoDisplays.Any(i=>string.IsNullOrEmpty(i.Id))) return;
			GameInfoDisplays.Where(i=>string.IsNullOrEmpty(i.Id)).First().Id = id;
		}
		var info = GameInfoDisplays.Where(i=>i.Id == id).First();
		info.Text = text;
		info.Position = position;
		info.UiText.xPos = position.x;
		info.UiText.yPos = Misc.Instance.ScreenHeight - position.y;
		//info.UiText.textScale = 0.25f;//CalculateScale(distance);
		info.TimeStarted = Misc.TimeInLevel;
	}

	void Start()
	{
		// setup our text instance which will parse our .fnt file and allow us to
		text = new UIText( "prototype", "prototype.png" );
		
		
		// spawn new text instances showing off the relative positioning features by placing one text instance in each corner
		var x = UIRelative.xPercentFrom( UIxAnchor.Left, 0f, 0 );
		var y = UIRelative.yPercentFrom( UIyAnchor.Top, 0f, 0 );
		// Uses default color, scale, alignment, and depth.
		instance = text.addTextInstance( "", x, y );
		tutorial = text.addTextInstance("", Misc.Instance.ScreenWidth/10, Misc.Instance.ScreenHeight/2);
		debugText = text.addTextInstance("", 10, 0);
		debugText.localScale *= 0.5f;
		GameInfoDisplays = new List<GameInfo>();
		for (int i=0; i<20; ++i)
			GameInfoDisplays.Add(new GameInfo() {UiText = text.addTextInstance("", 0, 0)});

	}
	

}

public class GameInfo
{
	public UITextInstance UiText;
	public string Text;
	public Vector3 Position;
	public string Id;
	public float TimeStarted;
}
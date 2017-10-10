using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TitleControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		if (!Misc.Instance.MusicMute)
			MusicPlayer.Instance.Play();
		else 
			MusicPlayer.Instance.Stop();
		
		Misc.GamePaused = false;
		StartButton = GameObject.Find("GameStart").guiTexture;
		OptionsButton = GameObject.Find("Options").guiTexture;
		PuzzleButton = GameObject.Find("GameStartPuzzle").guiTexture;
		OptionsButton.enabled = StartButton.enabled = PuzzleButton.enabled = false;  
		//if (Misc.Style == GameStyle.Lite)
		//	PuzzleButton.enabled = false;

		//if (Misc.Style == GameStyle.Lite)
		//	EtceteraBinding.askForReview(5, 24, "Please review!", "How do you like the game?", "http://itunes.apple.com/us/app/bespangledlite/id495611005?ls=1&mt=8");
		//else		
		//	EtceteraBinding.askForReview(5, 24, "Please review!", "How do you like the game?", "http://itunes.apple.com/us/app/bespangled!/id495606280?ls=1&mt=8");
	}
	
	float buttonTime=4;
	
	GUITexture StartButton, OptionsButton, PuzzleButton;
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < buttonTime) return;
		if (!OptionsButton.enabled) OptionsButton.enabled = StartButton.enabled = PuzzleButton.enabled =true;
		//if (Misc.Style == GameStyle.Lite)
		//	PuzzleButton.enabled = false;
		Vector3 pos = Vector3.zero;
		
		if (Input.touches.Count() > 0)
			pos = Input.touches[0].position;
		else if (Input.GetMouseButtonDown(0))
			pos = Input.mousePosition;
		if (pos != Vector3.zero)
		{
			if (StartButton.HitTest(pos))
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				buttonTime = Time.timeSinceLevelLoad + 0.3f;
				Misc.Mode = GameMode.Arcade;
				GameControl.StartingLevel = null;
				TextManager.MoveInfoDisplays = true;
				AutoFade.LoadLevel("Game");
			}
			else if ( PuzzleButton.HitTest(pos))
			{
				//MusicPlayer.PlaySound(SoundType.WrongMove);
				buttonTime = Time.timeSinceLevelLoad + 0.3f;
				//return;
				MusicPlayer.PlaySound(SoundType.Touches);
				Misc.Mode = GameMode.Puzzle;
				TextManager.MoveInfoDisplays = true;
				AutoFade.LoadLevel("Game");
			}
			else if (OptionsButton.HitTest(pos))
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				buttonTime = Time.timeSinceLevelLoad + 0.3f;
				AutoFade.LoadLevel("Options");
			}
		}
	}
}

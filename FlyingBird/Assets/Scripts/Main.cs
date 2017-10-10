// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace MyBird
{
	public static class Main
	{
		public static bool GameStarted = false;
		public static bool GameEnded = false;
		public static float ScoreTime = 0, GameMovingSpeedDefault = 1.15f, GameMovingSpeed = 0.15f, GameMovingSpeedDelta = 0.01f, ObstacleLoadTime = 2, AnimalLoadTime = 1.9f;
		public static int Score = 0, ScoreDelta = 1, TimeToChangeSpeed = 3;
		
		static float TimeStarted, GameOverTime, BombTime;

		public static bool GameRunning {
			get { return GameStarted && !GameEnded;}
		}

		
		public static void SetGuiTextureInset(GUITexture texture)
		{
			float textureHeight = texture.pixelInset.height;
			float textureWidth = texture.pixelInset.width;
			float screenHeight = Screen.height;
			float screenWidth = Screen.width;
			
			float widthDelta = screenWidth / 720;
			float heightDelta = screenHeight / 480;
			
			float scaledHeight;
			float scaledWidth;
			scaledWidth = textureWidth * widthDelta;
			scaledHeight = textureHeight * heightDelta;
			
			float xPosition = texture.pixelInset.x / 635 * screenWidth;// screenWidth / 2 - (scaledWidth / 2);
			float yPosition = texture.pixelInset.y / 476 * screenHeight;// (float)(screenHeight - scaledHeight) / 2.0f;
			texture.pixelInset = new Rect(xPosition, yPosition, (int)scaledWidth, (int)scaledHeight);
			Debug.Log (screenWidth + ", " + screenHeight);
		}



		public static void StartGame(){
			GameStarted = true;
			GameEnded = false;
			Score = 0;
			GameMovingSpeed = GameMovingSpeedDefault;
			ScoreTime = 0;
			BombTime = 0;
			ObstacleLoadTime = 2;
			AnimalLoadTime = 1.8f;
			TimeStarted = Time.timeSinceLevelLoad;
			//HighScore = PlayerPrefs.HasKey ("score") ? int.Parse(PlayerPrefs.GetString ("score")) : 0;
		}

		public static void IncreaseGameSpeed()
		{
			if ((int)TimeInLevel % TimeToChangeSpeed == 0)
				GameMovingSpeed += GameMovingSpeedDelta;
			UpdateOtherTimes (5, 1.1f, 1.05f);
			UpdateOtherTimes (7, 0.5f, 0.5f);
			UpdateOtherTimes (8, 0.35f, 0.33f);
			UpdateOtherTimes (9, 0.28f, 0.25f);
			UpdateOtherTimes (10, 0.2f, 0.18f);
			UpdateOtherTimes (11, 0.15f, 0.13f);
			UpdateOtherTimes (12, 0.13f, 0.12f);
		}

		static void UpdateOtherTimes(float threshold, float oLT, float aLT)
		{
			if (GameMovingSpeed > threshold){
				ObstacleLoadTime = oLT;
				AnimalLoadTime = aLT;
			}
		}
		
		public static bool IsTextureTouched(GUITexture texture)
		{
			return texture.enabled && ((Input.GetMouseButtonDown (0) && texture.HitTest(Input.mousePosition, Camera.main))
			                           || (Input.touches.Length > 0 && texture.HitTest(Input.GetTouch(0).position, Camera.main)));
		}

		public static bool IsCursorOverTexture(GUITexture texture)
		{
			return texture.HitTest (Input.mousePosition, Camera.main);
		}

		
		public static bool IsTextureTouchedReleased(GUITexture texture)
		{
			return IsTextureTouchedReleased (texture, false);
		}

		public static bool IsTextureTouchedReleased(GUITexture texture, bool PlaySound)
		{
			if (PlaySound && texture.enabled && ((Input.GetMouseButtonDown (0) && texture.HitTest(Input.mousePosition, Camera.main))
			                        || (Input.touches.Length > 0 && Input.GetTouch(0).phase == TouchPhase.Began && texture.HitTest(Input.GetTouch(0).position, Camera.main)))
			    )
				MyBird.MusicPlayer.PlaySound(SoundType.Thud);
			return texture.enabled && ((Input.GetMouseButtonUp (0) && texture.HitTest(Input.mousePosition, Camera.main))
			                           || (Input.touches.Length > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && texture.HitTest(Input.GetTouch(0).position, Camera.main)));
		}

		static bool? _IsiDevice;
		public static bool IsiDevice
		{
			get {
				if (_IsiDevice == null)
					_IsiDevice = iPhone.generation.ToString ().StartsWith ("iPad") || iPhone.generation.ToString ().StartsWith ("iPhone");
				return _IsiDevice ?? false;
			}
		}

		static float _flightTime, _deltaFlightTime = 0.05f;
		public static bool IsInFlight {
				get { return Time.timeSinceLevelLoad - _flightTime <= _deltaFlightTime;}
		}

		public static void SetFlightTime()
		{
			_flightTime = Time.timeSinceLevelLoad;
		}


		public static bool IsIpad
		{
			get {
								return iPhone.generation.ToString ().StartsWith ("iPad");
						}
		}

		public static bool IsFirstTimePlayed
		{
			get { return !PlayerPrefs.HasKey ("IsFirstTimePlayed");}
		}

		public static void SetFirstTimePlayed()
		{
			PlayerPrefs.SetInt ("IsFirstTimePlayed", 1);
		}

		public static string PreviousScene;

		public static void RestartGame()
		{
			StartGame ();
			GameStarted = false;
		}

		public static void SetBombTime()
		{
			BombTime = Time.timeSinceLevelLoad;
		}

		public static float TimeSinceBombed
		{
			get {return Time.timeSinceLevelLoad - BombTime;}
		}

		public static float TimeInLevel
		{
			get { return Time.timeSinceLevelLoad - TimeStarted;}
		}

		public static float TimeSinceGameOver
		{
			get { return Time.timeSinceLevelLoad - GameOverTime;}
		}

		public static float TimeSinceScored
		{
			get { return ScoreTime > 0 ? Time.timeSinceLevelLoad - ScoreTime : 100;}
		}

		public static bool ScoreUpdated;
		public static void UpdateScore()
		{
			MusicPlayer.PlaySound(SoundType.Coin);
			Score += ScoreDelta;
			ScoreTime = Time.timeSinceLevelLoad;
			ScoreUpdated = true;
		}

		public static string GetText(string text, string color, int size)
		{
			return string.Format ("<color={0}><size={1}>{2}</size></color>", color, size, text);
		}

		public static string CurrentScore
		{
			get {return string.Format("Score: {0} {1}", Score, HighCurrentScore);}
		}
		
		public static string HighCurrentScore
		{
			get {return string.Format("High Score: {0}", HighScore);}
		}

		public static void EndGame()
		{
			GameEnded = true;
			GameOverTime = Time.timeSinceLevelLoad;
			if (HighScore < Score) {
				PlayerPrefs.SetString ("score",  Score.ToString());
				PlayerPrefs.Save ();
			}
		}

		public static HandednessType Handedness
		{ 
			get { return PlayerPrefs.HasKey ("Handedness") && PlayerPrefs.GetString ("Handedness") == HandednessType.Left.ToString() ? HandednessType.Left : HandednessType.Right;}
		}

		public static void ToggleHandedness()
		{
			// toggle the handedness when set
			HandednessType which = Handedness == HandednessType.Left ? HandednessType.Right : HandednessType.Left;
			PlayerPrefs.SetString ("Handedness", which.ToString());
			PlayerPrefs.Save();
		}

		public static string CurrentSong
		{
			get { return PlayerPrefs.HasKey ("Song") ? PlayerPrefs.GetString ("Song") : "NoSong";}
			set 
			{
				PlayerPrefs.SetString ("Song", value);
				PlayerPrefs.Save();
			}
		}

		public static int HighScore 
		{
			get {return PlayerPrefs.HasKey ("score") ? int.Parse(PlayerPrefs.GetString ("score")) : 0;}
		}
	}

	public enum HandednessType
	{
		Left, 
		Right
	}

	public enum SoundType
	{
		Flap, 
		Menu,
		Default,
		Explosion,
		Coin,
		Thud,
		Song1,
		Song2
	}

}


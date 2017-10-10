using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
	public GUIStyle style;

	
	void OnGUI()
	{
		GUI.skin.button = style;
		if (GUI.Button(new Rect(10,5,Misc.ButtonWidth,Misc.ButtonHeight), "Back"))
		{
			MusicPlayer.PlaySound("Click");
			AutoFade.LoadLevel("Title");
		}
		//GUI.Label(new Rect(30, 80, 100, 50), "Select Music");
		if (GUI.Button(new Rect(20, 30+Misc.ButtonHeight, Misc.ButtonWidth, Misc.ButtonHeight), "Music 1"))
		{
			PlayTrack("BGMusic1");
		}
		if (GUI.Button(new Rect(20, 30+2*Misc.ButtonHeight, Misc.ButtonWidth, Misc.ButtonHeight), "Music 2"))
		{
			PlayTrack("BGMusic2");
		}
		if (GUI.Button(new Rect(20, 30+3*Misc.ButtonHeight, Misc.ButtonWidth, Misc.ButtonHeight), "Music 3"))
		{
			PlayTrack("BGMusic3");
		}
		if (GUI.Button(new Rect(30+Misc.ButtonWidth, 30+Misc.ButtonHeight, Misc.ButtonWidth + 60, Misc.ButtonHeight), string.Format("Turn Music {0}", SaveData.IsMusicOn ? "Off" : "On")))
		{
			SaveData.ToggleMusicOnOff();
			if (SaveData.IsMusicOn)
				MusicPlayer.Instance.Play();
			else
				MusicPlayer.Instance.Stop();
		}
		if (GUI.Button(new Rect(30+Misc.ButtonWidth, 30+2*Misc.ButtonHeight, Misc.ButtonWidth + 60, Misc.ButtonHeight), "Reset Settings"))
		{
			SaveData.Reset();
		}
	}
	
	void PlayTrack(string name)
	{
		MusicPlayer.Instance.Stop();
		SaveData.SetCurrentMusic(name);
		MusicPlayer.Instance.LoadNewTrack();
	}
}

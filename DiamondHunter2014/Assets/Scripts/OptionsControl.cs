using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OptionsControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BackButton = GameObject.Find("Back").guiTexture;
		Music1 = GameObject.Find("SoundTitle").guiTexture;
		Music2 = GameObject.Find("SoundTitle2").guiTexture;
		Music3 = GameObject.Find("SoundTitle3").guiTexture;
		Mute = GameObject.Find("Mute").guiTexture;
		Reset = GameObject.Find("Reset").guiTexture;
	
	}
	
	GUITexture BackButton, Music1, Music2, Music3, Mute, Reset;
	
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
			else if (Music1.HitTest(pos))
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				MusicPlayer.Instance.PlayNewSong(Music1.name);
				buttonClick = Time.timeSinceLevelLoad + 0.3f;
			}
			else if (Music2.HitTest(pos))
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				buttonClick = Time.timeSinceLevelLoad + 0.3f;
				MusicPlayer.Instance.PlayNewSong(Music2.name);
			}
			else if (Music3.HitTest(pos))
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				buttonClick = Time.timeSinceLevelLoad + 0.3f;
				MusicPlayer.Instance.PlayNewSong(Music3.name);
			}
			else if (Mute.HitTest(pos))
			{
				Misc.Instance.MusicMute = !Misc.Instance.MusicMute;
				buttonClick = Time.timeSinceLevelLoad + 0.3f;
				MusicPlayer.PlaySound(SoundType.Touches);
				MusicPlayer.Instance.TogglePlay();
			}
			else if (Reset.HitTest(pos))
			{
				MusicPlayer.PlaySound(SoundType.Touches);
				buttonClick = Time.timeSinceLevelLoad + 0.3f;
				PlayerPrefs.DeleteAll();
			}
		}
	}
}

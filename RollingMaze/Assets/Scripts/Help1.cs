using UnityEngine;
using System.Collections;

public class Help1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TextManager.LoadGui();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touches.Length > 0 || Input.GetMouseButtonDown(0))
		{
			AutoFade.LoadLevel("Level1");
			SaveData.ShowHelp = false;
		}
		TextManager.SetHudText("help1", "Collect all to pass level\n\nCollect these to buy power ups");
		TextManager.SetHudText("help2", "For best playing experience hold device\nupright and rotate to move ball\nFor more sensitive controls hold device\nparallel with the ground and tilt\nTouch to start!");
	}
	
	
}

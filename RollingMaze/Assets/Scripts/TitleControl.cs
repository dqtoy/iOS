using UnityEngine;
using System.Collections;

public class TitleControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.Button(new Rect(10, 10, 100, 100), "Options");
	}
}

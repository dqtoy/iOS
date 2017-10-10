using UnityEngine;
using System.Collections;

public class MessageControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		timeLoaded= Misc.TimeInLevel + 1;
	}
	
	float timeLoaded;
	// Update is called once per frame
	void FixedUpdate () {
		if (timeLoaded < Misc.TimeInLevel)
			Destroy(gameObject);
		else 
			transform.position += 0.04f * Vector3.forward + 0.02f * Vector3.up;
	}
}

using UnityEngine;
using System.Collections;

public class EggCrackedBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		timeBegin = Time.timeSinceLevelLoad;
	}

	float timeBegin;
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.timeSinceLevelLoad - timeBegin > 1)
						Destroy (gameObject);
	}
}

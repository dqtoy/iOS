using UnityEngine;
using System.Collections;

public class ShadowControl : MonoBehaviour {
	
	Transform theBall;
	// Use this for initialization
	void Start () {
		theBall = GameObject.Find("Ball(Clone)").transform;
	}
	
	void LateUpdate(){
		transform.Translate(theBall.position);
	}
}

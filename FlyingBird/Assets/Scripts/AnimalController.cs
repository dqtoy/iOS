using UnityEngine;
using System.Collections;
using MyBird;
using System.Collections.Generic;

public class AnimalController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	float DeadTime, DestroyTime = 1;
	bool IsDead = false;

	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		if (IsDead && Time.timeSinceLevelLoad - DeadTime > DestroyTime) {
						Destroy (gameObject);
				}
	}
	
	void OnTriggerEnter(Collider other) {
		ProcessCollision (other.gameObject);
	}
	
	void OnCollisionEnter(Collision collision) {
		ProcessCollision (collision.gameObject);
	}

	void ProcessCollision(GameObject go)
	{
		if (!IsDead && go.tag == "Egg") {
			GetComponent<Animator>().SetBool("Dead", true);
			GetComponent<Animator>().SetBool("Idle", false);
			audio.Play();
			IsDead = true;
			DeadTime = Time.timeSinceLevelLoad;
			Main.UpdateScore();
			string name = go.renderer != null && go.renderer.material != null ? go.renderer.material.mainTexture.name : "0";
			Instantiate((GameObject)Resources.Load (string.Format("egg_cracked{0}", name[name.Length-1])), gameObject.transform.position, Quaternion.identity);
			Destroy(go);
		}
	}


}

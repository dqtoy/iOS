using UnityEngine;
using System.Collections;
using MyBird;

public class BombBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TimeBegin = Time.timeSinceLevelLoad;
		if (gameObject.renderer.material.mainTexture == null)
			gameObject.renderer.material.mainTexture = (Texture)Resources.Load ("egg_color0");
	}

	float TimeBegin;
	bool IsFloored;

	float TimeSinceBegin {
				get { return Time.timeSinceLevelLoad - TimeBegin;}
		}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		if (TimeSinceBegin > 1)
			Destroy (gameObject);
	}
	
	void OnCollisionEnter(Collision collision) {
		if (!IsFloored && collision.gameObject.tag == "Floor") {
			IsFloored = true;
			
			MyBird.MusicPlayer.PlaySound(SoundType.Thud);
			string name = gameObject != null && gameObject.renderer != null && gameObject.renderer.material != null 
				&& gameObject.renderer.material.mainTexture != null ? gameObject.renderer.material.mainTexture.name : "0";
			Instantiate((GameObject)Resources.Load (string.Format("egg_cracked{0}", name[name.Length-1])), gameObject.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

}

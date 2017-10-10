using UnityEngine;
using System.Collections;
using MyBird;

public class HelpBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		BombTexture = GetTexture ("Drop");
		BackTexture = GetTexture ("Back");
		HelpTexture = GetTexture ("Help_Overlay_GUI");
		EggObject = Resources.Load<GameObject>("Egg");
		Chicken = GameObject.Find("chicken");
		random = new System.Random ();
		Main.SetGuiTextureInset (BombTexture);
		Main.SetGuiTextureInset (BackTexture);
		Main.SetGuiTextureInset (HelpTexture);
	}
	
	GUITexture GetTexture(string name)
	{
		return (GUITexture)GameObject.Find (name).GetComponent<GUITexture> ();;
	}

	GUITexture BombTexture, BackTexture, HelpTexture;
	GameObject EggObject, Chicken;
	System.Random random;
	bool touched, touchReleased, bombTouched;
	// Update is called once per frame
	void Update () {
		
		if (Main.IsiDevice) {
			if (touched && Input.touchCount == 0)
			{
				touchReleased = true;
				touched = false;
			}
			if (!touched && Input.touchCount > 0)
			{
				touched = true;
				touchReleased = false;
			}
		} else {
			if (touched && Input.GetMouseButtonUp(0))
			{
				touchReleased = true;
				touched = false;
			}
			if (!touched && Input.GetMouseButtonDown(0))
			{
				touched = true;
				touchReleased = false;
			}
		}
		if (Main.IsTextureTouchedReleased (BackTexture, true)) {
			AutoFade.LoadLevel (Main.PreviousScene != null ? Main.PreviousScene : "Level");
		} 
		bombTouched = Main.TimeSinceBombed > 0.5f && Main.IsTextureTouchedReleased(BombTexture, true);
	}

	void FixedUpdate()
	{
		if (bombTouched) {
			Instantiate(EggObject, Chicken.transform.position, Quaternion.identity);
			LoadEggTextures();
			bombTouched = false;
			Main.SetBombTime();
		}
	}

	
	void LoadEggTextures()
	{
		EggObject.renderer.material.mainTexture = Resources.Load<Texture>(string.Format("egg_color{0}", random.Next(100) % 3));
	}

}

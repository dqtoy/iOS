using UnityEngine;
using System.Collections;

public class GUITextureBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		texture = GetComponent<GUITexture> ();
		CurrentPosition = transform.position;
		DeltaPosition = new Vector3 (CurrentPosition.x + delta, CurrentPosition.y + delta, CurrentPosition.z);
		colorNormal = texture.color;
		colorTouched = new Color(0.2f, 0.2f, 0.2f);
	}

	GUITexture texture;
	Vector3 CurrentPosition, DeltaPosition;
	float delta = 0.005f, touchedTime;
	Color colorNormal, colorTouched;
	
	// Update is called once per frame
	void Update () {
		if (MyBird.Main.IsTextureTouched (texture)) {
			transform.position = DeltaPosition;
			texture.color = colorTouched;
		} else if (MyBird.Main.IsTextureTouchedReleased (texture) || !MyBird.Main.IsCursorOverTexture (texture)) {
			transform.position = CurrentPosition;
			texture.color = colorNormal;
		}
	}
}

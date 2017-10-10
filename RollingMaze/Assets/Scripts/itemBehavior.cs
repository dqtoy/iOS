using UnityEngine;
using System.Collections;

public class itemBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		collider.isTrigger = true;
	}
	
	public float CountDownTo = 1;
	public float CountDown = 0;
	public bool ItemTouched;
	float touchedRotationSpeed = 5, defaultRotationSpeed = 1;
	float touchedScaleSpeed = 2;
	public ItemType Type
	{
		get {
			if (name.StartsWith("Coin"))
				return ItemType.Coin;
			else
				return ItemType.Item;
		}
	}
	public string BallObjectName = "Ball";
	
	void OnTriggerEnter(Collider collider)
	{
		if (!ItemTouched && collider.gameObject.name.StartsWith(BallObjectName))
		{
			CountDown = Time.timeSinceLevelLoad;
			ItemTouched = true;
			if (ItemType.Coin == Type)
				MusicPlayer.PlaySound("coinSound");
			else
				MusicPlayer.PlaySound("whipSound");
			
			Transform theClonedBurst;
			theClonedBurst = Instantiate(Resources.Load("burst"), transform.position, transform.rotation) as Transform;
			theClonedBurst = Instantiate(Resources.Load("burst2"), transform.position, transform.rotation) as Transform;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (ItemType.Coin == Type)
		{
			transform.RotateAround(new Vector3(0,1,0), Time.deltaTime * (ItemTouched ? touchedRotationSpeed : defaultRotationSpeed));
		}
		else
		{
			transform.RotateAround(new Vector3(0,0,1), Time.deltaTime * (ItemTouched ? touchedRotationSpeed : defaultRotationSpeed));
			if (ItemTouched)
			{
				float val = Time.deltaTime * touchedScaleSpeed;
				transform.localScale -= (new Vector3(val, val, val));
				if (transform.localScale.x < 0)
					transform.localScale = Vector3.zero;
			}
		}
	}
}

public enum ItemType 
{
	Item, Coin
}

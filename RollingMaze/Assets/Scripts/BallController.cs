using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GamePaused = true;
	}
	
	bool _GamePaused;
	public bool GamePaused 
	{
		get {
			return _GamePaused;
		}
		set {
			_GamePaused = value;
			rigidbody.isKinematic = value;
		}
	}
	
	public bool ActionInProgress 
	{
		get {
			return PowActionToPosition != Vector3.zero;
		}
	}
	
	bool down, up, left, right, jump;
	void Update()
	{
		// using joystick input instead of iPhone accelerometer
		if (Input.GetKeyDown("d"))
			down = true;
		if (Input.GetKeyDown("w"))
			up = true;
		if (Input.GetKeyDown("a"))
			left = true;
		if (Input.GetKeyDown("s"))
			right = true;
		if (Input.GetKeyDown("j"))
			jump = true;

	}
	
	public Vector3 PowActionToPosition;
	float force = 10.0f;
	// Update is called once per frame
	void FixedUpdate () {
		if (GamePaused) 
		{
			return;
		}
		if (PowActionToPosition != Vector3.zero)
		{
			collider.enabled = false;
			rigidbody.useGravity = false;
			transform.position = Vector3.MoveTowards(transform.position, PowActionToPosition, Time.deltaTime*30);
			if (transform.position == PowActionToPosition)
			{
				PowActionToPosition = Vector3.zero;
				collider.enabled = true;
				rigidbody.useGravity = true;
			}
		}
		else
		{
			var dir  = Vector3.zero;
			dir.x = -Input.acceleration.y;
			dir.z = Input.acceleration.x;
			
			float testSpeed  = 10.0f;
			// using joystick input instead of iPhone accelerometer
			if (down)
			{
				dir.x = testSpeed;//.GetAxis("Horizontal");
				down = false;
			}
			if (up)
			{
				dir.z = testSpeed;
				up = false;
			}
			if (left)
			{
				dir.x = -testSpeed;//.GetAxis("Horizontal");
				left = false;
			}
			if (right)
			{
				dir.z = -testSpeed;
				right = false;
			}
			if (jump)
			{
				dir.y = testSpeed / 3;
				jump = false;
			}
			
			rigidbody.AddForce(dir * force);
		}
	
	}
}

public var force:float = 10.0;
public var simulateAccelerometer:boolean = false;

function Start()
{
	// make landscape view
	Screen.orientation = ScreenOrientation.Landscape;
}

function FixedUpdate () {
	var dir : Vector3 = Vector3.zero;
		
	// remap device acceleration axis to game coordinates
	// remap device acceleration axis to game coordinates
	// 1) XY plane of the device is mapped onto XZ plane
	// 2) rotated 90 degrees around Y axis
	dir.x = -Input.acceleration.y;
	dir.z = Input.acceleration.x;
	
	// clamp acceleration vector to unit sphere
	//if (dir.sqrMagnitude > 1)
	//	dir.Normalize();

	var testSpeed: float = 10.0f;
	// using joystick input instead of iPhone accelerometer
	if (Input.GetKeyDown("d"))
		dir.x = testSpeed;//.GetAxis("Horizontal");
	if (Input.GetKeyDown("w"))
		dir.z = testSpeed;
	if (Input.GetKeyDown("a"))
		dir.x = -testSpeed;//.GetAxis("Horizontal");
	if (Input.GetKeyDown("s"))
		dir.z = -testSpeed;
	
	rigidbody.AddForce(dir * force);
}


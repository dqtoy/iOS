var cameraTarget : Transform;

var Dist_x = 0;
var Dist_y = 20;
var Dist_z = 0;
var Angle = 90;


function ApplyTarget(Target )
{
    cameraTarget = Target;
}



function LateUpdate()
{
    transform.localEulerAngles.x = Angle;
    transform.position = Vector3(cameraTarget.position.x+Dist_x, cameraTarget.position.y+Dist_y, cameraTarget.position.z+Dist_z);
}
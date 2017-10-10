using UnityEngine;
using System.Collections;

namespace MyBird
{
	public class FloorScrolling : MonoBehaviour {

		// Use this for initialization
		void Start () {
			//IsObstacle = gameObject.tag == "Obstacle";
		}

		//bool IsObstacle;
		
		public static float Speed = 3.5f, MinZPosition = -24, MaxZPosition = 21;
		// Update is called once per frame
		void FixedUpdate () {
			if (!MyBird.Main.GameRunning)
				return;

			var newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - Main.GameMovingSpeed);
			transform.position = Vector3.MoveTowards(transform.position, newPos, Time.fixedDeltaTime * Main.GameMovingSpeed);
			// once reached the min threshold, move this one back ahead
			if (transform.position.z < MinZPosition) {

				transform.position = new Vector3(transform.position.x, transform.position.y, MaxZPosition);
			}
		}
			
	}
}


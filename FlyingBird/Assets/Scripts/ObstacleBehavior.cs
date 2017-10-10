using UnityEngine;
using System.Collections;

namespace MyBird
{
	public class ObstacleBehavior : MonoBehaviour {

		// Use this for initialization
		void Start () {
			FinalHeight = transform.position.y;
			//transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		}

		public float FinalHeight;
		
		// Update is called once per frame
		void Update () {
		
		}
		
		void FixedUpdate()
		{
			if (!MyBird.Main.GameRunning)
				return;

			var newPos = new Vector3(transform.position.x, transform.position.z < 5 ? FinalHeight : transform.position.y, transform.position.z - Main.GameMovingSpeed);
			transform.position = Vector3.MoveTowards(transform.position, newPos, Time.fixedDeltaTime * Main.GameMovingSpeed);
		}
	}
}
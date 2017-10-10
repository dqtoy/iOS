using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StartButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (IsFreeVersion)
			AdBinding.createAdBanner(true);
	}
	
	public static bool IsFreeVersion=true;
	// Update is called once per frame
	void Update () {
		processTouch ();
	}
	
	
	void processTouch ()
	{
		var touchPosition = Vector3.zero;
		if (Input.touches.Count() == 1)
	    	touchPosition = Input.touches[0].position;
		if (Input.GetMouseButtonDown(0))
			touchPosition = Input.mousePosition;

		if (touchPosition != Vector3.zero)
		{
			LoadTouchedItem(touchPosition);
		}
	}
	
	public static void LoadTouchedItem(Vector3 point)
	{
		var ray = Camera.main.ScreenPointToRay(point);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			if (hit.collider.tag == "Level")
			{
				TitleStart2.LoadBursts(hit.collider.transform.position);
				Destroy(hit.collider.gameObject);
				if (hit.collider.name == "Level1")
				{
					if (SaveData.ShowHelp)
						AutoFade.LoadLevel("Help1");
					else
						AutoFade.LoadLevel("Level1");
				}
				else
					AutoFade.LoadLevel(hit.collider.name);
			}
			//return hit.point;
		}
	}

}

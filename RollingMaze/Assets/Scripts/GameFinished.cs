using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameFinished : MonoBehaviour {

	// Use this for initialization
	System.Random Rand;
	Dictionary<GameObject, float> items;
	void Start () {
		Rand = new System.Random((int)(Time.time * 1000));
		TextManager.LoadGui();
		TextManager.SetHudText("gameFinished", "Thank you for playing!\nWe will have updates with new levels\nregularly!");
		items = new Dictionary<GameObject, float>();
	}
	
	void Update()
	{
		if (Input.touches.Length > 0 || Input.GetMouseButtonDown(0))
		{
			AutoFade.LoadLevel("Title");
		}
	}
	
	void FixedUpdate()
	{
		TextManager.SetHudText("gameFinished", "Thank you for playing!\nWe will have updates with \nnew levels regularly!\n\n--Rollin Maze Team");
		if (Rand.Next(0, 50) % 11 == 0)//(Time.timeSinceLevelLoad - (int)Time.timeSinceLevelLoad < 0.1f)
		{
			items.Add((GameObject)Instantiate(Resources.Load("burst")
			                                  , new Vector3(Rand.Next(-4, 8), 0, Rand.Next(1,5))
			                                  , transform.rotation)
			          , Time.timeSinceLevelLoad);
			items.Add((GameObject)Instantiate(Resources.Load("burst2")
			                                  , new Vector3(Rand.Next(-4, 8), 0, Rand.Next(1,5))
			                                  , transform.rotation)
			          , Time.timeSinceLevelLoad);
		}
		foreach(var go in items.Where(i=>Time.timeSinceLevelLoad - i.Value > 2).ToList())
		{
			items.Remove(go.Key);
			Destroy(go.Key);
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ShopControl : MonoBehaviour {
	
	public GUIStyle style;
	
	int Coins;
	GUIStyle Style;
	string Messsage;
	// Use this for initialization
	void Start () {
		Coins = SaveData.GetCoinCount();
		Style = new GUIStyle();
		Style.fontSize = 20;
		Style.normal.textColor = Color.yellow;
		TextManager.LoadGui();
	}
	
	
	void OnGUI()
	{
		GUI.skin.button = style;
		
		//GUI.Label(new Rect(300, 10, 200, 50), string.Format("   {0}", Coins), Style);
		TextManager.SetHudText("shopCoins", string.Format("      {0}    ", Coins));
		int startX = 50, startY = Misc.ButtonHeight+10;
		if (GUI.Button(new Rect(10,10,Misc.ButtonWidth,Misc.ButtonHeight), TextureCollection.Instance.GetTexture("icon_home")))
		{
			MusicPlayer.PlaySound("menuSound");
			AutoFade.LoadLevel("Title");
		}
		if (false && GUI.Button(new Rect(10 + Misc.ButtonWidth,10,Misc.ButtonWidth,Misc.ButtonHeight), TextureCollection.Instance.GetTexture("icon_buy")))
		{
			MusicPlayer.PlaySound("coinSound");
			Coins += 100;
			SaveData.AddCoinsCollected(100);
		}
		DisplayItem("pow", "icon_lightning", "Finds nearest item", new Rect(startX, startY, Misc.ButtonWidth*2,Misc.ButtonHeight*2), CostControl.Pow, true);
		//DisplayItem("hop", "icon_lock", "Coming soon!", new Rect(startX + width, startY, width, height), CostControl.Hop, false);
		if (Messsage != null)
		{
			//GUI.Label(new Rect(300, 100, 200, 50), Messsage, Style);
			TextManager.SetHudText("shopItemResult", string.Format("{0}             ", Messsage));
		}
	}
	
	void DisplayItem(string name, string texture, string description, Rect rect, int cost, bool available)
	{
		if (GUI.Button(rect, TextureCollection.Instance.GetTexture(texture)) && available)
		{
			if (Coins < cost)
				Messsage ="Not enough!";
			else
			{
				MusicPlayer.PlaySound("coinSound");
				Messsage = "Thanks!";
				SaveData.SubtractCoinsCollected(cost);
				SaveData.AddItemCollected(name);
				Coins -= cost;
			}
		}
		else
		{
			//GUI.Label(new Rect(rect.x, rect.y + rect.height + 10, 100, 50), string.Format("Cost: {0}", cost), Style);
			//GUI.Label(new Rect(rect.x, rect.y + rect.height + 30, 500, 50), description, Style);
			TextManager.SetHudText("shopItemDescription", string.Format("Cost: {0}\n{1}", cost, description));
		}
	}
}

public static class CostControl
{
	public static int Pow = 10;
	public static int Hop = 10;
}
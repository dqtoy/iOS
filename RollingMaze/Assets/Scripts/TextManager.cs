using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MNProductions.Maze.Enums;

public class TextManager : MonoBehaviour
{
	private UITextInstance text2;
	private UITextInstance text3;
	private UITextInstance text4;
	
	private UITextInstance textWrap1;
	private UITextInstance textWrap2;
	
	public bool setLowAsciiForcingMode = true;
	public LevelName Level;
	public string highAsciiString = char.ConvertFromUtf32( 8220 ) + "Grand Central Station" + char.ConvertFromUtf32( 8221 );
	
	void Update()
	{
		//if (HudText != null)
		//	instance.text = HudText;
		foreach (var key in HudTextInstance.Keys)
			HudTextInstance[key].text = HudText[key];
	}
	
	public static void LoadGui()
	{
		Instantiate(Resources.Load("UI"), Vector3.zero, Quaternion.identity);
		Instantiate(Resources.Load("UiGui"), Vector3.zero, Quaternion.identity);
	}
	
	static Dictionary<string,string> _HudText;
	static Dictionary<string,string> HudText {get {return (_HudText ?? (_HudText = new Dictionary<string, string>()));}}
	
	static Dictionary<string,UITextInstance> _HudTextInstance;
	static Dictionary<string,UITextInstance> HudTextInstance {get {return (_HudTextInstance ?? (_HudTextInstance = new Dictionary<string, UITextInstance>()));}}
	
	public static void SetHudText(string name, string value)
	{
		HudText[name] = value;
	}
	
	public static void SetHudInstance(string name, int x, int y, float scale)
	{
		var go = GameObject.Find("UiGui(Clone)").GetComponent<TextManager>();
		SetHudInstance(name, go.text.addTextInstance("", x, y, scale));
	}
	
	static void SetHudInstance(string name, UITextInstance value)
	{
		HudTextInstance[name] = value;
		HudText[name] = "";
	}
	
	public UIText Text {get {return text;}}
	UIText text;
	UITextInstance instance;
	static UITextInstance debugText;
	public static void DebugText(string text)
	{
		debugText.text = text;
	}
	
	void Start()
	{
		// setup our text instance which will parse our .fnt file and allow us to
		text = new UIText( "prototype", "prototype.png" );
		
		
		// spawn new text instances showing off the relative positioning features by placing one text instance in each corner
		var x = UIRelative.xPercentFrom( UIxAnchor.Left, 0f );
		var y = UIRelative.yPercentFrom( UIyAnchor.Top, 0f );
		// Uses default color, scale, alignment, and depth.
		SetHudInstance("hud", text.addTextInstance( "", x, y, 1 ));
		SetHudInstance("coin", text.addTextInstance("", Misc.ScreenWidth - Misc.ButtonWidth-10, 10, 1));
		SetHudInstance("pow", text.addTextInstance("", Misc.ScreenWidth - Misc.ButtonWidth-10, Misc.ScreenHeight/2, 1));
		SetHudInstance("alert", text.addTextInstance("", Misc.ScreenWidth/3, Misc.ScreenHeight /3, 2));
		SetHudInstance("shopCoins", text.addTextInstance("", Misc.ScreenWidth/2, 30));
		SetHudInstance("shopItemDescription", text.addTextInstance("", 50, Misc.ScreenHeight/2));
		SetHudInstance("shopItemResult", text.addTextInstance("", Misc.ScreenWidth/2, Misc.ScreenHeight/3));
		SetHudInstance("gameFinished", text.addTextInstance("", Misc.ScreenWidth/7, Misc.ScreenHeight/3));
		SetHudInstance("help1", text.addTextInstance("", Misc.ScreenWidth/6, Misc.ScreenHeight/4));
		SetHudInstance("help2", text.addTextInstance("", Misc.ScreenWidth/6, Misc.ScreenHeight/1.7f, 1));
		
		if (debugText == null)
			debugText = text.addTextInstance("", 10, 20);
		/*
		var textSize = text.sizeForText( "testing small bitmap fonts", 0.3f );
		x = UIRelative.xPercentFrom( UIxAnchor.Left, 0f );
		y = UIRelative.yPercentFrom( UIyAnchor.Bottom, .01f );
		text2 = text.addTextInstance( "testing small bitmap fonts", x, Screen.height - 25, 0.3f );
		
		
		// Centering using alignment modes.
		x = UIRelative.xPercentFrom( UIxAnchor.Left, 0.2f );
		y = UIRelative.yPercentFrom( UIyAnchor.Top, 0.5f );
		text3 = text.addTextInstance( "with only\n1 draw call\nfor everything", x, y, 0.5f, 5, Color.yellow, UITextAlignMode.Right, UITextVerticalAlignMode.Top );

		
		// High Ascii forcing crash demo. To test this, 
		// Disable "Set Low ASCII Forcing Mode" in the TextManager inspector and see the crash.
		// Not as handy if you don't need to paste in large amounts of text from word.
		text.forceLowAscii = setLowAsciiForcingMode;
		
		x = UIRelative.xPercentFrom( UIxAnchor.Right, 0 );
		y = UIRelative.yPercentFrom( UIyAnchor.Bottom, 0 );
		text4 = text.addTextInstance( highAsciiString, x, y, 0.4f, 1, Color.white, UITextAlignMode.Right, UITextVerticalAlignMode.Bottom );
		
		
		// Centering using text size calculation offset and per-char color
		var centeredText = "Be sure to try this with\niPhone and iPad resolutions";
		var colors = new List<Color>();
		for( var i = 0; i < centeredText.Length; i++ )
			colors.Add( Color.Lerp( Color.white, Color.magenta, (float)i / centeredText.Length ) );
		
		textSize = text.sizeForText( centeredText );
		x = UIRelative.xAnchorAdjustment( UIxAnchor.Center, textSize.x, false );
		y = UIRelative.yAnchorAdjustment( UIyAnchor.Center, Screen.height, false );
		text.addTextInstance( centeredText, x, y, 1f, 4, colors.ToArray(), UITextAlignMode.Left, UITextVerticalAlignMode.Middle );
		
		
		// Now center on right side.
		y = UIRelative.yPercentFrom( UIyAnchor.Top, 0.3f );
		text.addTextInstance( "Vert-Centering on right side", Screen.width, y, 0.5f, 1, Color.white, UITextAlignMode.Right, UITextVerticalAlignMode.Middle );
		
		
		x = UIRelative.xPercentFrom( UIxAnchor.Left, 0.1f );
		y = UIRelative.yPercentFrom( UIyAnchor.Bottom, 0.1f );

		var wrapText = new UIText( "prototype", "prototype.png" );
		wrapText.wrapMode = UITextLineWrapMode.MinimumLength;
		wrapText.lineWrapWidth = 100.0f;
		textWrap1 = wrapText.addTextInstance( "Testing line wrap width with small words in multiple resolutions.\n\nAnd manual L/B.", x, y, 0.3f, 1, Color.white, UITextAlignMode.Left, UITextVerticalAlignMode.Bottom );
		
		wrapText.lineWrapWidth = 100.0f;
		wrapText.wrapMode = UITextLineWrapMode.AlwaysHyphenate;
		
		x = UIRelative.xPercentFrom( UIxAnchor.Left, 0.5f );
		y = UIRelative.yPercentFrom( UIyAnchor.Bottom, 0f );
		textWrap2 = wrapText.addTextInstance( "This should be hyphenated. Check baseline - tytyt", x, y, 0.5f, 1, Color.green, UITextAlignMode.Center, UITextVerticalAlignMode.Bottom );
		
		StartCoroutine( modifyTextInstances() );
		*/
	}
	

	IEnumerator modifyTextInstances()
	{
		yield return new WaitForSeconds( 1.0f );
		text2.text = "gonna change the little text";
		text2.setColorForAllLetters( Color.green );
		
		yield return new WaitForSeconds( 2.0f );
		text3.clear();
		
		yield return new WaitForSeconds( 1.0f );
		text4.clear();
		text2.clear();
		
		yield return new WaitForSeconds( 1.0f );
		textWrap1.clear();
		textWrap2.clear();
	}

}

using UnityEngine;
using System.Collections;

public class DiamondControl : MonoBehaviour {
	
	public static float EndZPosition = 11, EndZPuzzlePosition = 4, PuzzleSpeedMultiplier= 10;
	public float EndPuzzleDelta {get;set;}
	public string ID;
	// Use this for initialization
	void Start () {
		ID = System.Guid.NewGuid().ToString();
		if (ArcadeMode)
		{
			EndPosition = new Vector3(transform.position.x, transform.position.y, EndZPosition);
		}
		else 
		{		EndPosition = new Vector3(transform.position.x, transform.position.y, EndZPuzzlePosition - EndPuzzleDelta);
			Speed += PuzzleSpeedMultiplier*DeltaSpeedIncrease;
			ShiftMultiplerSpeed = 3;
			//DeltaSpeedIncrease *= 3;
		}
			
	}
	
	bool ArcadeMode {get {return !Misc.Instance.TutorialMode && Misc.Mode == GameMode.Arcade;}}
	bool PuzzleMode {get {return Misc.Instance.TutorialMode || Misc.Mode == GameMode.Puzzle;}}
	
	public static float Speed = 1.5f, DeltaSpeedIncrease = 0.1f, ShiftMultiplerSpeed = 15;
	public static void IncreaseSpeed()
	{
		Speed += DeltaSpeedIncrease;
	}
	
	public static void InitSpeed()
	{
		Speed = 1.5f;
	}
	public Vector3 EndPosition;
	//9
	// Update is called once per frame
	void FixedUpdate () {
		bool shiftEnd = false;
		if (!Misc.GamePaused && ShiftDownPosition != Vector3.zero)
		{
			transform.position = Vector3.MoveTowards(transform.position, ShiftDownPosition, Time.fixedDeltaTime * ShiftMultiplerSpeed*Speed);
			if (transform.position == ShiftDownPosition)
			{
				ProcessShifting = true;
				IsShifted = false;
				shiftEnd = true;
				ShiftDownPosition = Vector3.zero;
				if (ArcadeMode)
				{
					EndPosition = new Vector3(transform.position.x, transform.position.y, EndZPosition);
				}
				else
				{
					EndPosition = transform.position;
				}
			}
			else if (ArcadeMode)
			{
				ShiftDownPosition = Vector3.MoveTowards(ShiftDownPosition, EndPosition, Time.fixedDeltaTime * Speed);
			}
		}
		else if (!Misc.GamePaused)
		{
			transform.position = Vector3.MoveTowards(transform.position, EndPosition, Time.fixedDeltaTime * Speed);
			if (Highlight != null)
				Highlight.transform.position = Vector3.MoveTowards(Highlight.transform.position, EndPosition, Time.fixedDeltaTime * Speed);
		}
		if (touched)
			transform.RotateAround(Vector3.right, Time.fixedDeltaTime * Speed);
		else
			transform.rotation = Quaternion.identity;
		if (transform.position == EndPosition && !DoneMoving)
		{
			if (ArcadeMode && !shiftEnd)
			{
				GameControl.TouchedEntities.Remove(this);//gameObject);
				RemoveHighlighter();
				Destroy(gameObject);
				DoneMoving = true;
			}
			else if (PuzzleMode)
			{
				Speed -= PuzzleSpeedMultiplier*DeltaSpeedIncrease;
				DoneMoving = true;
			}
		}
	}
	
	bool DoneMoving;
	
	Vector3 _ShiftDownPosition;
	public Vector3 ShiftDownPosition {get {return _ShiftDownPosition;}
		set 
		{ 
			_ShiftDownPosition = value;
		}
	}
	public Vector3 ShiftEndPosition {get;set;}
	
	bool touched;
	public bool IsTouched {get {return touched;}}
	public bool IsShifted;
	public bool ProcessShifting, ShiftMatched;
	public float TouchedTime, BurstTime;
	GameObject Highlight;
	public void Touched()
	{
		touched = !touched;
		if (touched)
		{
			MusicPlayer.PlaySound(SoundType.Touches);
			TouchedTime = Misc.TimeInLevel;
			Highlight = (GameObject)Instantiate(PrefabCollection.Instance.Get(EntityType.Highlight), transform.position, Quaternion.identity);
			Highlight.transform.position += 0.5f*Vector3.down;
			Destroy(Highlight, 10);
		}
		else 
		{
			TouchedTime = 0;
			RemoveHighlighter();
		}
		//FixedUpdate ();
			//Destroy(gameObject);
	}
	
	void RemoveHighlighter()
	{
		if (Highlight == null) return;
		Destroy(Highlight.gameObject);
		Highlight = null;
	}
	
	public void Shift(Vector3 position)
	{
		IsShifted = true;
		ShiftDownPosition = position;
		EndPosition = new Vector3(position.x, position.y, EndZPosition);
	}
	
}

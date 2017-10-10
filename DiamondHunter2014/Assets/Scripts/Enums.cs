using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EntityType
{
	Great,
	Hot,
	Incredible,
	Omg,
	Speechless,
	Stunning,
	Unbelievable,
	LevelUp,
	Highlight,
	UI,
	Gui
}

public enum Difficulty
{
	Easy,
	Medium,
	Hard,
	Extreme
}

public enum GameStyle
{
	Lite,
	Full
}

public enum Bias
{
	Left,
	Right
}

public enum GameMode
{
	Puzzle,
	Arcade
}

public static class NameValues
{
	public static string EnemyWalk = "walk";
	public static string EnemyDamage = "damage1";
	public static string EnemyDamage1 = "damage1";
	public static string EnemyDamage2 = "damage2";
	public static string EnemyDamage3 = "damage3";
	public static string EnemyDamage4 = "damage4";
	public static string EnemyAttack  = "attack";
	public static string EnemyAttack1 = "attack1";
	public static string EnemyAttack2 = "attack2";
	public static string EnemyAttack3 = "attack3";
	public static string Spawn = "Spawn";
	public static string Path = "Path";
	
}

public enum RoomType
{
	DiningHall,
	Kitchen1,
	Kitchen2,
	Bathroom1,
	Bathroom2,
	Entryway,
	Hall,
	Chopper,
	Foyer,
	Stairs
}

public enum SoundType
{
	Touches,
	Default,
	PowerUp,
	PowerUp2,
	WrongMove,
	Title,
	GameOver,
	LevelUp,
	Transition
}

public enum RowType
{
	Regular,
	Alternate
}

public class Rand
{
	static System.Random _Instance;
	public static System.Random Instance {get{return (_Instance ?? (_Instance = new System.Random()));}}
}

public static class Config
{
	public static int MaxNumberOfEnemies = 2;
	public static int MaxNumberOfProjectiles = 3;
}

public static class SlowMotion
{
	public static bool IsSlowMotion {get;set;}
	
	public static void SetSlowMotion(bool value, float howMuch)
	{
		IsSlowMotion = value;
		Time.timeScale = value ? howMuch : 1;
	}
}

public class Timer
{
	float timeStart, amount;
	
	public Timer(float howMuch)
	{
		amount = howMuch;
	}
	
	public void Start(float time)
	{
		timeStart = time;
	}
	
	public bool IsOver(float time)
	{
		return time - timeStart >= amount;
	}
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace MNProductions.Maze.Enums
{

	public enum PowerupTypes
	{
		pow
	}
	
	public static class PowerupIcons 
	{
		public static string GetIcon(string name)
		{
			switch (name)
			{
			case "pow":
				return "icon_lightning";
			default:
				break;
			}
			return "";
		}
	}
	
	public enum LevelName
	{
		Default,
		Help1
	}
}



using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Puzzles
{
	public static void AddMore(PuzzleCollection pc)
	{
		int pId = pc.Count > 0 ? pc.OrderByDescending(p=>p.Id).First().Id : 0;
		Puzzle puzzle;
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(1,1,0,0,0);
		puzzle.Add(1,2,2,1,1);
		puzzle.Add(2,1,1,1,0);
		pc.Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(2,2,2,0,0,0);
		puzzle.Add(2,2,1,2,1,1);
		puzzle.Add(1,1,1,0,0,0);
		puzzle.Add(0,2,2,1,1,1);
		puzzle.Add(1,1,2,0,0,0);
		pc.Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(2,3,3,3,0,0);
		puzzle.Add(2,2,1,1,0,0);
		puzzle.Add(3,1,3,3,0,0);
		puzzle.Add(3,3,0,0,1,1);
		puzzle.Add(2,2,3,1,2,2);
		pc.Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(4,4,4,3,3,3);
		puzzle.Add(0,0,0,4,3,4);
		puzzle.Add(0,0,1,1,1,4);
		puzzle.Add(3,0,2,2,2,4);
		puzzle.Add(0,3,3,4,4,4);
		puzzle.Add(0,0,1,1,1,1);
		pc.Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(2,1,1,1,0,0);
		puzzle.Add(2,2,1,1,0,0);
		puzzle.Add(3,1,3,3,0,0);
		puzzle.Add(3,3,0,0,3,3);
		puzzle.Add(2,2,3,3,2,2);
		pc.Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(0,0,1,1,3,2);
		puzzle.Add(3,3,1,1,3,2);
		puzzle.Add(1,1,3,3,1,2);
		puzzle.Add(1,3,0,0,2,2);
		puzzle.Add(0,3,3,0,0,0);
		pc.Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(3,3,3,2,3,2);
		puzzle.Add(3,3,0,1,3,2);
		puzzle.Add(0,0,0,1,1,2);
		puzzle.Add(3,3,0,2,3,3);
		puzzle.Add(0,3,3,3,2,2);
		pc.Add(puzzle);
		
	}
}

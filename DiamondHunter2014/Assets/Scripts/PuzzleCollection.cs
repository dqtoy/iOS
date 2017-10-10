using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class TutorialCollection : List<Puzzle>
{
	public TutorialCollection()
	{
		InitPuzzles();
	}
	
	void InitPuzzles()
	{
		var pId = 0;
		Puzzle puzzle;
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(1,1,1,2,2,2,2);
		Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(3,3,3,4,4,4,4);
		puzzle.Add(1,1,1,2,2,2,2);
		Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(3,3,3,5,4,4,4);
		puzzle.Add(6,6,6,5,0,0,0);
		puzzle.Add(3,3,3,5,4,4,4);
		puzzle.Add(1,1,1,2,2,2,2);
		Add(puzzle);
		
	}
}

public class PuzzleCollection : List<Puzzle>
{
	public PuzzleCollection()
	{
		InitPuzzles();
	}
	
	Puzzle GeneratePuzzle(Difficulty difficulty)
	{
		int max = 4;
		switch(difficulty)
		{
		case Difficulty.Easy: max = 4; break;
		case Difficulty.Medium: max = 5; break;
		case Difficulty.Hard: max = 6; break;
		case Difficulty.Extreme: max = 7; break;
		default: break;
		}
		var puzzle = new Puzzle(1, 10);
		int numOfTries = 100;
		var Rand = new System.Random();
		var ids = new List<int>();
		int id;
		for (int i=0; i<numOfTries; ++i)
		{
			ids.Clear();
			puzzle.Clear();
			for (int j=0; j<max; ++j)
			{
				var dl = new DiamondList();
				for (int k=0; k<max; ++k)
				{
					id = Rand.Next(0,max+1);
					dl.Add(id);
					ids.Add(id);					
				}
				puzzle.Add(dl);
			}
			var sql = from dc in ids
				group dc by dc into n
					select new {Count = n.Count()};
			if (!sql.Any(asdf=>asdf.Count < 6))
				return puzzle;
		}
		return puzzle;
	}
	
	void InitPuzzles()
	{
		var pId = 0;
		Puzzle puzzle;
		
		Add(GeneratePuzzle(Difficulty.Extreme));
		
		puzzle = new Puzzle(++pId, 3);
		puzzle.Add(3,6,5,4,6,6,5);
		puzzle.Add(6,3,0,5,5,5,8);
		puzzle.Add(6,5,3,8,0,7,8);
		puzzle.Add(3,0,5,4,6,8,2);
		puzzle.Add(6,6,4,4,4,5,2);
		puzzle.Add(6,4,4,4,6,7,2);
		puzzle.Add(0,0,0,6,4,8,8);
		puzzle.Add(0,0,4,6,4,7,7);
		Add(puzzle);
		
		puzzle = new Puzzle(++pId, 3);
		puzzle.Add(5,5,5,6,6,1,-1);
		puzzle.Add(5,6,5,0,6,1,4);
		puzzle.Add(5,6,3,5,6,5,4);
		puzzle.Add(6,1,3,0,6,5,4);
		puzzle.Add(1,1,3,3,0,0,5);
		puzzle.Add(1,1,3,5,5,5,5);
		Add(puzzle);
		
		puzzle = new Puzzle(++pId, 2);
		puzzle.Add(2,4,3,3,2,2,2);
		puzzle.Add(2,2,6,3,1,1,2);
		puzzle.Add(2,4,3,1,4,4,4);
		puzzle.Add(3,3,3,2,1,2,4);
		puzzle.Add(4,4,6,6,2,2,4);
		Add(puzzle);
		
		puzzle = new Puzzle(++pId, 4);
		puzzle.Add(5,5,3,4,4,3,5);
		puzzle.Add(5,5,3,3,3,1,7);
		puzzle.Add(7,7,5,4,4,1,7);
		puzzle.Add(7,4,3,5,1,3,7);
		puzzle.Add(5,7,7,5,5,4,7);
		puzzle.Add(7,4,4,4,5,4,7);
		Add(puzzle);
		
		puzzle = new Puzzle(++pId, 4);
		puzzle.Add(2,2,1,3,4,3,2);
		puzzle.Add(2,4,2,5,3,2,2);
		puzzle.Add(4,1,2,2,0,2,2);
		puzzle.Add(4,3,5,3,3,0,0);
		puzzle.Add(1,1,2,1,3,5,5);
		puzzle.Add(3,3,1,3,1,3,3);
		Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(1,1,1,0,0,0);
		puzzle.Add(0,0,1,1,1,1);
		puzzle.Add(1,1,1,0,0,0);
		puzzle.Add(0,0,0,1,1,1);
		puzzle.Add(1,1,1,0,0,0);
		Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(0,0,0,0,1,0);
		puzzle.Add(0,0,0,1,0,0);
		puzzle.Add(0,0,0,1,0,0);
		puzzle.Add(0,0,1,0,0,2);
		puzzle.Add(0,0,1,0,1,0);
		puzzle.Add(0,3,2,2,2,2);
		puzzle.Add(0,0,2,2,2,2);
		puzzle.Add(3,3,3,1,1,1);
		Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(1,1,1,1,1);
		puzzle.Add(1,1,1,1,1);
		puzzle.Add(1,0,0,1,1);
		puzzle.Add(1,1,1,0,0);
		Add(puzzle);
		
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(1,2,2,2,1);
		puzzle.Add(1,1,1,1,1);
		puzzle.Add(3,3,3,1,1);
		puzzle.Add(1,1,1,2,2);
		Add(puzzle);
		
		/*
		puzzle = new Puzzle(++pId, 1);
		puzzle.Add(1,1,2,2,1,1,3);
		puzzle.Add(0,4,2,6,3,4,0);
		puzzle.Add(4,4,3,6,4,0,3);
		puzzle.Add(2,5,0,3,2,3,4);
		puzzle.Add(0,5,6,1,1,1,3);
		Add(puzzle);
		
		*/
		
	}
}


public class Puzzle : List<DiamondList>
{
	public int Id {get;set;}
	public int MaximumNumberOfMoves {get;set;}
	
	public Puzzle(int id, int min)
	{
		Id = id;
		MaximumNumberOfMoves = min;
	}
	
	public void Add(params int[] ids)
	{
		if (ids.Length == 0) return;
		var list = new DiamondList();
		Add(list);
		for (int i=0; i<ids.Length; ++i)
			list.Add(ids[i]);
	}
}

public class DiamondList : List<int>
{
}
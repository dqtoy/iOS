using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PrefabCollection : Dictionary<EntityType, Object>
{
	
	static PrefabCollection instance;
	public static PrefabCollection Instance 
	{
		get {return (instance ?? (instance = new PrefabCollection()));}
	}
	
	public Object Get(EntityType type)
	{
		return this[type];
	}
	public PrefabCollection ()
	{
		LoadPrefabs();
	}

	void LoadPrefabs()
	{
		LoadPrefabs(EntityType.Great, "type_GreatJob");
		LoadPrefabs(EntityType.Hot, "type_hotness");
		LoadPrefabs(EntityType.Incredible, "type_incredible");
		LoadPrefabs(EntityType.Omg, "type_omg");
		LoadPrefabs(EntityType.Speechless, "type_speechless");
		LoadPrefabs(EntityType.Stunning, "type_stunning");
		LoadPrefabs(EntityType.Unbelievable, "type_unbelievable");
		LoadPrefabs(EntityType.UI, "UI");
		LoadPrefabs(EntityType.Gui, "UiGui");
		LoadPrefabs(EntityType.LevelUp, "type_levelUp");
		LoadPrefabs(EntityType.Highlight, "highlight");
		
	}
	
	void LoadPrefabs(EntityType type, string name)
	{
		this.Add(type, Resources.Load(name));		
	}

}


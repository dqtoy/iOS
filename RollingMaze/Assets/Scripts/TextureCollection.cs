using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextureCollection : Dictionary<string, Texture>
{
	    private static TextureCollection instance = null;
	    public static TextureCollection Instance { get { return (instance ?? (instance = new TextureCollection())); } }
		public TextureCollection ()
		{
		}
		
		public Texture GetTexture(string name)
		{
			if (!ContainsKey(name))
				Add(name, (Texture)Resources.Load(name));
			return this[name];
		}
}


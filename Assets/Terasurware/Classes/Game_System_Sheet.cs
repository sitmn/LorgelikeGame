using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_System_Sheet : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		
		public string id;
		public string name;
		public int price_int;
		public float price_float;
	}
}


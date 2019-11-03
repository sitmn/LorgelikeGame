using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item_State_Sheet : ScriptableObject
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
		public string price_name_string;
		public int price_heal_point_int;
		public int price_attack_point_int;
		public int price_attack_type_int;
		public int price_attack_range_int;
		public int price_develop_material1_int;
		public int price_develop_material2_int;
		public int price_develop_material3_int;
		public int price_develop_need_mp_int;
	}
}


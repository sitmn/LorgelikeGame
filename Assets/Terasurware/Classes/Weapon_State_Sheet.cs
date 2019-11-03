using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon_State_Sheet : ScriptableObject
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
		public int price_hp_int;
		public int price_attack_int;
		public int price_defense_int;
		public int price_attack_range_int;
		public int price_attack_type_int;
		public bool price_attack_through_bool;
		public bool price_slanting_wall_bool;
		public int price_develop_material1_int;
		public int price_develop_material2_int;
		public int price_develop_material3_int;
		public int price_mp_cost_int;
		public int price_endurance_int;
		public int price_develop_need_mp_int;
	}
}


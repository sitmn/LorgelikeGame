using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_State_Sheet : ScriptableObject
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
		public int price_player_MAX_hp_int;
		public int price_player_origin_hp_int;
		public int price_player_hp_int;
		public int price_player_MAX_mp_int;
		public int price_player_origin_mp_int;
		public int price_player_mp_int;
		public int price_player_origin_attack_int;
		public int price_player_attack_int;
		public int price_player_origin_defense_int;
		public int price_player_defense_int;
		public bool price_player_attack_through_bool;
		public int price_player_attack_range_int;
		public int price_player_attack_type_int;
		public bool price_player_slanting_wall_bool;
	}
}


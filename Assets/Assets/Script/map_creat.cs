using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine.UI;

public class map_creat : MonoBehaviour {

    public GameObject TestObject;


    public static GameObject Map;
    public GameObject map_object;

    //敵ステータス
    public string BAT1_NAME;
    public float BAT1_HP;
    public float BAT1_MP;
    public float BAT1_ATTACK;
    public float BAT1_DEFENSE;
    public int BAT1_ATTACK_RANGE;
    public int BAT1_ATTACK_TYPE;
    public bool BAT1_SLANTING_WALL;
    public int BAT1_POSSESSION_EXP;

    public string GHOST1_NAME;
    public float GHOST1_HP;
    public float GHOST1_MP;
    public float GHOST1_ATTACK;
    public float GHOST1_DEFENSE;
    public int GHOST1_ATTACK_RANGE;
    public int GHOST1_ATTACK_TYPE;
    public bool GHOST1_SLANTING_WALL;
    public int GHOST1_POSSESSION_EXP;

    public string RABBIT1_NAME;
    public float RABBIT1_HP;
    public float RABBIT1_MP;
    public float RABBIT1_ATTACK;
    public float RABBIT1_DEFENSE;
    public int RABBIT1_ATTACK_RANGE;
    public int RABBIT1_ATTACK_TYPE;
    public bool RABBIT1_SLANTING_WALL;
    public int RABBIT1_POSSESSION_EXP;

    public string SLIME1_NAME;
    public float SLIME1_HP;
    public float SLIME1_MP;
    public float SLIME1_ATTACK;
    public float SLIME1_DEFENSE;
    public int SLIME1_ATTACK_RANGE;
    public int SLIME1_ATTACK_TYPE;
    public bool SLIME1_SLANTING_WALL;
    public int SLIME1_POSSESSION_EXP;

    public string BAT2_NAME;
    public float BAT2_HP;
    public float BAT2_MP;
    public float BAT2_ATTACK;
    public float BAT2_DEFENSE;
    public int BAT2_ATTACK_RANGE;
    public int BAT2_ATTACK_TYPE;
    public bool BAT2_SLANTING_WALL;
    public int BAT2_POSSESSION_EXP;

    public string GHOST2_NAME;
    public float GHOST2_HP;
    public float GHOST2_MP;
    public float GHOST2_ATTACK;
    public float GHOST2_DEFENSE;
    public int GHOST2_ATTACK_RANGE;
    public int GHOST2_ATTACK_TYPE;
    public bool GHOST2_SLANTING_WALL;
    public int GHOST2_POSSESSION_EXP;

    public string RABBIT2_NAME;
    public float RABBIT2_HP;
    public float RABBIT2_MP;
    public float RABBIT2_ATTACK;
    public float RABBIT2_DEFENSE;
    public int RABBIT2_ATTACK_RANGE;
    public int RABBIT2_ATTACK_TYPE;
    public bool RABBIT2_SLANTING_WALL;
    public int RABBIT2_POSSESSION_EXP;

    public string SLIME2_NAME;
    public float SLIME2_HP;
    public float SLIME2_MP;
    public float SLIME2_ATTACK;
    public float SLIME2_DEFENSE;
    public int SLIME2_ATTACK_RANGE;
    public int SLIME2_ATTACK_TYPE;
    public bool SLIME2_SLANTING_WALL;
    public int SLIME2_POSSESSION_EXP;

    public string BAT3_NAME;
    public float BAT3_HP;
    public float BAT3_MP;
    public float BAT3_ATTACK;
    public float BAT3_DEFENSE;
    public int BAT3_ATTACK_RANGE;
    public int BAT3_ATTACK_TYPE;
    public bool BAT3_SLANTING_WALL;
    public int BAT3_POSSESSION_EXP;

    public string GHOST3_NAME;
    public float GHOST3_HP;
    public float GHOST3_MP;
    public float GHOST3_ATTACK;
    public float GHOST3_DEFENSE;
    public int GHOST3_ATTACK_RANGE;
    public int GHOST3_ATTACK_TYPE;
    public bool GHOST3_SLANTING_WALL;
    public int GHOST3_POSSESSION_EXP;

    public string RABBIT3_NAME;
    public float RABBIT3_HP;
    public float RABBIT3_MP;
    public float RABBIT3_ATTACK;
    public float RABBIT3_DEFENSE;
    public int RABBIT3_ATTACK_RANGE;
    public int RABBIT3_ATTACK_TYPE;
    public bool RABBIT3_SLANTING_WALL;
    public int RABBIT3_POSSESSION_EXP;

    public string SLIME3_NAME;
    public float SLIME3_HP;
    public float SLIME3_MP;
    public float SLIME3_ATTACK;
    public float SLIME3_DEFENSE;
    public int SLIME3_ATTACK_RANGE;
    public int SLIME3_ATTACK_TYPE;
    public bool SLIME3_SLANTING_WALL;
    public int SLIME3_POSSESSION_EXP;

    public string BAT4_NAME;
    public float BAT4_HP;
    public float BAT4_MP;
    public float BAT4_ATTACK;
    public float BAT4_DEFENSE;
    public int BAT4_ATTACK_RANGE;
    public int BAT4_ATTACK_TYPE;
    public bool BAT4_SLANTING_WALL;
    public int BAT4_POSSESSION_EXP;

    public string GHOST4_NAME;
    public float GHOST4_HP;
    public float GHOST4_MP;
    public float GHOST4_ATTACK;
    public float GHOST4_DEFENSE;
    public int GHOST4_ATTACK_RANGE;
    public int GHOST4_ATTACK_TYPE;
    public bool GHOST4_SLANTING_WALL;
    public int GHOST4_POSSESSION_EXP;

    public string RABBIT4_NAME;
    public float RABBIT4_HP;
    public float RABBIT4_MP;
    public float RABBIT4_ATTACK;
    public float RABBIT4_DEFENSE;
    public int RABBIT4_ATTACK_RANGE;
    public int RABBIT4_ATTACK_TYPE;
    public bool RABBIT4_SLANTING_WALL;
    public int RABBIT4_POSSESSION_EXP;

    public string SLIME4_NAME;
    public float SLIME4_HP;
    public float SLIME4_MP;
    public float SLIME4_ATTACK;
    public float SLIME4_DEFENSE;
    public int SLIME4_ATTACK_RANGE;
    public int SLIME4_ATTACK_TYPE;
    public bool SLIME4_SLANTING_WALL;
    public int SLIME4_POSSESSION_EXP;

    public string BOSS1_NAME;
    public float BOSS1_HP;
    public float BOSS1_MP;
    public float BOSS1_ATTACK;
    public float BOSS1_DEFENSE;
    public int BOSS1_ATTACK_RANGE;
    public int BOSS1_ATTACK_TYPE;
    public bool BOSS1_SLANTING_WALL;
    public int BOSS1_POSSESSION_EXP;

    //アイテム
    public string NAME_I1;
    public int HEAL_POINT_I1;
    public int DEVELOP_I1_MATERIAL_1;
    public int DEVELOP_I1_MATERIAL_2;
    public int DEVELOP_I1_MATERIAL_3;
    public int DEVELOP_NEED_MP_I1;

    public string NAME_I2;
    public int ATTACK_POINT_I2;
    public int ATTACK_TYPE;
    public int ATTACK_RANGE;
    public int DEVELOP_I2_MATERIAL_1;
    public int DEVELOP_I2_MATERIAL_2;
    public int DEVELOP_I2_MATERIAL_3;
    public int DEVELOP_NEED_MP_I2;

    /*
    public string NAME_I3;
    public int ATTACK_TYPE;
    public int ATTACK_RANGE;
    public int DEVELOP_I3_MATERIAL_1;
    public int DEVELOP_I3_MATERIAL_2;
    public int DEVELOP_I3_MATERIAL_3;
    public int DEVELOP_NEED_MP_I3;
    */
    public string NAME_I4;
    public int HEAL_POINT_I4;
    public int DEVELOP_I4_MATERIAL_1;
    public int DEVELOP_I4_MATERIAL_2;
    public int DEVELOP_I4_MATERIAL_3;
    public int DEVELOP_NEED_MP_I4;

    //武器ステータス
    public string NAME_W1;
    public int HP_W1;
    public int ATTACK_W1;
    public int DEFENSE_W1;
    public int ATTACK_RANGE_W1;
    public int ATTACK_TYPE_W1;
    public bool ATTACK_THROUGH_W1;
    public bool SLANTING_WALL_W1;
    public int DEVELOP_W1_MATERIAL_1;
    public int DEVELOP_W1_MATERIAL_2;
    public int DEVELOP_W1_MATERIAL_3;
    public int MP_COST_W1;
    public int ENDURANCE_W1;
    public int DEVELOP_NEED_MP_W1;

    public string NAME_W2;
    public int HP_W2;
    public int ATTACK_W2;
    public int DEFENSE_W2;
    public int ATTACK_RANGE_W2;
    public int ATTACK_TYPE_W2;
    public bool ATTACK_THROUGH_W2;
    public bool SLANTING_WALL_W2;
    public int DEVELOP_W2_MATERIAL_1;
    public int DEVELOP_W2_MATERIAL_2;
    public int DEVELOP_W2_MATERIAL_3;
    public int MP_COST_W2;
    public int ENDURANCE_W2;
    public int DEVELOP_NEED_MP_W2;

    public string NAME_W3;
    public int HP_W3;
    public int ATTACK_W3;
    public int DEFENSE_W3;
    public int ATTACK_RANGE_W3;
    public int ATTACK_TYPE_W3;
    public bool ATTACK_THROUGH_W3;
    public bool SLANTING_WALL_W3;
    public int DEVELOP_W3_MATERIAL_1;
    public int DEVELOP_W3_MATERIAL_2;
    public int DEVELOP_W3_MATERIAL_3;
    public int MP_COST_W3;
    public int ENDURANCE_W3;
    public int DEVELOP_NEED_MP_W3;

    public string NAME_W4;
    public int HP_W4;
    public int ATTACK_W4;
    public int DEFENSE_W4;
    public int ATTACK_RANGE_W4;
    public int ATTACK_TYPE_W4;
    public bool ATTACK_THROUGH_W4;
    public bool SLANTING_WALL_W4;
    public int DEVELOP_W4_MATERIAL_1;
    public int DEVELOP_W4_MATERIAL_2;
    public int DEVELOP_W4_MATERIAL_3;
    public int MP_COST_W4;
    public int ENDURANCE_W4;
    public int DEVELOP_NEED_MP_W4;

    public string NAME_W5;
    public int HP_W5;
    public int ATTACK_W5;
    public int DEFENSE_W5;
    public int ATTACK_RANGE_W5;
    public int ATTACK_TYPE_W5;
    public bool ATTACK_THROUGH_W5;
    public bool SLANTING_WALL_W5;
    public int DEVELOP_W5_MATERIAL_1;
    public int DEVELOP_W5_MATERIAL_2;
    public int DEVELOP_W5_MATERIAL_3;
    public int MP_COST_W5;
    public int ENDURANCE_W5;
    public int DEVELOP_NEED_MP_W5;

    public string NAME_M1;

    public string NAME_M2;

    public string NAME_M3;

    private GameObject FloorText;

    public GameObject wallObject;
    public GameObject wallObject1;
    public GameObject wallObject2;
    public GameObject wallObject3;
    public GameObject wallObject4;
    public GameObject floor;
    public GameObject Player;
    public GameObject Bat1;
    public GameObject Bat2;
    public GameObject Bat3;
    public GameObject Bat4;
    public GameObject Ghost1;
    public GameObject Ghost2;
    public GameObject Ghost3;
    public GameObject Ghost4;
    public GameObject Rabbit1;
    public GameObject Rabbit2;
    public GameObject Rabbit3;
    public GameObject Rabbit4;
    public GameObject Slime1;
    public GameObject Slime2;
    public GameObject Slime3;
    public GameObject Slime4;
    public GameObject Golem;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Kaidan;
    public GameObject Material1;
    public GameObject Material2;
    public GameObject Material3;
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject Weapon3;

    //ミニマップ
    public GameObject MiniMapWall;
    public GameObject MiniMapFloor;
    public GameObject MiniMapClear;
    public static GameObject MiniMapPlayer;
    public GameObject MiniMapKaidan;
    public GameObject MiniMapItem;
    public static int minimapdistance  = 100;
    
    public Vector3 entrancevec;


    public static int MAX_X = 50;
    public static int MAX_Y = 50;

    public int[] Xline;
    public int[] Yline;

    public int[] room_0;

    int[,,] room_x;
    int[,,] room_y;

    private bool duplication = false;

    private int i1, i2, i3, i4, i5, i6, r, z1, z2, z3, z4,enemynumber;


    public static map_state[,] map;
    public static map_camera_object[,] map_camera_obj;
    public static map_exist[,] map_ex;
    public static map_item[,] map_item;

    public static GameObject[,] mini_map;
    public static Renderer[,] grid_color;

    public int boss_pos_x;
    public int boss_pos_z;

    //マップ作る際と、プレイヤー操作中に分けるための変数
    public bool mapcreat;

    public map_creat map_creat_instance;
    

    void Start()
    {
        map_creat_instance = this;
}

    // Use this for initialization
    public void Mapcreat()
    {
        //マスターデータの代入
        BAT1_NAME = GameManager.instance.enemy_state_data.sheets[0].list[0].price_name_string;
        BAT1_HP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_hp_int;
        BAT1_MP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_mp_int;
        BAT1_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[0].price_attack_int;
        BAT1_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[0].price_defense_int;
        BAT1_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[0].price_attack_range_int;
        BAT1_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[0].price_attack_type_int;
        BAT1_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[0].price_slanting_wall_bool;
        BAT1_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        GHOST1_NAME = GameManager.instance.enemy_state_data.sheets[0].list[1].price_name_string;
        GHOST1_HP = GameManager.instance.enemy_state_data.sheets[0].list[1].price_hp_int;
        GHOST1_MP = GameManager.instance.enemy_state_data.sheets[0].list[1].price_mp_int;
        GHOST1_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[1].price_attack_int;
        GHOST1_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[1].price_defense_int;
        GHOST1_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[1].price_attack_range_int;
        GHOST1_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[1].price_attack_type_int;
        GHOST1_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[1].price_slanting_wall_bool;
        GHOST1_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        RABBIT1_NAME = GameManager.instance.enemy_state_data.sheets[0].list[2].price_name_string;
        RABBIT1_HP = GameManager.instance.enemy_state_data.sheets[0].list[2].price_hp_int;
        RABBIT1_MP = GameManager.instance.enemy_state_data.sheets[0].list[2].price_mp_int;
        RABBIT1_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[2].price_attack_int;
        RABBIT1_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[2].price_defense_int;
        RABBIT1_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[2].price_attack_range_int;
        RABBIT1_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[2].price_attack_type_int;
        RABBIT1_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[2].price_slanting_wall_bool;
        RABBIT1_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        SLIME1_NAME = GameManager.instance.enemy_state_data.sheets[0].list[3].price_name_string;
        SLIME1_HP = GameManager.instance.enemy_state_data.sheets[0].list[3].price_hp_int;
        SLIME1_MP = GameManager.instance.enemy_state_data.sheets[0].list[3].price_mp_int;
        SLIME1_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[3].price_attack_int;
        SLIME1_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[3].price_defense_int;
        SLIME1_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[3].price_attack_range_int;
        SLIME1_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[3].price_attack_type_int;
        SLIME1_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[3].price_slanting_wall_bool;
        SLIME1_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        BAT2_NAME = GameManager.instance.enemy_state_data.sheets[0].list[4].price_name_string;
        BAT2_HP = GameManager.instance.enemy_state_data.sheets[0].list[4].price_hp_int;
        BAT2_MP = GameManager.instance.enemy_state_data.sheets[0].list[4].price_mp_int;
        BAT2_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[4].price_attack_int;
        BAT2_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[4].price_defense_int;
        BAT2_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[4].price_attack_range_int;
        BAT2_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[4].price_attack_type_int;
        BAT2_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[4].price_slanting_wall_bool;
        BAT2_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        GHOST2_NAME = GameManager.instance.enemy_state_data.sheets[0].list[5].price_name_string;
        GHOST2_HP = GameManager.instance.enemy_state_data.sheets[0].list[5].price_hp_int;
        GHOST2_MP = GameManager.instance.enemy_state_data.sheets[0].list[5].price_mp_int;
        GHOST2_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[5].price_attack_int;
        GHOST2_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[5].price_defense_int;
        GHOST2_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[5].price_attack_range_int;
        GHOST2_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[5].price_attack_type_int;
        GHOST2_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[5].price_slanting_wall_bool;
        GHOST2_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        RABBIT2_NAME = GameManager.instance.enemy_state_data.sheets[0].list[6].price_name_string;
        RABBIT2_HP = GameManager.instance.enemy_state_data.sheets[0].list[6].price_hp_int;
        RABBIT2_MP = GameManager.instance.enemy_state_data.sheets[0].list[6].price_mp_int;
        RABBIT2_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[6].price_attack_int;
        RABBIT2_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[6].price_defense_int;
        RABBIT2_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[6].price_attack_range_int;
        RABBIT2_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[6].price_attack_type_int;
        RABBIT2_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[6].price_slanting_wall_bool;
        RABBIT2_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        SLIME2_NAME = GameManager.instance.enemy_state_data.sheets[0].list[7].price_name_string;
        SLIME2_HP = GameManager.instance.enemy_state_data.sheets[0].list[7].price_hp_int;
        SLIME2_MP = GameManager.instance.enemy_state_data.sheets[0].list[7].price_mp_int;
        SLIME2_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[7].price_attack_int;
        SLIME2_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[7].price_defense_int;
        SLIME2_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[7].price_attack_range_int;
        SLIME2_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[7].price_attack_type_int;
        SLIME2_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[7].price_slanting_wall_bool;
        SLIME2_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        BAT3_NAME = GameManager.instance.enemy_state_data.sheets[0].list[8].price_name_string;
        BAT3_HP = GameManager.instance.enemy_state_data.sheets[0].list[8].price_hp_int;
        BAT3_MP = GameManager.instance.enemy_state_data.sheets[0].list[8].price_mp_int;
        BAT3_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[8].price_attack_int;
        BAT3_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[8].price_defense_int;
        BAT3_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[8].price_attack_range_int;
        BAT3_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[8].price_attack_type_int;
        BAT3_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[8].price_slanting_wall_bool;
        BAT3_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        GHOST3_NAME = GameManager.instance.enemy_state_data.sheets[0].list[9].price_name_string;
        GHOST3_HP = GameManager.instance.enemy_state_data.sheets[0].list[9].price_hp_int;
        GHOST3_MP = GameManager.instance.enemy_state_data.sheets[0].list[9].price_mp_int;
        GHOST3_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[9].price_attack_int;
        GHOST3_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[9].price_defense_int;
        GHOST3_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[9].price_attack_range_int;
        GHOST3_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[9].price_attack_type_int;
        GHOST3_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[9].price_slanting_wall_bool;
        GHOST3_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        RABBIT3_NAME = GameManager.instance.enemy_state_data.sheets[0].list[10].price_name_string;
        RABBIT3_HP = GameManager.instance.enemy_state_data.sheets[0].list[10].price_hp_int;
        RABBIT3_MP = GameManager.instance.enemy_state_data.sheets[0].list[10].price_mp_int;
        RABBIT3_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[10].price_attack_int;
        RABBIT3_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[10].price_defense_int;
        RABBIT3_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[10].price_attack_range_int;
        RABBIT3_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[10].price_attack_type_int;
        RABBIT3_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[10].price_slanting_wall_bool;
        RABBIT3_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        SLIME3_NAME = GameManager.instance.enemy_state_data.sheets[0].list[11].price_name_string;
        SLIME3_HP = GameManager.instance.enemy_state_data.sheets[0].list[11].price_hp_int;
        SLIME3_MP = GameManager.instance.enemy_state_data.sheets[0].list[11].price_mp_int;
        SLIME3_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[11].price_attack_int;
        SLIME3_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[11].price_defense_int;
        SLIME3_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[11].price_attack_range_int;
        SLIME3_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[11].price_attack_type_int;
        SLIME3_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[11].price_slanting_wall_bool;
        SLIME3_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        BAT4_NAME = GameManager.instance.enemy_state_data.sheets[0].list[12].price_name_string;
        BAT4_HP = GameManager.instance.enemy_state_data.sheets[0].list[12].price_hp_int;
        BAT4_MP = GameManager.instance.enemy_state_data.sheets[0].list[12].price_mp_int;
        BAT4_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[12].price_attack_int;
        BAT4_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[12].price_defense_int;
        BAT4_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[12].price_attack_range_int;
        BAT4_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[12].price_attack_type_int;
        BAT4_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[12].price_slanting_wall_bool;
        BAT4_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        GHOST4_NAME = GameManager.instance.enemy_state_data.sheets[0].list[13].price_name_string;
        GHOST4_HP = GameManager.instance.enemy_state_data.sheets[0].list[13].price_hp_int;
        GHOST4_MP = GameManager.instance.enemy_state_data.sheets[0].list[13].price_mp_int;
        GHOST4_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[13].price_attack_int;
        GHOST4_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[13].price_defense_int;
        GHOST4_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[13].price_attack_range_int;
        GHOST4_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[13].price_attack_type_int;
        GHOST4_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[13].price_slanting_wall_bool;
        GHOST4_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        RABBIT4_NAME = GameManager.instance.enemy_state_data.sheets[0].list[14].price_name_string;
        RABBIT4_HP = GameManager.instance.enemy_state_data.sheets[0].list[14].price_hp_int;
        RABBIT4_MP = GameManager.instance.enemy_state_data.sheets[0].list[14].price_mp_int;
        RABBIT4_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[14].price_attack_int;
        RABBIT4_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[14].price_defense_int;
        RABBIT4_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[14].price_attack_range_int;
        RABBIT4_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[14].price_attack_type_int;
        RABBIT4_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[14].price_slanting_wall_bool;
        RABBIT4_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        SLIME4_NAME = GameManager.instance.enemy_state_data.sheets[0].list[15].price_name_string;
        SLIME4_HP = GameManager.instance.enemy_state_data.sheets[0].list[15].price_hp_int;
        SLIME4_MP = GameManager.instance.enemy_state_data.sheets[0].list[15].price_mp_int;
        SLIME4_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[15].price_attack_int;
        SLIME4_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[15].price_defense_int;
        SLIME4_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[15].price_attack_range_int;
        SLIME4_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[15].price_attack_type_int;
        SLIME4_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[15].price_slanting_wall_bool;
        SLIME4_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        BOSS1_NAME = GameManager.instance.enemy_state_data.sheets[0].list[16].price_name_string;
        BOSS1_HP = GameManager.instance.enemy_state_data.sheets[0].list[16].price_hp_int;
        BOSS1_MP = GameManager.instance.enemy_state_data.sheets[0].list[16].price_mp_int;
        BOSS1_ATTACK = GameManager.instance.enemy_state_data.sheets[0].list[16].price_attack_int;
        BOSS1_DEFENSE = GameManager.instance.enemy_state_data.sheets[0].list[16].price_defense_int;
        BOSS1_ATTACK_RANGE = GameManager.instance.enemy_state_data.sheets[0].list[16].price_attack_range_int;
        BOSS1_ATTACK_TYPE = GameManager.instance.enemy_state_data.sheets[0].list[16].price_attack_type_int;
        BOSS1_SLANTING_WALL = GameManager.instance.enemy_state_data.sheets[0].list[16].price_slanting_wall_bool;
        BOSS1_POSSESSION_EXP = GameManager.instance.enemy_state_data.sheets[0].list[0].price_possession_exp_int;

        //アイテム
        NAME_I1 = GameManager.instance.item_state_data.sheets[0].list[0].price_name_string;
        HEAL_POINT_I1 = GameManager.instance.item_state_data.sheets[0].list[0].price_heal_point_int;
        DEVELOP_I1_MATERIAL_1 = GameManager.instance.item_state_data.sheets[0].list[0].price_develop_material1_int;
        DEVELOP_I1_MATERIAL_2 = GameManager.instance.item_state_data.sheets[0].list[0].price_develop_material2_int;
        DEVELOP_I1_MATERIAL_3 = GameManager.instance.item_state_data.sheets[0].list[0].price_develop_material3_int;
        DEVELOP_NEED_MP_I1 = GameManager.instance.item_state_data.sheets[0].list[0].price_develop_need_mp_int;

        NAME_I2 = GameManager.instance.item_state_data.sheets[0].list[1].price_name_string;
        ATTACK_POINT_I2 = GameManager.instance.item_state_data.sheets[0].list[1].price_attack_point_int;
        ATTACK_TYPE = GameManager.instance.item_state_data.sheets[0].list[1].price_attack_type_int;
        ATTACK_RANGE = GameManager.instance.item_state_data.sheets[0].list[1].price_attack_range_int;
        DEVELOP_I2_MATERIAL_1 = GameManager.instance.item_state_data.sheets[0].list[1].price_develop_material1_int;
        DEVELOP_I2_MATERIAL_2 = GameManager.instance.item_state_data.sheets[0].list[1].price_develop_material2_int;
        DEVELOP_I2_MATERIAL_3 = GameManager.instance.item_state_data.sheets[0].list[1].price_develop_material3_int;
        DEVELOP_NEED_MP_I2 = GameManager.instance.item_state_data.sheets[0].list[1].price_develop_need_mp_int;

        /*
        NAME_I3 = GameManager.instance.item_state_data.sheets[0].list[2].price_name_string;
        ATTACK_TYPE = GameManager.instance.item_state_data.sheets[0].list[2].price_attack_type_int;
        ATTACK_RANGE = GameManager.instance.item_state_data.sheets[0].list[2].price_attack_range_int;
        DEVELOP_I3_MATERIAL_1 = GameManager.instance.item_state_data.sheets[0].list[2].price_develop_material1_int;
        DEVELOP_I3_MATERIAL_2 = GameManager.instance.item_state_data.sheets[0].list[2].price_develop_material2_int;
        DEVELOP_I3_MATERIAL_3 = GameManager.instance.item_state_data.sheets[0].list[2].price_develop_material3_int;
        DEVELOP_NEED_MP_I3 = GameManager.instance.item_state_data.sheets[0].list[2].price_develop_need_mp_int;
        */
        NAME_I4 = GameManager.instance.item_state_data.sheets[0].list[3].price_name_string;
        HEAL_POINT_I4 = GameManager.instance.item_state_data.sheets[0].list[3].price_heal_point_int;
        DEVELOP_I4_MATERIAL_1 = GameManager.instance.item_state_data.sheets[0].list[3].price_develop_material1_int;
        DEVELOP_I4_MATERIAL_2 = GameManager.instance.item_state_data.sheets[0].list[3].price_develop_material2_int;
        DEVELOP_I4_MATERIAL_3 = GameManager.instance.item_state_data.sheets[0].list[3].price_develop_material3_int;
        DEVELOP_NEED_MP_I4 = GameManager.instance.item_state_data.sheets[0].list[3].price_develop_need_mp_int;

        //武器ステータス
        NAME_W1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_name_string;
        HP_W1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_hp_int;
        ATTACK_W1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_attack_int;
        DEFENSE_W1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_defense_int;
        ATTACK_RANGE_W1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_attack_range_int;
        ATTACK_TYPE_W1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_attack_type_int;
        ATTACK_THROUGH_W1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_attack_through_bool;
        SLANTING_WALL_W1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_slanting_wall_bool;
        DEVELOP_W1_MATERIAL_1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_develop_material1_int;
        DEVELOP_W1_MATERIAL_2 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_develop_material2_int;
        DEVELOP_W1_MATERIAL_3 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_develop_material3_int;
        MP_COST_W1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_mp_cost_int;
        ENDURANCE_W1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_endurance_int;
        DEVELOP_NEED_MP_W1 = GameManager.instance.weapon_state_data.sheets[0].list[0].price_develop_need_mp_int;

        NAME_W2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_name_string;
        HP_W2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_hp_int;
        ATTACK_W2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_attack_int;
        DEFENSE_W2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_defense_int;
        ATTACK_RANGE_W2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_attack_range_int;
        ATTACK_TYPE_W2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_attack_type_int;
        ATTACK_THROUGH_W2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_attack_through_bool;
        SLANTING_WALL_W2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_slanting_wall_bool;
        DEVELOP_W2_MATERIAL_1 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_develop_material1_int;
        DEVELOP_W2_MATERIAL_2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_develop_material2_int;
        DEVELOP_W2_MATERIAL_3 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_develop_material3_int;
        MP_COST_W2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_mp_cost_int;
        ENDURANCE_W2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_endurance_int;
        DEVELOP_NEED_MP_W2 = GameManager.instance.weapon_state_data.sheets[0].list[1].price_develop_need_mp_int;

        NAME_W3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_name_string;
        HP_W3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_hp_int;
        ATTACK_W3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_attack_int;
        DEFENSE_W3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_defense_int;
        ATTACK_RANGE_W3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_attack_range_int;
        ATTACK_TYPE_W3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_attack_type_int;
        ATTACK_THROUGH_W3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_attack_through_bool;
        SLANTING_WALL_W3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_slanting_wall_bool;
        DEVELOP_W3_MATERIAL_1 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_develop_material1_int;
        DEVELOP_W3_MATERIAL_2 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_develop_material2_int;
        DEVELOP_W3_MATERIAL_3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_develop_material3_int;
        MP_COST_W3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_mp_cost_int;
        ENDURANCE_W3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_endurance_int;
        DEVELOP_NEED_MP_W3 = GameManager.instance.weapon_state_data.sheets[0].list[2].price_develop_need_mp_int;

        NAME_W4 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_name_string;
        HP_W4 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_hp_int;
        ATTACK_W4 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_attack_int;
        DEFENSE_W4 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_defense_int;
        ATTACK_RANGE_W4 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_attack_range_int;
        ATTACK_TYPE_W4 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_attack_type_int;
        ATTACK_THROUGH_W4 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_attack_through_bool;
        SLANTING_WALL_W4 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_slanting_wall_bool;
        DEVELOP_W4_MATERIAL_1 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_develop_material1_int;
        DEVELOP_W4_MATERIAL_2 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_develop_material2_int;
        DEVELOP_W4_MATERIAL_3 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_develop_material3_int;
        MP_COST_W4 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_mp_cost_int;
        ENDURANCE_W4 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_endurance_int;
        DEVELOP_NEED_MP_W4 = GameManager.instance.weapon_state_data.sheets[0].list[3].price_develop_need_mp_int;

        NAME_W5 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_name_string;
        HP_W5 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_hp_int;
        ATTACK_W5 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_attack_int;
        DEFENSE_W5 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_defense_int;
        ATTACK_RANGE_W5 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_attack_range_int;
        ATTACK_TYPE_W5 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_attack_type_int;
        ATTACK_THROUGH_W5 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_attack_through_bool;
        SLANTING_WALL_W5 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_slanting_wall_bool;
        DEVELOP_W5_MATERIAL_1 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_develop_material1_int;
        DEVELOP_W5_MATERIAL_2 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_develop_material2_int;
        DEVELOP_W5_MATERIAL_3 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_develop_material3_int;
        MP_COST_W5 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_mp_cost_int;
        ENDURANCE_W5 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_endurance_int;
        DEVELOP_NEED_MP_W5 = GameManager.instance.weapon_state_data.sheets[0].list[4].price_develop_need_mp_int;

        NAME_M1 = GameManager.instance.material_state_data.sheets[0].list[0].price_name_string;

        NAME_M2 = GameManager.instance.material_state_data.sheets[0].list[1].price_name_string;

        NAME_M3 = GameManager.instance.material_state_data.sheets[0].list[2].price_name_string;







        Map = Instantiate(map_object, new Vector3(0, 0, 0), Quaternion.identity);

        mapcreat = true;

        FloorText = GameObject.Find("FloorLevel");
            GameManager.instance.floorlevel++;


        //階数に応じて敵が強くなる
        if(GameManager.instance.floorlevel % 10 == 1 && GameManager.instance.floorlevel <= 40)
        {
            GameManager.instance.floor_enemy_level_coefficient = 1f;
        }

        GameManager.instance.floor_enemy_level_coefficient *= GameManager.instance.floor_level_coefficient;


        GameManager.instance.roomlist.Clear();
        GameManager.instance.roomlist_0.Clear();
        GameManager.instance.roomlist_1.Clear();
        GameManager.instance.roomlist_2.Clear();
        GameManager.instance.roomlist_3.Clear();
        GameManager.instance.roomlist_4.Clear();
        GameManager.instance.roomlist_5.Clear();
        GameManager.instance.roomlist_6.Clear();
        GameManager.instance.roomlist_7.Clear();
        GameManager.instance.roomlist_8.Clear();
        GameManager.instance.entrancelist_0.Clear();
            GameManager.instance.entrancelist_1.Clear();
            GameManager.instance.entrancelist_2.Clear();
            GameManager.instance.entrancelist_3.Clear();
            GameManager.instance.entrancelist_4.Clear();
            GameManager.instance.entrancelist_5.Clear();
            GameManager.instance.entrancelist_6.Clear();
            GameManager.instance.entrancelist_7.Clear();
            GameManager.instance.entrancelist_8.Clear();


        map = new map_state[MAX_X + 4, MAX_Y + 4];
        room_x = new int[3, 2, 3];
        room_y = new int[3, 2, 3];

        map_camera_obj = new map_camera_object[MAX_X + 4, MAX_Y + 4];

        map_ex = new map_exist[MAX_X + 4, MAX_Y + 4];

        map_item = new map_item[MAX_X + 4, MAX_Y + 4];

        mini_map = new GameObject[MAX_X + 4,MAX_Y + 4];

        grid_color = new Renderer[MAX_X + 4, MAX_Y + 4];

        for (i1 = 0; i1 < MAX_X + 4; i1++)
        {
            for (i2 = 0; i2 < MAX_X + 4; i2++)
            {
                map[i1, i2] = new wall();
                map_ex[i1, i2] = new clear();
                map_item[i1, i2] = new clean();
            }
        }//map全て壁にする、map_ex全て空欄に


        Xline[0] = Random.Range(10, 16);
        Xline[1] = Random.Range(Xline[0] + 6, Xline[0] + 11);

        Yline[0] = Random.Range(10, 16);
        Yline[1] = Random.Range(Yline[0] + 6, Yline[0] + 11);
        //部屋を分割



        for (i3 = 0; i3 < 3; i3++)
        {
            room_x[0, 0, i3] = Random.Range(6, Xline[0] - 3);
            room_x[0, 1, i3] = Random.Range(room_x[0, 0, i3] + 2, Xline[0] - 1);
            room_x[1, 0, i3] = Random.Range(Xline[0] + 2, Xline[1] - 3);
            room_x[1, 1, i3] = Random.Range(room_x[1, 0, i3] + 2, Xline[1] - 1);
            room_x[2, 0, i3] = Random.Range(Xline[1] + 2, MAX_X - 4);
            room_x[2, 1, i3] = Random.Range(room_x[2, 0, i3] + 2, MAX_X - 4);
        }
        for (i3 = 0; i3 < 3; i3++)
        {
            room_y[0, 0, i3] = Random.Range(6, Yline[0] - 3);
            room_y[0, 1, i3] = Random.Range(room_y[0, 0, i3] + 2, Yline[0] - 1);
            room_y[1, 0, i3] = Random.Range(Yline[0] + 2, Yline[1] - 3);
            room_y[1, 1, i3] = Random.Range(room_y[1, 0, i3] + 2, Yline[1] - 1);
            room_y[2, 0, i3] = Random.Range(Yline[1] + 2, MAX_Y - 4);
            room_y[2, 1, i3] = Random.Range(room_y[2, 0, i3] + 2, MAX_Y - 4);
        }

        i2 = 0;
        for (i1 = 0; i1 < 9; i1++) {
            room_0[i1] = Random.Range(0, 2);
            if (room_0[i1] == 0)
            {
                i2++;
            }
        }
        if (i2 > 6)
        {
            room_0[0] = 1;
            room_0[1] = 1;
        }


        //部屋をつくる

        for (i1 = 0; i1 < 3; i1++)
        {
            for (i2 = 0; i2 < 3; i2++)
            {
                if ((i1 == 0 && i2 == 0 && room_0[0] == 1) ||
                    (i1 == 1 && i2 == 0 && room_0[1] == 1) ||
                    (i1 == 2 && i2 == 0 && room_0[2] == 1) ||
                    (i1 == 0 && i2 == 1 && room_0[3] == 1) ||
                    (i1 == 1 && i2 == 1 && room_0[4] == 1) ||
                    (i1 == 2 && i2 == 1 && room_0[5] == 1) ||
                    (i1 == 0 && i2 == 2 && room_0[6] == 1) ||
                    (i1 == 1 && i2 == 2 && room_0[7] == 1) ||
                    (i1 == 2 && i2 == 2 && room_0[8] == 1))
                {
                    for (i3 = room_x[i1, 0, i2]; i3 <= room_x[i1, 1, i2]; i3++)
                    {
                        for (i4 = room_y[i2, 0, i1]; i4 <= room_y[i2, 1, i1]; i4++)
                        {
                            map[i3, i4] = new room();
                            if (i1 == 0 && i2 == 2)
                            {
                                map[i3, i4].room_No = 0;
                                GameManager.instance.roomlist_0.Add(new Vector3(i3, 0, i4));
                            }
                            else if (i1 == 1 && i2 == 2)
                            {
                                map[i3, i4].room_No = 1;
                                GameManager.instance.roomlist_1.Add(new Vector3(i3, 0, i4));
                            }
                            else if (i1 == 2 && i2 == 2)
                            {
                                map[i3, i4].room_No = 2;
                                GameManager.instance.roomlist_2.Add(new Vector3(i3, 0, i4));
                            }
                            else if (i1 == 0 && i2 == 1)
                            {
                                map[i3, i4].room_No = 3;
                                GameManager.instance.roomlist_3.Add(new Vector3(i3, 0, i4));
                            }
                            else if (i1 == 1 && i2 == 1)
                            {
                                map[i3, i4].room_No = 4;
                                GameManager.instance.roomlist_4.Add(new Vector3(i3, 0, i4));
                            }
                            else if (i1 == 2 && i2 == 1)
                            {
                                map[i3, i4].room_No = 5;
                                GameManager.instance.roomlist_5.Add(new Vector3(i3, 0, i4));
                            }
                            else if (i1 == 0 && i2 == 0)
                            {
                                map[i3, i4].room_No = 6;
                                GameManager.instance.roomlist_6.Add(new Vector3(i3, 0, i4));
                            }
                            else if (i1 == 1 && i2 == 0)
                            {
                                map[i3, i4].room_No = 7;
                                GameManager.instance.roomlist_7.Add(new Vector3(i3, 0, i4));
                            }
                            else if (i1 == 2 && i2 == 0)
                            {
                                map[i3, i4].room_No = 8;
                                GameManager.instance.roomlist_8.Add(new Vector3(i3, 0, i4));
                            }
                            
                            GameManager.instance.roomlist.Add(new Vector3(i3, 0, i4));
                        }
                    }
                }
            }
        }
        //2で部屋を設定,部屋終了

        for (i1 = 0; i1 < 2; i1++)
        {
            for (i2 = 1; i2 <= MAX_X + 2; i2++)
            {
                map[i2, Yline[i1]].number = 10;
                map[Xline[i1], i2].number = 10;
            }
        }

        for (i1 = 0; i1 < 9; i1++)
        {
            if (room_0[i1] == 1)
            {
                switch (i1)
                {
                    case 0:





                        r = Random.Range(0, 3);
                        z1 = Random.Range(room_x[0, 0, 0], room_x[0, 1, 0] + 1);
                        z2 = Random.Range(room_y[0, 1, 0], room_y[0, 0, 0] + 1);

                        if (r == 0 || r == 1)
                        {
                            z2 = Random.Range(room_y[0, 1, 0], room_y[0, 0, 0] + 1);
                            i2 = room_x[0, 1, 0];

                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 6;


                            for (int i = 0; i < GameManager.instance.entrancelist_6.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_6[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_6.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;

                            i2++;

                            while (true)
                            {
                                if (i2 == Xline[0])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;

                                i2++;

                            }
                            map[i2, z2] = new intersection();
                        }
                        if (r == 0 || r == 2)
                        {
                            z1 = Random.Range(room_x[0, 0, 0], room_x[0, 1, 0] + 1);
                            i2 = room_y[0, 1, 0];

                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 6;

                            for(int i = 0;i < GameManager.instance.entrancelist_6.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_6[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if(duplication != true)
                            {
                                GameManager.instance.entrancelist_6.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;
                            i2++;

                            while (true) {

                                if (i2 == Yline[0])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2++;

                            }
                            map[z1, i2] = new intersection();
                        }
                        break;


                    case 1:
                        z1 = Random.Range(room_x[1, 0, 0], room_x[1, 1, 0] + 1);
                        z2 = Random.Range(room_y[0, 0, 1], room_y[0, 1, 1] + 1);

                        r = Random.Range(0, 7);
                        if (r == 0 || r == 3 || r == 5 || r == 6)
                        {
                            z2 = Random.Range(room_y[0, 0, 1], room_y[0, 1, 1] + 1);
                            i2 = room_x[1, 0, 0];

                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 7;

                            for (int i = 0; i < GameManager.instance.entrancelist_7.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_7[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_7.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;

                            i2--;
                            while (true)
                            {
                                if (i2 == Xline[0])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;
                                i2--;
                            }
                            map[i2, z2] = new intersection();
                        }
                        if (r == 1 || r == 3 || r == 4 || r == 6)
                        {
                            z1 = Random.Range(room_x[1, 0, 0], room_x[1, 1, 0] + 1);
                            i2 = room_y[0, 1, 1];

                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 7;

                            for (int i = 0; i < GameManager.instance.entrancelist_7.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_7[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_7.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;

                            i2++;
                            while (true)
                            {
                                if (i2 == Yline[0])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2++;
                            }
                            map[z1, i2] = new intersection();
                        }
                        if (r == 2 || r == 4 || r == 5 || r == 6)
                        {
                            z2 = Random.Range(room_y[0, 0, 1], room_y[0, 1, 1] + 1);
                            i2 = room_x[1, 1, 0];
                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 7;

                            for (int i = 0; i < GameManager.instance.entrancelist_7.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_7[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_7.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;

                            i2++;
                            while (true)
                            {
                                if (i2 == Xline[1])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;    //変更
                                i2++;
                            }
                            map[i2, z2] = new intersection();    //変更
                        }
                        break;


                    case 2:
                        z1 = Random.Range(room_x[2, 0, 0], room_x[2, 1, 0] + 1);
                        z2 = Random.Range(room_y[0, 0, 2], room_y[0, 1, 2] + 1);

                        r = Random.Range(0, 3);
                        if (r == 0 || r == 1)
                        {
                            z2 = Random.Range(room_y[0, 0, 2], room_y[0, 1, 2] + 1);
                            i2 = room_x[2, 0, 0];
                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 8;

                            for (int i = 0; i < GameManager.instance.entrancelist_8.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_8[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_8.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;

                            i2--;
                            while (true)
                            {
                                if (i2 == Xline[1])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;
                                i2--;
                            }
                            map[i2, z2] = new intersection();
                        }
                        if (r == 0 || r == 2)
                        {
                            z1 = Random.Range(room_x[2, 0, 0], room_x[2, 1, 0] + 1);
                            i2 = room_y[0, 1, 2];
                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 8;

                            for (int i = 0; i < GameManager.instance.entrancelist_8.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_8[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_8.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;
                            i2++;
                            while (true)
                            {
                                if (i2 == Yline[0])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2++;
                            }
                            map[z1, i2] = new intersection();
                        }
                        break;


                    case 3:
                        z1 = Random.Range(room_x[0, 0, 1], room_x[0, 1, 1] + 1);
                        z2 = Random.Range(room_y[1, 0, 0], room_y[1, 1, 0] + 1);

                        r = Random.Range(0, 7);
                        if (r == 0 || r == 3 || r == 5 || r == 6)
                        {
                            z1 = Random.Range(room_x[0, 0, 1], room_x[0, 1, 1] + 1);
                            i2 = room_y[1, 0, 0];
                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 3;

                            for (int i = 0; i < GameManager.instance.entrancelist_3.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_3[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_3.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;

                            i2--;
                            while (true)
                            {
                                if (i2 == Yline[0])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2--;
                            }
                            map[z1, i2] = new intersection();
                        }
                        if (r == 1 || r == 3 || r == 4 || r == 6)
                        {
                            z2 = Random.Range(room_y[1, 0, 0], room_y[1, 1, 0] + 1);
                            i2 = room_x[0, 1, 1];
                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 3;

                            for (int i = 0; i < GameManager.instance.entrancelist_3.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_3[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_3.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;
                            i2++;
                            while (true)
                            {
                                if (i2 == Xline[0])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;
                                i2++;
                            }
                            map[i2, z2] = new intersection();
                        }
                        if (r == 2 || r == 4 || r == 5 || r == 6)
                        {
                            z1 = Random.Range(room_x[0, 0, 1], room_x[0, 1, 1] + 1);
                            i2 = room_y[1, 1, 0];
                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 3;

                            for (int i = 0; i < GameManager.instance.entrancelist_3.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_3[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_3.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;
                            i2++;
                            while (true)
                            {
                                if (i2 == Yline[1])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2++;
                            }
                            map[z1, i2] = new intersection();
                        }
                        break;


                    case 4:
                        z1 = Random.Range(room_x[1, 0, 1], room_x[1, 1, 1] + 1);
                        z2 = Random.Range(room_y[1, 0, 1], room_y[1, 1, 1] + 1);

                        r = Random.Range(0, 15);
                        if (r == 0 || r == 4 || r == 7 || r == 8 || r == 10 || r == 12 || r == 13 || r == 14)//↑
                        {
                            z1 = Random.Range(room_x[1, 0, 1], room_x[1, 1, 1] + 1);
                            i2 = room_y[1, 0, 1];
                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 4;

                            for (int i = 0; i < GameManager.instance.entrancelist_4.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_4[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_4.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;
                            i2--;
                            while (true)
                            {
                                if (i2 == Yline[0])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2--;
                            }
                            map[z1, i2] = new intersection();
                        }
                        if (r == 1 || r == 4 || r == 5 || r == 9 || r == 10 || r == 11 || r == 13 || r == 14)//→
                        {
                            z2 = Random.Range(room_y[1, 0, 1], room_y[1, 1, 1] + 1);
                            i2 = room_x[1, 1, 1];
                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 4;

                            for (int i = 0; i < GameManager.instance.entrancelist_4.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_4[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_4.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;
                            i2++;
                            while (true)
                            {
                                if (i2 == Xline[1])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;
                                i2++;
                            }
                            map[i2, z2] = new intersection();
                        }
                        if (r == 2 || r == 5 || r == 6 || r == 8 || r == 10 || r == 11 || r == 12 || r == 14)//↓
                        {
                            z1 = Random.Range(room_x[1, 0, 1], room_x[1, 1, 1] + 1);
                            i2 = room_y[1, 1, 1];
                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 4;

                            for (int i = 0; i < GameManager.instance.entrancelist_4.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_4[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_4.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;
                            i2++;
                            while (true)
                            {
                                if (i2 == Yline[1])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2++;
                            }
                            map[z1, i2] = new intersection();
                        }
                        if (r == 3 || r == 6 || r == 7 || r == 9 || r == 11 || r == 12 || r == 13 || r == 14)//←
                        {
                            z2 = Random.Range(room_y[1, 0, 1], room_y[1, 1, 1] + 1);
                            i2 = room_x[1, 0, 1];
                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 4;

                            for (int i = 0; i < GameManager.instance.entrancelist_4.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_4[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_4.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;
                            i2--;
                            while (true)
                            {
                                if (i2 == Xline[0])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;
                                i2--;
                            }
                            map[i2, z2] = new intersection();
                        }
                        break;


                    case 5:
                        z1 = Random.Range(room_x[2, 0, 1], room_x[2, 1, 1] + 1);
                        z2 = Random.Range(room_y[1, 0, 2], room_y[1, 1, 2] + 1);

                        r = Random.Range(0, 7);
                        if (r == 0 || r == 3 || r == 5 || r == 6)
                        {
                            z1 = Random.Range(room_x[2, 0, 1], room_x[2, 1, 1] + 1);
                            i2 = room_y[1, 0, 2];
                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 5;

                            for (int i = 0; i < GameManager.instance.entrancelist_5.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_5[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_5.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;
                            i2--;
                            while (true)
                            {
                                if (i2 == Yline[0])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2--;
                            }
                            map[z1, i2] = new intersection();
                        }
                        if (r == 1 || r == 3 || r == 4 || r == 6)
                        {
                            z2 = Random.Range(room_y[1, 0, 2], room_y[1, 1, 2] + 1);
                            i2 = room_x[2, 0, 1];
                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 5;

                            for (int i = 0; i < GameManager.instance.entrancelist_5.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_5[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_5.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;
                            i2--;
                            while (true)
                            {
                                if (i2 == Xline[1])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;
                                i2--;
                            }
                            map[i2, z2] = new intersection();
                        }
                        if (r == 2 || r == 4 || r == 5 || r == 6)
                        {
                            z1 = Random.Range(room_x[2, 0, 1], room_x[2, 1, 1] + 1);
                            i2 = room_y[1, 1, 2];
                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 5;

                            for (int i = 0; i < GameManager.instance.entrancelist_5.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_5[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_5.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;
                            i2++;
                            while (true)
                            {
                                if (i2 == Yline[1])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2++;
                            }
                            map[z1, i2] = new intersection();
                        }
                        break;


                    case 6:
                        z1 = Random.Range(room_x[0, 0, 2], room_x[0, 1, 2] + 1);
                        z2 = Random.Range(room_y[2, 0, 0], room_y[2, 1, 0] + 1);

                        r = Random.Range(0, 3);
                        if (r == 0 || r == 1)
                        {
                            z2 = Random.Range(room_y[2, 0, 0], room_y[2, 1, 0] + 1);
                            i2 = room_x[0, 1, 2];
                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 0;

                            for (int i = 0; i < GameManager.instance.entrancelist_0.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_0[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_0.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;

                            i2++;
                            while (true)
                            {
                                if (i2 == Xline[0])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;
                                i2++;
                            }
                            map[i2, z2] = new intersection();
                        }
                        if (r == 0 || r == 2)
                        {
                            z1 = Random.Range(room_x[0, 0, 2], room_x[0, 1, 2] + 1);
                            i2 = room_y[2, 0, 0];
                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 0;

                            for (int i = 0; i < GameManager.instance.entrancelist_0.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_0[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_0.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;
                            i2--;
                            while (true)
                            {
                                if (i2 == Yline[1])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2--;
                            }
                            map[z1, i2] = new intersection();
                        }
                        break;


                    case 7:
                        z1 = Random.Range(room_x[1, 0, 2], room_x[1, 1, 2] + 1);
                        z2 = Random.Range(room_y[2, 0, 1], room_y[2, 1, 1] + 1);

                        r = Random.Range(0, 7);
                        if (r == 0 || r == 3 || r == 5 || r == 6)
                        {
                            z2 = Random.Range(room_y[2, 0, 1], room_y[2, 1, 1] + 1);
                            i2 = room_x[1, 0, 2];
                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 1;

                            for (int i = 0; i < GameManager.instance.entrancelist_1.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_1[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_1.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;
                            i2--;
                            while (true)
                            {
                                if (i2 == Xline[0])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;
                                i2--;
                            }
                            map[i2, z2] = new intersection();
                        }
                        if (r == 1 || r == 3 || r == 4 || r == 6)
                        {
                            z1 = Random.Range(room_x[1, 0, 2], room_x[1, 1, 2] + 1);
                            i2 = room_y[2, 0, 1];
                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 1;

                            for (int i = 0; i < GameManager.instance.entrancelist_1.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_1[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_1.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;
                            i2--;
                            while (true)
                            {
                                if (i2 == Yline[1])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2--;
                            }
                            map[z1, i2] = new intersection();
                        }
                        if (r == 2 || r == 4 || r == 5 || r == 6)
                        {
                            z2 = Random.Range(room_y[2, 0, 1], room_y[2, 1, 1] + 1);
                            i2 = room_x[1, 1, 2];
                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 1;

                            for (int i = 0; i < GameManager.instance.entrancelist_1.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_1[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_1.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;
                            i2++;
                            while (true)
                            {
                                if (i2 == Xline[1])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;    //変更
                                i2++;
                            }
                            map[i2, z2] = new intersection();       //変更
                        }
                        break;


                    case 8:
                        z1 = Random.Range(room_x[2, 0, 2], room_x[2, 1, 2] + 1);
                        z2 = Random.Range(room_y[2, 0, 2], room_y[2, 1, 2] + 1);

                        r = Random.Range(0, 3);
                        if (r == 0 || r == 1)
                        {
                            z2 = Random.Range(room_y[2, 0, 2], room_y[2, 1, 2] + 1);
                            i2 = room_x[2, 0, 2];
                            map[i2, z2] = new entrance();
                            map[i2, z2].room_No = 2;

                            for (int i = 0; i < GameManager.instance.entrancelist_2.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_2[i] == new Vector3(i2, 0, z2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_2.Add(new Vector3(i2, 0, z2));
                            }
                            duplication = false;
                            i2--;
                            while (true)
                            {
                                if (i2 == Xline[1])
                                {
                                    break;
                                }
                                map[i2, z2].number = 10;
                                i2--;
                            }
                            map[i2, z2] = new intersection();
                        }
                        if (r == 0 || r == 2)
                        {
                            z1 = Random.Range(room_x[2, 0, 2], room_x[2, 1, 2] + 1);
                            i2 = room_y[2, 0, 2];
                            map[z1, i2] = new entrance();
                            map[z1, i2].room_No = 2;

                            for (int i = 0; i < GameManager.instance.entrancelist_2.Count; i++)
                            {
                                if (GameManager.instance.entrancelist_2[i] == new Vector3(z1, 0, i2))
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication != true)
                            {
                                GameManager.instance.entrancelist_2.Add(new Vector3(z1, 0, i2));
                            }
                            duplication = false;
                            i2--;
                            while (true)
                            {
                                if (i2 == Yline[1])
                                {
                                    break;
                                }
                                map[z1, i2].number = 10;
                                i2--;
                            }
                            map[z1, i2] = new intersection();
                        }
                        break;
                }
            }
        }

        //通路の交差点は残す
        for (i1 = 0; i1 < 2; i1++)
        {
            for (i2 = 0; i2 < 2; i2++)
            {
                map[Xline[i1], Yline[i2]] = new intersection();
            }
        }
        

        //部屋と通路をつなぐ

        i1 = 0;
        while (true)
        {
            if (map[Xline[0], MAX_X + 3 - i1].number == 2 || i1 == MAX_X + 3)
            {
                break;
            }
            map[Xline[0], MAX_X + 3 - i1] = new wall();
            i1++;
        }

        i1 = 0;
        while (true)
        {
            if (map[Xline[1], MAX_X + 3 - i1].number == 2 || i1 == MAX_X + 3)
            {
                break;
            }
            map[Xline[1], MAX_X + 3 - i1] = new wall();
            i1++;
        }

        i1 = 0;
        while (true)
        {
            if (map[Xline[0], i1].number == 2 || i1 == MAX_X + 3)
            {
                break;
            }
            map[Xline[0], i1] = new wall();
            i1++;
        }

        i1 = 0;
        while (true)
        {
            if (map[Xline[1], i1].number == 2 || i1 == MAX_X + 3)
            {
                break;
            }
            map[Xline[1], i1] = new wall();
            i1++;
        }

        i1 = 0;
        while (true)
        {
            if (map[i1, Yline[0]].number == 2 || i1 == MAX_X + 3)
            {
                break;
            }
            map[i1, Yline[0]] = new wall();
            i1++;
        }
        
        i1 = 0;
        while (true)
        {
            if (map[i1, Yline[1]].number == 2 || i1 == MAX_X + 3)
            {
                break;
            }
            map[i1, Yline[1]] = new wall();
            i1++;
        }

        i1 = 0;
        while (true)
        {
            if (map[MAX_X + 3 - i1, Yline[0]].number == 2 || i1 == MAX_X + 3)
            {
                break;
            }
            map[MAX_X + 3 - i1, Yline[0]] = new wall();
            i1++;
        }

        i1 = 0;
        while (true)
        {
            if (map[MAX_X + 3 - i1, Yline[1]].number == 2 || i1 == MAX_X + 3)
            {
                break;
            }
            map[MAX_X + 3 - i1, Yline[1]] = new wall();
            i1++;
        }


        //階段を部屋に配置
        InstantiateInRoom_map_item(Kaidan);

        for (int x = 0; x < MAX_X + 4; x++)
        {
            for (int y = 0; y < MAX_X + 4; y++)
            {
                if (map[x, y].number == 0)
                {
                    map[x,y].obj_wall = Instantiate(wallObject, new Vector3(x, 0, y), Quaternion.identity);
                    map[x, y].obj_wall.transform.parent = Map.transform;
                   // map_camera_obj[x, y].wall = map[x, y].obj;

                    mini_map[x,y] = Instantiate(MiniMapWall, new Vector3(x + minimapdistance, 0, y + minimapdistance), Quaternion.identity);
                    mini_map[x,y].transform.parent = Map.transform;
                    mini_map[x, y].SetActive(false);
                }

                if (map[x, y].number == 1 || map[x, y].number == 2 || map[x, y].number == 3 || map[x, y].number == 5 || map[x, y].number == 10)
                {
                    if (map[x, y].number != 5)
                    {
                        mini_map[x, y] = Instantiate(MiniMapFloor, new Vector3(x + minimapdistance, 0, y + minimapdistance), Quaternion.identity);
                        mini_map[x, y].transform.parent = Map.transform;
                    }
                    mini_map[x, y].SetActive(false);
                }
                
                if (map[x, y].number == 99)
                {
                    map[x,y].obj_wall = Instantiate(wallObject3, new Vector3(x, 0, y), Quaternion.identity);
                    map[x, y].obj_wall.transform.parent = Map.transform;
                }/*壁以外色付け用
                if (map[x, y] == 2)
                {
                    Instantiate(wallObject2, new Vector3(x, 0, y), Quaternion.identity);
                }
        if (map[x, y] == 3)//通路の分岐点
        {
            Instantiate(wallObject3, new Vector3(x, 0, y), Quaternion.identity);
        }
                if (map[x, y] == 4)//部屋の入口
                {
                    Instantiate(wallObject4, new Vector3(x, 0, y), Quaternion.identity);
                }
                */

                if (map[x, y].number != 5)
                {
                    map[x, y].obj_floor = Instantiate(floor, new Vector3(x, -1, y), Quaternion.identity);
                    map[x, y].obj_floor.transform.parent = Map.transform;
                    //map_camera_obj[x, y].floor = map[x, y].obj;
                }

                
            }
        }


        Instantiate(MiniMapClear, new Vector3(125, -1, 125), Quaternion.identity);
        /*for (int x = -25; x < MAX_X + 25; x++)
        {
            for (int y = -25; y < MAX_X + 25; y++)
            {
                //ミニマップの何もない場所
                GameObject clean = Instantiate(MiniMapClear, new Vector3(x + minimapdistance, -1, y + minimapdistance), Quaternion.identity);
                clean.transform.parent = Map.transform;
            }
        }*/

        //アイテムを部屋に配置
        int itemnumber = Random.Range(3, 10);
        for(int i = 0; i < itemnumber; i++)
        {
            int a = Random.Range(0, 100);
            if(a <= 15)
            {
                InstantiateInRoom_map_item(Item1);
            }
            else if(a >= 16 && a <= 19)
            {
                InstantiateInRoom_map_item(Item2);
            }
            /*else if(a >= 18 && a <= 19)
            {
                InstantiateInRoom_map_item(Item3);
            }*/else if(a >= 20 && a <= 69)
            {
                InstantiateInRoom_map_item(Material1);
            }else if(a >= 70 && a <= 91)
            {
                InstantiateInRoom_map_item(Material2);
            }else if(a >= 92 && a <= 97)
            {
                InstantiateInRoom_map_item(Material3);
            }else if(a == 98)
            {
                InstantiateInRoom_map_item(Weapon1);
            }else if(a == 99)
            {
                InstantiateInRoom_map_item(Weapon2);
            }else if(a == 100)
            {
                InstantiateInRoom_map_item(Weapon3);
            }
        }

        //グリッドを隠す
        for (int x = 0; x < MAX_X + 4; x++){
            for(int z = 0; z < MAX_Y + 4; z++)
            {
                grid_color[x, z] = map[x, z].obj_floor.transform.GetChild(0).GetComponent<Renderer>();
                map[x, z].obj_floor.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        /*
        //10階ごとにボス配置
        if (GameManager.instance.floorlevel % 10 == 0)
        {
            InstantiateBossInRoom(Golem);
        }
        */

        //敵をランダムに配置
        enemynumber = Random.Range(3, 8);
        Random_Enemy_Instantiate(enemynumber);


        FloorText.GetComponent<Text>().text = GameManager.instance.floorlevel +"階";


        //マップのオブジェクトを全消し（プレイヤー移動後に回りだけ表示させる）
        for (int x = 0; x < 44; x++)
        {
            /*for (int z = 0; z < 44; z++)
            {if (map_camera_obj[x, z].floor == true)
                {
                    if (map_camera_obj[x, z].floor.activeSelf == true)
                    {
                        map_camera_obj[x, z].floor.SetActive(false);
                    }
                }
                if (map_camera_obj[x, z].wall == true)
                {
                    if (map_camera_obj[x, z].wall.activeSelf == true)
                    {
                        map_camera_obj[x, z].wall.SetActive(false);
                    }
                }
            }*/
        }

        
            /*デバッグ用、部屋の入口を黄色にする
             * for (int i1 = 0; i1 < GameManager.instance.entrancelist_0.Count; i1++)
            {
                Instantiate(TestObject, GameManager.instance.entrancelist_0[i1], Quaternion.identity);
            }
        for (int i1 = 0; i1 < GameManager.instance.entrancelist_1.Count; i1++)
        {
            Instantiate(TestObject, GameManager.instance.entrancelist_1[i1], Quaternion.identity);
        }
        for (int i1 = 0; i1 < GameManager.instance.entrancelist_2.Count; i1++)
        {
            Instantiate(TestObject, GameManager.instance.entrancelist_2[i1], Quaternion.identity);
        }
        for (int i1 = 0; i1 < GameManager.instance.entrancelist_3.Count; i1++)
        {
            Instantiate(TestObject, GameManager.instance.entrancelist_3[i1], Quaternion.identity);
        }
        for (int i1 = 0; i1 < GameManager.instance.entrancelist_4.Count; i1++)
        {
            Instantiate(TestObject, GameManager.instance.entrancelist_4[i1], Quaternion.identity);
        }
        for (int i1 = 0; i1 < GameManager.instance.entrancelist_5.Count; i1++)
        {
            Instantiate(TestObject, GameManager.instance.entrancelist_5[i1], Quaternion.identity);
        }
        for (int i1 = 0; i1 < GameManager.instance.entrancelist_6.Count; i1++)
        {
            Instantiate(TestObject, GameManager.instance.entrancelist_6[i1], Quaternion.identity);
        }
        for (int i1 = 0; i1 < GameManager.instance.entrancelist_7.Count; i1++)
        {
            Instantiate(TestObject, GameManager.instance.entrancelist_7[i1], Quaternion.identity);
        }
        for (int i1 = 0; i1 < GameManager.instance.entrancelist_8.Count; i1++)
        {
            Instantiate(TestObject, GameManager.instance.entrancelist_8[i1], Quaternion.identity);
        }*/

        GameManager.instance.Map_All_Active_False();

        mapcreat = false;
    }

    

    public void InstantiateInRoom_map_item(GameObject obj)
    {
        Vector3 pos;

            do
            {
                pos = GameManager.instance.roomlist[Random.Range(0, GameManager.instance.roomlist.Count)];

            } while (map_item[(int)pos.x, (int)pos.z].exist == true || map[(int)pos.x, (int)pos.z].number == 5 || map[(int)pos.x, (int)pos.z].number == 0);

        if (obj.tag == "kaidan")
        {
            map[(int)pos.x , (int)pos.z] = new kaidan();
            map[(int)pos.x , (int)pos.z].number = 5;
            map[(int)pos.x, (int)pos.z].obj_floor = Instantiate(obj, new Vector3((int)pos.x, -0.5f, (int)pos.z), Quaternion.identity);
            map[(int)pos.x, (int)pos.z].obj_floor.transform.parent = Map.transform;

            boss_pos_x = (int)pos.x;
            boss_pos_z = (int)pos.z;

        }else if(obj.tag == "Item1")
        {
            map_item[(int)pos.x, (int)pos.z] = new item1(NAME_I1,HEAL_POINT_I1,DEVELOP_I1_MATERIAL_1,DEVELOP_I1_MATERIAL_2,DEVELOP_I1_MATERIAL_3,DEVELOP_NEED_MP_I1);
        }
        else if (obj.tag == "Item2")
        {
            map_item[(int)pos.x, (int)pos.z] = new item2(NAME_I2 , ATTACK_POINT_I2 , ATTACK_RANGE , ATTACK_TYPE , DEVELOP_I2_MATERIAL_1, DEVELOP_I2_MATERIAL_2, DEVELOP_I2_MATERIAL_3, DEVELOP_NEED_MP_I2);
        }
        /*else if (obj.tag == "Item3")
        {
            map_item[(int)pos.x, (int)pos.z] = new item3(NAME_I3 , DEVELOP_I3_MATERIAL_1, DEVELOP_I3_MATERIAL_2, DEVELOP_I3_MATERIAL_3, DEVELOP_NEED_MP_I3);
        }*/else if(obj.tag == "material1")
        {
            map_item[(int)pos.x, (int)pos.z] = new material1(NAME_M1);
        }
        else if(obj.tag == "material2")
        {
            map_item[(int)pos.x, (int)pos.z] = new material2(NAME_M2);
        }
        else if(obj.tag == "material3")
        {
            map_item[(int)pos.x, (int)pos.z] = new material3(NAME_M3);
        }
        else if(obj.tag == "weapon1")
        {
            map_item[(int)pos.x, (int)pos.z] = new weapon1(NAME_W1, HP_W1 , ATTACK_W1 , DEFENSE_W1, ATTACK_RANGE_W1 , ATTACK_TYPE_W1 , ATTACK_THROUGH_W1 , SLANTING_WALL_W1 , DEVELOP_W1_MATERIAL_1, DEVELOP_W1_MATERIAL_2, DEVELOP_W1_MATERIAL_3, MP_COST_W1, ENDURANCE_W1, DEVELOP_NEED_MP_W1);
        }
        else if(obj.tag == "weapon2")
        {
            map_item[(int)pos.x, (int)pos.z] = new weapon2(NAME_W2, HP_W2, ATTACK_W2, DEFENSE_W2, ATTACK_RANGE_W2, ATTACK_TYPE_W2, ATTACK_THROUGH_W2, SLANTING_WALL_W2, DEVELOP_W2_MATERIAL_1, DEVELOP_W2_MATERIAL_2, DEVELOP_W2_MATERIAL_3, MP_COST_W2, ENDURANCE_W2, DEVELOP_NEED_MP_W2);
        }
        else if(obj.tag == "weapon3")
        {
            map_item[(int)pos.x, (int)pos.z] = new weapon3(NAME_W3, HP_W3, ATTACK_W3, DEFENSE_W3, ATTACK_RANGE_W3, ATTACK_TYPE_W3, ATTACK_THROUGH_W3, SLANTING_WALL_W3, DEVELOP_W3_MATERIAL_1, DEVELOP_W3_MATERIAL_2, DEVELOP_W3_MATERIAL_3, MP_COST_W3, ENDURANCE_W3, DEVELOP_NEED_MP_W3);
        }
        

        if (obj.tag != "kaidan")
        {
            //ミニマップも含めてアイテムを生成
            Instantiate_item(Instantiate(obj, new Vector3(pos.x, -0.5f, pos.z), Quaternion.identity), (int)pos.x, (int)pos.z);
            
        }
        else if(obj.tag == "kaidan")
        {
            mini_map[(int)pos.x , (int)pos.z] = Instantiate(MiniMapKaidan, new Vector3(pos.x + map_creat.minimapdistance, 0, pos.z + map_creat.minimapdistance) , Quaternion.identity);
            mini_map[(int)pos.x, (int)pos.z].transform.parent = Map.transform;
        }
    }
    /*private void InstantiateInRoom_map_weapon(GameObject obj)
    {
        Vector3 pos;
        do
        {
            pos = GameManager.instance.roomlist[Random.Range(0, GameManager.instance.roomlist.Count)];

        } while (map_weapon[(int)pos.x , (int)pos.z].exist == true ||map_item[(int)pos.x, (int)pos.z].exist == true || map[(int)pos.x, (int)pos.z].number == 5 || map[(int)pos.x, (int)pos.z].number == 0);

        if (obj.tag == "Material1")
        {
            map_weapon[(int)pos.x, (int)pos.z] = new material();
            map_weapon[(int)pos.x, (int)pos.z].material_no = 1;
        }
        else if (obj.tag == "Material2")
        {
            map_weapon[(int)pos.x, (int)pos.z] = new material();
            map_weapon[(int)pos.x, (int)pos.z].material_no = 2;
        }
        else if (obj.tag == "Material3")
        {
            map_weapon[(int)pos.x, (int)pos.z] = new material();
            map_weapon[(int)pos.x, (int)pos.z].material_no = 3;
        }
        else if (obj.tag == "Equipment")
        {
            map_weapon[(int)pos.x, (int)pos.z] = new equipment();
        }
        else if (obj.tag == "Cannon")
        {
            map_weapon[(int)pos.x, (int)pos.z] = new cannon();
        }
        GameObject obj2 = Instantiate(obj, new Vector3(pos.x, 0, pos.z), Quaternion.identity);
        map_weapon[(int)pos.x, (int)pos.z].obj = obj2;
    }*/
    
    private void Instantiate_item(GameObject Map_item , int pos_x , int pos_z)
    {
        //アイテムを生成し、そのアイテムの子オブジェクトにミニマップ用のオブジェクトを追加
        map_item[pos_x, pos_z].obj = Map_item;
        map_item[pos_x, pos_z].obj.transform.parent = Map.transform;
        map_item[pos_x, pos_z].minimap_item = Instantiate(MiniMapItem, new Vector3(pos_x + map_creat.minimapdistance, 1, pos_z + map_creat.minimapdistance), Quaternion.identity);
        map_item[pos_x, pos_z].minimap_item.transform.parent = map_item[pos_x, pos_z].obj.transform;
        map_item[pos_x, pos_z].minimap_item.SetActive(false);
    }
    

    //敵の種類を決定
    public void Random_Enemy_Instantiate(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int a = Random.Range(0, 10);
            if (0 <= a && a < 5)
            {
                if(GameManager.instance.floorlevel > 30)
                {
                    InstantiateEnemyInRoom(Bat4);
                }
                else if(GameManager.instance.floorlevel > 20)
                {
                    InstantiateEnemyInRoom(Bat3);
                }
                else if (GameManager.instance.floorlevel > 10)
                {
                    InstantiateEnemyInRoom(Bat2);
                }
                else
                {
                    InstantiateEnemyInRoom(Bat1);
                }
                
            }
            else if (5 <= a && a < 7)
            {
                if (GameManager.instance.floorlevel > 30)
                {
                    InstantiateEnemyInRoom(Ghost4);
                }
                else if (GameManager.instance.floorlevel > 20)
                {
                    InstantiateEnemyInRoom(Ghost3);
                }
                else if (GameManager.instance.floorlevel > 10)
                {
                    InstantiateEnemyInRoom(Ghost2);
                }
                else
                {
                    InstantiateEnemyInRoom(Ghost1);
                }
                
            }
            else if (7 <= a && a < 9)
            {
                if (GameManager.instance.floorlevel > 30)
                {
                    InstantiateEnemyInRoom(Rabbit4);
                }
                else if (GameManager.instance.floorlevel > 20)
                {
                    InstantiateEnemyInRoom(Rabbit3);
                }
                else if (GameManager.instance.floorlevel > 10)
                {
                    InstantiateEnemyInRoom(Rabbit2);
                }
                else
                {
                    InstantiateEnemyInRoom(Rabbit1);
                }
                
            }
            else
            {
                if (GameManager.instance.floorlevel > 30)
                {
                    InstantiateEnemyInRoom(Slime4);
                }
                else if (GameManager.instance.floorlevel > 20)
                {
                    InstantiateEnemyInRoom(Slime3);
                }
                else if (GameManager.instance.floorlevel > 10)
                {
                    InstantiateEnemyInRoom(Slime2);
                }
                else
                {
                    InstantiateEnemyInRoom(Slime1);
                }
                
            }
        }
    }

    //部屋にランダムに敵を生成
    private void InstantiateEnemyInRoom(GameObject obj)
    {
        float random = Random.Range(0.8f, 1.2f);

        Vector3 pos;
        do
        {
            pos = GameManager.instance.roomlist[Random.Range(0, GameManager.instance.roomlist.Count)];
        } while (map_ex[(int)pos.x, (int)pos.z].number == 5 || map_ex[(int)pos.x, (int)pos.z].number == 6 || map[(int)pos.x, (int)pos.z].number == 3 || map[(int)pos.x , (int)pos.z].room_No == player.exist_room_no);
        
        if (obj.tag == "bat")
        {
            if (GameManager.instance.floorlevel > 30)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(BAT4_NAME,BAT4_HP,BAT4_MP, BAT4_ATTACK, BAT4_DEFENSE, BAT4_ATTACK_RANGE, BAT4_ATTACK_TYPE, BAT4_SLANTING_WALL , random , BAT4_POSSESSION_EXP);

            }
            else if (GameManager.instance.floorlevel > 20)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(BAT3_NAME, BAT3_HP, BAT3_MP, BAT3_ATTACK, BAT3_DEFENSE, BAT3_ATTACK_RANGE, BAT1_ATTACK_TYPE, BAT3_SLANTING_WALL, random, BAT3_POSSESSION_EXP);

            }
            else if (GameManager.instance.floorlevel > 10)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(BAT2_NAME, BAT2_HP, BAT2_MP, BAT2_ATTACK, BAT2_DEFENSE, BAT2_ATTACK_RANGE, BAT2_ATTACK_TYPE, BAT2_SLANTING_WALL, random, BAT2_POSSESSION_EXP);
            }
            else
            {//マップ管理のクラスと、敵のステータスを入れる
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(BAT1_NAME, BAT1_HP, BAT1_MP, BAT1_ATTACK, BAT1_DEFENSE, BAT1_ATTACK_RANGE, BAT1_ATTACK_TYPE, BAT1_SLANTING_WALL, random, BAT1_POSSESSION_EXP);
            }
            
            }
        else if(obj.tag == "slime")
        {
            if (GameManager.instance.floorlevel > 30)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(SLIME4_NAME,SLIME4_HP, SLIME4_MP, SLIME4_ATTACK, SLIME4_DEFENSE, SLIME4_ATTACK_RANGE, SLIME4_ATTACK_TYPE, SLIME4_SLANTING_WALL, random , SLIME4_POSSESSION_EXP);
            }
            else if (GameManager.instance.floorlevel > 20)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(SLIME3_NAME, SLIME3_HP, SLIME3_MP, SLIME3_ATTACK, SLIME3_DEFENSE, SLIME3_ATTACK_RANGE, SLIME3_ATTACK_TYPE, SLIME3_SLANTING_WALL, random, SLIME3_POSSESSION_EXP);
            }
            else if (GameManager.instance.floorlevel > 10)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(SLIME2_NAME, SLIME2_HP, SLIME2_MP, SLIME2_ATTACK, SLIME2_DEFENSE, SLIME2_ATTACK_RANGE, SLIME2_ATTACK_TYPE, SLIME2_SLANTING_WALL, random, SLIME2_POSSESSION_EXP);
            }
            else
            {//マップ管理のクラスと、敵のステータスを入れる
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(SLIME1_NAME, SLIME1_HP, SLIME1_MP, SLIME1_ATTACK, SLIME1_DEFENSE, SLIME1_ATTACK_RANGE, SLIME1_ATTACK_TYPE, SLIME1_SLANTING_WALL, random, SLIME1_POSSESSION_EXP);
            }
            
        }
        else if(obj.tag == "rabbit")
        {
            if (GameManager.instance.floorlevel > 30)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(RABBIT4_NAME ,RABBIT4_HP, RABBIT4_MP, RABBIT4_ATTACK, RABBIT4_DEFENSE, RABBIT4_ATTACK_RANGE, RABBIT4_ATTACK_TYPE, RABBIT4_SLANTING_WALL, random, RABBIT4_POSSESSION_EXP);
            }
            else if (GameManager.instance.floorlevel > 20)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(RABBIT3_NAME, RABBIT3_HP, RABBIT3_MP, RABBIT3_ATTACK, RABBIT3_DEFENSE, RABBIT3_ATTACK_RANGE, RABBIT3_ATTACK_TYPE, RABBIT3_SLANTING_WALL, random, RABBIT3_POSSESSION_EXP);
            }
            else if (GameManager.instance.floorlevel > 10)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(RABBIT2_NAME, RABBIT2_HP, RABBIT2_MP, RABBIT2_ATTACK, RABBIT2_DEFENSE, RABBIT2_ATTACK_RANGE, RABBIT2_ATTACK_TYPE, RABBIT2_SLANTING_WALL, random, RABBIT2_POSSESSION_EXP);
            }
            else
            {//マップ管理のクラスと、敵のステータスを入れる
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(RABBIT1_NAME, RABBIT1_HP, RABBIT1_MP, RABBIT1_ATTACK, RABBIT1_DEFENSE, RABBIT1_ATTACK_RANGE, RABBIT1_ATTACK_TYPE, RABBIT1_SLANTING_WALL, random, RABBIT1_POSSESSION_EXP);
            }
            
        }
        else if (obj.tag == "ghost")
        {
            if (GameManager.instance.floorlevel > 30)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(GHOST4_NAME ,GHOST4_HP, GHOST4_MP, GHOST4_ATTACK, GHOST4_DEFENSE, GHOST4_ATTACK_RANGE, GHOST4_ATTACK_TYPE, GHOST4_SLANTING_WALL, random, GHOST4_POSSESSION_EXP);
            }
            else if (GameManager.instance.floorlevel > 20)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(GHOST3_NAME, GHOST3_HP, GHOST3_MP, GHOST3_ATTACK, GHOST3_DEFENSE, GHOST3_ATTACK_RANGE, GHOST3_ATTACK_TYPE, GHOST3_SLANTING_WALL, random,GHOST3_POSSESSION_EXP);
            }
            else if (GameManager.instance.floorlevel > 10)
            {
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(GHOST2_NAME, GHOST2_HP, GHOST2_MP, GHOST2_ATTACK, GHOST2_DEFENSE, GHOST2_ATTACK_RANGE, GHOST2_ATTACK_TYPE, GHOST2_SLANTING_WALL, random,GHOST2_POSSESSION_EXP);
            }
            else
            {//マップ管理のクラスと、敵のステータスを入れる
                map_ex[(int)pos.x, (int)pos.z] = new enemy();
                map_ex[(int)pos.x, (int)pos.z].state = new enemystate(GHOST1_NAME, GHOST1_HP, GHOST1_MP, GHOST1_ATTACK, GHOST1_DEFENSE, GHOST1_ATTACK_RANGE, GHOST1_ATTACK_TYPE, GHOST1_SLANTING_WALL, random,GHOST1_POSSESSION_EXP);
            }
            
        }
        GameObject obj2 = Instantiate(obj, new Vector3(pos.x, -0.5f, pos.z), Quaternion.identity);
        
        map_ex[(int)pos.x, (int)pos.z].obj = obj2;
        map_ex[(int)pos.x, (int)pos.z].obj.transform.parent = Map.transform;
            map_ex[(int)pos.x, (int)pos.z].enemy_script = obj2.GetComponent<Enemy_script>();
    }

    private void InstantiateBossInRoom(GameObject obj)
    {
        map_ex[boss_pos_x, boss_pos_z] = new enemy();
        map_ex[boss_pos_x, boss_pos_z].state = new enemystate(BOSS1_NAME ,BOSS1_HP, BOSS1_MP, BOSS1_ATTACK, BOSS1_DEFENSE, BOSS1_ATTACK_RANGE, BOSS1_ATTACK_TYPE, BOSS1_SLANTING_WALL, 1 , BOSS1_POSSESSION_EXP);

        GameObject obj2 = Instantiate(obj, new Vector3(boss_pos_x, -0.5f, boss_pos_z), Quaternion.identity);

        map_ex[boss_pos_x, boss_pos_z].obj = obj2;
        map_ex[boss_pos_x, boss_pos_z].obj.transform.parent = Map.transform;
        map_ex[boss_pos_x, boss_pos_z].enemy_script = obj2.GetComponent<Enemy_script>();
    }



    /*private void MapDebug(int a)
    {
        for(int i = 0; i < GameManager.instance.entrancelist_0.Count; i++)
        {
            Debug.Log(GameManager.instance.entrancelist_0[i]+"A");
            map[(int)GameManager.instance.entrancelist_0[i].x, (int)GameManager.instance.entrancelist_0[i].z] = new test();
        }
        for (int i = 0; i < GameManager.instance.entrancelist_1.Count; i++)
        {
            Debug.Log(GameManager.instance.entrancelist_1[i] + "B");
            map[(int)GameManager.instance.entrancelist_1[i].x, (int)GameManager.instance.entrancelist_1[i].z] = new test();
        }
        for (int i = 0; i < GameManager.instance.entrancelist_2.Count; i++)
        {
            Debug.Log(GameManager.instance.entrancelist_2[i] + "C");
            map[(int)GameManager.instance.entrancelist_2[i].x, (int)GameManager.instance.entrancelist_2[i].z] = new test();
        }
        for (int i = 0; i < GameManager.instance.entrancelist_3.Count; i++)
        {
            Debug.Log(GameManager.instance.entrancelist_3[i] + "D");
            map[(int)GameManager.instance.entrancelist_3[i].x, (int)GameManager.instance.entrancelist_3[i].z] = new test();
        }
        for (int i = 0; i < GameManager.instance.entrancelist_4.Count; i++)
        {
            Debug.Log(GameManager.instance.entrancelist_4[i] + "E");
            map[(int)GameManager.instance.entrancelist_4[i].x, (int)GameManager.instance.entrancelist_4[i].z] = new test();
        }
        for (int i = 0; i < GameManager.instance.entrancelist_5.Count; i++)
        {
            Debug.Log(GameManager.instance.entrancelist_5[i] + "F");
            map[(int)GameManager.instance.entrancelist_5[i].x, (int)GameManager.instance.entrancelist_5[i].z] = new test();
        }
        for (int i = 0; i < GameManager.instance.entrancelist_6.Count; i++)
        {
            Debug.Log(GameManager.instance.entrancelist_6[i] + "G");
            map[(int)GameManager.instance.entrancelist_6[i].x, (int)GameManager.instance.entrancelist_6[i].z] = new test();
        }
        for (int i = 0; i < GameManager.instance.entrancelist_7.Count; i++)
        {
            Debug.Log(GameManager.instance.entrancelist_7[i] + "H");
            map[(int)GameManager.instance.entrancelist_7[i].x, (int)GameManager.instance.entrancelist_7[i].z] = new test();
        }
        for (int i = 0; i < GameManager.instance.entrancelist_8.Count; i++)
        {
            Debug.Log(GameManager.instance.entrancelist_8[i] + "I");
            map[(int)GameManager.instance.entrancelist_8[i].x, (int)GameManager.instance.entrancelist_8[i].z] = new test();
        }
    }*/

    
}





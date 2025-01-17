﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Player_State_Sheet player_state_data;
    public Enemy_State_Sheet enemy_state_data;
    public Item_State_Sheet item_state_data;
    public Material_State_Sheet material_state_data;
    public Weapon_State_Sheet weapon_state_data;
    public Game_System_Sheet game_system_data;
    
    
    //自動回復用
    public int hp_heel_time_count = 0;
    public int mp_heel_time_count = 0;
    public int hp_heel_need_time;
    public int mp_heel_need_time;

    //回避率
    public int Avoid_probability;


    public float floor_enemy_level_coefficient;
    public float floor_level_coefficient;
    public int floorlevel;
    public static GameManager instance = null;

    //移動用の1フレーム分の時間
    public float inverseMoveTime;
    public float moveTime;


    public bool Playerturn;
    public bool PlayerMoving;
    public int EnemyMoving;
    public bool enemyattack;
    public bool Menu;
    public bool coroutine;
    public bool Pose;
    public bool one;
    public bool space;
    public bool kaidan_screen;
    public bool kaidan;

    public int emoveY;
    public int emoveX;
    public int i, a;
    public int enemy_probability;

    public LayerMask blockinglayer;

    private Player_script player_script;
    private map_creat mapscript;
    private MenuController menuscript;
    public GameObject GameOverScreen;


    //public GameObject Enemy;
    private GameObject Player;
    public GameObject Menuobj;
    public GameObject Kaidan_Screen;

    public List<map_exist> damageenemy;
    public List<Enemy_script> enemies;
    public List<Vector3> roomlist;
    public List<Vector3> roomlist_0;
    public List<Vector3> roomlist_1;
    public List<Vector3> roomlist_2;
    public List<Vector3> roomlist_3;
    public List<Vector3> roomlist_4;
    public List<Vector3> roomlist_5;
    public List<Vector3> roomlist_6;
    public List<Vector3> roomlist_7;
    public List<Vector3> roomlist_8;
    public List<Vector3> entrancelist_0;
    public List<Vector3> entrancelist_1;
    public List<Vector3> entrancelist_2;
    public List<Vector3> entrancelist_3;
    public List<Vector3> entrancelist_4;
    public List<Vector3> entrancelist_5;
    public List<Vector3> entrancelist_6;
    public List<Vector3> entrancelist_7;
    public List<Vector3> entrancelist_8;

    public List<map_item> possessionitemlist;
    public List<map_item> possessionweaponlist;
    public List<map_item> possessioncannonlist;
    public List<map_item> developtopiclist;
    public int possession_material_1;
    public int possession_material_2;
    public int possession_material_3;

    public List<Text> MainTexts;
    public Text[] MainText = new Text[3];
    public GameObject HPTEXT;
    private Text HPText;
    public GameObject MPTEXT;
    private Text MPText;

    private Slider hp_slider;
    private Slider mp_slider;
    public GameObject HP_SLIDER;
    public GameObject MP_SLIDER;
    
    public int MAX_TEXT = 50;
    
    public int MAX_ITEM = 20;
    public int MAX_WEAPON = 20;
    public int MAX_CANNON = 20;
    
    public Text T;

    public GameObject MenuScreen;

    public bool map_active;
    public bool main_text_scroll;
    private int text_scroll_frame;

    RectTransform[] Main_Text_Transform;

    //スマホ用移動ボタン
    public bool up_left_button;
    public bool up_button;
    public bool up_right_button;
    public bool left_button;
    public bool right_button;
    public bool down_left_button;
    public bool down_button;
    public bool down_right_button;
    public bool attack_button;
    public bool vector_change_button = false;

    private AudioSource heel;

    private int x, z;
    public GameObject MiniMapPlayerObject;

    void Awake()
    {
        player_state_data = Resources.Load<Player_State_Sheet>("Player_State");
        enemy_state_data = Resources.Load<Enemy_State_Sheet>("Enemy_State");
        item_state_data = Resources.Load<Item_State_Sheet>("Item_State");
        weapon_state_data = Resources.Load<Weapon_State_Sheet>("Weapon_State");
        material_state_data = Resources.Load<Material_State_Sheet>("Material_State");
        game_system_data = Resources.Load<Game_System_Sheet>("Game_System");


        //game_system
        hp_heel_need_time = game_system_data.sheets[0].list[0].price_int;
        mp_heel_need_time = game_system_data.sheets[0].list[1].price_int;
        Avoid_probability = game_system_data.sheets[0].list[2].price_int;
        floor_enemy_level_coefficient = game_system_data.sheets[0].list[3].price_int;
        floor_level_coefficient = game_system_data.sheets[0].list[4].price_float;
        moveTime = game_system_data.sheets[0].list[5].price_float;
        enemy_probability = game_system_data.sheets[0].list[6].price_int;
        text_scroll_frame = game_system_data.sheets[0].list[7].price_int;



        //シングルトン(シーン移動なくなったため不要)
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);

        MainTexts = new List<Text>();

        //EnemyをListで管理
        enemies = new List<Enemy_script>();
        

        //itemをListで管理
        possessionitemlist = new List<map_item>();
        possessionweaponlist = new List<map_item>();
        possessioncannonlist = new List<map_item>();
        developtopiclist = new List<map_item>();

        roomlist = new List<Vector3>();
        roomlist_0 = new List<Vector3>();
        roomlist_1 = new List<Vector3>();
        roomlist_2 = new List<Vector3>();
        roomlist_3 = new List<Vector3>();
        roomlist_4 = new List<Vector3>();
        roomlist_5 = new List<Vector3>();
        roomlist_6 = new List<Vector3>();
        roomlist_7 = new List<Vector3>();
        roomlist_8 = new List<Vector3>();

        entrancelist_0 = new List<Vector3>();
        entrancelist_1 = new List<Vector3>();
        entrancelist_2 = new List<Vector3>();
        entrancelist_3 = new List<Vector3>();
        entrancelist_4 = new List<Vector3>();
        entrancelist_5 = new List<Vector3>();
        entrancelist_6 = new List<Vector3>();
        entrancelist_7 = new List<Vector3>();
        entrancelist_8 = new List<Vector3>();

        damageenemy = new List<map_exist>();

        Main_Text_Transform = new RectTransform[3];

        //コンポーネントを取得

        mapscript = GetComponent<map_creat>();
        menuscript = Menuobj.GetComponent<MenuController>();
        HPText = HPTEXT.GetComponent<Text>();
        MPText = MPTEXT.GetComponent<Text>();
        hp_slider = HP_SLIDER.GetComponent<Slider>();
        mp_slider = MP_SLIDER.GetComponent<Slider>();

        heel = GetComponent<AudioSource>();

        Main_Text_Transform[0] = MainText[0].GetComponent<RectTransform>();
        Main_Text_Transform[1] = MainText[1].GetComponent<RectTransform>();
        Main_Text_Transform[2] = MainText[2].GetComponent<RectTransform>();

        //マップ生成

        floor_level_coefficient = 1.1f;
        mapscript.Mapcreat();
        

        instance.PlayerMoving = false;
        instance.Playerturn = true;
        instance.enemyattack = false;
        instance.Menu = false;
        instance.EnemyMoving = 0;
        coroutine = false;
        space = false;

        one = true;
        enemy_probability = 2;

        Player = GameObject.Find("Player");
        player_script = Player.GetComponent<Player_script>();

        instance.Pose = false;
    }

    // Use this for initialization
    void Start()
    {
        //合成一覧を作成
        map_item item1 = new item1(mapscript.NAME_I1, mapscript.HEAL_POINT_I1, mapscript.DEVELOP_I1_MATERIAL_1, mapscript.DEVELOP_I1_MATERIAL_2, mapscript.DEVELOP_I1_MATERIAL_3, mapscript.DEVELOP_NEED_MP_I1);
        AddListDevelop(item1);
        //map_item item2 = new item2(map_creat.NAME_I2, map_creat.ATTACK_POINT_I2, map_creat.ATTACK_RANGE, map_creat.ATTACK_TYPE, map_creat.DEVELOP_I2_MATERIAL_1, map_creat.DEVELOP_I2_MATERIAL_2, map_creat.DEVELOP_I2_MATERIAL_3, map_creat.DEVELOP_NEED_MP_I2);
        //AddListDevelop(item2);
        //map_item item3 = new item3(map_creat.NAME_I3, map_creat.DEVELOP_I3_MATERIAL_1, map_creat.DEVELOP_I3_MATERIAL_2, map_creat.DEVELOP_I3_MATERIAL_3, map_creat.DEVELOP_NEED_MP_I3);
        //AddListDevelop(item3);
        map_item item4 = new item4(mapscript.NAME_I4, mapscript.HEAL_POINT_I4, mapscript.DEVELOP_I4_MATERIAL_1, mapscript.DEVELOP_I4_MATERIAL_2, mapscript.DEVELOP_I4_MATERIAL_3, mapscript.DEVELOP_NEED_MP_I4);
        AddListDevelop(item4);
        map_item weapon1 = new weapon1(mapscript.NAME_W1, mapscript.HP_W1, mapscript.ATTACK_W1, mapscript.DEFENSE_W1, mapscript.ATTACK_RANGE_W1, mapscript.ATTACK_TYPE_W1, mapscript.ATTACK_THROUGH_W1, mapscript.SLANTING_WALL_W1, mapscript.DEVELOP_W1_MATERIAL_1, mapscript.DEVELOP_W1_MATERIAL_2, mapscript.DEVELOP_W1_MATERIAL_3, mapscript.MP_COST_W1, mapscript.ENDURANCE_W1, mapscript.DEVELOP_NEED_MP_W1);
        AddListDevelop(weapon1);
        map_item weapon2 = new weapon2(mapscript.NAME_W2, mapscript.HP_W2, mapscript.ATTACK_W2, mapscript.DEFENSE_W2, mapscript.ATTACK_RANGE_W2, mapscript.ATTACK_TYPE_W2, mapscript.ATTACK_THROUGH_W2, mapscript.SLANTING_WALL_W2, mapscript.DEVELOP_W2_MATERIAL_1, mapscript.DEVELOP_W2_MATERIAL_2, mapscript.DEVELOP_W2_MATERIAL_3, mapscript.MP_COST_W2, mapscript.ENDURANCE_W2, mapscript.DEVELOP_NEED_MP_W2);
        AddListDevelop(weapon2);
        map_item weapon3 = new weapon3(mapscript.NAME_W3, mapscript.HP_W3, mapscript.ATTACK_W3, mapscript.DEFENSE_W3, mapscript.ATTACK_RANGE_W3, mapscript.ATTACK_TYPE_W3, mapscript.ATTACK_THROUGH_W3, mapscript.SLANTING_WALL_W3, mapscript.DEVELOP_W3_MATERIAL_1, mapscript.DEVELOP_W3_MATERIAL_2, mapscript.DEVELOP_W3_MATERIAL_3, mapscript.MP_COST_W3, mapscript.ENDURANCE_W3, mapscript.DEVELOP_NEED_MP_W3);
        AddListDevelop(weapon3);
        map_item weapon4 = new weapon4(mapscript.NAME_W4, mapscript.HP_W4, mapscript.ATTACK_W4, mapscript.DEFENSE_W4, mapscript.ATTACK_RANGE_W4, mapscript.ATTACK_TYPE_W4, mapscript.ATTACK_THROUGH_W4, mapscript.SLANTING_WALL_W4, mapscript.DEVELOP_W4_MATERIAL_1, mapscript.DEVELOP_W4_MATERIAL_2, mapscript.DEVELOP_W4_MATERIAL_3, mapscript.MP_COST_W4, mapscript.ENDURANCE_W4, mapscript.DEVELOP_NEED_MP_W4);
        AddListDevelop(weapon4);
        map_item weapon5 = new weapon5(mapscript.NAME_W5, mapscript.HP_W5, mapscript.ATTACK_W5, mapscript.DEFENSE_W5, mapscript.ATTACK_RANGE_W5, mapscript.ATTACK_TYPE_W5, mapscript.ATTACK_THROUGH_W5, mapscript.SLANTING_WALL_W5, mapscript.DEVELOP_W5_MATERIAL_1, mapscript.DEVELOP_W5_MATERIAL_2, mapscript.DEVELOP_W5_MATERIAL_3, mapscript.MP_COST_W5, mapscript.ENDURANCE_W5, mapscript.DEVELOP_NEED_MP_W5);
        AddListDevelop(weapon5);

        //初期状態で素材を持たせておく
        possession_material_1 += 5;
        possession_material_2 += 5;
        possession_material_3 += 5;


        inverseMoveTime = 1f / moveTime;
    }
    

    // Update is called once per frame
    void Update ()
    {

        if (instance.Playerturn == true || instance.Menu ==true || instance.Pose == true || coroutine == true || GameManager.instance.PlayerMoving == true)
        {
            return;
        }

        //マップの不要な部分（プレイヤーの周囲6マス）を非表示に
        Map_All_Active_False();
        Map_Open_6_All();

        //プレイヤーの自然回復
        hp_heel_time_count++;
        mp_heel_time_count++;
        if(hp_heel_time_count >= hp_heel_need_time)
        {
            hp_heel_time_count = 0;
            player.player_hp++;
            if(player.player_hp > player.player_MAX_hp)
            {
                player.player_hp = player.player_MAX_hp;
            }
            Hp_Bar();
            HP_Text();
        }
        if(mp_heel_time_count >= mp_heel_need_time)
        {
            mp_heel_time_count = 0;
            player.player_mp++;
            if (player.player_mp > player.player_MAX_mp)
            {
                player.player_mp = player.player_MAX_mp;
            }
            Mp_Bar();
            MP_Text();
        }

        //プレイヤーがどの部屋にいるのか判別
        if (coroutine == false)
        {
            if (map_creat.map[(int)Player.transform.position.x, (int)Player.transform.position.z].number == 2 || map_creat.map[(int)Player.transform.position.x, (int)Player.transform.position.z].number == 10)
        {
            player.exist_room_no = 10;
        }
        else
        {
            player.exist_room_no = map_creat.map[(int)Player.transform.position.x, (int)Player.transform.position.z].room_No;
        }

            
            coroutine = true;

            //敵ターン
            StartCoroutine(MoveEnemies());
        }

        //階段の上にいるとき選択肢を出す
        if (map_creat.map[(int)Player.transform.position.x, (int)Player.transform.position.z].number == 5)
        {

            if (GameManager.instance.kaidan == false)
            {
                GameManager.instance.kaidan = true;
                GameManager.instance.kaidan_screen = true;
                GameManager.instance.Kaidan_Screen.SetActive(true);
            }

        }

    }
    
    //Enemy全体の行動
    IEnumerator MoveEnemies()
    {
        //1ターンの最小時間を0.1秒に、Space押しながらで加速
        /*if (GameManager.instance.space == false /*&& map_creat.map[(int)Player.transform.position.x , (int)Player.transform.position.z] != 3 )
        {
            yield return new WaitForSeconds(0.1f);
        }*/
        
        //敵がいない際、動きが早くなるのを防ぐ
        if(GameManager.instance.enemies.Count == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return null;
            }
        }

        //Enemyを1体ずつ移動
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].Emove();

            //加速機能
            /*if (Input.GetKey(KeyCode.Space)== false /*&& map_creat.map[(int)Player.transform.position.x , (int)Player.transform.position.z] != 3 )
                {
                    yield return null;
                    
                }
        */
        }    
            

        //Playerが動ききってから次の処理へ(プレイヤーの移動が重複しないように)
        while (instance.EnemyMoving != GameManager.instance.enemies.Count)
        {
            yield return null;

        }
        

        //ランダムで敵を生成
        int random_enemy = Random.Range(0, 100);
        if (random_enemy <= enemy_probability)
        {
            int random = Random.Range(1, 3);
            mapscript.Random_Enemy_Instantiate(random);
        }

        GameManager.instance.EnemyMoving = 0;


        instance.Playerturn = true;
        coroutine = false;
        
        }
    

    //Enemyをリストに追加
    public void AddListenemy(Enemy_script script)
    {
        enemies.Add(script);
    }

    //アイテムをリストに追加
    public void AddListItem(map_item item)
    {
            possessionitemlist.Add(item);
    }

    //武器をリストに追加
    public void AddListWeapon(map_item weapon)
    {
        possessionweaponlist.Add(weapon);
    }

    //合成をリストに追加
    public void AddListDevelop(map_item develop)
    {
        developtopiclist.Add(develop);
    }

    //文章の表示
    public void AddMainText(string sentence)
    {
        CancelInvoke("Text_Chancel");

        Text TEXT = Instantiate(T);
        TEXT.text = sentence;

        MainTexts.Add(TEXT);

        //保存した文章を古いものから削除
        if (MainTexts.Count > MAX_TEXT)
        {
            MainTexts.RemoveAt(0);
        }

        //既にテキストが3行表示されている場合、テクストをスクロール
        if (MainText[2].text != "")
        {
            main_text_scroll = true;
            StartCoroutine(Main_Text_Scroll());
            
        }
        else
        {
            if (MainText[0].text == "")
            {
                MainText[0].text = MainTexts[MainTexts.Count - 1].text;
            }
            else if (MainText[1].text == "")
            {

                MainText[1].text = MainTexts[MainTexts.Count - 1].text;
            }
            else if (MainText[2].text == "")
            {

                MainText[2].text = MainTexts[MainTexts.Count - 1].text;
            }
            
            Invoke("Text_Chancel", 3);
        }
    }
    //文章の表示を削除
    void Text_Chancel()
    {
        MainText[0].text = "";
        MainText[1].text = "";
        MainText[2].text = "";
    }

    IEnumerator Main_Text_Scroll()
    {
        MainText[0].gameObject.SetActive(false);

        for (int yield_count = 0; yield_count < text_scroll_frame; yield_count++)
        {
            for (int i = 1; i < 3; i++)
            {
                Main_Text_Transform[i].localPosition += new Vector3(0, 120 / text_scroll_frame, 0);
            }
            yield return null;
        }

        MainText[0].gameObject.SetActive(true);
        MainText[0].text = MainTexts[MainTexts.Count - 3].text;
        MainText[1].text = MainTexts[MainTexts.Count - 2].text;
        MainText[2].text = MainTexts[MainTexts.Count - 1].text;
        
        Main_Text_Transform[1].localPosition = new Vector3(0, 0, 0);
        Main_Text_Transform[2].localPosition = new Vector3(0, -120, 0);

        main_text_scroll = false;
    }

    //HP,MPテキストとバー表示
    public void HP_Text()
    {
        HPText.text = player.player_hp + "/" + player.player_MAX_hp;
    }
    public void MP_Text()
    {
        MPText.text = player.player_mp + "/" + player.player_MAX_mp;
    }
    public void Hp_Bar()
    {
        float hp_bar = (float)player.player_hp / (float)player.player_MAX_hp;
        hp_slider.value = hp_bar;
    }
    public void Mp_Bar()
    {
        float mp_bar = (float)player.player_mp / (float)player.player_MAX_mp;
        mp_slider.value = mp_bar;
    }

    //アイテム使用時のシステム処理
    public void itemuse(int listnum)
    {
        if (GameManager.instance.possessionitemlist[listnum].name == "爆弾")
        {
            //メニュー閉
            GameManager.instance.menuscript.BackButton();
            GameManager.instance.Menu = false;
            MenuScreen.SetActive(false);
            //使用アイテム所持品から削除
            GameManager.instance.possessionitemlist.RemoveAt(listnum);
        }
        else
        {
            //メニュー閉・プレイヤーターン終
            GameManager.instance.menuscript.BackButton();
            GameManager.instance.menuscript.BackButton();
            GameManager.instance.possessionitemlist.RemoveAt(listnum);

            GameManager.instance.Playerturn = false;
        }
    }
    //装備時のシステム処理
    public void weaponuse(int listnum)
    {
        //メニュー閉・プレイヤーターン終
        GameManager.instance.menuscript.BackButton();
        GameManager.instance.menuscript.BackButton();

        GameManager.instance.Playerturn = false;
    }
    
    public void Attack(int attack_range, int attack_type, bool slanting_wall, bool attack_through, int attack_damage)
    {
        player_script.Attack(attack_range, attack_type, slanting_wall, attack_through, attack_damage , Color.white);
    }

    public void Grid_Color(Color color, float position_x, float position_z)
    {
        //if ((position_x >= 0 && position_x < map_creat.MAX_X) || (position_z >= 0 && position_z < map_creat.MAX_Y))
        //{
            map_creat.grid_color[(int)position_x, (int)position_z].material.color = color;
        //}
    }
    public void Grid_Color_White(float position_x, float position_z)
    {
        map_creat.grid_color[(int)position_x, (int)position_z].material.color = Color.white;
    }

    public void Player_Heal_HP(int healpoint)
    {
        player.player_hp += healpoint;
        if (player.player_hp > player.player_MAX_hp)
        {
            player.player_hp = player.player_MAX_hp;
        }
        Heel_Sound_Effect();
        Hp_Bar();
        HP_Text();
        GameManager.instance.AddMainText("クエリのＨＰが" + healpoint + "回復した。");
    }
    public void Player_Heal_MP(int healpoint)
    {
        player.player_mp += healpoint;
        if (player.player_mp > player.player_MAX_mp)
        {
            player.player_mp = player.player_MAX_mp;
        }
        Heel_Sound_Effect();
        
        Mp_Bar();
        MP_Text();
        GameManager.instance.AddMainText("クエリのＭＰが" + healpoint + "回復した。");
    }
    


    public void Kaidan_Get_Off_Yes()
    {
        //階層移動時、instanceのGamaManagerは残り続けるから、Awake,Startは読み込まない、なのでここでデータを変える
        GameManager.instance.Pose = true;
        GameManager.instance.Playerturn = true;
        GameManager.instance.one = true;
        MenuController.menu_one = true;

        GameManager.instance.emoveX = 0;
        GameManager.instance.emoveY = 0;

        GameManager.instance.Player_Heal_MP(10);
        GameManager.instance.Mp_Bar();

        player.exist_room_no = 10;

        GameManager.instance.enemies.Clear();

        kaidan = false;
        kaidan_screen = false;
        Kaidan_Screen.SetActive(false);

        map_exist Player_date = map_creat.map_ex[(int)Player.transform.position.x, (int)Player.transform.position.z];

        Destroy(map_creat.Map);
        Destroy(map_creat.MiniMapPlayer);
        mapscript.Mapcreat();


        do
        {
            x = Random.Range(1, map_creat.MAX_X + 3);
            z = Random.Range(1, map_creat.MAX_Y + 3);
        } while (map_creat.map[x, z].number != 1 || map_creat.map_ex[x, z].number == 6);

        Player.transform.position = new Vector3(x, -0.5f, z);
        map_creat.map_ex[x, z] = Player_date;
        map_creat.map_ex[x, z].obj = Player;
        map_creat.map_ex[x, z].player_script = Player.GetComponent<Player_script>();
        map_creat.MiniMapPlayer = Instantiate(MiniMapPlayerObject, new Vector3(x + map_creat.minimapdistance, 1, z + map_creat.minimapdistance), Quaternion.identity);
        player.exist_room_no = map_creat.map[x, z].room_No;

        Map_Open_6_All();

        GameManager.instance.Pose = false;
    }
    public void Kaidan_Get_Off_No()
    {
        kaidan_screen = false;
        Kaidan_Screen.SetActive(false);
    }

    public void Weapon_Destroy()
    {
        int destroy_weapon;

        for(int i = 0;i < possessionweaponlist.Count; i++)
        {
            if (possessionweaponlist[i].name.Contains("E:") == true)
            {
                destroy_weapon = i;
            }
        }

        player.equipment_weapon.installing(i);
        possessionweaponlist.RemoveAt(i);
    }
    public void Adddamageenemy(map_exist enemy)
    {
        damageenemy.Add(enemy);
    }

    public void Player_Attack_Coroutine_Manager(int attack_range, int attack_type, bool slanting_wall, bool attack_through, int attack, int attack_animation)
    {
        player_script.Player_Attack_Coroutine(attack_range, attack_type, slanting_wall, attack_through, attack, attack_animation);
    }
    public void Heel_Sound_Effect()
    {
        heel.PlayOneShot(heel.clip);
    }

    public void Map_All_Active_False()
    {
        for(int x = 0; x < map_creat.MAX_X + 4; x++)
        {
            for(int z = 0;z < map_creat.MAX_Y + 4;z++)
            {
                if (map_creat.map[x, z].obj_wall != null)
                {
                    map_creat.map[x, z].obj_wall.SetActive(false);
                }
                if (map_creat.map[x, z].obj_floor != null)
                {
                    map_creat.map[x, z].obj_floor.SetActive(false);
                }
            }
        }
    }
    public void Map_Open_6_All()
    {
        for(int ix = (int)Player.transform.position.x - 6; ix <= (int)Player.transform.position.x + 6; ix++)
        {
            for(int iz = (int)Player.transform.position.z - 6;iz <= (int)Player.transform.position.z + 6; iz++)
            {
                if (map_creat.map[ix, iz].obj_wall != null)
                {
                    map_creat.map[ix, iz].obj_wall.SetActive(true);
                }
                if (map_creat.map[ix, iz].obj_floor != null)
                {
                    map_creat.map[ix, iz].obj_floor.SetActive(true);
                }
            }
        }
    }
    public void Map_Player_Move_Obj(int pos_x , int pos_z)
    {
        for (int ix = pos_x - 6; ix <= pos_x + 6; ix++)
        {
            for (int iz = pos_z - 6; iz <= pos_z + 6; iz++)
            {

                if (map_creat.map[ix, iz].obj_wall != null && map_creat.map[ix, iz].obj_wall.activeSelf == false)
                {
                    map_creat.map[ix, iz].obj_wall.SetActive(true);
                }
                if (map_creat.map[ix, iz].obj_floor != null && map_creat.map[ix, iz].obj_floor.activeSelf == false)
                {
                    map_creat.map[ix, iz].obj_floor.SetActive(true);
                }
            }
        }
        
    }

    //スマホ用移動ボタン
    public void Up_Left_Button_On()
    {
        up_left_button = true;
    }
    public void Up_Left_Button_Off()
    {
        up_left_button = false;
    }
    public void Up_Button_On()
    {
        up_button = true;
    }
    public void Up_Button_Off()
    {
        up_button = false;
    }
    public void Up_Right_Button_On()
    {
        up_right_button = true;
    }
    public void Up_Right_Button_Off()
    {
        up_right_button = false;
    }
    public void Left_Button_On()
    {
        left_button = true;
    }
    public void Left_Button_Off()
    {
        left_button = false;
    }
    public void Right_Button_On()
    {
        right_button = true;
    }
    public void Right_Button_Off()
    {
        right_button = false;
    }
    public void Down_Left_Button_On()
    {
        down_left_button = true;
    }
    public void Down_Left_Button_Off()
    {
        down_left_button = false;
    }
    public void Down_Button_On()
    {
        down_button = true;
    }
    public void Down_Button_Off()
    {
        down_button = false;
    }
    public void Down_Right_Button_On()
    {
        down_right_button = true;
    }
    public void Down_Right_Button_Off()
    {
        down_right_button = false;
    }
    public void Vector_Change_Button()
    {
        if (vector_change_button == false)
        {
            vector_change_button = true;
        }
        else if (vector_change_button == true)
        {
            vector_change_button = false;
        }
    }
    public void Attack_Button_On()
    {
        attack_button = true;
    }
    public void Attack_Button_Off()
    {
        attack_button = false;
    }
    public void Game_Over()
    {
        GameOverScreen.SetActive(true);
    }

    public void Title_Button()
    {
        player.player_hp = 100;
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        SceneManager.LoadScene("Title");
    }
}

public class map_state
{
    public int number;
    public int room_No;
    public Vector3 entrance_pos;
    public GameObject obj_floor;
    public GameObject obj_wall;
}




public class wall : map_state
{
    public wall()
    {
        number = 0;
    }
}
public class room : map_state
{
    public room()
    {
        number = 1;
    }
}
public class intersection : map_state
{
    public intersection()
    {
        number = 2;
    }
}
public class entrance : map_state
{
    public entrance()
    {
        number = 3;
    }
}

public class kaidan : map_state
{
    public kaidan()
    {
        number = 5;
    }
}
public class map_camera_object
{
    public GameObject wall;
    public GameObject floor;
}

public class map_item
{
    public GameObject Player;
    public GameObject Menu;
    public MenuController Menu_Controller;
    public string name;
    public int number;
    public bool exist;
    public GameObject obj;
    public GameObject minimap_item;
    
    public string item_description;

    //item1
    public int heal_point;
    
    //item2
    public int attack_point;
    public int attack_range;
    public int attack_type;


    //↓武器用

    public int HP_W;
    public int ATTACK_W;
    public int DEFENSE_W;

    public int ATTACK_RANGE_W;
    public int ATTACK_TYPE_W;
    public bool ATTACK_THROUGH_W;
    public bool SLANTING_WALL_W;
    public int MP_COST_W;
    public int ENDURANCE_W;

    public int develop_need_material1;
    public int develop_need_material2;
    public int develop_need_material3;
    public int develop_need_MP;

    public void use(int listnum) {
        if(GameManager.instance.possessionitemlist[listnum].name == "回復薬")
        {
            GameManager.instance.AddMainText("クエリは回復薬を使用した。");

            GameManager.instance.Player_Heal_HP(heal_point);



            GameManager.instance.itemuse(listnum);
        }
        else if (GameManager.instance.possessionitemlist[listnum].name == "爆弾")
        {
            GameManager.instance.AddMainText("爆弾を使用した");
            GameManager.instance.Player_Attack_Coroutine_Manager(1, 0, true, true, attack_point , 1);
            GameManager.instance.itemuse(listnum);

        }else if(GameManager.instance.possessionitemlist[listnum].name == "場所替え")
        {
            GameManager.instance.AddMainText("クエリは場所替えを使用した。");
            GameManager.instance.itemuse(listnum);

        }else if(GameManager.instance.possessionitemlist[listnum].name == "回復薬（特）")
        {
            GameManager.instance.AddMainText("クエリは回復薬（特）を使用した。");

            GameManager.instance.Player_Heal_HP(heal_point);



            GameManager.instance.itemuse(listnum);
        }


    }

}

public class item : map_item
{
    
}

public class item1 : item
{
    public item1(string NAME , int HEAL_POINT , int DEVELOP_MATERIAL_1, int DEVELOP_MATERIAL_2, int DEVELOP_MATERIAL_3 ,int DEVELOP_NEED_MP)
    {
        name = "回復薬";
        number = 0;
        exist = true;
        heal_point = HEAL_POINT;
        develop_need_material1 = DEVELOP_MATERIAL_1;
        develop_need_material2 = DEVELOP_MATERIAL_2;
        develop_need_material3 = DEVELOP_MATERIAL_3;
        develop_need_MP = DEVELOP_NEED_MP;

        item_description = "青みがかった液体。人体に影響があるどころか、体力を" + heal_point + "回復する。ちょっと苦い。";
    }

    
}
public class item2 : item
{

    void Awake()
    {
    }
    
    public item2(string NAME, int ATTACK_POINT, int ATTACK_RANGE ,int ATTACK_TYPE,int DEVELOP_MATERIAL_1, int DEVELOP_MATERIAL_2, int DEVELOP_MATERIAL_3, int DEVELOP_NEED_MP)
    {

        name = "爆弾";
        number = 0;
        exist = true;
        attack_point = ATTACK_POINT;
        attack_range = ATTACK_RANGE;
        attack_type = ATTACK_TYPE;
        develop_need_material1 = DEVELOP_MATERIAL_1;
        develop_need_material2 = DEVELOP_MATERIAL_2;
        develop_need_material3 = DEVELOP_MATERIAL_3;
        develop_need_MP = DEVELOP_NEED_MP;

        item_description = "見るからに危険そうな見た目をした爆発物。どうやって着火しているのかは不明。正面に" + attack_point + "ダメージを与える。爆風で自身が食らうことはない、とっても不思議。";
    }
    
}
public class item3 : item
{
    public item3(string NAME, int DEVELOP_MATERIAL_1, int DEVELOP_MATERIAL_2, int DEVELOP_MATERIAL_3, int DEVELOP_NEED_MP)
    {
        name = "場所替え";
        number = 0;
        exist = true;
        develop_need_material1 = DEVELOP_MATERIAL_1;
        develop_need_material2 = DEVELOP_MATERIAL_2;
        develop_need_material3 = DEVELOP_MATERIAL_3;
        develop_need_MP = DEVELOP_NEED_MP;

        item_description = "ＨＰを３０回復する";
    }
    public void changeuse(int listnum)
    {
        //〇アイテム効果

        GameManager.instance.AddMainText("場所替えを使用した");
        GameManager.instance.itemuse(listnum);
    }

}

public class item4 : item
{
    public item4(string NAME, int HEAL_POINT, int DEVELOP_MATERIAL_1, int DEVELOP_MATERIAL_2, int DEVELOP_MATERIAL_3, int DEVELOP_NEED_MP)
    {
        name = "回復薬（特）";
        number = 0;
        exist = true;
        heal_point = HEAL_POINT;
        develop_need_material1 = DEVELOP_MATERIAL_1;
        develop_need_material2 = DEVELOP_MATERIAL_2;
        develop_need_material3 = DEVELOP_MATERIAL_3;
        develop_need_MP = DEVELOP_NEED_MP;

        item_description = "回復薬と同じように怪しい色をしている液体。回復薬と比べて回復量がおよそ２倍のお得なアイテム。体力を" + heal_point + "回復する。こっちはちょっと甘くておいしい。";
    }
    
}

public class material1 : map_item
{
    public material1(string NAME_M1)
    {
        name = NAME_M1;
        number = 1;
        exist = true;
    }
}
public class material2: map_item
{
    public material2(string NAME_M2)
    {
        name = NAME_M2;
        number = 1;
        exist = true;
    }
}
public class material3 : map_item
{
    public material3(string NAME_M3)
    {
        name = NAME_M3;
        number = 1;
        exist = true;
    }
}

public class weapon : map_item
{
    

    public string weapon_description;
        
    public void installing(int listnum)
    {
        if (GameManager.instance.possessionweaponlist[listnum].name.Contains("E:") == false)
        {
            player.player_MAX_hp = player.player_origin_hp + HP_W;
            if (player.player_MAX_hp <= player.player_hp)
            {
                player.player_hp = player.player_MAX_hp;
            }
            player.player_attack = player.player_origin_attack + ATTACK_W;
            player.player_defense = player.player_origin_defense + DEFENSE_W;
            

            player.player_attack_range = ATTACK_RANGE_W;
            player.player_attack_type = ATTACK_TYPE_W;
            player.player_attack_through = ATTACK_THROUGH_W;
            player.player_slanting_wall = SLANTING_WALL_W;

            player.equipment_weapon = GameManager.instance.possessionweaponlist[listnum] as weapon;

            for (int i = 0; i < GameManager.instance.possessionweaponlist.Count; i++)
            {
                if (GameManager.instance.possessionweaponlist[i].name.Contains("E:") == true)
                {
                    GameManager.instance.possessionweaponlist[i].name = GameManager.instance.possessionweaponlist[i].name.Replace("E:", "");
                }
            }
            GameManager.instance.AddMainText("クエリは" + GameManager.instance.possessionweaponlist[listnum].name + "を装備した。");

            GameManager.instance.possessionweaponlist[listnum].name = GameManager.instance.possessionweaponlist[listnum].name.Insert(0, "E:");

            GameManager.instance.weaponuse(listnum);
        }else if(GameManager.instance.possessionweaponlist[listnum].name.Contains("E:") == true)
        {
            player.player_MAX_hp = player.player_origin_hp;
            if (player.player_MAX_hp <= player.player_hp)
            {
                player.player_hp = player.player_MAX_hp;
            }
            player.player_attack = player.player_origin_attack;
            player.player_defense = player.player_origin_defense;

            player.player_attack_range = 1;
            player.player_attack_type = 0;
            player.player_attack_through = false;
            player.player_slanting_wall = false;

            if (player.equipment_weapon.ENDURANCE_W > 0)
            {
                GameManager.instance.AddMainText("クエリは" + GameManager.instance.possessionweaponlist[listnum].name + "を外した。");
            }

            player.equipment_weapon = null;

            GameManager.instance.possessionweaponlist[listnum].name = GameManager.instance.possessionweaponlist[listnum].name.Replace("E:", "");
            
            GameManager.instance.weaponuse(listnum);
        }
        GameManager.instance.Hp_Bar();
        GameManager.instance.HP_Text();
    }

    
}
public class weapon1 : weapon
{
    public weapon1(string NAME, int hp_w, int attack_w , int defense_w , int attack_range_w , int attack_type_w , bool attack_through_w , bool slanting_wall_w, int develop_W1_material_1, int develop_W1_material_2, int develop_W1_material_3 , int mp_cost , int endurance, int develop_need_mp)
    {
        exist = true;
        number = 2;
        name = NAME;

        HP_W = hp_w;
        ATTACK_W = attack_w;
        DEFENSE_W = defense_w;

        ATTACK_RANGE_W = attack_range_w;
        ATTACK_TYPE_W = attack_type_w;
        ATTACK_THROUGH_W = attack_through_w;
        SLANTING_WALL_W = slanting_wall_w;
        develop_need_material1 = develop_W1_material_1;
        develop_need_material2 = develop_W1_material_2;
        develop_need_material3 = develop_W1_material_3;
        MP_COST_W = mp_cost;
        ENDURANCE_W = endurance;
        develop_need_MP = develop_need_mp;

        item_description = "水色に輝く宝石。魔力を宿しており、装備するとステータスが上がる。";
    }   
}
public class weapon2 : weapon
{
    public weapon2(string NAME, int hp_w, int attack_w, int defense_w, int attack_range_w, int attack_type_w, bool attack_through_w, bool slanting_wall_w, int develop_W2_material_1, int develop_W2_material_2, int develop_W2_material_3, int mp_cost, int endurance, int develop_need_mp)
    {
        exist = true;
        number = 2;
        name = NAME;

        HP_W = hp_w;
        ATTACK_W = attack_w;
        DEFENSE_W = defense_w;

        ATTACK_RANGE_W = attack_range_w;
        ATTACK_TYPE_W = attack_type_w;
        ATTACK_THROUGH_W = attack_through_w;
        SLANTING_WALL_W = slanting_wall_w;
        develop_need_material1 = develop_W2_material_1;
        develop_need_material2 = develop_W2_material_2;
        develop_need_material3 = develop_W2_material_3;
        MP_COST_W = mp_cost;
        ENDURANCE_W = endurance;
        develop_need_MP = develop_need_mp;

        item_description = "紫色に輝く宝石。魔力を宿しており、装備するとステータスが上がる。";
    }
}
public class weapon3 : weapon
{
    public weapon3(string NAME, int hp_w, int attack_w, int defense_w, int attack_range_w, int attack_type_w, bool attack_through_w, bool slanting_wall_w, int develop_W3_material_1, int develop_W3_material_2, int develop_W3_material_3, int mp_cost, int endurance, int develop_need_mp)
    {
        exist = true;
        number = 2;
        name = NAME; ;

        HP_W = hp_w;
        ATTACK_W = attack_w;
        DEFENSE_W = defense_w;

        ATTACK_RANGE_W = attack_range_w;
        ATTACK_TYPE_W = attack_type_w;
        ATTACK_THROUGH_W = attack_through_w;
        SLANTING_WALL_W = slanting_wall_w;
        develop_need_material1 = develop_W3_material_1;
        develop_need_material2 = develop_W3_material_2;
        develop_need_material3 = develop_W3_material_3;
        MP_COST_W = mp_cost;
        ENDURANCE_W = endurance;
        develop_need_MP = develop_need_mp;

        item_description = "緑色に輝く宝石。魔力を宿しており、装備するとステータスが上がる。";
    }
}
public class weapon4 : weapon
{
    public weapon4(string NAME, int hp_w, int attack_w, int defense_w, int attack_range_w, int attack_type_w, bool attack_through_w, bool slanting_wall_w, int develop_W4_material_1, int develop_W4_material_2, int develop_W4_material_3, int mp_cost, int endurance, int develop_need_mp)
    {
        exist = true;
        number = 2;
        name = NAME; ;

        HP_W = hp_w;
        ATTACK_W = attack_w;
        DEFENSE_W = defense_w;

        ATTACK_RANGE_W = attack_range_w;
        ATTACK_TYPE_W = attack_type_w;
        ATTACK_THROUGH_W = attack_through_w;
        SLANTING_WALL_W = slanting_wall_w;
        develop_need_material1 = develop_W4_material_1;
        develop_need_material2 = develop_W4_material_2;
        develop_need_material3 = develop_W4_material_3;
        MP_COST_W = mp_cost;
        ENDURANCE_W = endurance;
        develop_need_MP = develop_need_mp;

        item_description = "真紅に輝く宝石。魔力を宿しており、装備するとステータスが上がる。";
    }
}
public class weapon5 : weapon
{
    public weapon5(string NAME, int hp_w, int attack_w, int defense_w, int attack_range_w, int attack_type_w, bool attack_through_w, bool slanting_wall_w, int develop_W5_material_1, int develop_W5_material_2, int develop_W5_material_3, int mp_cost, int endurance, int develop_need_mp)
    {
        exist = true;
        number = 2;
        name = NAME; ;

        HP_W = hp_w;
        ATTACK_W = attack_w;
        DEFENSE_W = defense_w;

        ATTACK_RANGE_W = attack_range_w;
        ATTACK_TYPE_W = attack_type_w;
        ATTACK_THROUGH_W = attack_through_w;
        SLANTING_WALL_W = slanting_wall_w;
        develop_need_material1 = develop_W5_material_1;
        develop_need_material2 = develop_W5_material_2;
        develop_need_material3 = develop_W5_material_3;
        MP_COST_W = mp_cost;
        ENDURANCE_W = endurance;
        develop_need_MP = develop_need_mp;

        item_description = "透明に澄んだ水晶。魔力を宿しており、装備するとステータスが上がる。";
    }
}
public class clean : map_item
{
    public clean()
    {
        number = 20;
        exist = false;
    }
}



public class test : map_state
{
    public test()
    {
        number = 99;
    }
}
public class aisle : map_state
{
    public aisle()
    {
        number = 10;
    }
}

public class map_exist
{
    public int number;
    
    public GameObject obj;
    public Player_script player_script;
    public Enemy_script enemy_script;

    public enemystate state;
}

public class player : map_exist
{
    //初期ステータス
    public static int player_MAX_hp = 100;
    public static int player_origin_hp = 100;
    public static int player_hp = 100;
    public static int player_MAX_mp = 100;
    public static int player_origin_mp = 100;
    public static int player_mp = 100;
    public static int player_origin_attack = 6;
    public static int player_attack = 6;
    public static int player_origin_defense = 2;
    public static int player_defense = 2;

    //装備で変わる攻撃タイプ
    public static bool player_attack_through = false;
    public static int player_attack_range = 1;
    public static int player_attack_type = 0;
    public static bool player_slanting_wall = false;

    public static int player_experience = 0;
    public static int player_level = 1;
    public static int exist_room_no;

    public static weapon equipment_weapon;
    

    public player()
    {
        number = 5;
    }
}
public class enemy : map_exist
{
    public enemy()
    {
        number = 6;

    }
}
public class clear : map_exist
{
    public clear()
    {
        number = 10;
    }
}

public class enemystate:map_exist
{
    public string name;
    public int MAX_HP;
    public int HP;
    public int MAX_MP;
    public int MP;
    public int MAX_ATTACK;
    public int ATTACK;
    public int MAX_DEFENSE;
    public int DEFENSE;
    public int RANGE_ATTACK;
    public int ATTACK_TYPE;
    public bool SLANTING_WALL;
    public int POSSESSION_EXP;
    
    public enemystate(string NAME ,float max_hp,float max_mp, float max_attack, float max_defense,int range_attack, int attack_type , bool slanting_wall ,float Random , int possession_exp)
    {
        name = NAME;
        MAX_HP = (int)(max_hp * GameManager.instance.floor_enemy_level_coefficient * Random);
        HP = MAX_HP;
        MAX_MP = (int)(max_mp * GameManager.instance.floor_enemy_level_coefficient * Random);
        MP = MAX_MP;
        MAX_ATTACK = (int)(max_attack * GameManager.instance.floor_enemy_level_coefficient * Random);
        ATTACK = MAX_ATTACK;
        MAX_DEFENSE = (int)(max_defense * GameManager.instance.floor_enemy_level_coefficient * Random);
        DEFENSE = MAX_DEFENSE;
        RANGE_ATTACK = range_attack;
        ATTACK_TYPE = attack_type;
        SLANTING_WALL = slanting_wall;
        POSSESSION_EXP = possession_exp;
    }
}

public class Cannon : map_item
{
    public string cannon_description;

    public Cannon()
    {
        Player = GameObject.Find("Player");
        Menu = GameObject.Find("Menu");
        Menu_Controller = Menu.GetComponent<MenuController>();
    }

    public void set_cannon(int listnum)
    {
        int set_x = 0;
        int set_z = 0;
        //intに変換した際数字が切り捨てられるのを防止
        int angle = ((int)(Player.transform.eulerAngles.y + 0.5));

        //プレイヤーの正面に設置
        if ((angle / 45) % 8 == 2 /*0*/)
        {
            set_x = 1;
            set_z = 0;
        }
        else if ((angle / 45) % 8 == 4 /*2*/)
        {
            set_x = 0;
            set_z = -1;
            
        }
        else if ((angle / 45) % 8 == 6 /*4*/)
        {
            set_x = -1;
            set_z = 0;
        }
        else if ((angle / 45) % 8 == 0 /*6*/)
        {
            set_x = 0;
            set_z = 1;
        }
        else if ((angle / 45) % 8 == 3 /*1*/)
        {
            set_x = 1;
            set_z = -1;
        }
        else if ((angle / 45) % 8 == 5 /*3*/)
        {
            set_x = -1;
            set_z = -1;
        }
        else if ((angle / 45) % 8 == 7 /*5*/)
        {
            set_x = -1;
            set_z = 1;
        }
        else if ((angle / 45) % 8 == 1 /*7*/)
        {
            set_x = 1;
            set_z = 1;
        }

        //設置先は置ける場所か？敵がいない、アイテムが置いてない、階段じゃない、壁じゃない
        if(map_creat.map_item[(int)Player.transform.position.x + set_x , (int)Player.transform.position.z + set_z] == null && map_creat.map_ex[(int)Player.transform.position.x + set_x, (int)Player.transform.position.z + set_z].number == 10 && map_creat.map[(int)Player.transform.position.x + set_x, (int)Player.transform.position.z + set_z].number != 0 && map_creat.map[(int)Player.transform.position.x + set_x, (int)Player.transform.position.z + set_z].number != 5)
        {
            GameObject Map_item;

            int pos_x = (int)Player.transform.position.x;
            int pos_z = (int)Player.transform.position.z;

            map_creat.map_item[pos_x, pos_z] = GameManager.instance.possessionitemlist[listnum];
            map_creat.map_item[pos_x, pos_z].exist = true;
            //map_creat.map_item[pos_x, pos_z].obj = Instantiate(Map_item, new Vector3(pos_x, -0.5f, pos_z), Quaternion.identity);
            map_creat.map_item[pos_x, pos_z].obj.transform.parent = map_creat.Map.transform;
            //map_creat.map_item[pos_x, pos_z].minimap_item =
            //Instantiate(MiniMapItem, new Vector3(pos_x + map_creat.minimapdistance, 1, pos_z + map_creat.minimapdistance), Quaternion.identity);
            map_creat.map_item[pos_x, pos_z].minimap_item.transform.parent =
                map_creat.map_item[pos_x, pos_z].obj.transform;

            Menu_Controller.BackButton();
            Menu_Controller.BackButton();
            GameManager.instance.possessionitemlist.RemoveAt(listnum);
        }
        else
        {
            GameManager.instance.AddMainText("置けそうにない。");
        }
    }
}

public class cannon1
{

}

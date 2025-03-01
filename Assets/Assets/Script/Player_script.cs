﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_script : MonoBehaviour {
    
    private int moveX;
    private int moveY;
    private bool attack;
    private int attack_x, attack_y,x,z;
    public static int asset_rotate;

    public bool notmove, vectorchange;
    
    
    public GameObject Player;
    public GameObject MenuScreen;
    private MenuController menu_controller_script;

    public GameObject HPBAR;

    public GameObject MiniMapPlayerObject;

    private Animator myAnimator;

    private HpBar HPBar;
    

    //private HPText_script HPText;
    
    // Use this for initialization
    void Start()
    {
        menu_controller_script = MenuScreen.GetComponent<MenuController>();

        asset_rotate = 90;

        GameManager.instance.kaidan = false;
        this.notmove = false;

        HPBar = HPBAR.GetComponent<HpBar>();
        //HPText = HPTEXT.GetComponent<HPText_script>();
        

        GameManager.instance.Hp_Bar();
        GameManager.instance.Mp_Bar();
        GameManager.instance.HP_Text();
        GameManager.instance.MP_Text();

        //プレイヤーをマップ内に移動
        do
        {
            x = Random.Range(1, map_creat.MAX_X + 3);
            z = Random.Range(1, map_creat.MAX_Y + 3);
        } while (map_creat.map[x, z].number != 1 || map_creat.map_ex[x, z].number == 6);

        map_creat.map_ex[x, z] = new player();
        map_creat.map_ex[x, z].obj = Player;
        map_creat.map_ex[x, z].player_script = Player.GetComponent<Player_script>();
        map_creat.MiniMapPlayer = Instantiate(MiniMapPlayerObject, new Vector3(x + map_creat.minimapdistance, 1, z + map_creat.minimapdistance), Quaternion.identity);
        player.exist_room_no = map_creat.map[x, z].room_No;
        transform.position = new Vector3(x, -0.5f, z);

        //プレイヤー周りのマップを表示
        GameManager.instance.Map_Open_6_All();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        //プレイヤーターンでないときまたはポーズ時は動かない
        if (GameManager.instance.Playerturn == false||GameManager.instance.Menu == true || GameManager.instance.Pose == true || GameManager.instance.PlayerMoving == true || GameManager.instance.kaidan_screen == true)
        {
            return;
        }
        


        //分岐点で停止
        if (map_creat.map[(int)transform.position.x , (int)transform.position.z].number == 2 || map_creat.map[(int)transform.position.x, (int)transform.position.z].number == 3 || map_creat.map[(int)transform.position.x, (int)transform.position.z].number == 4 || map_creat.map[(int)transform.position.x, (int)transform.position.z].number == 5)
        {
            GameManager.instance.space = false;
        }

        //Cキーを押している間、vectorchangeを有効に
        if ((Input.GetKey(KeyCode.C) || GameManager.instance.vector_change_button == true )&& GameManager.instance.Menu == false)
        {
            this.vectorchange = true;

            if (map_creat.map[x, z].obj_floor.transform.GetChild(0).gameObject.activeSelf == false)
            {

                //マス目を表示
                for (int x = 0; x < map_creat.MAX_X + 4; x++)
                {
                    for (int z = 0; z < map_creat.MAX_Y + 4; z++)
                    {
                        map_creat.map[x, z].obj_floor.transform.GetChild(0).gameObject.SetActive(true);
                    }
                }

                for(int x = 0; x< map_creat.MAX_X + 4; x++)
                {
                    for(int z = 0; z < map_creat.MAX_Y + 4; z++)
                    {
                        GameManager.instance.Grid_Color_White(x, z);
                    }
                }
                //グリッド(Grid)の赤色部分を表示、Attack関数を使っているが、vectorchange==trueのため攻撃はしない

                //Grid,一直線
                Attack(5, 0, true, true, 10,Color.red);

                //Grid,攻撃範囲
                Attack(player.player_attack_range, player.player_attack_type, true, true, 10, Color.yellow);
            }
        }
        else
        {
            this.vectorchange = false;

            if (map_creat.map[x, z].obj_floor.transform.GetChild(0).gameObject.activeSelf == true)
            {

                //マス目表示を消す
                for (int x = 0; x < map_creat.MAX_X + 4; x++)
                {
                    for (int z = 0; z < map_creat.MAX_Y + 4; z++)
                    {
                        map_creat.map[x, z].obj_floor.transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
            }
        }

        //Spaceを押している間、加速
        if (Input.GetKey(KeyCode.Space))
        {
            GameManager.instance.space = true;
        }
        else
        {
            GameManager.instance.space = false;
        }

        
        //向きのみ変更
        if (this.vectorchange == true && GameManager.instance.Menu==false)
        {
            VectorChange();

            for (int x = 0; x < 44; x++)
            {
                for (int z = 0; z < 44; z++)
                {
                    GameManager.instance.Grid_Color_White(x, z);
                }
            }
            //Grid,一直線
            Attack(5, 0, true, true, 10,Color.red);

            //Grid,攻撃範囲
            Attack(player.player_attack_range, player.player_attack_type, true, true, 10, Color.yellow);
        }
        else if(GameManager.instance.Menu == false ) {
            if (Input.GetKey(KeyCode.Z) || GameManager.instance.attack_button == true)
            {

                if(player.equipment_weapon != null)
                {
                    if(player.equipment_weapon.MP_COST_W > player.player_mp)
                    {
                        GameManager.instance.AddMainText("ＭＰが足りない。");
                    }
                    else
                    {
                        GameManager.instance.space = false;
                        
                        //攻撃
                        Player_Attack_Coroutine(player.player_attack_range, player.player_attack_type, player.player_slanting_wall, player.player_attack_through, player.player_attack, 0);

                    }
                }
                else
                {
                    GameManager.instance.space = false;
                    
                    //攻撃
                    Player_Attack_Coroutine(player.player_attack_range, player.player_attack_type, player.player_slanting_wall, player.player_attack_through, player.player_attack, 0);

                }

            } else{
                PlayerMove();
            }
        }
        
        
    }


    private void VectorChange()
    {
        if (Input.GetKey(KeyCode.RightArrow) == true || GameManager.instance.right_button == true)
        {
            transform.eulerAngles = new Vector3(0, 0 + asset_rotate, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow) == true || GameManager.instance.down_button == true)
        {
            transform.eulerAngles = new Vector3(0, 90 + asset_rotate, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) == true || GameManager.instance.left_button == true)
        {
            transform.eulerAngles = new Vector3(0, 180 + asset_rotate, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow) == true || GameManager.instance.up_button)
        {
            transform.eulerAngles = new Vector3(0, 270 + asset_rotate, 0);
        }
        else if (Input.GetKey(KeyCode.E) == true || GameManager.instance.down_right_button)
        {
            transform.eulerAngles = new Vector3(0, 45 + asset_rotate, 0);
        }
        else if (Input.GetKey(KeyCode.W) == true || GameManager.instance.down_left_button)
        {
            transform.eulerAngles = new Vector3(0, 135 + asset_rotate, 0);
        }
        else if (Input.GetKey(KeyCode.Q) == true || GameManager.instance.up_left_button)
        {
            transform.eulerAngles = new Vector3(0, 225 + asset_rotate, 0);
        }
        else if (Input.GetKey(KeyCode.R) == true || GameManager.instance.up_right_button)
        {
            transform.eulerAngles = new Vector3(0, 315 + asset_rotate, 0);
        }
    }


    private void PlayerMove()
    {
        //方向キーの向きに回転、障害物を確認
        if (Input.GetKey(KeyCode.UpArrow) == true || GameManager.instance.up_button == true)
        {
            this.moveY = 1;
            transform.eulerAngles = new Vector3(0, 270 + asset_rotate, 0);
            //移動先に壁と敵がいるか？
            if (map_creat.map_ex[(int)transform.position.x, (int)transform.position.z + moveY].number == 6 || map_creat.map[(int)transform.position.x, (int)transform.position.z + moveY].number == 0)
            {
                
                this.notmove = true;
            }
            if (this.notmove == false && GameManager.instance.Playerturn == true)
            {
                map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY] = map_creat.map_ex[(int)transform.position.x, (int)transform.position.z];
                map_creat.map_ex[(int)transform.position.x, (int)transform.position.z] = new clear();

                //加速移動と通常移動
                if (Input.GetKey(KeyCode.Space) == false)
                {
                    StartCoroutine(SmoothMovement(transform.position + new Vector3(moveX, 0, moveY)));
                }else if(Input.GetKey(KeyCode.Space))
                {
                    transform.position += new Vector3(moveX, 0, moveY);
                    PickUpItem();
                }

                GameManager.instance.Playerturn = false;
            }
            else if (this.notmove == true)
            {
                this.notmove = false;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) == true || GameManager.instance.left_button == true)
        {
            this.moveX = -1;
            transform.eulerAngles = new Vector3(0, 180 + asset_rotate, 0);
            if (map_creat.map_ex[(int)transform.position.x　+ moveX, (int)transform.position.z].number == 6 || map_creat.map[(int)transform.position.x + moveX, (int)transform.position.z].number == 0)
            {
                
                this.notmove = true;
            }
            if (this.notmove == false && GameManager.instance.Playerturn == true)
            {
                map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY] = map_creat.map_ex[(int)transform.position.x, (int)transform.position.z];
                map_creat.map_ex[(int)transform.position.x, (int)transform.position.z] = new clear();
                //加速移動と通常移動
                if (GameManager.instance.space == false)
                {
                    StartCoroutine(SmoothMovement(transform.position + new Vector3(moveX, 0, moveY)));
                }
                else if (GameManager.instance.space == true)
                {
                    transform.position += new Vector3(moveX, 0, moveY);
                    PickUpItem();
                }

                GameManager.instance.Playerturn = false;
            }
            else if (this.notmove == true)
            {
                this.notmove = false;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true || GameManager.instance.right_button == true)
        {
            this.moveX = 1;
            transform.eulerAngles = new Vector3(0, 0 + asset_rotate, 0);
            if (map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z].number == 6 || map_creat.map[(int)transform.position.x + moveX, (int)transform.position.z].number == 0)
            {
               
                this.notmove = true;
            }
            if (this.notmove == false && GameManager.instance.Playerturn == true)
            {
                map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY] = map_creat.map_ex[(int)transform.position.x, (int)transform.position.z];
                map_creat.map_ex[(int)transform.position.x, (int)transform.position.z] = new clear();
                //加速移動と通常移動
                if (GameManager.instance.space == false)
                {
                    StartCoroutine(SmoothMovement(transform.position + new Vector3(moveX, 0, moveY)));
                }
                else if (GameManager.instance.space == true)
                {
                    transform.position += new Vector3(moveX, 0, moveY);
                    PickUpItem();
                }

                GameManager.instance.Playerturn = false;
            }
            else if (this.notmove == true)
            {
                this.notmove = false;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) == true || GameManager.instance.down_button == true)
        {
            this.moveY = -1;
            transform.eulerAngles = new Vector3(0, 90 + asset_rotate, 0);
            if (map_creat.map_ex[(int)transform.position.x, (int)transform.position.z + moveY].number == 6 || map_creat.map[(int)transform.position.x, (int)transform.position.z + moveY].number == 0)
            {
                
                this.notmove = true;
            }
            if (this.notmove == false && GameManager.instance.Playerturn == true)
            {
                map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY] = map_creat.map_ex[(int)transform.position.x, (int)transform.position.z];
                map_creat.map_ex[(int)transform.position.x, (int)transform.position.z] = new clear();
                //加速移動と通常移動
                if (GameManager.instance.space == false)
                {
                    StartCoroutine(SmoothMovement(transform.position + new Vector3(moveX, 0, moveY)));
                }
                else if (GameManager.instance.space == true)
                {
                    transform.position += new Vector3(moveX, 0, moveY);
                    PickUpItem();
                }

                GameManager.instance.Playerturn = false;
            }
            else if (this.notmove == true)
            {
                this.notmove = false;
            }
        }
        else if (Input.GetKey(KeyCode.Q) == true || GameManager.instance.up_left_button == true)
        {
            this.moveX = -1;
            this.moveY = 1;
            transform.eulerAngles = new Vector3(0, 225 + asset_rotate, 0);
            if(map_creat.map[(int)transform.position.x + moveX, (int)transform.position.z].number == 0 || map_creat.map[(int)transform.position.x, (int)transform.position.z + moveY].number == 0)
            {
                this.notmove = true;
            }
            else
            {
                if (map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY].number == 6 || map_creat.map[(int)transform.position.x + moveX, (int)transform.position.z + moveY].number == 0)
                {
                    this.notmove = true;
                }
            }
            
            if (this.notmove == false && GameManager.instance.Playerturn == true)
            {
                map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY] = map_creat.map_ex[(int)transform.position.x, (int)transform.position.z];
                map_creat.map_ex[(int)transform.position.x, (int)transform.position.z] = new clear();
                //加速移動と通常移動
                if (GameManager.instance.space == false)
                {
                    StartCoroutine(SmoothMovement(transform.position + new Vector3(moveX, 0, moveY)));
                }
                else if (GameManager.instance.space == true)
                {
                    transform.position += new Vector3(moveX, 0, moveY);
                    PickUpItem();
                }

                GameManager.instance.Playerturn = false;
            }
            else if (this.notmove == true)
            {
                this.notmove = false;
            }
        }
        else if (Input.GetKey(KeyCode.W) == true || GameManager.instance.down_left_button == true)
        {
            this.moveX = -1;
            this.moveY = -1;
            transform.eulerAngles = new Vector3(0, 135 + asset_rotate, 0);
            if (map_creat.map[(int)transform.position.x + moveX, (int)transform.position.z].number == 0 || map_creat.map[(int)transform.position.x, (int)transform.position.z + moveY].number == 0)
            {
                this.notmove = true;
            }
            else
            {
                if (map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY].number == 6 || map_creat.map[(int)transform.position.x + moveX, (int)transform.position.z + moveY].number == 0)
                {
                    this.notmove = true;
                }
            }

            if (this.notmove == false && GameManager.instance.Playerturn == true)
            {
                map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY] = map_creat.map_ex[(int)transform.position.x, (int)transform.position.z];
                map_creat.map_ex[(int)transform.position.x, (int)transform.position.z] = new clear();
                //加速移動と通常移動
                if (GameManager.instance.space == false)
                {
                    StartCoroutine(SmoothMovement(transform.position + new Vector3(moveX, 0, moveY)));
                }
                else if (GameManager.instance.space == true)
                {
                    transform.position += new Vector3(moveX, 0, moveY);
                    PickUpItem();
                }

                GameManager.instance.Playerturn = false;
            }
            else if (this.notmove == true)
            {
                this.notmove = false;
            }
        }
        else if (Input.GetKey(KeyCode.E) == true || GameManager.instance.down_right_button == true)
        {
            this.moveX = 1;
            this.moveY = -1;
            transform.eulerAngles = new Vector3(0, 45 + asset_rotate, 0);
            if (map_creat.map[(int)transform.position.x + moveX, (int)transform.position.z].number == 0 || map_creat.map[(int)transform.position.x, (int)transform.position.z + moveY].number == 0)
            {
                this.notmove = true;
            }
            else
            {
                if (map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY].number == 6 || map_creat.map[(int)transform.position.x + moveX, (int)transform.position.z + moveY].number == 0)
                {
                    this.notmove = true;
                }
            }

            if (this.notmove == false && GameManager.instance.Playerturn == true)
            {
                map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY] = map_creat.map_ex[(int)transform.position.x, (int)transform.position.z];
                map_creat.map_ex[(int)transform.position.x, (int)transform.position.z] = new clear();
                //加速移動と通常移動
                if (GameManager.instance.space == false)
                {
                    StartCoroutine(SmoothMovement(transform.position + new Vector3(moveX, 0, moveY)));
                }
                else if (GameManager.instance.space == true)
                {
                    transform.position += new Vector3(moveX, 0, moveY);
                    PickUpItem();
                }

                GameManager.instance.Playerturn = false;
            }
            else if (this.notmove == true)
            {
                this.notmove = false;
            }
        }
        else if (Input.GetKey(KeyCode.R) == true || GameManager.instance.up_right_button == true)
        {
            this.moveX = 1;
            this.moveY = 1;
            transform.eulerAngles = new Vector3(0, 315 + asset_rotate, 0);
            if (map_creat.map[(int)transform.position.x + moveX, (int)transform.position.z].number == 0 || map_creat.map[(int)transform.position.x, (int)transform.position.z + moveY].number == 0)
            {
                this.notmove = true;
            }
            else
            {
                if (map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY].number == 6 || map_creat.map[(int)transform.position.x + moveX, (int)transform.position.z + moveY].number == 0)
                {
                    this.notmove = true;
                }
            }

            if (this.notmove == false && GameManager.instance.Playerturn == true)
            {
                map_creat.map_ex[(int)transform.position.x + moveX, (int)transform.position.z + moveY] = map_creat.map_ex[(int)transform.position.x, (int)transform.position.z];
                map_creat.map_ex[(int)transform.position.x, (int)transform.position.z] = new clear();
                //加速移動と通常移動
                if (GameManager.instance.space == false)
                {
                    StartCoroutine(SmoothMovement(transform.position + new Vector3(moveX, 0, moveY)));
                }
                else if (GameManager.instance.space == true)
                {
                    transform.position += new Vector3(moveX, 0, moveY);
                    PickUpItem();
                }
                
                GameManager.instance.Playerturn = false;
            }
            else if (this.notmove == true)
            {
                this.notmove = false;
            }
        }

        //障害物がなく、向きのみ変更でないとき移動


        //変数リセット
        this.moveX = 0;
        this.moveY = 0;
    }

    

    public void PickUpItem()
    {

        if (map_creat.map_item[(int)transform.position.x, (int)transform.position.z].exist == true)
        {

            if (map_creat.map_item[(int)transform.position.x, (int)transform.position.z].number == 0)
            {
                if (GameManager.instance.possessionitemlist.Count < GameManager.instance.MAX_ITEM)
                {
                    GameManager.instance.AddMainText(map_creat.map_item[(int)transform.position.x, (int)transform.position.z].name + "を拾った");

                    GameManager.instance.AddListItem(map_creat.map_item[(int)transform.position.x, (int)transform.position.z]);
                    Destroy(map_creat.map_item[(int)transform.position.x, (int)transform.position.z].obj);
                    map_creat.map_item[(int)transform.position.x, (int)transform.position.z] = new clean();
                }
                else
                {
                    GameManager.instance.AddMainText("持ち物が一杯で拾えない。");
                }
            }
            else if (map_creat.map_item[(int)transform.position.x, (int)transform.position.z].number == 1)
            {
                GameManager.instance.AddMainText(GameManager.instance.player_state_data.sheets[0].list[0].price_name_string + "は" + map_creat.map_item[(int)transform.position.x, (int)transform.position.z].name + "を拾った。");

                if (map_creat.map_item[(int)transform.position.x, (int)transform.position.z].name == GameManager.instance.material_state_data.sheets[0].list[0].price_name_string)
                {
                    GameManager.instance.possession_material_1++;
                    Destroy(map_creat.map_item[(int)transform.position.x, (int)transform.position.z].obj);
                    map_creat.map_item[(int)transform.position.x, (int)transform.position.z] = new clean();
                }
                else if (map_creat.map_item[(int)transform.position.x, (int)transform.position.z].name == GameManager.instance.material_state_data.sheets[0].list[1].price_name_string)
                {
                    GameManager.instance.possession_material_2++;
                    Destroy(map_creat.map_item[(int)transform.position.x, (int)transform.position.z].obj);
                    map_creat.map_item[(int)transform.position.x, (int)transform.position.z] = new clean();
                }
                else if (map_creat.map_item[(int)transform.position.x, (int)transform.position.z].name == GameManager.instance.material_state_data.sheets[0].list[2].price_name_string)
                {
                    GameManager.instance.possession_material_3++;
                    Destroy(map_creat.map_item[(int)transform.position.x, (int)transform.position.z].obj);
                    map_creat.map_item[(int)transform.position.x, (int)transform.position.z] = new clean();
                }
                else { Debug.Log(map_creat.map_item[(int)transform.position.x, (int)transform.position.z].name); }
            }
            else if (map_creat.map_item[(int)transform.position.x, (int)transform.position.z].number == 2)
            {
                if (GameManager.instance.possessionweaponlist.Count < GameManager.instance.MAX_WEAPON)
                {
                    GameManager.instance.AddMainText(GameManager.instance.player_state_data.sheets[0].list[0].price_name_string + "は" + map_creat.map_item[(int)transform.position.x, (int)transform.position.z].name + "を拾った。");

                    GameManager.instance.AddListWeapon(map_creat.map_item[(int)transform.position.x, (int)transform.position.z]);
                    Destroy(map_creat.map_item[(int)transform.position.x, (int)transform.position.z].obj);
                    map_creat.map_item[(int)transform.position.x, (int)transform.position.z] = new clean();
                }
            }
        }
    }

    public int playerdamage(int hp, int attack)
    {
        int damage = attack - player.player_defense;
        if(damage <= 0)
        {
            damage = 0;
        }
        player.player_hp -= damage;
        if (damage > 0)
        {
            GameManager.instance.AddMainText(GameManager.instance.player_state_data.sheets[0].list[0].price_name_string + "は" + damage + "のダメージを受けた。");
        }
        else
        {
            GameManager.instance.AddMainText(GameManager.instance.player_state_data.sheets[0].list[0].price_name_string + "はダメージを受けなかった。");
        }
        GameManager.instance.Hp_Bar();
        GameManager.instance.HP_Text();
        
        return damage;
    }

    public bool playerdie()
    {
        bool player_die;

        if (player.player_hp <= 0)
        {
            player_die = true;
            GameManager.instance.Game_Over();
        }
        else
        {
            player_die = false;
        }

        return player_die;
    }

    public void experience_get(int experience)
    {
        player.player_experience += experience;

    }

    IEnumerator SmoothMovement(Vector3 end)
    {
        GameManager.instance.PlayerMoving = true;
        //現在地から目的地を引き、2点間の距離を求める(Vector3型)
        //sqrMagnitudeはベクトルを2乗したあと2点間の距離に変換する(float型)
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        //2点間の距離が0になった時、ループを抜ける
        //Epsilon : ほとんど0に近い数値を表す
        while (sqrRemainingDistance > float.Epsilon)
        {
            myAnimator.SetInteger("AnimIndex", 1);

            //現在地と移動先の間を1秒間にinverseMoveTime分だけ移動する場合の、
            //1フレーム分の移動距離を算出する
            Vector3 newPosition = Vector3.MoveTowards(transform.position, end, GameManager.instance.inverseMoveTime * Time.deltaTime);
            

            //算出した移動距離分、移動する
            transform.localPosition = newPosition;
            //現在地が目的地寄りになった結果、sqrRemainDistanceが小さくなる
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            //1フレーム待ってから、while文の先頭へ戻る
            yield return null;
            
        }
        PickUpItem();

        GameManager.instance.PlayerMoving = false;

        myAnimator.SetInteger("AnimIndex", 0);

        transform.localPosition = new Vector3((int)end.x, -0.5f, (int)end.z);

        if (map_creat.map_ex[(int)transform.position.x, (int)transform.position.z].number != 5)
        {
            //Debug.Log(gameObject);
        }

        GameManager.instance.kaidan = false;

    }
        
    

    IEnumerator SmoothAttack(int attack_range, int attack_type, bool slanting_wall, bool attack_through, int attack_damage, Color grid_color ,int Player_Animation)
    {
        GameManager.instance.PlayerMoving = true;

        //攻撃方法によってアニメーション変更
        if (Player_Animation == 0)
        {
            GameManager.instance.AddMainText(GameManager.instance.player_state_data.sheets[0].list[0].price_name_string + "の攻撃。");
            myAnimator.SetInteger("AnimIndex", 2);

            yield return null;
            yield return new AnimationWait(myAnimator, 0);

        }else if(Player_Animation == 1)
        {
            myAnimator.SetInteger("AnimIndex", 12);

            yield return null;
            yield return new AnimationWait(myAnimator, 0);
        }

        myAnimator.SetInteger("AnimIndex", 0);

        //装備している場合、ＭＰを消費
        if(player.equipment_weapon != null && Player_Animation == 0)
        {
            player.player_mp -= player.equipment_weapon.MP_COST_W;
            GameManager.instance.Mp_Bar();
            GameManager.instance.MP_Text();
        }


        Attack(attack_range, attack_type, player.player_slanting_wall, player.player_attack_through, player.player_attack, Color.white);

        for(int i = 0; i < GameManager.instance.damageenemy.Count; i++)
        {
            int avoid = Random.Range(0, 100);

            int damage;
            int previous_hp;

            if (avoid >= GameManager.instance.Avoid_probability)
            {

                previous_hp = GameManager.instance.damageenemy[i].state.HP;

                GameManager.instance.damageenemy[i].state.HP = GameManager.instance.damageenemy[i].enemy_script.
                enemydamage(GameManager.instance.damageenemy[i].state.HP, attack_damage, GameManager.instance.damageenemy[i].state.DEFENSE, GameManager.instance.damageenemy[i].state.name);

                damage = previous_hp - GameManager.instance.damageenemy[i].state.HP;

                Animator enemyAnimator = GameManager.instance.damageenemy[i].obj.GetComponent<Animator>();


                if (damage <= 0)
                {

                }
                else if (damage > 0)
                {
                    if (GameManager.instance.damageenemy[i].state.HP > 0)
                    {
                        enemyAnimator.SetInteger("AnimIndex", 3);

                        yield return null;
                        yield return new AnimationWait(enemyAnimator, 0);
                    }
                    else if (GameManager.instance.damageenemy[i].state.HP <= 0)
                    {
                        int get_exp = GameManager.instance.damageenemy[i].state.POSSESSION_EXP;
                        
                        enemyAnimator.SetInteger("AnimIndex", 4);

                        yield return null;
                        yield return new AnimationWait(enemyAnimator, 0);
                        yield return null;
                        GameManager.instance.damageenemy[i].enemy_script.enemydie(GameManager.instance.damageenemy[i].state.name);
                        GameManager.instance.AddMainText(GameManager.instance.player_state_data.sheets[0].list[0].price_name_string + "は" + get_exp + "の経験値を手に入れた");

                        Player_Experience_Get(get_exp);
                    }

                    enemyAnimator.SetInteger("AnimIndex", 0);

                    //武器の耐久を減らし、耐久がなくなったら壊れる
                    if (player.equipment_weapon != null)
                    {
                        player.equipment_weapon.ENDURANCE_W--;

                        if (player.equipment_weapon.ENDURANCE_W <= 0)
                        {
                            GameManager.instance.Weapon_Destroy();

                            GameManager.instance.AddMainText("装備が壊れてしまった。");
                        }
                    }
                }
            }
            else
            {
                GameManager.instance.AddMainText(GameManager.instance.damageenemy[i].state.name + "は攻撃をかわした。");
            }
        }


        yield return new WaitForSeconds(0.1f);

        

        GameManager.instance.damageenemy.Clear();

        GameManager.instance.PlayerMoving = false;
    }

    public void Success_Develop()
    {
        StartCoroutine(Smooth_Success_Develop());
    }

    IEnumerator Smooth_Success_Develop()
    {
        myAnimator.SetInteger("AnimIndex", 5);

        yield return null;
        yield return new AnimationWait(myAnimator, 0);

        myAnimator.SetInteger("AnimIndex", 0);

        yield return new WaitForSeconds(0.1f);

        GameManager.instance.Playerturn = false;

        GameManager.instance.PlayerMoving = false;
    }



    //プレイヤーの向いている方向に攻撃
    public void Attack(int attack_range, int attack_type, bool slanting_wall , bool attack_through, int attack_damage ,Color grid_color)
    {
        if (attack_type == 0)
        {

            if (transform.eulerAngles == new Vector3(0, 0 + asset_rotate, 0))
            {
                line_attack_0(attack_range, attack_type, slanting_wall , attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles == new Vector3(0, 90 + asset_rotate, 0))
            {
                line_attack_90(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles == new Vector3(0, 180 + asset_rotate, 0))
            {
                line_attack_180(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if ((transform.eulerAngles.y >= 265 + asset_rotate && transform.eulerAngles.y <= 270 + asset_rotate) || (transform.eulerAngles.y >= 270 + asset_rotate -360 && transform.eulerAngles.y <= 275 + asset_rotate - 360))
            {
                line_attack_270(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles == new Vector3(0, 45 + asset_rotate, 0))
            {
                line_attack_45(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles.y >= 130 + asset_rotate && transform.eulerAngles.y <= 140 + asset_rotate)
            {
                line_attack_135(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles == new Vector3(0, 225 + asset_rotate, 0))
            {
                line_attack_225(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles.y >= 310 + asset_rotate -360 && transform.eulerAngles.y <= 320 + asset_rotate - 360)
            {
                line_attack_315(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
        }
        else if (attack_type == 1)
        {
            if (transform.eulerAngles == new Vector3(0, 0 + asset_rotate, 0))
            {
                line_attack_0(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_315(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_45(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles == new Vector3(0, 90 + asset_rotate, 0))
            {
                line_attack_90(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_45(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_135(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles == new Vector3(0, 180 + asset_rotate, 0))
            {
                line_attack_180(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_135(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_225(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if ((transform.eulerAngles.y >= 265 + asset_rotate && transform.eulerAngles.y <= 270 + asset_rotate) || (transform.eulerAngles.y >= 270 + asset_rotate - 360 && transform.eulerAngles.y <= 275 + asset_rotate - 360))
            {
                line_attack_270(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_225(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_315(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles == new Vector3(0, 45 + asset_rotate, 0))
            {
                line_attack_45(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_0(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_90(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles.y >= 130 + asset_rotate && transform.eulerAngles.y <= 140 + asset_rotate)
            {
                line_attack_135(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_90(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_180(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles == new Vector3(0, 225 + asset_rotate, 0))
            {
                line_attack_225(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_180(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_270(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
            else if (transform.eulerAngles.y >= 310 + asset_rotate - 360 && transform.eulerAngles.y <= 320 + asset_rotate - 360)
            {
                line_attack_315(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_270(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);

                line_attack_0(attack_range, attack_type, slanting_wall, attack_through, attack_damage, grid_color);
            }
        }

        if (vectorchange == false)
        {
            GameManager.instance.Playerturn = false;
        }
    }


    private void line_attack_0(int attack_range, int attack_type, bool slanting_wall, bool attack_through, int attack_damage , Color grid_color)
    {

        for (int i = 1; i <= attack_range; i++)
        {
            if (vectorchange == false)
            {
                if (map_creat.map[(int)transform.position.x + i, (int)transform.position.z].number == 0)
                {
                    break;
                }
                if (map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z].number == 6)
                {
                    GameManager.instance.Adddamageenemy(map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z]);
                    //map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z].state.HP = map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z].enemy_script.
                    //enemydamage(map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z].state.HP, attack_damage, map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z].state.DEFENSE);

                    if (attack_through == false)
                    {
                        break;
                    }
                }
            }
            else if (vectorchange == true) //グリッド（Grid）、Cキー押しているときは一直線上のＧｒｉｄの色が変わる
            {
                if (transform.position.x + i < 45 && transform.position.z < 45 && transform.position.x + i >= 0 && transform.position.z >= 0)
                {
                    GameManager.instance.Grid_Color(grid_color, (int)transform.position.x + i, (int)transform.position.z);
                }
            }
        }
    }
    private void line_attack_90(int attack_range, int attack_type, bool slanting_wall , bool attack_through, int attack_damage, Color grid_color)
    {
        for (int i = 1; i <= attack_range; i++)
        {
            if (vectorchange == false)
            {
                if (map_creat.map[(int)transform.position.x, (int)transform.position.z - i].number == 0)
                {
                    break;
                }
                if (map_creat.map_ex[(int)transform.position.x, (int)transform.position.z - i].number == 6)
                {
                    GameManager.instance.Adddamageenemy(map_creat.map_ex[(int)transform.position.x, (int)transform.position.z - i]);
                    //map_creat.map_ex[(int)transform.position.x, (int)transform.position.z - i].state.HP = map_creat.map_ex[(int)transform.position.x, (int)transform.position.z - i].enemy_script.
                    //enemydamage(map_creat.map_ex[(int)transform.position.x, (int)transform.position.z - i].state.HP, attack_damage, map_creat.map_ex[(int)transform.position.x, (int)transform.position.z - i].state.DEFENSE);

                    if (attack_through == false)
                    {
                        break;
                    }
                }
            }
            else if (vectorchange == true) //グリッド（Grid）、Cキー押しているときは一直線上のＧｒｉｄの色が変わる
            {
                if (transform.position.x < 45 && transform.position.z - i < 45 && transform.position.x >= 0 && transform.position.z - i >= 0)
                {
                    GameManager.instance.Grid_Color(grid_color, (int)transform.position.x, (int)transform.position.z - i);
                }
            }
        }
    }
    private void line_attack_180(int attack_range, int attack_type, bool slanting_wall , bool attack_through, int attack_damage, Color grid_color)
    {
        for (int i = 1; i <= attack_range; i++)
        {
            if (vectorchange == false)
            {
                if (map_creat.map[(int)transform.position.x - i, (int)transform.position.z].number == 0)
                {
                    break;
                }
                if (map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z].number == 6)
                {
                    GameManager.instance.Adddamageenemy(map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z]);
                    //map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z].state.HP = map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z].enemy_script.
                    //enemydamage(map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z].state.HP, attack_damage, map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z].state.DEFENSE);

                    if (attack_through == false)
                    {
                        break;
                    }
                }
            }
            else if (vectorchange == true) //グリッド（Grid）、Cキー押しているときは一直線上のＧｒｉｄの色が変わる
            {
                if (transform.position.x - i < 45 && transform.position.z < 45 && transform.position.x - i >= 0 && transform.position.z >= 0)
                {
                    GameManager.instance.Grid_Color(grid_color, (int)transform.position.x - i, (int)transform.position.z);
                }
            }
        }
    }
    private void line_attack_270(int attack_range, int attack_type, bool slanting_wall , bool attack_through, int attack_damage, Color grid_color)
    {
        for (int i = 1; i <= attack_range; i++)
        {
            if (vectorchange == false)
            {
                if (map_creat.map[(int)transform.position.x, (int)transform.position.z + i].number == 0)
                {
                    break;
                }
                if (map_creat.map_ex[(int)transform.position.x, (int)transform.position.z + i].number == 6)
                {
                    GameManager.instance.Adddamageenemy(map_creat.map_ex[(int)transform.position.x, (int)transform.position.z + i]);
                    //map_creat.map_ex[(int)transform.position.x, (int)transform.position.z + i].state.HP = map_creat.map_ex[(int)transform.position.x, (int)transform.position.z + i].enemy_script.
                    //enemydamage(map_creat.map_ex[(int)transform.position.x, (int)transform.position.z + i].state.HP, attack_damage, map_creat.map_ex[(int)transform.position.x, (int)transform.position.z + i].state.DEFENSE);

                    if (attack_through == false)
                    {
                        break;
                    }
                }
            }
            else if (vectorchange == true) //グリッド（Grid）、Cキー押しているときは一直線上のＧｒｉｄの色が変わる
            {
                if (transform.position.x < 45 && transform.position.z + i < 45 && transform.position.x >= 0 && transform.position.z + i >= 0)
                {
                    GameManager.instance.Grid_Color(grid_color, (int)transform.position.x, (int)transform.position.z + i);
                }
            }
        }
    }
    private void line_attack_45(int attack_range, int attack_type, bool slanting_wall , bool attack_through, int attack_damage , Color grid_color)
    {
        for (int i = 1; i <= attack_range; i++)
        {
            if (vectorchange == false)
            {
                if (map_creat.map[(int)transform.position.x + i, (int)transform.position.z - i].number == 0)
                {
                    break;
                }//横壁があるとき攻撃が通らない
                else if (slanting_wall == false && (map_creat.map[(int)transform.position.x + i - 1, (int)transform.position.z - i].number == 0 || map_creat.map[(int)transform.position.x + i, (int)transform.position.z - i + 1].number == 0))
                {
                    break;
                }
                if (map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z - i].number == 6)
                {
                    GameManager.instance.Adddamageenemy(map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z - i]);
                    //map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z - i].state.HP = map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z - i].enemy_script.
                    //enemydamage(map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z - i].state.HP, attack_damage, map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z - i].state.DEFENSE);

                    if (attack_through == false)
                    {
                        break;
                    }
                }
            }
            else if (vectorchange == true) //グリッド（Grid）、Cキー押しているときは一直線上のＧｒｉｄの色が変わる
            {
                if (transform.position.x + i < 45 && transform.position.z - i < 45 && transform.position.x + i >= 0 && transform.position.z - i >= 0)
                {
                    GameManager.instance.Grid_Color(grid_color, (int)transform.position.x + i, (int)transform.position.z - i);
                }
            }
        }
    }
    private void line_attack_135(int attack_range, int attack_type, bool slanting_wall ,bool attack_through, int attack_damage, Color grid_color)
    {
        for (int i = 1; i <= attack_range; i++)
        {
            if (vectorchange == false)
            {
                if (map_creat.map[(int)transform.position.x - i, (int)transform.position.z - i].number == 0)
                {
                    break;
                }//横壁があるとき攻撃が通らない
                else if (slanting_wall == false && (map_creat.map[(int)transform.position.x - i + 1, (int)transform.position.z - i].number == 0 || map_creat.map[(int)transform.position.x - i, (int)transform.position.z - i + 1].number == 0))
                {
                    break;
                }
                if (map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z - i].number == 6)
                {
                    GameManager.instance.Adddamageenemy(map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z - i]);
                    //map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z - i].state.HP = map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z - i].enemy_script.
                    //enemydamage(map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z - i].state.HP, attack_damage, map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z - i].state.DEFENSE);

                    if (attack_through == false)
                    {
                        break;
                    }
                }
            }
            else if (vectorchange == true) //グリッド（Grid）、Cキー押しているときは一直線上のＧｒｉｄの色が変わる
            {
                if (transform.position.x - i < 45 && transform.position.z - i < 45 && transform.position.x - i >= 0 && transform.position.z - i >= 0)
                {
                    GameManager.instance.Grid_Color(grid_color, (int)transform.position.x - i, (int)transform.position.z - i);
                }
            }
        }
    }
    private void line_attack_225(int attack_range, int attack_type, bool slanting_wall , bool attack_through, int attack_damage, Color grid_color)
    {
        for (int i = 1; i <= attack_range; i++)
        {
            if (vectorchange == false)
            {
                if (map_creat.map[(int)transform.position.x - i, (int)transform.position.z + i].number == 0)
                {
                    break;
                }//横壁があるとき攻撃が通らない
                else if (slanting_wall == false && (map_creat.map[(int)transform.position.x - i + 1, (int)transform.position.z + i].number == 0 || map_creat.map[(int)transform.position.x - i, (int)transform.position.z + i - 1].number == 0))
                {
                    break;
                }
                if (map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z + i].number == 6)
                {
                    GameManager.instance.Adddamageenemy(map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z + i]);
                    //map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z + i].state.HP = map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z + i].enemy_script.
                    //enemydamage(map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z + i].state.HP, attack_damage, map_creat.map_ex[(int)transform.position.x - i, (int)transform.position.z + i].state.DEFENSE);

                    if (attack_through == false)
                    {
                        break;
                    }
                }

            }
            else if (vectorchange == true) //グリッド（Grid）、Cキー押しているときは一直線上のＧｒｉｄの色が変わる
            {
                if (transform.position.x - i < 45 && transform.position.z + i < 45 && transform.position.x - i >= 0 && transform.position.z + i >= 0)
                {
                    GameManager.instance.Grid_Color(grid_color, (int)transform.position.x - i, (int)transform.position.z + i);
                }
            }
        }
    }
    private void line_attack_315(int attack_range, int attack_type, bool slanting_wall , bool attack_through, int attack_damage, Color grid_color)
    {
        for (int i = 1; i <= attack_range; i++)
        {
            if (vectorchange == false)
            {
                if (map_creat.map[(int)transform.position.x + i, (int)transform.position.z + i].number == 0)
                {
                    break;
                }//横壁があるとき攻撃が通らない
                else if (slanting_wall == false && (map_creat.map[(int)transform.position.x + i - 1, (int)transform.position.z + i].number == 0 || map_creat.map[(int)transform.position.x + i, (int)transform.position.z + i - 1].number == 0))
                {
                    break;
                }
                if (map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z + i].number == 6)
                {
                    GameManager.instance.Adddamageenemy(map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z + i]);
                    //map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z + i].state.HP = map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z + i].enemy_script.
                    //enemydamage(map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z + i].state.HP, attack_damage, map_creat.map_ex[(int)transform.position.x + i, (int)transform.position.z + i].state.DEFENSE);

                    if (attack_through == false)
                    {
                        break;
                    }
                }
            }
            else if (vectorchange == true) //グリッド（Grid）、Cキー押しているときは一直線上のＧｒｉｄの色が変わる
            {
                if (transform.position.x + i < 45 && transform.position.z + i < 45 && transform.position.x + i >= 0 && transform.position.z + i >= 0)
                {
                    GameManager.instance.Grid_Color(grid_color, (int)transform.position.x + i, (int)transform.position.z + i);
                }
            }
        }
    }

    public void Player_Attack_Coroutine(int attack_range, int attack_type, bool slanting_wall, bool attack_through, int attack, int attack_animation)
    {
        StartCoroutine(SmoothAttack(attack_range, attack_type, slanting_wall, attack_through, attack, Color.white, attack_animation /*通常攻撃*/));
    }

    private void Player_Experience_Get(int get_exp)
    {
        player.player_experience += get_exp;

        Player_Level_Up();
    }

    public void Player_Level_Up()
    {
        if(player.player_level * player.player_level * GameManager.instance.player_state_data.sheets[0].list[0].price_player_level_up_need_coefficient <= player.player_experience)
        {
            player.player_level++;

            Player_New_State_Update();
        }
        
    }

    private void Player_New_State_Update()
    {
        int HP_W = 0;
        int ATTACK_W = 0;
        int DEFENSE_W = 0;

        if (player.equipment_weapon != null)
        {
            HP_W = player.equipment_weapon.HP_W;
            ATTACK_W = player.equipment_weapon.ATTACK_W;
            DEFENSE_W = player.equipment_weapon.DEFENSE_W;
        }

        player.player_origin_hp = player.player_origin_hp + GameManager.instance.player_state_data.sheets[0].list[0].price_player_hp_up_coefficient;
        player.player_MAX_hp = player.player_origin_hp + HP_W;
        player.player_hp = player.player_MAX_hp;

        player.player_origin_mp = player.player_origin_mp + GameManager.instance.player_state_data.sheets[0].list[0].price_player_mp_up_coefficient;
        player.player_MAX_mp = player.player_origin_mp;
        player.player_mp = player.player_MAX_mp;

        player.player_origin_attack = player.player_origin_attack + GameManager.instance.player_state_data.sheets[0].list[0].price_player_attack_up_coefficient;
        player.player_attack = player.player_origin_attack + ATTACK_W;

        player.player_origin_defense = player.player_origin_defense + GameManager.instance.player_state_data.sheets[0].list[0].price_player_defense_up_coefficient;
        player.player_defense = player.player_origin_defense + DEFENSE_W;

        GameManager.instance.Hp_Bar();
        GameManager.instance.HP_Text();
        GameManager.instance.Mp_Bar();
        GameManager.instance.MP_Text();

        GameManager.instance.AddMainText("レベルアップ");
        GameManager.instance.AddMainText(GameManager.instance.player_state_data.sheets[0].list[0].price_name_string + "はレベルが" + player.player_level + "になった。");
    }
    

}

public class AnimationWait : CustomYieldInstruction
{
    Animator m_animator;
    int m_layerNo;
    int m_lastStateHash;

    public AnimationWait(Animator animator, int layerNo)
    {
        m_animator = animator;
        m_layerNo = layerNo;
        m_lastStateHash = m_animator.GetCurrentAnimatorStateInfo(m_layerNo).nameHash;
    }

    public override bool keepWaiting
    {
        get
        {
            var currentAnimatorState = m_animator.GetCurrentAnimatorStateInfo(m_layerNo);
            return currentAnimatorState.fullPathHash == m_lastStateHash &&
                (currentAnimatorState.normalizedTime < 1);
        }
    }
    
}

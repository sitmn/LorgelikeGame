using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_item_position : MonoBehaviour {

    //アイテムの場所微調整用

    //薬品系
    private Transform Item;


	// Use this for initialization
	void Start () {
        Item = this.GetComponent<Transform>();
        Item.position += new Vector3(0 , 0.3f , 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

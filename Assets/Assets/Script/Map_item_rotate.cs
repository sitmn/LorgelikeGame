using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_item_rotate : MonoBehaviour {
   
    //アイテムの場所等微調整用



    private Transform Juel;

	// Use this for initialization
	void Start () {
        Juel = this.GetComponent<Transform>();
        Juel.transform.Rotate(90, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

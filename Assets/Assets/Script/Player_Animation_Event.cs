using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation_Event : MonoBehaviour {

    private AudioSource walk;
    private AudioSource attack;
    private AudioSource damage;
    private AudioSource make_success;


	// Use this for initialization
	void Start () {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        walk = audioSources[0];
        attack = audioSources[1];
        damage = audioSources[2];
        make_success = audioSources[3];
    }
	
    public void Walk_Sound_Effect()
    {
        walk.PlayOneShot(walk.clip);
    }

	public void Attack_Sound_Effect()
    {
        attack.PlayOneShot(attack.clip);
    }

    public void Damage_Sound_Effect()
    {
        damage.PlayOneShot(damage.clip);
    }

    

    public void Make_Success_Sound_Effect()
    {
        make_success.PlayOneShot(make_success.clip);
    }

    public void Make_Miss_Sound_Effect()
    {

    }

}

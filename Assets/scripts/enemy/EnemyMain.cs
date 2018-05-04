using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonHaul.states;

public class EnemyMain : MonoBehaviour {
    //stats
    [Header("Main Stats")]
    public byte atk;
    public byte def;
    public float maxHP;
    public float curHP = 1;
    public float speed;

    //reward
    [Header("Rewards")]
    public int gold;
    public int Exp;

    //states
    [Header("States")]
    public AttackStates curState;

    //ability time
    float apTime;
    float curAPTime;

    //Attacking
    [Header("Attacks")]
    public GameObject[] attacks;
    int maxAttack;

    //constants
    GameObject projSpawn;

    //enemy type
    private void Awake()
    {
        maxAttack = attacks.Length;
        projSpawn = transform.Find("enemy_projSpawn").gameObject;
        curHP = maxHP;
        apTime = 30 / speed;
        curAPTime = apTime;
    }

    private void FixedUpdate()
    {
        //if death
        if (curHP <= 0)
        {
            Destroy(this.gameObject);
        }

        //Ability bar/timer
        if (curAPTime >= 0)
        { //timer step
            curAPTime -= 0.1f;
        } else
        { //perform ability
            Debug.Log(this.gameObject.name + " Attacked.");

            if (maxAttack != 0)
            {
                Instantiate(attacks[Random.Range(0, maxAttack)], projSpawn.transform);
            }

            curAPTime = apTime;
        }
    }
}

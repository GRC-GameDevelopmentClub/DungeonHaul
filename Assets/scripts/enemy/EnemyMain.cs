using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonHaul.states;

public class EnemyMain : MonoBehaviour {
    //stats
    [Header("Main Stats")]
    public byte atk;
    public byte def;
    public int maxHP;
    public int curHP = 1;
    public float speed;

    //reward
    [Header("Rewards")]
    public int gold;
    public int Exp;

    //states
    [Header("States")]
    public AttackStates activeState;
    float statesTimer;
    bool startState;
    public float statesTimerMax;

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
        statesTimer = statesTimerMax;
    }

    private void FixedUpdate()
    {
        //if death
        if (curHP <= 0)
        {
            PlayerMain.Exp += Exp;
            PlayerMain.gold += gold;
            Destroy(this.gameObject);
        }

        //Ability bar/timer
        if (curAPTime >= 0)
        { //timer step
            curAPTime -= 0.1f;
        } else
        { //perform ability
            //Debug.Log(this.gameObject.name + " Attacked.");

            if (maxAttack != 0)
            {
                Instantiate(attacks[Random.Range(0, maxAttack)], projSpawn.transform);
            }

            curAPTime = apTime;
        }

        if (activeState != AttackStates.none)
        {
            StateTimerStep();
        }
        //player states
        //..poison
        if (activeState == AttackStates.poison && startState)
        {
            States.PoisionDamage(gameObject, maxHP);
            startState = false;
            statesTimer = statesTimerMax;
        }
        if (curHP <= maxHP / 4)
        {
            activeState = AttackStates.none;
        }

    }
    void StateTimerStep()
    {
        if (statesTimer <= 0)
        {
            startState = true;
        }
        else
        {
            statesTimer -= 0.1f;
        }
    }
}

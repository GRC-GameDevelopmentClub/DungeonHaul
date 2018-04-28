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

    //enemy type
    private void Awake()
    {
        curHP = maxHP;
    }

    private void FixedUpdate()
    {
        if (curHP <= 0)
        {
            PlayerMain.Exp += Exp;
            PlayerMain.gold += gold;
            Destroy(this.gameObject);
        }
    }
}

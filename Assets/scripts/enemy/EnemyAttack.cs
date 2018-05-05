/*Copyright (c) Hunter Ahlquist
 *http://hunterahlquist.com/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonHaul.states;
using DungeonHaul.Stats;

public class EnemyAttack : MonoBehaviour {

    //attack properties
    public int baseDamage;
    public float projSpeed;
    public AttackStates attackState;
    public decimal inflictChance;

    GameObject Enemy;
    GameObject self;

    private void Start()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        Enemy = this.transform.root.gameObject;
        self = this.gameObject;
        this.transform.SetParent(null);
        //Debug.Log("EnemyAttack." + Enemy.name);
    }

    private void FixedUpdate()
    {
        self.transform.position += transform.up * projSpeed;
        //Debug.Log(transform.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("hit " + collision.tag);
        if (collision.gameObject.tag == "projKillZone")
        {
            //Debug.Log("killzone");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("enemy");
            Damage.InflictDamage(collision.gameObject, baseDamage * (Enemy.GetComponent<EnemyMain>().atk - collision.GetComponent<PlayerMain>().def), true, attackState);
            Destroy(this.gameObject);
        }
    }
 }


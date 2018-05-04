using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonHaul.states;
using DungeonHaul.Stats;

public class PlayerAttack : MonoBehaviour {
    //attack properties
    public int baseDamage;
    int totalDamage;
    public float projSpeed;
    public AttackStates attackState;
    public decimal inflictChance;

    GameObject Player;
    GameObject self;
    public GameObject emit;

    private void Start()
    {
        self = this.gameObject;
        Player = GameObject.Find("theWiz");
        totalDamage = baseDamage * Player.GetComponent<PlayerMain>().atk;
        emit = GameObject.Find("particles");
        emit.gameObject.name = "magic";
    }

    private void FixedUpdate()
    {
        self.transform.position += transform.up * projSpeed;
        Debug.Log(transform.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("hit " + collision.tag);
        if (collision.gameObject.tag == "projKillZone")
        {
            //Debug.Log("killzone");
            emit.transform.SetParent(null);
            DetachParticles();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("enemy");
            Damage.InflictDamage(collision.gameObject, baseDamage, false, attackState);
            emit.transform.SetParent(null);
            DetachParticles();
            Destroy(this.gameObject);
        }
    }
    public void DetachParticles()
    {
        // This splits the particle off so it doesn't get deleted with the parent
        

        // this stops the particle from creating more bits
        ParticleSystem.EmissionModule em = emit.GetComponent<ParticleSystem>().emission;
        em.enabled = false;

        if (emit.GetComponent<ParticleSystem>().particleCount == 0)
            Destroy(emit.gameObject); 

    }
}

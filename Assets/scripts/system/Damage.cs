using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonHaul.states;

namespace DungeonHaul.Stats
{
    public class Damage : MonoBehaviour
    {
        //Contact Damage
        public static void InflictDamage(
            GameObject target, 
            int baseDamage, 
            bool isPlayer,
            AttackStates inflict = AttackStates.none, 
            decimal inflictChance = 0)
        {
            if (isPlayer) //attack hitting the player
            {
                Mathf.Floor(target.GetComponent<PlayerMain>().curHP -= baseDamage - (target.GetComponent<PlayerMain>().def * 2));
                //Debug.Log("gave damage to " + target.name + " for " + (baseDamage / target.GetComponent<PlayerMain>().def) + ". hp of target is now " + target.GetComponent<PlayerMain>().curHP);
            } else //attack hitting an enemy
            {
                Mathf.Floor(target.GetComponent<EnemyMain>().curHP -= baseDamage - (target.GetComponent<EnemyMain>().def * 2));
                //Debug.Log("gave damage to " + target.name + " for " + (baseDamage / target.GetComponent<EnemyMain>().def) + ". hp of target is now " + target.GetComponent<EnemyMain>().curHP);
            }
        }

        public static void PoisonDamage()
        {

        }
    }
    
}

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
                //check if damage would be zero after defense calculation
                int totalDamage = baseDamage - (target.GetComponent<PlayerMain>().def * 2);
                if (totalDamage >= 0)
                {
                    Mathf.Floor(target.GetComponent<PlayerMain>().curHP -= totalDamage);
                } else
                {
                    target.GetComponent<PlayerMain>().curHP -= 1;
                }
                
                //Debug.Log("gave damage to " + target.name + " for " + (baseDamage / target.GetComponent<PlayerMain>().def) + ". hp of target is now " + target.GetComponent<PlayerMain>().curHP);
            } else //attack hitting an enemy
            {
                int totalDamage = baseDamage - (target.GetComponent<EnemyMain>().def * 2);
                if (totalDamage >= 0)
                {
                    Mathf.Floor(target.GetComponent<EnemyMain>().curHP -= baseDamage);
                } else
                {
                    target.GetComponent<EnemyMain>().curHP -= 1;
                }
                    
                //Debug.Log("gave damage to " + target.name + " for " + (baseDamage / target.GetComponent<EnemyMain>().def) + ". hp of target is now " + target.GetComponent<EnemyMain>().curHP);
            }
        }

        public static void PoisonDamage()
        {

        }
    }
    
}

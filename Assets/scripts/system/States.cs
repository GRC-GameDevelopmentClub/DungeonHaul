using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonHaul.Stats;

namespace DungeonHaul.states
{
    public enum AttackStates { none, poison, slog, iframed };

    public class States : MonoBehaviour
    {

        //state effects
        public static void PoisionDamage(GameObject target, int maxHP)
        {
            if (target.tag == "Player")
            {
                //Debug.Log("maxHP = " + maxHP / 10);
                //Debug.Log("maxHP / 10 = " + maxHP / 10);
                Damage.InflictDamage(target, maxHP / 10, true);
            } else if (target.tag == "Enemy")
            {
                //Debug.Log("maxHP = " + maxHP / 10);
                //Debug.Log("maxHP / 10 = " + maxHP / 10);
                Damage.InflictDamage(target, maxHP / 10, false);
            }

        }
        

    }
}


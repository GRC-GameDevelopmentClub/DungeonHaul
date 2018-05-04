/*Copyright (c) Hunter Ahlquist
 *http://hunterahlquist.com/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_SideToSide : MonoBehaviour {

    float speed;
    bool left;

    float debug_actionTime = 40;

    public GameObject attackSlot00;
    GameObject projSpawn;

    private void Start()
    {
        speed = GetComponent<EnemyMain>().speed;
        projSpawn = GameObject.Find("enemy_projSpawn");
    }

    private void FixedUpdate()
    {
        if (!left && transform.position.x < 4)
        {
            transform.position += new Vector3(0.02f, 0) * speed;
        } else if (!left)
        {
            left = true;
        }

        if (left && transform.position.x > -4)
        {
            transform.position += new Vector3(-0.02f, 0) * speed;
        }
        else if (left)
        {
            left = false;
        }

        if (debug_actionTime >= 0)
        {
            debug_actionTime -= 0.5f;
        } else if (debug_actionTime <= 0)
        {
            Instantiate(attackSlot00, projSpawn.transform.position, projSpawn.transform.rotation);
            debug_actionTime = 40;
        }
    }
}

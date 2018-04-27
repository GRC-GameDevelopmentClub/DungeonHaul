/*Copyright (c) Hunter Ahlquist
 *http://hunterahlquist.com/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_SideToSide : MonoBehaviour {

    float speed;
    bool left;

    private void Start()
    {
        speed = GetComponent<EnemyMain>().speed;
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
    }
}

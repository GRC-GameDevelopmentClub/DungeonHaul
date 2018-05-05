/*Copyright (c) Hunter Ahlquist
 *http://hunterahlquist.com/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DungeonHaul.states;

public class UIManager : MonoBehaviour {

    GameObject HPBar;
    GameObject HPBar_fill;
    GameObject Player;
    public Color hpfill_poisoned;
    public Color hpfill_normal;

    public bool isPlayer;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        HPBar = transform.Find("HPBar").gameObject;
        HPBar_fill = HPBar.transform.Find("Fill Area").transform.Find("Fill").gameObject;
    }

    private void Update()
    {
        if (isPlayer)
        {
            if (Player.GetComponent<PlayerMain>().activeState == AttackStates.poison)
            {
                HPBar_fill.GetComponent<Image>().color = hpfill_poisoned;
            }
            else
            {
                HPBar_fill.GetComponent<Image>().color = hpfill_normal;
            }
        }
        if (!isPlayer)
        {
            if (transform.parent.GetComponent<EnemyMain>().activeState == AttackStates.poison)
            {
                HPBar_fill.GetComponent<Image>().color = hpfill_poisoned;
            }
            else
            {
                HPBar_fill.GetComponent<Image>().color = hpfill_normal;
            }
        }

    }

}

/*Copyright (c) Hunter Ahlquist
 *http://hunterahlquist.com/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour {

    GameObject HPBar;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        HPBar = transform.Find("HPBar").gameObject;
    }

    private void Update()
    {
        HPBar.GetComponent<Slider>().value = Player.GetComponent<PlayerMain>().curHP;
    }

}

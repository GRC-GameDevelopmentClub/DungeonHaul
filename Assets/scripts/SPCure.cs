using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonHaul.states;

public class SPCure : MonoBehaviour {

    GameObject Player;
    PlayerMain plMain;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        plMain = Player.GetComponent<PlayerMain>();

        //cure
        plMain.activeState = AttackStates.none;
        Destroy(this.gameObject);
    }


}

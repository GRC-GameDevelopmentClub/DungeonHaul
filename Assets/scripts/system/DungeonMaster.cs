/*Copyright (c) Hunter Ahlquist
 *http://hunterahlquist.com/
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour {

    GameObject[] curEnemies;

    public bool lose;
    public bool win;

	// Use this for initialization
	void Start () {
        curEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
	
	// Update is called once per frame
	void Update () {
        curEnemies = GameObject.FindGameObjectsWithTag("Enemy");
	}

    private void FixedUpdate() {
        Debug.Log(curEnemies.Length);
    }
}

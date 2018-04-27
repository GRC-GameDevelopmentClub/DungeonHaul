using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
        this.gameObject.transform.position = GameObject.Find("theWiz").transform.position + new Vector3(0,0.5f,0);
	}
}

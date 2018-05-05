using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotDetect : MonoBehaviour {
    // Update is called once per frame
    private void Start()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        //this.transform.SetParent(null);
    }
    void Update () {
		if (transform.childCount <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}

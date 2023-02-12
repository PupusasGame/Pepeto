using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {

    float time;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time > 5f)
        {
            Destroy(gameObject);
        }
	}
}

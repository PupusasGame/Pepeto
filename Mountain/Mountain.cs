using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour {

    Vector3 myPosition;
    float smoothSpeed = 10;
    Pepeto pepeto;

	// Use this for initialization
	void Start () {
        pepeto = GameObject.FindObjectOfType<Pepeto>();
        myPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate () {

        Vector3 mountainNewPosition = new Vector3(pepeto.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(myPosition, mountainNewPosition + Camera.main.transform.position, smoothSpeed * Time.deltaTime);

    }
}

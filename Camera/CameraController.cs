using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Pepeto pepeto;
    float speedSmooth = 10f;
    public Vector3 offsetCamera;

    // Use this for initialization
    void Start () {
        pepeto = GameObject.FindObjectOfType<Pepeto>();
        
	}
	
	// Update is called once per frame
	void LateUpdate () {

        Vector3 posicionFinal = pepeto.transform.position + offsetCamera;
        Vector3 SmoothPosition = Vector3.Lerp(transform.position, posicionFinal, speedSmooth * Time.deltaTime);
        transform.position = SmoothPosition;
    }
}

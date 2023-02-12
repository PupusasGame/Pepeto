using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour {

    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        GameManager.instance.hasKey = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioSource.Play();
            Destroy(gameObject, .15f);
            GameManager.instance.hasKey = true;
        }
    }
}

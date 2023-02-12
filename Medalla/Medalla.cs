using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medalla : MonoBehaviour {

    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        GameManager.instance.hasMedal = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.Play();
            Destroy(gameObject, .15f);

            //Google Game Services
            Puntaje.instance.DesbloquearLogro(GPGSIds.achievement_medalla_pepeto_al_rescate);
            GameManager.instance.hasMedal = true;
        }
    }
}

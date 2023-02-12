using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hueso : MonoBehaviour {

    GameManager gameManager;
    AudioSource audioSource;
    GameObject destello;
    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        destello = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (destello != null)
            {
                destello.SetActive(true);
            }
            audioSource.Play();
            Destroy(gameObject, .25f);
            gameManager.huesos += 1;
        }
    }
}

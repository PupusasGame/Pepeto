using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jaula : MonoBehaviour {

    public Casa casa;
    public Transform rescate;
    public Transform aviso;
    public GameObject contenedorEstrellas;
    GameManager gameManager;
    SpriteRenderer spriteRenderer;
    public Sprite puertaAbierta;


    // Use this for initialization
    void Start () {
        casa = GameObject.FindObjectOfType<Casa>();
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        rescate = transform.GetChild(0);
        aviso = transform.GetChild(1);
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(contenedorEstrellas.transform.childCount <= 0 && !gameManager.tiempoFuera)
        {
            LiberarRescate();
        }
	}

    public void LiberarRescate()
    {
        spriteRenderer.sprite = puertaAbierta;
        if (rescate != null)
        {
            rescate.gameObject.SetActive(true);
        }
        aviso.gameObject.SetActive(false);
        casa.ActivarAvisoCasa();
        GameManager.instance.chipyDelivered = true;
    }
}

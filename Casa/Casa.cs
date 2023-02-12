using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour {

    Transform aviso;

	// Use this for initialization
	void Start () {
        aviso = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivarAvisoCasa()
    {
        aviso.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && GameManager.instance.chipyDelivered)
        {
            GameManager.instance.hasChipy = true;
            Puntaje.instance.DesbloquearLogro(GPGSIds.achievement_chipy_est_a_salvo);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nubes : MonoBehaviour {

    Vector3 limiteIzq;// es el límite izquierdo de la pantalla
    Vector3 limiteDer;// es el límite derecho de la pantalla
    public Camera maincamera; //está es la camara principal del juego
    Rigidbody2D rb2d; // Este es el RigidBody de la nube
    public float speed; // La velocidad con que la nube se desplaza

    // Use this for initialization
    void Start()
    {
 
        rb2d = GetComponent<Rigidbody2D>(); //busca y guarda el componente RigidBody

    }

    void Update()
    {
        MedirPantalla();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

        //La velocidad del Rigidbody de la nube aumenta hacia la izquierda en segundos
        rb2d.velocity = Vector3.left * speed * Time.deltaTime;
        //Si la posición pasa el límite izquierdo 3 unidades a la izquierda (sale de la pantalla)
        if (transform.position.x <= limiteIzq.x - 3f)
        {
            //La nueva posición será 3 unidades adelante del límite derecho (fuera de la pantalla)
            transform.position = new Vector3((limiteDer.x + 3f), transform.position.y, transform.position.z);

        }
    }

    void MedirPantalla()
    {
        //Establece el límite Izquiero 0,0 de la cámara
        limiteIzq = maincamera.ViewportToWorldPoint(new Vector3(0, 0, maincamera.transform.position.z));
        //Establece el límite Derecho 0,1 de la cámara
        limiteDer = maincamera.ViewportToWorldPoint(new Vector3(1, 0, maincamera.transform.position.z));
    }
}

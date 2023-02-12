using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour {
    public float speed;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector2.down * -speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "positionB")
        {
            speed = -speed;
        }

        if (collision.gameObject.tag == "positionA")
        {
            speed = -speed;
        }
    }
}

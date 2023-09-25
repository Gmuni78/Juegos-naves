using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //Variable privada de forma serializada para que se pueda ver y modificar en Unity.
    [SerializeField]
    private float speed;
    private GameManager gameManager;
    
    void Start()
    {
        speed = 10.0f;
    }

    // Crear el movimiento del laser.
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
        //Pregunto si ha superado el límite de pantalla.
        if (transform.position.y > 3.82f)
        {
            //Destruyo el laser cuando se sale de la pantalla.
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Collaider: " + collision.name);
        //nuestro profesor nos puso.
        //if ((collision.Tag == "Meteorito"))
        if (collision.tag=="Meteorito")
        {
            Destroy(gameObject);
        }
    }
}

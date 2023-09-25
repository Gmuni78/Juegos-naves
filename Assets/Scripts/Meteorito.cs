using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorito : MonoBehaviour
{
    [SerializeField]
    private float _velocidadMete;
    void Start()
    {
        _velocidadMete = 2.0f;
    }

    
    void Update()
    {
        transform.Translate(_velocidadMete * Time.deltaTime * Vector3.down);
        //Pregunto si ha superado el límite de pantalla.
        if (transform.position.y < -5.0f)
        {
            //Destruyo el laser cuando se sale de la pantalla.
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* lo mio
        Debug.Log("Collaider: " + collision.name);
        //como nos lo escribe el profesor
        // if ((collision.tag == "Laser"))
        //la sugerencia de visual
        if ((collision.CompareTag("Laser")))
        {
            Destroy(gameObject);
        }*/
        //Debug.Log("Collaider: " + collision.name); con los daños
        //Si colisiona con el laser se destruye.
        if (collision.tag == "Laser")
        {
            //Destruimos el asteroide
            Destroy(this.gameObject);
        }
        //Si chocamos con el jugador
        else if (collision.tag == "Nave")
        {
            //Acceder a la clase del jugador para acceder a los métodos.
            Jugador jugador = collision.GetComponent<Jugador>();
            //Comprobamos si se ha cargado todos los métodos de jugador.
            if (jugador != null)
            {
                //Llamar al método que le quita una vida.
                jugador.Damage();
            }
            //Destruimos el asteroide.
            Destroy(this.gameObject);
            


        }
    }
}

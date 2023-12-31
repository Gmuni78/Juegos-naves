using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorito : MonoBehaviour
{
    [SerializeField]
    private float _velocidadMete;
    //Variable para cargar el UIManager.
    private UIManager _uiManager;
    [SerializeField]
    private GameObject _explosionMete;
    void Start()
    {
        _velocidadMete = 2.0f;
        //Cargamos los componentes del UIManager
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    
    void Update()
    {
        transform.Translate(_velocidadMete * Time.deltaTime * Vector3.down);
        //Pregunto si ha superado el l�mite de pantalla.
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
        //Debug.Log("Collaider: " + collision.name); con los da�os.
        //Si colisiona con el laser se destruye.
        if (collision.tag == "Laser")
        {
            Instantiate(_explosionMete, transform.position, Quaternion.identity);
            //Destruimos el asteroide
            Destroy(this.gameObject);
            if (_uiManager != null)
            {
                //llamo al m�todo de actualizar los puntos.
                _uiManager.UpdatePuntos();
            }
        }
        //Si chocamos con el jugador
        else if (collision.tag == "Nave")
        {
            //Acceder a la clase del jugador para acceder a los m�todos.
            Jugador jugador = collision.GetComponent<Jugador>();
            //Comprobamos si se ha cargado todos los m�todos de jugador.
            if (jugador != null)
            {
                //Llamar al m�todo que le quita una vida.
                jugador.Damage();
            }

            //Destruimos el asteroide.
            Destroy(this.gameObject);
            


        }
    }
}

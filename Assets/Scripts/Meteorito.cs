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
        Debug.Log("Collaider: " + collision.name);
        //como nos lo escribe el profesor
        // if ((collision.tag == "Laser"))
        //la sugerencia de visual
        if ((collision.CompareTag("Laser")))
        {
            Destroy(gameObject);
        }
    }
}

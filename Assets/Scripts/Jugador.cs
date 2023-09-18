using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float horizontalInput;
    public float velocidad;
    public float verticalInput;
    //Crear variable para coger el laser Prefab en Unity.
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _meteoritoPrefab;
    //Variable que marque el tiempo entre disparos
    [SerializeField]
    private float _espacioEntreDisparos;
    //segunda variable que diga que ya podemos disparar
    [SerializeField]
    private float _puedesDisparar;

    //generacion de meteoritos no oficial.
    //[SerializeField]
    //private float _generarMeteorito;
    //[SerializeField]
    //private float _tiempoEntreMeteoritos;

    // Start is called before the first frame update
    void Start()
    {
        //colocamos la nave de ataque en el centro.
        //La cargamos en el start.
        this.transform.position = new Vector3(0, -2.45f, 0);
        velocidad = 5f;
        //inicializar las variables de control de disparo
        _espacioEntreDisparos= 0.25f;
        _puedesDisparar = 0.0f;
       /* _generarMeteorito = 0.0f;
        _tiempoEntreMeteoritos = 5.0f;*/

      // for (int i = 0; i < 5; i++)
      // {
           

     //  }

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        
        // Preguntamos si podemos preguntar.
        if (Time.time > _puedesDisparar)
        {
            Disparo();
        }
       /* if (Time.time>_generarMeteorito)
        {
            GenerarMeterorito();
        }*/
      
    }

    /*private void GenerarMeterorito()
    {
        Instantiate(_meteoritoPrefab, transform.position + new Vector3(0, 5.25f, 0), Quaternion.identity);
        _generarMeteorito = Time.time + _tiempoEntreMeteoritos;
    }*/

    public void Movimiento()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        this.transform.Translate(horizontalInput * Time.deltaTime * velocidad * Vector3.right);
        this.transform.Translate(Time.deltaTime * velocidad * verticalInput * Vector3.up);

        if (transform.position.y > 1.60f)
        {
            transform.position = new Vector3(transform.position.x, 1.60f, 0);
        }
        else if (transform.position.y < -2.45f)
        {
            transform.position = new Vector3(transform.position.x, -2.45f, 0);
        }
        if (transform.position.x > 5.50f)
        {
            transform.position = new Vector3(5.50f, transform.position.y, 0);
        }
        else if (transform.position.x < -5.50f)
        {
            transform.position = new Vector3(-5.50f, transform.position.y, 0);
        }
    }
    public void Disparo()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.15f, 0), Quaternion.identity);
            _puedesDisparar = Time.time + _espacioEntreDisparos;
        }
       
    }
}

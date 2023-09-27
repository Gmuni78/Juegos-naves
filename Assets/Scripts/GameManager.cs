using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float tiempo;
    // Variable que contenga el asteroide.
    [SerializeField]
    private GameObject _asteroide;
    //Variable de tipo Array que contenga los powerUps.
    [SerializeField]
    private GameObject[] _powerUps;

    [SerializeField]
    private GameObject _jugadorPrefab;
    //Variable se han acabado las vidas.
    public bool game;

    //Variable de acceso a UIManager
    private UIManager _uIManager;

    void Start()
    {
        //inicio de la corrutina
        StartCoroutine(Asteroides());
        StartCoroutine(PowerUp());
        tiempo = 2f;
        //Variable de si jugamos o no.
        game = true;

        //Cargo el componente UIManager de la clase UIManager.
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void Update()
    {
        //Preguntamos si estamos jugando.
        if (game == true)
        {
            //Si presione la tecla Espacio creo una nueva nave.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Creamos el jugador
                Instantiate(_jugadorPrefab, Vector3.zero, Quaternion.identity);
                //La vida se está utilizando y no cree una nueva vida
                game = false;

                //Llamamos a la función que nos oculta el panel de inicio de jugador.
                _uIManager.OcultarTitulo();
            }

        }
    }

    //Para controlar el tiempo con la corrutina
    IEnumerator Asteroides()
    {
        //Creo un bucle que va a ir creando los asteroides.
        while (true)
        {
            //creo el asteroide.
            Instantiate(_asteroide, new Vector3(Random.Range(-5.50f,5.50f), 6.6f, 0), Quaternion.identity);
            //darle el tiempo entre un asteroide y otro
            yield return new WaitForSeconds(2.0f);
        }
    }
    IEnumerator PowerUp()
    {
        //Creo un bucle que va a ir creando los asteroides.
        while (true)
        {
            //Creo el asteroide.
            Instantiate(_powerUps[Random.Range(0, 3)], new Vector3(Random.Range(-6.3f, 6.3f), 5.8f, 0), Quaternion.identity);
            //Darle el tiempo entre uno y otro asteroide.
            yield return new WaitForSeconds(5f);
        }
    }
}

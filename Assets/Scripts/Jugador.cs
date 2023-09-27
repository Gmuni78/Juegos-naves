using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float horizontalInput;
    public float velocidad;
    public float verticalInput;
    public int vidas;
    //Crear variable para coger el laser Prefab en Unity.
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _meteoritoPrefab;
    //Variable que marque el tiempo entre disparos
    [SerializeField]
    private float _EspacioEntreDisparos;
    //segunda variable que diga que ya podemos disparar
    [SerializeField]
    private float _PuedesDisparar;

    //generacion de meteoritos no oficial.
    //[SerializeField]
    //private float _generarMeteorito;
    //[SerializeField]
    //private float _tiempoEntreMeteoritos;
    //variable triple disparo
    [SerializeField]
    private bool _TripleDisparo;
    //variable de gameObjetct de prefab triple disparo.
    [SerializeField]
    private GameObject _TripleDisparoPrefab;

    //variable de más velocidad.
    [SerializeField]
    private bool _MasVelocidad;
    //Variable para la prefab de  la explosion.
    [SerializeField]
    private GameObject _naveExplosion;

    //variable de escudo.
    [SerializeField]
    private bool _escudo;
    //Variable de Gameobject de prefab de escudo hijo.
    [SerializeField]
    private GameObject _escudoHijo;

    //variable de gameObject para coger métodos.
    private GameManager _gameManager;

    // Creo una variable de UIManager para acceder a ella.
    private UIManager _uiManager;

    //Creo una variable de tipo sonido para contener el laser.
    private AudioSource _audiosource;

    private void Start()
    {
        this.transform.position = new Vector3(0, -2.45f, 0);
        velocidad = 5f;
        _EspacioEntreDisparos = 0.25f;
        _PuedesDisparar = 0.0f;
        //iniciamos varibles de powerup.
        _TripleDisparo = false;
        _MasVelocidad = false;
        _escudo = false;
        //pongo el numero de vidas.
        vidas = 3;
        //cargo la clase de GameManager
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Cargo UIManager y pregunto si está.
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        //Preguntamos si se ha cargado los componentes.
        if (_uiManager != null)
        {
            //Llamamos al método de UIManager para mandarle las vidas.
            _uiManager.UpdateVidas(vidas);
        }

        //cojo el componente de sonido adiosouerce.
        _audiosource = GetComponent<AudioSource>();
     }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        
        // Preguntamos si podemos preguntar.
        if (Time.time > _PuedesDisparar)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                //Llamar a Disparo.
                Disparo();
            }
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

        if (_MasVelocidad == true)
        {
            //Multiplicamos por la supervelocidad.
            this.transform.Translate(Vector3.right * velocidad * 3f * horizontalInput * Time.deltaTime);
            this.transform.Translate(Vector3.up * velocidad * 3f * verticalInput * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(horizontalInput * Time.deltaTime * velocidad * Vector3.right);
            this.transform.Translate(Time.deltaTime * velocidad * verticalInput * Vector3.up);
        }
       

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
    /*hecho antes de las vacaciones.
    public void Disparo()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.15f, 0), Quaternion.identity);
            _puedesDisparar = Time.time + _espacioEntreDisparos;
        }
       
    }*/
    public void Disparo()
    {
        //Preguntamos si podemos disparar.
        if (Time.time > _PuedesDisparar)
        {
            //reproducir audio del disparo.

            _audiosource.Play();
            //Si no es triple disparo.
            if (_TripleDisparo == false)
            {
                //Crear el objeto(cojo el objeto,cojo la posición de la nave y le sumo un vector para que
                //se coloque y le pongo rotación a 0.
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.65f, 0), Quaternion.identity);
            }
            else
            {
                //Creamos el disparo triple.
                Instantiate(_TripleDisparoPrefab, transform.position + new Vector3(0, 0.65f, 0), Quaternion.identity);
            }
            //Establecemos el nuevo valor del tiempo de disparo.
            _PuedesDisparar = Time.time + _EspacioEntreDisparos;
        }
    }
    //Creamos el método que activa el triple disparo.
    public void TripleDisparoPowerupOn()
    {
        //Hacemos que el powerup triple disparo se active.
        _TripleDisparo = true;
     //   StartCoroutine(TripleshotPowerRoutine());
        // Tiempo de espera del triple disparo.
  /*   public IEnumerator TripleshotPowerRoutine()
        {
            //Establece el nuevo tempo de espera.
            yield return new WaitForSeconds(5.0f);
            //Desactivamos el powerup.
            _tripleDisparo = false;
        }*/
    }
    public void SuperVelocidadPowerupOn()
    {
        //Hacemos que el powerup super velocidad se active.
        _MasVelocidad = true;
        // Llamamos a la coroutine y la inicializamos.
     //   StartCoroutine(SuperVelocidadPowerRoutine());
    }
    // Tiempo de espera del triple disparo.
    /*public IEnumerator SuperVelocidadPowerRoutine()
    {
        //Establece el nuevo tempo de espera.
        yield return new WaitForSeconds(5.0f);
        //Desactivamos el powerup.
        _MasVelocidad = false;
    }*/
    public void EscudoPowerupOn()
    {
        //Hacemos que el powerup escudo se active.
        _escudo = true;
        //Activamos que sea visible el escudo.
        _escudoHijo.SetActive(true);
        // Llamamos a la coroutine y la inicializamos.
      //  StartCoroutine(EscudoPowerRoutine());
    }
    // Tiempo de espera del triple disparo.
    /*public IEnumerator EscudoPowerRoutine()
    {
        //Establece el nuevo tempo de espera.
        yield return new WaitForSeconds(5.0f);
        //Desactivamos el powerup.
        _escudo = false;
        //Desactivamos que sea visible el escudo.
        _escudoHijo.SetActive(false);
    }*/
    //Método para quitar las vidas.
    public void Damage()
    {
        //Preguntamos si el escudo está activado.
        if (_escudo == true)
        {
            //Desactivamos el escudo.
            _escudo = false;
            //Dejamos de ver el escudo.
            _escudoHijo.SetActive(false);
            //Termino el método.
            return;
        }
        //Quitamos una vida.
        vidas--;
        //Llamo al método de UpdateVidas y le mando las vidas que quedan.
        _uiManager.UpdateVidas(vidas);

        //Preguntamos si quedan vidas.
        if (vidas < 1)
        {
            //Vuelvo a estar en juego para crear una nueva vida.
            _gameManager.game = true;

            //Mostrar el título.
            _uiManager.MostrarTitulo();

            //Creamos la explosión.
            Instantiate(_naveExplosion, transform.position, Quaternion.identity);
            //Destruimos la nave.
            Destroy(this.gameObject);
        }
    }
}

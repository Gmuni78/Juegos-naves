using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variable que contenga el asteroide.
    [SerializeField]
    private GameObject _asteroide;
    void Start()
    {
        //inicio de la corrutina
        StartCoroutine(Asteroides());
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
   
}

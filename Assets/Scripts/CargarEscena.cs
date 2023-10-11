using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour
{
   public void CargarScena(string NombreEscena)
    {
        SceneManager.LoadScene(NombreEscena);
    }
    //Cierra apliaci�n compilada.
    public void CerrarAplicacion()
    {
        Application.Quit();
    }
   
}

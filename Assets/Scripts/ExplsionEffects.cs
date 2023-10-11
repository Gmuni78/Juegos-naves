using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplsionEffects : MonoBehaviour
{
    // destruyo el objeto en el que estoy y le doy un tiempode autodestrucción.
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

}

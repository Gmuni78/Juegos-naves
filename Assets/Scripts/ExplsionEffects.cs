using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplsionEffects : MonoBehaviour
{
    // destruyo el objeto en el que estoy y le doy un tiempode autodestrucci�n.
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

}

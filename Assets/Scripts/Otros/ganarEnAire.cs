using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ganarEnAire : MonoBehaviour
{
    public CollidersPAire p;
    public GameObject puerta;



    // Update is called once per frame
    void Update()
    {
        if(p.i == 5)
        {
            puerta.SetActive(false);
        }
        
    }
}

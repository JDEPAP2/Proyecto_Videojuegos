using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanarP : MonoBehaviour
{
    // Start is called before the first frame update
    public CollidersP p;
    public GameObject puerta;


    // Update is called once per frame
    void Update()
    {
        if (p.i == 5)
        {
            puerta.SetActive(false);
        }

    }
}

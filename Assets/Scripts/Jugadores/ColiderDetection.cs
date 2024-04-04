using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderDetection : MonoBehaviour
{
    int i;
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        i++;
        Debug.Log("Entro, Objetos que pasaron: " + i);
        string res = "";
        if (other.tag == "Detection")
        {
            res = other.name;
        }
        Debug.Log(res);
    }

    public void OnTriggerExit(Collider other)
    {

        if (i != 0)
            i--;
        Debug.Log("Salio, Objetos adentro: " + i);
    }
}

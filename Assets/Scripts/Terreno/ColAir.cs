using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColAir : MonoBehaviour
{
    public changeCm scriptCam;
    public bool estado;
    public GameObject obj;
    public Material original, temp;

    void Start()
    {
        estado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptCam.estado && Input.GetKey(KeyCode.C))
        {
            putTexture.cambiarTex(obj, temp);
            estado = false;

        }
        else
        {
            if(!estado)
            putTexture.cambiarTex(obj, original);
            estado = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCm : MonoBehaviour
{
    public GameObject main, cam;
    public bool estado;
    void Start()
    {
        estado = true;
    }
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.C))
        {
            if (!estado)
            {
                cam.SetActive(false);
                main.SetActive(true);
                return;
            }
            cam.SetActive(true);
            main.SetActive(false);
        }
        else
        {
            cam.SetActive(false);
            main.SetActive(true);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaManagerCanvas : MonoBehaviour
{
    public GameObject vistas;
    public int vida;


    // Update is called once per frame
    void Update()
    {
        if (vida != 0)
        {
            if (vida == 2)
            {
                vistas.transform.Find($"C{2}F").gameObject.SetActive(true);
                vistas.transform.Find($"C{2}T").gameObject.SetActive(false);
                vistas.transform.Find($"C{2}T").gameObject.SetActive(false);
                vistas.transform.Find($"C{1}F").gameObject.SetActive(true);
                vistas.transform.Find($"C{1}T").gameObject.SetActive(false);
                vistas.transform.Find($"C{1}T").gameObject.SetActive(false);
            }
            else
            {
                vistas.transform.Find($"C{1}F").gameObject.SetActive(true);
                vistas.transform.Find($"C{1}T").gameObject.SetActive(false);
                vistas.transform.Find($"C{1}T").gameObject.SetActive(false);
            }
            
        }
        if(vida == 3)
        {

            for (int i = 1; i < 4; i++)
            {
                vistas.transform.Find($"C{i}T").gameObject.SetActive(true);
                vistas.transform.Find($"C{i}F").gameObject.SetActive(false);
            }
            vida = 0;

        }
    }
}

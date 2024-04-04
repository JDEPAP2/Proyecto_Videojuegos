using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaManager : MonoBehaviour
{
    public GameObject vistas;
    public int vida;
    public Reiniciar r;

    void Start()
    {
        vida = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida != 0)
        {
            vistas.transform.Find($"C{vida}F").gameObject.SetActive(true);
            vistas.transform.Find($"C{vida}T").gameObject.SetActive(false);
        }
        if(vida == 3)
        {

            r.parcial = true;

            for (int i = 1; i < 4; i++)
            {
                vistas.transform.Find($"C{i}T").gameObject.SetActive(true);
                vistas.transform.Find($"C{i}F").gameObject.SetActive(false);
            }
            vida = 0;

        }
    }
}

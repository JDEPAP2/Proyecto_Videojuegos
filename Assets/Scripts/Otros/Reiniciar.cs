using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reiniciar : MonoBehaviour
{
    public bool total, parcial, checkP;
    public Transform respawn, respawn2;

    void Update()
    {
        if (total)
        {
            transform.position = respawn.position;
            checkP = false;

            total = false;
        }

        if (parcial)
        {
            if (checkP)
            {
                transform.position = respawn2.position;
            }
            else
            {
                transform.position = respawn.position;
            }

            parcial = false;
        }
    }
}

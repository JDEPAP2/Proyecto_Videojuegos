using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaSaltos : MonoBehaviour
{
    public Lgica logicaPersonaje;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        logicaPersonaje.canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        logicaPersonaje.canJump = false;
    }
}

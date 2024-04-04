using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigo : MonoBehaviour
{
    public int danio;
    public GameObject Personaje;

    private void OnTriggerEnter(Collider other){
        if(other.tag=="Player")
        {
            Personaje.GetComponent<DatosJugador>().vidaJugador -=danio;
            Debug.Log("Jugador dañado por el enemigo");
        }
        if(other.tag=="Enemigo")
        {
            
            Debug.Log("Soy el enemigo");
        }
    }
}

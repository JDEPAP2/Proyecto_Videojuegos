using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneJ : MonoBehaviour
{
    // Start is called before the first frame update
    public string Nombreescena;
    public Temporizador tiempoE;
    public DatosJugador datos;
    public int escena;
    public vidaManager i;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (escena == 1)
            {
                datos.tiempo1 = tiempoE.i;
                datos.vida1 = i.vida;
                datos.scores1 = puntajeVida(i.vida) + puntajeTiempo(tiempoE.i);
            }
            if (escena == 2)
            {
                datos.tiempo2 = tiempoE.i;
                datos.vida2 = i.vida;
                datos.scores2 = puntajeVida(i.vida) + puntajeTiempo(tiempoE.i);
            }
            if (escena == 3)
            {
                datos.tiempo3 = tiempoE.i;
                datos.vida3 = i.vida;
                datos.scores3 = puntajeVida(i.vida) + puntajeTiempo(tiempoE.i);
            }
            if (escena == 4)
            {
                datos.tiempo4 = tiempoE.i;
                datos.vida4 = i.vida;
                datos.scores4 = puntajeVida(i.vida) + puntajeTiempo(tiempoE.i);
            }
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(Nombreescena);
        }
    }

    public int puntajeVida(int vida)
    {
        if (vida == 0)
            return 300;
        else
        {
            if (vida == 1)
                return 200;
            else
                return 100;
        }
    }


    public int puntajeTiempo(int tiempo)
    {
        if(tiempo < 301)
        {
            if(tiempo < 100)
                return 102000;
            if(tiempo < 200)
                return 101000;
            return 100000;
        }

        else
        {
            int valor = 100000 - tiempo;
            if (valor < 0)
                return 0;
            return valor;
        }
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pausa : MonoBehaviour
{
    public string nombreEscena;
    public GameObject canva;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            canva.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(nombreEscena);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Continuar()
    {
        canva.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }
}

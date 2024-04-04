using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollidersP : MonoBehaviour
{
    // Start is called before the first frame update
    public int i = 0;
    public Text pocion;
    public bool checkP = false;
    public Reiniciar r;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pocion"))
        {
            other.gameObject.SetActive(false);
            i += 1;
            pocion.text = "" + i;
        }
        if (other.CompareTag("Abismo"))
        {
            r.parcial = true;
        }
        if (other.CompareTag("CheckP"))
        {
            r.checkP = true;
        }

    }


}

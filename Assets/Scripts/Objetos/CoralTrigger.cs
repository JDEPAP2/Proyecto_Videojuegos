using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralTrigger : MonoBehaviour
{
    public Rigidbody rb;
    public float velocidadRio = 0.01f;
    public int i;
    private bool estado;
   
    // Start is called before the first frame update
    private void OnCollisionStay(Collision other)
{
        //NorteSurPositivo
        if (other.gameObject.tag == "Abismo" && i == 0 && estado)
        {
            rb.transform.Translate(new Vector3(velocidadRio,0,0));
        }
        //Rio_OccidOrientePositivo
        if (other.gameObject.tag == "Abismo" && i == 1 && estado)
        {
            rb.transform.Translate(new Vector3(0,0,velocidadRio));
        }
        //Rio_NorteSurNegativo
        if (other.gameObject.tag == "Abismo" && i == 2 && estado)
        {
            rb.transform.Translate(new Vector3(-velocidadRio,0,0));
        }
        //Rio_OccidOrienteNegativo
        if (other.gameObject.tag == "Abismo" && i == 3 && estado)
        {
            rb.transform.Translate(new Vector3(0,0,-velocidadRio));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plataforma_Coral") || other.CompareTag("Player"))
        {
            estado = true;
        }
        else
        {
            estado = false;
        }
    }

}

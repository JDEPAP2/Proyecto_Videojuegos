using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsTrigger : MonoBehaviour
{
    public Material original, trig;
    private void OnTriggerStay(Collider other)
    {
        Renderer a = transform.GetComponent<Renderer>();

        if (other.CompareTag("Columns"))
        {
            if (a != null)
                a.material = trig;

        }
        else
        {
            if (a != null)
                a.material = original;
        }
    }
}

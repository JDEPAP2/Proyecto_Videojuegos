using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class FragmentBehaviour : MonoBehaviour
{
    bool first = true, destroyed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&first)
        {
            GameObject.Find("Dimension").GetComponent<DimensionController>().next = true;
            gameObject.transform.parent.GetComponent<VisualEffect>().Stop();
            destroyed = true;
            first = false;
        }
    }

    private void OnEnable()
    {
        if (destroyed)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class OnTriggerEvents : MonoBehaviour
{
    public UnityEvent onTrigEnter, onTrigStay, onTrigExit;
    public string tagName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            onTrigEnter.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            onTrigStay.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            onTrigExit.Invoke();
        }
    }
}

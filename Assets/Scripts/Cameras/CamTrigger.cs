using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Transform pRef;
    public GameObject pCam;
    public CapsuleCollider boxCam;
    private Vector3 pBack;
    public bool bloquearCam = false, repetir = false;
    private bool estado = true;

    private void Awake()
    {
        pBack = pCam.transform.localPosition;
    }

    private void Update()
    {
        if (bloquearCam && repetir)
        {
            pCam.transform.localPosition = new Vector3(pRef.localPosition.x, pCam.transform.localPosition.y, pRef.localPosition.z+0.5f);
            boxCam.enabled = true;
            repetir = false;
        }
        if (!bloquearCam && repetir)
        {
            pCam.transform.localPosition = pBack;
            boxCam.enabled = false;
            repetir = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (estado && !other.CompareTag("Player") && !bloquearCam)
        {
            
            pCam.transform.localPosition = new Vector3(pRef.localPosition.x, pCam.transform.localPosition.y, pRef.localPosition.z+0.5f);
            estado = false;
            boxCam.enabled = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (!estado && !other.CompareTag("Player") && !bloquearCam)
        {
            
            pCam.transform.localPosition = pBack;
            estado = true;
            boxCam.enabled = false;
        }
    }
}

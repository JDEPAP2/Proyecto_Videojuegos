using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovNube : MonoBehaviour
{
    public Reiniciar estado;
    private Vector3 posI;
    private void Awake()
    {
        posI = transform.position;
    }

    private void Update()
    {
        if(estado.parcial || estado.total)
        {
            transform.position = posI;
        }
    }

    [System.Obsolete]
    private void OnTriggerStay(Collider other) {
        if (Input.GetKey(KeyCode.N) && other.CompareTag("Player")){
            transform.position = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
        }
    } 
}
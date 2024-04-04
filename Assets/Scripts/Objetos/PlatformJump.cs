using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJump : MonoBehaviour
{
    public Rigidbody rb;
    public float fuerzaSalto;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ImpulsoSalto")
        {
            rb.AddForce(new Vector3(0,fuerzaSalto,0),ForceMode.Impulse);
        }
    }

        private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ImpulsoSalto")
        {
            rb.AddForce(new Vector3(0,0,0),ForceMode.Acceleration);
            rb.AddForce(new Vector3(0,0,0),ForceMode.Impulse);
        }
    }

}

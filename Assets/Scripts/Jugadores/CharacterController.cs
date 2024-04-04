using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharacterController : MonoBehaviour
{
    public float velocidadM = 5.0f;
    public float velocidadR = 200.0f;
    private Animator a;
    public float x, y;
    public Rigidbody rb;
    public float fSalto = 8f;
    public bool saltar;
    public GameObject P2;

    void Start()
    {
        saltar = false;
    }

    void FixedUpdate()
    {
        P2.transform.rotation = transform.rotation;
        P2.transform.position = transform.position;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

   

        if (saltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                a.SetBool("salto", true);
                rb.AddForce(new Vector3(0, fSalto, 0), ForceMode.Impulse);
            }
            a.SetBool("suelo", true);
        }
    }
}
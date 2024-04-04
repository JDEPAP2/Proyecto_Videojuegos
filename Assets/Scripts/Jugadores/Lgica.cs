using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lgica : MonoBehaviour
{
    public float velM = 5f, velR = 250f, salto = 8f;
    private Animator anim;
    private Rigidbody rb;
    public bool canJump, swich = false;
    public float x, y;

    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove;
    public float speed = 2;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * velR, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velM);
    }

    [System.Obsolete]
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        turn.x += Input.GetAxis("Mouse X") * sensitivity * speed;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity * speed;
        transform.localRotation = Quaternion.Euler((-turn.y)/90, turn.x, 0);
        

        if (swich)
        {
            anim.SetBool("Swich", true);
            swich = false;
        }
        else
        {
            anim.SetBool("Swich", false);
        }



        if (Input.GetKey(KeyCode.LeftShift))
        {
            velM = 10f;
            anim.SetBool("Run", true);
        }
        else
        {
            velM = 5f;
            anim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            anim.SetBool("Atack", true);
        }
        else
        {
            anim.SetBool("Atack", false);
        }

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Jump", true);
                rb.AddForce(new Vector3(0, salto, 0), ForceMode.Impulse);
            }
            anim.SetBool("Floor", true);
        }
        else
        {
            anim.SetBool("Floor", false);
            anim.SetBool("Jump", false);
        }

        if (anim.GetBool("Eva"))
        {
            if (Input.GetKey(KeyCode.E))
            {

                anim.SetBool("Crouch", true);
            }
            else
            {
                anim.SetBool("Crouch", false);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("Push", true);
            }
            else
            {

                anim.SetBool("Push", false);
            }

        }
    }
}

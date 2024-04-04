using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateController : MonoBehaviour
{
    Animator animator;
    float velocityX = 0.0f, velocityZ = 0.0f;
    float speed = 2;
    public float velM = 5f, velR = 250f, height = 8f;
    float x, y;
    Vector2 turn;

    public float sensitivity = .5f;
    public float acceleration = 2f, deceleration = 2f,
        maxVelocity = 2, minVelocity = 0.5f;

    public bool run;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * velR, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velM);
    }
    // Update is called once per frame
    void Update()
    {
        playerMovement();
        CameraMovement();
    }


    void CameraMovement()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        turn.x += Input.GetAxis("Mouse X") * sensitivity * speed;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity * speed;
        transform.localRotation = Quaternion.Euler((-turn.y) / 90, turn.x, 0);
    }


    void playerMovement()
    {
        run = Input.GetKey(KeyCode.LeftShift);
        bool left = Input.GetAxis("Horizontal") < 0;
        bool right = Input.GetAxis("Horizontal") > 0;
        bool backward = Input.GetAxis("Vertical") < 0;
        bool forward = Input.GetAxis("Vertical") > 0;

        float currVelocity = run ? maxVelocity : minVelocity;

        if (left && velocityX > -currVelocity) //Left
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        if (!left && velocityX < 0)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        if (right && velocityX < currVelocity) //Right
        {
            velocityX += Time.deltaTime * deceleration;
        }
        if (!right && velocityX > 0)
        {
            velocityX -= Time.deltaTime * deceleration;
        }

        if (!left && !right && velocityX != 0.0f && (velocityX > -0.05 && velocityX < 0.05f))
        {
            velocityX = 0;
        }


        if (forward && velocityZ < currVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        if (!forward && velocityZ > 0)
        {
            velocityZ -= Time.deltaTime * acceleration;
        }

        if (backward && velocityZ > -currVelocity)
        {
            velocityZ -= Time.deltaTime * acceleration;
        }
        if (!backward && velocityZ < 0)
        {
            velocityZ += Time.deltaTime * deceleration;
        }

        if (!forward && !backward && velocityZ != 0.0f && (velocityZ > -0.05 && velocityZ < 0.05f))
        {
            velocityZ = 0;
        }

        animator.SetFloat("velocityZ", velocityZ);
        animator.SetFloat("velocityX", velocityX);
    }
}
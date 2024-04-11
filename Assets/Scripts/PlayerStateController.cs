using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    Animator animator;
    private float velocityX = 0.0f, velocityZ = 0.0f;
    float x, y, currVelocity;
    Vector2 turn;
    int VelocityZHash, VelocityXHash;
    bool left, right, backward, forward;
    bool run;

    public float velM = 5f, velR = 250f, height = 8f;

    [Header("Movement")]
    public float sensitivity = .5f;
    [SerializeField]
    float speed = 0.1f;
    public float acceleration = 2f, deceleration = 2f,
        maxVelocity = 2, minVelocity = 0.5f;

    [SerializeField]
    private TargetController camTarget;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityXHash = Animator.StringToHash("velocityX");
        VelocityZHash = Animator.StringToHash("velocityZ");
    }


    private void FixedUpdate()
    {
        run = Input.GetKey(KeyCode.LeftShift);
        left = Input.GetAxis("Horizontal") < 0;
        right = Input.GetAxis("Horizontal") > 0;
        backward = Input.GetAxis("Vertical") < 0;
        forward = Input.GetAxis("Vertical") > 0;

        currVelocity = run ? maxVelocity : minVelocity;
        PlayerRotation();
        PlayerMovement();
        LockMovement();
        transform.Translate(velocityX*speed, 0, velocityZ*speed);
        animator.SetFloat(VelocityZHash, velocityZ);
        animator.SetFloat(VelocityXHash, velocityX);
    }

    void PlayerRotation()
    {
        //float h  = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        ////var moveInput = (new Vector3(h, 0, v)).normalized;

        ////var moveDir = camTarget.PlanarRotation * moveInput;

        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.PlanarRotation, 1);

    }


    void PlayerMovement()
    {
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



    }

    void LockMovement()
    {
        //Locks

        //Forward
        if (forward && run && velocityZ > currVelocity)
        {
            velocityZ = currVelocity;
        }
        else if (forward && velocityZ > currVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if (velocityZ > currVelocity && velocityZ < (currVelocity + 0.05))
            {
                velocityZ = currVelocity;
            }

        }
        else if (forward && velocityZ < currVelocity && velocityZ > (currVelocity - 0.05f))
        {
            velocityZ = currVelocity;
        }



        //Backward
        if (backward && run && velocityZ < -currVelocity)
        {
            velocityZ = -currVelocity;
        }
        else if (backward && velocityZ < -currVelocity)
        {
            velocityZ += Time.deltaTime * deceleration;
            if (velocityZ < -currVelocity && velocityZ < (-currVelocity - 0.05))
            {
                velocityZ = -currVelocity;
            }

        }
        else if (backward && velocityZ > -currVelocity && velocityZ < (-currVelocity + 0.05f))
        {
            velocityZ = -currVelocity;
        }


        //Right
        if (right && run && velocityX > currVelocity)
        {
            velocityX = currVelocity;
        }
        else if (right && velocityX > currVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;
            if (velocityX > currVelocity && velocityX < (currVelocity + 0.05))
            {
                velocityX = currVelocity;
            }

        }
        else if (right && velocityX < currVelocity && velocityX > (currVelocity - 0.05f))
        {
            velocityX = currVelocity;
        }



        //Left
        if (left && run && velocityX < -currVelocity)
        {
            velocityX = -currVelocity;
        }
        else if (left && velocityX < -currVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            if (velocityX < -currVelocity && velocityX < (-currVelocity - 0.05))
            {
                velocityX = -currVelocity;
            }

        }
        else if (left && velocityX > -currVelocity && velocityX < (-currVelocity + 0.05f))
        {
            velocityX = -currVelocity;
        }
    }
}
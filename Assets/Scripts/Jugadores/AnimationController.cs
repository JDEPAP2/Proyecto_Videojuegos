using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;
    int isSpecialHash;
    int isAttackHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isSpecialHash = Animator.StringToHash("isSpecial");
        isAttackHash = Animator.StringToHash("isAttack");

    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool isSpecial = animator.GetBool(isSpecialHash);
        bool isAttack = animator.GetBool(isAttackHash);
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool backPressed = Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        bool specialPressed = Input.GetKey("e");
        bool attackPressed = Input.GetKey("q");

        if ((forwardPressed || leftPressed || rightPressed) && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if (!forwardPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (runPressed && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if (!runPressed && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
        if (jumpPressed && !isJumping)
        {
            animator.SetBool(isJumpingHash, true);
        }
        else if (!jumpPressed && isJumping)
        {
            animator.SetBool(isJumpingHash, false);
        }
        if (specialPressed && !isSpecial)
        {
            animator.SetBool(isSpecialHash, true);
        }
        else if (!specialPressed && isSpecial)
        {
            animator.SetBool(isSpecialHash, false);
        }
        if (attackPressed && !isAttack)
        {
            animator.SetBool(isAttackHash, true);
        }
        else if (!attackPressed && isAttack)
        {
            animator.SetBool(isAttackHash, false);
        }
    }
}

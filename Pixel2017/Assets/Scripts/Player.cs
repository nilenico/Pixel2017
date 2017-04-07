using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerController
{
    private Animator animator;

    private bool animationIsSet = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!animationIsSet)
        {
            SetAnimators();
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("isClose", true);
            animator.SetBool("isPushing", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("isClose", false);
            animator.SetBool("isPushing", true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("isClose", false);
            animator.SetBool("isPushing", false);
        }
    }

    void SetAnimators()
    {
        switch (this.pid)
        {
            case 0:
                animator.runtimeAnimatorController = Resources.Load("Animators/SpoutnikAnimator") as RuntimeAnimatorController;
                break;
            case 1:
                animator.runtimeAnimatorController = Resources.Load("Animators/HubbleAnimator") as RuntimeAnimatorController;
                break;
            case 2:
                animator.runtimeAnimatorController = Resources.Load("Animators/AstridAnimator") as RuntimeAnimatorController;
                break;
            case 3:
                animator.runtimeAnimatorController = Resources.Load("Animators/KeplerAnimator") as RuntimeAnimatorController;
                break;
        }
    }


}
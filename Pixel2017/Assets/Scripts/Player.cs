using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using System;

public class Player : PlayerController
{
    protected GameObject border;
    void Start() {
       this.OnDie += performDie;
    }
        
    void performDie() {
        Destroy(this.gameObject);
    }
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
        SetRotation();


        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = new Quaternion(0, 0, -90, 0);
            animator.SetBool("isClose", true);
            animator.SetBool("isPushing", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = new Quaternion(0, 0, 90, 0);
            animator.SetBool("isClose", false);
            animator.SetBool("isPushing", true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("isClose", false);
            animator.SetBool("isPushing", false);
        }
    }

    void SetRotation()
    {
        if(InputManager.Devices[pid].LeftStickX.Value > 0.2)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if (InputManager.Devices[pid].LeftStickX.Value < -0.2)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (InputManager.Devices[pid].LeftStickY.Value > 0.2)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (InputManager.Devices[pid].LeftStickY.Value < -0.2)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
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
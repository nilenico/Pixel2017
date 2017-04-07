﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using System;

public class Player : PlayerController
{
    private Animator animator;
    
    private bool animationIsSet = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        this.OnDie += performDie;
    }
        
    void performDie() {
        Destroy(this.gameObject);
    }
    private bool animationIsSet = false;


    void Update()
    {
        if (!animationIsSet)
        {
            SetAnimators();
        }
        Actions();

    }

    void Actions()
    {
        SetRotation();
        CheckForPush();
        CollectItem();
    }

    void SetRotation()
    {
        if (InputManager.Devices[pid].LeftStickX.Value < -0.2 ||
            InputManager.Devices[pid].LeftStickX.Value > 0.2 ||
            InputManager.Devices[pid].LeftStickY.Value < -0.2 ||
            InputManager.Devices[pid].LeftStickY.Value > 0.2)
        {
            float angle = Mathf.Atan2(InputManager.Devices[pid].LeftStickX.Value, InputManager.Devices[pid].LeftStickY.Value);
            float degree = angle * Mathf.Rad2Deg;
            Quaternion eulerRot = Quaternion.Euler(0.0f, 0.0f, -degree);
            transform.rotation = Quaternion.Slerp(transform.rotation, eulerRot, Time.deltaTime * 10);
        }
    }


    void CheckForPush()
    {
        Vector3 rayOffset = transform.position + transform.up * 1.8f;
        RaycastHit2D hit1 = Physics2D.Raycast(rayOffset, transform.up, 0.8f);
        RaycastHit2D hit2 = Physics2D.Raycast(rayOffset, transform.up, 0.3f);

        if (hit1.collider != null && (hit1.transform.tag == "Wall" || hit1.transform.tag == "Border"))
        {
            animator.SetBool("isClose", true);
            animator.SetBool("isPushing", false);
            if (hit2.collider != null && (hit2.transform.tag == "Wall" || hit2.transform.tag == "Border"))
            {
                animator.SetBool("isClose", false);
                animator.SetBool("isPushing", true);
            }
        }
        else
        {
            animator.SetBool("isClose", false);
            animator.SetBool("isPushing", false);
        }
    }

    void CollectItem()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.8f);
        if (hit.collider != null && hit.transform.tag == "Item")
        {
            foreach (Transform child in transform)
            {
                foreach (AnimationsTestScript boosterAnim in child.GetComponentsInChildren<AnimationsTestScript>())
                {
                    boosterAnim.isBoosting = true;
                }
            }
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
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using System;

public class Player : PlayerController
{
    private Animator animator;
    private SpriteRenderer shockwaveSprite;
    private BoxCollider2D boxCollider;
    public AudioClip[] audioClips;

    private bool animationIsSet = false;
    public bool gotShocked = false;
    public bool isShocked = false;
    private float startTime;
    private float shockedTime = 2.0f;
    private float startSpeed;
    bool canPlayShock = true;


    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "playerShockwave")
            {
                shockwaveSprite = child.GetComponent<SpriteRenderer>();
            }
        }
        startTime = Time.time;
        this.OnDie += performDie;

        startSpeed = speed;
       
    }
        
    void performDie() {
        StartCoroutine(playSound(1)); //OhNoNo sound
        StartCoroutine(waitDestroyObject());
    }


    void Update()
    {
        if (!animationIsSet)
        {
            SetAnimators();
        }
        Actions();


        if (Input.GetKeyDown(KeyCode.K))
        {
            //performDie();
            //CallShock();
            //CheckForPush();
        }

    }

    void Actions()
    {
        if(!gotShocked)
        {
            SetRotation();
            CheckForPush();
        }
        else
        {
            if (!isShocked)
            {
                CallShock();
            }
            else
            { 
                CheckForPush();
                if ((startTime + shockedTime) <= Time.time)
                {
                    shockwaveSprite.enabled = false;
                    isShocked = false;
                    gotShocked = false;
                    animator.SetBool("isElectro", false);
                    speed = startSpeed;
                }
            }
        }
    }

    void SetRotation()
    {
        if(InputManager.Devices.Count >0)
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
                //StartCoroutine(playSound(2));
            }
        }
        else
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


    void ShockingFunction(AnimationsTestScript boosterAnim)
    {
        shockwaveSprite.enabled = true;
        boosterAnim.gotShocked = true;
        isShocked = true;
        animator.SetBool("isElectro", true);
        startTime = Time.time;
    }


    void CallShock()
    {
        StartCoroutine(playShockSound());
        foreach (Transform child in transform)
        {
            foreach (AnimationsTestScript boosterAnim in child.GetComponentsInChildren<AnimationsTestScript>())
            {
                ShockingFunction(boosterAnim);
            }
        }
    }

    IEnumerator playSound(int audioClipIndex)
    {
        canPlayShock = false;
        GetComponent<AudioSource>().clip = audioClips[audioClipIndex];
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5.0f);
        canPlayShock = true;
    }

    IEnumerator playShockSound()
    {
        if (canPlayShock)
        {
            canPlayShock = false;
            GetComponent<AudioSource>().clip = audioClips[0];
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5.0f);
            canPlayShock = true;
        }
    }

    IEnumerator waitDestroyObject()
    {
        //need this so the audioclip can finish playing
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    }

}
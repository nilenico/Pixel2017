using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using System;

public class Player : PlayerController
{
    private Animator animator;
    private SpriteRenderer shockwaveSprite;
    private SpriteRenderer panicSprite;
    private BoxCollider2D boxCollider;
    public AudioClip[] audioClips;
    private Blaster blaster;
    public GameObject target;
    private GameObject currentTarget;

    private bool animationIsSet = false;
    public bool gotShocked = false;
    public bool isShocked = false;
    public bool gotBoost = false;
    private float startTime;
    private float shockedTime = 2.0f;
    private float startSpeed;
    bool canPlayShock = true;
    public bool canBlast;
    private Vector3 originPos;
    private Vector3 targetVelocity;
    bool canPlayPanicSound = true;
    bool canFlashPanic = true;

    public delegate void Blast(Transform trs);
    public static event Blast OnBlast;


    void Start()
    {
        originPos = transform.position;
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
        this.OnPanic += performPanic;
        startSpeed = speed;
    }

    void performDie() {
        Destroy(this.gameObject);
        Destroy(GameObject.FindGameObjectWithTag("Spawner") as GameObject);
    }

    void performPanic()
    {
        StartCoroutine(playPanicSound());
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        if (canFlashPanic)
        {
            canFlashPanic = false;

            panicSprite = GetComponent<SpriteRenderer>();

            for (int i = 0; i < 10; i++)
            {
                panicSprite.color = new Color32(200, 200, 200, 255);
                yield return new WaitForSeconds(0.1f);
                panicSprite.color = new Color(255, 255, 255, 255);
                yield return new WaitForSeconds(0.1f);
            }
            
            canFlashPanic = true;
        }
        

    }

    void Update()
    {
        if (!animationIsSet)
        {
            SetAnimators();
        }
        Actions();

        if (canBlast && currentTarget != null){
            targetVelocity = Vector3.zero;
            targetVelocity.y += InputManager.Devices[pid].RightStickY.Value * 5;
            targetVelocity.x += InputManager.Devices[pid].RightStickX.Value * 5;
            currentTarget.transform.position += targetVelocity * 5 * Time.deltaTime;
            SpriteRenderer targetSprite = currentTarget.GetComponent<SpriteRenderer>();
            switch (pid)
            {
                case 0:
                    targetSprite.color = new Color32(10, 119, 255, 255);
                    break;
                case 1:
                    targetSprite.color = new Color32(255, 184, 10, 255);
                    break;
                case 2:
                    targetSprite.color = new Color32(206, 41, 223, 255);
                    break;
                case 3:
                    targetSprite.color = new Color32(57, 203, 193, 255);
                    break;
            }
            if (InputManager.Devices[pid].Action1.WasPressed)
            {
                canBlast = false;
                LaunchMissile(currentTarget.transform);
            }

        }
    }

    public Vector3 GetOriginPos() { return originPos; }

    void Actions()
    {
        if(!gotShocked)
        {
            SetRotation();
            CheckForPush();
            if (gotBoost)
            {
                SetBoostAnim();
            }
            else
            {
                foreach (Transform child in transform)
                {
                    foreach (AnimationsTestScript boosterAnim in child.GetComponentsInChildren<AnimationsTestScript>())
                    {
                        boosterAnim.isBoosting = false;
                    }
                }
            }
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
        if(InputManager.Devices.Count > 0)
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

    void SetBoostAnim()
    {
        foreach (Transform child in transform)
        {
            foreach (AnimationsTestScript boosterAnim in child.GetComponentsInChildren<AnimationsTestScript>())
            {
                boosterAnim.isBoosting = true;
            }
        }
    }

    public void SetCanBlast(bool canBlast) {
        this.canBlast = canBlast;
        if (canBlast){
            currentTarget = Instantiate(target, transform.position, Quaternion.identity);
        }
    }

    private void LaunchMissile(Transform trs) {
        if (OnBlast != null){
            OnBlast(trs);
            currentTarget = null;
        }
    }

    IEnumerator playPanicSound()
    {
        if (canPlayPanicSound)
        {
            canPlayPanicSound = false;
            GetComponent<AudioSource>().clip = audioClips[1];
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(8.0f);
            canPlayPanicSound = true;
        }
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
}
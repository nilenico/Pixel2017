using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsTestScript : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer sprite;

    public bool isBoosting = false;
    public bool gotShocked = false;
    private bool isShocked = false;

    private float shockTime = 2.0f;
    private float startTime;


    void Start ()
    {
        startTime = Time.time;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
	
	void Update ()
    {
        CheckBoost();
        CheckElectro();



        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isBoosting", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("isBoosting", false);
        }

    }


    void CheckBoost()
    {
        if (isBoosting)
            animator.SetBool("isBoosting", true);
        if (!isBoosting)
            animator.SetBool("isBoosting", false);
    }

    void CheckElectro()
    {
        animator.SetBool("restart", false);
        if (gotShocked)
        {
            animator.SetBool("isOff", true);
            startTime = Time.time;
            gotShocked = false;
            isShocked = true;
            sprite.enabled = false;
        }
        if (isShocked && startTime + shockTime <= Time.time)
        {
            isShocked = false;
            sprite.enabled = true;
            animator.SetBool("isOff", false);
            animator.SetBool("restart", true);
        }

    }
}

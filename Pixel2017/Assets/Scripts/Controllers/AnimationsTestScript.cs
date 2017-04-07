using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsTestScript : MonoBehaviour
{

    private Animator animator;


    void Start ()
    {
        animator = GetComponent<Animator>();

    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isBoosting", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("isBoosting", false);
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsTestScript : MonoBehaviour
{

    private Animator animator;
    public bool isBoosting = false;


    void Start ()
    {
        animator = GetComponent<Animator>();

    }
	
	void Update ()
    {
        if(isBoosting)
            animator.SetBool("isBoosting", true);


        if (!isBoosting)
            animator.SetBool("isBoosting", false);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isBoosting", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("isBoosting", false);
        }

    }
}

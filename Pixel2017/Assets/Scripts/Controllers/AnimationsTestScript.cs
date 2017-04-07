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

    }
}

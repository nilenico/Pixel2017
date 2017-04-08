using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using System;

public class PlayerController : MonoBehaviour {
    protected int pid = 0;
    public float speed = 10;
    private Vector3 velocity;
    bool gameStarted = false;

    protected delegate void Die();
    protected event Die OnDie;


    public delegate void RemovePlayer();
    public static event RemovePlayer OnRemovePlayer;
    
    

    public void setPid(int pid) {
        this.pid = pid;
    }

    IEnumerator waitForStart()
    {
        yield return new WaitForSeconds(5.0f);
        gameStarted = true;
    }

    void FixedUpdate() {
        if(!gameStarted)
            StartCoroutine(waitForStart());

        if (InputManager.Devices.Count > 0 && gameStarted)
        {
            velocity = Vector3.zero;
            velocity.x += InputManager.Devices[pid].LeftStickX.Value * speed;
            velocity.y += InputManager.Devices[pid].LeftStickY.Value * speed;
            transform.position += velocity * speed * Time.deltaTime;

            Vector3 offset = transform.position + transform.up * 1.8f;

            RaycastHit2D upHit = Physics2D.Raycast(offset, transform.up, 0.03f);
            offset = transform.position - transform.right * 1.8f;
            RaycastHit2D leftHit = Physics2D.Raycast(offset, -transform.right, 0.03f);

            if (leftHit.collider != null && (leftHit.transform.tag == "Wall" || leftHit.transform.tag == "Border"))
            {
                offset = transform.position + transform.right * 1.8f;
                RaycastHit2D rightHit = Physics2D.Raycast(offset, transform.right, 0.03f);
                if (rightHit.collider != null && (rightHit.transform.tag == "Wall" || rightHit.transform.tag == "Border"))
                {
                    if (OnDie != null)
                        OnDie();
                    if (OnRemovePlayer != null)
                        OnRemovePlayer();
                }
            }

            if (upHit.collider != null && (upHit.transform.tag == "Wall" || upHit.transform.tag == "Border"))   
            {
                offset = transform.position - transform.up * 0.5f;
                RaycastHit2D downHit = Physics2D.Raycast(offset, -transform.up, 0.03f);
                if (downHit.collider != null && (downHit.transform.tag == "Wall" || downHit.transform.tag == "Border")) {
                    if (OnDie != null)
                        OnDie();
                    if (OnRemovePlayer != null)
                        OnRemovePlayer();

                }
            }
        }
    }
}

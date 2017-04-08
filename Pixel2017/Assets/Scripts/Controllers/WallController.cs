using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {
    public bool isHorizontal;
    private bool isDestroyed;

    private float killTime = 0.5f;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if(isDestroyed && startTime + killTime <= Time.time)
            Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Border") {
            startTime = Time.time;
            isDestroyed = true;
            foreach (Transform child in transform)
            {
                foreach (Animator laserAnim in child.GetComponentsInChildren<Animator>())
                {
                    laserAnim.SetBool("isDestroyed", true);
                }
            }
        }
    }
}
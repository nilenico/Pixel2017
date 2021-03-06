﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableProps : MonoBehaviour {
    public bool rotate = true;
    public float speed = 1;

    private Vector3 velocity;
    private Quaternion lookRotation;
	void Start () {
        speed *= WanderingBackground.maximumSpeed;
        velocity = new Vector3(0 - transform.position.x, 0 - transform.position.y, 0);
        Destroy(this.gameObject, 20/speed);
    }       
	// Update is called once per frame
	void Update () {
        if(rotate)
            transform.Rotate(0, 0, Time.deltaTime * speed * 50);
        transform.position += velocity * speed * Time.deltaTime;
        OnDeath();
	}

    void OnDeath()
    {
        if (transform.position.x > 30.0f || transform.position.x < -30.0f)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y > 30.0f || transform.position.y < -30.0f)
        {
            Destroy(this.gameObject);
        }
    }
}

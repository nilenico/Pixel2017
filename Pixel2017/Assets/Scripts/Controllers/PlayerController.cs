using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using System;

public class PlayerController : MonoBehaviour {
    protected int pid = 0;
    public float speed = 5;
    private Vector3 velocity;

    public void setPid(int pid) {
        this.pid = pid;
    }

    void FixedUpdate() {
        if(InputManager.Devices.Count > 0)
        {
            velocity = Vector3.zero;
            velocity.x += InputManager.Devices[pid].LeftStickX.Value;
            velocity.y += InputManager.Devices[pid].LeftStickY.Value;
            transform.position += velocity * speed * Time.deltaTime;
        }

    }
}

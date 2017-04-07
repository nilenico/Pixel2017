using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player {

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W)) {
            transform.position += Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            transform.position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            transform.position += Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.D))  {
            transform.position += Vector3.right;
        }
    }
}

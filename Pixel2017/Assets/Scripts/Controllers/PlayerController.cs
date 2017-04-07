using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player {
 
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.up * speed; ;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * speed ;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.down * speed;
        }
        if (Input.GetKey(KeyCode.D))  {
            transform.position += Vector3.right * speed;
        }
    }
}

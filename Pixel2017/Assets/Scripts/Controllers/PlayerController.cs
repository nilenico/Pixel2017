using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player {


    void Start() {
    }

	// Update is called once per frame
	void Update () {
        checkInput();
    }

    private void checkInput() {

        if (Input.GetKey(KeyCode.W)){
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)){
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("speed_boost"))
        {
            speed *= 1.5f;
        }
    }
}

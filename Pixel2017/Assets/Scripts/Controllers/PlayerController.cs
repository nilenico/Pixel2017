using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player {

    public float movingSpeed;

    void Start() {
    }

	// Update is called once per frame
	void Update () {
        checkInput();
    }

    private void checkInput() {

        if (Input.GetKey(KeyCode.W)){
            transform.position += Vector3.up * movingSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left * movingSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)){
            transform.position += Vector3.down * movingSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * movingSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("speed_boost"))
        {
            Debug.Log("Speed boosT");
            movingSpeed *= 1.5f;
        }
    }
}

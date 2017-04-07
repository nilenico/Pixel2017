using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

    public float MoveSpeed;

    public float frequency;  // Speed of sine movement
    public float magnitude;   // Size of sine movement
    private Vector3 axis;
    Vector3 pos;


    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        axis = transform.right;  // May or may not be the axis you want
    }
	
	// Update is called once per frame
	void Update () {
        move();
	}

    private void move() {
        pos += transform.up * Time.deltaTime * MoveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}

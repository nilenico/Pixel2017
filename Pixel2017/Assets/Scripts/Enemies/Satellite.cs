using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

    public float MoveSpeed;
    public GameObject beam_go;

    private float frequency;  // Speed of sine movement
    private float magnitude;   // Size of sine movement
    private Vector3 axis;
    Vector3 pos;
    private int beamTimeout;
    private int initial_time_beam = 300;
    private Vector3 normalizedDirection;
    private float rotateSpeed = 60.0f;


    // Use this for initialization
    void Start()
    {
        frequency = 4.0f;
        magnitude = 4.0f;

        pos = transform.position;
        axis = transform.right;  // May or may not be the axis you want
        beamTimeout = initial_time_beam;
        normalizedDirection = (Vector3.zero - transform.position).normalized;
    }
	
	// Update is called once per frame
	void Update () {
        move();
        onRotate();

        if (beamTimeout <= 0)
        {
            releaseBeam(beam_go);
            beamTimeout = initial_time_beam;
        }
        else { beamTimeout--; }
	}

    private void move() {
        pos += normalizedDirection * MoveSpeed * Time.deltaTime;
        Vector3 axis = new Vector3(normalizedDirection.x, normalizedDirection.y);
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    private void releaseBeam(GameObject beam) {
        Instantiate(beam, transform.position, Quaternion.identity);
    }

    void onRotate()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed);
    }

}

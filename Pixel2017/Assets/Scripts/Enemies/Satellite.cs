using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

    public float MoveSpeed;
    public GameObject beam_go;

    public float frequency;  // Speed of sine movement
    public float magnitude;   // Size of sine movement
    private Vector3 axis;
    Vector3 pos;
    private int beamTimeout;
    private int initial_time_beam = 300;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        axis = transform.right;  // May or may not be the axis you want
        beamTimeout = initial_time_beam;
    }
	
	// Update is called once per frame
	void Update () {
        move();
        if (beamTimeout <= 0)
        {
            releaseBeam(beam_go);
            beamTimeout = initial_time_beam;
        }
        else { beamTimeout--; }
	}

    private void move() {
        pos += transform.up * Time.deltaTime * MoveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    private void releaseBeam(GameObject beam) {
        Instantiate(beam, transform.position, Quaternion.identity);
    }

}

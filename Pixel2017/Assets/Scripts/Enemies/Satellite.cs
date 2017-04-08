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
    private int initial_time_beam = 0;
    private Vector3 normalizedDirection;
    private float distanceToCenter;
    private float rotateSpeed = 60.0f;
    private bool hasPlayed = false;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        beamTimeout = initial_time_beam;
        normalizedDirection = (Vector3.zero - transform.position).normalized;
        releaseBeam(beam_go);
    }

    // Update is called once per frame
    void Update () {
        move();
        onRotate();

        playEnterSound();

        /*if (beamTimeout <= 0)
        {
            
            beamTimeout = initial_time_beam;
        }
        else { beamTimeout--; }*/
	}

    private void move() {
        pos += normalizedDirection * MoveSpeed * Time.deltaTime;
        axis = new Vector3(-normalizedDirection.x, normalizedDirection.y);
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    private void releaseBeam(GameObject beam) {
        (Instantiate(beam, transform.position, Quaternion.identity) as GameObject).transform.parent = this.transform;
            
    }

    void onRotate(){
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed);
    }

    void playEnterSound()
    {
        distanceToCenter = Vector3.Distance(Vector3.zero, transform.position);
        if (distanceToCenter < 35.0f && hasPlayed == false)
        {
            GetComponent<AudioSource>().Play();
            hasPlayed = true;
        }
    }
}

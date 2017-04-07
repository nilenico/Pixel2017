using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    private float startTime;
    public float speed = 1;

    public GameObject level;
    private Vector3 shrinkspeed;

    void Start () {
        shrinkspeed = new Vector3(speed, speed, speed);
        startTime = Time.time;	
	}

	void Update () {
        if(startTime < Time.time + speed) {
            //Reduce 
            level.transform.localScale -= shrinkspeed * speed * Time.deltaTime;
            startTime = Time.time;            
        }
	}
}

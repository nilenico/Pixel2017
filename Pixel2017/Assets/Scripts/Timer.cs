using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    private float startTime;
    public float speed = 1;
    public bool active;
    public GameObject level;
    private Vector3 shrinkspeed;

    public void Stop() { active = false; }
    void Start () {
        shrinkspeed = new Vector3(speed, speed, speed);
        startTime = Time.time;	
	}

	void Update () {
        if(active) {
            if(startTime < Time.time + speed) {
                //Reduce 
                level.transform.localScale -= shrinkspeed * speed * Time.deltaTime;
                startTime = Time.time;            
            }
        }
	}
}

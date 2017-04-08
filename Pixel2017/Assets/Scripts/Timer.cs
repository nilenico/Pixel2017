using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    private float startTime;
    public float speed = 1;
    public bool active;
    public GameObject level;
    public GameObject Wall1;
    public GameObject Wall2;
    private Vector3 shrinkspeed;
    public float coefficient = 4;

    public void Stop() { active = false; }
    void Start () {
        shrinkspeed = new Vector3(speed, speed, speed);
        startTime = Time.time;	
	}
    public float GetSpeed() { return speed; }
	void Update () {
        if(active) {
            if(startTime < Time.time + speed) {
                //Reduce 
                level.transform.localScale -= shrinkspeed * speed * Time.deltaTime;
                if(Wall1 != null) {
                    Wall1.transform.localScale -=  new Vector3(0, coefficient * speed * Time.deltaTime, 0);
                }
                if (Wall2 != null) {
                    Wall2.transform.localScale -= new Vector3(0, coefficient * speed * Time.deltaTime, 0);
                }
                startTime = Time.time;            
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class RomanoController : MonoBehaviour {

    public float speed;
    public float time = 25;
    private Vector3 velocity;
    private float startTime = 0;

    void Start () {
        startTime = Time.time;
        velocity = Vector3.left;
    }
	
	void FixedUpdate () {
        if(startTime + time <= Time.time ) {
            transform.position += velocity * speed * Time.deltaTime;
        }   
    
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAsteroidRotation : MonoBehaviour {

    private float rotateSpeed = 100.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        onRotate();

    }

    void onRotate()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed);
    }
}

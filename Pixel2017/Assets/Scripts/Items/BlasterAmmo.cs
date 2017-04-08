using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterAmmo : MonoBehaviour {

    public int speed;


	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.up * speed *Time.deltaTime;        	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag.Equals("Player")) {
            coll.GetComponent<Player>().gotShocked = true;
        }
    }
}

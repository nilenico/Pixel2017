using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAsteroid : MonoBehaviour {

    public float movementSpeed = 55.0f;
    //private float rotateSpeed = 100.0f;
    private float lifeTime = 10.0f;
    private float distanceToCenter;
    private bool hasPlayed = false;

    private Vector3 normalizedDirection;

    void Awake(){
        Destroy(gameObject, lifeTime);
    }

    // Use this for initialization
    void Start () {
        normalizedDirection = (Vector3.zero - transform.position).normalized;

    }
	
	// Update is called once per frame
	void Update () {
        onMove();
        //onRotate();
        //playEnterSound();

    }

    //void onRotate(){
    //    transform.Rotate(0, 0, Time.deltaTime * rotateSpeed);
    //}

    void onMove(){
        transform.position += normalizedDirection * movementSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag.Equals("Player")) {
            coll.transform.position += normalizedDirection * 30 * Time.deltaTime;
            //coll.transform.Rotate(0, 0, Time.deltaTime * rotateSpeed);
        }
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

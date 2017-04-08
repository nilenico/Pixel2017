using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterAmmo : MonoBehaviour {

    public float speed;
    private Vector3 target;
    private Vector3 velocity;
    public Transform trs;
    Vector3 direction;
    Vector3 origin;
    private float timeout;
    private Vector3 lastPos;

    private bool freezePlayer;
    private GameObject playerHit;
    private Vector3 freezePosition;
    private float freezeTimeout = 100;
    private float tempSpeed = 2.5f;


    // Use this for initialization
    void Start () {
        origin = transform.position;
        timeout = 10;
        GetComponent<CircleCollider2D>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (trs != null) {
            velocity = Vector3.zero;
            velocity += trs.position - origin;
            transform.position += velocity * speed*Time.deltaTime;
    }
        if (timeout <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = true;
            checkIfMoving(transform.position);
        }
        else { timeout--; }
        stun();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag.Equals("Player"))
        {
            coll.GetComponent<Player>().gotShocked = true;
            playerHit = coll.gameObject;
            freezePosition = transform.position;
            freezePlayer = true;
        }
        else if (coll.gameObject.tag.Equals("Target")) {
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void setTransform(Transform trs) {
        this.trs = trs;
    }

    private void checkIfMoving(Vector3 currentPos) {
        if (lastPos != null){
            if (lastPos == currentPos){
                Destroy(this.gameObject);
            }
            else { lastPos = currentPos; }
        }
        else { lastPos = currentPos; }
    }

    public void setVelocity(Vector3 velocity){
        this.velocity = velocity;
    }

    private void stun()
    {
        if (freezePlayer && playerHit != null)
        {
            if (freezeTimeout > 0)
            {
                playerHit.transform.position = freezePosition;
                freezeTimeout--;
            }
            else
            {
                freezeTimeout = 100;
                freezePosition = Vector3.zero;
                playerHit.GetComponent<Player>().speed = tempSpeed;
                playerHit = null;
            }
        }
    }
}

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
        }
        else { timeout--; }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag.Equals("Player"))
        {
            coll.GetComponent<Player>().gotShocked = true;
        }
        else if (coll.gameObject.tag.Equals("Target")) {
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
        Debug.Log("coll "+coll.gameObject.name);
        Debug.Log("trs " + trs.gameObject.name);
    }

    public void setTransform(Transform trs) {
        this.trs = trs;
    }

    public void setVelocity(Vector3 velocity){
        this.velocity = velocity;
    }
}

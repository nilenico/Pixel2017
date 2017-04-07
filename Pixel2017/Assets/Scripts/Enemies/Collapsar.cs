using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapsar : MonoBehaviour {

    public GameObject radius;
    private CircleCollider2D radius_coll;
    private GameObject attractObj;
    public int speed;
    public float distance;
    public bool swap_state;
    private Transform target;
    private int timeout;
    public int initial_timeout;

    // Use this for initialization
    void Start () {
        timeout = initial_timeout;
    }
	
	// Update is called once per frame
	void Update () {
        if (attractObj != null && (Vector3.Distance(transform.position, attractObj.transform.position) > distance)){
            attractObj.transform.position = Vector3.MoveTowards(attractObj.transform.position, transform.position, speed * Time.deltaTime);
        }
        else if ((attractObj != null && Vector3.Distance(transform.position, attractObj.transform.position) <= distance) && swap_state) {
            if (target != null){
                attractObj.transform.position = target.position;
            }
        }

        if (timeout >0) { timeout--; }
        else { Destroy(this.gameObject); }
        
	}

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag.Equals("Player")){
            attractObj = coll.gameObject;
        }
    }
}

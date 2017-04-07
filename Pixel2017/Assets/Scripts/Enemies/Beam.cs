using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public Vector3 beam_scale;
    private CircleCollider2D cirleCollider;
    private bool freezePlayer;
    private GameObject playerHit;
    private Vector3 freezePosition;
    private float freezeTimeout = 100;


    // Use this for initialization
    void Start () {
        cirleCollider = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += beam_scale;
        cirleCollider.radius += 0.0001f;
        stun();
        if (transform.localScale.x >= 90){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag.Equals("Player")){
            freezePlayer = true;
            playerHit = coll.gameObject;
            freezePosition = coll.transform.position;
        }
    }

    private void stun(){
        if (freezePlayer && playerHit != null) {
            if (freezeTimeout > 0){
                playerHit.transform.position = freezePosition;
                freezeTimeout--;
            }
            else {
                freezeTimeout = 100;
                playerHit = null;
                freezePosition = Vector3.zero;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {
    public bool isHorizontal;

    void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Border") {
            Destroy(this.gameObject);
        }
    }
}
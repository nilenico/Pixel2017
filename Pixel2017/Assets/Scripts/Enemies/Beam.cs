using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public Vector3 beam_scale;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += beam_scale;
        if (transform.localScale.x >= 30){
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    private GameObject speedyObj;
    private int timeout;
    public int boost_initial_timeout;

	// Use this for initialization
	void Start () {
        timeout = boost_initial_timeout;
	}
	
	// Update is called once per frame
	void Update () {
        if (speedyObj != null)
        {
            if (timeout <= 0)
            {
                speedyObj.GetComponent<Player>().speed /= 1.5f;
                //speedyObj.GetComponent<Player>().gotBoost = false;
                speedyObj = null;
                timeout = boost_initial_timeout;
                Destroy(this.gameObject);
            }
            else if (timeout > 0) { timeout--; }
        }
	}

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag.Equals("Player")) {
            coll.gameObject.GetComponent<Player>().speed *= 1.5f;
            //coll.gameObject.GetComponent<Player>().gotBoost = true;
            speedyObj = coll.gameObject;
            transform.position = new Vector3(0, 3000, 0);
        }
    }
}

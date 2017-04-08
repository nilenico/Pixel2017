using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItems : MonoBehaviour {

    private GameObject choosenItem;
    private Object[] vPowerUps;
    public float timeout;
    // Use this for initialization
    void Start () {
        Destroy(this.gameObject,timeout);
        vPowerUps = Resources.LoadAll("Prefabs/BoostItems");
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag.Equals("Player")) {
            Vector3 location = new Vector3(transform.position.x-0.2f, transform.position.y-0.2f, transform.position.z);
            choosenItem = Instantiate(vPowerUps[Random.Range(0, vPowerUps.Length)], transform.position, Quaternion.identity) as GameObject;
            //choosenItem = Instantiate(vPowerUps[0], transform.position, Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItems : MonoBehaviour {

    private GameObject choosenItem;
    private Object[] vPowerUps;

    // Use this for initialization
    void Start () {
        vPowerUps = Resources.LoadAll("Prefabs/BoostItems");
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag.Equals("Player")) {
            choosenItem = Instantiate(vPowerUps[Random.Range(0, vPowerUps.Length)], transform.position, Quaternion.identity) as GameObject;
            Debug.Log(choosenItem.name);
            Destroy(this.gameObject);
        }
    }
}

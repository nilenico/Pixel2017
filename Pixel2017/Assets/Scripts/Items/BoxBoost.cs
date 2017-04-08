using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBoost : MonoBehaviour {

    private GameObject choosenItem;
    public GameObject speedBoost;
    public GameObject blaster;
    public GameObject swapCollapsar;
    public GameObject normalCollapsar;

    private int timeout;
    public int startTimeout;

    // Use this for initialization
    void Start () {
        timeout = startTimeout;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeout <= 0) { Destroy(this.gameObject); }
        else { timeout--; }
	}

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag.Equals("Player")) {
            rollDice(coll.gameObject);
        }
    }

    private void rollDice(GameObject player) {
        int rnd = Random.Range(0, 29);

        if (rnd >= 0 && rnd < 10) { InstantiateSpeedBoost(); }
        if (rnd >= 10 && rnd < 20) { InstantiateBlaster(player); }
        if (rnd >= 20 && rnd < 25) { InstantiateSwapCollapsar(); }
        if (rnd >= 25 && rnd < 29) { InstantiateNormalCollapsar(); }
    }

    private void InstantiateSpeedBoost() {
        choosenItem = Instantiate(speedBoost, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    private void InstantiateBlaster(GameObject player)
    {
        choosenItem = Instantiate(blaster, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    private void InstantiateSwapCollapsar()
    {
        choosenItem = Instantiate(swapCollapsar, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    private void InstantiateNormalCollapsar()
    {
        choosenItem = Instantiate(normalCollapsar, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour {

    private GameObject player;
    private Ray ray;
    private Color rayColor = Color.green; //blue by default, update with the getPid
    public GameObject blasterAmmo;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            /*Physics2D.Raycast(player.transform.position, player.transform.up, 10);
            Vector3 forward = player.transform.TransformDirection(Vector3.up) * 50;
            Debug.DrawRay(player.transform.position, forward, rayColor);*/
            //Debug.Log("Shooting");
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log("Blasters hits");
        startFire(coll.gameObject);
        transform.position = new Vector3(0, 3000, 0);
    }

    private void startFire(GameObject player) {
        //player.GetComponent<Player>().getPid() get the color to set the beams color
        player.GetComponent<Player>().SetCanBlast(true, this);
        this.player = player;

    }

    public void shoot() {
        Instantiate(blasterAmmo, player.transform.position, player.transform.rotation);
    }
}

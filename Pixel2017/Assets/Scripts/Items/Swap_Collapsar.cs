using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap_Collapsar : Item
{
    private CircleCollider2D radius_coll;
    private GameObject attractObj;
    public int speed;
    public float distance;
    private Transform target;
    private Transform startFrom;
    private GameObject otherPlayerToSwap;
    private Player attracked_player;
    private List<Player> players = new List<Player>();

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, timeout);
        GameObject[] players_gameObject = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players_gameObject.Length; ++i){
            players.Add(players_gameObject[i].GetComponent<Player>());
        }
    }

    // Update is called once per frame
    void Update(){
        checkCollision();
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag.Equals("Player")){
            attractObj = (coll.gameObject);
            attracked_player = coll.gameObject.GetComponent<Player>();
        }
    }

    private void checkCollision() {
        if (attractObj != null && (Vector3.Distance(transform.position, attractObj.transform.position) > distance)){
            attractObj.transform.position = Vector3.MoveTowards(attractObj.transform.position, transform.position, speed * Time.deltaTime);
        }
        else if ((attractObj != null && Vector3.Distance(transform.position, attractObj.transform.position) <= distance)){
            for (int i = 0; i < players.Count; ++i){
                if (players[i] != null && players[i].gameObject.name != attractObj.gameObject.name){
                    startFrom = transform;
                    otherPlayerToSwap = players[i].gameObject;
                    target = otherPlayerToSwap.transform;
                }
            }
            if (target != null && otherPlayerToSwap != null){
                attractObj.transform.position = target.position;
                otherPlayerToSwap.transform.position = startFrom.position;
                Destroy(this.gameObject);
            }
        }
    }
}

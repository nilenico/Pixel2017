using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayersHandler : MonoBehaviour {
    private GameObject[] vPlayers;
    private int count;
    public GameObject timer;

    void Start () {
        PlayerController.OnRemovePlayer += removePlayer;
        vPlayers = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < InputManager.Devices.Count; ++i ) {
            if (vPlayers.Length > i) {
                vPlayers[i].GetComponent<Player>().setPid(i);
            }
            else break;
        }
        count = vPlayers.Length;
    } 

    void removePlayer() {
        count--;
    }

    void Update() {
        if(count <= 1 ){
            win();
        }
    }
    void win() {
        timer.GetComponent<Timer>().Stop();
    }
}
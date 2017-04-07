using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayersHandler : MonoBehaviour {
    private GameObject[] vPlayers;

    void Start () {

        vPlayers = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < InputManager.Devices.Count; ++i ) {
            if (vPlayers.Length > i) {
                vPlayers[i].GetComponent<Player>().setPid(i);
            }
            else break;
        }   
    }
}
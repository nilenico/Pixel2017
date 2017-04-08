using UnityEngine.UI;
using UnityEngine;
using InControl;

public class PlayersHandler : MonoBehaviour {
    private GameObject[] vPlayers;
    private int count;
    public GameObject timer;
    public Image lblWin;
    void Start () {
        //lblWin.enabled = false;
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
            //win();
        }
    }
    void win() {
        lblWin.enabled = true;
        timer.GetComponent<Timer>().Stop();
    }
}
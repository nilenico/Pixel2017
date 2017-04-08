using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void StartNewGame() {
        SceneManager.LoadScene("Game");
    }
	// Update is called once per frame
	void Update () {
		
	}
}

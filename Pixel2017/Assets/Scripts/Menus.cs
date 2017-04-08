using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menus : MonoBehaviour
{
    private GameObject MainCanvas;
    private GameObject ControlsCanvas;

    public GameObject player1Menu;
    public GameObject player2Menu;
    public GameObject player1Controls;
    public GameObject player2Controls;


    void Start()
    {
        MainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        ControlsCanvas = GameObject.FindGameObjectWithTag("ControlsCanvas");
        MainCanvas.GetComponent<Canvas>().enabled = true;
        ControlsCanvas.GetComponent<Canvas>().enabled = false;
        player1Menu.active = true;
        player2Menu.active = true;
        player1Controls.active = false;
        player2Controls.active = false;
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("Game");
    }

    public void ControlsBtn()
    {
        player1Menu.active = false;
        player2Menu.active = false;
        player1Controls.active = true;
        player2Controls.active = true;
        MainCanvas.GetComponent<Canvas>().enabled = false;
        ControlsCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void BackToMainMenu()
    {
        player1Menu.active = true;
        player2Menu.active = true;
        player1Controls.active = false;
        player2Controls.active = false;
        MainCanvas.GetComponent<Canvas>().enabled = true;
        ControlsCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}

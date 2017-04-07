using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menus : MonoBehaviour
{
    private GameObject MainCanvas;
    private GameObject ControlsCanvas;
    private GameObject OptionsCanvas;


    void Start()
    {
        MainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        ControlsCanvas = GameObject.FindGameObjectWithTag("ControlsCanvas");
        OptionsCanvas = GameObject.FindGameObjectWithTag("OptionsCanvas");
        MainCanvas.GetComponent<Canvas>().enabled = true;
        ControlsCanvas.GetComponent<Canvas>().enabled = false;
        OptionsCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("Game");
    }

    public void ControlsBtn()
    {
        MainCanvas.GetComponent<Canvas>().enabled = false;
        ControlsCanvas.GetComponent<Canvas>().enabled = true;
        OptionsCanvas.GetComponent<Canvas>().enabled = false;

    }

    public void OptionsBtn()
    {
        MainCanvas.GetComponent<Canvas>().enabled = false;
        ControlsCanvas.GetComponent<Canvas>().enabled = false;
        OptionsCanvas.GetComponent<Canvas>().enabled = true;

    }

    public void BackToMainMenu()
    {
        MainCanvas.GetComponent<Canvas>().enabled = true;
        ControlsCanvas.GetComponent<Canvas>().enabled = false;
        OptionsCanvas.GetComponent<Canvas>().enabled = false;

    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}

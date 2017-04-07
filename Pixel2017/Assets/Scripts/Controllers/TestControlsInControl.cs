using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class TestControlsInControl : MonoBehaviour
{
    private List<InputDevice> vPlayers;

    void Start()
    {
        //SetupPlayers();
    }


    void Update()
    {
        if (InputManager.Devices[0].Action1.WasPressed)
        {
            Debug.Log("Player 0 pressed Action1");
        }

        if (InputManager.Devices[1].Action1.WasPressed)
        {
            Debug.Log("Player 1 pressed Action1");
        }
    }


    void SetupPlayers()
    {
        Debug.Log("Number of plugged controllers = " + InputManager.Devices.Count);

        foreach (InputDevice input in InputManager.Devices)
        {
            vPlayers.Add(input);
        }

    }
}

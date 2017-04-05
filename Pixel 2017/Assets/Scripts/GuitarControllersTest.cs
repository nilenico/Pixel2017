using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuitarControllersTest : MonoBehaviour
{
    

    void Update()
    {

        //Debug.Log("GSensor1 : " + Input.GetAxis("GSensor1"));
        //Debug.Log("WhamBar1 : " + Input.GetAxis("WhamBar1"));

        if (Input.GetButtonDown("Submit"))
        {
            Debug.Log("Submit is on");
        }
        


    }

}

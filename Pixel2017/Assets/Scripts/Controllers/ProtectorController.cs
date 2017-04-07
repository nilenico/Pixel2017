using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectorController : MonoBehaviour {
    public GameObject AxisX;
    public GameObject AxisY; 

	void Start () {
		
	} 

	void Update () {
        float hauteurX = AxisX.transform.position.y;
       // float hauteurX = AxisX.transform.position.y;

        transform.position = new Vector3(0, 0, 0);
	}
}

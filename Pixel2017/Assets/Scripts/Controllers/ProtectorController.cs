using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectorController : MonoBehaviour {
    public GameObject AxisX;
    public GameObject AxisY; 

	void Start () {
		
	} 

	void Update () {
        if (AxisX == null || AxisY == null)
            Destroy(this.gameObject);
        transform.position = new Vector3(AxisY.transform.position.x, AxisX.transform.position.y, -1);
	}
}

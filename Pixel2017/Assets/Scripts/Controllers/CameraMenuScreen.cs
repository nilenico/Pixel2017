using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuScreen : MonoBehaviour {

    Camera camera;
    float zoom1 = 5.0f;
    float zoom2 = 4.5f;
    float elapsed = 0.0f;
    bool transition = false;
    float duration = 0.5f;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10.0f));


        if (transform.position.x > 1.0f)
        {
            transform.position = new Vector3(1.0f, transform.position.y, -10.0f);
            transition = true;
        }
        else if (transform.position.x < -1.0f)
        {
            transform.position = new Vector3(-1.0f, transform.position.y, -10.0f);
            transition = true;
        }
        else if (transform.position.y > 0.5f)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, -10.0f);
            transition = true;
        }
        else if (transform.position.y < -0.5f)
        {
            transform.position = new Vector3(transform.position.x, -0.5f, -10.0f);
            transition = true;
        }
        else
        {
            transition = false;
            elapsed = 0.0f;
            //if (camera.orthographicSize != zoom1)
            //{
            //    elapsed += Time.deltaTime / duration;
            //    camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, zoom1, elapsed);
            //}
        }

        if (transition)
        {
            elapsed += Time.deltaTime / duration;
            Camera.main.orthographicSize = Mathf.Lerp(zoom1, zoom2, elapsed);
        }
        else
        {
            if (camera.orthographicSize != zoom1)
            {
                elapsed += Time.deltaTime / duration;
                camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, zoom1, elapsed);
            }
        }


        //transform.LookAt(camera.ScreenToWorldPoint(new Vector3(
        //    Input.mousePosition.x,
        //    Input.mousePosition.y,
        //    camera.nearClipPlane)), Vector3.up);
    }
}

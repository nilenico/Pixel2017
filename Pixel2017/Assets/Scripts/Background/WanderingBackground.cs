using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingBackground : MonoBehaviour
{

    public float delai = 3;
    public bool isSpawning = true;
    public static float maximumSpeed;
    public float speed;
    private Object[] vProps;
    
    private int startWait = 5;
    private float spawnAngle;
    private float screenAspect;
    private const float offset = 15;
    private bool propsTimeout = true;
    private float timeout;
    private float startTime;
    private float width;

    void Start() {
        maximumSpeed = speed;
        vProps = Resources.LoadAll("Prefabs/Background");
        screenAspect = Camera.main.orthographicSize * Screen.width / Screen.height;
        startTime = Time.time;
        width = Camera.main.orthographicSize * 2 * Camera.main.aspect / 2;
    }
    void Update() {

        spawnAngle = Random.Range(0, 360);
        if(startTime + startTime <= Time.time) {
            if(propsTimeout) {
                float x;
                float y;
                if(Random.Range(0, 101) % 2 != 0)
                {
                    if(Random.Range(0, 101) % 2 != 0)
                        y = Random.Range(-Camera.main.orthographicSize - 1, -Camera.main.orthographicSize - offset);
                    else
                        y = Random.Range(Camera.main.orthographicSize + 1, Camera.main.orthographicSize + offset);
                    x = Random.Range(-width, width);
                } else {
                    if(Random.Range(0, 101) % 2 != 0)
                        x = Random.Range(-width, -width - offset);
                    else
                        x = Random.Range(width, width + offset);
                    y = Random.Range(Camera.main.orthographicSize, -Camera.main.orthographicSize);
                }


                Vector3 stuffSpawnPosition = new Vector3(x, y, 0);
                Instantiate(vProps[Random.Range(0, vProps.Length)], stuffSpawnPosition, transform.rotation);

                propsTimeout = false;
                timeout = Time.time;
            } else if(timeout + Mathf.Clamp(delai, delai*0.2f, delai*1.2f) <= Time.time) {
                propsTimeout = true;
            }
        }
    }


}

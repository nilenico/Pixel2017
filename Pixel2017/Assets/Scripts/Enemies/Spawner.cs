using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;
    public Vector2 spawnValues;
    private float spawnWait;
    private float spawnMostWait = 10.0f;
    private float spawnLeastWait = 7.0f;
    public int startWait = 1;
    public bool stop;

    int randEnemy;
    private Vector2 spawnPosition;
    private int radius = 25;

    float spawnAngle;

    // Use this for initialization
    void Start () {
        

        StartCoroutine(waitSpawner());
	}
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        spawnAngle = Random.Range(0, 360);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            //do stuff
            randEnemy = Random.Range(0, enemies.Length);

            float xValue = Mathf.Sin(spawnAngle) * radius;
            float yValue = Mathf.Cos(spawnAngle) * radius;
            
            spawnPosition = new Vector2(xValue, yValue);
            Instantiate(enemies[randEnemy], spawnPosition, transform.rotation);

            yield return new WaitForSeconds(spawnWait);

        }
    }
}

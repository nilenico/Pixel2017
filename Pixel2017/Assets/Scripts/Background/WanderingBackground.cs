﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingBackground : MonoBehaviour
{

    public GameObject[] stuff;


    private float stuffSpawnWait;
    private float stuffSpawnMostWait = 20.0f;    
    private float stuffSpawnLeastWait = 5.0f;

    public bool isSpawning = true;
    private int startWait = 5;
    int randStuff;

    private Vector2 stuffSpawnPosition;
    private int stuffOuterRadius = 50;
    
    float spawnAngle;
    
    void Start()
    {
        StartCoroutine(waitStuffSpawner());
    }


    void Update()
    {
        stuffSpawnWait = Random.Range(stuffSpawnLeastWait, stuffSpawnMostWait);
        spawnAngle = Random.Range(0, 360);
    }


    IEnumerator waitStuffSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while(isSpawning)
        {
            randStuff = Random.Range(0, stuff.Length);

            float xValue = Mathf.Sin(spawnAngle) * stuffOuterRadius;
            float yValue = Mathf.Cos(spawnAngle) * stuffOuterRadius;

            stuffSpawnPosition = new Vector2(xValue, yValue);
            Instantiate(stuff[randStuff], stuffSpawnPosition, transform.rotation);

            yield return new WaitForSeconds(stuffSpawnWait);
        }
    }


}
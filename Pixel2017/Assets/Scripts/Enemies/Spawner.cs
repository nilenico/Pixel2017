using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;
    public GameObject powerUps;

    private float enemySpawnWait;
    private float enemySpawnMostWait = 10.0f; //10.0f
    private float enemySpawnLeastWait = 8.0f; // 8.0

    private float powerUpSpawnWait;
    private float powerUpSpawnMostWait = 20.0f;
    private float powerUpSpawnLeastWait = 5.0f;

    private int startWait = 5;
    public bool enemiesStop;
    public bool powerUpsStop;

    int randEnemy;
    int randPowerUp;

    private Vector2 enemySpawnPosition;
    private Vector2 powerUpSpawnPosition;
    private int enemyOuterRadius = 50;
    private float powerUpInnerRadius = 15;

    private float timerSpeed;
    float spawnAngle;

    // Use this for initialization
    void Start () {
        timerSpeed = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().GetSpeed();

        StartCoroutine(waitEnemySpawner());
        StartCoroutine(waitPowerUpSpawner());
	}
	
	// Update is called once per frame
	void Update () {
        powerUpInnerRadius = timerSpeed * Time.deltaTime;
        enemySpawnWait = Random.Range(enemySpawnLeastWait, enemySpawnMostWait);
        powerUpSpawnWait = Random.Range(powerUpSpawnLeastWait, powerUpSpawnMostWait);
        enemySpawnPosition *=
        spawnAngle = Random.Range(0, 360);

    }

    IEnumerator waitEnemySpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!enemiesStop)
        {
            //do stuff
            randEnemy = Random.Range(0, enemies.Length);

            float xValue = Mathf.Sin(spawnAngle) * enemyOuterRadius;
            float yValue = Mathf.Cos(spawnAngle) * enemyOuterRadius;
            
            enemySpawnPosition = new Vector2(xValue, yValue);
            Instantiate(enemies[randEnemy], enemySpawnPosition, transform.rotation);

            yield return new WaitForSeconds(enemySpawnWait);

        }
    }

    IEnumerator waitPowerUpSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!powerUpsStop)
        {
            powerUpSpawnPosition = Random.insideUnitCircle * powerUpInnerRadius;
            Instantiate(powerUps, powerUpSpawnPosition, transform.rotation);

            yield return new WaitForSeconds(powerUpSpawnWait);
        }
    }
}

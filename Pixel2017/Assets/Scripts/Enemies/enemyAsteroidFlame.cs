using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAsteroidFlame : MonoBehaviour
{

    public float movementSpeed = 55.0f;
    public float distanceToPlaySound = 35.0f;
    private float rotateSpeed = 1000.0f; //dont touch else it wont rotate fast enough at start
    private float lifeTime = 20.0f;
    private float distanceToCenter;
    private bool hasPlayed = false;

    private Vector3 normalizedDirection;

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    // Use this for initialization
    void Start()
    {
        normalizedDirection = (Vector3.zero - transform.position).normalized;
        onRotateTowardsCenter(normalizedDirection);
    }

    // Update is called once per frame
    void Update()
    {
        onMove();
        playEnterSound();
    }

    Quaternion FindRotationAngle()
    {
        float angle = Mathf.Atan2(normalizedDirection.y, normalizedDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        return q;
    }

    void onRotateTowardsCenter(Vector2 destinationVector)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, FindRotationAngle(), rotateSpeed);
    }

    void onMove()
    {
        transform.position += normalizedDirection * movementSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            coll.transform.position += normalizedDirection * 30 * Time.deltaTime;
        }
    }

    void playEnterSound()
    {
        distanceToCenter = Vector3.Distance(Vector3.zero, transform.position);
        if (distanceToCenter < distanceToPlaySound && hasPlayed == false)
        {
            GetComponent<AudioSource>().Play();
            hasPlayed = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableProps : MonoBehaviour {
    private Vector3 velocity;
    private float speed;
    private Quaternion lookRotation;

	void Start () {
        speed = Random.Range(0, WanderingBackground.maximumSpeed);
        velocity = new Vector3(0 - transform.position.x, 0 - transform.position.y, 0);

        Vector3 targetDir = Vector3.zero - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 lookRotation = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(lookRotation);

        Destroy(this.gameObject, 20/speed);
    }
	// Update is called once per frame
	void Update () {
        transform.position += velocity * speed * Time.deltaTime;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapsar : Item {

    public GameObject radius;
    private CircleCollider2D radius_coll;
    private List<GameObject> attractObj = new List<GameObject>();
    public int speed;
    public float distance;
    public bool swap_state;
    private Transform target;
    public int initial_timeout;

    // Use this for initialization
    void Start () {
        timeout = initial_timeout;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < attractObj.Count; ++i)
        {
            if (attractObj != null)
            {
                {
                    if (attractObj != null && (Vector3.Distance(transform.position, attractObj[i].transform.position) > distance))
                    {
                        attractObj[i].transform.position = Vector3.MoveTowards(attractObj[i].transform.position, transform.position, speed * Time.deltaTime);
                    }
                    else if ((attractObj != null && Vector3.Distance(transform.position, attractObj[i].transform.position) <= distance) && swap_state)
                    {
                        if (target != null)
                        {
                            attractObj[i].transform.position = target.position;
                        }
                    }

                    if (timeout > 0) { timeout--; }
                    else { Destroy(this.gameObject); }

                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag.Equals("Player")){
            attractObj.Add(coll.gameObject);
        }
    }
}

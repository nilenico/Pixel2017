using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerController
{
    protected GameObject border;
    void Start() {
       this.OnDie += performDie;
    }
        
    void performDie() {
        Destroy(this.gameObject);
    }
}
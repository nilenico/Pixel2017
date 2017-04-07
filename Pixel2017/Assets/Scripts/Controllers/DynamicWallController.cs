using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWallController : DynamicWall {

    private Vector3 velocity;

    /// <summary>
    /// Implement Update hook
    /// </summary>
    void Update() {

        transform.position += velocity;
    }
}

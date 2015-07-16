using UnityEngine;
using System.Collections;

/// <summary>
/// This class handles the triggers of a little collider at the bottom of a GameObject to check if it's touching the floor
/// </summary>
public class FloorContact : MonoBehaviour {

    // Is the container touching the floor?
    [System.NonSerialized]
    public bool isTouching = false;

    void OnTriggerEnter2D(Collider2D collider) {
        isTouching = true;
    }

    void OnTriggerExit2D(Collider2D collider) {
        isTouching = false;
    }
}

using UnityEngine;
using System.Collections;

public class FloorContact : MonoBehaviour {

    public bool isTouching = false;

    void OnTriggerEnter2D(Collider2D collider) {
        isTouching = true;
    }

    void OnTriggerExit2D(Collider2D collider) {
        isTouching = false;
    }
}

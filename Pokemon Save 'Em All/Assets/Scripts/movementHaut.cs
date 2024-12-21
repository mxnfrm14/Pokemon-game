using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementHaut : MonoBehaviour {

    float dirY, moveSpeed = 3f;
    bool moveUp = true;

    // Update is called once per frame
    void Update2 () {
        if (transform.position.y > 4f)
            moveUp = false;
        if (transform.position.y < -4f)
            moveUp = true;

        if (moveUp)
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
    }
}
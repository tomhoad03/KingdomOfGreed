using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int money;
    public float speed = 0.08f;

    private Vector3 currentPos;

    void FixedUpdate() {
        currentPos = this.transform.position;

        // Player movement
        switch (Input.GetKey(KeyCode.W), Input.GetKey(KeyCode.A), Input.GetKey(KeyCode.S), Input.GetKey(KeyCode.D)) {
            case (true, true, false, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (true, false, false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true, true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false, true, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false, false, false):
                currentPos = new Vector3(currentPos.x, currentPos.y + speed, currentPos.z);
                break;
            case (false, true, false, false):
                currentPos = new Vector3(currentPos.x - speed, currentPos.y, currentPos.z);
                break;
            case (false, false, true, false):
                currentPos = new Vector3(currentPos.x, currentPos.y - speed, currentPos.z);
                break;
            case (false, false, false, true):
                currentPos = new Vector3(currentPos.x + speed, currentPos.y, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
}

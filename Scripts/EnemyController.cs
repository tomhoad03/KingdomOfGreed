using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private GameObject player;

    // starting positions
    private float startingX;
    private float startingY;

    public bool patrolling;
    public float interruptTime;

    public float speed = 0.012f; // enemy speed
    public float detectionDistance = 3.0f;
    public float time;

    void Start() {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        
        startingX = this.transform.position.x;
        startingY = this.transform.position.y;
    }

    void FixedUpdate() {

        time = Time.time % 12;
        Vector3 currentPos = this.transform.position;
        Vector3 playerPos = player.transform.position;

        if (Math.Abs(playerPos.x - currentPos.x) < detectionDistance && Math.Abs(playerPos.y - currentPos.y) < detectionDistance) {
            switch (playerPos.x < currentPos.x, playerPos.y < currentPos.y) {
                case (true, true):
                    currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                    break;
                case (true, false):
                    currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                    break;
                case (false, true):
                    currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                    break;
                case (false, false):
                    currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                    break;
            }
            this.transform.position = currentPos;
            patrolling = false;
        } else if (Math.Abs(startingX - currentPos.x) > 0.0f && Math.Abs(startingY - currentPos.y) > 0.0f && !patrolling) {
            this.transform.position = new Vector3(startingX, startingY, currentPos.z);
            interruptTime = Time.time % 12;
        } else {
            float modTime = (Time.time + interruptTime) % 12.0f;
            patrolling = true;

            if (modTime >= 9.0f) {
                this.transform.position = new Vector3(currentPos.x + speed, currentPos.y, currentPos.z);
            } else if (modTime >= 6.0f) {
                this.transform.position = new Vector3(currentPos.x, currentPos.y + speed, currentPos.z);
            } else if (modTime >= 3.0f) {
                this.transform.position = new Vector3(currentPos.x - speed, currentPos.y, currentPos.z);
            } else if (modTime >= 0.0f) {
                this.transform.position = new Vector3(currentPos.x, currentPos.y - speed, currentPos.z);
            }
        }
    }
}

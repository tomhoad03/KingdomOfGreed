using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int money;
    public float speed = 0.08f;

    public int damage = 100;
    public int health = 1000;
    public int maxHealth = 1000;

    public int enemiesKilled = 0;

    public float damageIndicatorTime;
    private float healthRecoveryTime;
    public bool enemyColliding;

    private Vector3 currentPos;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            enemyColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            enemyColliding = false;
        }
    }

    void FixedUpdate() {
        currentPos = this.transform.position;

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

        if (Time.time > damageIndicatorTime) {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (health <= 0) {
            this.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
        if (Time.time > healthRecoveryTime && health < maxHealth) {
            health += 1;
            healthRecoveryTime = Time.time + 0.25f;
        }
    }
}

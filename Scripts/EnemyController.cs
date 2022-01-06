using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private GameObject player;
    private PlayerController playerController;

    private Vector3 playerPos;
    private Vector3 currentPos;
    private bool playerColliding;

    private float speed = 0.0075f;
    private float attackTime;
    public float damageIndicatorTime;

    public int damage = 100;
    public int health = 1000;

    void Start() {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            playerColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            playerColliding = false;
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && playerColliding) {
            health = health - playerController.damage;
            this.GetComponent<SpriteRenderer>().color = Color.red;
            damageIndicatorTime = Time.time + 0.2f;
            
            if (health <= 0) {
                playerController.enemiesKilled += 1;
                playerController.health += 100;
                playerController.money += 50;
                Destroy(gameObject);
            }
        }
        if (Time.time > damageIndicatorTime) {
            this.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        if (Time.time > attackTime && playerController.enemyColliding) {
            playerController.health -= damage;
            playerController.damageIndicatorTime = Time.time + 0.2f;
            player.GetComponent<SpriteRenderer>().color = Color.red;
            attackTime = Time.time + 2.0f;
        }

        currentPos = this.transform.position;
        playerPos = player.transform.position;

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
    }
}

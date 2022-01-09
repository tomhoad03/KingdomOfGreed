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

    public float speed = 0.05f;
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
            damageIndicatorTime = Time.time + 0.2f;

            GameObject sprite = this.transform.GetChild(0).gameObject;
            for (int i = 0; i < sprite.transform.childCount; i++) {
                GameObject spritePart = sprite.transform.GetChild(i).gameObject;
                spritePart.GetComponent<SpriteRenderer>().color = Color.red;
            }
            
            if (health <= 0) {
                playerController.enemiesKilled += 1;
                playerController.health += 100;
                playerController.money += 50;
                Destroy(gameObject);
            }
        }
        if (Time.time > damageIndicatorTime) {
            GameObject sprite = this.transform.GetChild(0).gameObject;
            for (int i = 0; i < sprite.transform.childCount; i++) {
                GameObject spritePart = sprite.transform.GetChild(i).gameObject;
                spritePart.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        if (Time.time > attackTime && playerController.enemyColliding) {
            playerController.takeDamage(damage);
            attackTime = Time.time + UnityEngine.Random.Range(1.2f, 2.0f);
        }
    }

    void FixedUpdate () {
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
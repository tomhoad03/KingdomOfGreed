using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;

    private bool playerColliding;

    private float attackTime;

    public int damage = 25;
    public int health = 1500;

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
            health = health - 100;
            
            if (health <= 0) {
                playerController.firesPutOut++;
                Destroy(gameObject);
            }
        }
        if (Time.time > attackTime && playerColliding) {
            playerController.takeDamage(damage);
            attackTime = Time.time + 1.0f;
        }
    }
}

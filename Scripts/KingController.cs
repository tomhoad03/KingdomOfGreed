using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : MonoBehaviour {
    private GameObject player;
    private PlayerController playerController;
    private bool playerColliding;

    private bool playerOfferMade = false;

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
        if (playerController.questsCompleted == 1 && !playerOfferMade) {
            print("The king offers an invitation to the player.");
            playerOfferMade = true;
        }
    }
}
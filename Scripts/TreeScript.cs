using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {

    private GameObject player;

    private Vector3 treePos;
    private Vector3 playerPos;

    private bool atTree;
    private float chopValue;

    private float treeX;
    private float treeY;
    private float playerX;
    private float playerY;

    void Start() {
        player = GameObject.Find("Player");
        float chopValue = 0;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.name == "Player") {
            treePos = playerPos;
            treeX = treePos.x;
            treeY = treePos.y;
            atTree = true;
        }
    }

    void FixedUpdate() {

        playerPos = player.transform.position;
        playerX = playerPos.x;
        playerY = playerPos.y;

        if ((treeX - playerX < 2 && treeX - playerX > -2) && (treeY - playerY < 2 && treeY - playerY > -2)) {
            atTree = true;
        } else {
            atTree = false;
            player.GetComponent<PlayerController>().chopperUI.SetActive(false);
        }

        // All of these setActives are actually necessary
        if (atTree) {
            
            player.GetComponent<PlayerController>().pressButton.gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.P)) {

                player.GetComponent<PlayerController>().pressButton.gameObject.SetActive(false);
                player.GetComponent<PlayerController>().chopperUI.SetActive(true);
                chopValue += player.GetComponent<PlayerController>().chopSpeed * Time.deltaTime;

                if (chopValue < 100) {
                    player.GetComponent<PlayerController>().chopperSlider.value = (int)chopValue;
                } else {
                    chopValue = 0;
                    player.GetComponent<PlayerController>().chopperUI.SetActive(false);
                    gameObject.SetActive(false);
                    player.GetComponent<PlayerController>().wood += 10;
                    atTree = false;
                }
            } else {
                player.GetComponent<PlayerController>().pressButton.gameObject.SetActive(true);
                chopValue = 0;
                player.GetComponent<PlayerController>().chopperUI.SetActive(false);
            }
        } else {
            player.GetComponent<PlayerController>().pressButton.gameObject.SetActive(false);
        }
    }
}

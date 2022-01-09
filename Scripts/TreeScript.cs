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
    private float UItimer;

    void Start() {
        player = GameObject.Find("Player");
        float chopValue = 0;
        UItimer = 0f;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.name == "Player") {
            Debug.Log("Hit registered");
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

        /** What happened was, the script worked perfect with one tree, and then the 
         *  other trees not having the player near them would have atTree = false and 
         *  it fucked everything the UI timer is now necessary to make the UI work 
         *  near enough perfect I literally cannot think of any other way to do this 
         */

        // All of these setActives are actually necessary
        if (atTree) {
            
            UItimer += Time.deltaTime;
            if (UItimer < 5) {
                player.GetComponent<PlayerController>().pressButton.gameObject.SetActive(true);
                Debug.Log(UItimer);
            } else {
                player.GetComponent<PlayerController>().pressButton.gameObject.SetActive(false);
                player.GetComponent<PlayerController>().chopperUI.SetActive(false);
                UItimer = 0f;
                atTree = false;
            }
     
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
                player.GetComponent<PlayerController>().chopperUI.SetActive(false);
                chopValue = 0;
            }
        } else {
            
        }
    }
}

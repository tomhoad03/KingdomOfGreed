using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour {

    private GameObject player;
    private GameObject shop;
    private ShopManager shopManager;

    private bool atStone;
    private float chopValue;

    private float UItimer;


    void Start() {
        shop = GameObject.Find("ShopMain");
        player = GameObject.Find("Player");
        shopManager = shop.GetComponent<ShopManager>();
        float chopValue = 0;
        UItimer = 0f;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.name == "Player") {
            Debug.Log("Stone hit registered");
            atStone = true;
        }
    }

    void FixedUpdate() {

        /** What happened was, the script worked perfect with one tree, and then the 
         *  other trees not having the player near them would have atTree = false and 
         *  it fucked everything the UI timer is now necessary to make the UI work 
         *  near enough perfect I literally cannot think of any other way to do this 
         */

        // All of these setActives are actually necessary
        if (atStone && shopManager.ownsPickaxe) {

            UItimer += Time.deltaTime;
            if (UItimer < 5) {
                player.GetComponent<PlayerController>().pressButton.gameObject.SetActive(true);
                //Debug.Log(UItimer);
            } else {
                player.GetComponent<PlayerController>().pressButton.gameObject.SetActive(false);
                player.GetComponent<PlayerController>().chopperUI.SetActive(false);
                UItimer = 0f;
                atStone = false;
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
                    player.GetComponent<PlayerController>().stone += 50;
                    player.GetComponent<PlayerController>().stoneMined++;
                    atStone = false;
                }
            } else {
                player.GetComponent<PlayerController>().chopperUI.SetActive(false);
                chopValue = 0;
            }
        } else {

        }
    }
}

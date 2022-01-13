using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBook : MonoBehaviour {

    public GameObject questBook;
    private GameObject player;
    private PlayerController playerController;
    private GameObject shop;
    private ShopManager shopManager;

    // Quests
    public bool collectingResources;
    public bool plantingCrops;
    public bool fishing;
    private bool questOneFinished;
    private bool questTwoFinished;
    private bool questThreeFinished;

    private int treesChopped;
    private int stonesMined;

    // Dialog Text
    public GameObject dialogBox;
    public Text dialogText;

    private float UItimer;

    // NPC fishing quest
    public GameObject npc;
    private NPCMovement npcMovement;

    void Start() {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        shop = GameObject.Find("ShopMain");
        shopManager = shop.GetComponent<ShopManager>();
        UItimer = 0f;
        npcMovement = npc.GetComponent<NPCMovement>();
    }

    public void QuestOne() {
        collectingResources = true;
        dialogBox.SetActive(true);
        dialogText.text = "Chop down some trees and mine some stone. You may need to visit the shop!";
        treesChopped = playerController.treesChoppedDown;
        stonesMined = playerController.stoneMined;
    }

    public void Quest2() {
        plantingCrops = true;
        dialogBox.SetActive(true);
        dialogText.text = "Clear a square area suitable for planting crops";
        treesChopped = playerController.treesChoppedDown;
        stonesMined = playerController.stoneMined;
    }

    public void Quest3() {
        fishing = true;
        dialogBox.SetActive(true);
        dialogText.text = "Purchase a fishing rod and take an npc to the fishing spot";
    }

    void FixedUpdate() {

        if (collectingResources) {
            if ((playerController.treesChoppedDown > treesChopped) && (playerController.stoneMined > stonesMined)) {
                UItimer += Time.deltaTime;
                if (UItimer < 7) {
                    dialogText.text = "You have completed the first quest!";
                } else {
                    questOneFinished = true;
                    UItimer = 0f;
                    dialogBox.SetActive(false);
                    collectingResources = false;
                }
            } 
        }

        if (plantingCrops) {
            if ((playerController.treesChoppedDown > treesChopped + 4) && (playerController.stoneMined > stonesMined + 4)) {
                UItimer += Time.deltaTime;
                if (UItimer < 7) {
                    dialogText.text = "You have completed the second quest!";
                } else {                   
                    questTwoFinished = true;
                    UItimer = 0f;
                    dialogBox.SetActive(false);
                    plantingCrops = false;
                }
            }
        }

        if (fishing) {
            if (shopManager.ownsFishingRod) {
                npc.SetActive(true);
                npcMovement.fishingRoute = true;
                UItimer += Time.deltaTime;
                if (UItimer < 7) {
                    dialogText.text = "Guide the npc to the secret fishing spot. " +
                        "You'll see it North of the town..";
                } else {
                    UItimer = 0f;
                }
                if (playerController.atFishingSpot) {
                    UItimer += Time.deltaTime;
                    if (UItimer < 7) {
                        npcMovement.fishingRoute = false;
                        npcMovement.guestDisplay.SetActive(true);
                        npcMovement.dialogueDisplay.text = "Thank you for your help!";
                        dialogText.text = "You have completed the third quest!";
                    } else {
                        Debug.Log("END OF QUEST");
                        npcMovement.guestDisplay.SetActive(false);
                        npc.SetActive(false);
                        questThreeFinished = true;
                        dialogBox.SetActive(false);
                        fishing = false;
                        playerController.atFishingSpot = false;
                        npcMovement.dialogueDisplay.text = "";
                        npc.transform.position = new Vector3(7, -8, 0);
                        UItimer = 0f;
                    }
                }        
            }         
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            questBook.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            questBook.SetActive(false);
        }
    }
}

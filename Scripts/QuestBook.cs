using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBook : MonoBehaviour {

    public GameObject questBook;
    private GameObject player;

    // Quests
    public bool collectingResources;
    public bool plantingCrops;
    public bool fishing;

    // Dialog Text
    public GameObject dialogBox;
    public Text dialogText;

    void Start() {
        player = GameObject.Find("Player");
    }

    public void QuestOne() {
        collectingResources = true;
        dialogBox.SetActive(true);
        dialogText.text = "Chop down some trees and mine some stone";
    }

    public void Quest2() {
        plantingCrops = true;
        dialogBox.SetActive(true);
        dialogText.text = "Clear a square area suitable for planting crops";
    }

    public void Quest3() {
        fishing = true;
        dialogBox.SetActive(true);
        dialogText.text = "Purchase a fishing rod and take an npc to the fishing spot";
    }

    void FixedUpdate() {

        if (collectingResources) {

        }

        if (plantingCrops) {

        }

        if (fishing) {

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

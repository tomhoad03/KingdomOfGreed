using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCController : MonoBehaviour {
    private GameObject player;
    private PlayerController playerController;

    // NPC dialogue collection
    public TextMeshProUGUI dialogueDisplay;
    public GameObject guestDisplay;
    public Button questButton;

    public string[] questAdvertismentGood = {};
    public string[] questAdvertismentBad = {};
    public string[] questIntro = {};
    public string[] questUnfinishedGood = {};
    public string[] questUnfinishedBad = {};
    public string[] questCompletion = {};
    public string[] questFinishedGood = {};
    public string[] questFinishedBad = {};

    public int questStage = 0;
    public int dialogueCount = 0;
    public bool completionCondition;

    void Start() {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        guestDisplay.SetActive(false);
        questButton.gameObject.SetActive(false);
        questButton.onClick.AddListener(nextDialogue);
    }

    void nextDialogue() {
        dialogueCount++;

        if (questStage == 0) {
            questStage = 1;
            dialogueDisplay.text = questIntro[0];
        } else if (questStage == 1) {
            if (dialogueCount < questIntro.Length) {
                dialogueDisplay.text = questIntro[dialogueCount];
            } else {
                questStage = 2;

                if (playerController.arrivedInTown2 && ((!playerController.helpedTown1 && !playerController.helpedTown2) || playerController.acceptedKingsOffer)) {
                    dialogueDisplay.text = questUnfinishedBad[UnityEngine.Random.Range(0, questUnfinishedBad.Length)];
                } else {
                    dialogueDisplay.text = questUnfinishedGood[UnityEngine.Random.Range(0, questUnfinishedGood.Length)];
                }

                dialogueCount = 0;
                questButton.gameObject.SetActive(completionCondition);
            }
        } else if (questStage == 2 && completionCondition) {
            questStage = 3;
            dialogueDisplay.text = questCompletion[0];
        } else if (questStage == 3) {
            if (dialogueCount < questCompletion.Length) {
                dialogueDisplay.text = questCompletion[dialogueCount];
            } else {
                questStage = 4;

                if (playerController.arrivedInTown2 && ((!playerController.helpedTown1 && !playerController.helpedTown2) || playerController.acceptedKingsOffer)) {
                    dialogueDisplay.text = questFinishedBad[UnityEngine.Random.Range(0, questFinishedBad.Length)];
                } else {
                    dialogueDisplay.text = questFinishedGood[UnityEngine.Random.Range(0, questFinishedGood.Length)];
                }
            
                playerController.money += 200;
                playerController.questsCompleted++;
                questButton.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            switch (questStage) {
                case 0:
                    if (playerController.arrivedInTown2 && ((!playerController.helpedTown1 && !playerController.helpedTown2) || playerController.acceptedKingsOffer)) {
                        dialogueDisplay.text = questAdvertismentBad[UnityEngine.Random.Range(0, questAdvertismentBad.Length)];
                    } else {
                        dialogueDisplay.text = questAdvertismentGood[UnityEngine.Random.Range(0, questAdvertismentGood.Length)];
                    }
                    questButton.gameObject.SetActive(true);
                    break;
                case 1:
                    dialogueDisplay.text = questIntro[dialogueCount];
                    questButton.gameObject.SetActive(true);
                    break;
                case 2:
                    if (playerController.arrivedInTown2 && ((!playerController.helpedTown1 && !playerController.helpedTown2) || playerController.acceptedKingsOffer)) {
                        dialogueDisplay.text = questUnfinishedBad[UnityEngine.Random.Range(0, questUnfinishedBad.Length)];
                    } else {
                        dialogueDisplay.text = questUnfinishedGood[UnityEngine.Random.Range(0, questUnfinishedGood.Length)];
                    }
                    questButton.gameObject.SetActive(completionCondition);
                    break;
                case 3:
                    dialogueDisplay.text = questCompletion[dialogueCount];
                    questButton.gameObject.SetActive(true);
                    break;
                case 4:
                    if (playerController.arrivedInTown2 && ((!playerController.helpedTown1 && !playerController.helpedTown2) || playerController.acceptedKingsOffer)) {
                        dialogueDisplay.text = questFinishedBad[UnityEngine.Random.Range(0, questFinishedBad.Length)];
                    } else {
                        dialogueDisplay.text = questFinishedGood[UnityEngine.Random.Range(0, questFinishedGood.Length)];
                    }
                    break;
            }
            guestDisplay.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            dialogueDisplay.text = "";
            guestDisplay.SetActive(false);
            questButton.gameObject.SetActive(false);
        }
    }
}
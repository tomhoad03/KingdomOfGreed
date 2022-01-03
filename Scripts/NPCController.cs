using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCController : MonoBehaviour {
    private GameObject player;
    private bool playerColliding;

    // NPC dialogue collection
    public TextMeshProUGUI dialogueDisplay;
    public GameObject guestDisplay;
    public Button guestButton;
    private string[] questAdvertisment = {"Can you lend us a hand?", "Please help us!", "Over here!"};
    private string[] questIntro = {"Hello traveller!", "We need your help!"};
    private string[] questUnfinished = {"Have you collected it for us yet?", "Hows that thing you were doing for us going?"};
    private string[] questCompletion = {"Thank you so much!", "Here, take this for you troubles!"};
    private string[] questFinished = {"I hope your having a good day hero!", "We are forever grateful hero!"};
    private int questStage = 0;
    private int dialogueCount = 0;

    void Start() {
        player = GameObject.Find("Player");

        guestDisplay.SetActive(false);
        guestButton.gameObject.SetActive(false);

        guestButton.onClick.AddListener(nextDialogue);
    }

    void nextDialogue() {
        dialogueCount++;

        if (questStage == 1) {
            if (dialogueCount < questIntro.Length) {
                dialogueDisplay.text = questIntro[dialogueCount];
            } else {
                questStage = 2;
                guestButton.gameObject.SetActive(false);
                dialogueDisplay.text = questUnfinished[UnityEngine.Random.Range(0, questUnfinished.Length)];
                dialogueCount = 0;
            }
        } else if (questStage == 3) {
            if (dialogueCount < questCompletion.Length) {
                dialogueDisplay.text = questCompletion[dialogueCount];
            } else {
                questStage = 4;
                guestButton.gameObject.SetActive(false);
                dialogueDisplay.text = questFinished[UnityEngine.Random.Range(0, questFinished.Length)];
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            switch (questStage) {
                case 0:
                    dialogueDisplay.text = questAdvertisment[UnityEngine.Random.Range(0, questAdvertisment.Length)];
                    break;
                case 1:
                    dialogueDisplay.text = questIntro[dialogueCount];
                    guestButton.gameObject.SetActive(true);
                    break;
                case 2:
                    dialogueDisplay.text = questUnfinished[UnityEngine.Random.Range(0, questUnfinished.Length)];
                    break;
                case 3:
                    dialogueDisplay.text = questCompletion[dialogueCount];
                    guestButton.gameObject.SetActive(true);
                    break;
                case 4:
                    dialogueDisplay.text = questFinished[UnityEngine.Random.Range(0, questFinished.Length)];
                    break;
            }
            playerColliding = true;
            guestDisplay.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            dialogueDisplay.text = "";
            playerColliding = false;
            guestDisplay.SetActive(false);
            guestButton.gameObject.SetActive(false);
        }
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.Space) && playerColliding) {
            if (questStage == 0) {
                questStage = 1;
                dialogueDisplay.text = questIntro[0];
                guestButton.gameObject.SetActive(true);
            } else if (questStage == 2 && player.GetComponent<PlayerController>().money > 2000) {
                questStage = 3;
                dialogueDisplay.text = questCompletion[0];
                guestButton.gameObject.SetActive(true);
            }
        }
    }
}
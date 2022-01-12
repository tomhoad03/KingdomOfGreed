using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCController : MonoBehaviour {
    private GameObject player;
    public PlayerController playerController;

    // NPC dialogue collection
    public TextMeshProUGUI dialogueDisplay;
    public GameObject guestDisplay;
    public Button questButton;

    public string[] questIntro = {};
    public string questUnfinished;
    public string[] questCompletion = {};

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

                dialogueDisplay.text = questUnfinished;

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

                if (playerController.kingsOfferQuestRefused) {
                    dialogueDisplay.text = "Thank you for saving our town!";
                } else if (playerController.kingsOfferQuestAccepted) {
                    dialogueDisplay.text = "Why have you forsaken us?";
                } else if (playerController.oldTreeQuestAccepted) {
                    dialogueDisplay.text = "May the old kings protect you.";
                } else if (playerController.oldTreeQuestRefused) {
                    dialogueDisplay.text = "The old kings will never rest whilst you survive.";
                } else if (playerController.burningTownQuestRefused) {
                    dialogueDisplay.text = "Without you we might not have survived!";
                } else if (playerController.burningTownQuestAccepted) {
                    dialogueDisplay.text = "Why have you done this too us?";
                } else if (playerController.introQuestAccepted) {
                    dialogueDisplay.text = "Thanks for the help!";
                } else {
                    dialogueDisplay.text = "Have a good day.";
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
                    if (playerController.kingsOfferQuestRefused) {
                        dialogueDisplay.text = "Does our hero have time to lend a hand?";
                    } else if (playerController.kingsOfferQuestAccepted) {
                        dialogueDisplay.text = "Please ease our suffering.";
                    } else if (playerController.oldTreeQuestAccepted) {
                        dialogueDisplay.text = "I've heard that you might be able to help me.";
                    } else if (playerController.oldTreeQuestRefused) {
                        dialogueDisplay.text = "I really need some help, even from you.";
                    } else if (playerController.burningTownQuestRefused) {
                        dialogueDisplay.text = "Can you spare a moment to help?";
                    } else if (playerController.burningTownQuestAccepted) {
                        dialogueDisplay.text = "I'm desperate for help but I won't pay you.";
                    } else if (playerController.introQuestAccepted) {
                        dialogueDisplay.text = "Hello! I hear you can help me?";
                    } else {
                        dialogueDisplay.text = "Will you help me?";
                    }
                    questButton.gameObject.SetActive(true);
                    break;
                case 1:
                    dialogueDisplay.text = questIntro[dialogueCount];
                    questButton.gameObject.SetActive(true);
                    break;
                case 2:
                    dialogueDisplay.text = questUnfinished;
                    questButton.gameObject.SetActive(completionCondition);
                    break;
                case 3:
                    dialogueDisplay.text = questCompletion[dialogueCount];
                    questButton.gameObject.SetActive(true);
                    break;
                case 4:
                    if (playerController.kingsOfferQuestRefused) {
                        dialogueDisplay.text = "Thank you for saving our town!";
                    } else if (playerController.kingsOfferQuestAccepted) {
                        dialogueDisplay.text = "Why have you forsaken us?";
                    } else if (playerController.oldTreeQuestAccepted) {
                        dialogueDisplay.text = "May the old kings protect you.";
                    } else if (playerController.oldTreeQuestRefused) {
                        dialogueDisplay.text = "The old kings will never rest whilst you survive.";
                    } else if (playerController.burningTownQuestRefused) {
                        dialogueDisplay.text = "Without you we might not have survived!";
                    } else if (playerController.burningTownQuestAccepted) {
                        dialogueDisplay.text = "Why have you done this too us?";
                    } else if (playerController.introQuestAccepted) {
                        dialogueDisplay.text = "Thanks for the help!";
                    } else {
                        dialogueDisplay.text = "Have a good day.";
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
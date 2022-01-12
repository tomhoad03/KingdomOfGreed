using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    private GameObject player;
    private NPCController npcController;
    private PlayerController playerController;
    private bool questGiven = false;
    private bool questCompleted = false;
    private int treesChopped;

    void Start() {
        player = GameObject.Find("Player");
        npcController = this.GetComponent<NPCController>();
        playerController = player.GetComponent<PlayerController>();
    }

    void Update() {
        if ((npcController.questStage == 2) && !questGiven) {
            questGiven = true;
            treesChopped = playerController.treesChoppedDown;
        } else if (questGiven && (playerController.treesChoppedDown >= treesChopped + 5) && !questCompleted) {
            npcController.completionCondition = true;
            npcController.playerController.questsCompleted++;
            playerController.money += 250;
            questCompleted = true;
        }
    }
}
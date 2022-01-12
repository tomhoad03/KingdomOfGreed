using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefController : MonoBehaviour
{
    private GameObject player;
    private NPCController npcController;
    private PlayerController playerController;
    private bool questGiven = false;
    private bool questCompleted = false;
    private int treeCount;

    void Start() {
        player = GameObject.Find("Player");
        npcController = this.GetComponent<NPCController>();
        playerController = player.GetComponent<PlayerController>();
    }

    void Update() {
        if ((npcController.questStage == 2) && !questGiven) {
            questGiven = true;
            treeCount = playerController.treesChoppedDown;
        } else if (questGiven && (playerController.treesChoppedDown >= treeCount + 5) && !questCompleted) {
            npcController.completionCondition = true;
            npcController.playerController.questsCompleted++;
            playerController.chopSpeed += 10;
            questCompleted = true;
        }
    }
}
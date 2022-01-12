using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithController : MonoBehaviour
{
    private GameObject player;
    private NPCController npcController;
    private PlayerController playerController;
    private bool questGiven = false;
    private bool questCompleted = false;
    private int woodCount;
    private int stoneCount;

    void Start() {
        player = GameObject.Find("Player");
        npcController = this.GetComponent<NPCController>();
        playerController = player.GetComponent<PlayerController>();
    }

    void Update() {
        if ((npcController.questStage == 2) && !questGiven) {
            questGiven = true;
            woodCount = playerController.treesChoppedDown;
            stoneCount = playerController.stoneMined;
        } else if (questGiven && (playerController.treesChoppedDown > woodCount + 3) && (playerController.stoneMined > stoneCount + 3) && !questCompleted) {
            npcController.completionCondition = true;
            playerController.questsCompleted++;
            playerController.damage += 20;
            questCompleted = true;
        }
    }
}
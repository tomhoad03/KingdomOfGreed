using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefController : MonoBehaviour
{
    private NPCController npcController;
    private PlayerController playerController;
    private bool questGiven;
    private bool questCompleted;
    private int treeCount;

    void Start() {
        npcController = this.GetComponent<NPCController>();
        playerController = npcController.playerController;
    }

    void Update()
    {
        if (npcController.questStage == 2 && !questGiven) {
            questGiven = true;
            treeCount = playerController.treesChoppedDown;
        } else if (questGiven && (playerController.treesChoppedDown > treeCount + 3) && !questCompleted) {
            npcController.completionCondition = true;
            npcController.playerController.questsCompleted++;
            questCompleted = true;
        }
    }
}

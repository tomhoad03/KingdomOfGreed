using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTamerController : MonoBehaviour
{
    private GameObject player;
    private NPCController npcController;
    private PlayerController playerController;
    private bool questGiven = false;
    private bool questCompleted = false;
    private int enemiesKilled;

    void Start() {
        player = GameObject.Find("Player");
        npcController = this.GetComponent<NPCController>();
        playerController = player.GetComponent<PlayerController>();
    }

    void Update() {
        if ((npcController.questStage == 2) && !questGiven) {
            questGiven = true;
            enemiesKilled = playerController.enemiesKilled;
        } else if (questGiven && (playerController.enemiesKilled >= enemiesKilled) && !questCompleted) {
            npcController.completionCondition = true;
            npcController.playerController.questsCompleted++;
            playerController.money += 250;
            questCompleted = true;
        }
    }
}
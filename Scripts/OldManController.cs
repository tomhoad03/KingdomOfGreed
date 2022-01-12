using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManController : MonoBehaviour
{
    private GameObject player;
    private NPCController npcController;
    private PlayerController playerController;
    private bool questGiven = false;
    private bool questCompleted = false;
    private int enemiesKilled;
    public GameObject ghost;

    void Start() {
        player = GameObject.Find("Player");
        npcController = this.GetComponent<NPCController>();
        playerController = player.GetComponent<PlayerController>();
    }

    void Update() {
        if ((npcController.questStage == 2) && !questGiven) {
            questGiven = true;
            enemiesKilled = playerController.enemiesKilled;

            GameObject enemy1 = Instantiate(ghost, new Vector3(64, (float) -18, 0), Quaternion.identity) as GameObject;
            GameObject enemy2 = Instantiate(ghost, new Vector3(60, (float) -18, 0), Quaternion.identity) as GameObject;
            GameObject enemy3 = Instantiate(ghost, new Vector3(68, (float) -18, 0), Quaternion.identity) as GameObject;
            GameObject enemy4 = Instantiate(ghost, new Vector3(60, (float) -8, 0), Quaternion.identity) as GameObject;
            GameObject enemy5 = Instantiate(ghost, new Vector3(68, (float) -8, 0), Quaternion.identity) as GameObject;

            enemy1.transform.parent = GameObject.Find("Enemies").transform;
            enemy2.transform.parent = GameObject.Find("Enemies").transform;
            enemy3.transform.parent = GameObject.Find("Enemies").transform;
            enemy4.transform.parent = GameObject.Find("Enemies").transform;
            enemy5.transform.parent = GameObject.Find("Enemies").transform;
        } else if (questGiven && (playerController.enemiesKilled > enemiesKilled + 5) && !questCompleted) {
            npcController.completionCondition = true;
            npcController.playerController.questsCompleted++;
            playerController.damageBlockFactor += 2;
            playerController.regenTime -= 0.025f;
            questCompleted = true;
        }
    }
}
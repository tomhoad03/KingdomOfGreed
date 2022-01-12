using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    private GameObject player;
    private NPCController npcController;
    private PlayerController playerController;
    private bool questGiven = false;
    private bool questCompleted = false;
    private int enemiesKilled;
    public GameObject vampire;

    void Start() {
        player = GameObject.Find("Player");
        npcController = this.GetComponent<NPCController>();
        playerController = player.GetComponent<PlayerController>();
    }

    void Update() {
        if ((npcController.questStage == 2) && !questGiven) {
            questGiven = true;
            enemiesKilled = playerController.enemiesKilled;

            GameObject enemy1 = Instantiate(vampire, new Vector3(7, (float) -10, 0), Quaternion.identity) as GameObject;
            GameObject enemy2 = Instantiate(vampire, new Vector3(11, (float) -10, 0), Quaternion.identity) as GameObject;
            GameObject enemy3 = Instantiate(vampire, new Vector3(15, (float) -10, 0), Quaternion.identity) as GameObject;
            GameObject enemy4 = Instantiate(vampire, new Vector3(7, (float) -20, 0), Quaternion.identity) as GameObject;
            GameObject enemy5 = Instantiate(vampire, new Vector3(15, (float) -20, 0), Quaternion.identity) as GameObject;

            enemy1.transform.parent = GameObject.Find("Enemies").transform;
            enemy2.transform.parent = GameObject.Find("Enemies").transform;
            enemy3.transform.parent = GameObject.Find("Enemies").transform;
            enemy4.transform.parent = GameObject.Find("Enemies").transform;
            enemy5.transform.parent = GameObject.Find("Enemies").transform;
        } else if (questGiven && (playerController.enemiesKilled >= enemiesKilled + 5) && !questCompleted) {
            npcController.completionCondition = true;
            npcController.playerController.questsCompleted++;
            playerController.damage += 20;
            playerController.money += 250;
            questCompleted = true;
        }
    }
}
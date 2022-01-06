using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;

    public GameObject enemy;

    private int baseKilled;
    private bool spawnEnemies = false;

    void Start() {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {   
        if (!spawnEnemies && this.GetComponent<NPCController>().questStage == 2) {
            spawnEnemies = true;
            baseKilled = playerController.enemiesKilled;

            GameObject enemy1 = Instantiate(enemy, new Vector3(5, (float) 0, 0), Quaternion.identity) as GameObject;
            GameObject enemy2 = Instantiate(enemy, new Vector3(5, (float) 2, 0), Quaternion.identity) as GameObject;
            GameObject enemy3 = Instantiate(enemy, new Vector3(5, (float) 4, 0), Quaternion.identity) as GameObject;

            enemy1.transform.parent = GameObject.Find("Enemies").transform;
            enemy2.transform.parent = GameObject.Find("Enemies").transform;
            enemy3.transform.parent = GameObject.Find("Enemies").transform;
        }
        if (spawnEnemies && playerController.enemiesKilled >= baseKilled + 3) {
            this.GetComponent<NPCController>().completionCondition = true;
        }
    }
}

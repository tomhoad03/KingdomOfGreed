using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldKingController : MonoBehaviour
{
    void Update()
    {
        if (this.GetComponent<EnemyController>().health < 1000) {
            GameObject.Find("Player").GetComponent<PlayerController>().oldKingDead = true;
            Destroy(gameObject);
        }
    }
}

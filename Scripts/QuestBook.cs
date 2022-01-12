using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBook : MonoBehaviour {

    public GameObject questBook;

    void Start() {

    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            questBook.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            questBook.SetActive(false);
        }
    }

    void FixedUpdate() {
        
    }
}

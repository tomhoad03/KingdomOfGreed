using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private GameObject player;

    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI moneyDisplay;

    void Start() {
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        healthDisplay.text = "Health: " + player.GetComponent<PlayerController>().health;
        moneyDisplay.text = "Money: " + player.GetComponent<PlayerController>().money;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreeNPCController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    private bool playerColliding;

    private bool playerOfferMade = false;
    private bool playerOfferRecieved = false;
    private bool playerOfferAccepted = false;
    private bool playerOfferConsequences = false;

    public TextMeshProUGUI dialogueDisplay;
    public GameObject treeDisplay, goodOption, badOption;
    public Button questButton, goodOptionBtn, badOptionBtn;

    private string[] treeAdvertisment = {"What are you doing on my land!", "Get out of here before I set my dogs on you.", "Guards!"};
    private string[] treeOffer = {"I've been watching you for a while now.", "You've made quite the mess of my land.", "I want to make you a peace offering.", "You can share some of my endless wealth...", "...or I shall order for you to be executed right now.", "What shall it be?"};
    private string[] treeAcceptance = {"You have chosen wisely.", "I burnt that village to the ground to send a message.", "To earn this wealth, you must do so at the sacrifice of others.", "Your actions were noble, but only you deserve such wealth.", "Wait? What is that over there!", "Nooooo, I'm sorry father!"};
    private string[] treeRefusal = {"You are a coward just like my father!", "You show too much compassion for these people.", "It shall be your downfall.", "Guards! Sieze him!"};
    private string[] treeAcceptanceEnd = {"We must protect our gold!", "Please! Save me!", "Father? Is that you?", "Please! Leave me alone!"};
    private string[] treeRefusalEnd = {"How dare you refuse my gold!", "What did the people of this town ever do to you.", "It's your fault the village burnt to the ground!"};

    private int dialogueCount = 0;

    public GameObject enemy;
    public TextMeshProUGUI hintText;
    
    void Start() {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        treeDisplay.SetActive(false);
        questButton.gameObject.SetActive(false);
        questButton.onClick.AddListener(nextDialogue);
        goodOptionBtn.onClick.AddListener(goodChoice); 
        badOptionBtn.onClick.AddListener(badChoice); 
    }

    void nextDialogue() {
        if (!playerOfferRecieved && dialogueCount < treeOffer.Length) {
            dialogueDisplay.text = treeOffer[dialogueCount];
            dialogueCount++;
        } else if (!playerOfferRecieved) {
            goodOption.SetActive(true);
            badOption.SetActive(true);
            questButton.gameObject.SetActive(false);
            dialogueCount = 0;
        } else if (playerOfferRecieved && playerOfferAccepted && dialogueCount < treeAcceptance.Length) {
            goodOption.SetActive(false);
            badOption.SetActive(false);

            dialogueDisplay.text = treeAcceptance[dialogueCount];
            dialogueCount++;
        } else if (playerOfferRecieved && !playerOfferAccepted && dialogueCount < treeRefusal.Length) {
            goodOption.SetActive(false);
            badOption.SetActive(false);

            dialogueDisplay.text = treeRefusal[dialogueCount];
            dialogueCount++;
        } else if (!playerOfferConsequences && playerOfferAccepted) {
            playerOfferConsequences = true;    
            badConsequences();
        } else if (!playerOfferConsequences && !playerOfferAccepted) {
            playerOfferConsequences = true;    
            goodConsequences();
        } else {
            questButton.gameObject.SetActive(false);
        }
    }

    void goodChoice() {
        playerOfferRecieved = true;

        questButton.gameObject.SetActive(true);
    }

    void goodConsequences() {
        hintText.text = "Head north west.";
    }

    void badChoice() {
        playerOfferRecieved = true;
        playerOfferAccepted = true;

        questButton.gameObject.SetActive(true);
    }

    void badConsequences() {
        hintText.text = "Head north east.";
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            playerColliding = true;
            treeDisplay.SetActive(true);

            if (playerOfferRecieved || playerOfferAccepted) {
                dialogueDisplay.text = treeAcceptanceEnd[UnityEngine.Random.Range(0, treeAcceptanceEnd.Length)];
            } else if (playerOfferRecieved) {
                dialogueDisplay.text = treeRefusalEnd[UnityEngine.Random.Range(0, treeRefusalEnd.Length)];
            } else {
                dialogueDisplay.text = treeAdvertisment[UnityEngine.Random.Range(0, treeAdvertisment.Length)];
                questButton.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            playerColliding = false;
            dialogueDisplay.text = "";
            treeDisplay.SetActive(false);
        }
    }
}

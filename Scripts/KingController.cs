using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KingController : MonoBehaviour {
    private GameObject player;
    private PlayerController playerController;
    private bool playerColliding;

    private bool playerOfferMade = false;
    private bool playerOfferRecieved = false;
    private bool playerOfferAccepted = false;
    private bool playerOfferConsequences = false;

    public TextMeshProUGUI dialogueDisplay;
    public GameObject kingDisplay, goodOption, badOption;
    public Button questButton, goodOptionBtn, badOptionBtn;

    private string[] kingAdvertismentNotReady = {"What are you doing on my land!", "Get out of here before I set my dogs on you.", "Guards!"};
    private string[] kingAdvertismentReady = {"I have a proposal for you.", "Will you listen to my offer?"};
    private string[] kingOffer = {"I've been watching you for a while now.", "You've made quite the mess of my land.", "I want to make you a peace offering.", "You can share some of my endless wealth...", "...or I shall order for you to be executed right now.", "What shall it be?"};
    private string[] kingAcceptance = {"You have chosen wisely.", "I burnt that village to the ground to send a message.", "To earn this wealth, you must do so at the sacrifice of others.", "Your actions were noble, but only you deserve such wealth.", "Wait? What is that over there!", "Nooooo, I'm sorry father!"};
    private string[] kingRefusal = {"You are a coward just like my father!", "You show too much compassion for these people.", "It shall be your downfall.", "Guards! Sieze him!"};
    private string[] kingAcceptanceEnd = {"We must protect our gold!", "Please! Save me!", "Father? Is that you?", "Please! Leave me alone!"};
    private string[] kingRefusalEnd = {"How dare you refuse my gold!", "What did the people of this town ever do to you.", "It's your fault the village burnt to the ground!"};

    private int dialogueCount = 0;

    public GameObject goodEnemy;
    public GameObject badEnemy;
    public GameObject oldKing;

    public TextMeshProUGUI hintText;
    public GameObject castleBridge;
    
    void Start() {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        kingDisplay.SetActive(false);
        questButton.gameObject.SetActive(false);
        questButton.onClick.AddListener(nextDialogue);
        goodOptionBtn.onClick.AddListener(goodChoice); 
        badOptionBtn.onClick.AddListener(badChoice); 
    }

    void nextDialogue() {
        if (!playerOfferRecieved && dialogueCount < kingOffer.Length) {
            dialogueDisplay.text = kingOffer[dialogueCount];
            dialogueCount++;
        } else if (!playerOfferRecieved) {
            goodOption.SetActive(true);
            badOption.SetActive(true);
            questButton.gameObject.SetActive(false);
            dialogueCount = 0;
        } else if (playerOfferRecieved && playerOfferAccepted && dialogueCount < kingAcceptance.Length) {
            goodOption.SetActive(false);
            badOption.SetActive(false);

            dialogueDisplay.text = kingAcceptance[dialogueCount];
            dialogueCount++;
        } else if (playerOfferRecieved && !playerOfferAccepted && dialogueCount < kingRefusal.Length) {
            goodOption.SetActive(false);
            badOption.SetActive(false);

            dialogueDisplay.text = kingRefusal[dialogueCount];
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
        GameObject enemy1 = Instantiate(goodEnemy, new Vector3(24, (float) 28, 0), Quaternion.identity) as GameObject;
        GameObject enemy2 = Instantiate(goodEnemy, new Vector3(28, (float) 28, 0), Quaternion.identity) as GameObject;
        GameObject enemy3 = Instantiate(goodEnemy, new Vector3(32, (float) 28, 0), Quaternion.identity) as GameObject;

        enemy1.transform.parent = GameObject.Find("Enemies").transform;
        enemy2.transform.parent = GameObject.Find("Enemies").transform;
        enemy3.transform.parent = GameObject.Find("Enemies").transform;

        hintText.text = "You have chosen to refuse the offer. Defeat the king.";
        playerController.kingsOfferQuestRefused = true;
    }

    void badChoice() {
        playerOfferRecieved = true;
        playerOfferAccepted = true;

        questButton.gameObject.SetActive(true);
    }

    void badConsequences() {
        GameObject enemy1 = Instantiate(badEnemy, new Vector3(24, (float) 28, 0), Quaternion.identity) as GameObject;
        GameObject enemy2 = Instantiate(badEnemy, new Vector3(28, (float) 28, 0), Quaternion.identity) as GameObject;
        GameObject enemy3 = Instantiate(badEnemy, new Vector3(32, (float) 28, 0), Quaternion.identity) as GameObject;

        enemy1.transform.parent = GameObject.Find("Enemies").transform;
        enemy2.transform.parent = GameObject.Find("Enemies").transform;
        enemy3.transform.parent = GameObject.Find("Enemies").transform;

        GameObject king = Instantiate(oldKing, new Vector3(24, (float) 28, 0), Quaternion.identity) as GameObject;
        king.transform.parent = GameObject.Find("Enemies").transform;

        hintText.text = "You have chosen to accept the offer. The forest disapproves.";
        playerController.kingsOfferQuestAccepted = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            playerColliding = true;
            kingDisplay.SetActive(true);

            if (playerOfferRecieved && playerOfferAccepted) {
                dialogueDisplay.text = kingAcceptanceEnd[UnityEngine.Random.Range(0, kingAcceptanceEnd.Length)];
            } else if (playerOfferRecieved) {
                dialogueDisplay.text = kingRefusalEnd[UnityEngine.Random.Range(0, kingRefusalEnd.Length)];
            } else if (playerOfferMade) {
                dialogueDisplay.text = kingAdvertismentReady[UnityEngine.Random.Range(0, kingAdvertismentReady.Length)];
                questButton.gameObject.SetActive(true);
            } else {
                dialogueDisplay.text = kingAdvertismentNotReady[UnityEngine.Random.Range(0, kingAdvertismentNotReady.Length)];
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            playerColliding = false;
            dialogueDisplay.text = "";
            kingDisplay.SetActive(false);
        }
    }

    void Update() {
        if (playerController.questsCompleted == 1 && !playerOfferMade) {
            playerOfferMade = true;
            hintText.text = "The king has made you an offer. Go see him.";
            castleBridge.SetActive(false);
        }
        if (playerOfferAccepted && playerController.oldKingDead) {
            GameObject king = Instantiate(oldKing, new Vector3(24, (float) 28, 0), Quaternion.identity) as GameObject;
            king.transform.parent = GameObject.Find("Enemies").transform;
            playerController.oldKingDead = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroNPCController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    public bool playerColliding;

    private bool playerOfferMade = false;
    private bool playerOfferRecieved = false;
    private bool playerOfferAccepted = false;
    private bool playerOfferConsequences = false;

    public TextMeshProUGUI dialogueDisplay;
    public GameObject introDisplay, goodOption, badOption;
    public Button questButton, goodOptionBtn, badOptionBtn;

    private string[] introAdvertisment = {"Hello?", "Over here!", "Someone help me!"};
    private string[] introOffer = {"Who are you? Where did you come from?", "I thought it was impossible to make it through the forest.", "I could really use your help traveller."};
    private string[] introAcceptance = {"Thank you so much!", "This forest changes people, makes them greedy.", "You'll earn a reward for every enemy you defeat.", "Once you're done, head north west.", "Watch out, they are coming from behind!"};
    private string[] introRefusal = {"Oh, nevermind then.", "I'm sure you'll want to visit the town.", "Just head north east.", "You should find everything you need."};
    private string[] introAcceptanceEnd = {"Thanks for the help!", "Watch your back out there!"};
    private string[] introRefusalEnd = {"I hope you're not here to cause trouble."};

    private int dialogueCount = 0;
    private int baseKilled;
    private bool bridgeOpen;

    public GameObject enemy;
    public TextMeshProUGUI hintText;
    public GameObject leftBridge, rightBridge;
    
    void Start() {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        introDisplay.SetActive(false);
        questButton.gameObject.SetActive(false);
        questButton.onClick.AddListener(nextDialogue);
        goodOptionBtn.onClick.AddListener(goodChoice); 
        badOptionBtn.onClick.AddListener(badChoice); 
    }

    void nextDialogue() {
        if (!playerOfferRecieved && dialogueCount < introOffer.Length) {
            dialogueDisplay.text = introOffer[dialogueCount];
            dialogueCount++;
        } else if (!playerOfferRecieved) {
            goodOption.SetActive(true);
            badOption.SetActive(true);
            questButton.gameObject.SetActive(false);
            dialogueCount = 0;
        } else if (playerOfferRecieved && playerOfferAccepted && dialogueCount < introAcceptance.Length) {
            goodOption.SetActive(false);
            badOption.SetActive(false);

            dialogueDisplay.text = introAcceptance[dialogueCount];
            dialogueCount++;
        } else if (playerOfferRecieved && !playerOfferAccepted && dialogueCount < introRefusal.Length) {
            goodOption.SetActive(false);
            badOption.SetActive(false);

            dialogueDisplay.text = introRefusal[dialogueCount];
            dialogueCount++;
        } else if (!playerOfferConsequences && playerOfferAccepted) {
            playerOfferConsequences = true;    
            goodConsequences();
        } else if (!playerOfferConsequences && !playerOfferAccepted) {
            playerOfferConsequences = true;    
            badConsequences();
        } else {
            questButton.gameObject.SetActive(false);
        }
    }

    void goodChoice() {
        playerOfferRecieved = true;
        playerOfferAccepted = true;

        questButton.gameObject.SetActive(true);
    }

    void goodConsequences() {
        GameObject enemy1 = Instantiate(enemy, new Vector3(24, (float) -56, 0), Quaternion.identity) as GameObject;
        GameObject enemy2 = Instantiate(enemy, new Vector3(28, (float) -56, 0), Quaternion.identity) as GameObject;
        GameObject enemy3 = Instantiate(enemy, new Vector3(32, (float) -56, 0), Quaternion.identity) as GameObject;

        enemy1.transform.parent = GameObject.Find("Enemies").transform;
        enemy2.transform.parent = GameObject.Find("Enemies").transform;
        enemy3.transform.parent = GameObject.Find("Enemies").transform;

        baseKilled = playerController.enemiesKilled;

        hintText.text = "Head north west.";
    }

    void badChoice() {
        playerOfferRecieved = true;

        questButton.gameObject.SetActive(true);
    }

    void badConsequences() {
        rightBridge.SetActive(false);

        hintText.text = "Head north east.";
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            playerColliding = true;
            introDisplay.SetActive(true);

            if (playerOfferRecieved || playerOfferAccepted) {
                dialogueDisplay.text = introAcceptanceEnd[UnityEngine.Random.Range(0, introAcceptanceEnd.Length)];
            } else if (playerOfferRecieved) {
                dialogueDisplay.text = introRefusalEnd[UnityEngine.Random.Range(0, introRefusalEnd.Length)];
            } else {
                dialogueDisplay.text = introAdvertisment[UnityEngine.Random.Range(0, introAdvertisment.Length)];
                questButton.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            playerColliding = false;
            dialogueDisplay.text = "";
            introDisplay.SetActive(false);
        }
    }

    void Update() {
        if (!bridgeOpen && playerController.enemiesKilled >= baseKilled + 3) {
            leftBridge.SetActive(false);
        }
    }
}

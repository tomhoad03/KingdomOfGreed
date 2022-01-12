using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FireNPCController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    private bool playerColliding;

    private bool playerOfferMade = false;
    private bool playerOfferRecieved = false;
    private bool playerOfferAccepted = false;
    private bool playerOfferConsequences = false;

    public TextMeshProUGUI dialogueDisplay;
    public GameObject fireDisplay, goodOption, badOption;
    public Button questButton, goodOptionBtn, badOptionBtn;

    private string[] fireAdvertisment = {"What are you doing over there?", "The king disapproves of your medelling."};
    private string[] fireOffer = {"These people don't deserve anything.", "Why are you helping them?", "Around here I collect taxes.", "Hand over all your money to me right now."};
    private string[] fireAcceptance = {"Good. You're just another villager of this town.", "This is my gold...", "...I mean it's the kings gold.", "It's a good thing your around.", "We've had a few problems with rebelellious folks lately.", "I've got to deliver these coins to the king now.", "Would you mind cleaning up?"};
    private string[] fireRefusal = {"The king warned me you wouldn't go quitely.", "No worries, I can have a contingency plan.", "Watch your work be undone by FIRE!!!"};
    private string[] fireAcceptanceEnd = {"This king protects this town.", "Your money will go a long way."};
    private string[] fireRefusalEnd = {"This town burns because of you.", "Have you come to pay me your taxes now?"};

    private int dialogueCount = 0;

    public TextMeshProUGUI hintText;
    public GameObject midBridge, rightBridge;
    public GameObject rebelEnemy, fire;
    
    void Start() {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        fireDisplay.SetActive(false);
        questButton.gameObject.SetActive(false);
        questButton.onClick.AddListener(nextDialogue);
        goodOptionBtn.onClick.AddListener(goodChoice); 
        badOptionBtn.onClick.AddListener(badChoice); 
    }

    void nextDialogue() {
        if (!playerOfferRecieved && dialogueCount < fireOffer.Length) {
            dialogueDisplay.text = fireOffer[dialogueCount];
            dialogueCount++;
        } else if (!playerOfferRecieved) {
            goodOption.SetActive(true);
            badOption.SetActive(true);
            questButton.gameObject.SetActive(false);
            dialogueCount = 0;
        } else if (playerOfferRecieved && playerOfferAccepted && dialogueCount < fireAcceptance.Length) {
            goodOption.SetActive(false);
            badOption.SetActive(false);

            dialogueDisplay.text = fireAcceptance[dialogueCount];
            dialogueCount++;
        } else if (playerOfferRecieved && !playerOfferAccepted && dialogueCount < fireRefusal.Length) {
            goodOption.SetActive(false);
            badOption.SetActive(false);

            dialogueDisplay.text = fireRefusal[dialogueCount];
            dialogueCount++;
        } else if (!playerOfferConsequences && playerOfferAccepted) {
            playerOfferConsequences = true;    
            badConsequences();
        } else if (!playerOfferConsequences && !playerOfferAccepted) {
            playerOfferConsequences = true;    
            goodConsequences();
        } else {
            midBridge.SetActive(false);
            rightBridge.SetActive(false);
            questButton.gameObject.SetActive(false);
        }
    }

    void goodChoice() {
        playerOfferRecieved = true;
        playerOfferAccepted = true;
        
        questButton.gameObject.SetActive(true);
    }

    void goodConsequences() {
        hintText.text = "Head east to the second town.";

        GameObject fire1 = Instantiate(fire, new Vector3(0, (float) 0, 0), Quaternion.identity) as GameObject;
        GameObject fire2 = Instantiate(fire, new Vector3(6, (float) 0, 0), Quaternion.identity) as GameObject;
        GameObject fire3 = Instantiate(fire, new Vector3(0, (float) -5, 0), Quaternion.identity) as GameObject;
        GameObject fire4 = Instantiate(fire, new Vector3(6, (float) -5, 0), Quaternion.identity) as GameObject;
        GameObject fire5 = Instantiate(fire, new Vector3(0, (float) -10, 0), Quaternion.identity) as GameObject;
        GameObject fire6 = Instantiate(fire, new Vector3(6, (float) -10, 0), Quaternion.identity) as GameObject;

        fire1.transform.parent = GameObject.Find("Fires").transform;
        fire2.transform.parent = GameObject.Find("Fires").transform;
        fire3.transform.parent = GameObject.Find("Fires").transform;
        fire4.transform.parent = GameObject.Find("Fires").transform;
        fire5.transform.parent = GameObject.Find("Fires").transform;
        fire6.transform.parent = GameObject.Find("Fires").transform;

        hintText.text = "Put out the fire. Head east to the second village.";
        playerController.burningTownQuestRefused = true;
    }

    void badChoice() {
        playerOfferRecieved = true;

        questButton.gameObject.SetActive(true);
    }

    void badConsequences() {
        playerController.money = 100;

        GameObject enemy1 = Instantiate(rebelEnemy, new Vector3(0, (float) 0, 0), Quaternion.identity) as GameObject;
        GameObject enemy2 = Instantiate(rebelEnemy, new Vector3(-4, (float) 0, 0), Quaternion.identity) as GameObject;
        GameObject enemy3 = Instantiate(rebelEnemy, new Vector3(4, (float) 0, 0), Quaternion.identity) as GameObject;

        enemy1.transform.parent = GameObject.Find("Enemies").transform;
        enemy2.transform.parent = GameObject.Find("Enemies").transform;
        enemy3.transform.parent = GameObject.Find("Enemies").transform;

        hintText.text = "Defeat the angry villagers. Head east to the second village.";
        playerController.burningTownQuestAccepted = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            playerColliding = true;
            fireDisplay.SetActive(true);

            if (playerOfferRecieved && playerOfferAccepted) {
                dialogueDisplay.text = fireAcceptanceEnd[UnityEngine.Random.Range(0, fireAcceptanceEnd.Length)];
            } else if (playerOfferRecieved) {
                dialogueDisplay.text = fireRefusalEnd[UnityEngine.Random.Range(0, fireRefusalEnd.Length)];
            } else {
                dialogueDisplay.text = fireAdvertisment[UnityEngine.Random.Range(0, fireAdvertisment.Length)];
                questButton.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            playerColliding = false;
            dialogueDisplay.text = "";
            fireDisplay.SetActive(false);
        }
    }
}

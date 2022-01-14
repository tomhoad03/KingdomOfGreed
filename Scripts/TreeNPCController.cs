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

    private string[] treeAdvertisment = {"Come speak to me.", "Do you want to know more about this place?"};
    private string[] treeOffer = {"This tree is very important to our people.", "Those that can see through the greed remember it.", "Our old king was buried here, murdered by his own son.", "The king is a greedy coward who only wanted power.", "This tree grew here and so did the forest around our town.", "Now none of us can leave.", "You must protect this tree from the king.", "If it falls I fear the kings greed may consume us all."};
    private string[] treeAcceptance = {"Defend this tree with your life!"};
    private string[] treeRefusal = {"You have forsaken this town.", "The forest will punish you for your greed."};
    private string[] treeAcceptanceEnd = {"Remember what the king has done to this town."};
    private string[] treeRefusalEnd = {"This tree was sacred to us."};

    private int dialogueCount = 0;

    public GameObject knight, king;
    public TextMeshProUGUI hintText;
    public GameObject castleBridge, midBridge, leftBridge;
    
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
            goodConsequences();
        } else if (!playerOfferConsequences && !playerOfferAccepted) {
            playerOfferConsequences = true;    
            badConsequences();
        } else {
            midBridge.SetActive(false);
            leftBridge.SetActive(false);
            questButton.gameObject.SetActive(false);
        }
    }

    void goodChoice() {
        playerOfferRecieved = true;
        playerOfferAccepted = true;

        questButton.gameObject.SetActive(true);
    }

    void goodConsequences() {
        GameObject enemy1 = Instantiate(knight, new Vector3(48, (float) -15, 0), Quaternion.identity) as GameObject;
        GameObject enemy2 = Instantiate(knight, new Vector3(52, (float) -15, 0), Quaternion.identity) as GameObject;
        GameObject enemy3 = Instantiate(knight, new Vector3(56, (float) -15, 0), Quaternion.identity) as GameObject;

        enemy1.transform.parent = GameObject.Find("Enemies").transform;
        enemy2.transform.parent = GameObject.Find("Enemies").transform;
        enemy3.transform.parent = GameObject.Find("Enemies").transform;

        castleBridge.SetActive(false);

        hintText.text = "Defend the tree from the king.";
        playerController.oldTreeQuestAccepted = true;
    }

    void badChoice() {
        playerOfferRecieved = true;

        questButton.gameObject.SetActive(true);
    }

    void badConsequences() {
        GameObject oldKing = Instantiate(king, new Vector3(52, (float) -15, 0), Quaternion.identity) as GameObject;
        oldKing.transform.parent = GameObject.Find("Enemies").transform;

        castleBridge.SetActive(false);

        hintText.text = "Defeat the ghost of the old king.";
        playerController.oldTreeQuestRefused = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            playerColliding = true;
            treeDisplay.SetActive(true);

            if (playerOfferRecieved && playerOfferAccepted) {
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

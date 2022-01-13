using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCMovement : MonoBehaviour {

    private GameObject shop;
    private ShopManager shopManager;
    private GameObject quests;
    private QuestBook questBook;
    private GameObject player;

    // NPC dialogue collection
    public TextMeshProUGUI dialogueDisplay;
    public GameObject guestDisplay;

    public GameObject fishingArea;

    private Vector3 playerPos;
    private Vector3 currentPos;
    public float speed = 0.05f;

    public bool fishingRoute;
    public bool atFishingArea;


    void Start() {
        player = GameObject.Find("Player");
        shop = GameObject.Find("shopMain");
        shopManager = shop.GetComponent<ShopManager>();
    }

    public void FishingRoute() {
        Debug.Log("Fishing route");
        fishingRoute = true;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.name == "Fishing area") {
            Debug.Log("At fishing area");
        }
    }

    void FixedUpdate() {

        if (fishingRoute) {
            currentPos = this.transform.position;
            playerPos = player.transform.position;

            switch (playerPos.x < currentPos.x, playerPos.y < currentPos.y) {
                case (true, true):
                    currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                    break;
                case (true, false):
                    currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                    break;
                case (false, true):
                    currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                    break;
                case (false, false):
                    currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                    break;
            }
            this.transform.position = currentPos;
        }       
    }
}

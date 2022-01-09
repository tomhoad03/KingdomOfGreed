using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour {
    
    public float speed = 0.018f;

    public int damage = 100;
    public int health = 1000;
    public int maxHealth = 1000;

    public int enemiesKilled = 0;
    public int firesPutOut = 0;
    public int housesBought = 0;
    public int materialsCollected = 0;
    public int questsCompleted;

    public bool arrivedInTown1 = false; // the player has arrived in town 1
    public bool helpedTown1 = false; // the player choose to help town 1
    public bool arrivedInTown2 = false; // the player has arrived in town 2
    public bool helpedTown2 = false; // the player choose to help town 2
    public bool acceptedKingsOffer = false; // does the player accept the kings offer

    public float damageIndicatorTime;
    private float healthRecoveryTime;
    public bool enemyColliding;
    public bool fireColliding;
    public bool oldKingDead;

    public GameObject fire;
    private bool startedTown1Fire = false;
    private float burnTown1Time = 5.0f;

    private Vector3 currentPos;

    public GameObject sword;
    public GameObject shield;
    public GameObject swordSwipe;
    private float attackTime;
    private float angle;
    private bool shieldUp;

    // Player materials
    public int money;
    public int wood;
    public int stone;
    public int chopSpeed;

    // UI game objects
    public Slider playerHealthSlider;
    public GameObject chopperUI;
    public Slider chopperSlider;
    public Text pressButton; // Above player text 
    public Text woodText;
    public Text stoneText;
    public Text moneyText;
    public TextMeshProUGUI hintText;

    void Start() {
        chopperUI.SetActive(false);
        chopSpeed = 50;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            enemyColliding = true;
        } else if (other.gameObject.tag == "Fire") {
            fireColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            enemyColliding = false;
        } else if (other.gameObject.tag == "Fire") {
            fireColliding = true;
        }
    }

    void Update() {

        // UI
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        moneyText.text = money.ToString();

        playerHealthSlider.value = health;
         
        // Player movement
        currentPos = this.transform.position;
        switch (Input.GetKey(KeyCode.W), Input.GetKey(KeyCode.A), Input.GetKey(KeyCode.S), Input.GetKey(KeyCode.D)) {
            case (true, true, false, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (true, false, false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true, true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false, true, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false, false, false):
                currentPos = new Vector3(currentPos.x, currentPos.y + speed, currentPos.z);
                break;
            case (false, true, false, false):
                currentPos = new Vector3(currentPos.x - speed, currentPos.y, currentPos.z);
                break;
            case (false, false, true, false):
                currentPos = new Vector3(currentPos.x, currentPos.y - speed, currentPos.z);
                break;
            case (false, false, false, true):
                currentPos = new Vector3(currentPos.x + speed, currentPos.y, currentPos.z);
                break;
        }
        this.transform.position = currentPos;

        // Damage indication, death and recovery
        if (Time.time > damageIndicatorTime) {
            GameObject sprite = this.transform.GetChild(0).gameObject;
            for (int i = 0; i < sprite.transform.childCount; i++) {
                GameObject spritePart = sprite.transform.GetChild(i).gameObject;
                spritePart.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        if (health <= 0) {
            GameObject sprite = this.transform.GetChild(0).gameObject;
            for (int i = 0; i < sprite.transform.childCount; i++) {
                GameObject spritePart = sprite.transform.GetChild(i).gameObject;
                spritePart.GetComponent<SpriteRenderer>().color = Color.magenta;
            }
        }
        if (Time.time > healthRecoveryTime && health < maxHealth) {
            health += 1;
            healthRecoveryTime = Time.time + 0.1f;
        }
        if (Input.GetMouseButtonDown(0) && Time.time > attackTime && !shieldUp) {
            if (angle > 90 || angle < -90) {
                sword.transform.rotation = Quaternion.Euler(0, 180, 50);
            } else {
                sword.transform.rotation = Quaternion.Euler(0, 0, 50);
            }
            
            swordSwipe.GetComponent<AudioSource>().Play(0);
            attackTime = Time.time + 0.2f;
        } else if (Time.time > attackTime) {
            if (angle > 90 || angle < -90) {
                sword.transform.rotation = Quaternion.Euler(0, 180, 32);
            } else {
                sword.transform.rotation = Quaternion.Euler(0, 0, 32);
            }
        }
        if (Input.GetMouseButton(1)) {
            shieldUp = true;
            shield.SetActive(true);
        } else {
            shieldUp = false;
            shield.SetActive(false);
        }

        // Direction facing
        Vector2 screenPos = Camera.main.WorldToViewportPoint(this.transform.position);
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        angle = Mathf.Atan2(screenPos.y - mousePos.y, screenPos.x - mousePos.x) * Mathf.Rad2Deg;

        if (angle > 90 || angle < -90) {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        } else {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        /*
        // Town 1 fire
        if (Time.time > burnTown1Time && !startedTown1Fire) {
            GameObject fire1 = Instantiate(fire, new Vector3(-26.5f, (float) 0, -1), Quaternion.identity) as GameObject;
            GameObject fire2 = Instantiate(fire, new Vector3(-26.5f, (float) 7, -1), Quaternion.identity) as GameObject;

            fire1.transform.parent = GameObject.Find("Fire").transform;
            fire2.transform.parent = GameObject.Find("Fire").transform;

            startedTown1Fire = true;
        }
        if (startedTown1Fire && firesPutOut > 5 && !arrivedInTown2) {
            helpedTown1 = true;
        }
        */
    }

    public void takeDamage(int damageRecieved) {
        if (shieldUp) {
            health -= damageRecieved / 10;
        } else {
            health -= damageRecieved;
        }

        GameObject sprite = this.transform.GetChild(0).gameObject;
        for (int i = 0; i < sprite.transform.childCount; i++) {
            GameObject spritePart = sprite.transform.GetChild(i).gameObject;
            spritePart.GetComponent<SpriteRenderer>().color = Color.red;
        }
        damageIndicatorTime = Time.time + 0.2f;
    }
}

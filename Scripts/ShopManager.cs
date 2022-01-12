using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    private GameObject player;
    private PlayerController playerController;

    public int playerMoney;
    public int playerWood;
    public int playerStone;
    public GameObject shop;
    public GameObject cannotAfford;
    public GameObject canAfford;
    public GameObject alreadyOwn;
    public Text moneyText;
    public Text woodText;
    public Text stoneText;

    public bool ownsHouse0;
    public bool ownsHouse1;
    public bool ownsHouse2;
    public bool ownsHouse3;

    public bool ownsAxe;
    public bool ownsPickaxe;
    public bool ownsFishingRod;

    private bool armour1;
    private bool armour2;
    private bool armour3;

    void Start() {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        shop.SetActive(false);
        ownsHouse0 = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            shop.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            shop.SetActive(false);
        }
    }

    void FixedUpdate() {
        playerMoney = playerController.money;
        playerWood = playerController.wood;
        playerStone = playerController.stone;
        moneyText.text = playerMoney.ToString();
        woodText.text = playerWood.ToString();
        stoneText.text = playerStone.ToString();
    }

    private bool CanAffordMoney(int playerCash, int money) {
        if (playerCash >= money) {
            playerController.money -= money;
            return true;
        } else {
            return false;
        }
    }

    private bool CanAffordStone(int playerStone, int stone) {
        if (playerStone >= stone) {
            playerController.stone -= stone;
            return true;
        } else {
            return false;
        }
    }

    private bool CanAffordWood(int playerWood, int wood) {
        if (playerWood >= wood) {
            playerController.wood -= wood;
            return true;
        } else {
            return false;
        }
    }

    // House purchases
    public void HousePurchaseOne() {
        Debug.Log("House 1");
        if (CanAffordWood(playerController.wood, 1000)) {
            canAfford.SetActive(true);
            ownsHouse1 = true;
            ownsHouse0 = false;
            ownsHouse2 = false;
            ownsHouse3 = false;
            playerController.housesBought++;
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void HousePurchaseTwo() {
        Debug.Log("House 2");
        if (CanAffordWood(playerController.wood, 300) && CanAffordStone(playerController.stone, 700)) {
            canAfford.SetActive(true);
            ownsHouse0 = false;
            ownsHouse2 = true;
            ownsHouse1 = false;
            ownsHouse3 = false;
            playerController.housesBought++;
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void HousePurchaseThree() {
        Debug.Log("House 3");
        if (CanAffordWood(playerController.wood, 800) && CanAffordStone(playerController.stone, 800)) {
            canAfford.SetActive(true);
            ownsHouse0 = false;
            ownsHouse1 = false;
            ownsHouse3 = true;
            ownsHouse2 = false;
            playerController.housesBought++;
        } else {
            cannotAfford.SetActive(true);
        }
    }

    // Armour purchases
    public void ArmourPurchaseOne() {
        Debug.Log("Armour 1");
        if (CanAffordMoney(playerController.money, 500)) {
            if (!armour1) {
                playerController.maxHealth += 500;
                playerController.speed += 0.025f;
                canAfford.SetActive(true);
                armour1 = true;
            } else {
                playerController.money += 500;
                alreadyOwn.SetActive(true);
            }       
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void ArmourPurchaseTwo() {
        Debug.Log("Armour 2");
        if (CanAffordMoney(playerController.money, 500)) {
            if (!armour2) {
                playerController.maxHealth += 500;
                playerController.speed += 0.025f;
                canAfford.SetActive(true);
                armour2 = true;
            } else {
                playerController.money += 500;
                alreadyOwn.SetActive(true);
            }
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void ArmourPurchaseThree() {
        Debug.Log("Armour 3");
        if (CanAffordMoney(playerController.money, 500)) {
            if (!armour3) {
                playerController.maxHealth += 500;
                playerController.speed += 0.025f;
                canAfford.SetActive(true);
                armour3 = true;
            } else {
                playerController.money += 500;
                alreadyOwn.SetActive(true);
            }
        } else {
            cannotAfford.SetActive(true);
        }
    }

    // Weapon purchases
    public void WeaponPurchaseOne() {
        if (CanAffordMoney(playerController.money, 200)) {
            if (!ownsAxe) {
                playerController.chopSpeed *= 2;
                playerController.damage += 100;
                canAfford.SetActive(true);
                ownsAxe = true;
            } else {
                playerController.money += 200;
                alreadyOwn.SetActive(true);
            }
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void WeaponPurchaseTwo() {
        if (CanAffordMoney(playerController.money, 200)) {
            if (!ownsPickaxe) {
                playerController.damage += 100;
                canAfford.SetActive(true);
                ownsPickaxe = true;
            } else {
                playerController.money += 200;
                alreadyOwn.SetActive(true);
            }
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void WeaponPurchaseThree() {
        if (CanAffordMoney(playerController.money, 200)) {
            if (!ownsFishingRod) {
                playerController.damage += 100;
                canAfford.SetActive(true);
                ownsFishingRod = true;
            } else {
                playerController.money += 200;
                alreadyOwn.SetActive(true);
            }          
        } else {
            cannotAfford.SetActive(true);
        }
    }

    // Material purchases
    public void MaterialPurchaseOne() {
        if (CanAffordWood(playerController.wood, 100)) {
            canAfford.SetActive(true);
            playerController.money += 100;
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void MaterialPurchaseTwo() {
        if (CanAffordStone(playerController.stone, 100)) {
            canAfford.SetActive(true);
            playerController.money += 100;
        } else {
            cannotAfford.SetActive(true);
        }
    }

        public void MaterialPurchaseThree() {
        if (CanAffordMoney(playerController.money, 100)) {
            canAfford.SetActive(true);
            playerController.maxHealth += 100;
        } else {
            cannotAfford.SetActive(true);
        }
    }
}

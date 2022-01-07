using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {
    private GameObject player;
    private PlayerController playerController;

    public int playerMoney;
    public GameObject shop;
    public GameObject cannotAfford;
    public GameObject canAfford;
    public Text moneyText;

    void Start() {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        shop.SetActive(false);
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
        moneyText.text = playerMoney.ToString();
    }

    private bool CanAfford(int playerCash, int price) {
        if (playerCash >= price) {
            playerController.money -= price;
            return true;
        } else {
            return false;
        }
    }

    // House purchases
    public void HousePurchaseOne() {
        if (CanAfford(playerController.money, 1000)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void HousePurchaseTwo() {
        if (CanAfford(playerController.money, 1000)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void HousePurchaseThree() {
        if (CanAfford(playerController.money, 1000)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    // Armour purchases
    public void ArmourPurchaseOne() {
        if (CanAfford(playerController.money, 500)) {
            playerController.maxHealth += 500;
            playerController.speed += 0.002f;
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void ArmourPurchaseTwo() {
        if (CanAfford(playerController.money, 500)) {
            playerController.maxHealth += 500;
            playerController.speed += 0.002f;
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void ArmourPurchaseThree() {
        if (CanAfford(playerController.money, 500)) {
            playerController.maxHealth += 500;
            playerController.speed += 0.002f;
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    // Weapon purchases
    public void WeaponPurchaseOne() {
        if (CanAfford(playerController.money, 200)) {
            playerController.damage = 200;
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void WeaponPurchaseTwo() {
        if (CanAfford(playerController.money, 400)) {
            playerController.damage = 300;
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void WeaponPurchaseThree() {
        if (CanAfford(playerController.money, 600)) {
            playerController.damage = 400;
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    // Material purchases
    public void MaterialPurchaseOne() {
        if (CanAfford(playerController.money, 100)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void MaterialPurchaseTwo() {
        if (CanAfford(playerController.money, 100)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void MaterialPurchaseThree() {
        if (CanAfford(playerController.money, 100)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }
}

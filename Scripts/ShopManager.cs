using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public int playerMoney;
    GameObject player;
    public GameObject shop;
    public GameObject cannotAfford;
    public GameObject canAfford;
    public Text moneyText;

    void Start() {

        player = GameObject.Find("Player");
        shop.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            shop.SetActive(true);
            Debug.Log("Player is at shop");
            //Debug.Log("Money : " + playerMoney);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            shop.SetActive(false);
            Debug.Log("Player has left the shop");
            //Debug.Log("Money : " + playerMoney);
        }
    }

    void FixedUpdate() {
        playerMoney = player.GetComponent<PlayerController>().money;
        moneyText.text = playerMoney.ToString();
    }

    private bool CanAfford(int playerCash, int price) {
        if (playerCash >= price) {
            player.GetComponent<PlayerController>().money -= price;
            return true;
        } else {
            return false;
        }
    }

    // House purchases
    public void HousePurchaseOne() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 1000)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void HousePurchaseTwo() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 1000)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void HousePurchaseThree() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 1000)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    // Armour purchases
    public void ArmourPurchaseOne() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 500)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void ArmourPurchaseTwo() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 500)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void ArmourPurchaseThree() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 500)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    // Weapon purchases
    public void WeaponPurchaseOne() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 200)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void WeaponPurchaseTwo() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 200)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void WeaponPurchaseThree() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 200)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    // Material purchases
    public void MaterialPurchaseOne() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 100)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void MaterialPurchaseTwo() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 100)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }

    public void MaterialPurchaseThree() {

        if (CanAfford(player.GetComponent<PlayerController>().money, 100)) {
            canAfford.SetActive(true);
        } else {
            cannotAfford.SetActive(true);
        }
    }
}

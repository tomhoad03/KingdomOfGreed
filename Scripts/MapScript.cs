using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour {

    // Shop
    private GameObject shop;

    // Start House
    public GameObject house0_0;

    // First Houses
    public GameObject house1_0;
    public GameObject house1_1;
    public GameObject house1_2;

    // Second Houses
    public GameObject house2_0;
    public GameObject house2_1;
    public GameObject house2_2;

    // Third Houses
    public GameObject house3_0;
    public GameObject house3_1;
    public GameObject house3_2;
    public GameObject house3_3;
    public GameObject house3_4;


    void Start() {
        shop = GameObject.Find("ShopMain");
    }


    void FixedUpdate() {

        if (shop.GetComponent<ShopManager>().ownsHouse0) {
            house0_0.SetActive(true);
        } else {
            house0_0.SetActive(false);
        }
        if (shop.GetComponent<ShopManager>().ownsHouse1) {
            house1_0.SetActive(true);
            house1_1.SetActive(true);
            house1_2.SetActive(true);
        } else {
            house1_0.SetActive(false);
            house1_1.SetActive(false);
            house1_2.SetActive(false);
        }
        if (shop.GetComponent<ShopManager>().ownsHouse2) {
            house2_0.SetActive(true);
            house2_1.SetActive(true);
            house2_2.SetActive(true);
        } else {
            house2_0.SetActive(false);
            house2_1.SetActive(false);
            house2_2.SetActive(false);
        }
        if (shop.GetComponent<ShopManager>().ownsHouse3) {
            house3_0.SetActive(true);
            house3_1.SetActive(true);
            house3_2.SetActive(true);
            house3_3.SetActive(true);
            house3_4.SetActive(true);
        } else {
            house3_0.SetActive(false);
            house3_1.SetActive(false);
            house3_2.SetActive(false);
            house3_3.SetActive(false);
            house3_4.SetActive(false);
        }
    }
}
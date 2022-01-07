using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour {

    // Shop
    private GameObject shop;

    // Start House
    public GameObject house0_0;
    public GameObject house0_1;

    // First House
    public GameObject house1_0;
    public GameObject house1_1;
    public GameObject house1_2;


    void Start() {
        shop = GameObject.Find("ShopMain");
    }


    void FixedUpdate() {

        //Debug.Log("Owns house 0: " + shop.GetComponent<ShopManager>().ownsHouse0);
        //Debug.Log("Owns house 1: " + shop.GetComponent<ShopManager>().ownsHouse1);

        if (shop.GetComponent<ShopManager>().ownsHouse0) {
            house0_0.SetActive(true);
            house0_1.SetActive(true);
        } else {
            house0_0.SetActive(false);
            house0_1.SetActive(false);
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
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private GameObject player;
    private Vector3 offset;

    void Start() {
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate() {
        transform.position = player.transform.position + offset;
    }
}

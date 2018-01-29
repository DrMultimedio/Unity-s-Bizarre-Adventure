using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () {
        if(player == null)
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update () {
        Vector3 newPosition = transform.position;
        //newPosition.x = player.transform.position.x + offset.x;

        newPosition.z = player.transform.position.z + offset.z;
        newPosition.y = player.transform.position.y + offset.y;

        transform.position = newPosition;
    }
}

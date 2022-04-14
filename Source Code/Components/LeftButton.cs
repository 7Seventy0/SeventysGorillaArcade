using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    bool isPressing;
    GameObject arcade;
    GameObject player;
    ArcadePlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
       isPressing = true;
    }
    void OnTriggerExit(Collider other)
    {
       isPressing=false;
    }
    void Start()
    {
        arcade = GameObject.Find("Arcade(Clone)");
        player = GameObject.Find("ArcadePlatform");
        playerController = player.GetComponent<ArcadePlayerController>();
        gameObject.layer = 18;
    }
    void Update()
    {
        if (isPressing)
        {
            playerController.MoveLeft();
        }
    }
}

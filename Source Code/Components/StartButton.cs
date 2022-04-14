using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    GameObject arcade;
    GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (!arcade.GetComponent<ArcadeManager>().isPlaying)
        {
            arcade.GetComponent<ArcadeManager>().StartGame();
        }
    }
    
    void Start()
    {
        arcade = GameObject.Find("Arcade(Clone)");
        player = GameObject.Find("ArcadePlatform");
        gameObject.layer = 18;
    }

}

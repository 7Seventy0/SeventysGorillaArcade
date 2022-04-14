using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArcadePlayerController : MonoBehaviour
{

    public float speed = 3;
    Rigidbody rb;
    GameObject arcade;
    ArcadeManager manager;
    public GameObject succesParticle;

    void Update()
    {
        if (Keyboard.current.dKey.isPressed)
        {
            MoveRight();
        }
        if (Keyboard.current.aKey.isPressed)
        {
            MoveLeft();
        }

    }
    void Start()
    {
        InvokeRepeating("SlowUpdate", 0, 0.1f);
        rb = GameObject.Find("ArcadePlatform").GetComponent<Rigidbody>();
        arcade = GameObject.Find("Arcade(Clone)");
        manager = arcade.GetComponent<ArcadeManager>(); 
        audioSource = GameObject.Find("KillBananaSound").GetComponent<AudioSource>();
    }
    void SlowUpdate()
    {
      
    }
public void MoveRight()
    {
        if (manager.isPlaying)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        
    }
    public void MoveLeft()
    {
        if (manager.isPlaying)
        {
            rb.velocity = new Vector3(-speed, 0, 0);
        }
    }
    AudioSource audioSource;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "banana(Clone)")
        {
            Destroy(collision.gameObject);
            audioSource.pitch = Random.Range(0.8f, 1.4f);
            audioSource.Play();
            Instantiate(succesParticle, transform.position, Quaternion.identity);
            manager.GainHealth(0.05f);
            manager.score++;
            
            if (manager.score == 10)
            {
                manager.timeTillNextBanana -= 0.5f;
            }
            if (manager.score == 20)
            {
                manager.timeTillNextBanana -= 0.5f;
            }
            if (manager.score == 35)
            {
                manager.timeTillNextBanana -= 0.3f;
            }
            if (manager.score == 55)
            {
                manager.timeTillNextBanana -= 0.1f;
            }
        }
    }

}

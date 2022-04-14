using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcadeManager : MonoBehaviour
{
    public float score;
    public bool isPlaying;
    public float startHealth = 3;
    public float health;
    GameObject itemSpawner;
    public bool musicOn = true;
    public GameObject banana;
    GameObject healthBar;
    AudioSource dieSound;
    AudioSource startSound;
    AudioSource bgMusic;
    GameObject scoreText;

    public float timeTillNextBanana = 2;
    void Start()
    {
        health = startHealth;
        itemSpawner = GameObject.Find("itemspawner");
        scoreText = GameObject.Find("Score Text");
        healthBar = GameObject.Find("HealthBar");
        dieSound = GameObject.Find("DieSound").GetComponent<AudioSource>();
        startSound = GameObject.Find("StartGameSound").GetComponent<AudioSource>();
        bgMusic = GameObject.Find("bgMusic").GetComponent<AudioSource>();
    }
    float countDown;
    Rigidbody rigidbody;
    void Update()
    {


        Vector3 randompos = new Vector3(Random.Range(3.75f,8.5f), 14.902f, -11.092f);
        itemSpawner.transform.localPosition = randompos;

        if (isPlaying)
        {
            GameObject.Find("Score Text").GetComponent<TextMesh>().text = "Score: " + score;
            countDown -= Time.deltaTime;
           

            if (countDown <= 0)
            {
                Instantiate(banana, itemSpawner.transform.position, Quaternion.Euler(-90, 0,0));
                rigidbody = banana.GetComponent<Rigidbody>();


                rigidbody.drag = 10;

                countDown = timeTillNextBanana;
            }
        }
        if(health <= 0)
        {
            
            
            EndGame();
           health = 0.0001f;
        }

    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.GetComponent<Image>().fillAmount = health / startHealth;
        Debug.Log(healthBar.GetComponent<Image>().fillAmount);
    }
    public void GainHealth(float amount)
    {
        if(health < startHealth)
        {
            health += amount;
            healthBar.GetComponent<Image>().fillAmount = health / startHealth;
        }
    }
    public void EndGame()
    {
        isPlaying = false;
        dieSound.Play();
        GameObject.Find("Score Text").GetComponent<TextMesh>().text = "Game Over!";
        StopMusic();
    }
    void StartMusic()
    {
        if (musicOn)
        {
            bgMusic.Play();
            
        }
        else
        {
            StopMusic();
        }
    }
    void StopMusic()
    {
        bgMusic.Stop();
    }
    public void StartGame()
    {
        isPlaying=true;
        startHealth = 3;
        health = startHealth;
        healthBar.GetComponent<Image>().fillAmount = health / startHealth;
        startSound.Play();
        score = 0;
        timeTillNextBanana = 2f;
        StartMusic();
    }
}

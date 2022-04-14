using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailZone : MonoBehaviour
{
    ArcadeManager manager;
    AudioSource audioSource;
    void Start()
    {
        manager = GameObject.Find("Arcade(Clone)").GetComponent<ArcadeManager>();
        audioSource = GameObject.Find("TakeDamageSound").GetComponent<AudioSource>();
    }
    
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "banana(Clone)")
        {
            audioSource.Play();
            manager.TakeDamage(0.8f);
            Destroy(other.gameObject);
        }
    }
}

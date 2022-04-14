using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter5s : MonoBehaviour
{
    float countdown = 5;
    void Update()
    {
       
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            Destroy(gameObject);
        }
    }

}

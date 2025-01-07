using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GotHit : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Bullet") {
            
            // killCount = Int32.Parse(killCountText.text);
            // killCount += 1;
            // killCountText.text = killCount.ToString();
            
            // Destroy(gameObject);

        }
    }
}

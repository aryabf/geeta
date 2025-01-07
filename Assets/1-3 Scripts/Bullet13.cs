using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Bullet13 : MonoBehaviour
{

    public float life = 2.5f;
    public float direction;

    public GameObject explosionPrefab;

    public GameObject healthPickup;

    private PlayerMovementTest13 player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMovementTest13.player;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy") {
            // StartCoroutine(Explode());
 
            // Nambah teksnya
            // killCount = Int32.Parse(killCountText.text);
            // killCount += 1;
            // killCountText.text = killCount.ToString();

            Enemy13 enemy = collision.gameObject.GetComponent<Enemy13>();
            Miniboss boss = collision.gameObject.GetComponent<Miniboss>();
            if (boss != null) {
                boss.currentHP -= 10;
                if (boss.currentHP <= 0) {
                    boss.enemyGotHit += player.killBoss;
                    Debug.Log("BULLET");
                    int rand = UnityEngine.Random.Range(0, 100);
                    if (rand < 5) {
                        Instantiate(healthPickup, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                    }  
                    Destroy(collision.gameObject);
                }
            }
            if (enemy != null) {
                enemy.currentHP -= 10;
                if (enemy.currentHP <= 0) {
                    enemy.enemyGotHit += player.TambahKill;
                    int rand = UnityEngine.Random.Range(0, 100);
                    if (rand < 5) {
                        Instantiate(healthPickup, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                    }  
                    Destroy(collision.gameObject);
                }
                
            }

            // Bikin ledakan
            var explosion = Instantiate(explosionPrefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            // yield return new WaitForSeconds(0.25f);
            Destroy(explosion, 0.4f);
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Hitable Env") {
            // Bikin ledakan
            var explosion = Instantiate(explosionPrefab, transform.position, collision.gameObject.transform.rotation);
            // yield return new WaitForSeconds(0.25f);
            Destroy(explosion, 0.4f);
            Destroy(gameObject);
        }
    }

    // private IEnumerator Explode()
    // {
    //     // var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
    //     // yield return new WaitForSeconds(0.25f);
    //     // Destroy(explosion, 0f);
    // }
}
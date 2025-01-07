using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float life = 2.5f;
    public float direction;

    public int killCount;
    public Text killCountText;

    public GameObject explosionPrefab;

    public GameObject healthPickup;

    private PlayerMovementTest player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMovementTest.player;
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

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.enemyGotHit += player.TambahKill;
                int rand = UnityEngine.Random.Range(0, 100);
                if (rand < 5) {
                    Instantiate(healthPickup, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                }
            }

            // Bikin ledakan
            var explosion = Instantiate(explosionPrefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            // yield return new WaitForSeconds(0.25f);
            Destroy(explosion, 0.4f);
            Destroy(collision.gameObject);
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

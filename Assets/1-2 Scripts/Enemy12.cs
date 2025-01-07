using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Enemy12 : MonoBehaviour
{

    private float horizontal;
    public float moveSpeedMultiplier = 1.5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public event Action enemyGotHit;
    private bool isRight = true;
    private float moveSpeed;
    private float enemyBaseSpeed;
    public bool canHit = true;

    public float maxHP = 20f;
    public float currentHP = 20f;
    public Slider hpBar;

    public Canvas hp;

    // public AudioSource[] deathSounds;
    // private AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        // int rand = UnityEngine.Random.Range(0, deathSounds.Length);
        // deathSound = deathSounds[rand];
    }

    // Update is called once per frame
    void Update()
    {

        enemyBaseSpeed = EnemyManagement.GetEnemyBaseSpeed();
        moveSpeed = enemyBaseSpeed * moveSpeedMultiplier;

        Vector3 direction = PlayerReference.GetPlayerTransform().position - transform.position;
        direction.Normalize();
        movement = direction;
        horizontal = direction.x;

        if (!canHit) {
            Wait1Detik();
        }

        Flip();
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Bullet") {
            
            // if (!deathSound.isPlaying) {
            //     deathSound.Play(0);
            // }
            hpBar.value = currentHP;
            if (currentHP <= 0) {
                enemyGotHit?.Invoke();
            }
        }
    }

    private void Flip() {
        if (isRight && horizontal < 0f || !isRight && horizontal > 0f) {
            isRight = !isRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            localScale = hp.GetComponent<RectTransform>().localScale;
            localScale.x *= -1f;
            hp.GetComponent<RectTransform>().localScale = localScale;
        }
    }

    private IEnumerator Wait1Detik() {
        yield return new WaitForSeconds(1f);
        canHit = true;
    }
}

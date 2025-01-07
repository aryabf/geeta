using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class PlayerMovementTest13 : MonoBehaviour
{
    private float attackInterval = 1.01f;

    public float kecepatan = 2.5f;

    private float horizontal;
    private bool isRight = true;

    public Rigidbody2D rb;

    public Animator animator;

    public Transform rightHand;

    public Transform camera;

    public Transform bulletSpawnPoint;

    public GameObject bulletRightPrefab;
    public GameObject bulletUpPrefab;
    public GameObject bulletLeftPrefab;
    public GameObject bulletDownPrefab;

    public AudioSource bgm;

    public float bulletSpeed = 7;

    private bool sedangGesek = false;

    private float pergerakanTanganHor;
    private float pergerakanTanganVer;
    private bool bolehAttack = true;

    private int geterCount = 3;

    private float attackCount = 0;

    Vector2 movement;

    private int killCount;
    public Text killCountText;

    private int health;
    public Text healthText;

    private float time2 = 0;
    private float time = 0;
    private double minute;
    private double second;
    private string minuteString;
    private string secondString;
    public Text countdownText;

    public static PlayerMovementTest13 player { get; private set; }

    public Slider exp;

    public Text levelText;
    private float level = 0;

    private bool isPaused = false;

    public Canvas pauseMenu;
    public Canvas gameOverMenu;
    public Canvas levelUpMenu;
    public Canvas levelCompleteMenu;

    public TMP_Text scoreGameOver;

    public Button resumeButton;
    public Button mainMenuPauseButton;
    public Button retryButton;
    public Button mainMenuGOButton;
    public Sprite blankButton;

    public Button incMaxHP;
    public Button incMvtSpd;
    public Button incAtkSpd;

    public Button nextLevelButton;
    public Button replayButton;
    public Button mainMenuCompleteButton;

    private int maxHP = 100;

    public TMP_Text finalScore;

    public TMP_Text hpValue;
    public TMP_Text spdValue;

    public AudioSource complete;
    public AudioSource over;
    public AudioSource levelUp;

    private string[] currentData;

    public GameObject boss;

    public Image sun;
    private bool pulseSun = false;
    private bool bolehPulse = true;

    private bool bossKilled = false;

    void Start()
    {
        kecepatan = kecepatan / 2;
        StartCoroutine(Shake());
        StartCoroutine(FasterYetFaster());
        StartCoroutine(spawnBoss());
        pauseMenu.enabled = false;
        gameOverMenu.enabled = false;
        levelUpMenu.enabled = false;
        levelCompleteMenu.enabled = false;
        Time.timeScale = 1f;
        currentData = File.ReadAllLines("geetadata.txt");
    }

    // Update is called once per frame
    void Update()
    {

        // Check for the "Esc" key press
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverMenu.enabled)
        {
            TogglePause();
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);

        time2 += Time.deltaTime;
        time = 191 - time2;
        minute = Math.Floor(time / 60);
        second = Math.Floor(time % 60);
        if (minute < 10) { 
            minuteString = $"0{minute}";
        } 
        else { 
            minuteString = minute.ToString(); 
        }
        if (second < 10) { 
            secondString = $"0{second}";
        }
        else { 
            secondString = second.ToString();
        }
        countdownText.text = $"{minuteString}:{secondString}";
        if (time <= 1 && bossKilled) LevelComplete();
        else if (time <= 1 && !bossKilled) {
            Time.timeScale = 0f;
            gameOverMenu.enabled = true;
            scoreGameOver.text = $"Score: {killCount}";
            retryButton.interactable = true;
            bgm.Stop();
            if (!over.isPlaying) {
                over.Play(0);
                over.loop = false;
            }
        }
        // countdownText.text = Time.deltaTime.ToString();

        // if (!sedangAttack) {  
        //     StartCoroutine(Attack());
        // }

        if (bolehAttack) StartCoroutine(Attack());
        if (pulseSun && bolehPulse) StartCoroutine(pulsingSun());

        Flip();

    }

    private IEnumerator spawnBoss() {
        yield return new WaitForSeconds(123.4f);
        // yield return new WaitForSeconds(1f);
        Vector3 bossPos = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        Instantiate(boss, bossPos, Quaternion.identity);
    }

    private IEnumerator FasterYetFaster() {
        yield return new WaitForSeconds(140.2f);
        pulseSun = true;
        kecepatan = kecepatan * 150 / 100;
        attackInterval /= 2;
        camera.position = camera.position + new Vector3(0, 0.4f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, -0.4f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, 0.3f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, -0.3f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, 0.2f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, -0.2f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, 0.1f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, -0.1f);
    }

    private void LevelComplete()
    {
        levelCompleteMenu.enabled = true;
        Time.timeScale = 0f;
        bgm.Pause();
        nextLevelButton.interactable = true;
        replayButton.interactable = true;
        mainMenuCompleteButton.interactable = true;
        finalScore.text = $"Score: {killCount}";
        if (!complete.isPlaying) {
            complete.Play(0);
            complete.loop = false;
        }
        currentData[1] = "1";
        File.WriteAllLines("geetadata.txt", currentData);
    }

    private IEnumerator pulsingSun() {
        bolehPulse = false;
        sun.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.05f);
        sun.color = new Color(1f, 1f, 1f, 0.95f);
        yield return new WaitForSeconds(0.05f);
        sun.color = new Color(1f, 1f, 1f, 0.9f);
        yield return new WaitForSeconds(0.05f);
        sun.color = new Color(1f, 1f, 1f, 0.85f);
        yield return new WaitForSeconds(0.05f);
        sun.color = new Color(1f, 1f, 1f, 0.8f);
        yield return new WaitForSeconds(0.05f);
        sun.color = new Color(1f, 1f, 1f, 0.75f);
        yield return new WaitForSeconds(0.05f);
        sun.color = new Color(1f, 1f, 1f, 0.7f);
        yield return new WaitForSeconds(0.05f);
        sun.color = new Color(1f, 1f, 1f, 0.65f);
        yield return new WaitForSeconds(0.05f);
        sun.color = new Color(1f, 1f, 1f, 0.6f);
        yield return new WaitForSeconds(0.05f);
        sun.color = new Color(1f, 1f, 1f, 0.55f);
        yield return new WaitForSeconds(0.055f);
        bolehPulse = true;
    }

    private void CloseLevelUp() {
        Time.timeScale = 1f;
        bgm.UnPause();
        levelUpMenu.enabled = false;
        incMaxHP.interactable = false;
        incMvtSpd.interactable = false;
        incAtkSpd.interactable = false;
    }

    public void IncreaseMaxHP() {
        CloseLevelUp();
        maxHP = 115;
    }

    public void IncreaseAtkSpd() {
        CloseLevelUp();
        attackInterval /= 2;
        StartCoroutine(Wait20Seconds());
    }

    public void IncreaseMvtSpd() {
        CloseLevelUp();
        kecepatan = kecepatan * 125 / 100;
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        retryButton.interactable = false;
        replayButton.interactable = true;
        if (over.isPlaying) over.Stop();
        if (complete.isPlaying) complete.Stop();
    }

    public void ToMenu() 
    {
        if (over.isPlaying) over.Stop();
        if (complete.isPlaying) complete.Stop();
        SceneManager.LoadScene(1);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;

        // Add any additional pause/resume functionality here
        if (isPaused)
        {
            pauseMenu.enabled = true;
            bgm.Pause();
            resumeButton.interactable = true;
        }
        else
        {
            pauseMenu.enabled = false;
            bgm.UnPause();
            resumeButton.interactable = false;
        }
    }

    public void LevelUp()
    {
        Time.timeScale = 0f;
        bgm.Pause();
        levelUpMenu.enabled = true;
        incMaxHP.interactable = true;
        incMvtSpd.interactable = true;
        incAtkSpd.interactable = true;
        hpValue.text = $"{maxHP}";
        spdValue.text = $"{(int)(kecepatan)}";
        levelUp.Play(0);
        levelUp.loop = false;
    }

    private void Flip() {
        if (isRight && horizontal < 0f || !isRight && horizontal > 0f) {
            isRight = !isRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * kecepatan * Time.fixedDeltaTime);
    }

    private IEnumerator Wait20Seconds()
    {
        yield return new WaitForSeconds(10f);
        attackInterval *= 2;
    }

    private IEnumerator Attack()
    {

        if (!bgm.isPlaying) {
            bgm.Play(0);
            bgm.loop = false;
        }

        bolehAttack = false;
        // geterCount += 1;
        attackCount += 1;

        var bullet1 = Instantiate(bulletUpPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        var bullet2 = Instantiate(bulletRightPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        var bullet3 = Instantiate(bulletDownPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        var bullet4 = Instantiate(bulletLeftPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet1.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        bullet2.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
        bullet3.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * -bulletSpeed;
        bullet4.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * -bulletSpeed;

        if (isRight) {
            if (sedangGesek) {
                pergerakanTanganHor = -0.1f;
                pergerakanTanganVer = -0.1f;
            } else {
                pergerakanTanganHor = 0.1f;
                pergerakanTanganVer = 0.1f;
            }
        } else {
            if (sedangGesek) {
                pergerakanTanganHor = 0.1f;
                pergerakanTanganVer = -0.1f;
            } else {
                pergerakanTanganHor = -0.1f;
                pergerakanTanganVer = 0.1f;
            }
        }
        rightHand.position = rightHand.position + new Vector3(pergerakanTanganHor, pergerakanTanganVer);
        sedangGesek = !sedangGesek;

        yield return new WaitForSeconds(attackInterval);
        bolehAttack = true;
        
        // sedangAttack = true;
        // //rightHand.eulerAngles = Vector3.forward * 22.5;
        // rightHand.Rotate(0, 0, 22.5f);
        // rightHand.position = rightHand.position + new Vector3(0.20f, 0.15f);
        // yield return new WaitForSeconds(0.2f);
        // //rightHand.eulerAngles = Vector3.forward * 22.5;
        // rightHand.Rotate(0, 0, 22.5f);
        // rightHand.position = rightHand.position + new Vector3(0.10f, 0.15f);
        // yield return new WaitForSeconds(0.2f);
        // //rightHand.eulerAngles = Vector3.back * 22.5;
        // rightHand.Rotate(0, 0, -22.5f);
        // rightHand.position = rightHand.position - new Vector3(0.10f, 0.15f);
        // yield return new WaitForSeconds(0.2f);
        // //rightHand.eulerAngles = Vector3.back * 22.5;
        // rightHand.Rotate(0, 0, -22.5f);
        // rightHand.position = rightHand.position - new Vector3(0.20f, 0.15f);
        // yield return new WaitForSeconds(0.2f);
        // sedangAttack = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy13 enemy = collision.gameObject.GetComponent<Enemy13>();
            if (enemy != null) {
                if (enemy.canHit == true) {
                    KurangHealth();
                    enemy.canHit = false;
                }
            }
        } else if (collision.gameObject.CompareTag("Health")) {
            Destroy(collision.gameObject);
            health = Int32.Parse(healthText.text);
            health += 5;
            if (health > maxHP) health = 100;
            healthText.text = health.ToString();
        }
    }

    private IEnumerator Shake() {
        yield return new WaitForSeconds(19.2f);
        attackInterval /= 2;
        kecepatan = 5f;
        //bolehGeter = false;
        // camera.position = camera.position + new Vector3(0, 0.5f);
        // yield return new WaitForSeconds(0.05f);
        // camera.position = camera.position + new Vector3(0, -0.5f);
        // yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, 0.4f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, -0.4f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, 0.3f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, -0.3f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, 0.2f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, -0.2f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, 0.1f);
        yield return new WaitForSeconds(0.05f);
        camera.position = camera.position + new Vector3(0, -0.1f);
        //yield return new WaitForSeconds(0.5385f);
        //yield return new WaitForSeconds(2.244f);
        geterCount = 0;
    }

    public void killBoss() {
        bossKilled = true;
        
        Debug.Log("PMT");
    }

    public void TambahKill()
    {
        killCount = Int32.Parse(killCountText.text);
        killCount += 1;
        killCountText.text = killCount.ToString();

        if (exp.value < 100) {
            exp.value++;
        } else {
            exp.value = 0;
            level++;
            levelText.text = $"Lv.{level}";
            LevelUp();
        }

        // int rand = UnityEngine.Random.Range(0, deathSounds.Length);
        // deathSound = deathSounds[rand];
        // // if (!deathSound.isPlaying) {
        //     deathSound.Play(0);
        // // }
        // for (int i = 0; i < playingSounds.Length; i++) {
        //     if (!playingSounds[i].isPlaying) {
        //         continue;
        //     }
        //     else {
        //         int rand = UnityEngine.Random.Range(0, deathSounds.Length);
        //         playingSounds[i] = deathSounds[rand];
        //         playingSounds[i].Play(0);
        //         break;
        //     }
        // }

    }

    public void KurangHealth()
    {
        health = Int32.Parse(healthText.text);
        health -= 5;
        if (health < 0) health = 0;
        healthText.text = health.ToString();
        if (health <= 0) {
            Time.timeScale = 0f;
            gameOverMenu.enabled = true;
            scoreGameOver.text = $"Score: {killCount}";
            retryButton.interactable = true;
            bgm.Stop();
            if (!over.isPlaying) {
                over.Play(0);
                over.loop = false;
            }
        }
    }

    private void Awake()
    {
        if (player == null)
            player = this;
        else
            Destroy(gameObject);
    }

    // private IEnumerator GerakBullet() {

    // }

}
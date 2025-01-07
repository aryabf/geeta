using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public Transform player;
    private bool mapExists;
    // private bool checkeds;

    private Vector3 spawnPos;
    private bool rightCheck = false;
    private bool leftCheck = false;
    private bool topCheck = false;
    private bool downCheck = false;

    public GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        mapExists = false;
        // checkeds = false;
    }

    // Update is called once per frame
    void Update()
    {
        RightCheck();
        LeftCheck();
        TopCheck();
        DownCheck();
        TopRightCheck();
        DownRightCheck();
        TopLeftCheck();
        DownLeftCheck();
        // // Right
        // if (player.position.x % 60 >= 15 && player.position.x % 60 < 30) {
        //     // Debug.Log("Spawn!");
        //     if (!rightCheck) {
        //         Debug.Log("RightTrue");
        //         transform.position += new Vector3(20f, 0f, 0f);
        //         rightCheck = true;
        //     }
        //     if (rightCheck) {
        //         if (CheckMap()) {
        //             mapExists = true;
        //         } else mapExists = false;
        //     }
        //     // if (checkeds && !mapExists) {
        //     if (!mapExists) {
        //         spawnPos = new Vector3(((int)(player.position.x / 60) + 1) * 60, (int)(player.position.y / 60) * 60, 0f);
        //         Debug.Log($"{(int)(player.position.x / 60)}");
        //         Instantiate(map, spawnPos, player.transform.rotation);
        //         // checkeds = false;
        //     }
        // } else {
        //     if (rightCheck) {
        //         rightCheck = false;
        //         transform.position += new Vector3(-20f, 0f, 0f);
        //         Debug.Log("RightFalse");
        //         mapExists = false;
        //     }   
        // }
        // // Left
        // if (player.position.x % 60 <= -15 && player.position.x % 60 > -30) {
        //     // Debug.Log("Spawn!");
        //     if (!leftCheck) {
        //         transform.position += new Vector3(-20f, 0f, 0f);
        //         leftCheck = true;
        //         Debug.Log("LeftTrue");
        //     }
        //     if (leftCheck) {
        //         if (CheckMap()) {
        //             mapExists = true;
        //         } else mapExists = false;
        //     }
        //     // if (checkeds && !mapExists) {
        //     if (!mapExists) {
        //         spawnPos = new Vector3(((int)(player.position.x / 60) - 1) * 60, (int)(player.position.y / 60) * 60, 0f);
        //         Debug.Log($"{(int)(player.position.x / 60)}");
        //         Instantiate(map, spawnPos, player.transform.rotation);
        //         // checkeds = false;
        //     }
        // } else {
        //     if (leftCheck) {
        //         leftCheck = false;
        //         transform.position += new Vector3(20f, 0f, 0f);
        //         Debug.Log("LeftFalse");
        //         mapExists = false;
        //     }   
        // }
        // // Top
        // if (player.position.y % 60 >= 15 && player.position.y % 60 < 30) {
        //     // Debug.Log("Spawn!");
        //     if (!topCheck) {
        //         transform.position += new Vector3(0f, 20f, 0f);
        //         topCheck = true;
        //     }
        //     if (topCheck) {
        //         if (CheckMap()) {
        //             mapExists = true;
        //         } else mapExists = false;
        //     }
        //     // if (checkeds && !mapExists) {
        //     if (!mapExists) {
        //         spawnPos = new Vector3((int)(player.position.x / 60) * 60, ((int)(player.position.y / 60) + 1) * 60, 0f);
        //         Debug.Log($"{(int)(player.position.y / 60)}");
        //         Instantiate(map, spawnPos, player.transform.rotation);
        //         // checkeds = false;
        //     }
        // } else {
        //     if (topCheck) {
        //         topCheck = false;
        //         transform.position += new Vector3(0f, -20f, 0f);
        //         mapExists = false;
        //     }   
        // }
        // // Down
        // if (player.position.y % 60 <= -15 && player.position.y % 60 > -30) {
        //     // Debug.Log("Spawn!");
        //     if (!downCheck) {
        //         transform.position += new Vector3(0f, -20f, 0f);
        //         downCheck = true;
        //     }
        //     if (downCheck) {
        //         if (CheckMap()) {
        //             mapExists = true;
        //         } else mapExists = false;
        //     }
        //     // if (checkeds && !mapExists) {
        //     if (!mapExists) {
        //         spawnPos = new Vector3((int)(player.position.x / 60) * 60, ((int)(player.position.y / 60) - 1) * 60, 0f);
        //         Debug.Log($"{(int)(player.position.y / 60)}");
        //         Instantiate(map, spawnPos, player.transform.rotation);
        //         // checkeds = false;
        //     }
        // } else {
        //     if (downCheck) {
        //         downCheck = false;
        //         transform.position += new Vector3(0f, 20f, 0f);
        //         mapExists = false;
        //     }   
        // }
    // }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // checkeds = true;
        if (collision.gameObject.CompareTag("Map")) {
            mapExists = true;
            Debug.Log("WOW!");
        }
    }

    private void CheckCollide() {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);
        foreach (Collider2D collider in colliders) {
            if (collider.gameObject.CompareTag("Map")) {
                mapExists = true;
            }
        }
    }

    private void RightCheck()
    {
        if ((player.position.x % 60 >= 15 && player.position.x % 60 < 30) || (player.position.x % 60 <= -31 && player.position.x % 60 > -45)) {
            transform.position += new Vector3(20f, 0f, 0f);
            CheckCollide();
            if (!mapExists) {
                int newX = ((int)(player.position.x / 60)) * 60;
                if (player.position.x > 0) newX += 60;
                int newY = ((int)((player.position.y + 30) / 60)) * 60;
                if ((player.position.y + 30) <= 0) newY -= 60;
                // if (player.position.x > 0) {
                //     spawnPos = new Vector3(((int)(player.position.x / 60) + 1) * 60, (int)(player.position.y / 60) * 60, 0f);
                // } else spawnPos = new Vector3(((int)(player.position.x / 60)) * 60, (int)(player.position.y / 60) * 60, 0f);
                Debug.Log("Right");
                Instantiate(map, new Vector3(newX, newY, 0f), player.transform.rotation);
                // Instantiate(map, spawnPos, player.transform.rotation);
            }
            transform.position += new Vector3(-20f, 0f, 0f);
            mapExists = false;
        }
    }

    private void LeftCheck()
    {
        if ((player.position.x % 60 >= 31 && player.position.x % 60 < 45) || (player.position.x % 60 <= -15 && player.position.x % 60 > -30)) {
            transform.position += new Vector3(-20f, 0f, 0f);
            CheckCollide();
            if (!mapExists) {
                int newX = ((int)(player.position.x / 60)) * 60;
                if (player.position.x <= 0) newX -= 60;
                int newY = ((int)((player.position.y + 30) / 60)) * 60;
                if ((player.position.y + 30) <= 0) newY -= 60;
                // if (player.position.x > 0) {
                //     spawnPos = new Vector3(((int)(player.position.x / 60)) * 60, (int)(player.position.y / 60) * 60, 0f);
                // } else spawnPos = new Vector3(((int)(player.position.x / 60) - 1) * 60, (int)(player.position.y / 60) * 60, 0f);
                Debug.Log("Left");
                // Instantiate(map, spawnPos, player.transform.rotation);
                Instantiate(map, new Vector3(newX, newY, 0f), player.transform.rotation);
            }
            transform.position += new Vector3(20f, 0f, 0f);
            mapExists = false;
        }
    }

    private void TopCheck()
    {
        if ((player.position.y % 60 >= 15 && player.position.y % 60 < 30) || (player.position.y % 60 <= -31 && player.position.y % 60 > -45)) {
            transform.position += new Vector3(0f, 20f, 0f);
            CheckCollide();
            if (!mapExists) {
                int newX = ((int)((player.position.x + 30) / 60)) * 60;
                if ((player.position.x + 30) <= 0) newX -= 60;
                int newY = ((int)((player.position.y) / 60)) * 60;
                if (player.position.y > 0) newY += 60;
                // if (player.position.x > 0) {
                //     spawnPos = new Vector3(((int)(player.position.x / 60)) * 60, ((int)(player.position.y / 60) + 1) * 60, 0f);
                // } else spawnPos = new Vector3(((int)(player.position.x / 60) - 1) * 60, (int)(player.position.y / 60) * 60, 0f);
                Debug.Log("Top");
                // Instantiate(map, spawnPos, player.transform.rotation);
                Instantiate(map, new Vector3(newX, newY, 0f), player.transform.rotation);
            }
            transform.position += new Vector3(0f, -20f, 0f);
            mapExists = false;
        }
    }

    private void DownCheck()
    {
        if ((player.position.y % 60 >= 31 && player.position.y % 60 < 45) || (player.position.y % 60 <= -15 && player.position.y % 60 > -30)) {
            transform.position += new Vector3(0f, -20f, 0f);
            CheckCollide();
            if (!mapExists) {
                int newX = ((int)((player.position.x + 30) / 60)) * 60;
                if ((player.position.x + 30) <= 0) newX -= 60;
                int newY = ((int)((player.position.y) / 60)) * 60;
                if (player.position.y <= 0) newY -= 60;
                // if (player.position.x > 0) {
                //     spawnPos = new Vector3(((int)(player.position.x / 60)) * 60, (int)(player.position.y / 60) * 60, 0f);
                // } else spawnPos = new Vector3(((int)(player.position.x / 60) - 1) * 60, ((int)(player.position.y / 60) - 1) * 60, 0f);
                Debug.Log("Down");
                // Instantiate(map, spawnPos, player.transform.rotation);
                Instantiate(map, new Vector3(newX, newY, 0f), player.transform.rotation);
            }
            transform.position += new Vector3(0f, 20f, 0f);
            mapExists = false;
        }
    }

    private void TopRightCheck() {
        if (((player.position.x % 60 >= 15 && player.position.x % 60 < 30) || (player.position.x % 60 <= -31 && player.position.x % 60 > -45)) && ((player.position.y % 60 >= 15 && player.position.y % 60 < 30) || (player.position.y % 60 <= -31 && player.position.y % 60 > -45))) {
            transform.position += new Vector3(20f, 20f, 0f);
            CheckCollide();
            if (!mapExists) {
                int newX = ((int)(player.position.x / 60)) * 60;
                if (player.position.x > 0) newX += 60;
                int newY = ((int)((player.position.y) / 60)) * 60;
                if (player.position.y > 0) newY += 60;
                // if (player.position.x > 0) {
                //     spawnPos = new Vector3(((int)(player.position.x / 60) + 1) * 60, ((int)(player.position.y / 60) + 1) * 60, 0f);
                // } else spawnPos = new Vector3(((int)(player.position.x / 60)) * 60, (int)(player.position.y / 60) * 60, 0f);
                Debug.Log("TopRight");
                // Instantiate(map, spawnPos, player.transform.rotation);
                Instantiate(map, new Vector3(newX, newY, 0f), player.transform.rotation);
            }
            transform.position += new Vector3(-20f, -20f, 0f);
            mapExists = false;
        }
    }

    private void DownRightCheck() {
        if (((player.position.x % 60 >= 15 && player.position.x % 60 < 30) || (player.position.x % 60 <= -31 && player.position.x % 60 > -45)) && ((player.position.y % 60 >= 31 && player.position.y % 60 < 45) || (player.position.y % 60 <= -15 && player.position.y % 60 > -30))) {
            transform.position += new Vector3(20f, -20f, 0f);
            CheckCollide();
            if (!mapExists) {
                int newX = ((int)(player.position.x / 60)) * 60;
                if (player.position.x > 0) newX += 60;
                int newY = ((int)((player.position.y) / 60)) * 60;
                if (player.position.y <= 0) newY -= 60;
                // if (player.position.x > 0) {
                //     spawnPos = new Vector3(((int)(player.position.x / 60) + 1) * 60, ((int)(player.position.y / 60)) * 60, 0f);
                // } else spawnPos = new Vector3(((int)(player.position.x / 60)) * 60, ((int)(player.position.y / 60) - 1) * 60, 0f);
                Debug.Log("DownRight");
                // Instantiate(map, spawnPos, player.transform.rotation);
                Instantiate(map, new Vector3(newX, newY, 0f), player.transform.rotation);
            }
            transform.position += new Vector3(-20f, 20f, 0f);
            mapExists = false;
        }
    }

    private void TopLeftCheck() {
        if (((player.position.x % 60 >= 31 && player.position.x % 60 < 45) || (player.position.x % 60 <= -15 && player.position.x % 60 > -30)) && ((player.position.y % 60 >= 15 && player.position.y % 60 < 30) || (player.position.y % 60 <= -31 && player.position.y % 60 > -45))) {
            transform.position += new Vector3(-20f, 20f, 0f);
            CheckCollide();
            if (!mapExists) {
                int newX = ((int)(player.position.x / 60)) * 60;
                if (player.position.x <= 0) newX -= 60;
                int newY = ((int)((player.position.y) / 60)) * 60;
                if (player.position.y > 0) newY += 60;
                // if (player.position.x > 0) {
                //     spawnPos = new Vector3(((int)(player.position.x / 60)) * 60, ((int)(player.position.y / 60) + 1) * 60, 0f);
                // } else spawnPos = new Vector3(((int)(player.position.x / 60) - 1) * 60, (int)(player.position.y / 60) * 60, 0f);
                Debug.Log("TopLeft");
                // Instantiate(map, spawnPos, player.transform.rotation);
                Instantiate(map, new Vector3(newX, newY, 0f), player.transform.rotation);
            }
            transform.position += new Vector3(20f, -20f, 0f);
            mapExists = false;
        }
    }

    private void DownLeftCheck() {
        if (((player.position.x % 60 >= 31 && player.position.x % 60 < 45) || (player.position.x % 60 <= -15 && player.position.x % 60 > -30)) && ((player.position.y % 60 >= 31 && player.position.y % 60 < 45) || (player.position.y % 60 <= -15 && player.position.y % 60 > -30))) {
            transform.position += new Vector3(-20f, -20f, 0f);
            CheckCollide();
            if (!mapExists) {
                int newX = ((int)(player.position.x / 60)) * 60;
                if (player.position.x <= 0) newX -= 60;
                int newY = ((int)((player.position.y) / 60)) * 60;
                if (player.position.y <= 0) newY -= 60;
                // if (player.position.x > 0) {
                //     spawnPos = new Vector3(((int)(player.position.x / 60)) * 60, ((int)(player.position.y / 60)) * 60, 0f);
                // } else spawnPos = new Vector3(((int)(player.position.x / 60) - 1) * 60, ((int)(player.position.y / 60) - 1) * 60, 0f);
                Debug.Log("DownLeft");
                // Instantiate(map, spawnPos, player.transform.rotation);
                Instantiate(map, new Vector3(newX, newY, 0f), player.transform.rotation);
            }
            transform.position += new Vector3(20f, 20f, 0f);
            mapExists = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner12 : MonoBehaviour
{

    public Transform target;

    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private bool canSpawn = true;

    public float xPos;
    public float yPos;
    public float zPos;

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x + xPos, target.transform.position.y + yPos, target.transform.position.z + zPos);
    }

    // private IEnumerator Spawner()
    // {

    //     // WaitForSeconds wait = new WaitForSeconds(spawnRate);

    //     // while (canSpawn) {
    //     //     yield return wait;
    //     //     int rand = Random.Range(0, enemyPrefabs.Length);
    //     //     GameObject enemy = enemyPrefabs[rand];

    //     //     Instantiate(enemy, transform.position, Quaternion.identity);
    //     // }
    // }

    public void Spawn()
    {
        int rand = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = enemyPrefabs[rand];

        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}

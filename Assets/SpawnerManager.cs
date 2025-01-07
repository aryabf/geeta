using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    public GameObject[] spawners;

    public float spawnRate = 0.4f;

    [SerializeField]
    private bool canSpawn = true;

    public float firstChange = 19.2f;
    public float secondChange = 156;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = spawnRate * 2;
        StartCoroutine(changeRate());
        StartCoroutine(Spawning());
        StartCoroutine(changeRateAgain());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawning()
    {

        while (canSpawn) {

            yield return new WaitForSeconds(spawnRate);
            // int rand = Random.Range(0, enemyPrefabs.Length);
            // GameObject enemy = enemyPrefabs[rand];
            int rand = Random.Range(0, spawners.Length);
            GameObject spawner = spawners[rand];
            spawner.GetComponent<EnemySpawner>().Spawn();

            // Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator changeRate()
    {
        yield return new WaitForSeconds(firstChange);
        spawnRate = spawnRate / 2.2f;
    }

    private IEnumerator changeRateAgain() {
        yield return new WaitForSeconds(secondChange);
        spawnRate = spawnRate / 1.7f;
    }
}

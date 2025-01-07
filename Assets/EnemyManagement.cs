using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    private static float enemyBaseSpeed;
    public float firstChange = 19.2f;
    public float secondChange = 156f;

    void Awake()
    {
        enemyBaseSpeed = 1;
    }

    void Start()
    {
        StartCoroutine(IncreaseSpeed());
        StartCoroutine(IncreaseAgain());
    }

    private IEnumerator IncreaseAgain() {
        yield return new WaitForSeconds(secondChange);
        enemyBaseSpeed = 2.5f;
    }

    public static float GetEnemyBaseSpeed()
    {
        return enemyBaseSpeed;
    }

    private IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(firstChange);
        enemyBaseSpeed = 2;
    }
}

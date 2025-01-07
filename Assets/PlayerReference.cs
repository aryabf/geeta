using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    private static Transform playerTransform;

    private void Awake()
    {
        playerTransform = transform;
    }

    public static Transform GetPlayerTransform()
    {
        return playerTransform;
    }
}

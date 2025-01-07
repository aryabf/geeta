using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDeathSound : MonoBehaviour
{

    public AudioSource[] deathSounds;
    private AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        int rand = UnityEngine.Random.Range(0, deathSounds.Length);
        deathSound = deathSounds[rand];
        if (!deathSound.isPlaying) {
            deathSound.Play(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

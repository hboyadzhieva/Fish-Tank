using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip eatSound, hurtSound;
    static AudioSource audioSource;

    void Start()
    {
        eatSound = Resources.Load<AudioClip>("eat");
        hurtSound = Resources.Load<AudioClip>("hurt");
        audioSource = GetComponent<AudioSource>();
        PlayerCollision.onPlayerEatSmallerFish += playEatSound;
        PlayerCollision.onPlayerEatBiggerFish += playHurtSound;
    }

    private void playEatSound(GameObject other)
    {
        audioSource.PlayOneShot(eatSound);
    }

    private void playHurtSound()
    {
        audioSource.PlayOneShot(hurtSound);
    }

}

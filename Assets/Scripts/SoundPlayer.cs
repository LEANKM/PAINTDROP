using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip jump;
    public AudioClip land;
    public AudioClip hurt;
    public AudioClip respawn;
    public AudioClip success;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayJump()
    {
        audioSource.PlayOneShot(jump);
    }
    public void PlayLanding()
    {
        audioSource.PlayOneShot(land);
    }
    public void PlayHurt()
    {
        audioSource.PlayOneShot(hurt);
    }
    public void PlayRespawn()
    {
        audioSource.PlayOneShot(respawn);
    }
    public void PlaySuccess()
    {
        audioSource.PlayOneShot(success);
    }
}

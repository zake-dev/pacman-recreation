using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicHandler : MonoBehaviour
{
    public AudioClip introMusicClip;
    public AudioClip normalMusicClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.loop = true;
        StartCoroutine(playBackgroundMusic());
    }

    IEnumerator playBackgroundMusic()
    {
        audioSource.clip = introMusicClip;
        audioSource.Play();
        yield return new WaitForSeconds(3.0f);
        audioSource.clip = normalMusicClip;
        audioSource.Play();
    }
}

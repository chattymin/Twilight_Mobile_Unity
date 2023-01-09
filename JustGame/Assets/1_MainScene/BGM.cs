using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(AudioSource))]
public class BGM : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        AudioClip audioAsset = (AudioClip)Resources.Load("Main");//myfile.mp3
        audioSource.clip = (AudioClip)audioAsset;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(AudioSource))]

public class BGMManager : MonoBehaviour {
    private AudioSource audioSource;

    void Start() {
        audioSource = this.GetComponent<AudioSource>();

        AudioClip audioAsset = (AudioClip)Resources.Load("Sounds/MainBGM"); //myfile.mp3
        audioSource.clip = (AudioClip)audioAsset;
        audioSource.Play();
    }
}
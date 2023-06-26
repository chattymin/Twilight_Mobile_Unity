using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD:JustGame/Assets/1_MainScene/BGM.cs
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
=======
using UnityEngine.Audio;
using UnityEngine.UI;
//using System;
//[RequireComponent(typeof(AudioSource))]

public class BGMManager : MonoBehaviour {

    public AudioMixer masterMixer;
    public Slider audioSlider;

    public void AudioControl() {
        float sound = audioSlider.value;
        if (sound == -40f) masterMixer.SetFloat("Master", -80);
        else masterMixer.SetFloat("Master", sound);
    }

    public void ToggleAudioVolume() {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
>>>>>>> feature/Issue15:JustGame/Assets/1_MainScene/Scripts/BGMManager.cs
    }

    // Update is called once per frame
    void Update()
    {

    }
}
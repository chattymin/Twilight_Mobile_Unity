using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }
}
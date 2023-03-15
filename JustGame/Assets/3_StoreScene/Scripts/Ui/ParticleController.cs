using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleObject1;
    public ParticleSystem particleObject2;
    public ParticleSystem particleObject3;

    void Start() {
        particleObject1 = GameObject.Find("CFXR3 Hit Ice B (Air) (1)").GetComponent<ParticleSystem>();
        particleObject2 = GameObject.Find("CFXR3 Hit Ice B (Air)").GetComponent<ParticleSystem>();
        particleObject3 = GameObject.Find("CFXR3 Hit Ice B (Air) (2)").GetComponent<ParticleSystem>();

        particleObject1.Pause();
        particleObject2.Pause();
        particleObject3.Pause();
    }

    public void particleON(string expName) {

        if (expName.Equals("attack")) {
            particleObject1.Play();
        }
        else if (expName.Equals("defense")) {
            particleObject2.Play();
        }
        else {
            particleObject3.Play();
        }
    }
}

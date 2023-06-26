using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem attackParticle;
    public ParticleSystem defenseParticle;
    public ParticleSystem recoveryParticle;

    //public ParticleSystem clickParticle;

    void Start() {
        attackParticle = GameObject.Find("attackParticle").GetComponent<ParticleSystem>();
        defenseParticle = GameObject.Find("defenseParticle").GetComponent<ParticleSystem>();
        recoveryParticle = GameObject.Find("recoveryParticle").GetComponent<ParticleSystem>();
        //clickParticle = GameObject.Find("clickParticle").GetComponent<ParticleSystem>();

        attackParticle.Pause();
        defenseParticle.Pause();
        recoveryParticle.Pause();
        //clickParticle.Pause();
    }

    public void particleON(string expName) {

        if (expName.Equals("attack")) {
            attackParticle.Play();
        }
        else if (expName.Equals("defense")) {
            defenseParticle.Play();
        }
        else {
            recoveryParticle.Play();
        }
    }

    /*public void touchParticleOn(float xpos, float ypos) {

        clickParticle.Play(); 
    }*/
}

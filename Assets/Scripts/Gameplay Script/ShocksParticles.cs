using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShocksParticles : MonoBehaviour
{

    [Header("Particles")]
    public ParticleSystem Particles;
    private float ShockTimer;
    public bool ParticlesWontShock = false;

    [Header("Particle Sound: ")]
    public AudioSource[] RandomElectrics;


    void Start()
    {
        ShockTimer = Random.Range(1.0f, 5.0f);
        
        InvokeRepeating("ParticlesPlayer", ShockTimer, ShockTimer);
    }
    
    public void ParticlesPlayer()
    {
        if (!ParticlesWontShock)
        {
            int Randoms = Random.Range(0, 3);
            RandomElectrics[Randoms].Play();
            Particles.Play();
        }
        
    }
}

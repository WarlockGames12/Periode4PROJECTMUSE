using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShocksParticles : MonoBehaviour
{

    [Header("Particles")]
    public AudioSource ShockEffect;
    public ParticleSystem Particles;
    public float ShockTimer = 3f;
    public bool ParticlesWontShock = false;


    void Start()
    {
        InvokeRepeating("ParticlesPlayer", ShockTimer, ShockTimer);
    }
    
    void Update()
    {
        if (ParticlesWontShock)
        {
            Particles.Stop();
            ShockTimer = 10000000000f;
        }
    }
    
    public void ParticlesPlayer()
    {
        ShockEffect.Play();
        Particles.Play();
    }

    /*
    IEnumerator ParticlePlayer()
    {
        
        yield return new WaitForSeconds(3);
    }
    */
}

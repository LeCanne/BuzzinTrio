using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EffectPlay : MonoBehaviour
{
    public VisualEffect VisualEffect;
    public ParticleSystem ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffect()
    {
        VisualEffect.Play();
    }

    public void PlayParticles()
    {
        ParticleSystem.Play();
    }
}

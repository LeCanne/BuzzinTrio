using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public bool HasRandom;
    public float minpitch;
    public float maxpitch;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    public void Play()
    {
        if (HasRandom == true)
        {
            audioSource.pitch =  Random.Range(minpitch, maxpitch);
        }   
        audioSource.Play();
    }
}

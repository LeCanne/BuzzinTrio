using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSound : MonoBehaviour
{
    public List<AudioClip> buzzinfrights;
    public AudioSource BootSound;
    // Start is called before the first frame update

    private void Awake()
    {
       BootSound.clip = buzzinfrights[Random.Range(0, buzzinfrights.Count)]; 
    }
    void Start()
    {
        BootSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

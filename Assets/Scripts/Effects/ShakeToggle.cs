using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeToggle : MonoBehaviour
{

    public CameraShake camShake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shake()
    {
        camShake.StartCoroutine(camShake.Shaking());
    }
}

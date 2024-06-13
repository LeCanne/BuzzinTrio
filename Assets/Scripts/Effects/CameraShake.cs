using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration;
    public AnimationCurve curve;
    public AudioSource sourceSlap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public IEnumerator Shaking()
    {
        sourceSlap.pitch = Random.Range(0.8f, 1.5f);
        sourceSlap.Play();
        Vector3 startPosition = transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.localPosition = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.localPosition = startPosition;
    }
}

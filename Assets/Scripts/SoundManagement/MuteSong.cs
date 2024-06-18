using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSong : MonoBehaviour
{
    private AudioSource songToMute;
    // Start is called before the first frame update
    void Start()
    {
        songToMute = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        songToMute.pitch = Time.timeScale;
        if(MatchManager.instance.TimerOn == false)
        {
            songToMute.volume = Mathf.Lerp(songToMute.volume, 0, 1.5f * Time.deltaTime);
        }
    }
}

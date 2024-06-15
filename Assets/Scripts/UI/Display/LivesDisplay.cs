using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    private TMP_Text txt_lives;
    
    // Start is called before the first frame update
    void Start()
    {
        txt_lives = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt_lives.text = MatchManager.instance.lives.ToString();
    }
}

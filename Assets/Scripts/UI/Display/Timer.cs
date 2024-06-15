using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private TMP_Text timerToUpdate;
    // Start is called before the first frame update
    void Start()
    {
        timerToUpdate = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
            timerToUpdate.text = MatchManager.instance.timerTxt;
        
       
    }
}

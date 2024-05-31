using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.InputSystem;

public class LocalPause : MonoBehaviour
{
    public GameObject ConfirmScreen;
    public GameObject PauseScreen;
   
    public bool Performed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseScreen.SetActive(GameManager.instance.paused);
        if(GameManager.instance.paused == false)
        {
            ConfirmScreen.SetActive(false);
        }
    }

    public void Confirm(bool sure)
    {
        
        ConfirmScreen.SetActive(sure);

    }

    public void Resume()
    {
        GameManager.instance.paused = false;
    }

  
        
           
        
    
        
    

}

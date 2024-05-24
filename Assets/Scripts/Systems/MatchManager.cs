using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MatchManager : MonoBehaviour
{

    public static MatchManager instance;

    [Header ("MatchTimer")]
    public string timerTxt;
    public float Timer;
    public float timerLeft;
    public bool TimerOn;
    private bool onlyOnce;

    [Header("PlayerSetup")]
    public float HP;
    public float MaxHP;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Timermanage();
        
    }

    public void Timermanage()
    {
        if (TimerOn)
        {
            if(timerLeft > 0)
            {
                timerLeft -= Time.deltaTime;
                updateTimer(timerLeft);
            }
            else
            {
                timerLeft = 0;
                TimerOn = false;
                if(onlyOnce == false)
                {
                    WinCondition();
                    onlyOnce = true;
                }
              
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTxt = string.Format("{0:00} : {1:00}", minutes, seconds);
        
    }

     
    void WinCondition()
    {
        updateTimer(0);
        StopGame();
        if (timerLeft <= 0)
        {
           

        }
    }

    public void StopGame()
    {
      

        InputSystem.DisableAllEnabledActions();
       
    }
}

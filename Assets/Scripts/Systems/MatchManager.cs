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

    [Header("WinBools")]
    public bool noHpLeft;
    public bool noTimeLeft;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
       timerLeft = Timer;
       if(instance == null)
        {
            instance = this;
        }
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Timermanage();
        HealthManager();
        
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

    public void HealthManager()
    {
        if (HP <= 0)
        {
            TimerOn = false;
            WinCondition();
         
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
       
        
        StopGame();
        if (timerLeft <= 0)
        {
            timerTxt = string.Format("{0:00} : {1:00}", 0, 0);
            noTimeLeft = true;
            Debug.Log("Human Win");

        }
        if(HP <= 0)
        {
            noHpLeft = true;
            Debug.Log("Moskito Win");
        }

        
    }

    public void StopGame()
    {
      

        InputSystem.DisableAllEnabledActions();
       
    }

    public void RestartMatch()
    {
        HP = MaxHP;
        noHpLeft = false;
        noTimeLeft = false;
        onlyOnce = false;
    }
}

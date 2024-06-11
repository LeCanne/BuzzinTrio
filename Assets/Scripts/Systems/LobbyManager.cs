using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public List<TeamJoinController> teamJoins;
    public PlayerInputManager Player_IM;
    public HelperScriptButton HelpButton;
    public GameObject TimerHolder;
    public TMP_Text Timer;
    public bool canBegin;
    private bool allready;

    public float timer;
    private float timeBegin;
    public float token;
    // Start is called before the first frame update
    void Start()
    {
         timeBegin = timer;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayer();

        if(canBegin == true)
        {
            BeginMatch();
        }

       
        if(timeBegin > 0)
        {
            Timer.text = timeBegin.ToString("#;#");
        }
        else
        {
            Timer.text = "0";
        }

    }
    
    void CheckPlayer()
    {
       if( Player_IM.playerCount >= 2)
       {
            canBegin = true;
       }
       else
       {
            canBegin = false;
       }
    }

    void BeginMatch()
    {
        //Step 1 : Check if everyone is ready.
        allready = true;
        for (int i = 0; i < teamJoins.Count; i++)
        {
            

            if (teamJoins[i].ready == false || token != 1)
            {
                allready = false;

            }
            

           
        }
        
           
        //Step 2 : Decrement timer or reset it.
        if (allready == true)
        {
            timeBegin -= Time.deltaTime;
            TimerHolder.SetActive(true);
        }
        else
        {
            timeBegin = timer;
            TimerHolder.SetActive(false);
        }

        //Step 3 : Begin the goddamn thing
        if(timeBegin < 0)
        {
            for (int i = 0; i < teamJoins.Count; i++)
            {
                if (teamJoins[i].TeamIndex == -1)
                {
                    MatchManager.instance.HumanIndex = teamJoins[i].playerIndx;
                }
            }
            MatchManager.instance.Players = Player_IM.playerCount;
            HelpButton.RestartGame();
            
        }



    }
}

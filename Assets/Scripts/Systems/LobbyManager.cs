using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyManager : MonoBehaviour
{
    public List<TeamJoinController> teamJoins;
    public PlayerInputManager Player_IM;
    public HelperScriptButton HelpButton;
    public bool canBegin;
    private bool allready;

    public float timer;
    private float timeBegin;
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
        for(int i = 0; i < teamJoins.Count; i++)
        {
            if(teamJoins[i].ready == false)
            {
                allready = false;
            }
        }

        //Step 2 : Decrement timer or reset it.
        if (allready == true)
        {
            timeBegin -= Time.deltaTime;
        }
        else
        {
            timeBegin = timer;
        }

        //Step 3 : Begin the goddamn thing
        if(timeBegin < 0)
        {
            for (int i = 0; i < teamJoins.Count; i++)
            {
                if (teamJoins[i].TeamIndex == 1)
                {
                    MatchManager.instance.HumanIndex = teamJoins[i].playerIndx;
                }
            }
            MatchManager.instance.Players = Player_IM.playerCount;
            HelpButton.RestartGame();
            
        }



    }
}

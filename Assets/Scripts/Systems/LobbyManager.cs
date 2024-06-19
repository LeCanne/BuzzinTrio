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
    public GameObject tutorial;
    public AudioSource menuMusic;
    public TMP_Text Timer;
    public bool canBegin;
    private bool allready;

    public float timer;
    private float timeBegin;
    public float token;
    public bool load;

    public Animator anim;
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

       
        if(timeBegin > 0.1f)
        {
            Timer.text = timeBegin.ToString("F0");
        }
        else
        {
            Timer.text = "0";
        }
        if(load == true)
        {
            menuMusic.volume = Mathf.Lerp(menuMusic.volume, 0, 3 * Time.deltaTime);
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
            InputSystem.DisableAllEnabledActions();
            MatchManager.instance.actionUI.Enable();
            if(load == false)
            {
                StartCoroutine(Transition());
                load = true;
            }
           
           
            
        }



    }

    public IEnumerator Transition()
    {
        anim.SetTrigger("GameBegin");
        yield return new WaitForSeconds(3);
        tutorial.SetActive(true);
        yield return new WaitForSeconds(3);
        HelpButton.RestartGame();
    }
}

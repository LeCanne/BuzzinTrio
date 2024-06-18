using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIndexCheck : MonoBehaviour
{
    public PlayerInputManager _inputManager;
    public static PlayerIndexCheck instance;

    [Header("Players")]
    public GameObject Moskito;
    public GameObject Player;
    public GameObject UI;
    public int MoskitoCameraCheck;

    [Header("Debug")]
    public bool debug;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        _inputManager = GetComponent<PlayerInputManager>();
        MoskitoCameraCheck = 0;
        if (instance == null)
        {
            instance = this;
        }
        
       

        DontDestroyOnLoad(gameObject);
       
    }

    public void Update()
    {
        if(debug == true)
        {
            if (_inputManager.playerCount >= 1)
            {
                _inputManager.playerPrefab = Moskito;
            }
            else
            {
                _inputManager.playerPrefab = Player;
            }
        }
       
    }
    public void ExecuteSpawns()
    {
        int scale = 0;
        MoskitoCameraCheck = 0;
        if(debug == false)
        {
            
            _inputManager.joinBehavior = PlayerJoinBehavior.JoinPlayersManually;
            for (int i = 0; i < MatchManager.instance.Players; i++)
            {

                Debug.Log(MatchManager.instance.HumanIndex);
                if (_inputManager.playerCount == MatchManager.instance.HumanIndex)
                {

                    _inputManager.playerPrefab = Player;
                    _inputManager.JoinPlayer(i, 0, null, GameManager.instance.indexControllers[i]);
                }
                else
                {
                    _inputManager.playerPrefab = Moskito;
                    _inputManager.JoinPlayer(i, 0, null, GameManager.instance.indexControllers[i]);
                    MoskitoCameraCheck += 1;



                }


            }
            
            
                scale = 50 * MoskitoCameraCheck - 1;
           
                MatchManager.instance.HP = MatchManager.instance.MaxHP + scale;
            
                
            
           
            
            MatchManager.instance.lives = MatchManager.instance.maxLives * MoskitoCameraCheck;
        }
        else
        {
            MatchManager.instance.lives = 10;
            MatchManager.instance.HP = 100;
        }
      
       
       
    }

    public void RestartObject()
    {
        _inputManager.joinBehavior = PlayerJoinBehavior.JoinPlayersWhenButtonIsPressed;
        _inputManager.playerPrefab = UI;
        _inputManager.DisableJoining();
        MoskitoCameraCheck = 0;
        GameManager.instance.indexControllers.Clear();
       
    }

   





}

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
        MoskitoCameraCheck = 0;
        if (instance == null)
        {
            instance = this;
        }
        
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
       
    }

    public void ExecuteSpawns()
    {
        if(debug == false)
        {
            _inputManager = GetComponent<PlayerInputManager>();
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
        }
        else
        {


            if(_inputManager.playerCount > 1)
            {
                _inputManager.playerPrefab = Moskito;
            }
            else
            {
                _inputManager.playerPrefab = Player;
            }
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

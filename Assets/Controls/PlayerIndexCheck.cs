using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIndexCheck : MonoBehaviour
{
    private PlayerInputManager _inputManager;

    [Header("Players")]
    public GameObject Moskito;
    public GameObject Player;
    public int MoskitoCameraCheck;

    private void Awake()
    {
        
   
        _inputManager = GetComponent<PlayerInputManager>();
        for (int i = 0; i < MatchManager.instance.Players; i++)
        {
           
            Debug.Log(MatchManager.instance.HumanIndex);
            if (_inputManager.playerCount == MatchManager.instance.HumanIndex)
            {
                
                _inputManager.playerPrefab = Player;
                _inputManager.JoinPlayer(i);
            }
            else
            {
                _inputManager.playerPrefab = Moskito;
                _inputManager.JoinPlayer(i);
                MoskitoCameraCheck += 1;
                
                

            }
           

        }
    }

    



}

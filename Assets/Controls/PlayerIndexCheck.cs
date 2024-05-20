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

    private void Awake()
    {
        _inputManager = GetComponent<PlayerInputManager>();
    }

    public void LateUpdate()
    {
        if(_inputManager.playerCount < 1)
        {
            _inputManager.playerPrefab = Player;
        }
        else
        {
         
            _inputManager.playerPrefab = Moskito;
        }
    }



}

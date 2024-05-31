using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header ("Dependencies")]
    public List<Button> MainMenuButtons;
    public EventSystem eventSystem;
    public Animator animator;

    [Header ("MultiplayerSelection")]
    public GameObject PlayerJoin;
    public PlayerInputManager pInputManager;
    

    void Start()
    {
        PlayerIndexCheck.instance.RestartObject();
        PlayerIndexCheck.instance._inputManager.joinBehavior = PlayerJoinBehavior.JoinPlayersWhenButtonIsPressed;
    }


    void Update()
    {
        
    }

    public void ToLobby()
    {
        animator.SetTrigger("Lobby");
        PlayerJoin.SetActive(true);
        PlayerIndexCheck.instance._inputManager.enabled = true;
        foreach(Button button in MainMenuButtons)
        {
            button.enabled = false;
        }
    }

    public void ToMainMenu()
    {
        pInputManager.enabled = false;
        animator.SetTrigger("MainMenu");
        PlayerJoin.SetActive(false);
        
        foreach (Button button in MainMenuButtons)
        {
            button.enabled = true;
        }
        eventSystem.currentSelectedGameObject.Equals(MainMenuButtons[0].gameObject);

    }
}

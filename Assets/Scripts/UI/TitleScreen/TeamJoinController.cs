using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TeamJoinController : MonoBehaviour
{
    public float TeamIndex;
    public int playerIndx;
    public Image img;
    public GameObject readyImage;
    public PlayerInput playerInput;
    public Vector3 currentpos;
    
    public PlayerInputManager playerInputManager;
    public LobbyManager lobbyManager;
    

    [Header("KeepPositions")]
    public GameObject MainOutline;
    private Transform outline;
    public GameObject LeftMost, RightMost, Center;
    private Transform left, right,center;   
    public GameObject TextRef;

    [Header("Conditions")]
    public bool ready;
    private void Awake()
    {
      
        playerIndx = playerInput.playerIndex;
        ready = false;
        gameObject.transform.SetParent(GameObject.FindWithTag("RecievePlayers").transform);
        lobbyManager = GameObject.FindWithTag("LobbyManager").GetComponent<LobbyManager>();
       
       
    }
    void Start()
    {
        Debug.Log(playerInput.GetDevice<InputDevice>());
        GameManager.instance.indexControllers.Add(playerInput.GetDevice<InputDevice>());
        lobbyManager.teamJoins.Add(this);
        outline = MainOutline.transform;
        center = Center.transform;
        left = LeftMost.transform;
        right = RightMost.transform;
    }

    


    // Update is called once per frame
    void Update()
    {
        CheckTeamPos();
        CheckPlayerColor();
    }

    void CheckTeamPos()
    {
        switch (TeamIndex)
        {
            case -1:
                outline.position = Vector3.Lerp(outline.position, left.position, 5 * Time.deltaTime);
                break;

            case 0:
                outline.position = Vector3.Lerp(outline.position, center.position, 5 * Time.deltaTime);
                break;

            case 1:
                outline.position = Vector3.Lerp(outline.position, right.position, 5 * Time.deltaTime);
                break;

        }
           
        

    }

    void CheckPlayerColor()
    {
        switch (playerInput.playerIndex)
        {
            case 0:
                img.color = Color.red;
                break;

            case 1:
                img.color = Color.blue;
                break;

            case 2:
               img.color = Color.green;
                break;

            case 3:
                img.color = Color.yellow;
                break;

        }
    }

    public void RightMovement(InputAction.CallbackContext input)
    {
       
        if (input.performed && ready == false)
        {
           
            if (TeamIndex < 1)
            {
                TeamIndex += 1;
            }
        }
    }

    public void LeftMovement(InputAction.CallbackContext input)
    {
        if (input.performed && ready == false)
        {
            if (TeamIndex > -1)
            {
                TeamIndex -= 1;
            }
        }
    }

    public void Ready(InputAction.CallbackContext input)
    {
       
        if (input.performed)
        {
           
            if (TeamIndex != 0)
            {
                ready = !ready;
            }
          
            
                readyImage.SetActive(ready);
                
            
        }
       
    }

    public void JoinGame(InputAction.CallbackContext input) 
    {
        TextRef.SetActive(false);
        MainOutline.SetActive(true);
    }


}

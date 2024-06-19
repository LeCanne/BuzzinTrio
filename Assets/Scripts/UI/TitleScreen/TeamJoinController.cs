using System.Collections;
using System.Collections.Generic;


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
    public List<Sprite> spriteList;
    public List<Sprite> spriteList2;
    

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
        gameObject.transform.localScale = Vector3.one;
        Debug.Log(playerInput.GetDevice<InputDevice>());
        GameManager.instance.indexControllers.Add(playerInput.GetDevice<InputDevice>());
        lobbyManager.teamJoins.Add(this);
        outline = MainOutline.transform;
        center = Center.transform;
        left = LeftMost.transform;
        right = RightMost.transform;
        playerInput.actions.Enable();
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
                img.sprite = spriteList[0];
                readyImage.GetComponent<Image>().sprite = spriteList2[0];
                break;

            case 1:
                img.sprite = spriteList[1];
                readyImage.GetComponent<Image>().sprite = spriteList2[1];
                break;

            case 2:
                img.sprite = spriteList[2];
                readyImage.GetComponent<Image>().sprite = spriteList2[2];
                break;

            case 3:
                img.sprite = spriteList[3];
                readyImage.GetComponent<Image>().sprite = spriteList2[3];
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
          
            if(TeamIndex == -1)
            {
                if (ready == false)
                    lobbyManager.token -= 1;

                
                if (ready == true)
                    lobbyManager.token += 1;
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

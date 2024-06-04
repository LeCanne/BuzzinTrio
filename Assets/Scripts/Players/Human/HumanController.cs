using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanController : MonoBehaviour
{
    [Header("Physics")]
    public float Speed;
    private MoskitoControls m_Controls;
    private Rigidbody rbPlayer;
    public float Deceleration;

    [Header ("Dependencies")]
    public GameObject Camera;
    public Animator _Animator;

    
    
    private Vector2 moveForce;

    
   
    // Start is called before the first frame update
    private void Awake()
    {
        
        rbPlayer = GetComponent<Rigidbody>();
        transform.position = GameObject.FindWithTag("PlayerSpawn").transform.position;
        

    }

    private void OnEnable()
    {
        
    }
    void Start()
    {
      
    }

    // Update is called once per frame
   

    void Update()
    {
        RotationCam();
        AnimationProcess();
    }

    void FixedUpdate()
    {
        MovePhysics();
    }

    public void Movement(InputAction.CallbackContext joystickmove)
    {
        moveForce = joystickmove.ReadValue<Vector2>();


    }

    public void Pause(InputAction.CallbackContext Paused)
    {
        if (Paused.performed)
        {
            GameManager.instance.Pause();
        }
    }

    private void AnimationProcess()
    {
        if(moveForce.magnitude > 0)
        {
            _Animator.SetBool("Walkin", true);
        }
        else
        {
            _Animator.SetBool("Walkin", false);
        }

        
    }

    private void MovePhysics()
    {
        if(moveForce.magnitude > 0)
        {
            rbPlayer.AddForce(moveForce.y * transform.forward * Speed, ForceMode.Force);
            rbPlayer.AddForce(moveForce.x * transform.right * Speed, ForceMode.Force);
        }
     
       
    }

    private void RotationCam()
    {
        transform.eulerAngles = new Vector3(0, Camera.transform.eulerAngles.y, 0); 
    }
}

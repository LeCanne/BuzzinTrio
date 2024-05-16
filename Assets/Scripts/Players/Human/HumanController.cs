using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanController : MonoBehaviour
{
    [Header("Physics")]
    public float Speed;
    private MoskitoControls m_Controls;
    private Rigidbody rbPlayer;
    
    
    private Vector2 moveForce;

    
   
    // Start is called before the first frame update
    private void Awake()
    {
        
        rbPlayer = GetComponent<Rigidbody>();
        

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
        
    }

    void FixedUpdate()
    {
        MovePhysics();
    }

    public void Movement(InputAction.CallbackContext joystickmove)
    {
        moveForce = joystickmove.ReadValue<Vector2>();


    }

    private void MovePhysics()
    {
        rbPlayer.AddForce(moveForce.y * transform.forward * Speed, ForceMode.Force);
        rbPlayer.AddForce(moveForce.x * transform.right * Speed, ForceMode.Force);
    }

    private void RotationCam()
    {

    }
}

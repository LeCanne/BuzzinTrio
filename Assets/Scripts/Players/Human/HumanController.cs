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
    private InputAction move;
    
    private Vector2 moveForce;

    
   
    // Start is called before the first frame update
    private void Awake()
    {
        m_Controls = new MoskitoControls();
        rbPlayer = GetComponent<Rigidbody>();
        move = m_Controls.Human.Walk;

    }

    private void OnEnable()
    {
        move.Enable();
    }
    void Start()
    {
      
    }

    // Update is called once per frame
   

    void Update()
    {
        Movement();
    }

    void FixedUpdate()
    {
        MovePhysics();
    }

    private void Movement()
    {
        moveForce = move.ReadValue<Vector2>();


    }

    private void MovePhysics()
    {
        rbPlayer.AddForce(moveForce.y * transform.forward * Speed, ForceMode.Force);
        rbPlayer.AddForce(moveForce.x * transform.right * Speed, ForceMode.Force);
    }
}

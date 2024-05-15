using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoskitoController : MonoBehaviour
{

    private Rigidbody rbMoskito;


    [Header("PhysicsChecks")]
    public LayerMask maskToCheck;
    public float RaycastGroundCheckLenght;
    public float maxVelocity;
    [Range(0, 1)] public float smoothVelocitor;

    [Header("CharacterMovement")]
    public MoskitoControls MoskControls;
    private InputAction _move;
    private InputAction _fly;
    private Vector2 _moveDirection = Vector2.zero;

    [Header("Checker")]
    private bool _inFly;

    private void Awake()
    {
        MoskControls = new MoskitoControls();
    }
    private void OnEnable()
    {
        _move = MoskControls.Moskito.Move;
        _fly = MoskControls.Moskito.Fly;
    }
    // Start is called before the first frame update
    void Start()
    {
        rbMoskito = GetComponent<Rigidbody>();
        _move.Enable();
        _fly.Enable();
    }

    // Update is called once per frame
    void Update()
    {
      
        Movement();
    }

    private void FixedUpdate()
    {
        PhysicsUpdater();
        AirResistance();
    }

    #region Physics
    public bool Grounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, RaycastGroundCheckLenght, maskToCheck))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            return true;

        }
        else
        {

            return false;
        }

    }

    public void AirResistance()
    {
        var rb = rbMoskito;
        var p = 1.225f;
        var cd = .47f;
        var a = Mathf.PI * 1.2f * 1.2f;
        var v = rb.velocity.magnitude;

        var direction = -rb.velocity.normalized;
        var forceAmount = (p * v * v * cd * a) / 2;
        rb.AddForce(direction * forceAmount);
    }

    private void PhysicsUpdater()
    {
        //Apply Gravity.

        if (Grounded() == false && rbMoskito.velocity.y < 0)
        {
            if (rbMoskito.useGravity == true)
            {
                rbMoskito.AddForce(Physics.gravity, ForceMode.Acceleration);
                Mathf.Clamp(Mathf.Abs(rbMoskito.velocity.y), 0, 1);
                Debug.Log(rbMoskito.velocity.y);
            }
        }

        //Clamp the Max Velocity.

        if (rbMoskito.velocity.sqrMagnitude > maxVelocity)
        {
            //smoothness of the slowdown is controlled by the 0.99f, 
            //0.5f is less smooth, 0.9999f is more smooth
            rbMoskito.velocity *= 0.99f;
        }
    }
    #endregion 

    private void Movement()
    {
        _moveDirection = _move.ReadValue<Vector2>();

        

        JumpStart();
    }

    private void JumpStart()
    {
        if(Grounded() == true)
        {
            if (_fly.triggered)
            {
                rbMoskito.AddForce(new Vector3(0,10,0), ForceMode.Impulse);
                _inFly = true;
                
            }
        }

        //Change gravity according to state.
        _inFly = true ? rbMoskito.useGravity = false : rbMoskito.useGravity = true;


    }
}

   

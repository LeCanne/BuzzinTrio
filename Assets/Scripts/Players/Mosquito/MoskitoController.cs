using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoskitoController : MonoBehaviour
{

    private Rigidbody rbMoskito;
    [Header("PhysicsParameters")]
    public float flyDrag;
    public float groundDrag;
    public float InitialLift;
    public GameObject Camera;

    [Header("PhysicsChecks")]
    public LayerMask maskToCheck;
    public float RaycastGroundCheckLenght;
    public float maxVelocity;
    [Range(0, 1)] public float smoothVelocitor;

    [Header("CharacterMovement")]
    public MoskitoControls MoskControls;
    private InputAction _move;
    private InputAction _fly;
    private InputAction _attack;
    private Vector2 _moveDirection = Vector2.zero;
    public float FlightSpeed;
    public float AttackBoostSpeed;
    

    [Header("Checker")]
    private bool _inFly;
    private float attackTimer;
    private float attackCurrent;
    public float attackDuration;
    
    [Header("AttachedObjects")]
    public GameObject HitBox;
    public PlayerInput Input;
    

    private void Awake()
    {
      
        
    }
    private void OnEnable()
    {

        MoskControls = new MoskitoControls();
        Input.actions = MoskControls.asset;

        _move = MoskControls.Moskito.Move;
        _fly = MoskControls.Moskito.Fly;
        _attack = MoskControls.Moskito.Sting;
    }

    private void OnDisable()
    {
        _move.Disable();
        _fly.Disable();
        _attack.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {

        

        rbMoskito = GetComponent<Rigidbody>();
        _move.Enable();
        _fly.Enable();
        _attack.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.rotation = Camera.transform.rotation;
        Movement();
        if(_inFly == true)
        {
            StingAttack();
        }
      
    }

    private void FixedUpdate()
    {
        PhysicsUpdater();
        MovementPhysics();
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

  
    private void MovementPhysics()
    {
        if (_inFly == true)
        {
            rbMoskito.AddForce(transform.forward * _moveDirection.y * 10);
            rbMoskito.AddForce(transform.right * _moveDirection.x * 10);
        }
      
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

    #region Movement&PlayerCapacities 
    private void Movement()
    {
        _moveDirection = _move.ReadValue<Vector2>();
      

        
        //JumpStartCalculations
        JumpStart();
    }

    private void StingAttack()
    {
        if (_attack.triggered && attackTimer < 0)
        {
            attackTimer = 3;
            rbMoskito.AddForce(transform.forward * AttackBoostSpeed , ForceMode.Impulse);
            attackCurrent = attackDuration;
            HitBox.SetActive(true);
        }

        if(attackTimer >= 0)
        {
            attackTimer -= Time.deltaTime;
        }

        if(attackCurrent <= 0)
        {
            HitBox.SetActive(false);
        }
        else
        {
            attackCurrent -= Time.deltaTime;
        }
       
    }
    private void JumpStart()
    {
        
        if (_fly.triggered)
        {
            Debug.Log("ye");
            if (Grounded() == true)
            {
                rbMoskito.AddForce(new Vector3(0, InitialLift, 0), ForceMode.Impulse);
                _inFly = true;
               
            }
            else
            {
                
                    _inFly = !_inFly;
               
               

            }

        }





        //Change gravity according to state.
        if (_inFly == true)
        {
            rbMoskito.drag = flyDrag;
            rbMoskito.useGravity = false;

        }
        else
        {
            rbMoskito.drag = groundDrag;
            rbMoskito.useGravity = true;
        }
          


    }

    
    #endregion
}



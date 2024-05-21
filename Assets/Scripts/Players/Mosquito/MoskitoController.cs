using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class MoskitoController : MonoBehaviour
{

    private Rigidbody rbMoskito;
    [Header("PhysicsParameters")]
    public float flyDrag;
    public float groundDrag;
    public float InitialLift;
    public GameObject Camera;
    [HideInInspector] public Collider _collider;

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
    [HideInInspector] public bool _inFly;
    private float attackTimer;
    private float attackCurrent;
    public float attackDuration;
    public bool dead;
    
    [Header("AttachedObjects")]
    public GameObject HitBox;
    public PlayerInput Input;
    

    private void Awake()
    {

        rbMoskito = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
    }
    private void OnEnable()
    {

     

       
    }

    private void OnDisable()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnManager.Instance.SpawnMe(gameObject);
        

       
      

    }

    // Update is called once per frame
    void Update()
    {
        if(dead == false)
        {
            if (_inFly == true)
            {
                StingAttack();
            }
        }
        
        transform.rotation = Camera.transform.rotation;
       
      
      
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
        if (_inFly == true && dead == false)
        {
            rbMoskito.AddForce(transform.forward * _moveDirection.y * FlightSpeed);
            rbMoskito.AddForce(transform.right * _moveDirection.x * FlightSpeed);
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
    public void Movement(InputAction.CallbackContext move)
    {

        _moveDirection = move.ReadValue<Vector2>();
      

        
        //JumpStartCalculations
       
    }

    public void AttackEvent(InputAction.CallbackContext attack)
    {
        if (attack.started && attackTimer < 0)
        {
            attackTimer = 3;
            rbMoskito.AddForce(transform.forward * AttackBoostSpeed, ForceMode.Impulse);
            attackCurrent = attackDuration;
            HitBox.SetActive(true);
        }
    }
    private void StingAttack()
    {
       
        if(dead == false)
        {
            if (attackTimer >= 0)
            {
                attackTimer -= Time.deltaTime;
            }

            if (attackCurrent <= 0)
            {
                HitBox.SetActive(false);
            }
            else
            {
                attackCurrent -= Time.deltaTime;
            }
        }
      
       
    }
    public void JumpStart(InputAction.CallbackContext Fly)
    {


        if (Fly.performed && enabled == true && dead == false)
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







        //Change gravity according to state.
      
          


    }


    
    
    #endregion
}



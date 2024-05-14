using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MoskitoController : MonoBehaviour
{

    private Rigidbody rbMoskito;


    [Header("PhysicsChecks")]
    public LayerMask maskToCheck;
    public float RaycastGroundCheckLenght;

    // Start is called before the first frame update
    void Start()
    {
        rbMoskito = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PhysicsUpdater();
        Movement();
    }

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

    private void PhysicsUpdater()
    {
        //Apply Gravity

        if(Grounded() == false && rbMoskito.velocity.y < 0)
        {
            rbMoskito.AddForce(Physics.gravity, ForceMode.Acceleration);
        }
    }

    private void Movement()
    {

    }
}

   

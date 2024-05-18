using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackHuman : MonoBehaviour
{
    private Camera _camera;
    public float interactionDistance;
   
   
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    
    void Update()
    {

        Debug.DrawRay(transform.position, transform.forward * interactionDistance, Color.green);
    }

    public void Attack(InputAction.CallbackContext slap)
    {
        if (slap.performed)
        {
            RaycastHit hit;
           
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
            {
                Debug.Log("hit");
             
                if (hit.collider.tag == "Moskito")
                {
                    
                    hit.transform.gameObject.transform.GetComponentInParent<MoskitoGeneral>().Die();
                }
            }
        }
      
    }
}

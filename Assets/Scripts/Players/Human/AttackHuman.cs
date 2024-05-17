using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackHuman : MonoBehaviour
{
    private Camera _camera;
    public float interactionDistance;
    public float width;
   
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    
    void Update()
    {
       
    }

    public void Attack(InputAction.CallbackContext slap)
    {
        if (slap.performed)
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, width, transform.forward, out hit, interactionDistance))
            {
                Debug.Log("hit");
                if (hit.collider.tag == "Moskito")
                {
                    
                    hit.transform.gameObject.GetComponent<MoskitoGeneral>().Die();
                }
            }
        }
      
    }
}

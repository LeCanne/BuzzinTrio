using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackHuman : MonoBehaviour
{
    private Camera _camera;
    public float interactionDistance;
    public Animator animaionhit;
   
   
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
            animaionhit.SetTrigger("Hit");
            RaycastHit hit;
           
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
            {
                
             
                if (hit.collider.tag == "Moskito" || hit.collider == null)
                {
                    Debug.Log("HitAnything");
                    hit.transform.gameObject.transform.GetComponentInParent<MoskitoGeneral>().Die();
                }
                if(hit.collider.tag == "Untagged")
                {
                    Debug.Log("HitWall");
                }
                
            }
        }
      
    }
}

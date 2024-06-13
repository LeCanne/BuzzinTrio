using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackHuman : MonoBehaviour
{
    private Camera _camera;
    public float interactionDistance;
    public Animator animaionhit;
    public LayerMask layermask;

    [Header("Attack Priority")]
    private float timerCurrent;
    public float timer;
    public float reduction;
    private bool attack;
    public bool attacking;  

    [Header("DataAttack")]
    private float timeBetweenAttacks;
    private bool checkDelay;
    private float delayedTimer;

  
   
   
    void Start()
    {
        attack = false;
        timerCurrent = 0;
        
        _camera = GetComponent<Camera>();
    }

    
    void Update()
    {
        
        Debug.DrawRay(transform.position, transform.forward * interactionDistance, Color.green);
        CdAttack();
    }

    void CdAttack()
    {
        timeBetweenAttacks += Time.deltaTime;


       
        if (attack == true)
        {
            
            


            timerCurrent -= Time.deltaTime;
               


            
            if(timerCurrent < 0)
            {
              
               
               
                attack = false;
                timerCurrent = delayedTimer;
               
                
            }
        }
    }

    public void Attack(InputAction.CallbackContext slap)
    {

       
        if (slap.performed && attack == false)
        {
            
            animaionhit.SetTrigger("Hit");



            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, layermask))
            {

                Debug.Log(hit.collider.tag);
                //if (hit.collider.tag == "Moskito" || hit.collider == null)
                //{

                //    hit.transform.gameObject.transform.GetComponentInParent<MoskitoGeneral>().Die();
                //}
                if (hit.collider.tag == "Untagged")
                {
                    
                }

            }


            //Check Time Between each attacks and apply cooldown
            if (timeBetweenAttacks < 1)
            {

                timerCurrent += 0.05f;
                delayedTimer = timerCurrent;
                
            }
            if (timeBetweenAttacks >= 1)
            {
                
                timerCurrent = 0f;
                delayedTimer = 0f;
            }
            timeBetweenAttacks = 0;

            attack = true;
        }
      
    }

    public void Death(Collider hit)
    {
        if (attacking == true)
        hit.gameObject.GetComponentInParent<MoskitoGeneral>().Die();
    }
}

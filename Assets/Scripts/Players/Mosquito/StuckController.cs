using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StuckController : MonoBehaviour
{
    [Header ("Dependencies")]
    private MoskitoControls m_Controls;
    private MoskitoController _MoskitoController;
    public MoskitoCamera moskitoCamera;
    private Rigidbody rigidMoskito;
    private InputAction _spam;
    public Collider _collider;
    public PlayerInput player;
    [Header("Parameters")]
    public float suckspeed;
    public int SpamCount;
    private bool pumping;
    private bool max;
    private int spamCurrent;
    [Header("Damager Bool")]
    [HideInInspector] public bool HumanHit;
    [Header("UI Management")]
    public GameObject healthbar;
    public Slider BloodSlider;
    public Slider StockSlider;
    [Header("Damager")]
    public float OverallDamage;
    public float damage;
    




    // Start is called before the first frame update
    private void Awake()
    {
        OverallDamage = StockSlider.maxValue;
        damage = OverallDamage;
        BloodSlider.maxValue = StockSlider.maxValue;
        _MoskitoController = GetComponent<MoskitoController>();
        rigidMoskito = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        
        _collider.enabled = false;
        rigidMoskito.isKinematic = true;
        _MoskitoController._collider.isTrigger = true;
        _MoskitoController.HitBox.SetActive(false);
        // player.actions = m_Controls.asset;
    }

    private void OnDisable()
    {
        _collider.enabled = true;
       
    }
    void Start()
    {
      
        
        rigidMoskito = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (HumanHit == true)
        {
            healthbar.SetActive(true);
            

        }
        if (pumping == true)
        {
            Increase();
        }
      
      
    }

    public void Unstuck(InputAction.CallbackContext punchawall)
    {
        if (punchawall.performed && enabled == true)
        {



            if(HumanHit == false)
            {
                if (spamCurrent < SpamCount)
                {
                    spamCurrent++;
                }
                else
                {
                    Unstucked();
                }
            }
           
                
            
        }

        

    }

    public void Suck(InputAction.CallbackContext suck)
    {
        if(HumanHit == true)
        {
            
            if (suck.performed && enabled == true)
            {
                pumping = true;
               
            }
            if (suck.canceled && enabled == true)
            {
                if (HumanHit == true)
                {
                    Debug.Log("yesss");
                    Succ();
                    pumping = false;
                }
            }
        }
      
    }


    private void Succ()
    {
        DamagePlayer();
        max = false;
       
      
        

      

        Unstucked();

    }


    public void Increase()
    {
        if(max == false)
        {
            if (BloodSlider.value < BloodSlider.maxValue)
            {
                BloodSlider.value += suckspeed * Time.deltaTime;

            }
            else
            {
                max = true;
            }
        }
        else
        {
            if (BloodSlider.value > 0)
            {
                BloodSlider.value -= suckspeed * Time.deltaTime;

            }
            else
            {
                max = false;
            }
        }
       
      
    }

   

    public void Unstucked() 
    {
        rigidMoskito.isKinematic = false;
        _MoskitoController.enabled = true;
        _MoskitoController._collider.isTrigger = false;
        rigidMoskito.AddForce(-transform.forward * 10, ForceMode.Impulse);

        spamCurrent = 0;
        gameObject.transform.parent = null;
        moskitoCamera.checkStung = false;
        this.enabled = false;
    }

    public void DamagePlayer()
    {
        StockSlider.value += BloodSlider.value;
        if (damage < BloodSlider.value)
        {
            MatchManager.instance.HP -= damage;
        }
        else
        {
            MatchManager.instance.HP -= BloodSlider.value;
            damage -= BloodSlider.value;
        }
     
        
        BloodSlider.value = 0;
    }

    public void ResetDamage()
    {
        damage = OverallDamage;
    }

    

}

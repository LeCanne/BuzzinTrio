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
    public GameObject mash;
    [Header("Parameters")]
    public float suckspeed;
    public int SpamCount;
    private bool pumping;
    private bool max;
    private int token;
    private int spamCurrent;
    [Header("Damager Bool")]
    [HideInInspector] public bool HumanHit;
    [Header("UI Management")]
    public GameObject healthbar;
    public Slider BloodSlider;
    public Slider StockSlider;
    public Image mat;
    [Header("Damager")]
    public float OverallDamage;
    public float damage;
    




    // Start is called before the first frame update
    private void Awake()
    {
        OverallDamage = StockSlider.maxValue;
        damage = OverallDamage;
        BloodSlider.maxValue = MatchManager.instance.MaxHP;
        _MoskitoController = GetComponent<MoskitoController>();
        rigidMoskito = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        mash.SetActive(true);
        rigidMoskito.velocity = Vector3.zero;
        rigidMoskito.isKinematic = true;
        _MoskitoController._collider.isTrigger = true;
        _MoskitoController.HitBox.SetActive(false);
        
    }

    private void OnDisable()
    {
        _collider.enabled = true;
        mash.SetActive(false);


    }
    void Start()
    {
      
        
        rigidMoskito = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {

        mat.materialForRendering.SetFloat("_progress_segmentremoval", 5 - spamCurrent);


        //if (pumping == true)
        //{
        //    Increase();
        //}
        if(_MoskitoController.dead == true)
        {
            Unstucked();
        }

    }

    public void Unstuck(InputAction.CallbackContext punchawall)
    {
        if (punchawall.performed && enabled == true)
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

    public void Suck(InputAction.CallbackContext suck)
    {
        if(HumanHit == true)
        {
            
            if (suck.performed && enabled == true)
            {
                Succ();

            }
            
        }
      
    }


    private void Succ()
    {
        
        DamagePlayer();
        
       
      
        

      

       

    }


    //public void Increase()
    //{
    //    if(max == false)
    //    {
    //        if (BloodSlider.value < BloodSlider.maxValue)
    //        {
    //            BloodSlider.value += suckspeed * Time.deltaTime;

    //        }
    //        else
    //        {
    //            max = true;
    //        }
    //    }
    //    else
    //    {
    //        if (BloodSlider.value > 0)
    //        {
    //            BloodSlider.value -= suckspeed * Time.deltaTime;

    //        }
    //        else
    //        {
    //            max = false;
    //        }
    //    }
       
      
    //}

   

    public void Unstucked() 
    {
        _collider.enabled = false;
        token = 0;
        rigidMoskito.isKinematic = false;
        _MoskitoController.enabled = true;
        _MoskitoController._collider.isTrigger = false;
        rigidMoskito.AddForce(-transform.forward * 10, ForceMode.Impulse);
        HumanHit = false;
        spamCurrent = 0;
        gameObject.transform.parent = null;
        moskitoCamera.checkStung = false;
        this.enabled = false;
    }

    public void DamagePlayer()
    {
      
        
       
        
            MatchManager.instance.HP -= damage * 0.25f;



        StockSlider.value += 1;
        BloodSlider.value += damage * 0.25f;
    }

    //public void ResetDamage()
    //{
    //    damage = OverallDamage;
    //}

    

}

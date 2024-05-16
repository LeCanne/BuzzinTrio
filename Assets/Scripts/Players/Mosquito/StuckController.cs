using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class StuckController : MonoBehaviour
{
    [Header ("Dependencies")]
    private MoskitoControls m_Controls;
    private MoskitoController _MoskitoController;
    public MoskitoCamera moskitoCamera;
    private Rigidbody rigidMoskito;
    private InputAction _spam;
    private int spamCurrent;
    public PlayerInput player;
    [Header ("Parameters")]
    public int SpamCount;
    // Start is called before the first frame update
    private void Awake()
    {

        _MoskitoController = GetComponent<MoskitoController>();
    }

    private void OnEnable()
    {
        m_Controls = _MoskitoController.MoskControls;
        player.actions = m_Controls.asset;
        _spam = m_Controls.Moskito.Sting;
        
        // player.actions = m_Controls.asset;
    }
    void Start()
    {
      
        _spam.Enable();
        rigidMoskito = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        Unstuck();
    }

    private void Unstuck()
    {
        if(spamCurrent < SpamCount)
        {
            if(_spam.triggered)
            spamCurrent += 1;
        }
        else
        {
          
            _MoskitoController.enabled = true;
            rigidMoskito.AddForce(-transform.forward * 10, ForceMode.Impulse);
            
            spamCurrent = 0;
            gameObject.transform.parent = null;
            moskitoCamera.checkStung = false;
            this.enabled = false;

        }
    }

   
}

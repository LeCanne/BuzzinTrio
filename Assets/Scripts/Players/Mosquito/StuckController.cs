using System.Collections;
using System.Collections.Generic;
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
        m_Controls = new MoskitoControls();
        _spam = m_Controls.Moskito.Sting;
        rigidMoskito = GetComponent<Rigidbody>();
        _MoskitoController = GetComponent<MoskitoController>();
        player.actions = m_Controls.asset;
    }

    private void OnEnable()
    {
        _spam.Enable();
       // player.actions = m_Controls.asset;
    }
    void Start()
    {
        
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

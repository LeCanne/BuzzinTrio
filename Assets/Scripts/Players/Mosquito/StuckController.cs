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
        rigidMoskito = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {

        rigidMoskito.isKinematic = true;
        _MoskitoController._collider.isTrigger = true;
        _MoskitoController.HitBox.SetActive(false);
        // player.actions = m_Controls.asset;
    }
    void Start()
    {
      
        
        rigidMoskito = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {

      
    }

    public void Unstuck(InputAction.CallbackContext punchawall)
    {
        if (punchawall.performed && enabled == true)
        {
            if (spamCurrent < SpamCount)
            {

                spamCurrent += 1;
            }
            else
            {
                Unstucked();

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

}

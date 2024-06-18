using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MoskitoGeneral : MonoBehaviour
{
    public MoskitoController _moskControl;
    public StuckController _stuckController;
    public Animator moskitoAnimator;
    private Rigidbody RbMoskito;
    public MoskitoCamera _camera;
    public Camera camera_Asset;
    private Vector3 origin;
    public float RespawnTime;
    private float timeSpent;
    public Slider stock;
    public LayerMask layermaskall;
    public LayerMask layermaskempty;
    private AudioSource audioc;

    public bool deadforgood;
    public ParticleSystem muzzleDed;


    // Start is called before the first frame update
    void Start()
    {
        RbMoskito = GetComponent<Rigidbody>();
        origin = transform.position;
        audioc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Sound();
        if (_moskControl.dead == true)
        {
            timeSpent += Time.deltaTime;
            if(MatchManager.instance.lives > 0)
            {
                if (timeSpent >= RespawnTime)
                {
                    Respawn();
                }
            }
            else
            {
                deadforgood = true;
            }
         
        }

        if(stock.value == stock.maxValue)
        {
            camera_Asset.cullingMask = layermaskall;
        }
        else
        {
            camera_Asset.cullingMask = layermaskempty;
        }

        if(_stuckController.HumanHit == false)
        {
           _stuckController.StockSlider.value = Mathf.Lerp(_stuckController.StockSlider.value, 0, 5 * Time.deltaTime);
        }

        moskitoAnimator.SetBool("Fly", _stuckController.enabled);

        
    }
    public void Sound()
    {
        if(_moskControl.enabled == true)
        {
            if(_moskControl._moveDirection.magnitude > 0)
            {
                audioc.enabled = true;
                
            }
            else
            {
                audioc.enabled = false;
            }
        }
        else
        {
            audioc.enabled = false;
        }

    }
    public void Die()
    {
        muzzleDed.Play();
        _stuckController.Unstucked();

        
        _stuckController._collider.enabled = false;
        stock.value = 0;
        _moskControl.attackTimer = 0;
        _stuckController.HumanHit = false;
        _camera.checkStung = true;
        RbMoskito.useGravity = true;
        _moskControl._inFly = false;
        _moskControl.dead = true;
        _camera.enabled = false;
       // _stuckController.ResetDamage();
        
    }

    public void Respawn()
    {
        _stuckController._collider.enabled = true;
        _moskControl._inFly = true;
        RbMoskito.useGravity = false;
        _camera.checkStung = false;
        _moskControl.dead = false;
        _camera.enabled = true;

        timeSpent = 0;
       
        SpawnManager.Instance.SpawnMe(gameObject);

        
    }

    public void Pausethis(InputAction.CallbackContext pause)
    {
        if (pause.performed)
        {
            GameManager.instance.Pause();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ExtractZone")
        {
            //if(stock.value >= stock.value)
            //{
            //    MatchManager.instance.timerLeft += 10;
            //}
           
            Die();
                   
        }
    }

}

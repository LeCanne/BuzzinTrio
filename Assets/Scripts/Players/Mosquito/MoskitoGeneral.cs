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
    private Rigidbody RbMoskito;
    public MoskitoCamera _camera;
    public Camera camera_Asset;
    private Vector3 origin;
    public float RespawnTime;
    private float timeSpent;
    public Slider stock;
    public LayerMask layermaskall;
    public LayerMask layermaskempty;

    // Start is called before the first frame update
    void Start()
    {
        RbMoskito = GetComponent<Rigidbody>();
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (_moskControl.dead == true)
        {
            timeSpent += Time.deltaTime;

            if(timeSpent >= RespawnTime)
            {
                Respawn();
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
    }

    public void Die()
    {
        _stuckController.Unstucked();

        stock.value = 0;
        _moskControl.attackTimer = 0;
        _stuckController.HumanHit = false;
        _camera.checkStung = true;
        RbMoskito.useGravity = true;
        _moskControl._inFly = false;
        _moskControl.dead = true;
        _camera.enabled = false;
        _stuckController.ResetDamage();
        
    }

    public void Respawn()
    {
        _moskControl._inFly = true;
        RbMoskito.useGravity = false;
        _camera.checkStung = false;
        _moskControl.dead = false;
        _camera.enabled = true;

        timeSpent = 0;
        SpawnManager.Instance.SpawnMe(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ExtractZone")
        {
            if(stock.value >= stock.value)
            {
                MatchManager.instance.timerLeft += 10;
            }
           
            Die();
                   
        }
    }

}

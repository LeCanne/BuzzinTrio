using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoskitoGeneral : MonoBehaviour
{
    public MoskitoController _moskControl;
    public StuckController _stuckController;
    private Rigidbody RbMoskito;
    public MoskitoCamera _camera;
    private Vector3 origin;
    public float RespawnTime;
    private float timeSpent;

    // Start is called before the first frame update
    void Start()
    {
        RbMoskito = GetComponent<Rigidbody>();
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_moskControl.dead == true)
        {
            timeSpent += Time.deltaTime;

            if(timeSpent >= RespawnTime)
            {
                Respawn();
            }
        }
    }

    public void Die()
    {
        _stuckController.Unstucked();

      
       
        _camera.checkStung = true;
        RbMoskito.useGravity = true;
        _moskControl._inFly = false;
        _moskControl.dead = true;
        _camera.enabled = false;
        
    }

    public void Respawn()
    {
        _camera.checkStung = false;
        _moskControl.dead = false;
        _camera.enabled = true;

        timeSpent = 0;
        SpawnManager.Instance.SpawnMe(gameObject);
    }
}

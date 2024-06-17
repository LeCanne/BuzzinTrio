using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MoskitoHit : MonoBehaviour
{
    public MoskitoController moskitoController;
    public StuckController stuckController;
    public Rigidbody rb;
    public MoskitoCamera moskitoCam;
    public GameObject Skito;

    [Header("Visuals")]
    public ParticleSystem impact1;
    public ParticleSystem impact2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Human")
        {
            rb.velocity = Vector3.zero;
            Debug.Log("HitPlayer");
            Skito.transform.parent = other.gameObject.transform;
            moskitoController.enabled = false;
            stuckController.enabled = true;
            stuckController._collider.enabled = false;
            moskitoCam.checkStung = true;
            stuckController.HumanHit = true;
          

        }

        if(other.gameObject.tag == "Untagged")
        {
            impact1.Play();
            impact2.Play();
            rb.velocity = Vector3.zero;
            Debug.Log("HitWall");
            Skito.transform.parent = other.gameObject.transform;
           
            moskitoController.enabled = false;
            stuckController.enabled = true;
            moskitoCam.checkStung = true;
        }
    }
}

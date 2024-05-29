using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoskitoHit : MonoBehaviour
{
    public MoskitoController moskitoController;
    public StuckController stuckController;
    public MoskitoCamera moskitoCam;
    public GameObject Skito;
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
            Debug.Log("HitWall");
            Skito.transform.parent = other.gameObject.transform;
            moskitoController.enabled = false;
            stuckController.enabled = true;
            moskitoCam.checkStung = true;
        }
    }
}

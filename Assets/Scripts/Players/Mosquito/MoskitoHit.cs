using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoskitoHit : MonoBehaviour
{
    public MoskitoController moskitoController;
    public StuckController stuckController;
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
            Debug.Log("hit");
            moskitoController.enabled = false;
            stuckController.enabled = true;
            
        }
    }
}

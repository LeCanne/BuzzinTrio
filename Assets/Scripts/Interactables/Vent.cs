using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    //SusAmogus
    public GameObject EndArea;
    
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
        Debug.Log("other");
        if(other.gameObject.tag == "Moskito")
        {
            other.transform.parent.position = EndArea.transform.position;
            other.transform.parent.GetComponent<MoskitoGeneral>()._camera.gameObject.transform.rotation = EndArea.transform.rotation;
        }
    }

    private void OnDrawGizmos()
    {
        if(EndArea != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, EndArea.transform.position);
        }
    }

}

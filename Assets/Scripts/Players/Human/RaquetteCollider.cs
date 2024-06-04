using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaquetteCollider : MonoBehaviour
{
    public AttackHuman AttackHuman;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("ye");
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Moskito")
        {
            Debug.Log("anothervictoryfortheog");
            AttackHuman.Death(collision);
        }
    }

   
}
  
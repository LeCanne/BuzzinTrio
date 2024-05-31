using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        PlayerIndexCheck.instance.ExecuteSpawns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}

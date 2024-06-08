using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapToggle : MonoBehaviour
{
    public AttackHuman AtkHuman;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackToggle(int boolean)
    {
        if(boolean == 0)
        {
            AtkHuman.attacking = false;
        }
        if(boolean == 1)
        {
            AtkHuman.attacking = true;
        }
      
    }
}

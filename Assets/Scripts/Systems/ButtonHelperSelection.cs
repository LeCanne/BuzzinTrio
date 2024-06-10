using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHelperSelection : MonoBehaviour
{
    public GameObject selectedButton;
    private void OnEnable()
    {
        ButtonSelector.instance.SelectButton(selectedButton);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

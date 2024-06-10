using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelector: MonoBehaviour
{
    private EventSystem eventSystem;
   
    public static ButtonSelector instance;
    // Start is called before the first frame update

    private void Awake()
    {

        if(instance != null && instance != this)
        {
            Destroy(this);
        }   

        if(instance == null)
        {
           instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        eventSystem = GetComponent<EventSystem>();
    }

   public void SelectButton(GameObject select)
   {
        eventSystem.SetSelectedGameObject(select);
   }

    
}

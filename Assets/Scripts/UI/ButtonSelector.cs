using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelector: MonoBehaviour
{
    private EventSystem eventSystem;
   
    public static ButtonSelector instance;
    // Start is called before the first frame update

    private void OnEnable()
    {
      
    }
    private void Awake()
    {
        eventSystem = GetComponent<EventSystem>();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }   

        if(instance == null)
        {
           instance = this;
            DontDestroyOnLoad(gameObject);
        }
      
    }
   
    
       
    

   public void SelectButton(GameObject select)
   {
        eventSystem.SetSelectedGameObject(select);
   }

    
}

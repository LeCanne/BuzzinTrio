using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   
    public List<GameObject> spawns = new List<GameObject>();
    // Start is called before the first frame update

    private void Awake()
    {
    
        DontDestroyOnLoad(gameObject);
    }
  
   
        
    
    void Start()
    {
        
      
    }
   
    
        
    
    void StartGame()
    {
        spawns.Clear();
        spawns.AddRange(GameObject.FindGameObjectsWithTag("Spawns"));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

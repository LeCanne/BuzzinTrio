using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   public static SpawnManager Instance;
    public List<GameObject> spawns = new List<GameObject>();
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
       
    }
  
   
        
    
    void Start()
    {

        StartGame();
    }
   
    
        
    
    void StartGame()
    {
        spawns.Clear();
        spawns.AddRange(GameObject.FindGameObjectsWithTag("Spawns"));
    }

    public void SpawnMe(GameObject obj)
    {
        obj.transform.position = spawns[Random.Range(0, spawns.Count - 1)].transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

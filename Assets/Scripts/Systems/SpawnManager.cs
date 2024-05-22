using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    
   public static SpawnManager Instance;
    public List<GameObject> spawns = new List<GameObject>();
    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
        SceneManager.sceneLoaded += StartGame;
       
    }

   


    void Start()
    {

       
    }
   
    
        
    
    void StartGame(Scene scene, LoadSceneMode load)
    {
        Debug.Log("yes");
        spawns.Clear();
        spawns.AddRange(GameObject.FindGameObjectsWithTag("Spawns"));
    }

    public void SpawnMe(GameObject obj)
    {
        GameObject ovj = spawns[Random.Range(0, spawns.Count - 1)];
        obj.transform.position = ovj.transform.position;
        obj.transform.rotation = ovj.transform.rotation;
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
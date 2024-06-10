using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouSureMenu : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        foreach(GameObject go in gameObjects)
        {
            go.SetActive(false);
        }
    }

    private void OnDisable()
    {
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

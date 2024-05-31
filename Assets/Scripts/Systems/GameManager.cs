using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<InputDevice> indexControllers = new List<InputDevice>();
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if(instance != null && instance != this)
        {
            
            Destroy(gameObject);
        }
               
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopGame()
    {
        MatchManager.instance.TimerOn = false;
        MatchManager.instance.timerLeft = MatchManager.instance.Timer;
        SpawnManager.Instance.spawns.Clear();
        PlayerIndexCheck.instance.RestartObject();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        MatchManager.instance.TimerOn = true;
        MatchManager.instance.timerLeft = MatchManager.instance.Timer;
    }

    public void OnLoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}

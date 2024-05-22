using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
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
    }

    public void StartGame()
    {
        MatchManager.instance.TimerOn = false;
        MatchManager.instance.timerLeft = MatchManager.instance.Timer;
    }

    public void OnLoadScene(int scene)
    {
        SceneManager.LoadScene(0);
    }

}

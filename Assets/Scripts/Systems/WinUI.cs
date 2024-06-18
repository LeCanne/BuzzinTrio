using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{
    public GameObject WinScreenHuman;
    public GameObject WinScreenMoskito;
    public GameObject CameraWin;
    public AudioSource winJingle;
    public Animator animMoskito;
    public Animator animPlayer;
    public Animator transition;

    public List<GameObject> PracticalUI;

    public bool once;
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MatchManager.instance.noTimeLeft == true)
        {
            if(once == false)
            {
                animMoskito.SetTrigger("TriggerLose");
                animPlayer.SetTrigger("TriggerWin");
                StartCoroutine(Win(WinScreenHuman));
                once = true;
            }
            
        }
        if (MatchManager.instance.noHpLeft == true)
        {
            if (once == false)
            {
                animMoskito.SetTrigger("TriggerWin");
                animPlayer.SetTrigger("TriggerLose");
                StartCoroutine(Win(WinScreenMoskito));
                once = true;
            }
            
        }
    }

    public IEnumerator Win(GameObject objecttoSpawn)
    {
        transition.SetTrigger("GameBegin");
        yield return new WaitForSeconds(1.5f);
        CameraWin.SetActive(true);
        foreach (GameObject obj in PracticalUI)
        {
            obj.SetActive(false);
        }
        transition.SetTrigger("GameEnd");
        winJingle.Play();
        yield return new WaitForSeconds(1.5f);
        objecttoSpawn.SetActive(true);
       




    }
}

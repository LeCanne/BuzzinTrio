using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class HelperScriptButton : MonoBehaviour
{
    public void RestartGame()
    {
        GameManager.instance.StartGame();
        MatchManager.instance.RestartMatch();
        GameManager.instance.OnLoadScene(1);
    }

    public void SceneChange(int choosescene)
    {
        MatchManager.instance.StopGame();
        GameManager.instance.OnLoadScene(choosescene);
    }

    public void QuitGame()
    {
        GameManager.instance.QuitGame();
    }
}

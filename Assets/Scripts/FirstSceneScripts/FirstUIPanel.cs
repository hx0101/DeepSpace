using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstUIPanel : MonoBehaviour
{
    public void StartGame()
    {
        GameSelect gameSelect = new GameSelect();
        LoadManager.Instance.LoadNextLevel(gameSelect.SceneName, gameSelect);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

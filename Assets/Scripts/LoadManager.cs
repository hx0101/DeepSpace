using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : Singleton<LoadManager>
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void LoadNextLevel(string sceneName,SceneBase sceneBase)
    {
        StartCoroutine(SceneControl.GetInstance().LoadLevel(sceneName, sceneBase, new LoadPanel()));
    }

    public void LoadNextPanel(BasePanel basePanel)
    {
        StartCoroutine(LoadMainInterfacePanel(basePanel));
    }

    public IEnumerator LoadMainInterfacePanel(BasePanel basePanel)
    {
        yield return new WaitForSeconds(0.01f);
        UIManager.GetInstance().canvasObj = UIMethod.GetInstance().FindCanvas();
        UIManager.GetInstance().Push(basePanel);
    }
}

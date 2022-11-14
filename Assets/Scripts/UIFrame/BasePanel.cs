using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel
{
    public UIType uiType;

    /// <summary>
    /// 此panel在场景里对应的物体
    /// </summary>
    public GameObject ActiveObj;

    public BasePanel(UIType uitype)
    {
        uiType = uitype;
    }

    public virtual void OnStart()
    {
        UIMethod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = true;
        //if (UIManager.GetInstance().stack_ui.Count >= 2)
        //{
        //    if (GameObject.FindWithTag("Player"))
        //    {
        //        Time.timeScale = 0;
        //        if (GameObject.FindWithTag("Player").GetComponent<PlayerControll>())
        //        {
        //            GameObject.FindWithTag("Player").GetComponent<PlayerControll>().enabled = false;
        //        }
        //        else
        //        {
        //            GameObject.FindWithTag("Player").GetComponent<CompetePlayerController>().enabled = false;
        //        }
                
        //    }
        //}
        //else
        //{
        //    if (GameObject.FindWithTag("Player"))
        //    {
        //        Time.timeScale = 1;
        //        if (GameObject.FindWithTag("Player").GetComponent<PlayerControll>())
        //        {
        //            GameObject.FindWithTag("Player").GetComponent<PlayerControll>().enabled = true;
        //        }
        //        else
        //        {
        //            GameObject.FindWithTag("Player").GetComponent<CompetePlayerController>().enabled = true;
        //        }
        //    }
        //}
    }

    public virtual void OnEnable()
    {
        UIMethod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = true;
        //if (UIManager.GetInstance().stack_ui.Count >= 2)
        //{
        //    if (GameObject.FindWithTag("Player"))
        //    {
        //        Time.timeScale = 0;
        //        if (GameObject.FindWithTag("Player").GetComponent<PlayerControll>())
        //        {
        //            GameObject.FindWithTag("Player").GetComponent<PlayerControll>().enabled = false;
        //        }
        //        else
        //        {
        //            GameObject.FindWithTag("Player").GetComponent<CompetePlayerController>().enabled = false;
        //        }
        //    }
        //}
        //else
        //{
        //    if (GameObject.FindWithTag("Player"))
        //    {
        //        Time.timeScale = 1;
        //        if (GameObject.FindWithTag("Player").GetComponent<PlayerControll>())
        //        {
        //            GameObject.FindWithTag("Player").GetComponent<PlayerControll>().enabled = true;
        //        }
        //        else
        //        {
        //            GameObject.FindWithTag("Player").GetComponent<CompetePlayerController>().enabled = true;
        //        }
        //    }
        //}
    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnDisable()
    {
        UIMethod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false;
    }

    public virtual void OnDestroy()
    {
        UIMethod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false;
    }
}

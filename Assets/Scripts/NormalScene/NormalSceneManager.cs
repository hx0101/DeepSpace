using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSceneManager : BaseSceneManager
{
    bool canUpdate;

    SinglePlayerController playerController;
    NormalTipsController normalTipsController;
    NormalUIImagesManager normalUIManager;
    CubeManager cubeManager;
    GroundMove groundMove;

    private void Update()
    {
        if (!canUpdate)
        {
            return;
        }
        StartCoroutine(CompareKeyAndUI());
    }

    public override void LoadSceneAfter()
    {
        base.LoadSceneAfter();
        canUpdate = false;
    }
    public override void LoadUIPanelAfter()
    {
        base.LoadUIPanelAfter();
        //获得场景中所有的Script脚本
        playerController = GameObject.FindWithTag("Player").gameObject.GetComponent<SinglePlayerController>();
        normalTipsController = GameObject.FindWithTag("MainPanel").gameObject.GetComponent<NormalTipsController>();
        normalUIManager = GameObject.FindWithTag("MainPanel").gameObject.GetComponent<NormalUIImagesManager>();
        cubeManager = GameObject.FindWithTag("CubeManager").gameObject.GetComponent<CubeManager>();
        groundMove = GameObject.FindWithTag("Ground").gameObject.GetComponent<GroundMove>();
        canUpdate = true;
    }

    public override void LoadPlayerAfter()
    {
        base.LoadPlayerAfter();
        //游戏开始，当角色移动时计时开始
    }

    IEnumerator CompareKeyAndUI()
    {
        float key = playerController.PlayerPressKey();
        Debug.Log(key);
        if (key != 0)
        {
            if (normalTipsController.moveKeyTextLeft.Peek() == normalTipsController.moveKeyTextRight.Peek())
            {
                playerController.PlayerMove(key);
            }
            else
            {
                playerController.PlayerMove(-key);
            }

            canUpdate = false;
            //人物音效
            AudioManager.PlayerMoveAudio();
            //UI移动
            normalUIManager.CheckUIFadeOutAndIn();
            //判定移动的字符串队列，出队
            normalTipsController.moveKeyTextLeft.Dequeue();
            normalTipsController.moveKeyTextRight.Dequeue();
            //图片数组队列，出队
            normalUIManager.ExitQueue();
            //地面跟随player移动
            groundMove.MoveGround();
            yield return new WaitForSeconds(0.1f);
            //判定player的位置
            cubeManager.CheckPlayerOnLastCube();
            yield return new WaitForSeconds(0.1f);
            //图片数组队列，入队
            normalUIManager.JoinQueue();
            canUpdate = true;
        }
    }
}

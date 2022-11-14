using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSceneManager : BaseSceneManager
{
    bool canUpdate;

    SinglePlayerController playerController;
    SimpleTipsController simpleTipsController;
    SimpleUIImagesManager simpleUIManager;
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
        simpleTipsController = GameObject.FindWithTag("MainPanel").gameObject.GetComponent<SimpleTipsController>();
        simpleUIManager = GameObject.FindWithTag("MainPanel").gameObject.GetComponent<SimpleUIImagesManager>();
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
            switch (simpleTipsController.moveKeyTextMiddle.Peek())
            {
                case "白色":
                    playerController.PlayerMove(key);
                    break;
                case "黑色":
                    playerController.PlayerMove(-key);
                    break;
            }

            canUpdate = false;
            //人物音效
            AudioManager.PlayerMoveAudio();
            //UI移动
            simpleUIManager.CheckUIFadeOutAndIn();
            //判定移动的字符串队列，出队
            simpleTipsController.moveKeyTextMiddle.Dequeue();
            //图片数组队列，出队
            simpleUIManager.ExitQueue();
            //地面跟随player移动
            groundMove.MoveGround();
            yield return new WaitForSeconds(0.1f);
            //判定player的位置
            cubeManager.CheckPlayerOnLastCube();
            yield return new WaitForSeconds(0.1f);
            //图片数组队列，入队
            simpleUIManager.JoinQueue();
            canUpdate = true;
        }
    }
}

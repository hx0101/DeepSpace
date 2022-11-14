using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;

public class StartingRequest : BaseRequest
{
    private bool isstart = false;

    public override void Awake()
    {
        actionCode = ActionCode.Starting;
        base.Awake();
    }

    private void Update()
    {
        if (isstart)
        {
            Debug.Log("游戏已启动。");
            isstart = false;
        }
    }
    public override void OnResponse(MainPack pack)
    {
        isstart = true;
    }
}

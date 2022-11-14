using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BaseSceneManager : Singleton<BaseSceneManager>
{
    public GameObject player;

    public virtual void LoadSceneAfter()
    {

    }

    public virtual void LoadUIPanelAfter()
    {
        GameObject Player = Instantiate(player, new Vector3(0, 1.09f, 0), Quaternion.identity);
        CinemachineTargetGroup cinemachineTargetGroup = GameObject.FindWithTag("CinemachineTargetGroup").gameObject.GetComponent<CinemachineTargetGroup>();
        cinemachineTargetGroup.AddMember(Player.transform, 1, 1);

    }

    public virtual void LoadPlayerAfter()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    GameObject player;

    GameObject ground;
    private void Awake()
    {
        
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        ground = GameObject.FindWithTag("Ground");
    }

    public void MoveGround()
    {
        ground.transform.position = new Vector3(player.transform.position.x, ground.transform.position.y, player.transform.position.z);
    }
}

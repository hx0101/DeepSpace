using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Photon.Pun;

public class CompetePlayerController : MonoBehaviourPun
{
    public Rigidbody rigidbody;

    public float moveDistance;

    public Animator animator;

    Vector3 vector3;

    CompeteCubeManager competeCubeManager;

    CompeteTipsController competeTipsController;

    GroundMove groundMove;

    CompeteUIImageManager uiManager;

    bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Ground") != null)
        {
            competeCubeManager = GameObject.FindWithTag("CubeManager").gameObject.GetComponent<CompeteCubeManager>();
            competeTipsController = GameObject.FindWithTag("MainPanel").gameObject.GetComponent<CompeteTipsController>();
            groundMove = GameObject.FindWithTag("Ground").gameObject.GetComponent<GroundMove>();
            uiManager = GameObject.FindWithTag("UIImageManager").gameObject.GetComponent<CompeteUIImageManager>();

            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;
        StartCoroutine(MovePlayer());
    }

    private void FixedUpdate()
    {
        
    }

    IEnumerator MovePlayer()
    {
        if (canMove)
        {
            if (PlayerMove(competeTipsController.moveKeyTextBlack.Peek(), competeTipsController.moveKeyTextWhite.Peek()))
            {
                canMove = false;
                //人物音效
                AudioManager.PlayerMoveAudio();
                //UI移动
                uiManager.CheckUIFadeOutAndIn();
                //判定移动的字符串队列，出队
                competeTipsController.moveKeyTextBlack.Dequeue();
                competeTipsController.moveKeyTextWhite.Dequeue();
                //图片数组队列，出队
                uiManager.ExitQueue();
                //地面跟随player移动
                groundMove.MoveGround();
                yield return new WaitForSeconds(0.1f);
                //判定player的位置
                competeCubeManager.CheckPlayerOnLastCube();
                yield return new WaitForSeconds(0.1f);
                //图片数组队列，入队
                uiManager.JoinQueue();
                canMove = true;
            }

        }

    }

    public bool PlayerMove(string leftShow, string rightShow)
    {

        if (leftShow == rightShow)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                Vector3 Horizontal = new Vector3(-Input.GetAxisRaw("Horizontal"), 0, 0);

                vector3 = rigidbody.transform.position + Horizontal * moveDistance;
                rigidbody.transform.LookAt(rigidbody.transform.position + Horizontal * moveDistance);
                animator.SetBool("Jump", true);
                rigidbody.transform.DOMove(rigidbody.transform.position + Horizontal * moveDistance, 0.1f);
                Invoke("RigidbodyMove", 0.1f);

                return true;
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                Vector3 Vertical = new Vector3(0, 0, -Input.GetAxisRaw("Vertical"));

                vector3 = rigidbody.transform.position + Vertical * moveDistance;
                rigidbody.transform.LookAt(rigidbody.transform.position + Vertical * moveDistance);
                animator.SetBool("Jump", true);
                rigidbody.transform.DOMove(rigidbody.transform.position + Vertical * moveDistance, 0.1f);
                Invoke("RigidbodyMove", 0.1f);

                return true;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                Vector3 Horizontal = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

                vector3 = rigidbody.transform.position + Horizontal * moveDistance;
                rigidbody.transform.LookAt(rigidbody.transform.position + Horizontal * moveDistance);
                animator.SetBool("Jump", true);
                rigidbody.transform.DOMove(rigidbody.transform.position + Horizontal * moveDistance, 0.1f);
                Invoke("RigidbodyMove", 0.1f);

                return true;
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                Vector3 Vertical = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));

                vector3 = rigidbody.transform.position + Vertical * moveDistance;
                rigidbody.transform.LookAt(rigidbody.transform.position + Vertical * moveDistance);
                animator.SetBool("Jump", true);
                rigidbody.transform.DOMove(rigidbody.transform.position + Vertical * moveDistance, 0.1f);
                Invoke("RigidbodyMove", 0.1f);

                return true;
            }
        }
        return false;
    }

    void RigidbodyMove()
    {
        rigidbody.transform.position = Vector3.MoveTowards(rigidbody.transform.position, vector3, moveDistance);
        animator.SetBool("Jump", false);
    }
}

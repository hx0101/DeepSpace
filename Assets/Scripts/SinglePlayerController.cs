using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SinglePlayerController : MonoBehaviour
{
    public Rigidbody rigidbody;

    public float moveDistance;

    public Animator animator;

    Vector3 vector3;

    bool isChangeHorizontal;

    public float PlayerPressKey()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        if (!Mathf.Approximately(horizontal, 0))
        {
            isChangeHorizontal = true;
            return horizontal;
        }

        if (!Mathf.Approximately(vertical, 0))
        {
            isChangeHorizontal = false;
            Debug.Log(vertical);
            Debug.Log(isChangeHorizontal);
            return vertical;
        }

        return 0;
    }

    public void PlayerMove(float direction)
    {
        
        if (isChangeHorizontal)
        {
            Vector3 Horizontal = new Vector3(direction, 0, 0);

            vector3 = rigidbody.transform.position + Horizontal * moveDistance;
            rigidbody.transform.LookAt(rigidbody.transform.position + Horizontal * moveDistance);
            animator.SetBool("Jump", true);
            rigidbody.transform.DOMove(rigidbody.transform.position + Horizontal * moveDistance, 0.1f);
            Invoke("RigidbodyMove", 0.1f);
        }
        else
        {
            Vector3 Vertical = new Vector3(0, 0, direction);

            vector3 = rigidbody.transform.position + Vertical * moveDistance;
            rigidbody.transform.LookAt(rigidbody.transform.position + Vertical * moveDistance);
            animator.SetBool("Jump", true);
            rigidbody.transform.DOMove(rigidbody.transform.position + Vertical * moveDistance, 0.1f);
            Invoke("RigidbodyMove", 0.1f);
        }
    }

    void RigidbodyMove()
    {
        rigidbody.transform.position = Vector3.MoveTowards(rigidbody.transform.position, vector3, moveDistance);
        animator.SetBool("Jump", false);
    }
}

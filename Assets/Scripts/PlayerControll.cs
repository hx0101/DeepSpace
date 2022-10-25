using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerControll : MonoBehaviour
{
    public Rigidbody rigidbody;

    public float moveSpeed;

    public float moveDistance;

    public Animator animator;

    Vector3 vector3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public bool PlayerMove(string leftShow,string rightShow)
    {
        
        if (leftShow == rightShow)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                Vector3 Horizontal = new Vector3(-Input.GetAxisRaw("Horizontal"), 0, 0);

                vector3 = rigidbody.transform.position + Horizontal * moveDistance;
                rigidbody.transform.LookAt(rigidbody.transform.position + Horizontal * moveDistance);
                animator.SetBool("Jump",true);
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

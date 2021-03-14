using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public Animator animator = null;
    public float moveSpeed = 1f;
    public GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {

        Vector3 moveInput = Vector3.zero;
        if (Input.GetKey(gameManager.left) || Input.GetKey(gameManager.right))
        {
            moveInput.x =  Input.GetAxis("Horizontal");
        }

        if (Input.GetKey(gameManager.up) || Input.GetKey(gameManager.down))
        {
            moveInput.y = Input.GetAxis("Vertical");
        }

        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.magnitude);
        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }
}

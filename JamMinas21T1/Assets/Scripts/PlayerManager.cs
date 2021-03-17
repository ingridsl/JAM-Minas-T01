using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public Animator animator = null;
    public float moveSpeed = 1f;
    public GameManager gameManager = null;

    public bool isHitingOre = false;
    public bool isMining = false;

    public float testmousex = 0;
    public float testmousey = 0;

    public bool canMove = true;
    bool click = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Movement();
            //if (!isHitingOre && click)
            //{
            //    ActivateMiningAnim(false);
            //}
        }

        Vector3 mousePos = Input.mousePosition;
        testmousex = mousePos.x;
        testmousey = mousePos.y;
    }

    void Movement()
    {

        Vector3 moveInput = Vector3.zero;
        if (Input.GetKey(gameManager.left) || Input.GetKey(gameManager.right))
        {
            moveInput.x = Input.GetAxis("Horizontal");
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

    public void ActivateMiningAnim(bool thisClick)
    {
        Vector3 mousePos = Input.mousePosition;
        var playerPosition = Camera.main.WorldToScreenPoint(transform.position);

        click = thisClick;
        animator.SetBool("Click", click);
        if (click)
        {
            click = false;
            StartCoroutine(ForceClickFalse(0.7f));
        }
        animator.SetFloat("MouseX", mousePos.x - playerPosition.x);
        animator.SetFloat("MouseY", mousePos.y - playerPosition.y);
    }

    public IEnumerator ForceClickFalse(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        isHitingOre = false;
        ActivateMiningAnim(false);
    }
}

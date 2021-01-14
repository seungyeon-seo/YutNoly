using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharac : MonoBehaviour
{
    public float movePower = 1f;
    public float jumpPower = 1f;

    Rigidbody2D rigid;

    Vector3 movement;
    bool isJumping = false;
/*    bool isTrigger = false; */

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        // 방향설정
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-50, 50, 50); // left flip
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(50, 50, 50); // right flip
        }


        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump()
    {
        if (!isJumping)
            return;

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
    }

    // Attach event - 착지
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Attach: " + other.gameObject.layer);
    }

    // Detach event - 착지
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Detach: " + other.gameObject.layer);
    }
}
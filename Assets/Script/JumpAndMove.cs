using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAndMove : MonoBehaviour
{

    public float speed = 5f;        //이동속도
    public float jump_speed = 5f;   //점프 높이
    private Rigidbody2D rd;         //점프 하기 위해 rigidbody 가져옴
    private bool facingRight = true;        //캐릭터 이동회전

    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");        //이동 : 1 = 오른쪽, -1 = 왼쪽

        transform.Translate(Vector3.right * speed * hor * Time.deltaTime);
        if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f)
        {    // 만약 왼쪽 혹은 오른쪽 이동 중 0.5f 이상인 경우

            if (Input.GetAxis("Horizontal") > 0.5f && !facingRight)      //facingRight 가 false이면서 오른쪽 이동키 누른 경우.
            {
                Flip();
                facingRight = true;
            }
            else if (Input.GetAxis("Horizontal") < -0.5f && facingRight)     // gacingRight 가 true이면서 왼쪽 이동키 누른 경우.
            {
                Flip();
                facingRight = false;
            }
        }

        if (Input.GetKey(KeyCode.Space))        //스페이스바 키 누를 시 점프
        {
            rd.velocity = Vector3.up * jump_speed;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;             // 1 = 오른쪽 방향, -1 = 왼쪽방향
        transform.localScale = theScale;
    }
}
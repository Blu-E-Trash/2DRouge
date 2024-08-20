using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Jump : PlayerMove
{
    public float jumpPower;     //점프력
    private float scaleX;
    
    private Vector2 StartPoint;
    [SerializeField]
    private int jumpCount;

    public LayerMask Mask;

    void Start()
    {
        jumpPower = 5f;
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scaleX = transform.localScale.x;

        GroundCheck();

        if (Input.GetButtonDown("JumpC"))
        {
            JumpAction();
        }
    }
    private void JumpAction()
    { 
        if (jumpCount == 0)
        {//1단점프
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount=1;
        }
        if (jumpCount == 1)
        {//2단점프
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount=2;
        }
    }
    private void GroundCheck()
    {
        float RayLength = 0.3f;
        if (scaleX == -1)//왼쪽을 보는중
        {
            StartPoint = new Vector2(Playercollider2D.bounds.center.x + Playercollider2D.bounds.extents.x, Playercollider2D.bounds.min.y);
        }

        else if (scaleX == 1)
        {
            StartPoint = new Vector2(Playercollider2D.bounds.center.x - Playercollider2D.bounds.extents.x, Playercollider2D.bounds.min.y);
        }
        Debug.DrawRay(StartPoint, Vector2.down * RayLength, Color.red); // 디버그 레이
        RaycastHit2D hit = Physics2D.Raycast(StartPoint, Vector2.down, RayLength, Mask);

        if(hit.collider != null)
        {//땅에 있을떄
            Debug.Log(hit.collider);
            jumpCount = 0;
        }
    }
}

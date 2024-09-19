using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public float jumpPower;     //점프력
    private float scaleX;

    private Vector2 StartPoint;
    [SerializeField]
    private int jumpCount;

    public LayerMask Mask;
    public float movePower;     //이속
    //대쉬
    protected float dashForce = 20f;
    protected float dashDuration = 0.1f;
    public float dashCooldown = 3f;
    public bool isDash = false;
    private float dashTimeLeft;
    private float lastDashTime;

    protected Rigidbody2D rb;
    public Animator animator;
    protected Collider2D Playercollider2D;
    SpriteRenderer render;

    [SerializeField]
    ParticleSystem moveEffect;
    [SerializeField]
    private GameManager gameManager;

    public bool immortal=false;

    protected void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Playercollider2D = GetComponent<Collider2D>();
    }
    private void Start()
    {
        jumpPower = 5f;
        jumpCount = 0;
    }
    private void Update()
    {
        if (!gameManager.isGameOver)
        {
            if (Input.GetButtonDown("Dash") && !isDash && Time.time >= lastDashTime + dashCooldown)
            {
                StartDash();
            }
            if (isDash)
            {
                if (dashTimeLeft > 0)
                {
                    dashTimeLeft -= Time.deltaTime;
                }
                else
                {
                    EndDash();
                }
            }
            //이동
            Move();

            scaleX = transform.localScale.x;

            GroundCheck();

            if (Input.GetButtonDown("JumpC"))
            {
                JumpAction();
            }
        }
    }
    public void StartDash()
    {
        isDash = true;
        dashTimeLeft = dashDuration;
        lastDashTime = Time.time;

        animator.SetTrigger("doAttack");//공격모션으로 재생
        if (render.flipX)
        {
            rb.velocity = new Vector2((-1) * dashForce, 0f);
        }
        else if(!render.flipX) 
        {
            rb.velocity = new Vector2(dashForce, 0f);
        }

    }
    private void EndDash()
    {
        isDash = false;

        rb.velocity = new Vector2(0f, rb.velocity.y);
    }
    private void Move()
    {
        float movedir = 0;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetTrigger("doMove");
            movedir = -1;
            render.flipX = true;//transform.localScale = leftV;
            if (!moveEffect.isPlaying)
            {
                moveEffect.Play();
            }
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetTrigger("doMove");
            movedir = 1;
            render.flipX = false;//transform.localScale = rightV;
            if (!moveEffect.isPlaying)
            {
                moveEffect.Play();
            }
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetTrigger("doStop");
            if (moveEffect.isPlaying)
            {
                moveEffect.Stop();
            }
        }
        if (!isDash)
        {
            rb.velocity = new Vector2(movedir * movePower, rb.velocity.y);
        }
        //this.transform.position += movedir * movePower * Time.deltaTime;
    }
    private void JumpAction()
    {
        if (jumpCount == 0)
        {//1단점프
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount = 1;
        }
        if (jumpCount == 1)
        {//2단점프
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount = 2;
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

        if (hit.collider != null)
        {
            jumpCount = 0;
        }
    }
}

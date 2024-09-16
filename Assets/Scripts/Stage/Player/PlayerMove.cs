using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //이동
    public float movePower;     //이속
    //대쉬
    protected float dashForce = 20f;
    protected float dashDuration = 0.1f;
    public float dashCooldown = 3f;
    private bool isDash = false;
    private float dashTimeLeft;
    private float lastDashTime;

    protected Rigidbody2D rb;
    public Animator animator;
    protected Collider2D Playercollider2D;
    private EnemyHp enemyHp;
    SpriteRenderer render;

    Vector3 leftV = new Vector3(-1, 1, 1);
    Vector3 rightV = new Vector3(1, 1, 1);

    [SerializeField]
    ParticleSystem moveEffect;
    [SerializeField]
    private GameManager gameManager;

    protected void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Playercollider2D = GetComponent<Collider2D>();
    }
    private void Update()
    { 
        //대쉬
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
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetTrigger("doMove");
            moveVelocity = Vector3.left;
            render.flipX = true;//transform.localScale = leftV;
            if (!moveEffect.isPlaying)
            {
                moveEffect.Play();
            }
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetTrigger("doMove");
            moveVelocity = Vector3.right;
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

        this.transform.position += moveVelocity * movePower * Time.deltaTime;
    }
}

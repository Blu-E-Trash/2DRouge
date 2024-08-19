using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //이동
    public float movePower;     //이속
    public float jumpPower;     //점프력
    private bool isMove;
    //대쉬
    public float dashForce = 20f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 4f;
    private bool isDash = false;
    private float dashTimeLeft;
    private float lastDashTime;
    [SerializeField]
    private bool OnGround;
    private bool AirJump;

    public LayerMask Mask;
    public LayerMask mobMask;

    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    SpriteRenderer playerSpriteRenderer;
    [SerializeField]
    ParticleSystem moveEffect;
    [SerializeField]
    Animator animator;
    [SerializeField]
    Collider2D Playercollider2D;

    EnemyHp enemyHp;

    private PlayerStatus status;

    private void Awake()
    {
        movePower = 5f;
        jumpPower = 5f;
    }
    private void Update()
    {
        GroundCheck();
        //점프
        if (Input.GetButtonDown("JumpC"))
        {
            if (OnGround)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            if (!AirJump)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                AirJump = false;
            }
        }
        //공격
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
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

        // 캐릭터가 바라보는 방향 계산 (localScale.x가 양수이면 오른쪽, 음수이면 왼쪽)
        float dashDirection = transform.localScale.x > 0 ? 1f : -1f;
        animator.SetTrigger("doAttack");//공격모션으로 재생
        rb.velocity = new Vector2(dashDirection * dashForce, 0f);//(new Vector2(dashDirection * dashForce, 0f), ForceMode2D.Impulse);
    }

    private void EndDash()
    {
        isDash = false;

        rb.velocity = new Vector2(0f, rb.velocity.y);
    }
    private void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), new Vector2(5, 5), 0, mobMask);
            animator.SetTrigger("doAttack");
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.CompareTag("Mob"))
                    enemyHp.mobDamaged();
            }

        }
    }
    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetTrigger("doMove");
            isMove = true;
            moveVelocity = Vector3.left;
            this.transform.localScale = new Vector3(-1, 1, 1);
            if (!moveEffect.isPlaying)
            {
                moveEffect.Play();
            }
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetTrigger("doMove");
            isMove = true;
            moveVelocity = Vector3.right;
            this.transform.localScale = new Vector3(1, 1, 1);
            if (!moveEffect.isPlaying)
            {
                moveEffect.Play();
            }
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetTrigger("doStop");
            isMove = false;
            if (moveEffect.isPlaying)
            {
                moveEffect.Stop();
            }
        }

        this.transform.position += moveVelocity * movePower * Time.deltaTime;
    }
    private void GroundCheck()
    {
        float RayLength = Playercollider2D.bounds.center.y-Playercollider2D.bounds.min.y+0.05f;
        RaycastHit2D hit = Physics2D.Raycast(Playercollider2D.bounds.center, Vector2.down,RayLength,Mask);
        if (hit != null)
        {
            Debug.Log(hit.transform.gameObject);
            OnGround = true;
            AirJump = true;
            return;
        }
        hit = Physics2D.Raycast(new Vector2(Playercollider2D.bounds.center.x - Playercollider2D.bounds.min.x+0.001f,Playercollider2D.bounds.center.y), Vector2.down, RayLength, Mask);
        if (hit != null)
        {
            OnGround = true;
            AirJump = true;
            return;
        }
        hit = Physics2D.Raycast(new Vector2(Playercollider2D.bounds.max.x - Playercollider2D.bounds.center.x - 0.001f, Playercollider2D.bounds.center.y), Vector2.down, RayLength, Mask);
        if (hit != null)
        {
            OnGround = true;
            AirJump = true;
            return;
        }
        OnGround = false;
    }
}

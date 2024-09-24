using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{

    public Vector2 StartPoint;
    private Transform playerPos;
    [SerializeField]
    private int jumpCount;
    private PlayerStatus playerStatus;

    public LayerMask Mask;
    public LayerMask mobMask;

    //대쉬
    protected float dashForce = 20f;
    protected float dashDuration = 0.1f;
    public float dashCooldown = 3f;
    public bool isDash = false;
    private float dashTimeLeft;
    private float lastDashTime;

    protected Rigidbody2D rb;
    public Animator nowAnimator;
    public RuntimeAnimatorController UpgradeAnimator;
    public Collider2D Playercollider2D;
    SpriteRenderer render;

    [SerializeField]
    private GameObject RmoveEffect;
    [SerializeField]
    private GameObject LmoveEffect;
    public GameManager gameManager;
    private EnemyHp enemyHp;

    private float curTime;
    public float coolTime = 0.5f;
    public float RayLength;
    private RaycastHit2D[] rayHit;
    private Vector2 attackStartPoint;

    public bool immortal=false;

    private void Awake()
    {
        RmoveEffect.SetActive(false); 
        LmoveEffect.SetActive(false);
        jumpCount = 0;
    }
    private void Start()
    {
        playerPos = GetComponent<Transform>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        nowAnimator = GetComponent<Animator>();
        Playercollider2D = GetComponent<Collider2D>();
        playerStatus = GetComponent<PlayerStatus>();
    }
    private void OnEnable()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    public void ChangeAnimation()
    {
        nowAnimator.runtimeAnimatorController = UpgradeAnimator;
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
            if (playerStatus.isDamaged)
            {
                playDamagedAnim();
            }
            GroundCheck();

            if (Input.GetButtonDown("JumpC"))
            {
                JumpAction();
            }
            CheckAttackRange();
            if (curTime <= 0)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Attack();
                    curTime = coolTime;
                }
            }
            else
            {
                curTime -= Time.deltaTime;
            }
        }
        if (gameManager.isGameOver||gameManager.isVictory)
        {
            rb.velocity = new Vector2(0, 0);
            RmoveEffect.SetActive(false);
            LmoveEffect.SetActive(false);
        }
    }
    private void playDamagedAnim()
    {
        nowAnimator.SetTrigger("doHit");
    }
    private void Attack()
    {
        nowAnimator.SetTrigger("doAttack");
        for (int i = 0; i < rayHit.Length; i++) {
            enemyHp = rayHit[i].collider.GetComponent<EnemyHp>();
            if (!enemyHp.isDead)
            {
                enemyHp.mobDamaged();
            } 
        }
    }
    private void CheckAttackRange()
    {
        if (!render.flipX)
        {
            attackStartPoint = new Vector2(playerPos.position.x,playerPos.position.y+0.5f);
            rayHit = Physics2D.RaycastAll(attackStartPoint, Vector2.right, RayLength,mobMask);
            
            Debug.DrawRay(attackStartPoint, Vector3.right * RayLength, Color.blue);

        }
        else if (render.flipX)
        {
            attackStartPoint = new Vector2(playerPos.position.x, playerPos.position.y + 0.5f);
            rayHit = Physics2D.RaycastAll(attackStartPoint, Vector2.left, RayLength,mobMask);
            Debug.DrawRay(attackStartPoint, Vector3.left * RayLength, Color.blue);
        }
    }
    public void StartDash()
    {
        isDash = true;
        dashTimeLeft = dashDuration;
        lastDashTime = Time.time;

        nowAnimator.SetTrigger("doAttack");//공격모션으로 재생
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

        if (!isDash)
        {
            float movedir = 0;

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                nowAnimator.SetTrigger("doMove");
                movedir = -1;
                render.flipX = true;
                RmoveEffect.SetActive(false);
                LmoveEffect.SetActive(true);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                nowAnimator.SetTrigger("doMove");
                movedir = 1;
                render.flipX = false;
                RmoveEffect.SetActive(true);
                LmoveEffect.SetActive(false);
            }
            else if (Input.GetButtonUp("Horizontal"))
            {
                nowAnimator.SetTrigger("doStop");
                RmoveEffect.SetActive(false);
                LmoveEffect.SetActive(false);
            }
            if (!isDash)
            {
                rb.velocity = new Vector2(movedir * playerStatus.movePower, rb.velocity.y);
            }
        }
    }
    private void JumpAction()
    {
        if (jumpCount == 0)
        {//1단점프
            rb.velocity = new Vector2(rb.velocity.x, playerStatus.jumpPower);
            jumpCount = 1;
        }
        if (jumpCount == 1)
        {//2단점프
            rb.velocity = new Vector2(rb.velocity.x, playerStatus.jumpPower);
            jumpCount = 2;
        }
    }
    private void GroundCheck()
    {
        float RayLength = 0.3f;
        if (render.flipX)//왼쪽을 보는중
        {
            StartPoint = new Vector2(Playercollider2D.bounds.center.x + Playercollider2D.bounds.extents.x, Playercollider2D.bounds.min.y);
        }

        else if (!render.flipX)
        {
            StartPoint = new Vector2(Playercollider2D.bounds.center.x - Playercollider2D.bounds.extents.x, Playercollider2D.bounds.min.y);
        }
        Debug.DrawRay(StartPoint, Vector2.down * RayLength, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(StartPoint, Vector2.down, RayLength, Mask);

        if (hit.collider != null)
        {
            jumpCount = 0;
        }
    }
}

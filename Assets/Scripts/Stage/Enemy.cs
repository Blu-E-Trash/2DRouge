using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;
    private EnemyHp enemyHp;
    public Transform pos;
    public Vector2 boxSize;
    private Sword sword;
    [SerializeField]
    private GameManager gameManager;

    public int nextMove;//행동지표를 결정할 변수

    public IEnumerator currentCoroutine;
    float nextThinkTime;

    public LayerMask groundMask;

    void Awake()
    {
        enemyHp = GetComponent<EnemyHp>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    private void Start()
    {
        this.transform.localScale = new Vector3(1, 1, 1);

        currentCoroutine = MoveCorutine();
        StartCoroutine(currentCoroutine);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (!enemyHp.isDead)
            {
                sword = other.GetComponent<Sword>();
                Debug.Log(other.name);
                gameManager.getAttacked();
            }
        }
    }
    void FixedUpdate()
    {
        if (nextMove != 0)
        {
            this.transform.localScale = new Vector3(nextMove, 1, 1);
        }

        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        Vector2 frontVec = new Vector2(transform.position.x + transform.localScale.x * 0.2f, transform.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, groundMask);
        RaycastHit2D rayHitWall = Physics2D.Raycast(frontVec, new Vector3(transform.localScale.x, 0,0), 1, groundMask);
        Debug.DrawRay(frontVec, new Vector3(nextMove, 0, 0), new Color(0, 1, 0));
        if (rayHit.collider == null || rayHitWall.collider != null) //|| or 맞지 않음? 쏘는 방향 맞잖어 그냥 태그를 검사할까요? 콜라먹누?
        {
            nextMove = nextMove * -1;
        }
    }

    IEnumerator MoveCorutine()
    {
        while (true)
        {
            if (enemyHp.isDead)
            {
                rigid.velocity = new Vector2(0, 0);
                break;
            }
           
            nextMove = Random.Range(-1, 2); //-1 = 왼쪽,1 = 오른쪽 
            
            anim.SetTrigger("Run");

            nextThinkTime = Random.Range(2f, 4f);

            
            yield return new WaitForSeconds(nextThinkTime);
        }
    }
}
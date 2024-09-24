using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;
    private EnemyHp enemyHp;

    [SerializeField]
    private PlayerStatus playerStatus;

    public int nextMove;//행동지표를 결정할 변수

    public IEnumerator currentCoroutine;
    float nextThinkTime;

    public LayerMask groundMask;

    private void Awake()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
        enemyHp = GetComponent<EnemyHp>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentCoroutine = MoveCorutine();
        StartCoroutine(currentCoroutine);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (!enemyHp.isDead)
            {

                playerStatus.getAttacked();
            }
        }
    }
    void FixedUpdate()
    {
        if (!enemyHp.isDead)
        {
            if (nextMove != 0)
            {
           this.transform.localScale = new Vector3(nextMove, 1, 1);
            }

            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

            Vector2 frontVec = new Vector2(transform.position.x + transform.localScale.x * 0.2f, transform.position.y);
            Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, groundMask);
            RaycastHit2D rayHitWall = Physics2D.Raycast(frontVec, new Vector3(transform.localScale.x, 0, 0), 1, groundMask);
            Debug.DrawRay(frontVec, new Vector3(nextMove, 0, 0), new Color(0, 1, 0));

            if (rayHit.collider == null || rayHitWall.collider != null)
            {
                nextMove = nextMove * -1;
            }
        }
        else
        {
            rigid.velocity = new Vector2(0, 0);
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
           
            nextMove = Random.Range(-1, 2);
            
            anim.SetTrigger("Run");

            nextThinkTime = Random.Range(2f, 4f);

            
            yield return new WaitForSeconds(nextThinkTime);
        }
    }
}
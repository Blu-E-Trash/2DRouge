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

    public LayerMask mobMask;

    public int nextMove;//행동지표를 결정할 변수

    void Awake()
    {
        enemyHp = GetComponent<EnemyHp>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Invoke("Think", 3);
    }
    private void OnTriggerEnter2D(Collider2D other)
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
    //public void Attack()
    //{
    //    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0,mobMask);
    //    foreach (Collider2D collider in collider2Ds)
    //    {
    //        if (collider.CompareTag("Player"))
    //        {
    //            if (!enemyHp.isDead)
    //            {
    //                sword = collider.GetComponent<Sword>();
    //                Debug.Log(collider.name);
    //                gameManager.getAttacked();
    //            }
    //        }
    //    }
    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
    void FixedUpdate()
    {
        //한 방향으로만 알아서 움직이게
        if (enemyHp.isDead)
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);//죽으면 멈추게
        }
        else if(!enemyHp.isDead) 
        {
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        }

        //몬스터 앞 체크
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        // 시작,방향 색깔
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));
        if (rayHit.collider == null)
        {
            Turn();
        }
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2); //-1 = 왼쪽,1 = 오른쪽

        anim.SetTrigger("Run");
        this.transform.localScale = new Vector3(1, 1, 1);
        //재귀 
        float nextThinkTime = Random.Range(2f, 4f);//생각하는 시간도 랜덤으로 

        Invoke("Think", nextThinkTime);//재귀
    }
    void Turn()
    {
        nextMove = nextMove * (-1);

        if ((nextMove == 1))
        {
            this.transform.localScale = new Vector3(1, 1, 1); //nextMove가 1이면 방향바꾸기
        }
        else if(nextMove == -1)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        CancelInvoke();
        Invoke("Think", 4);
    }
}
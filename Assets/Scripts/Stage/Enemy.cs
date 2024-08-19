using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public int nextMove;//행동지표를 결정할 변수

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Invoke("Think", 5);
    }
    void FixedUpdate()
    {
        //한 방향으로만 알아서 움직이게
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);//왼쪽으로 가니까 -1

        //몬스터는 앞을 체크해야 
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
        nextMove = Random.Range(-1, 2); //-1 = 왼쪽, 0 = 정지,1 = 오른쪽

        anim.SetTrigger("Run");

        //방향 바꾸기 (0일 때는 굳이 바꿀 필요없기에 조건문 사용해준거)
        if (nextMove != 0)
        {
            spriteRenderer.flipX = (nextMove == 1); //nextMove가 1이면 방향바꾸기
        }

        //재귀 
        float nextThinkTime = Random.Range(2f, 5f);//생각하는 시간도 랜덤으로 

        Invoke("Think", nextThinkTime);//재귀
    }
    void Turn()
    {
        nextMove = nextMove * (-1);
        spriteRenderer.flipX = (nextMove == 1); //nextMove가 1이면 방향바꾸기


        CancelInvoke();
        Invoke("Think", 2);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    public int nextMove;//행동지표를 결정할 변수

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Invoke("Think", 3);
    }
    void FixedUpdate()
    {
        //한 방향으로만 알아서 움직이게
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);//왼쪽으로 가니까 -1

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
        if(nextMove == -1)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        CancelInvoke();
        Invoke("Think", 4);
    }
}
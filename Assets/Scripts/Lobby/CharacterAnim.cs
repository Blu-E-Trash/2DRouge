using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    Animator anim;
    SpriteRenderer spriteRenderer;
    public int nextMove;//행동지표를 결정할 변수

    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Invoke("Think", 5);
    }
    void Think()
    {
        nextMove = Random.Range(0, 4); //0~3

        if (nextMove == 0)
        {
            anim.SetTrigger("doAttack");
        }
        else if(nextMove == 1)
        {
            anim.SetTrigger("doMove");
        }
        else if( nextMove == 2) 
        {
            anim.SetTrigger("doHit");
        }
        else if(nextMove == 3)
        {
            anim.SetTrigger("doDie");
        }

        float nextThinkTime = 2;

        Invoke("Think", nextThinkTime);
    }
}

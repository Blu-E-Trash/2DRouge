using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Attack : MonoBehaviour
{
    EnemyHp enemyHp;

    private float curTime;
    public float coolTime = 0.5f;
    public Transform pos;
    public Vector2 boxSize;
    public Animator animator;

    public LayerMask mobMask;
    Shop shop;

    private void Start()
    {
        Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), new Vector2(1, 1), 0, mobMask);
    }
    void Update()
    {
        if (curTime <= 0)
        {//°ø¼Ó
            if (Input.GetButtonDown("Attack"))
            {
                animator.SetTrigger("doAttack");
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0,mobMask);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.CompareTag("Mob"))
                    {
                        enemyHp = collider.GetComponent<EnemyHp>();
                        Debug.Log(collider.name);
                        enemyHp.mobDamaged();
                    }
                    else if (collider.CompareTag("Shop"))
                    {
                        shop.Open();
                    }
                }
                curTime = coolTime;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}

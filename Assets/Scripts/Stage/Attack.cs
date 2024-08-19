using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Attack : MonoBehaviour
{
    PlayerMove playerMove;
    private void Awake()
    {
        Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), new Vector2(1, 1), 0, playerMove.mobMask);
    }
    void Update()
    {
        
    }
}

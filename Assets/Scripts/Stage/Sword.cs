using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : PlayerStatus
{
    PlayerMove playerMove;
    new void Start()
    {
        maxHp = 6;
        Hp = maxHp;
        Damage = 100;
        playerMove.movePower = 5;
        CritPer = 20;
        CritDam = 150;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

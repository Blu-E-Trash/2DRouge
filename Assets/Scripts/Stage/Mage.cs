using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : PlayerStatus
{
    // Start is called before the first frame update
    private void Start()
    {
        Hp = 3;
        Damage = 200;
        playerMove.movePower = 4;
        CritPer = 30;
        CritDam = 180;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PlayerStatus
{
    // Start is called before the first frame update
    private void Start()
    {
        Hp = 4;
        Damage = 80;
        playerMove.movePower = 4;
        CritPer = 10;
        CritDam = 130;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

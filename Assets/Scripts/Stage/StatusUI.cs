using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    [SerializeField]
    private Text DamageText;       //공격력
    [SerializeField]
    private Text HpText;           //체력
    [SerializeField]
    private Text movePowerText;
    [SerializeField]
    private Text CritPerText;       //크확
    [SerializeField]
    private Text CritDamText;       //크뎀
    [SerializeField]
    PlayerStatus playerStatus;
    [SerializeField]
    PlayerMove playerMove;

    void Update()
    {
        DamageText.text = "공격력:" + playerStatus.Damage.ToString();
        HpText.text = "Hp:" + playerStatus.maxHp.ToString() + "/" + playerStatus.Hp.ToString();
        movePowerText.text = "이동속도:" + playerMove.movePower.ToString();
        CritDamText.text = "치명타 데미지:"+playerStatus.CritDam.ToString()+"%";
        CritPerText.text = "치명타 확률:" + playerStatus.CritPer.ToString() + "%";
    }
}

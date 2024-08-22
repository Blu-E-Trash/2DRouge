using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    [SerializeField]
    private Text DamageText;       //���ݷ�
    [SerializeField]
    private Text HpText;           //ü��
    [SerializeField]
    private Text movePowerText;
    [SerializeField]
    private Text CritPerText;       //ũȮ
    [SerializeField]
    private Text CritDamText;       //ũ��
    [SerializeField]
    private Text HpUIText;

    [SerializeField]
    PlayerStatus playerStatus;
    [SerializeField]
    PlayerMove playerMove;

    void Update()
    {
        DamageText.text = "���ݷ�:" + playerStatus.Damage.ToString();
        HpText.text = "Hp:" + playerStatus.maxHp.ToString() + "/" + playerStatus.Hp.ToString();
        HpUIText.text = "Hp:"+ playerStatus.Hp.ToString();
        movePowerText.text = "�̵��ӵ�:" + playerMove.movePower.ToString();
        CritDamText.text = "ġ��Ÿ ������:"+playerStatus.CritDam.ToString()+"%";
        CritPerText.text = "ġ��Ÿ Ȯ��:" + playerStatus.CritPer.ToString() + "%";
        playerStatus.goldText.text = playerStatus.gold.ToString();
    }
}

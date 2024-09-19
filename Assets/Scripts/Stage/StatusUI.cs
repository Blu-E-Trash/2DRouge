using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    [SerializeField]
    private Text basicHpText;       //�⺻ UI
    [SerializeField]
    private Text basicCoinText;     //�⺻ UI

    [SerializeField]
    private Text mainDamageText;       //���ݷ�
    [SerializeField]
    public Text mainHpText;           //ü��
    [SerializeField]
    private Text mainmovePowerText;
    [SerializeField]
    private Text mainCritPerText;       //ũȮ
    [SerializeField]
    private Text mainCritDamText;       //ũ��

    [SerializeField]
    PlayerStatus playerStatus;
    [SerializeField]
    PlayerMove playerMove;

    private void Awake()
    {
        mainHpText.text = "Hp:" + playerStatus.maxHp.ToString() + "/" + playerStatus.Hp.ToString();
        mainmovePowerText.text = "�̵��ӵ�:" + playerMove.movePower.ToString();
        mainCritDamText.text = "ġ��Ÿ ������:" + playerStatus.CritDam.ToString() + "%";
        mainCritPerText.text = "ġ��Ÿ Ȯ��:" + playerStatus.CritPer.ToString() + "%";
        mainDamageText.text = "���ݷ�:" + playerStatus.Damage.ToString();
        basicHpText.text = "Hp:" + playerStatus.Hp.ToString();
        basicCoinText.text = "$"+ playerStatus.gold.ToString();
    }
    public void BasicUIUpdate()
    {
        basicCoinText.text = "Hp:" + playerStatus.gold.ToString();
        basicHpText.text = "$" + playerStatus.Hp.ToString();
    }
    public void MainUIUpdate()
    {
        mainDamageText.text = "���ݷ�:" + playerStatus.Damage.ToString();
        mainHpText.text = "Hp:" + playerStatus.maxHp.ToString() + "/" + playerStatus.Hp.ToString();
        mainmovePowerText.text = "�̵��ӵ�:" + playerMove.movePower.ToString();
        mainCritDamText.text = "ġ��Ÿ ������:" + playerStatus.CritDam.ToString() + "%";
        mainCritPerText.text = "ġ��Ÿ Ȯ��:" + playerStatus.CritPer.ToString() + "%";
    }
}

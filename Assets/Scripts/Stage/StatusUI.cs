using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    [SerializeField]
    private Text basicHpText;       //기본 UI
    [SerializeField]
    private Text basicCoinText;     //기본 UI

    [SerializeField]
    private Text mainDamageText;       //공격력
    [SerializeField]
    public Text mainHpText;           //체력
    [SerializeField]
    private Text mainmovePowerText;
    [SerializeField]
    private Text mainCritPerText;       //크확
    [SerializeField]
    private Text mainCritDamText;       //크뎀

    [SerializeField]
    PlayerStatus playerStatus;
    [SerializeField]
    PlayerMove playerMove;

    private void Awake()
    {
        mainHpText.text = "Hp:" + playerStatus.maxHp.ToString() + "/" + playerStatus.Hp.ToString();
        mainmovePowerText.text = "이동속도:" + playerMove.movePower.ToString();
        mainCritDamText.text = "치명타 데미지:" + playerStatus.CritDam.ToString() + "%";
        mainCritPerText.text = "치명타 확률:" + playerStatus.CritPer.ToString() + "%";
        mainDamageText.text = "공격력:" + playerStatus.Damage.ToString();
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
        mainDamageText.text = "공격력:" + playerStatus.Damage.ToString();
        mainHpText.text = "Hp:" + playerStatus.maxHp.ToString() + "/" + playerStatus.Hp.ToString();
        mainmovePowerText.text = "이동속도:" + playerMove.movePower.ToString();
        mainCritDamText.text = "치명타 데미지:" + playerStatus.CritDam.ToString() + "%";
        mainCritPerText.text = "치명타 확률:" + playerStatus.CritPer.ToString() + "%";
    }
}

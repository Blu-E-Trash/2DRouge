using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{ 
    public Text goldText;           //얼마 있는지 확인
    public Image hp;            //하트 개수 표현
    public Image characterImage; //캐릭터 초상화
    private Image UpgradedClass; //업글 후의 초상화

    [SerializeField]
    public float Damage;       //공격력
    [SerializeField]
    private float Range;        //범위
    [SerializeField] 
    private float AttackSpeed;  //공속
    [SerializeField] 
    private int Hp;           //체력
    
    private int gold;       

    public void Awake()
    {
        gold = 100;
        goldText = GetComponent<Text>();
        hp = GetComponent<Image>();
        characterImage = GetComponent<Image>();
    }
    public void UpgradeClass()
    {
        if (gold>1000)
        {
            
        }
    }
}

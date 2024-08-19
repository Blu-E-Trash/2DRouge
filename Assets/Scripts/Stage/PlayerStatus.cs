using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{ 
    public Text goldText;           //�� �ִ��� Ȯ��
    public Image hp;            //��Ʈ ���� ǥ��
    public Image characterImage; //ĳ���� �ʻ�ȭ
    private Image UpgradedClass; //���� ���� �ʻ�ȭ

    [SerializeField]
    public float Damage;       //���ݷ�
    [SerializeField]
    private float Range;        //����
    [SerializeField] 
    private float AttackSpeed;  //����
    [SerializeField] 
    private int Hp;           //ü��
    
    private int gold;       


    private bool beAttacked;
    PlayingUI playingUI;


    public void Awake()
    {
        gold = 100;
        goldText = GetComponent<Text>();
        hp = GetComponent<Image>();
        characterImage = GetComponent<Image>();
    }
    private void HpImage()
    {
        if (beAttacked)
        {
            Hp--;
        }
    }
    private void ClassUpgrade()
    {
        characterImage = UpgradedClass;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField]
    public GameObject Sword;
    [SerializeField]
    public GameObject Archor;
    [SerializeField]
    public GameObject Shield;
    [SerializeField]
    public GameObject Mage;

    public Text Hp;
    public Text Damage;
    public Text MoveSpeed;
    public Text AttackRate;
    public Text CriticalRate;
    public Text CriticalDamage;

    public Image SelectoedImage;
    public GameObject CharacterAnim;

    private void Awake()
    {
        CharacterAnim.SetActive(false);

        string SelectedImageName = SelectoedImage.sprite.name;
    }
    public void ShowCharacter(string SelectedImageName)
    {
        CharacterAnim.SetActive (true);
        if (SelectedImageName == "Sword")
        {
            Hp.text = "ü��:6";
            Damage.text = "���ݷ�:100";
            MoveSpeed.text = "�̵��ӵ�:5";
            AttackRate.text = "���ݼӵ�:5";
            CriticalRate.text = "ġ��Ÿ Ȯ��:20%";
            CriticalDamage.text = "ġ��Ÿ ������:150%";

            Sword.SetActive(true);
            Archor.SetActive(false);
            Shield.SetActive(false);
            Mage.SetActive(false);
        }
        else if (SelectedImageName == "Archor")
        {
            Hp.text = "ü��:3";
            Damage.text = "���ݷ�:150";
            MoveSpeed.text = "�̵��ӵ�:7";
            AttackRate.text = "�����ӵ�:3";
            CriticalRate.text = "ġ��Ÿ Ȯ��:40%";
            CriticalDamage.text = "ġ��Ÿ ������:200%";

            Sword.SetActive(false);
            Archor.SetActive(true);
            Shield.SetActive(false);
            Mage.SetActive(false);
        }
        else if (SelectedImageName == "Shield")
        {
            Hp.text = "ü��:4";
            Damage.text = "���ݷ�:80";
            MoveSpeed.text = "�̵��ӵ�:4";
            AttackRate.text = "���ݼӵ�:4";
            CriticalRate.text = "ġ��Ÿ Ȯ��:10%";
            CriticalDamage.text = "ġ��Ÿ ������:130%";

            Sword.SetActive(false);
            Archor.SetActive(false);
            Shield.SetActive(true);
            Mage.SetActive(false);
        }
        else if (SelectedImageName == "Mage")
        {
            Hp.text = "ü��:3";
            Damage.text = "����:200";
            MoveSpeed.text = "�̵��ӵ�:4";
            AttackRate.text = "�ɽ��� �ӵ�:3";
            CriticalRate.text = "ġ��Ÿ Ȯ��:30%";
            CriticalDamage.text = "ġ��Ÿ ������:180%";

            Sword.SetActive(false);
            Archor.SetActive(false);
            Shield.SetActive(false);
            Mage.SetActive(true);
        }
    }
    public void StartButton()
    {
        Debug.Log("���� ��ȯ�մϴ�.");
        SceneManager.LoadScene("Stage1");
    }
}

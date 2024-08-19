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
            Hp.text = "체력:6";
            Damage.text = "공격력:100";
            MoveSpeed.text = "이동속도:5";
            AttackRate.text = "공격속도:5";
            CriticalRate.text = "치명타 확률:20%";
            CriticalDamage.text = "치명타 데미지:150%";

            Sword.SetActive(true);
            Archor.SetActive(false);
            Shield.SetActive(false);
            Mage.SetActive(false);
        }
        else if (SelectedImageName == "Archor")
        {
            Hp.text = "체력:3";
            Damage.text = "공격력:150";
            MoveSpeed.text = "이동속도:7";
            AttackRate.text = "장전속도:3";
            CriticalRate.text = "치명타 확률:40%";
            CriticalDamage.text = "치명타 데미지:200%";

            Sword.SetActive(false);
            Archor.SetActive(true);
            Shield.SetActive(false);
            Mage.SetActive(false);
        }
        else if (SelectedImageName == "Shield")
        {
            Hp.text = "체력:4";
            Damage.text = "공격력:80";
            MoveSpeed.text = "이동속도:4";
            AttackRate.text = "공격속도:4";
            CriticalRate.text = "치명타 확률:10%";
            CriticalDamage.text = "치명타 데미지:130%";

            Sword.SetActive(false);
            Archor.SetActive(false);
            Shield.SetActive(true);
            Mage.SetActive(false);
        }
        else if (SelectedImageName == "Mage")
        {
            Hp.text = "체력:3";
            Damage.text = "마력:200";
            MoveSpeed.text = "이동속도:4";
            AttackRate.text = "케스팅 속도:3";
            CriticalRate.text = "치명타 확률:30%";
            CriticalDamage.text = "치명타 데미지:180%";

            Sword.SetActive(false);
            Archor.SetActive(false);
            Shield.SetActive(false);
            Mage.SetActive(true);
        }
    }
    public void StartButton()
    {
        Debug.Log("씬을 전환합니다.");
        SceneManager.LoadScene("Stage1");
    }
}

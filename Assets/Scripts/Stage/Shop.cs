using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public bool canOpen;
    private bool itemExTrue;
    private Image SellingItemImage;

    [SerializeField]
    public Image ExItemImage; // 아이템의 이미지
    [SerializeField]
    public Text ExItemNameText; //아이템의 이름 텍스트
    [SerializeField]
    public Text ExItemDescriptionText; //추임세 택스트
    [SerializeField]
    public Text ExItemText; // 아이템의 효과 텍스트
    [SerializeField]
    GameObject SellingItemExplain;
    [SerializeField]
    BoxCollider2D boxCollider;


    private void Start()
    { 
        SellingItemExplain.SetActive(false);

        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (itemExTrue)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SellingItemExplain.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = true;
            Debug.Log("Player has entered the box!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
            Debug.Log("Player has left the box!");
        }
    }

    public void Open()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canOpen)
            {
                canOpen = false;
            }
        }
    }
    public void ItemExplainFunction(Image ItemName)
    {
        if (ItemName.sprite != null)
        {
            ChangeImageText(ItemName);
            SellingItemExplain.SetActive(true);
            itemExTrue = true;
        }
    }
    private void ChangeImageText(Image ItemName)
    {
        ExItemImage.sprite = ItemName.sprite;

        switch (ExItemImage.sprite.name)
        {
            case "Rune Stone":
                ExItemNameText.text = "룬스톤";
                ExItemDescriptionText.text = "고대 룬이 새겨진 돌쪼가리";
                ExItemText.text = "공/마 +10%";
                break;
            case "Chest":
                ExItemNameText.text = "판도라의 상자";
                ExItemDescriptionText.text = "이번에야말로 나올겁니다! 아마도..?";
                ExItemText.text = "사용시 랜덤한 아이템 획득";
                break;
            case "Feather":
                ExItemNameText.text = "천사의 깃털";
                ExItemDescriptionText.text = "천사의 날개에서 떨어진 깃털";
                ExItemText.text = "이동속도+2, 점프력 +2";
                break;
            case "Monster Eye":
                ExItemNameText.text = "용의 눈";
                ExItemDescriptionText.text = "생전 강력했던 몬스터의 눈이다.";
                ExItemText.text = "공/마+20%";
                break;
            case "Slime Gel":
                ExItemNameText.text = "슬라임 점액";
                ExItemDescriptionText.text = "생각보다 쫀쫀하다..?";
                ExItemText.text = "상점에 판매시 100G 획득";
                break;
            case "Helm":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Iron Armor":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Iron Boot":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Iron Helmet":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Leather Armor":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Leather Boot":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Leather Helmet":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Skull":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Wizard Hat":
                ExItemNameText.text = "";
                ExItemDescriptionText.text = "";
                ExItemText.text = "";
                break;
            case "Beer":
                ExItemNameText.text = "맥주";
                ExItemDescriptionText.text = "시원한 맥주한잔! 기분이 좋지만 약간 취합니다!";
                ExItemText.text = "체력3 회복, 1스테이지간 이동속도 -2, 공격속도 20%감소";
                break;
            case "Bone":
                ExItemNameText.text = "뼈";
                ExItemDescriptionText.text = "칼륨 섭취! 뼈가 단단해졌습니다!";
                ExItemText.text = "최대체력 1증가";
                break;
            case "Bread":
                ExItemNameText.text = "빵";
                ExItemDescriptionText.text = "빵은 역시 식빵! 부드럽고 담백한 빵입니다!";
                ExItemText.text = "체력 1회복";
                break;
            case "Fish Steak":
                ExItemNameText.text = "물고기 스테이크";
                ExItemDescriptionText.text = "스테이크입니다! 비록 고기는 아니지만..";
                ExItemText.text = "체력 2 회복";
                break;
            case "Ham":
                ExItemNameText.text = "햄";
                ExItemDescriptionText.text = "판타지의 정석! 한입 크게 하고싶은 생김새!";
                ExItemText.text = "체력 3회복";
                break;
            case "Heart":
                ExItemNameText.text = "생명력";
                ExItemDescriptionText.text = "화이팅입니다! 응원을 받았습니다!";
                ExItemText.text = "최대체력 2증가";
                break;
            case "Monster Meat":
                ExItemNameText.text = "몬스터 고기";
                ExItemDescriptionText.text = "역하지만 어쩌겠습니까! 살아야죠!";
                ExItemText.text = "체력 2 회복, 최대체력 1 감소";
                break;
            case "Wine":
                ExItemNameText.text = "와인(용의 숨결)";
                ExItemDescriptionText.text = "강렬하고 강력한 맛! 용의 숨결처럼 뜨겁고 화려한 와인!";
                ExItemText.text = "상점에 판매시 500G획득";
                break;
            case "Copper Coin":
                ExItemNameText.text = "동화";
                ExItemDescriptionText.text = "흔한 동화입니다.";
                ExItemText.text = "골드 획득량 5% 증가";
                break;
            case "Golden Coin":
                ExItemNameText.text = "금화";
                ExItemDescriptionText.text = "당신도 이제 부자!";
                ExItemText.text = "골드 획득량 25% 증가";
                break;
            case "Golden Ingot":
                ExItemNameText.text = "골드바";
                ExItemDescriptionText.text = "진짜 골드바! 초콜릿은 아닐겁니다..";
                ExItemText.text = "300G 획득";
                break;
            case "Silver Coin":
                ExItemNameText.text = "은화";
                ExItemDescriptionText.text = "나름 귀한 동전입니다.";
                ExItemText.text = "골드 획득량 15% 증가";
                break;
            case "Arrow":
                ExItemNameText.text = "화살";
                ExItemDescriptionText.text = "그다지 좋은 화살은.. 그래도 기존보다는 좋습니다!";
                ExItemText.text = "공격력 +10%";
                break;
            case "Bow":
                ExItemNameText.text = "활";
                ExItemDescriptionText.text = "그다지 좋은 활은… 그래도 기존보다는 좋습니다!\r\n";
                ExItemText.text = "공격력 +10%";
                break;
            case "Emerald Staff":
                ExItemNameText.text = "에메랄드 스태프";
                ExItemDescriptionText.text = "에메랄드는 얼마일까요? 마력반응이 빨라집니다!";
                ExItemText.text = "캐스팅 속도 +10%";
                break;
            case "Golden Sword":
                ExItemNameText.text = "화려한 검";
                ExItemDescriptionText.text = "멋지고 예쁘지만 실용성은 떨어진다. 쓰쓰쓰?";
                ExItemText.text = "공격력 +5%, 치명타 데미지 +30%";
                break;
            case "Iron Shield":
                ExItemNameText.text = "강철방패";
                ExItemDescriptionText.text = "넌 못지나간다!";
                ExItemText.text = "최대체력 +3, 이동속도 -1"; ;
                break;
            case "Iron Sword":
                ExItemNameText.text = "철검";
                ExItemDescriptionText.text = "평범한 철검. 재미없는 검이다\r\n";
                ExItemText.text = "공격력 +10%";
                break;
            case "Knife":
                ExItemNameText.text = "암살자의 단검";
                ExItemDescriptionText.text = "암살자들이 사용하던 단검입니다.";
                ExItemText.text = "치명타 확률 +20%";
                break;
            case "Magic Wand":
                ExItemNameText.text = "딱총나무 지팡이";
                ExItemDescriptionText.text = "Avada Kedavra!";
                ExItemText.text = "마력+50%, 캐스팅 속도 +30%";
                break;
            case "Sapphire Staff":
                ExItemNameText.text = "사파이어 스태프";
                ExItemDescriptionText.text = "영롱하네요.. 마법공격력이 상승합니다!";
                ExItemText.text = "마력 +10%";
                break;
            case "Silver Sword":
                ExItemNameText.text = "강철검";
                ExItemDescriptionText.text = "실용적이고 단단한 검.";
                ExItemText.text = "공격력 +20%";
                break;
            case "Wooden Shield":
                ExItemNameText.text = "나무방패";
                ExItemDescriptionText.text = "황단목으로 만든 단단한 나무방패!";
                ExItemText.text = "최대체력+2";
                break;
            case "Wooden Staff":
                ExItemNameText.text = "고목나무 스태프";
                ExItemDescriptionText.text = "오래된 나무면..안부러지나,,?";
                ExItemText.text = "마력 +15%,캐스팅 속도 +15%";
                break;
            case "Wooden Sword":
                ExItemNameText.text = "나무검";
                ExItemDescriptionText.text = "꼬꼬마 시절 들고놀던 나무검. 생각보다 단단할지도..?\r\n";
                ExItemText.text = "공격력 +5%";
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingUI : MonoBehaviour
{
    private int MobCount;

    [SerializeField]
    private Sprite changeImage;
    Sprite currentImage;

    private void Start()
    {
        currentImage = GetComponent<Sprite>();
    }
    public void ChangeImage()
    {
        currentImage = changeImage;
    }
}

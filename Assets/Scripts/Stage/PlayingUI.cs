using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingUI : MonoBehaviour
{
    [SerializeField]
    private Sprite changeImage;
    Sprite currentImage;

    private void Awake()
    {
        currentImage = GetComponent<Sprite>();
    }
    public void ChangeImage()
    {
        currentImage = changeImage;
    }
}

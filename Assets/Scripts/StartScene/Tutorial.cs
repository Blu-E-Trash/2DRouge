using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : StartUI
{
    void Update()
    {
        if(tutorialOPen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TutorialUI.SetActive(false);
                tutorialOPen = false;
            }
        }
    }
}

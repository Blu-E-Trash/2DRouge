using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField]
    private GameObject TutorialUI;


    private bool tutorialOPen;

    private void Start()
    {
        TutorialUI.SetActive(false);
        tutorialOPen = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (tutorialOPen)
            {
                TutorialUI.SetActive(false);
                tutorialOPen = false;
            }
        }
    }
    public void StartButton()
    {
        if (!tutorialOPen)
        {
            SceneManager.LoadScene("Stage1");
        }
    }
    public void ExitButton()
    {
        if (!tutorialOPen)
        {
            Application.Quit();
        }
    }
    public void TutorialButton()
    {
        TutorialUI.SetActive(true);
        tutorialOPen = true;
    }
}

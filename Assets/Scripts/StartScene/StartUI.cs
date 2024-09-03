using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField]
    protected GameObject TutorialUI;
    protected bool tutorialOPen;

    private void Start()
    {
        TutorialUI.SetActive(false);
        tutorialOPen = false;
    }
    public void StartButton()
    {
        if (!tutorialOPen)
        {
            SceneManager.LoadScene("Lobby");
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

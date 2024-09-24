using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField]
    private GameObject TutorialUI;
    [SerializeField]
    private GameObject Tutorial;
    [SerializeField]
    private GameObject startUI;
    [SerializeField]
    private GameObject Quit;


    private bool tutorialOPen;

    private void Start()
    {
        gameObject.SetActive(true);
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
                startUI.SetActive(true);
                Tutorial.SetActive(true);
                Quit.SetActive(true);
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
        startUI.SetActive(false);
        Quit.SetActive(false);
        Tutorial.SetActive(false);

        tutorialOPen = true;
    }
}

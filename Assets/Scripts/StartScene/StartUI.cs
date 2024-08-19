using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}

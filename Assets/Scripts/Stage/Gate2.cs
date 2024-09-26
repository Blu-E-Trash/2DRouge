using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate2 : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject defeatUI;
    private GameManager gameManager;
    private bool isVictory = false;
    private void Update()
    {
        if (isVictory)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("FirstSceen");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "BS")
        {
            gameOverUI.SetActive(true);
            defeatUI.SetActive(false);
            isVictory = true;
            gameManager.isGameOver = true;
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameObject.SetActive(true);
    }
}

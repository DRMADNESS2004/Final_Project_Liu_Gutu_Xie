using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGameEnd : MonoBehaviour
{
    [SerializeField]
    private bool isWon = false;
    [SerializeField]
    private GameObject victoryCanvas;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (!triggered && collision.CompareTag("Player"))
        {
            isWon = true;
            Debug.Log("entered");
            triggered = true;
        }
    }

    void Update()
    {
        if (isWon)
        {
            Won();
        }
        if (!isWon)
        {
            NotWon();
        }
    }

    public void Won()
    {
        Time.timeScale = 0;
        victoryCanvas.SetActive(true);
        isWon = true;
    }

    public void NotWon()
    {

        Time.timeScale = 1;
        victoryCanvas.SetActive(false);
        isWon = false;

    }

    public void exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Lobby");
    }
}

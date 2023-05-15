using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayMenus : MonoBehaviour
{
    public GameObject startMenu;

    public GameObject endMenu;

    public TextMeshProUGUI totalScore;

    public TextMeshProUGUI currentScore;

    public TextMeshProUGUI totalQuestions;

    public Button replay;

    public Button menu;

    public TextMeshProUGUI validation;

    AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        am=GetComponent<AudioManager>();
        StartMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Constants.QUESTIONNUM == Constants.QUESTIONS.Length - 1)
        {
            Time.timeScale = 0;
            endMenu.SetActive(true);
            totalQuestions.text = $"/{Constants.QUESTIONS.Length - 1}";
            totalScore.text=currentScore.text;
            am.Play("Space");
        }
    }

    public void Replay()
    {
        Time.timeScale = 1;
        endMenu.SetActive(false);
        currentScore.text = "0";
        validation.text = "";
        Constants.QUESTIONNUM = 0;
        Constants.NEWQUESTION = true;
        am.Stop("Space");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Constants.MAINSCENENAME);
    }

    public void StartMenu()
    {
        if (Constants.STARTGAME)
        {
            Time.timeScale = 0;
            startMenu.SetActive(true);
            am.Play("Space");
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startMenu.SetActive(false);
        currentScore.text = "0";
        validation.text = "";
        Constants.QUESTIONNUM = 0;
        am.Stop("Space");
    }
}

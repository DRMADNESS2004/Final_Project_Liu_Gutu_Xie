using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayEndMenu : MonoBehaviour
{

    public GameObject endMenu;

    public TextMeshProUGUI totalScore;

    public TextMeshProUGUI currentScore;

    public TextMeshProUGUI totalQuestions;

    public Button replay;

    public Button menu;

    public TextMeshProUGUI validation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Constants.QUESTIONNUM == 2/*Constants.QUESTIONS.Length - 1*/)
        {
            Time.timeScale = 0;
            endMenu.SetActive(true);
            totalQuestions.text = $"/{Constants.QUESTIONS.Length - 1}";
            totalScore.text=currentScore.text;
            
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
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Constants.MAINSCENENAME);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayEndMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject endMenu;

    [SerializeField]
    private TextMeshProUGUI totalScore;

    [SerializeField] 
    private TextMeshProUGUI currentScore;

    [SerializeField] 
    private TextMeshProUGUI totalQuestions;

    [SerializeField]
    private Button replay;

    [SerializeField]
    private Button menu;

    [SerializeField]
    private TextMeshProUGUI validation;

    // Start is called before the first frame update
    void Start()
    {
        
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
            
        }
    }

    public void Replay()
    {
        Time.timeScale = 1;
        endMenu.SetActive(false);
        currentScore.text = "0";
        validation.text = "";
        Constants.QUESTIONNUM = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Constants.MAINSCENENAME);
    }
}

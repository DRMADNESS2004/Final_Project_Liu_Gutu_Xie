using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField]
    private bool isStarted = false;
    [SerializeField]
    private GameObject startCanvas;

    [SerializeField]
    private bool isPaused = false;
    [SerializeField]
    private GameObject pausedCanvas;

    [SerializeField]
    private TMP_Text mTxt;

    [SerializeField]
    private bool isWon = false;
    [SerializeField]
    private GameObject victoryCanvas;

    public TMP_Text livestxt;

    [SerializeField]
    private bool isLost = false;
    [SerializeField]
    private GameObject DefeatCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //start
        if (isStarted)
        {
            Started();
        }
        if (!isStarted)
        {
            NotStarted();
        }
        //pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseMe();
            }
        }
        //victory
        int boom = Convert.ToInt32(mTxt.text);
        
        if(boom == 20)
        {
            isWon = true;
        }

        
        if (isWon)
        {
            Won();
        }
        if (!isWon)
        {
            NotWon();
        }

        //defeat...`
        int life = Convert.ToInt32(livestxt.text);
        if(life == 0)
        {
            isLost = true;
        }

        if (isLost)
        {
            Lost();
        }
        if (!isLost)
        {
            NotLost();
        }


    }

    public void NotStarted()
    {
        Time.timeScale = 0;
        startCanvas.SetActive(true);
        isStarted = false;
    }

    public void Started()
    {
        Time.timeScale = 1;
        startCanvas.SetActive(false);
        isStarted = true;
        victoryCanvas.SetActive(false);
    }

    public void PauseMe()
    {
        Time.timeScale = 0;
        pausedCanvas.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausedCanvas.SetActive(false);
        isPaused = false;
    }

    public void restart()
    {
        NotStarted();
        ScoreSystem.scoreSystem.Reset();
        mTxt.text = "0";
        livestxt.text = "3";
        //NotWon();   
        //NotLost();
        isLost = false;
        isWon = false;
    }

    public void exit()
    {
        SceneManager.LoadScene("MainArea");
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

    public void Lost()
    {
        Time.timeScale = 0;
        DefeatCanvas.SetActive(true);
        isLost = true;
    }

    public void NotLost()
    {
        Time.timeScale = 1;
        DefeatCanvas.SetActive(false);
        isLost = false;
    }
}

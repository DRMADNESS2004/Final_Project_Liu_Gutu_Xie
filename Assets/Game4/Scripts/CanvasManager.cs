using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
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
    private GameObject cpuCanvas;

    [SerializeField]
    private GameObject ramCanvas;

    [SerializeField]
    private GameObject hardDCanvas;

    [SerializeField]
    private GameObject keyboardCanvas;

    [SerializeField]
    private GameObject motheboardCanvas;

    [SerializeField]
    private GameObject mouseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        DropBox db = GetComponent<DropBox>();
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
    public void exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Lobby");
    }

    public void ok()
    {
        cpuCanvas.SetActive(false);
        ramCanvas.SetActive(false);
        hardDCanvas.SetActive(false);
        keyboardCanvas.SetActive(false);
        motheboardCanvas.SetActive(false);
        mouseCanvas.SetActive(false);

        DropBox db = GameObject.Find("DropBoxObj").GetComponent<DropBox>();
        if (db != null)
        {   
            db.questionsV2();
        }
        db.addToQuestionCounter();
    }
}
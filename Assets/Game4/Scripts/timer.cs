using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField]
    private float timeLeft = 30.0f;
    
    public bool timerOn = false;
    [SerializeField]
    private TMP_Text timerTxt;

    [SerializeField]
    private GameObject lostCanvas;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                Debug.Log("times up kaboom");
                timeLeft = 0;
                timerOn = false;
                lostCanvas.SetActive(true);

            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
        
}

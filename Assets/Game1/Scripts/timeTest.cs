using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timeTest : MonoBehaviour
{
    [SerializeField]
    private Slider timerSlider;

    [SerializeField]
    private TMP_Text timertxt;

    [SerializeField]
    private float gameTime = 10;

    [SerializeField]
    private bool stopTimer;

    // Start is called before the first frame update
    void Start()
    {
        //stopTimer = false;
        //timerSlider.maxValue = gameTime;
        //timerSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("restartTimer", 3f);

        {
            //float time = gameTime - Time.time;

            //int minutes = Mathf.FloorToInt(time / 60);
            //int seconds = Mathf.FloorToInt(time - minutes * 60f);

            //string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            //if (time <= 0)
            //{
            //    stopTimer = true;
            //}
            //if (stopTimer == false)
            //{
            //    timertxt.SetText(textTime);
            //    timerSlider.value = time;

            //}

            //if(timerSlider.value <= 0.2)
            //{
            //    //wrong
            //    onClick oc = GetComponent<onClick>();
            //    oc.notRight();
            //}

        }

    }
}
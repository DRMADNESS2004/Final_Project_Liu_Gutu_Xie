using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DisplayQuestions : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI question;
    [SerializeField]
    private TextMeshProUGUI option1;
    [SerializeField]
    private TextMeshProUGUI option2;
    [SerializeField]
    private TextMeshProUGUI option3;
    [SerializeField]
    private TextMeshProUGUI option1_display;
    [SerializeField]
    private TextMeshProUGUI option2_display;
    [SerializeField]
    private TextMeshProUGUI option3_display;

    private List<int> arr = new List<int>{1,2,3};

    void Start()
    {
        Shuffle(arr);
        question.text = Constants.QUESTIONS[Constants.QUESTIONNUM][0];
        option1_display.text = option1.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[0]];
        option2_display.text = option2.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[1]];
        option3_display.text = option3.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[2]];
        Constants.NEWQUESTION = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Constants.NEWQUESTION && Constants.QUESTIONNUM != Constants.QUESTIONS.Length - 1) 
        {
            Shuffle(arr);
            question.text = Constants.QUESTIONS[Constants.QUESTIONNUM][0];
            option1_display.text = option1.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[0]];
            option2_display.text = option2.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[1]];
            option3_display.text = option3.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[2]];
            Constants.NEWQUESTION = false;
        }
    }

    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

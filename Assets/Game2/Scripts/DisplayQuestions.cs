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

    private List<int> arr = new List<int>{1,2,3};

    void Start()
    {
        Shuffle(arr);
        question.text = Constants.QUESTIONS[Constants.QUESTIONNUM][0];
        option1.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[0]];
        option2.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[1]];
        option3.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[2]];
        Constants.NEWQUESTION = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Constants.NEWQUESTION)
        {
            Shuffle(arr);
            question.text = Constants.QUESTIONS[Constants.QUESTIONNUM][0];
            option1.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[0]];
            option2.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[1]];
            option3.text = Constants.QUESTIONS[Constants.QUESTIONNUM][arr[2]];
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

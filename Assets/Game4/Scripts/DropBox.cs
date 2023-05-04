using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropBox : MonoBehaviour, IDropHandler
{
    //[HideInInspector]
    public int id;

    public AudioSource right;
    public AudioSource wrong;

    [SerializeField]
    private TMP_Text question;
    private int questionId;
    private int questionCounter = 1;


    bool isCpuDone = false;
    bool isRamDone = false;
    bool isHardDone = false;
    bool isKeyDone = false;
    bool isMotherBDone = false;
    bool isMouseDone = false;
    Stack<int> stack = new Stack<int>();


    //[SerializeField]
    //private bool isWon = false;
    [SerializeField]
    private GameObject victoryCanvas;


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragNDrop>().id == id)
            {
                Debug.Log("Correct");
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                right.Play();

                Invoke("questionsV2", 2f);
                Debug.Log("questions asked +1");
                questionCounter++;
            }
            else
            {
                Debug.Log("Incorrect");
                eventData.pointerDrag.GetComponent<DragNDrop>().ResetPosition();
                wrong.Play();
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //getQuestion();
        startStack();
        Invoke("questionsV2", 2f);
        //isCpuDone = false;
        //isRamDone = false;
        //isHardDone = false;
        //isKeyDone = false;
        //isMotherBDone = false;
        //isMouseDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (questionCounter == 6)
        {
            victoryCanvas.SetActive(true);
        }
    }

    //public void getQuestion()
    //{
    //    questionId = UnityEngine.Random.Range(13, 7);
    //    Debug.Log(questionId);
    //    if(questionId == 1 && !isCpuDone)
    //    {
    //        id = questionId;
    //        question.text = "Which is the CPU?";
    //         isCpuDone = true;

    //    }
    //    else
    //    {
    //        questionId = UnityEngine.Random.Range(1, 7);
    //    }

    //    if (questionId == 2 && !isRamDone)
    //    {
    //        id = questionId;
    //        question.text = "Which is the Ram?";
    //         isRamDone = true;
    //    }
    //    else
    //    {
    //        questionId = UnityEngine.Random.Range(1, 7);
    //    }

    //    if (questionId == 3 && !isHardDone)
    //    {
    //        id = questionId;
    //        question.text = "Which is the Hard drive?";
    //        isHardDone = true;
    //    }
    //    else
    //    {
    //        questionId = UnityEngine.Random.Range(1, 7);
    //    }

    //    if (questionId == 4 && !isKeyDone)
    //    {
    //        id = questionId;
    //        question.text = "Which is the Keyboard?";
    //        isKeyDone = true;
    //    }
    //    else
    //    {
    //        questionId = UnityEngine.Random.Range(1, 7);
    //    }

    //    if (questionId == 5 && !isMotherBDone)
    //    {
    //        id = questionId;
    //        question.text = "Which is the Motherboard?";
    //        isMotherBDone = true;
    //    }
    //    else
    //    {
    //        questionId = UnityEngine.Random.Range(1, 7);
    //    }

    //    if (questionId == 6 && !isMouseDone)
    //    {
    //        id = questionId;
    //        question.text = "Which is the Mouse?";
    //        isMouseDone = true;
    //    }
    //    else
    //    {
    //        questionId = UnityEngine.Random.Range(1, 7);
    //    }

    //}

    public void questionsV2()
    {
       

       

        int top = stack.Peek();
        Debug.Log(stack.Peek());
        id = top;
        questionId = top;



        if (questionId == 1 && !isCpuDone)
        {
            id = questionId;
            question.text = "Which is the CPU?";
            isCpuDone = true;

        }

        if (questionId == 2 && !isRamDone)
        {
            id = questionId;
            question.text = "Which is the Ram?";
            isRamDone = true;
        }


        if (questionId == 3 && !isHardDone)
        {
            id = questionId;
            question.text = "Which is the Hard drive?";
            isHardDone = true;
        }


        if (questionId == 4 && !isKeyDone)
        {
            id = questionId;
            question.text = "Which is the Keyboard?";
            isKeyDone = true;
        }


        if (questionId == 5 && !isMotherBDone)
        {
            id = questionId;
            question.text = "Which is the Motherboard?";
            isMotherBDone = true;
        }

        if (questionId == 6 && !isMouseDone)
        {
            id = questionId;
            question.text = "Which is the Mouse?";
            isMouseDone = true;
        }

        stack.Pop();

    }
    public void startStack()
    {

        {
            for (int i = 1; i <= 6; i++)
            {
                stack.Push(i);
            }

            //randomize stack
            int[] array = stack.ToArray();
            stack.Clear();
            while (array.Length > 0)
            {
                int index = UnityEngine.Random.Range(0, array.Length);
                int value = array[index];
                stack.Push(value);
                List<int> list = new List<int>(array);
                list.RemoveAt(index);
                array = list.ToArray();
            }
           
        }




    }
}

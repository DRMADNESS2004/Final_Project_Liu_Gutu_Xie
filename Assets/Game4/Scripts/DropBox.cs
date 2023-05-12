using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private int questionCounter = 0;


    bool isCpuDone = false;
    bool isRamDone = false;
    bool isHardDone = false;
    bool isKeyDone = false;
    bool isMotherBDone = false;
    bool isMouseDone = false;
    Stack<int> stack = new Stack<int>();

    [SerializeField]
    private GameObject victoryCanvas;

    [SerializeField]
    private GameObject locked;
    [SerializeField]
    private GameObject match;

    Dictionary<int, GameObject> canvasDict = new Dictionary<int, GameObject>();

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

                GameObject canvasToActivate;
                if (canvasDict.TryGetValue(id, out canvasToActivate))
                {
                    canvasToActivate.SetActive(true);
                }

                //Invoke("questionsV2", 2f);
                //Debug.Log("questions asked +1");
                //questionCounter++;
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
        startStack();
        Invoke("questionsV2", 2f);
        canvasDict.Add(1, cpuCanvas);
        canvasDict.Add(2, ramCanvas);
        canvasDict.Add(3, hardDCanvas);
        canvasDict.Add(4, keyboardCanvas);
        canvasDict.Add(5, motheboardCanvas);
        canvasDict.Add(6, mouseCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(questionCounter);
        if (questionCounter == 6)
        {
            match.SetActive(false);
            locked.SetActive(true);
        }
    }

    public void questionsV2()
    {
        try
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
        catch(InvalidOperationException e)
        {
            Debug.LogWarning("Stack is empty: " + e.Message);
            match.SetActive(false);
            locked.SetActive(true);

        }

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
    public void addToQuestionCounter()
    {
        questionCounter++;
    }
}

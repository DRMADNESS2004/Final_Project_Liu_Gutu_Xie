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
    //blah blah blah
    
    bool isCpuDone = false;
    bool isRamDone = false;
    bool isHardDone = false;
    bool isKeyDone = false;
    bool isMotherBDone = false;
    bool isMouseDone = false;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        if(eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.GetComponent<DragNDrop>().id == id)
            {
                Debug.Log("Correct");
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                right.Play();
                Invoke("getQuestion", 2f);
               
            }
            else{
                Debug.Log("Incorrect");
                eventData.pointerDrag.GetComponent<DragNDrop>().ResetPosition();
                wrong.Play();
            }
           
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        getQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getQuestion()
    {
        questionId = Random.Range(1, 6);
        if(questionId == 1 && !isCpuDone)
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
    }

    IEnumerator WaitAWhile()
    {
        yield return new WaitForSeconds(2);

        
    }

}

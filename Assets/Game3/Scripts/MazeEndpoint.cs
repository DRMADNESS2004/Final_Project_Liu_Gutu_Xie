using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeEndpoint : MonoBehaviour
{

    public Canvas messageBoxCanvas;
    public string messageText;

    private Text messageTextComponent;

    void Start()
    {
        messageTextComponent = messageBoxCanvas.GetComponentInChildren<Text>();
        messageBoxCanvas.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            messageTextComponent.text = messageText;
            messageBoxCanvas.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            messageBoxCanvas.enabled = false;
        }
    }
}

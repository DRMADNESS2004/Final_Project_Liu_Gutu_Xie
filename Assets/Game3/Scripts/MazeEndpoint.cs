using UnityEngine;
using UnityEngine.UI;

public class TriggerMessage : MonoBehaviour
{
    public Canvas messageCanvas;
    public Text messageText;
    public string triggerMessage;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.CompareTag("Player"))
        {
            triggered = true;
            messageText.text = triggerMessage;
            messageCanvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (triggered && collision.CompareTag("Player"))
        {
            triggered = false;
            messageCanvas.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnim : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public string[] lines;
    public float textSpeed;
    public CharacterMove characterMove;
    public GameObject dialogueBox;

    private int index;
    private bool isDialogueActive;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textMeshProUGUI.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textMeshProUGUI.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        characterMove.FreezeMovement();
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textMeshProUGUI.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length -1)
        {
            index++;
            textMeshProUGUI.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            isDialogueActive=false;
            characterMove.UnfreezeMovement();
            gameObject.SetActive(false);
            dialogueBox.SetActive(false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VerifyAnswers : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI validation;

    [SerializeField]
    private TextMeshProUGUI score;

    //[SerializeField]
    //private GameObject trash;

    private bool inRange = false;

    private GameObject lastCollided=null;

    Rigidbody2D rb2d;

    AudioManager am;

    // Start is called before the first frame update

    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        am=GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (inRange && !Constants.ISGRABBED && lastCollided!=null)
        {
            if (lastCollided.GetComponent<TextMeshProUGUI>().text == Constants.QUESTIONS[Constants.QUESTIONNUM][1]) 
            {
                rb2d.MovePosition(new Vector2(0, 2.12f));
                Debug.Log("correct");
                validation.text = "Correct!";
                int totalScore=int.Parse(score.text);
                totalScore++;
                score.text = totalScore.ToString();
                Constants.QUESTIONNUM++;
                Debug.Log(Constants.QUESTIONNUM);
                am.Play("Win");
                Constants.NEWQUESTION = true;
            }
            else
            {
                Debug.Log("Incorrect");
                validation.text = "Incorrect";
                rb2d.MovePosition(new Vector2(0, 2.12f));
                Constants.QUESTIONNUM++;
                Debug.Log(Constants.QUESTIONNUM);
                if (Constants.QUESTIONNUM < Constants.QUESTIONS.Length - 1)
                {
                    am.Play("Lose");
                }
                Constants.NEWQUESTION = true; 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.name == "option1" || collided.name == "option2" || collided.name == "option3")
        {
            inRange = false;
            lastCollided= null;
        }
        Debug.Log(inRange);
        Debug.Log(lastCollided);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.name == "option1" || collided.name == "option2" || collided.name == "option3")
        {
            inRange = true;
            lastCollided= collided;
        }
        Debug.Log(inRange);
        Debug.Log(lastCollided);
    }
}

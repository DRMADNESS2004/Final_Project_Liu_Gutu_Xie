using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem scoreSystem;

    public TMP_Text scoretxt;
    int score = 0;

    public TMP_Text livestxt;
    int lives = 3;


    public void Awake()
    {
        scoreSystem = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoretxt.text = score.ToString(); //resets it when game starts might want to remove...
        livestxt.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void correct()
    {
        score++;
        scoretxt.text = score.ToString();

    }

    public void incorrect()
    {
        if (lives > 0)
        {
            lives--;
        }
        livestxt.text = lives.ToString();
    }
}

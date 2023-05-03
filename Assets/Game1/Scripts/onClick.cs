using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class onClick : MonoBehaviour
{
    [SerializeField]
    private GameObject missile;

    [SerializeField]
    private TMP_Text astTxt;

    [SerializeField]
    private TMP_Text mTxt;

    public static NbrGenerator n;

    private bool correct = false;

    [SerializeField]
    private GameObject metor;

    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        generateNewQ();
    }

    // Update is called once per frame
    void Update()
    {
        if (correct)
        {
            transform.position = Vector2.MoveTowards(transform.position, metor.transform.position, speed * Time.deltaTime);
            transform.right = metor.transform.position - transform.position;

        }
    }

    int DecimalToBinary(int decimalNumber)
    {
        int bin1 = 0;
        int r1;
        int placement1 = 1;

        while (decimalNumber != 0)
        {
            r1 = decimalNumber % 2;
            decimalNumber = decimalNumber / 2;
            bin1 = bin1 + (r1 * placement1);
            placement1 = placement1 * 10;
        }
        return bin1;
    }

    private void OnMouseDown()
    {

        int dAst = Convert.ToInt32(astTxt.text);
        int boom = Convert.ToInt32(mTxt.text);
        int bAst = DecimalToBinary(int.Parse(dAst.ToString()));
        int Boom = int.Parse(boom.ToString());
        Debug.Log($"{bAst}");
        Debug.Log($"{Boom}");

        if (bAst == Boom)
        {
            //right
            Debug.Log("You hit the asteroid!");
            //prevents spam answering to cheat points as well as spam generating new questions
            if (!correct)
            {
                ScoreSystem.scoreSystem.correct();
                correct = true;


                Invoke("generateNewQ", 5f);
            }
            
            
        }
        else
        {
            //wrong
            Debug.Log("Missed the asteroid!");
            ScoreSystem.scoreSystem.incorrect();
        }


    }

    private void generateNewQ()
    {
        NbrGenerator nbrGen = FindObjectOfType<NbrGenerator>();
        if (nbrGen!=null)
        {
            nbrGen.assignRandom();
            correct = false;
        }
        else
        {
            Debug.LogError("NbrGenerator not found");
        }
    }

}

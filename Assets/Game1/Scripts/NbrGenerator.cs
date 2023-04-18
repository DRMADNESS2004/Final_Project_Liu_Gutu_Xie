using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NbrGenerator : MonoBehaviour
{
    private int astNbr;
    private int m1Nbr;
    private int m2Nbr;
    private int m3Nbr;
    private int m4Nbr;

    [SerializeField]
    private TMP_Text astTxt;

    [SerializeField]
    private TMP_Text m1Txt;

    [SerializeField]
    private TMP_Text m2Txt;

    [SerializeField]
    private TMP_Text m3Txt;

    [SerializeField]
    private TMP_Text m4Txt;

    private List<int> multChoiceAns = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            assignRandom();
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

    void assignRandom()
    {
        astNbr = Random.Range(1, 21);
        astTxt.text = "" + astNbr;

        //int num1 = astNbr;
        //int bin1 =0;
        //int r1;
        //int placement1 = 1;

        //while (num1 != 0)
        //{
        //    r1 = num1 % 2;
        //    num1 = num1 / 2;
        //    bin1 = bin1 + (r1 * placement1);
        //    placement1 = placement1 * 10;
        //}




        //int num2 = m2Nbr;
        //int bin2 = 0;
        //int r2;
        //int placement2 = 1;


        //while (num2 != 0)
        //{
        //    r2 = num2 % 2;
        //    num2 = num2 / 2;
        //    bin2 = bin2 + (r2 * placement2);
        //    placement2 = placement2 * 10;
        //}

        //int num3 = m3Nbr;
        //int bin3 = 0;
        //int r3;

        //int placement3 = 1;


        //while (num3 != 0)
        //{
        //    r3 = num3 % 2;
        //    num3 = num3 / 2;
        //    bin3 = bin3 + (r3 * placement3);
        //    placement3 = placement3 * 10;
        //}
        //int num4 = m4Nbr;
        //int bin4 = 0;
        //int r4;
        //int placement4 = 1;


        //while (num4 != 0)
        //{
        //    r4 = num4 % 2;
        //    num4 = num4 / 2;
        //    bin4 = bin4 + (r4 * placement4);
        //    placement4 = placement4 * 10;
        //}

        //m2Txt.text = "" + bin2;
        //m1Txt.text = "" + bin1;
        //m3Txt.text = "" + bin3;
        //m4Txt.text = "" + bin4;

        m2Nbr = Random.RandomRange(1, 21);
        m3Nbr = Random.RandomRange(1, 21);
        m4Nbr = Random.RandomRange(1, 21);

        //put em in a  list and assign at random to the .text things so the answer isn't at  the same place every time...
        multChoiceAns.Clear();
        multChoiceAns.Add(DecimalToBinary(m2Nbr));
        multChoiceAns.Add(DecimalToBinary(m3Nbr));
        multChoiceAns.Add(DecimalToBinary(m4Nbr));
        multChoiceAns.Add(DecimalToBinary(astNbr));


        //scramble List
        for (int i = 0; i < multChoiceAns.Count; i++)
        {
            int temp = multChoiceAns[i];
            int randomIndex = Random.Range(i, multChoiceAns.Count);
            multChoiceAns[i] = multChoiceAns[randomIndex];
            multChoiceAns[randomIndex] = temp;
        }

        if (m2Txt != null)
        {
            m2Txt.text = multChoiceAns[0].ToString();
        }
        if (m1Txt != null)
        {
            m1Txt.text = multChoiceAns[1].ToString();
        }
        if (m3Txt != null)
        {
            m3Txt.text = multChoiceAns[2].ToString();
        }
        if (m4Txt != null)
        {
            m4Txt.text = multChoiceAns[3].ToString();
        }


    }
}

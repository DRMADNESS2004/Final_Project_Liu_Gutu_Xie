using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Missile1OnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject missile;

    [SerializeField]
    private TMP_Text astTxt;

    [SerializeField]
    private TMP_Text mTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        //if(DecimalToBinary(astTxt).ToString  == mTxt)
        //{
        //    //do smth
        //}

        int dAst = Convert.ToInt32(astTxt);
        int boom = Convert.ToInt32(mTxt);
        int bAst = DecimalToBinary(dAst);
        if(bAst == boom)
        {
            Debug.Log("You hit the asteroid!");
        }
        else
        {
            Debug.Log("Missed the asteroid!");
        }

        
    }


}

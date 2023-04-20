using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public static readonly string[][] QUESTIONS = new string[][]
    {
        new string[] {"Q1: Select the correct syntax to print out \"hello world\"","System.out.println(\"Hello World\");","System.println(\"Hello World\");","println(\"Hello World\");"},
        new string[] {"Q2: What keyword should you use to comment out a single line","//","#","-"},
        new string[] {"Q3: What data type should you use to create a name variable","String","int","char"},
        new string[] {"Q4: What is the ouput of the following code: \nvar x = 5; \nSystem.out.println(x++);","5","6","error"},
        new string[] {"54: What is the ouput of the following code: \nvar x = 5; \nSystem.out.println(--x);","4","5","error"}

    };

    public static bool NEWQUESTION = true;
}

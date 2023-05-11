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
        new string[] {"Q5: What is the ouput of the following code: \nvar x = 5; \nSystem.out.println(--x);","4","5","error"},
        new string[] {"Q6: Which data type should you use to assign the following variable \nmyFloatNum = 8.99f;", "float","int","var"},
        new string[] {"Q7: Which data type should you use to assign the following variable \nmyBool = false;", "boolean","long","String"},
        new string[] {"Q8: Print the results of 10 multiplied by 5 \nSystem.out.println(10 ... 5);", "*","**","x"},
        new string[] {"Q9: Increase the value of the variable x by 1 \nint x = 10;", "All answers","++x","x+=1"},
        new string[] {"Q10: What method should you use to print the length of the txt string \nString txt = \"Hello\"; \nSystem.out.println(txt...);", ".length()", ".size()", ".Length"},
        new string[] {"Q11: Convert the String txt to upper case \nString txt = \"Hello\"; \nSystem.out.println(txt...);", ".toUpperCase()", ".toUpper()", ".strtoupper()"},
        new string[] {"Q12: Concatenate the two strings \nString firstName = \"John \"; \nString lastName = \"Doe\"; \nSystem.out.println(firstName ... lastName);", "+","plus","and"},
        new string[] {"Q13: Print the index (position) of the first occurrence of \"e\" in the string below \nString txt = \"Hello Everybody\"; \nSystem.out.println(txt. ...(\"e\"));", "indexOf", "get","position"},
        new string[] {"Q14: Find the highest value between x and y \nint x = 5; \nint y = 10; \nMath...(x, y);", ".max",".big",".high"},
        new string[] {"Q15: Find the square root of x. \nint x = 16; \nMath...(x);", "sqrt","root","square"},
        new string[] {"Q16: Find a random number between 1 and 100 \nMath...;", ".Random()*100+1",".Random(0,100)",".Random(100)"},
        new string[] {"Q17: Which option prints the value true \nint x = 10; \nint y = 9; \nSystem.out.println(...);", "All answers","y>8","x>y"},
        new string[] {"Q18: Print \"Hello World\" if x is greater than or equal to y \nint x = 50;\nint y = 10;\n (x ... y) {\nSystem.out.println(\"Hello World\");\n}", ">=","==","=>"},
        new string[] {"Q19: Which keyword creates an array of type String called cars. \n...={\"Volvo\", \"BMW\", \"Ford\"};", "String[] cars","Array<String> cars","ArrayList<String> cars"},
        new string[] {"Q20: Which option prints the second item in the cars array \nString[] cars = {\"Volvo\", \"BMW\", \"Ford\"};\nSystem.out.println(...);", "cars[1]", "cars.get(1)","cars[2]"}
    };

    public static bool NEWQUESTION = true;

    public static bool ISGRABBED = false;

    public static int QUESTIONNUM = 0;

    public static float LBORDER=-7.67f;
    public static float RBORDER=7.61f;
    public static float TBORDER=3.58f;
    public static float BBORDER=-3.56f;

    public static string MAINSCENENAME = "Lobby";
}

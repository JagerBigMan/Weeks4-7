using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptingProblems : MonoBehaviour
{
    public TMPro.TMP_Text premiseText;
    public TMPro.TMP_Text resultText;

    private void Start()
    {
        //SwapNumbers();
        //FindHighestNumber();
        //IncreaseAge();
        MovePosition();
    }

    public void SwapNumbers()
    {
        premiseText.text = "Swapping numbers: 5 and 3";
        int firstNumber = 5;
        int secondNumber = 3;

        int swappedFirstNumber = secondNumber; //placeholder variable to store the values of the numbers.
        int swappedSecondNumber = firstNumber;

        //firstNumber = secondNumber;  //firstNumber becomes 3
                                    //secondNumber can't become firstNumber since the value of firstNumber has changed to 3, aka lost in the process of swapping
        //secondNumber = firstNumber; 

        resultText.text = "First number[" + swappedFirstNumber.ToString() + "], Second number[" + swappedSecondNumber.ToString() + "]";

    }

    public void FindHighestNumber()
    {
        premiseText.text = "Finding the highest number out of 4, 3, 5, 1, 12, 6, 2";
        List<int> numbers = new List<int>() { 4, 3, 5, 1, 12, 6, 2 };
        int highestNumber = 0;

        for (int i = 0; i < numbers.Count; i++)  //We're checking the number now and the one that comes up, if the number comes up then it gets stored
        {
            if (numbers[i] > highestNumber)
            {
                highestNumber = numbers[i];		//The console shows it's counting from 1 to 6, when the current count is greater than the number it's counting it will stop and display that number.
            }
        }
        resultText.text = "Highest number[" + highestNumber.ToString() + "]";
    }

    class Person
    {
        public int age = 0;
        public string name = "";

        public Person()
        {
        }

        public Person(int inAge, string inName)
        {
            age = inAge;
            name = inName;
        }
    }

    public void IncreaseAge()
    {
        Person alice = new Person(32, "Alice");
        Person thomas = new Person(24, "Thomas");

        int ageIncrease = 3;
        premiseText.text = "Increasing age of Alice and Thomas";

        alice.age += ageIncrease;
        thomas.age += ageIncrease;
        resultText.text = "Alice is now " + alice.age.ToString() + " years old and Thomas is now " + thomas.age.ToString() + " years old.";
    }

    public void MovePosition()
    {
        Vector3 currentPosition = new Vector3(1.5f, 2.5f, 3.5f);
        premiseText.text = "Moving the position " + currentPosition.ToString();
        float shiftedX = 3 + (float)currentPosition.x;
        currentPosition.x = shiftedX;
        resultText.text = "Position is now " + currentPosition.ToString();
    }

}

using System;
using TMPro;
using UnityEngine;

public class Calculadora : MonoBehaviour
{
    public TMP_Text displayText;
    private string numberArray;
    private int currentNumber;
    private float result;
    private char lastOperator = '+';

    private void Start()
    {
        displayText.text = string.Empty;
    }

    public void InsertNumber(int number)
    {
        // Append the digit to the current number
        currentNumber = currentNumber * 10 + number;
        // Update the displayed number string
        displayText.text += number;
    }

    public void InsertPlus()
    {
        InsertOperator('+');
        displayText.text += " " + "+" + " ";
    }

    public void InsertMinus()
    {
        InsertOperator('-');
        displayText.text += " " + "-" + " ";
    }

    public void InsertMultiply()
    {
        InsertOperator('*');
        displayText.text += " " + "*" + " ";
    }

    public void InsertDivide()
    {
        InsertOperator('/');
        displayText.text += " " + "/" + " ";
    }

    private void InsertOperator(char op)
    {
        // Perform the operation using the last entered number and operator
        result = ApplyOperation(result, currentNumber, lastOperator);
        // Reset current number for the next input
        currentNumber = 0;
        // Update the last operator to the current one
        lastOperator = op;
        // Update the display with the intermediate result
        displayText.text = result.ToString();
    }

    public void Calculate()
    {
        // Perform the last operation to calculate the final result
        result = ApplyOperation(result, currentNumber, lastOperator);
        currentNumber = 0;
        displayText.text = result.ToString();
    }

    private float ApplyOperation(float left, float right, char op)
    {
        // Perform the calculation based on the operator
        return op switch
        {
            '+' => left + right,
            '-' => left - right,
            '*' => left * right,
            '/' => right != 0 ? left / right : throw new DivideByZeroException("Cannot divide by zero"),
            _ => throw new InvalidOperationException("Invalid operator: " + op),
        };
    }

    public void Clear()
    {
        // Reset all values
        currentNumber = 0;
        result = 0;
        lastOperator = '+';
        numberArray = string.Empty;
        displayText.text = string.Empty;
    }
}
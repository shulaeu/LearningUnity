//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
using TMPro;
using System.Globalization;
using UnityEngine.UI;
//using System;

public class CalculatorView : MonoBehaviour
{
    #region Inputs

    [SerializeField] private TMP_InputField input;

    [Header("Nums")]
    [SerializeField] private ButtonView num0;
    [SerializeField] private ButtonView num1;
    [SerializeField] private ButtonView num2;
    [SerializeField] private ButtonView num3;
    [SerializeField] private ButtonView num4;
    [SerializeField] private ButtonView num5;
    [SerializeField] private ButtonView num6;
    [SerializeField] private ButtonView num7;
    [SerializeField] private ButtonView num8;
    [SerializeField] private ButtonView num9;
    [SerializeField] private Button point;

    [Header("Operations")]
    [SerializeField] private Button plus;
    [SerializeField] private Button minus;
    [SerializeField] private Button multiply;
    [SerializeField] private Button divide;
    [SerializeField] private Button squareRoot;
    [SerializeField] private Button square;
    [SerializeField] private Button changeSign;
    [SerializeField] private Button equals;
    [SerializeField] private Button escape;

    #endregion



    [SerializeField] private string inputStr;
    [SerializeField] private float result = 0;
    [SerializeField] OperationType currentOperation;
    private float pow = 2;
           
    private void Start()
    {

        num0.AddListener(AddToInput);
        num1.AddListener(AddToInput);
        num2.AddListener(AddToInput);
        num3.AddListener(AddToInput);
        num4.AddListener(AddToInput);
        num5.AddListener(AddToInput);
        num6.AddListener(AddToInput);
        num7.AddListener(AddToInput);
        num8.AddListener(AddToInput);
        num9.AddListener(AddToInput);

        point.onClick.AddListener(AddPointToInput);
        plus.onClick.AddListener(OnPlusOperation);
        minus.onClick.AddListener(OnMinusOperation);
        multiply.onClick.AddListener(OnMultiplyOperation);
        divide.onClick.AddListener(OnDivideOperation);
        squareRoot.onClick.AddListener(OnSquareRootOperation);
        square.onClick.AddListener(OnSquareOperation);
        changeSign.onClick.AddListener(OnChangeSignOperation);
        equals.onClick.AddListener(OnEqualOperation);
        escape.onClick.AddListener(OnEscapeOperation);
    }

    private void AddToInput(string value)
    {
        inputStr += value;
        input.text = inputStr;
    }

    private void OnEqualOperation()
    {
            if (inputStr.Length == 0)
            //if (inputStr == string.empty)
            {
            return;
            }

        switch (currentOperation)
        {
            case OperationType.Plus:
                result += float.Parse(inputStr, NumberStyles.Any);
                inputStr = result.ToString();
                input.text = result.ToString();
                break;
            case OperationType.Minus:
                result -= float.Parse(inputStr, NumberStyles.Any);
                inputStr = result.ToString();
                input.text = result.ToString();
                break;
            case OperationType.Multiply:
                result *= float.Parse(inputStr, NumberStyles.Any);
                inputStr = result.ToString();
                input.text = result.ToString();
                break;
            case OperationType.Divide:
                result /= float.Parse(inputStr, NumberStyles.Any);
                inputStr = result.ToString();
                input.text = result.ToString();
                break;
            case OperationType.SquareRoot:
                result = Mathf.Sqrt(float.Parse(inputStr, NumberStyles.Any));
                inputStr = result.ToString();
                input.text = result.ToString();
                break;
            case OperationType.Square:
                result = Mathf.Pow(float.Parse(inputStr, NumberStyles.Any), pow);
                inputStr = result.ToString();
                input.text = result.ToString();
                break;
            case OperationType.ChangeSign:
                currentOperation = OperationType.ChangeSign;
                result = float.Parse(inputStr, NumberStyles.Any);
                result = -result;
                //inputStr = string.Empty;
                input.text = result.ToString();
                break;


                //result = 0;
                //result = result.ToString();
                
        }

        currentOperation = OperationType.Equal;
     }
        
        
        private void OnPlusOperation()
        {
             if (inputStr.Length > 0)
            {
                currentOperation = OperationType.Plus;
                result = float.Parse(inputStr, NumberStyles.Number);
                inputStr = string.Empty;
                //inputStr = result.ToString();
                input.text = result.ToString();
            }
        }
        
    
        private void OnMinusOperation()
        {
            if (inputStr.Length > 0)
            {
                currentOperation = OperationType.Minus;
                result = float.Parse(inputStr, NumberStyles.Number);
                inputStr = string.Empty;
                //inputStr = result.ToString();
                input.text = result.ToString();
               
            }
        }

        private void OnMultiplyOperation()
        {
            if (inputStr.Length > 0)
            {
                currentOperation = OperationType.Multiply;
                result = float.Parse(inputStr, NumberStyles.Any);
                inputStr = string.Empty;
                //inputStr = result.ToString();
                input.text = result.ToString();
            }
        }

        private void OnDivideOperation()
        {
            if (inputStr.Length > 0)
            {
                currentOperation = OperationType.Divide;
                result = float.Parse(inputStr, NumberStyles.Any);
                inputStr = string.Empty;
                //inputStr = result.ToString();
                input.text = result.ToString();
            }
        }

        private void OnSquareRootOperation()
        {
            if (inputStr.Length > 0)
            {
                currentOperation = OperationType.SquareRoot;
                result = Mathf.Sqrt(float.Parse(inputStr, NumberStyles.Any));
                //inputStr = string.Empty;
                inputStr = result.ToString();
                input.text = result.ToString();
            }
        }

        private void OnSquareOperation()
        {
            if (inputStr.Length > 0)
            {
                currentOperation = OperationType.Square;
                result = Mathf.Pow(float.Parse(inputStr, NumberStyles.Any), pow);
                //inputStr = string.Empty;
                inputStr = result.ToString();
                input.text = result.ToString();
            }
        }

        private void OnChangeSignOperation()
        {
            if (inputStr.Length > 0)
            {
                currentOperation = OperationType.ChangeSign;
                result = float.Parse(inputStr, NumberStyles.Any);
                result = -result;
                //inputStr = string.Empty;
                inputStr = result.ToString();
                input.text = result.ToString();
            }
            else
            {
                result = 0;
                //inputStr = string.Empty;
                inputStr = result.ToString();
                input.text = result.ToString();
            }
        }

        private void OnEscapeOperation()
        {
            currentOperation = OperationType.Escape;
            result = 0;
            inputStr = string.Empty;
            input.text = result.ToString();
        }
    
        private void AddPointToInput()
        {
            if (inputStr.IndexOf(',') == -1)
            {
                if (inputStr.Length > 0)
                {
                    inputStr += ",";
                }
                else {
                inputStr += "0,";
                }
                input.text = inputStr;
            }
            
        }
    
       
    //private void AddOneToInput()
    //{
    //    inputStr += "1";
    //    input.text = inputStr;
    //}

    //private void AddTwoToInput()
    //{
    //    inputStr += "2";
    //    input.text = inputStr;
    //}

    //private void AddThreeToInput()
    //{
    //    inputStr += "3";
    //    input.text = inputStr;
    //}
    //private void AddFourToInput()
    //{
    //    inputStr += "4";
    //    input.text = inputStr;
    //}
    //private void AddFiveToInput()
    //{
    //    inputStr += "5";
    //    input.text = inputStr;
    //}
    //private void AddSixToInput()
    //{
    //    inputStr += "6";
    //    input.text = inputStr;
    //}
    //private void AddSevenToInput()
    //{
    //    inputStr += "7";
    //    input.text = inputStr;
    //}
    //private void AddEightToInput()
    //{
    //    inputStr += "8";
    //    input.text = inputStr;
    //}
    //private void AddNineToInput()
    //{
    //    inputStr += "9";
    //    input.text = inputStr;
    //}
    //private void AddZeroToInput()
    //{
    //    inputStr += "0";
    //    input.text = inputStr;
    //}

    private enum OperationType
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        SquareRoot,
        Square,
        ChangeSign,
        Equal,
        Escape
    }
}
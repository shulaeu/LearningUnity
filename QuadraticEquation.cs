//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class QuadraticEquation : MonoBehaviour
{

    #region Inputs

    [SerializeField] private TMP_Text ResultText;
    [SerializeField] private TMP_InputField inputFieldA;
    [SerializeField] private TMP_InputField inputFieldB;
    [SerializeField] private TMP_InputField inputFieldC;
    [SerializeField] private TMP_Text InputTextA;
    [SerializeField] private TMP_Text InputTextB;
    [SerializeField] private TMP_Text InputTextC;

    [SerializeField] private Button buttonSolve;
    [SerializeField] private Button buttonEscape;

    #endregion


    private string result;

    private  float x1;
    private float x2;

    void Start()
    {
        buttonSolve.onClick.AddListener(OnSolveOperation);
        buttonEscape.onClick.AddListener(OnEscapeOperation);
    }

    void OnSolveOperation()
    {
        var A = float.Parse(inputFieldA.text, CultureInfo.InvariantCulture.NumberFormat);
        var B = float.Parse(inputFieldB.text, CultureInfo.InvariantCulture.NumberFormat);
        var C = float.Parse(inputFieldC.text, CultureInfo.InvariantCulture.NumberFormat);

        var D = B * B - 4f * A * C;
        if (D > 0f)
        {
            x1 = ((-B) + (Mathf.Sqrt(D))) / 2f * A;
            x2 = ((-B) - (Mathf.Sqrt(D))) / 2f * A;
            result = x1 + "; " + x2;
            ResultText.SetText(result.ToString());
        }
        else if (D == 0f)
        {
            x1 = x2 = ((-B) + (Mathf.Sqrt(D))) / 2f * A;
            result = x1 + "; " + x2;
            ResultText.SetText(result.ToString());
        }
        else if (D < 0f)
        {
            result = "There is no Roots";
            ResultText.SetText(result.ToString());
        }
    }

    void OnEscapeOperation()
    {
        result = "";
        ResultText.text = "";
        inputFieldA.text = "";
        inputFieldB.text = "";
        inputFieldC.text = "";
    }
}





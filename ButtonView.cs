using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonView : MonoBehaviour
{
    [SerializeField] private string value;

    private Action<string> onClickAction;

    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void AddListener(Action<string> action)
    {
        onClickAction += action;
    }

    private void OnClick()
    {
        onClickAction.Invoke(value);
    }
}
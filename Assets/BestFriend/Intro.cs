using System;
using TMPro;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string introMessage = $"Привет, я твой виртуальный друг. \n Давай знакомиться \n как тебя зовут:";
    [SerializeField] private TMP_Text introText;
    [SerializeField] private Vector2Int typeSpeed;
    [SerializeField] private TMP_InputField nameField;

    private void Awake() {
        nameField.gameObject.SetActive( false);
    }

    private async void Start() {
        await introText.TypeWithRandomDelay(introMessage, typeSpeed.x, typeSpeed.y);
        Debug.Log("IsOk");
        nameField.gameObject.SetActive( true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class CanvasedText : MonoBehaviour
{
    TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void UpdateText (int _value)
    {
        UpdateText(_value.ToString());
    }

    public void UpdateText(string _newText)
    {
        text.text = _newText;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTextOnEnable : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textBox;

    [TextArea]
    [SerializeField]
    string text;

    private void OnEnable()
    {
        textBox.text = text;
    }
}

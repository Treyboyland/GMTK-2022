using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarrationButton : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI buttonText;

    [SerializeField]
    TextMeshProUGUI descriptionBox;

    public bool Found { get; set; } = false;

    public NarrationSO Narration;

    public void UpdateDescription()
    {
        descriptionBox.text = Found ? Narration.NarrationText : "You have not found this fragment";
    }

    public void UpdateText()
    {
        buttonText.text = Found ? Narration.ItemName : "???";
    }
}

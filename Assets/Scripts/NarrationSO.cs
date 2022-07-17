using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Narration", menuName = "Game/Narration")]
public class NarrationSO : ItemSO
{
    [SerializeField]
    AlienTypeSO alien;

    [SerializeField]
    int order;

    public int Order { get { return order; } }

    [TextArea]
    [SerializeField]
    string narrationText;

    public string NarrationText { get { return narrationText; } }
}

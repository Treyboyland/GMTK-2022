using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Alien Name", menuName = "Game/Alien Species")]
public class AlienTypeSO : ScriptableObject
{
    [SerializeField]
    string alienName;

    public string AlienName { get { return alienName; } }
}

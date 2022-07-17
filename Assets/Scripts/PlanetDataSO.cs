using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "Space/Planet")]
public class PlanetDataSO : ScriptableObject
{
    [SerializeField]
    Vector2 sizeRange;

    [SerializeField]
    Gradient possibleColors;

    public float GetSize()
    {
        return Random.Range(sizeRange.x, sizeRange.y);
    }

    public Color GetColor()
    {
        return possibleColors.Evaluate(Random.Range(0.0f, 1.0f));
    }
}

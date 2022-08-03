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

    [SerializeField]
    Material sourceMaterial;

    [SerializeField]
    List<Sprite> surfaceSprites;

    [SerializeField]
    Vector2 speedRange;

    [SerializeField]
    List<RuntimeAnimatorController> spinCycles;

    public float GetSize()
    {
        return RandomNum(sizeRange);
    }

    public Color GetColor()
    {
        return possibleColors.Evaluate(Random.Range(0.0f, 1.0f));
    }

    public Sprite GetSprite()
    {
        int index = UnityEngine.Random.Range(0, surfaceSprites.Count);
        return surfaceSprites[index];
    }

    float RandomNum(Vector2 range)
    {
        return Random.Range(range.x, range.y);
    }

    public float GetSpeed()
    {
        return RandomNum(speedRange);
    }

    public RuntimeAnimatorController GetAnimation()
    {
        int index = UnityEngine.Random.Range(0, spinCycles.Count);
        return spinCycles[index];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSurface : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    List<SpriteRenderer> surfaces;

    public void SetData(PlanetDataSO dataSO)
    {
        var newSprite = dataSO.GetSprite();
        var color = dataSO.GetColor();

        foreach (var surface in surfaces)
        {
            surface.sprite = newSprite;
            surface.color = color;
        }

        animator.runtimeAnimatorController = dataSO.GetAnimation();
        animator.speed = dataSO.GetSpeed();
    }

    public void SetOrder(int order)
    {
        foreach (var surface in surfaces)
        {
            surface.sortingOrder = order;
        }
    }
}

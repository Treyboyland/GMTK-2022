using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnCollision : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    private void OnEnable()
    {
        transform.localPosition = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        target.SetActive(false);
    }
}

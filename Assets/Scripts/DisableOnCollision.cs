using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnCollision : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    [SerializeField]
    List<SpriteRenderer> renderers;

    float creationTime;


    private void OnEnable()
    {
        transform.localPosition = Vector2.zero;
        creationTime = Time.realtimeSinceStartup;
        StartCoroutine(WaitThenEnable());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var otherDis = other.gameObject.GetComponent<DisableOnCollision>();
        if (otherDis == null)
        {
            DeactivateTarget();
            return;
        }

        if (creationTime < otherDis.creationTime)
        {
            otherDis.DeactivateTarget();
        }
        else
        {
            DeactivateTarget();
        }
    }

    void DeactivateTarget()
    {
        target.SetActive(false);
    }

    IEnumerator WaitThenEnable()
    {
        foreach (var renderer in renderers)
        {
            renderer.enabled = false;
        }

        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();

        foreach (var render in renderers)
        {
            render.enabled = true;
        }
    }
}

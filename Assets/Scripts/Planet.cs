using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    PlanetDataSO planetData;

    [SerializeField]
    CircleCollider2D planetRadius;

    [SerializeField]
    SpriteRenderer planetSprite;

    [SerializeField]
    string ignoreLayer;

    [SerializeField]
    string usedLayer;

    public float Radius
    {
        get
        {
            return Mathf.Max(transform.localScale.x, transform.localScale.y) * planetRadius.radius;
        }
    }


    private void OnEnable()
    {
        RandomizeSettings();
        gameObject.layer = LayerMask.NameToLayer(usedLayer);
    }

    void RandomizeSettings()
    {
        float scale = planetData.GetSize();
        transform.localScale = new Vector3(scale, scale, scale);
        planetSprite.color = planetData.GetColor();
    }

    public void EnableLayer()
    {
        StartCoroutine(WaitThenEnable());
    }

    public void DisableLayer()
    {
        StopAllCoroutines();
        gameObject.layer = LayerMask.NameToLayer(ignoreLayer);
    }

    IEnumerator WaitThenEnable()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        gameObject.layer = LayerMask.NameToLayer(usedLayer);
    }
}

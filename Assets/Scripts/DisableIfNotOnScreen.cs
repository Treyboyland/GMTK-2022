using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfNotOnScreen : MonoBehaviour
{
    [SerializeField]
    Renderer objectRender;

    [SerializeField]
    float secondsToWait;

    float elapsed = 0;


    private void OnEnable()
    {
        elapsed = 0;
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        while (true)
        {
            elapsed += Time.deltaTime;
            if (objectRender.isVisible)
            {
                elapsed = 0;
            }
            if (elapsed >= secondsToWait)
            {
                gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}

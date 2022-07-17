using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterPlaying : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    public AudioSource Source { get { return source; } }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }


    IEnumerator WaitThenDisable()
    {
        source.Play();
        while (source.isPlaying)
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }
}

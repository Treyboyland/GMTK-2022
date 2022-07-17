using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip clip;

    [SerializeField]
    float volume;

    [SerializeField]
    DisableAfterPlaying prefab;

    List<DisableAfterPlaying> pool = new List<DisableAfterPlaying>();

    // Start is called before the first frame update
    void Start()
    {

    }

    DisableAfterPlaying CreateObject()
    {
        DisableAfterPlaying temp = Instantiate(prefab);
        temp.gameObject.SetActive(false);
        pool.Add(temp);
        return temp;
    }

    DisableAfterPlaying GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateObject();
    }

    public void PlayAudio()
    {
        var sound = GetObject();
        sound.Source.clip = clip;
        sound.Source.volume = volume;

        sound.gameObject.SetActive(true);
    }
}

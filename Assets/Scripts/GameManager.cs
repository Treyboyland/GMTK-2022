using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    public static GameManager Manager { get { return _instance; } }

    public UnityEvent OnPlayerLaunch;

    public UnityEvent OnPlayerOrbit;

    private void Awake()
    {
        _instance = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    public Camera Camera { get { return mainCamera; } }

    static GameCamera _instance;

    public static GameCamera Instance { get { return _instance; } }
}

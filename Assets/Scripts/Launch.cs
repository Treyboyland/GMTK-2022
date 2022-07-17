using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    [SerializeField]
    Orbit orbit;

    [SerializeField]
    PlayerShip ship;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Launch"))
        {
            LaunchShip();
        }
        //Debug.DrawRay(transform.position, GetLaunchVector(), Color.white);
    }

    public Vector3 GetLaunchVector()
    {
        var distanceNormal = transform.position - orbit.Target.transform.position;
        return (orbit.CounterClockwise ? -1 : 1) * Vector3.Cross(distanceNormal.normalized, Vector3.forward);
    }

    public void LaunchShip()
    {
        if (orbit.Target == null || ship == null)
        {
            return;
        }

        ship.StartLaunch(GetLaunchVector());
    }
}

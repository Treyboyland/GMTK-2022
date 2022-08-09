using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField]
    Transform target;

    public Transform Target { get { return target; } set { target = value; } }

    [SerializeField]
    float orbitalRadius;

    public float OrbitalRadius { get { return orbitalRadius; } set { orbitalRadius = value; } }

    public Planet CurrentPlanet;

    public Planet PreviousPlanet;

    [SerializeField]
    float orbitalPeriod;

    float elapsed = 0;

    [SerializeField]
    bool beginOrbit;

    [SerializeField]
    int numCalculations;

    /// <summary>
    /// True if we should start orbiting
    /// </summary>
    /// <value></value>
    public bool BeginOrbit { get { return beginOrbit; } set { beginOrbit = value; } }

    [SerializeField]
    bool counterClockwise;

    public bool CounterClockwise { get { return counterClockwise; } set { counterClockwise = value; } }

    float timeOutOfOrbit = 0;

    public float TimeOutOfOrbit { get { return timeOutOfOrbit; } }

    public bool IsOrbiting { get { return target != null; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Reverse Orbit"))
        {
            ToggleOrbitRotation();
        }
        DoOrbit();
        CheckTimeOutOfOrbit();
    }

    void ToggleOrbitRotation()
    {
        counterClockwise = !counterClockwise;
    }

    void CheckTimeOutOfOrbit()
    {
        if (target == null)
        {
            timeOutOfOrbit += Time.deltaTime;
        }
        else
        {
            timeOutOfOrbit = 0;
        }
    }

    void DoOrbit()
    {
        if (target == null)
        {
            return;
        }

        if (counterClockwise)
        {
            elapsed = (elapsed + Time.deltaTime) % orbitalPeriod;
        }
        else
        {
            elapsed -= Time.deltaTime;
            if (elapsed < 0)
            {
                elapsed = orbitalPeriod + elapsed;
            }
        }


        transform.position = GetOrbitPoint(elapsed);
    }

    Vector3 GetOrbitPoint(float time)
    {
        float progress = Mathf.Lerp(0, 1, time / orbitalPeriod);
        float inside = 2 * Mathf.PI * progress;
        float x = Mathf.Cos(inside);
        float y = Mathf.Sin(inside);

        return target.transform.position + orbitalRadius * new Vector3(x, y, 0);
    }

    public void SetTimeClosestToPosition(Vector3 position)
    {
        float progressDelta = orbitalPeriod / numCalculations;
        float minProgress = 0;
        float minDistance = float.MaxValue;
        Vector3 minPoint = Vector3.zero;
        for (float i = 0; i < orbitalPeriod; i += progressDelta)
        {
            var point = GetOrbitPoint(i);
            float distance = Vector3.SqrMagnitude(point - position);
            if (distance < minDistance)
            {
                minPoint = point;
                minDistance = distance;
                minProgress = i;
            }
        }

        elapsed = minProgress;
    }
}

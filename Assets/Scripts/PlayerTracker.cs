using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField]
    float progressStep;

    [SerializeField]
    float secondsToCatchup;

    [SerializeField]
    PlayerShip ship;

    [SerializeField]
    Orbit playerOrbit;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TrackingLogic());
    }

    IEnumerator TrackToPlayer()
    {
        Vector3 start = transform.position;
        float elapsed = 0;
        while (elapsed < secondsToCatchup)
        {
            if (playerOrbit.IsOrbiting)
            {
                yield break;
            }
            elapsed += Time.deltaTime;
            var newPos = Vector3.Lerp(start, playerOrbit.transform.position, elapsed / secondsToCatchup);
            newPos.z = transform.position.z;
            transform.position = newPos;
            yield return null;
        }

        var finalPos = playerOrbit.transform.position;
        finalPos.z = transform.position.z;

        transform.position = finalPos;
    }

    IEnumerator TrackingLogic()
    {
        while (true)
        {
            yield return null;
            if (!playerOrbit.IsOrbiting)
            {
                yield return StartCoroutine(TrackToPlayer());
                while (!playerOrbit.IsOrbiting)
                {
                    var newPos = Vector3.Lerp(transform.position, playerOrbit.transform.position, progressStep);
                    newPos.z = transform.position.z;
                    transform.position = newPos;
                    yield return null;
                }

            }
        }
    }
}

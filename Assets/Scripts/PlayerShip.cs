using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField]
    float speed;

    public float Speed { get { return speed; } }

    [SerializeField]
    Orbit orbit;

    [SerializeField]
    Rigidbody2D body;

    int orbitCount = 0;

    public int OrbitCount { get { return orbitCount; } }

    public bool CanLaunch { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CalculateOrbitRotation(Vector3 point)
    {
        bool xGreater = body.velocity.x > body.velocity.y;

        if (xGreater)
        {
            bool counterClockwise = transform.position.y < point.y;

            if (body.velocity.x < 0)
            {
                counterClockwise = !counterClockwise;
            }

            orbit.CounterClockwise = counterClockwise;
        }
        else
        {
            bool counterClockwise = transform.position.x > point.x;

            if (body.velocity.y < 0)
            {
                counterClockwise = !counterClockwise;
            }

            orbit.CounterClockwise = counterClockwise;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        var planet = other.gameObject.GetComponent<Planet>();
        if (planet != null)
        {
            orbitCount++;
            GameManager.Manager.OnPlayerOrbit.Invoke();
            orbit.PreviousPlanet = orbit.CurrentPlanet;
            orbit.CurrentPlanet = planet;
            orbit.CurrentPlanet.DisableLayer();
            orbit.Target = planet.transform;
            CalculateOrbitRotation(planet.transform.position);
            orbit.SetTimeClosestToPosition(other.GetContact(0).point);
            orbit.OrbitalRadius = planet.Radius;
            orbit.BeginOrbit = true;
            body.velocity = Vector2.zero;
            body.simulated = false;
        }
    }

    public void StartLaunch(Vector2 launchVector)
    {
        if (!CanLaunch)
        {
            return;
        }

        GameManager.Manager.OnPlayerLaunch.Invoke();
        orbit.CurrentPlanet?.DisableLayer();
        orbit.CurrentPlanet?.EnableLayer();
        orbit.BeginOrbit = false;
        orbit.Target = null;
        body.simulated = true;
        body.velocity = launchVector * speed;
    }
}

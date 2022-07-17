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

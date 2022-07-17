using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField]
    Orbit playerOrbit;

    [SerializeField]
    Rigidbody2D playerBody;

    [SerializeField]
    Planet planetPrefab;

    [SerializeField]
    float timeToWaitBeforeSpawiningInPath;

    [SerializeField]
    int minNumPlanets;

    List<Planet> pool = new List<Planet>();

    float elapsed;

    enum Direction { North = 0, South, East, West }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        SpawnPlanet();
        ClutchSpawn();
    }

    Planet CreatePlanet()
    {
        var planet = Instantiate(planetPrefab) as Planet;
        planet.gameObject.SetActive(false);
        pool.Add(planet);
        return planet;
    }

    Planet GetPlanet()
    {
        foreach (var planet in pool)
        {
            if (!planet.gameObject.activeInHierarchy)
            {
                return planet;
            }
        }

        return CreatePlanet();
    }

    float RandomSign()
    {
        return Random.Range(0.0f, 1.0f) < .5f ? 1 : -1;
    }

    Vector2 GetPointOffScreen(Direction dir)
    {


        float x, y;

        switch (dir)
        {
            case Direction.West:
                x = -1 * Random.Range(13.0f, 20.0f);
                y = Random.Range(-10.0f, 10.0f);
                break;
            case Direction.East:
                x = Random.Range(13.0f, 20.0f);
                y = Random.Range(-10.0f, 10.0f);
                break;
            case Direction.South:
                x = Random.Range(-10.0f, 10.0f);
                y = -1 * Random.Range(7.0f, 17.0f);
                break;
            case Direction.North:
            default:
                x = Random.Range(-10.0f, 10.0f);
                y = Random.Range(7.0f, 17.0f);
                break;
        }
        return new Vector2(x, y);
    }

    Direction GetRandomDirection(Vector2 velocity)
    {
        List<Direction> directions = new List<Direction>();
        directions.Add(velocity.x < 0 ? Direction.West : Direction.East);
        directions.Add(velocity.y < 0 ? Direction.South : Direction.North);

        int index = Random.Range(0, directions.Count);
        return directions[index];
    }


    void SpawnPlanet()
    {
        int numActive = pool.Where(x => x.gameObject.activeInHierarchy).Count();
        if (numActive < minNumPlanets)
        {
            int diff = Mathf.Abs(numActive - minNumPlanets);
            for (int i = 0; i < diff; i++)
            {
                var startPos = playerOrbit.transform.position;
                var velocity = playerBody.velocity;
                Vector3 newPos;
                if (velocity != Vector2.zero)
                {
                    newPos = GetPointOffScreen(GetRandomDirection(velocity));
                }
                else
                {
                    int direction = Random.Range(0, 4);
                    Direction dir = (Direction)direction;

                    newPos = GetPointOffScreen(dir);
                }

                startPos += newPos;

                var planet = GetPlanet();
                planet.transform.position = startPos;
                planet.gameObject.SetActive(true);
            }
        }
    }

    void ClutchSpawn()
    {
        if (playerOrbit.Target == null)
        {
            elapsed += Time.deltaTime;
        }
        else
        {
            elapsed = 0;
        }

        if (elapsed >= timeToWaitBeforeSpawiningInPath)
        {
            elapsed = 0;
            //Debug.LogWarning("Clutch Spawn");
            var startPos = playerOrbit.transform.position;
            var velocity = playerBody.velocity;
            var x = velocity.x * 3;
            var y = velocity.y * 3;

            startPos += new Vector3(x, y);

            var planet = GetPlanet();
            planet.transform.position = startPos;
            planet.gameObject.SetActive(true);
        }
    }
}

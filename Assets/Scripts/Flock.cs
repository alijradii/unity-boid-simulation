using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent flockAgentPrefab;

    public List<FlockBehavior> behaviors = new List<FlockBehavior>();
    List<FlockAgent> flockAgents = new List<FlockAgent>();

    public Vector2 minRange = new Vector2(-10, -6);
    public Vector2 maxRange = new Vector2(10, 6);


    [Range(10, 500)]
    public int startingPopulationSize = 10;

    [Range(1f, 100f)]
    public float maxForce = 0.8f;

    [Range(1f, 100f)]
    public float minSpeed = 0.4f;

    [Range(1f, 100f)]
    public float maxSpeed = 0.4f;

    [Range(1f, 10f)]
    public float visionRadius = 1.5f;

    [Range(0f, 1f)]
    public float avoidanceRadius = 0.5f;

    void Start()
    {
        for (int i = 0; i < startingPopulationSize; i++)
        {
            FlockAgent agent = Instantiate(
                flockAgentPrefab,
                new Vector3(Random.Range(minRange.x, maxRange.x),
                Random.Range(minRange.y, maxRange.y),
                0),
                Quaternion.Euler(0, 0, 0),
                transform
            );

            agent.Initialize(this);
            agent.name = "Agent " + i;
        }

        behaviors.Add(new CohesionBehavior(0.2f));
        behaviors.Add(new AlignmentBehavior(0.4f));
        behaviors.Add(new SeparationBehavior(0.6f));
    }

    void Update()
    {
        foreach (FlockAgent agent in flockAgents)
        {
            Vector2 move = Vector2.zero;
        }
    }
}

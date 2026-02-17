using System.Collections.Generic;
using UnityEngine;

public class CohesionBehavior : FlockBehavior
{
    public CohesionBehavior(float weight) : base(weight)
    {
    }
    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    {
        Vector2 move = Vector2.zero;
        Vector2 center = Vector2.zero;

        int count = 0;

        foreach (Transform item in context)
        {
            FlockAgent otherAgent = item.GetComponent<FlockAgent>();

            if (otherAgent == null || otherAgent == flockAgent) continue;

            center += (Vector2)otherAgent.transform.position;
            count++;
        }

        if (count == 0) return Vector2.zero;

        center /= count;

        Vector2 desired = center - (Vector2)flockAgent.transform.position;
        desired = desired.normalized * flock.maxSpeed;

        Vector2 steering = desired - (Vector2)flockAgent.rb.linearVelocity;
        return steering;
    }
}

using UnityEngine;
using System.Collections.Generic;

public class SeparationBehavior : FlockBehavior
{
    public SeparationBehavior(float weight) : base(weight)
    {
    }
    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    {
        Vector2 move = Vector2.zero;

        int count = 0;
        foreach (Transform item in context)
        {
            FlockAgent otherAgent = item.GetComponent<FlockAgent>();

            if (otherAgent == null || otherAgent == flockAgent) continue;

            float distance = Mathf.Max(
             Vector2.Distance(otherAgent.transform.position, flockAgent.transform.position),
             0.0001f
            );

            if (distance > flock.avoidanceRadius) continue;

            Vector2 diff = (Vector2)flockAgent.transform.position - (Vector2)otherAgent.transform.position;
            move += diff / distance;

            count++;
        }

        if (count == 0) return Vector2.zero;

        Vector2 desired = move.normalized * flock.maxSpeed;
        Vector2 steering = desired - flockAgent.rb.linearVelocity;

        return steering;
    }
}

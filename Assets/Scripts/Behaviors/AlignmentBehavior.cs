using System.Collections.Generic;
using UnityEngine;

public class AlignmentBehavior : FlockBehavior
{
    public AlignmentBehavior(float weight) : base(weight)
    { }
    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    {
        Vector2 averageVelocity = Vector2.zero;
        int count = 0;

        foreach (Transform item in context)
        {
            FlockAgent otherAgent = item.GetComponent<FlockAgent>();

            if (otherAgent == null || otherAgent == flockAgent) continue;

            count++;
            averageVelocity += otherAgent.rb.linearVelocity;
        }

        if (count == 0) return Vector2.zero;

        averageVelocity /= count;

        Vector2 desired = averageVelocity.normalized * flock.maxSpeed;
        Vector2 steering = desired - flockAgent.rb.linearVelocity;

        return steering;
    }
}

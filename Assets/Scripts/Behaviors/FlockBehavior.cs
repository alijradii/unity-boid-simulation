using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehavior
{
    public float Weight { get; private set; }

    protected FlockBehavior(float weight)
    {
        Weight = weight;
    }

    public abstract Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock);
}

using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehavior
{
    public abstract Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock);
}

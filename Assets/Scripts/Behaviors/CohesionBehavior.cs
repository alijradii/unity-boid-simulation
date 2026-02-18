using System.Collections.Generic;
using UnityEngine;

public class CohesionBehavior : FlockBehavior
{
    public CohesionBehavior(float weight) : base(weight)
    {
    }
    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    {
        return Vector2.zero;
    }
}

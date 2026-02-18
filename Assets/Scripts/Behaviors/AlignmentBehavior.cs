using System.Collections.Generic;
using UnityEngine;

public class AlignmentBehavior : FlockBehavior
{
    public AlignmentBehavior(float weight) : base(weight)
    { }
    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    {
        return Vector2.zero;
    }
}

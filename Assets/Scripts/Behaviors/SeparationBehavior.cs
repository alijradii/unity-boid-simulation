using UnityEngine;
using System.Collections.Generic;

public class SeparationBehavior: FlockBehavior
{
    public SeparationBehavior(float weight) : base(weight) {
    }
    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock) {
        return Vector2.zero;
    }
}

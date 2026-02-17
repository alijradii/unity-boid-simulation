using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody2D))]
public class FlockAgent : MonoBehaviour
{
    Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }
    public Rigidbody2D rb;
    Flock flock;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        agentCollider = GetComponent<Collider2D>();
    }

    public void Initialize(Flock flock)
    {
        this.flock = flock;
    }

    void Start()
    {

        var linearVelocity = Random.insideUnitCircle.normalized * 10f;

        rb.linearVelocity = linearVelocity;
        transform.up = linearVelocity.normalized;
    }

    void FixedUpdate()
    {
        List<Transform> context = GetNearbyObjects(flock.visionRadius);
        Vector2 steering = Vector2.zero;

        foreach (FlockBehavior behavior in flock.behaviors)
        {
            Vector2 move = behavior.CalculateMove(this, context, flock);
            steering += move * behavior.Weight;
        }

        steering = Vector2.ClampMagnitude(steering, flock.maxForce);

        Vector2 acceleration = steering;
        rb.linearVelocity += acceleration * Time.fixedDeltaTime;
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, flock.maxSpeed);

        if (rb.linearVelocity.magnitude < flock.minSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * flock.minSpeed;
        }

        transform.up = rb.linearVelocity;

        CheckBounds();
    }

    void CheckBounds()
    {
        Vector3 pos = transform.position;

        pos.x = Wrap(pos.x, flock.minRange.x, flock.maxRange.x);
        pos.y = Wrap(pos.y, flock.minRange.y, flock.maxRange.y);

        transform.position = pos;
    }

    float Wrap(float cur, float min, float max)
    {
        if (cur < min) return max;
        if (cur > max) return min;

        return cur;
    }

    public List<Transform> GetNearbyObjects(float radius)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D c in contextColliders)
        {
            if (c != agentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}

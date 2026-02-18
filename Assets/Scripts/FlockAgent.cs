using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlockAgent : MonoBehaviour
{
    Collider2D agentCollider;
    public Collider2D AgentCollider {get {return agentCollider;}}
    Flock flock;

    Rigidbody2D rb;
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        agentCollider = GetComponent<Collider2D>();
    }

    public void Initialize(Flock flock) {
        this.flock = flock;
    }

    void Start()
    {

        var linearVelocity = Random.insideUnitCircle.normalized * 10f;

        rb.linearVelocity = linearVelocity;
        transform.up = linearVelocity.normalized;
    }

    void Update()
    {
        CheckBounds();
    }

    void CheckBounds() {
        Vector3 pos = transform.position;

        pos.x = Wrap(pos.x, flock.minRange.x, flock.maxRange.x);
        pos.y = Wrap(pos.y, flock.minRange.y, flock.maxRange.y);

        transform.position = pos;
    }

    float Wrap(float cur, float min, float max) {
        if(cur < min) return max;
        if(cur > max) return min;

        return cur;
    }
}

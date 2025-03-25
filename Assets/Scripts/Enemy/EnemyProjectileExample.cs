using UnityEngine;

public class EnemyProjectileExample : EnemyProjectileBase
{
    [SerializeField] float speed;

    public override void MoveBehaviour()
    {
        rb.linearVelocity = speed * transform.right;
    }
}

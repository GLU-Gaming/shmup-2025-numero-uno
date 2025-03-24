using UnityEngine;

public class EnemyProjectileExample : EnemyProjectileBase
{
    [SerializeField] float speed;

    public override void MoveBehaviour()
    {
        rb.linearVelocity = new Vector3(-speed, 0, 0);
    }
}

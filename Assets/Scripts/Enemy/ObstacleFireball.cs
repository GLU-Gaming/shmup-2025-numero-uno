using UnityEngine;

public class ObstacleFireball : EnemyBehaviourBase
{
    [SerializeField] float acceleration;
    [SerializeField] float initialSpeed;
    [SerializeField] float horizontalSpeed;

    private float speed;

    public new void Start() // put permanent overrides here
    {
        base.Start();
    }

    void OnEnable() // put things that are normally in Start here
    {
        speed = initialSpeed;
    }

    public override void MoveBehaviour() // set movement code here
    {
        rb.linearVelocity = new Vector3(horizontalSpeed, speed, 0f);

        speed -= acceleration * Time.deltaTime;
    }
}
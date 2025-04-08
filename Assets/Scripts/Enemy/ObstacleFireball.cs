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

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg + 270);

        speed -= acceleration * Time.deltaTime;
    }
}
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpike : EnemyBehaviourBase
{
    [SerializeField] private GameObject bulletManagerHolder;

    private BatchManager bulletManager;

    [SerializeField] private float speed;

    [SerializeField] private Vector3 startDirection;
    [SerializeField] private Vector3 endDirection;

    [SerializeField] private float timeTurnStart;
    [SerializeField] private float timeTurnDuration;

    [SerializeField] private uint projectiles;

    private float movementTimer = 0;

    public new void Start() // put permanent overrides here
    {
        base.Start();

        shoots = true;
        bulletManager = bulletManagerHolder.GetComponent<BatchManager>();
    }

    void OnEnable() // put things that are normally in Start here
    {
        movementTimer = 0;
    }

    public override void MoveBehaviour() // set movement code here
    {
        movementTimer += Time.deltaTime;
        Vector3 velocity = speed * Vector3.Lerp(startDirection, endDirection, (movementTimer - timeTurnStart) / timeTurnDuration).normalized;

        rb.linearVelocity = velocity;
    }

    public override void OnDeath()
    {
        for (int i = 0; i < projectiles; i++)
        {
            float rot = i * 360f / projectiles;
            bulletManager.Activate(transform.position, Quaternion.Euler(0, 0, rot));
        }
    }
}

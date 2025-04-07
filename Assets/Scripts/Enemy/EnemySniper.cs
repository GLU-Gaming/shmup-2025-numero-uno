using UnityEngine;

public class EnemySniper : EnemyBehaviourBase
{
    [SerializeField] private GameObject bulletManager1Holder;
    [SerializeField] private float shootCooldown1;

    [SerializeField] private GameObject bulletManager2Holder;
    [SerializeField] private float shootCooldown2;
    [SerializeField] private float offset;

    private BatchManager bulletManager1;
    private BatchManager bulletManager2;

    [SerializeField] private float hSpeed;
    [SerializeField] private float vSpeed;

    private float shootTimer1 = 0;
    private float shootTimer2 = 0;

    [SerializeField] Transform target;

    [SerializeField] float moveInTime;
    [SerializeField] float stayTime;
    [SerializeField] float moveOutTime;

    private float moveTimer;

    public new void Start() // put permanent overrides here
    {
        base.Start();

        shoots = true;
        bulletManager1 = bulletManager1Holder.GetComponent<BatchManager>();
        bulletManager2 = bulletManager2Holder.GetComponent<BatchManager>();
    }

    void OnEnable() // put things that are normally in Start here
    {
        shootTimer1 = 0;
        shootTimer2 = 0;
        moveTimer = 0;
    }

    public override void ShootBehaviour() // set shooting code here
    {
        shootTimer1 += Time.deltaTime;
        shootTimer2 += Time.deltaTime;

        while (shootTimer1 > shootCooldown1)
        {
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            bulletManager1.Activate(transform.position, Quaternion.Euler(0, 0, angle));

            shootTimer1 -= shootCooldown1;
        }

        while (shootTimer2 > shootCooldown2)
        {
            bulletManager2.Activate(transform.position + new Vector3(0, offset, 0), Quaternion.Euler(0, 0, 0));
            bulletManager2.Activate(transform.position + new Vector3(0, -offset, 0), Quaternion.Euler(0, 0, 0));

            shootTimer2 -= shootCooldown2;
        }
    }

    public override void MoveBehaviour() // set movement code here
    {
        moveTimer += Time.deltaTime;

        Vector3 movement = Vector3.Lerp(new Vector3(-hSpeed, 0, 0), Vector3.Lerp(Vector3.zero, new Vector3(0, vSpeed, 0), (moveTimer - stayTime - moveInTime)/moveOutTime), moveTimer/moveInTime);

        rb.linearVelocity = movement;
    }
}
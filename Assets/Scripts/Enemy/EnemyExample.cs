using Unity.VisualScripting;
using UnityEngine;

public class EnemyExample : EnemyBehaviourBase
{
    [SerializeField] private GameObject bulletManagerHolder;
    [SerializeField] private float shootCooldown;

    private BatchManager bulletManager;
    private float shootTimer = 0;

    public new void Start() // put permanent overrides here
    {
        base.Start();

        shoots = true;
        bulletManager = bulletManagerHolder.GetComponent<BatchManager>();
    }
    
    void OnEnable() // put things that are normally in Start here
    {
        
    }

    public override void ShootBehaviour() // set shooting code here
    {
        shootTimer += Time.deltaTime;

        while (shootTimer > shootCooldown)
        {
            bulletManager.Activate(transform.position, transform.rotation);
            shootTimer -= shootCooldown;
        }
    }

    public override void MoveBehaviour() // set movement code here
    {
        rb.linearVelocity = new Vector3(-1f, 0f, 0f);
    }
}

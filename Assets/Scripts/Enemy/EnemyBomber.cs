using UnityEngine;

public class EnemyBomber : EnemyBehaviourBase
{
    [SerializeField] private GameObject bulletManagerHolder;
    [SerializeField] private float shootCooldown;
    
    [SerializeField] private GameObject bombManagerHolder;
    [SerializeField] private float bombCooldown;

    private BatchManager bulletManager;
    private BatchManager bombManager;

    [SerializeField] private float speed;

    private float shootTimer = 0;
    private float bombTimer = 0;

    public new void Start() // put permanent overrides here
    {
        base.Start();

        shoots = true;
        bulletManager = bulletManagerHolder.GetComponent<BatchManager>();
        bombManager = bombManagerHolder.GetComponent<BatchManager>();
    }

    void OnEnable() // put things that are normally in Start here
    {

    }

    public override void ShootBehaviour() // set shooting code here
    {
        shootTimer += Time.deltaTime;
        bombTimer += Time.deltaTime;

        while (shootTimer > shootCooldown)
        {
            
            shootTimer -= shootCooldown;
        }

        while (bombTimer > bombCooldown)
        {

            bombTimer -= bombCooldown;
        }
    }

    public override void MoveBehaviour() // set movement code here
    {
        rb.linearVelocity = new Vector3(-speed, 0, 0);
    }
}

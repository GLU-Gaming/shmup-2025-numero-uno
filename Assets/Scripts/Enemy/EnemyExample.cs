using Unity.VisualScripting;
using UnityEngine;

public class EnemyExample : EnemyBehaviourBase
{
    [SerializeField] private GameObject bulletManagerHolder;

    private BatchManager bulletManager;

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
        bulletManager.Activate(transform.position, transform.rotation);
    }

    public override void MoveBehaviour() // set movement code here
    {
        rb.linearVelocity = new Vector3(-1f, 0f, 0f);
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class EnemyExample : EnemyBehaviourBase
{
    public new void Start() // put permanent overrides here
    {
        base.Start();

        shoots = true;
    }
    
    void Spawn() // put things that are normally in Start here
    {
        
    }

    public override void ShootBehaviour() // set shooting code here
    {
        //Debug.Log("pew");
    }

    public override void MoveBehaviour() // set movement code here
    {
        rb.linearVelocity = new Vector3(-1f, 0f, 0f);
    }
}

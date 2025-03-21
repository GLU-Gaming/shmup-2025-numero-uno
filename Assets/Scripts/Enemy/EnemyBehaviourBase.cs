using UnityEngine;

public class EnemyBehaviourBase : MonoBehaviour
{
    protected bool shoots = false;

    public Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        MoveBehaviour();
        if (shoots)
        {
            ShootBehaviour();
        }
    }

    public virtual void ShootBehaviour()
    {

    }

    public virtual void MoveBehaviour()
    {

    }
}

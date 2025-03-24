using UnityEngine;

public class EnemyProjectileBase : MonoBehaviour
{
    public Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveBehaviour();
    }

    public virtual void MoveBehaviour()
    {

    }
}

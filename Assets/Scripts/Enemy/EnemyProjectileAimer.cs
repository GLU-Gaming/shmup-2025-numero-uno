using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectileAimer : EnemyProjectileBase
{
    [SerializeField] float normalSpeed;
    [SerializeField] float startSpeed;
    [SerializeField] float slowSpeed;

    [SerializeField] float timeUntilTurn;

    [SerializeField] Transform target;

    private float timer;

    private bool turned;

    new void Start()
    {
        base.Start();
    }

    void OnEnable() // put things that are normally in Start here
    {
        timer = timeUntilTurn;
        turned = false;
    }

    public override void MoveBehaviour()
    {
        float speed = 0;

        if (turned)
        {
            speed = normalSpeed;
        } else
        {
            timer -= Time.deltaTime;

            speed = Mathf.Lerp(slowSpeed, startSpeed, timer / timeUntilTurn);

            if (timer < 0)
            {
                Vector3 direction = target.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);

                turned = true;
            }
        }

        rb.linearVelocity = speed * transform.right;
    }
}

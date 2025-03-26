using UnityEngine;

public class EnemyProjectileBomb : EnemyProjectileBase
{
    [SerializeField] float speed;
    [SerializeField] float timeTillBoom;

    [SerializeField] uint fragments;
    [SerializeField] GameObject fragmentManagerHolder;

    private BatchManager fragmentManager;

    private float boomTimer = 0;

    void Start()
    {
        fragmentManager = fragmentManagerHolder.GetComponent<BatchManager>();
    }

    void OnEnable() // put things that are normally in Start here
    {
        boomTimer = timeTillBoom;
    }

    public override void MoveBehaviour()
    {
        rb.linearVelocity = speed * transform.right;

        boomTimer -= Time.deltaTime;

        if (boomTimer < 0)
        {
            Boom();
        }
    }

    private void Boom()
    {
        for (int i = 0; i < fragments; i++)
        {
            float minRot = i * 360 / fragments;
            float maxRot = (i + 1) * 360 / fragments;

            fragmentManager.Activate(transform.position, Quaternion.Euler(0, 0, Random.Range(minRot, maxRot)));
        }

        GetComponent<BatchChild>().Deactivate();
    }
}

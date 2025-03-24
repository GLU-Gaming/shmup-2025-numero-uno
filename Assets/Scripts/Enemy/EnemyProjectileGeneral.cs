using UnityEngine;

public class EnemyProjectileGeneral : MonoBehaviour
{
    [SerializeField] private float projectileLifetime;
    private float timer = 0;

    private void OnEnable()
    {
        timer = 0;
    }

    private void FixedUpdate()
    {
        if (timer > projectileLifetime)
        {
            GetComponent<BatchChild>().Deactivate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerManager>().OnHit();
            GetComponent<BatchChild>().Deactivate();
        }
    }

    private void OnBecameInvisible()
    {
        GetComponent<BatchChild>().Deactivate();
    }
}

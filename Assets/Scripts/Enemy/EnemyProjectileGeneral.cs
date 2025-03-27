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
        timer += Time.deltaTime;
        if (timer > projectileLifetime)
        {
            GetComponent<BatchChild>().Deactivate();
        }

        if (transform.position.x > 15.5 || transform.position.x < -15.5 || transform.position.y > 8.75 || transform.position.y < -8.75)
        {
            GetComponent<BatchChild>().Deactivate();
        }
    }
}

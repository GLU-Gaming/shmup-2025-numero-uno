using UnityEngine;

public class Lazer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyGeneral>().Death();

            GetComponent<BatchChild>().Deactivate();
        } else if (other.gameObject.CompareTag("EnemyBoss"))
        {
            other.gameObject.GetComponent<BossGeneral>().OnHit();

            GetComponent<BatchChild>().Deactivate();
        }
    }
}

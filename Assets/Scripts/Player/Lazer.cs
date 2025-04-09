using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Update()
    {
        transform.position = player.transform.position + new Vector3(17.75f, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyGeneral>().Death();
        } 
        
        if (other.gameObject.CompareTag("EnemyBoss"))
        {
            other.gameObject.GetComponent<BossGeneral>().OnHit();
        }
    }
}

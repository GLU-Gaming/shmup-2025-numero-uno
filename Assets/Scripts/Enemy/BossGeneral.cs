using UnityEngine;

public class BossGeneral : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health = 0;

    public bool invincible = false;

    public void OnHit()
    {
        if (!invincible)
        {
            health--;
            if (health <= 0) Death();
        }
    }

    public void Death()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<EnemyGeneral>().Death();
        }

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyProjectile"))
        {
            enemy.GetComponent<BatchChild>().Deactivate();
        }

        gameObject.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class BossGeneral : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    public int health = 0;

    public bool invincible = false;

    private void OnEnable()
    {
        health = maxHealth;
    }

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

        SceneManager.LoadScene("WinScreen");
    }
}

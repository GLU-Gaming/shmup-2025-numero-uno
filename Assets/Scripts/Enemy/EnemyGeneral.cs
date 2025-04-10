using UnityEngine;

public class EnemyGeneral : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health = 0;

    [SerializeField] private EnemyBehaviourBase enemyBehaviour;

    [SerializeField] private GameObject player;

    [SerializeField] private bool tilts;

    void FixedUpdate()
    {
        if (transform.position.x > 20 || transform.position.x < -20 || transform.position.y > 20 || transform.position.y < -20)
        {
            GetComponent<BatchChild>().Deactivate();
        }

        if (tilts)
        {
            transform.rotation = Quaternion.Euler(0, 0, -enemyBehaviour.rb.linearVelocity.x);
        }
    }

    private void OnEnable()
    {
        health = maxHealth;
    }

    public void OnHit()
    {
        health--;
        if (health <= 0) Death();
    }

    public void Death()
    {
        player?.GetComponent<PlayerManager>().Kill();
        enemyBehaviour.OnDeath();
        GetComponent<BatchChild>().Deactivate();
    }
}

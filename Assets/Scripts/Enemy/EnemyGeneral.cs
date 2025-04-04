using UnityEngine;

public class EnemyGeneral : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health = 0;

    [SerializeField] private EnemyBehaviourBase enemyBehaviour;

    [SerializeField] private GameObject player;

    void FixedUpdate()
    {
        if (transform.position.x > 20 || transform.position.x < -20 || transform.position.y > 20 || transform.position.y < -20)
        {
            GetComponent<BatchChild>().Deactivate();
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

    void OnMouseDown()
    {
        Death();
    }
}

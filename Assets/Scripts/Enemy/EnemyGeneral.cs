using UnityEngine;

public class EnemyGeneral : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health = 0;

    [SerializeField] private EnemyBehaviourBase enemyBehaviour;

    [SerializeField] private GameObject player;

    private void OnBecameInvisible()
    {
        GetComponent<BatchChild>().Deactivate();
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

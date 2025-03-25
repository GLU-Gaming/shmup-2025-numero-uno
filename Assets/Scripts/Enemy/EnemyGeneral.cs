using UnityEngine;

public class EnemyGeneral : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health = 0;

    [SerializeField] private EnemyBehaviourBase enemyBehaviour;

    private void OnBecameInvisible()
    {
        GetComponent<BatchChild>().Deactivate();
    }

    public void OnHit()
    {
        health--;
        if (health <= 0) Death();
    }

    public void Death()
    {
        enemyBehaviour.OnDeath();
        GetComponent<BatchChild>().Deactivate();
    }

    void OnMouseDown()
    {
        Death();
    }
}

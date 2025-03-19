using UnityEngine;

public class EnemyGeneral : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health = 0;

    private void OnTriggerEnter(Collider other)
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
        GetComponent<BatchChild>().Deactivate();
    }
}

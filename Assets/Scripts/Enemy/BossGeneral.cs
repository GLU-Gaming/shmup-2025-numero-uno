using UnityEngine;

public class BossGeneral : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health = 0;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
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
        gameObject.SetActive(false);
    }
}

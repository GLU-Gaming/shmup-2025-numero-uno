using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform EnemySpawn;
    public float timer = 0;
    void Start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 4)
        {
            timer = 0;

            GameObject enemy = Instantiate(enemyPrefab, EnemySpawn.position, EnemySpawn.rotation);
        }
    }
}

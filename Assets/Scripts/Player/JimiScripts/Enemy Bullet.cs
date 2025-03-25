using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBullet : MonoBehaviour
{
    public float shootTimer = 0;
    public GameObject bulletobj;
    public Transform bulletspawn;
    void Start()
    {
        
    }

    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer > 1)
        {
            GameObject bullet = Instantiate(bulletobj, bulletspawn.position, bulletspawn.rotation);
            shootTimer = 0;
        }
   
    }
}

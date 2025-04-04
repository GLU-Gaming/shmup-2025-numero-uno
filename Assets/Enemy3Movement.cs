using UnityEngine;

public class Enemy3Movement : MonoBehaviour
{
    public float speed = 850f;
    public float timer = 0;
    public bool isMoving = false;
    public bool timerStart = false;
    public float shootTimer = 0;
    public GameObject bulletobj;
    public Transform bulletspawn1;
    public Transform bulletspawn2;
    public bool shootable1 = false;
    public bool shootable2 = false;
    public float EnemyHealth = 40;
    private Rigidbody rb;
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        //all fuctions called on spawn
        isMoving = true;  
        timerStart = true;
        shootable1 = true;
        shootable2 = true;
    }


    void Update()
    {

        if (isMoving)
        {
            transform.position += Vector3.left * speed * Time.deltaTime * 4;
        }

        if (isMoving == false)
        {
            transform.position += Vector3.left * 0 * Time.deltaTime;
        }

        if (timerStart == true)
        {
            timer += Time.deltaTime;
        }


        if (timer > 3)
        {
            isMoving = false;   
        }

        shootTimer += Time.deltaTime;
        if (shootTimer > 4 && shootable1)
        {
            Instantiate(bulletobj, bulletspawn1.position, bulletspawn1.rotation);
            shootable1 = false;
        }
        if (shootTimer > 4.5 && shootable2)
        {
            Instantiate(bulletobj, bulletspawn2.position, bulletspawn2.rotation);
            shootable2 = false;
        }
        if (shootTimer > 5)
        {
            Instantiate(bulletobj, bulletspawn1.position, bulletspawn1.rotation);
            shootable1 = true;
            shootable2 = true;

            shootTimer = 0;
        }




        if (EnemyHealth == 0)
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayBullet"))
        {
          
            EnemyHealth -= 1;
        }

    }
}


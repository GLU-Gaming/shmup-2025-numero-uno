using System;
using UnityEngine;

public class BulletHomin : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 200f;
    private Transform target;
    public float timer = 0;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (target == null)
            return;

        if (timer < 1)
        {
            // Calculate direction to the target
            Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
            direction.Normalize();

            // Calculate rotation step
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            transform.Rotate(0, 0, -rotateAmount * rotationSpeed * Time.deltaTime * 2);
        }

   

        transform.position += transform.up * speed * Time.deltaTime * 3 ;



        if (timer > 2)
        {
            Destroy(gameObject);
        }

    }
}
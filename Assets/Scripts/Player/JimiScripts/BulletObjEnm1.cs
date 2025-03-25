using UnityEngine;

public class BulletObjEnm1 : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float bulletSpeed;
    private float destroyTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(new Vector2(-1000, 0));
    }


    void Update()
    {
        destroyTimer += Time.deltaTime;
        if (destroyTimer > 1.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

      //  Destroy(gameObject);



    }

}

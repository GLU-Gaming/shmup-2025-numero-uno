using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody rb;
    [SerializeField] private Transform CurrentPoint;
    public float speed;
    public float UNspeed;
    public PlayerManager PlayerManager;
    [SerializeField]  private  float health = 7;


    void Start()
    {
       rb = GetComponent<Rigidbody>();
        CurrentPoint = PointB.transform;
    }


    void Update()
    {

        Debug.Log(CurrentPoint);
        Vector2 point = CurrentPoint.position - transform.position;
        if (CurrentPoint == PointB.transform)
        {
            rb.AddForce(new Vector2(0, UNspeed));
        }
        else
        {

            if (CurrentPoint == PointA.transform)
            {
                rb.AddForce(new Vector2(0, speed));
            }
        }



        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == PointB.transform)
        {
            CurrentPoint = PointA.transform;
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == PointA.transform)
        {
            CurrentPoint = PointB.transform;
        }

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayBullet"))
        {
            PlayerManager.Kill();
            health -= 1;
        }

    }
}

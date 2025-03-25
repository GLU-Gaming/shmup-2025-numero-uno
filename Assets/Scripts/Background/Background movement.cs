using UnityEngine;

public class Backgroundmovement : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed = 120;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(new Vector2(Speed , 0));
    }
    void Update()
    {
   
    }
}

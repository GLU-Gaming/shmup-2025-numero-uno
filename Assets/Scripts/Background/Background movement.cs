using UnityEngine;

public class Backgroundmovement : MonoBehaviour
{
    private Rigidbody rb;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(new Vector2(-120, 0));
    }
    void Update()
    {
   
    }
}

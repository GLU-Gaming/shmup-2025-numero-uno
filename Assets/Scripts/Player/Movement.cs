using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            {
                rb.AddForce(new Vector2(5, 0));
            }

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(0, 5));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            {
                rb.AddForce(new Vector2(-5, 0));
            }

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector2(0, -5));
        }



        if (Input.GetKey(KeyCode.Alpha6))
        {
            {
                rb.AddForce(new Vector2(5, 0));
            }

        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            rb.AddForce(new Vector2(0, 5));
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            {
                rb.AddForce(new Vector2(-5, 0));
            }

        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            rb.AddForce(new Vector2(0, -5));
        }
    }
}

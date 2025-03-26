using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private float shiftFactor;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Keypad8))
        {
            velocity += new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Keypad2))
        {
            velocity += new Vector3(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Keypad6))
        {
            velocity += new Vector3(1, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Keypad4))
        {
            velocity += new Vector3(-1, 0, 0);
        }

        velocity.Normalize();

        velocity *= speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity *= shiftFactor;
        }

        rb.linearVelocity = velocity;
    }
}

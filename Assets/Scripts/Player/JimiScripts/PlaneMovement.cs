using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float speed = 2f; // Units per second

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
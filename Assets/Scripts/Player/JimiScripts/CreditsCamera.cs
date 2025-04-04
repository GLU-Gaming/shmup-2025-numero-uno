using UnityEngine;

public class CreditsCamera : MonoBehaviour
{
    public float speed = 1f; // Speed at which the camera moves down

    void Update()
    {
     
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
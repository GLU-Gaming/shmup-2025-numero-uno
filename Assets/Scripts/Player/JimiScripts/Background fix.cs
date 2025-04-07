using UnityEngine;

public class Backgroundfix : MonoBehaviour
{
    public float resetX = 0f;         // X position to move back to
    public float thresholdX = -340f;  // X position threshold

    void Update()
    {
        if (transform.position.x <= thresholdX)
        {
            Vector3 newPos = transform.position;
            newPos.x = resetX;
            transform.position = newPos;
        }
    }
}

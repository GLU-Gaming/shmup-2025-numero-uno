using UnityEngine;

public class Backgroundfix : MonoBehaviour
{
    public float resetX = 0f;        
    public float thresholdX = -340f;  

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

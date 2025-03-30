using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HitboxIndicator : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject indicator;

    [SerializeField] float indicatorMaxSize;
    [SerializeField] float growFactor;
    [SerializeField] float constantGrowth;

    [SerializeField] RectTransform canvas;

    private float indicatorSize;

    void Start()
    {
        indicatorSize = 0;
    }

    void Update()
    {
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(player.transform.position);
        Vector2 finalPosition = new Vector2(viewportPosition.x * canvas.sizeDelta.x, viewportPosition.y * canvas.sizeDelta.y);
        indicator.transform.position = finalPosition * ((float)Screen.height / 1080);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            indicatorSize += (indicatorMaxSize - indicatorSize) * Time.deltaTime * growFactor + constantGrowth * Time.deltaTime;
            if (indicatorSize > indicatorMaxSize) indicatorSize = indicatorMaxSize;
        } else
        {
            indicatorSize -= indicatorSize * Time.deltaTime * growFactor + constantGrowth * Time.deltaTime;
            if (indicatorSize < 0) indicatorSize = 0;
        }

        indicator.transform.localScale = indicatorSize * new Vector3(1, 1, 1);
    }
}

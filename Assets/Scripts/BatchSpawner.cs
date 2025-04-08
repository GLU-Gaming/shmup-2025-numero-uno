using UnityEngine;

public class BatchSpawner : MonoBehaviour
{
    [SerializeField] Vector3[] XYT;
    private BatchManager batchManager;

    private uint index = 0;

    void Start()
    {
        batchManager = GetComponent<BatchManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (index < XYT.Length)
        {
            while (Time.timeSinceLevelLoad > XYT[index].z)
            {
                batchManager.Activate(new Vector3(XYT[index].x, XYT[index].y, 0), Quaternion.Euler(Vector3.zero));

                index++;
            }
        }
    }
}

using UnityEngine;

public class BatchManager : MonoBehaviour
{
    private ulong[] batches; // Each ulong represents 64 objects (1 = inactive, 0 = active)
    private GameObject[][] objects;
    [SerializeField] private GameObject prefab;

    [SerializeField] private int totalBatches;

    void Start()
    {
        batches = new ulong[totalBatches];
        objects = new GameObject[totalBatches][];

        // Initialize objects and set all bits to 1 (inactive)
        for (int i = 0; i < totalBatches; i++)
        {
            batches[i] = ulong.MaxValue;
            objects[i] = new GameObject[64];

            for (int j = 0; j < 64; j++)
            {
                objects[i][j] = Instantiate(prefab);
                objects[i][j].GetComponent<BatchChild>().batch = i;
                objects[i][j].GetComponent<BatchChild>().index = j;
                objects[i][j].GetComponent<BatchChild>().manager = this;
                objects[i][j].SetActive(false); // Start inactive
            }
        }
    }

    public GameObject Activate()
    {
        for (int i = 0; i < totalBatches; i++)
        {
            if (batches[i] != 0) // Check if there's any inactive object
            {
                int bitIndex = FindFirstInactive(i);
                if (bitIndex != -1)
                {
                    // Set bit to 0 (activate)
                    batches[i] &= ~(1UL << bitIndex);
                    objects[i][bitIndex].SetActive(true);
                    return objects[i][bitIndex];
                }
            }
        }

        Debug.LogError("ERROR: No Objects Available, Increase Batch Count");

        return null; // No available object
    }

    public GameObject Activate(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < totalBatches; i++)
        {
            if (batches[i] != 0) // Check if there's any inactive object
            {
                int bitIndex = FindFirstInactive(i);
                if (bitIndex != -1)
                {
                    // Set bit to 0 (activate)
                    batches[i] &= ~(1UL << bitIndex);
                    objects[i][bitIndex].SetActive(true);
                    objects[i][bitIndex].transform.position = position;
                    objects[i][bitIndex].transform.rotation = rotation;
                    return objects[i][bitIndex];
                }
            }
        }

        Debug.LogError("ERROR: No Objects Available, Increase Batch Count For [" + prefab.name + "] In [" + gameObject.name + "]");

        return null; // No available object
    }

    // Deactivate a specific object (set bit to 1)
    public void Deactivate(int batch, int index)
    {
        // Set bit to 1 (deactivate)
        batches[batch] |= (1UL << index);
    }

    // Binary search to find the first available bit (bit set to 1)
    private int FindFirstInactive(int batchIndex)
    {
        ulong value = batches[batchIndex];

        int left = 0;
        int right = 63;

        while (left < right)
        {
            int mid = (left + right) / 2;

            // Check if there's any active bit in the left half (from left to mid)
            if ((value & ((1UL << (mid + 1)) - 1)) != 0)
                right = mid;  // There is an active bit in the left half, move the search to the left
            else
                left = mid + 1;  // No active bit in the left half, move the search to the right
        }

        return left;
    }

    void OnMouseDown()
    {
        Activate(new Vector3(14.5f, 0f, 0f), Quaternion.Euler(Vector3.zero));
    }
}

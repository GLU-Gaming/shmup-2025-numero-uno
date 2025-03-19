using UnityEngine;

public class BatchChild : MonoBehaviour
{
    public int batch = -1;
    public int index = -1;
    public BatchManager manager = null;

    public void Deactivate()
    {
        manager.Deactivate(batch, index);
        gameObject.SetActive(false);
    }
}

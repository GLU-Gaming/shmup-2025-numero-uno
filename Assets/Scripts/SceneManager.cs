using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float bulletSpeed;
    private float destroyTimer = 0f;



    public void Play()
    {
        SceneManager.LoadScene(1);
    }


}

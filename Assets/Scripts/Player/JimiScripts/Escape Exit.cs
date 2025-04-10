using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeExit : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

}

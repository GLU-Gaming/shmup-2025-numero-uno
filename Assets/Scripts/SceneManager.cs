using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{




    public void Play()
    {
        SceneManager.LoadScene(1);
    }



    public void QuitGame()
    {
        Application.Quit();
    }


}

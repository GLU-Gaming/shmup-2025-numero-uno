using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{




    public void Play()
    {
        SceneManager.LoadScene(1);
        Debug.Log("test play");
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("test menu");
    }

    public void credits()
    {
        SceneManager.LoadScene(4);
        Debug.Log("test credits");
    }


    public void QuitGame()
    {
        Application.Quit();
    }


}

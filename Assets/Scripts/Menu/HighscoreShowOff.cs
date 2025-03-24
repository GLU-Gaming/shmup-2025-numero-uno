using TMPro;
using UnityEngine;

public class HighscoreShowOff : MonoBehaviour
{
    public float OLDHighscore = 0;
    [SerializeField] TMP_Text OLDHighscoreTXT;
    void Start()
    {
        OLDHighscore = PlayerPrefs.GetFloat("Highscore");
    }


    void Update()
    {
        OLDHighscoreTXT.text = "HighScore:" + " " + OLDHighscore;
    }
}

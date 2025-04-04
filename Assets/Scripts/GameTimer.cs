using UnityEngine;
using TMPro;
public class GameTimer : MonoBehaviour
{
   public float timerFull = 180;
    public float playerHealth = 5;
    [SerializeField] TMP_Text Timer;
    void Start()
    {
        Timer.text = "Time : " + timerFull;
    }


    void Update()
    {
        timerFull -= Time.deltaTime;
        Timer.text = "Time : " + timerFull;


        if (timerFull < 0)
        {
            //start bossfight
        }
    }
}

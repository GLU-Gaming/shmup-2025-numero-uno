using UnityEngine;
using TMPro;
public class GameTimer : MonoBehaviour
{
    public float timerFull = 180;
    public float playerHealth = 5;
    [SerializeField] TMP_Text Timer;

    [SerializeField] GameObject boss;

    private bool canStartBoss;
    void Start()
    {
        Timer.text = "Time : " + (int)timerFull;
        canStartBoss = true;
    }


    void Update()
    {
        timerFull -= Time.deltaTime;
        Timer.text = "Time : " + (int)timerFull;


        if (canStartBoss && timerFull < 0)
        {
            //start bossfight
            boss.SetActive(true);

            canStartBoss = false;
        }
    }
}

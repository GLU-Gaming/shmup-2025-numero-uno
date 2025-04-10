using UnityEngine;


public class Hiding : MonoBehaviour
{
    float timer = 0;


    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;



        if (timer > 3)
        {
            gameObject.SetActive(false);
        }
    }
}
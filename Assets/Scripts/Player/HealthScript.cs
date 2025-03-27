using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 10;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;
    public GameObject health6;
    public GameObject health7;
    public GameObject health8;
    public GameObject health9;
    public GameObject health10;

    public GameObject midhealth7;
    public GameObject midhealth8;
    public GameObject midhealth9;
    public GameObject midhealth10;

    public GameObject lowhealth9;
    public GameObject lowhealth10;

    public float lowhealthTimer = 0;
    public bool lowOnHealth = false;
    public bool LastLife = false;

    public void Start()
    {
        midhealth7.SetActive(false);
        midhealth8.SetActive(false);
        midhealth9.SetActive(false);
        midhealth10.SetActive(false);
        lowhealth9.SetActive(false);
        lowhealth10.SetActive(false);
    }
    public void healthtest()
    {
        health -= 1;

        healthupdate();

        
    }

    private void Update()
    {
        if (lowOnHealth == true)
        {
            lowhealthTimer += Time.deltaTime;

            if (lowhealthTimer > 0.4)
            {
                lowhealth10.SetActive(false);
                if (LastLife == false)
                {
                    lowhealth9.SetActive(false);
                }
            }

            if (lowhealthTimer > 0.8)
            {
                lowhealth10.SetActive(true);
                if (LastLife == false)
                {
                    lowhealth9.SetActive(true);
                }
          
                lowhealthTimer = 0;
            }
        }
    }


    public void healthupdate()
    {
        if (health < 10)
        {
            health1.SetActive(false);
        }

        if (health < 9)
        {
            health2.SetActive(false);
        }

        if (health < 8)
        {
            health3.SetActive(false);
        }

        if (health < 7)
        {
            health4.SetActive(false);
        }
        if (health < 6)
        {
            health5.SetActive(false);
        }
        if (health < 5)
        {
            health6.SetActive(false);
            health8.SetActive(false);
            health9.SetActive(false);
            health10.SetActive(false);
            health7.SetActive(false);
            midhealth7.SetActive(true);
            midhealth8.SetActive(true);
            midhealth9.SetActive(true);
            midhealth10.SetActive(true);
        }
        if (health < 4)
        {
            midhealth7.SetActive(false);
        }
        if (health < 3)
        {
            midhealth8.SetActive(false);
            midhealth9.SetActive(false);
            midhealth10.SetActive(false);
            lowhealth10.SetActive(true);
            lowhealth9.SetActive(true);

            lowOnHealth = true;
        }
        if (health < 2)
        {
            LastLife = true;
            lowhealth9.SetActive(false);
        }
        if (health < 1)
        {

            lowOnHealth = false;
            lowhealth10.SetActive(false);
        }
    }
}

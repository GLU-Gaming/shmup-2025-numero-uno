using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player;
    public float playerHealth = 5;
    [SerializeField] TMP_Text PlayerHealthTXT;
    [SerializeField] TMP_Text HighscoreTXT;
    [SerializeField] TMP_Text OLDHighscoreTXT;
    [SerializeField] private GameObject bulletManagerHolder;
    private BatchManager bulletManager;
    public bool canshoot = true;
    public float shootTimer = 0;
    public int Highscore = 0;
    public int OLDHighscore = 0;
    public HealthScript healthScript;

    [SerializeField] Vector3 spawnPos;

    [SerializeField] float invincibilityTime;
    
    private float invincibilityTimer;
    private bool invincible = true;

    [SerializeField] float haloWobbleSpeed;
    private float haloWobbleTimer;

    [SerializeField] float haloWobbleAmplitude;

    [SerializeField] GameObject halo;

    private void Start()
    {
        PlayerHealthTXT.text = "HP:" + playerHealth;
        HighscoreTXT.text = "Score:" + " " + Highscore + "00";
        OLDHighscore = PlayerPrefs.GetInt("Highscore");
        OLDHighscoreTXT.text = "HighScore:" + " " + OLDHighscore + "00";

        invincibilityTimer = invincibilityTime;

        bulletManager = bulletManagerHolder.GetComponent<BatchManager>();

        haloWobbleTimer = 0;
    }

    private void Update()
    {
        haloWobbleTimer += haloWobbleSpeed * Time.deltaTime;

        halo.transform.rotation = Quaternion.Euler(90 + haloWobbleAmplitude * math.sin(haloWobbleTimer), -90 + haloWobbleAmplitude * math.cos(haloWobbleTimer), 0);

        if (shootTimer > 0.15)
        {
            canshoot = true;
            shootTimer = 0;
        }


        if (canshoot == true)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                bulletManager.Activate(transform.position, transform.rotation);
                canshoot = false;
            }
        }

        if (canshoot == false)
        {
            shootTimer += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (invincible)
        {
            transform.GetChild(0).gameObject.SetActive((Time.frameCount & 0xf) < 8);
            invincibilityTimer -= Time.deltaTime;

            if (invincibilityTimer < 0)
            {
                invincible = false;
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyProjectile"))
        {
            OnHit();

            if (other.gameObject.CompareTag("EnemyProjectile"))
            {
                other.gameObject.GetComponent<BatchChild>().Deactivate();
            }
        }
    }

    public void OnHit()
    {
        if (!invincible)
        {
            if (playerHealth <= 0)
            {
                SceneManager.LoadScene("LoseScreen");
            } 
            else
            {
                playerHealth -= 1;
                healthScript.healthtest();
                PlayerHealthTXT.text = "HP:" + playerHealth;
            }

            transform.position = spawnPos;

            invincible = true;
            invincibilityTimer = invincibilityTime;
        }
    }

    public void Kill()
    {
        Highscore += 1;

        SaveData();

        HighscoreTXT.text = "Score:" + " " + Highscore + "00";
        OLDHighscoreTXT.text = "HighScore:" + " " + OLDHighscore + "00";
    }    

    public void SaveData()
    {
        if (Highscore > OLDHighscore)
        {
            OLDHighscore = Highscore;
            PlayerPrefs.SetInt("Highscore", Highscore);
        }
    }

}

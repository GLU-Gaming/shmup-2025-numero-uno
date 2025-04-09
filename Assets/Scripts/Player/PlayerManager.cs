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


    [SerializeField] private AudioClip  ShootSFX;
    [SerializeField] private AudioClip hitSFX;

    [SerializeField] float invincibilityTime;
    
    private float invincibilityTimer;
    private bool invincible = true;

    [SerializeField] float haloWobbleSpeed;
    private float haloWobbleTimer;

    private AudioSource audioSource;


    [SerializeField] float haloWobbleAmplitude;

    [SerializeField] GameObject halo;
    [SerializeField] GameObject shieldObj;

    private bool shield = true;

    [SerializeField] float shieldCooldown;
    private float shieldTimer;

    [SerializeField] GameObject lazerObj;

    private bool lazer = false;

    [SerializeField] float lazerCooldown;
    private float lazerTimer;

    private float lazerActiveTimer;
    [SerializeField] float lazerActive;

    [SerializeField] GameObject lazerIndicator;

    private void Start()
    {
        PlayerHealthTXT.text = "HP:" + playerHealth;
        HighscoreTXT.text = "Score:" + " " + Highscore + "00";
        OLDHighscore = PlayerPrefs.GetInt("Highscore");
        OLDHighscoreTXT.text = "HighScore:" + " " + OLDHighscore + "00";

        invincibilityTimer = invincibilityTime;

        bulletManager = bulletManagerHolder.GetComponent<BatchManager>();

        haloWobbleTimer = 0;

        lazerTimer = 0;
        lazerActiveTimer = 0;

        audioSource = GetComponent<AudioSource>();
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


        if (canshoot)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                bulletManager.Activate(transform.position, transform.rotation);
                canshoot = false;
                audioSource.clip = ShootSFX;
                audioSource.Play();
            }
        } else 
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

        if (!Input.GetKey(KeyCode.LeftShift) && !shield) 
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer < 0)
            {
                shield = true;
            }
        }

        shieldObj.SetActive(shield && Input.GetKey(KeyCode.LeftShift));

        if (Input.GetKey(KeyCode.Z))
        {
            lazerTimer += Time.deltaTime;

            if (lazerTimer > lazerCooldown)
            {
                lazer = true;
            }
        } else
        {
            lazerTimer = 0;

            if (lazer)
            {
                lazerActiveTimer = lazerActive;
                lazer = false;
            }
        }

        lazerIndicator.SetActive(lazer);

        lazerObj.SetActive(lazerActiveTimer > 0);
        lazerActiveTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("PlayBullet") && (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyProjectile") || other.gameObject.CompareTag("EnemyLazer")))
        {
            OnHit(other);

            if (other.gameObject.CompareTag("EnemyProjectile"))
            {
                other.gameObject.GetComponent<BatchChild>().Deactivate();
            }
        }
    }

    public void OnHit(Collider other)
    {
        if (!invincible)
        {
            if (other.gameObject.CompareTag("EnemyLazer"))
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
            } else if (shield && Input.GetKey(KeyCode.LeftShift))
            {
                shield = false;

                shieldTimer = shieldCooldown;

                other.gameObject.GetComponent<BatchChild>().Deactivate();
            }
            else
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
                    audioSource.clip = hitSFX;
                    audioSource.Play();
                }

                transform.position = spawnPos;

                invincible = true;
                invincibilityTimer = invincibilityTime;
            }
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
